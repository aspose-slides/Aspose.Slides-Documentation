---
title: IBackground
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 840
url: /python-net/api-reference/aspose.slides/ibackground/
---

## IBackground class

Represents background of a slide.

The IBackground type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|type|Returns a type of background fill.<br/>            Read/write [BackgroundType](/slides/python-net/api-reference/aspose.slides/backgroundtype/).|
|fill_format|Returns a FillFormat for BackgroundType.OwnBackground fill.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|effect_format|Returns a EffectFormat for BackgroundType.OwnBackground fill.<br/>            Read-only [IEffectFormat](/slides/python-net/api-reference/aspose.slides/ieffectformat/).|
|style_color|Returns a ColorFormat for a BackgroundType.Themed fill.<br/>            Read-only [IColorFormat](/slides/python-net/api-reference/aspose.slides/icolorformat/).|
|style_index|Returns an index of BackgroundType.Themed fill in background theme collection.<br/>            0 means no fill.<br/>            1..999 - index.<br/>            Read/write int.|
|as_i_slide_component|Returns ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|as_i_fill_param_source|Returns IFillParamSource interface.<br/>            Read-only [IFillParamSource](/slides/python-net/api-reference/aspose.slides/ifillparamsource/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
## Methods
| Name | Description |
| :- | :- |
|get_effective()|Gets effective background data with the inheritance applied.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

