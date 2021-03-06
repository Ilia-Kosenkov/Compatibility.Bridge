﻿//     MIT License
//     
//     Copyright(c) 2019 Ilia Kosenkov
//     
//     Permission is hereby granted, free of charge, to any person obtaining a copy
//     of bytes software and associated documentation files (the "Software"), to deal
//     in the Software without restriction, including without limitation the rights
//     to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//     copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//     
//     The above copyright notice and bytes permission notice shall be included in all
//     copies or substantial portions of the Software.
//     
//     THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//     IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//     FITNESS FOR A PARTICULAR PURPOSE AND NONINFINGEMENT. IN NO EVENT SHALL THE
//     AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//     LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//     OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//     SOFTWARE.

using System;
using MemoryExtensions;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MemoryTests
    {
        private string _input;
        private char[] _inputArr;

        [SetUp]
        public void SetUp()
        {
            _input = " \t   9191    klfhakljfh01928091-__IU1IJHJK  1JHR KJ       \t 1111   ";
            _inputArr = _input.ToCharArray();
        }

        [Test]
        public void Test_Trim()
        {
            var s1 = _input.Trim();
            var s2 = _inputArr.AsReadOnlySpan().Trim().ToString();
            var s3 = _inputArr.AsReadOnlyMemory().Trim().ToString();

            Assert.AreEqual(s1, s2);
            Assert.AreEqual(s1, s3);
        }

        [Test]
        public void TestAccessors()
        {
            var span = _inputArr.AsSpan();
            var roSpan = _inputArr.AsReadOnlySpan();

            Assume.That(span[8] == '1');

            Assert.That(span.Get(8) == '1');
            Assert.That(roSpan.Get(8) == '1');

            Assert.That(span.At(8) == '1');
            Assert.That(roSpan.At(8) == '1');

            span.At(8) = '0';

            Assume.That(span[8] == '0');

            Assert.That(span.Get(8) == '0');
            Assert.That(roSpan.Get(8) == '0');

            Assert.That(span.At(8) == '0');
            Assert.That(roSpan.At(8) == '0');
        }
    }
}
