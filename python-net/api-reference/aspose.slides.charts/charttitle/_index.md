---
title: ChartTitle Class
type: docs
weight: 280
url: /python-net/api-reference/aspose.slides.charts/charttitle/
---

Represents chart title properties.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.ChartTitle

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ChartTitle type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|x|Returns or sets the x coordinate of a title as a fraction of the width of the chart.<br/>            Read/write|
|y|Returns or sets the y coordinate of a title as a fraction of the height of the chart.<br/>            Read/write|
|width|Returns or sets the width of a title as a fraction of the width of the chart.<br/>            Read/write|
|height|Returns or sets the height of a title as a fraction of the height of the chart.<br/>            Read/write|
|right|Right.<br/>            Read-only|
|bottom|Bottom.<br/>            Read-only|
|overlay|Determines whether other chart elements shall be allowed to overlap title.<br/>            Read/write bool.|
|format|Returns the fill, line, effect styles of a title.<br/>            Read-only [IFormat](/slides/python-net/api-reference/aspose.slides.charts/iformat/).|
|text_frame_for_overriding|Can contain a rich formatted text. If this property is not null then this <br/>            formatted text value overrides auto-generated text.<br/>            Auto-generated text is an implicit property of the data label, the display <br/>            unit label of the value axis, the axis title, the chart title, the label of the trendline.<br/>            Auto-generated text is formatted with the IFormattedTextContainer.TextFormat property.<br/>            Read-only [ITextFrame](/slides/python-net/api-reference/aspose.slides/itextframe/).|
|text_format|Returns text format.<br/>            Read-only [IChartTextFormat](/slides/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|chart|Returns the parent chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_ilayoutable|Allows to get base ILayoutable interface.<br/>            Read-only [ILayoutable](/slides/python-net/api-reference/aspose.slides.charts/ilayoutable/).|
|as_ioverridable_text|Allows to get base IOverridableText interface.<br/>            Read-only [IOverridableText](/slides/python-net/api-reference/aspose.slides.charts/ioverridabletext/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/slides/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_text_frame_for_overriding(text)|Initialize TextFrameForOverriding with the text in paramener "text".<br/>            If TextFrameForOverriding is already initialized then simply changes its text.|
