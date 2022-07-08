---
title: IChartTitle
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 710
url: /python-net/api-reference/aspose.slides.charts/icharttitle/
---

## IChartTitle class

Represents chart title properties.

The IChartTitle type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|overlay|Determines whether other chart elements shall be allowed to overlap title.<br/>            Read/write bool.|
|format|Returns the fill, line, effect styles of a title.<br/>            Read-only [IFormat](/slides/python-net/api-reference/aspose.slides.charts/iformat/).|
|as_i_layoutable|Allows to get base ILayoutable interface.<br/>            Read-only [ILayoutable](/slides/python-net/api-reference/aspose.slides.charts/ilayoutable/).|
|as_i_overridable_text|Allows to get base IOverridableText interface.<br/>            Read-only [IOverridableText](/slides/python-net/api-reference/aspose.slides.charts/ioverridabletext/).|
|x|Specifies the x location (left) of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|y|Specifies the top of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|width|Specifies the width of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|height|Specifies the height of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|right|Gets the right of the chart element as a fraction of the width of the chart.<br/>            Read-only|
|bottom|Gets the top of the chart element as a fraction of the height of the chart.<br/>            Read-only|
|chart|Returns the chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_i_slide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|text_frame_for_overriding|Can contain a rich formatted text. If this property is not null then this <br/>            formatted text value overrides auto-generated text.<br/>            Auto-generated text is an implicit property of the data label, the display <br/>            unit label of the value axis, the axis title, the chart title, the label of the trendline.<br/>            Auto-generated text is formatted with the IFormattedTextContainer.TextFormat property.<br/>            Read-only [ITextFrame](/slides/python-net/api-reference/aspose.slides/itextframe/).|
|as_i_formatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/slides/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|text_format|Returns chart text format.<br/>            Read-only [IChartTextFormat](/slides/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
## Methods
| Name | Description |
| :- | :- |
|add_text_frame_for_overriding(text)|Initialize TextFrameForOverriding with the text in paramener "text".<br/>            If TextFrameForOverriding is already initialized then simply changes its text.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

