---
title: ColorFormat Class
type: docs
weight: 230
url: /slides/python-net/api-reference/aspose.slides/colorformat/
---

Represents a color used in a presentation.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ColorFormat

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ColorFormat type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|color_type|Returns or sets the color definition method.<br/>            Read/write [ColorType](/python-net/api-reference/aspose.slides/colortype/).|
|color|Returns resulting color (with all color transformations applied).<br/>            Sets RGB colors and clears all color transformations.<br/>            Read/write aspose.pydrawing.Color.|
|preset_color|Returns or sets the color preset.<br/>            Read/write [PresetColor](/python-net/api-reference/aspose.slides/presetcolor/).|
|system_color|Returns or sets the color identified by the system color table.<br/>            Read/write [SystemColor](/python-net/api-reference/aspose.slides/systemcolor/).|
|scheme_color|Returns or sets the color identified by a color scheme.<br/>            Read/write [SchemeColor](/python-net/api-reference/aspose.slides/schemecolor/).|
|r|Returns or sets the red component of a color. All color transformations are ignored.<br/>            Read/write int.|
|g|Returns or sets the green component of a color. All color transformations are ignored.|
|b|Returns or sets the blue component of a color. All color transformations are ignored.<br/>            Read/write int.|
|float_r|Returns or sets the red component of a color. All color transformations are ignored.<br/>            Read/write|
|float_g|Returns or sets the green component of a color. All color transformations are ignored.<br/>            Read/write|
|float_b|Returns or sets the blue component of a color. All color transformations are ignored.<br/>            Read/write|
|hue|Returns or sets the hue component of a color in HSL representation.<br/>            All color transformations are ignored.<br/>            Read/write|
|saturation|Returns or sets the saturation component of a color in HSL representation.<br/>            All color transformations are ignored.<br/>            Read/write|
|luminance|Returns or sets the luminance component of a color in HSL representation.<br/>            All color transformations are ignored.<br/>            Read/write|
|color_transform|Returns the collection of color transformations applied to a color.<br/>            Read-only [IColorOperationCollection](/python-net/api-reference/aspose.slides/icoloroperationcollection/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
|as_ifill_param_source|Returns IFillParamSource interface.<br/>            Read-only [IFillParamSource](/python-net/api-reference/aspose.slides/ifillparamsource/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|to_string(format)|Returns a string that represents the current color format.|
|copy_from(color)|Copy color format from "color".|
