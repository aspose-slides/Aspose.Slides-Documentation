---
title: ColorTransformOperation
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 9270
url: /python-net/api-reference/aspose.slides/colortransformoperation/
---

## ColorTransformOperation enumeration

Defines color transform operation.

## Members
| Member name | Description |
| :- | :- |
|TINT|Tints the color. Parameter is in range between 0 (original color) and 1 (white).|
|SHADE|Shades the color. Parameter is in range between 0 (original color) and 1 (black).|
|COMPLEMENT|Changes the color to a RGB complementary one.<br/>            m = Max(r, g, b);<br/>            r = m - r;<br/>            g = m - g;<br/>            b = m - b;|
|INVERSE|Changes the color to an inverted color.<br/>            r = 1 - r;<br/>            g = 1 - g;<br/>            b = 1 - b;|
|GRAYSCALE|Changes the color to a gray one with same lightness. Parameter ignored.|
|SET_ALPHA|Defines an alpha component of the color. Parameter is in range between 0 (transparent) and 1 (opaque).|
|ADD_ALPHA|Adds a parameter's value to an alpha component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_ALPHA|Multiplies an alpha component to a parameter's value.|
|SET_HUE|Changes a hue component of the color to a parameter's value. Parameter is in range between 0 and 360.|
|ADD_HUE|Adds parameter's value to hue component of the color. Parameter is in range between -360 and 360.|
|MULTIPLY_HUE|Multiplies a hue component to a parameter's value.|
|SET_SATURATION|Changes a saturation component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_SATURATION|Adds a parameter's value to a saturation component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_SATURATION|Multiplies a saturation component to a parameter's value.|
|SET_LUMINANCE|Changes a luminance component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_LUMINANCE|Adds a parameter's value to a luminance component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_LUMINANCE|Multiplies a luminance component to a parameter's value.|
|SET_RED|Changes a red component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_RED|Adds a parameter's value to a red component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_RED|Multiplies a red component to a parameter.|
|SET_GREEN|Changes a green component of the color to a parameter's value value. Parameter is in range between 0 and 1.|
|ADD_GREEN|Adds a parameter to a green component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_GREEN|Multiplies a green component of the color to a parameter's value.|
|SET_BLUE|Changes a blue component of the color to a parameter's value. Parameter is in range between 0 and 360.|
|ADD_BLUE|Adds a parameter's value to a blue component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_BLUE|Multiplies a blue component of the color to a parameter's value.|
|GAMMA|Gamma correction. Parameter ignored.|
|INVERSE_GAMMA|Inverse gamma correction. Parameter ignored.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

