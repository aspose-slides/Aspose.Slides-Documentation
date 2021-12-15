---
title: Point Class
type: docs
weight: 390
url: /slides/python-net/api-reference/aspose.slides.animation/point/
---

Represent animation point.

**Namespace:** [aspose.slides.animation](/slides/python-net/api-reference/aspose.slides.animation/)

**Full Class Name:** aspose.slides.animation.Point

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The Point type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|Point()|Default constructor.|
|Point(time, value, formula)|Initializes a new instance of the Point class|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|time|Represents time value.<br/>            Read/write|
|value|Represents point value.<br/>            Only: bool, ColorFormat, float, int, string.<br/>            Read/write object.|
|formula|Formulas within values, from, to, by attributes can be made up of these:<br/>            Standard arithmetic operators: ‘+’, ‘-‘, ‘*’, ‘/’, ‘^’, ‘%’ (mod)<br/>            Constants: ‘pi’ ‘e’<br/>            Conditional operators: ‘abs’, ‘min’, ‘max’, ‘?’ (if)<br/>            Comparison operators: '==', '>=', '', '!=', '!'<br/>            Trigonometric operators: ‘sin()’, ‘cos()’, ‘tan()’, ‘asin()’, ‘acos()’, ‘atan()’<br/>            Natural logarithm ‘ln()’<br/>            Property references (host supported properties)<br/>            <br/>            for example: "#ppt_x+(cos(-2*pi*(1-$))*-#ppt_x-sin(-2*pi*(1-$))*(1-#ppt_y))*(1-$)"<br/>            Read/write string.|
