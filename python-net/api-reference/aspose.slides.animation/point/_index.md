---
title: Point
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 390
url: /python-net/api-reference/aspose.slides.animation/point/
---

## Point class

Represent animation point.

The Point type exposes the following members:
## Constructors
| Name | Description |
| :- | :- |
|Point()|Default constructor.|
|Point(time, value, formula)|Initializes a new instance of the Point class|
## Properties
| Name | Description |
| :- | :- |
|time|Represents time value.<br/>            Read/write|
|value|Represents point value.<br/>            Only: bool, ColorFormat, float, int, string.<br/>            Read/write object.|
|formula|Formulas within values, from, to, by attributes can be made up of these:<br/>            Standard arithmetic operators: ‘+’, ‘-‘, ‘*’, ‘/’, ‘^’, ‘%’ (mod)<br/>            Constants: ‘pi’ ‘e’<br/>            Conditional operators: ‘abs’, ‘min’, ‘max’, ‘?’ (if)<br/>            Comparison operators: '==', '>=', '', '!=', '!'<br/>            Trigonometric operators: ‘sin()’, ‘cos()’, ‘tan()’, ‘asin()’, ‘acos()’, ‘atan()’<br/>            Natural logarithm ‘ln()’<br/>            Property references (host supported properties)<br/>            <br/>            for example: "#ppt_x+(cos(-2*pi*(1-$))*-#ppt_x-sin(-2*pi*(1-$))*(1-#ppt_y))*(1-$)"<br/>            Read/write string.|

### See Also

* namespace [aspose.slides.animation](/slides/python-net/api-reference/aspose.slides.animation/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

