---
title: {0} Enumeration - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 9360
url: /python-net/api-reference/aspose.slides/colortransformoperation/
---

Defines color transform operation.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Name:** aspose.slides.ColorTransformOperation

**Assembly:**  Aspose.Slides Version: 21.11.0.0

## **Members**
|**Member name**|**Value**|**Description**|
| :- | :- | :- |
|TINT|0|Tints the color. Parameter is in range between 0 (original color) and 1 (white).|
|SHADE|1|Shades the color. Parameter is in range between 0 (original color) and 1 (black).|
|COMPLEMENT|2|Changes the color to a RGB complementary one.<br/>            m = Max(r, g, b);<br/>            r = m - r;<br/>            g = m - g;<br/>            b = m - b;|
|INVERSE|3|Changes the color to an inverted color.<br/>            r = 1 - r;<br/>            g = 1 - g;<br/>            b = 1 - b;|
|GRAYSCALE|4|Changes the color to a gray one with same lightness. Parameter ignored.|
|SET_ALPHA|5|Defines an alpha component of the color. Parameter is in range between 0 (transparent) and 1 (opaque).|
|ADD_ALPHA|6|Adds a parameter's value to an alpha component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_ALPHA|7|Multiplies an alpha component to a parameter's value.|
|SET_HUE|8|Changes a hue component of the color to a parameter's value. Parameter is in range between 0 and 360.|
|ADD_HUE|9|Adds parameter's value to hue component of the color. Parameter is in range between -360 and 360.|
|MULTIPLY_HUE|10|Multiplies a hue component to a parameter's value.|
|SET_SATURATION|11|Changes a saturation component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_SATURATION|12|Adds a parameter's value to a saturation component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_SATURATION|13|Multiplies a saturation component to a parameter's value.|
|SET_LUMINANCE|14|Changes a luminance component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_LUMINANCE|15|Adds a parameter's value to a luminance component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_LUMINANCE|16|Multiplies a luminance component to a parameter's value.|
|SET_RED|17|Changes a red component of the color to a parameter's value. Parameter is in range between 0 and 1.|
|ADD_RED|18|Adds a parameter's value to a red component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_RED|19|Multiplies a red component to a parameter.|
|SET_GREEN|20|Changes a green component of the color to a parameter's value value. Parameter is in range between 0 and 1.|
|ADD_GREEN|21|Adds a parameter to a green component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_GREEN|22|Multiplies a green component of the color to a parameter's value.|
|SET_BLUE|23|Changes a blue component of the color to a parameter's value. Parameter is in range between 0 and 360.|
|ADD_BLUE|24|Adds a parameter's value to a blue component of the color. Parameter is in range between -1 and 1.|
|MULTIPLY_BLUE|25|Multiplies a blue component of the color to a parameter's value.|
|GAMMA|26|Gamma correction. Parameter ignored.|
|INVERSE_GAMMA|27|Inverse gamma correction. Parameter ignored.|
