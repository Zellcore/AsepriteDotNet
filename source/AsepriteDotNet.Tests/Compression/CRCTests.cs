/* -----------------------------------------------------------------------------
Copyright 2022 Christopher Whitley

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
----------------------------------------------------------------------------- */
using AsepriteDotNet.Compression;

using System.Text;

namespace AsepriteDotNet.Tests;

public class CRCTests
{
    [Fact]
    public void CRC_Test()
    {
        CRC crc = new();
        Assert.Equal(0xC061813AU, crc.Update(Encoding.UTF8.GetBytes("It may be that the gulfs will wash us down, ")));
        Assert.Equal(0xAE0CCA93U, crc.Update(Encoding.UTF8.GetBytes("It may be we shall touch the Happy Isles, ")));
        Assert.Equal(0x00EA1BBDU, crc.Update(Encoding.UTF8.GetBytes("and though We are not now that strength ")));
        Assert.Equal(0x0436A1DFU, crc.Update(Encoding.UTF8.GetBytes("which in old days Moved earth and heaven, ")));
        Assert.Equal(0x5CC83E5DU, crc.Update(Encoding.UTF8.GetBytes("that which we are, we are.")));

        Assert.Equal(0x5CC83E5DU, crc.CurrentValue);
    }
}