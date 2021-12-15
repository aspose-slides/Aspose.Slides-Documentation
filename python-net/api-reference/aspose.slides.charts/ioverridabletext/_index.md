---
title: IOverridableText Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 890
url: /python-net/api-reference/aspose.slides.charts/ioverridabletext/
---

Represents overridable text for a chart.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IOverridableText

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IOverridableText type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|text_frame_for_overriding|Can contain a rich formatted text. If this property is not null then this <br/>            formatted text value overrides auto-generated text.<br/>            Auto-generated text is an implicit property of the data label, the display <br/>            unit label of the value axis, the axis title, the chart title, the label of the trendline.<br/>            Auto-generated text is formatted with the IFormattedTextContainer.TextFormat property.<br/>            Read-only [ITextFrame](/python-net/api-reference/aspose.slides/itextframe/).|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|text_format|Returns chart text format.<br/>            Read-only [IChartTextFormat](/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|as_ichart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|chart|Returns the chart.<br/>            Read-only [IChart](/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_text_frame_for_overriding(text)|Initialize TextFrameForOverriding with the text in paramener "text".<br/>            If TextFrameForOverriding is already initialized then simply changes its text.|
