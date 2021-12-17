---
title: IBackground Class
type: docs
weight: 840
url: /python-net/api-reference/aspose.slides/ibackground/
---

Represents background of a slide.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IBackground

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IBackground type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|type|Returns a type of background fill.<br/>            Read/write [BackgroundType](/python-net/api-reference/aspose.slides/backgroundtype/).|
|fill_format|Returns a FillFormat for BackgroundType.OwnBackground fill.<br/>            Read-only [IFillFormat](/python-net/api-reference/aspose.slides/ifillformat/).|
|effect_format|Returns a EffectFormat for BackgroundType.OwnBackground fill.<br/>            Read-only [IEffectFormat](/python-net/api-reference/aspose.slides/ieffectformat/).|
|style_color|Returns a ColorFormat for a BackgroundType.Themed fill.<br/>            Read-only [IColorFormat](/python-net/api-reference/aspose.slides/icolorformat/).|
|style_index|Returns an index of BackgroundType.Themed fill in background theme collection.<br/>            0 means no fill.<br/>            1..999 - index.<br/>            Read/write int.|
|as_islide_component|Returns ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|as_ifill_param_source|Returns IFillParamSource interface.<br/>            Read-only [IFillParamSource](/python-net/api-reference/aspose.slides/ifillparamsource/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_effective()|Gets effective background data with the inheritance applied.|
