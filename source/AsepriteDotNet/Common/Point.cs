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
using System.Diagnostics.CodeAnalysis;

namespace AsepriteDotNet;

/// <summary>
///     Represents an x- and y-coordinate point in a two dimensional plane.
/// </summary>
public struct Point : IEquatable<Point>
{

    /// <summary>
    ///     Represents a <see cref="Point"/> value who's x- and y-coordinate
    ///     elements are initialized to zero.
    /// </summary>
    public static readonly Point Empty;

    private int _x;
    private int _y;

    /// <summary>
    ///     Gets the x-coordinate element of this <see cref="Point"/>.
    /// </summary>
    public int X
    {
        readonly get => _x;
        set => _x = value;
    }

    /// <summary>
    ///     Gets the y-coordinate element of this <see cref="Point"/>.
    /// </summary>
    public int Y
    {
        readonly get => _y;
        set => _y = value;
    }

    /// <summary>
    ///     Initializes a new <see cref="Point"/> value.
    /// </summary>
    /// <param name="x">
    ///     The x-coordinate element of this <see cref="Point"/>.
    /// </param>
    /// <param name="y">
    ///     The y-coordinate element of this <see cref="Point"/>.
    /// </param>
    public Point(int x, int y) => (_x, _y) = (x, y);

    /// <summary>
    ///     Returns a value that indicates whether the specified 
    ///     <see cref="object"/> is equal to this <see cref="Point"/>.
    /// </summary>
    /// <param name="obj">
    ///     The <see cref="object"/> to check for equality with this 
    ///     <see cref="Point"/>.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the specified <see cref="object"/> is
    ///     equal to this <see cref="Point"/>; otherwise, 
    ///     <see langword="false"/>.
    /// </returns>
    public override bool Equals([NotNullWhen(true)] object? obj) => obj is Point other && Equals(other);

    /// <summary>
    ///     Returns a value that indicates whether the specified 
    ///     <see cref="Point"/> is equal to this <see cref="Point"/>.
    /// </summary>
    /// <param name="other">
    ///     The other <see cref="Point"/> to check for equality
    /// </param>
    /// <returns></returns>
    public bool Equals(Point other) => this == other;

    /// <summary>   
    ///     Returns the hash code for this <see cref="Point"/> value.
    /// </summary>
    /// <returns>
    ///     A 32-bit signed integer that is the hash code for this
    ///     <see cref="Point"/> value.
    /// </returns>
    public override readonly int GetHashCode() => HashCode.Combine(_x, _y);

    /// <summary>
    ///     Adds the x- and y-coordinate elements of two <see cref="Point"/>
    ///     values.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the addition
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side fo the addition
    ///     operator.
    /// </param>
    /// <returns>
    ///     A new <see cref="Point"/> value who's x- and y-coordinate elements
    ///     are the sum of the two <see cref="Point"/> values given.
    /// </returns>
    public static Point operator +(Point left, Point right) => Add(left, right);

    /// <summary>
    ///     Subtracts the x- and y-coordinate elements of one
    ///     <see cref="Point"/> value from another.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the subtraction
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side fo the subtraction
    ///     operator.
    /// </param>
    /// <returns>
    ///     A new <see cref="Point"/> value who's x- and y-coordinate elements
    ///     are the result of subtracting the x- and y-coordinate elements of the
    ///     <paramref name="right"/> <see cref="Point"/> from the x- and
    ///     y-coordinate elements of the <paramref name="left"/> 
    ///     <see cref="Point"/>.
    /// </returns>
    public static Point operator -(Point left, Point right) => Subtract(left, right);

    /// <summary>
    ///     Compares two <see cref="Point"/> values for equality.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the equality
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side of the equality
    ///     operator.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the two <see cref="Point"/> values are
    ///     equal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator ==(Point left, Point right) => left._x == right._x && left._y == right._y;

    /// <summary>
    ///     Compares two <see cref="Point"/> values for inequality.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the inequality
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side of the inequality
    ///     operator.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the two <see cref="Point"/> values are
    ///     unequal; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool operator !=(Point left, Point right) => !(left == right);

    /// <summary>
    ///     Adds the x- and y-coordinate elements of two <see cref="Point"/>
    ///     values.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the addition
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side fo the addition
    ///     operator.
    /// </param>
    /// <returns>
    ///     A new <see cref="Point"/> value who's x- and y-coordinate elements
    ///     are the sum of the two <see cref="Point"/> values given.
    /// </returns>
    public static Point Add(Point left, Point right) => new Point(unchecked(left._x + right._x), unchecked(left._y + right._y));

    /// <summary>
    ///     Subtracts the x- and y-coordinate elements of one
    ///     <see cref="Point"/> value from another.
    /// </summary>
    /// <param name="left">
    ///     The <see cref="Point"/> value on the left side of the subtraction
    ///     operator.
    /// </param>
    /// <param name="right">
    ///     The <see cref="Point"/> value on the right side fo the subtraction
    ///     operator.
    /// </param>
    /// <returns>
    ///     A new <see cref="Point"/> value who's x- and y-coordinate elements
    ///     are the result of subtracting the x- and y-coordinate elements of the
    ///     <paramref name="right"/> <see cref="Point"/> from the x- and
    ///     y-coordinate elements of the <paramref name="left"/> 
    ///     <see cref="Point"/>.
    /// </returns>
    public static Point Subtract(Point left, Point right) => new Point(unchecked(left._x - right._x), unchecked(left._y - right._y));
}