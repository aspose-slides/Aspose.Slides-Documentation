---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 730
url: /python-net/api-reference/aspose.slides.charts/idatalabel/
---

Represents a series labels.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IDataLabel

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IDataLabel type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|is_visible|False means that data label is not visible (and so all Show*-flags (ShowValue, ...) are false).<br/>            Read-only bool.|
|data_label_format|Returns format of the data label.<br/>            Read-only [IDataLabelFormat](/python-net/api-reference/aspose.slides.charts/idatalabelformat/).|
|value_from_cell|Gets or sets workbook data cell. Applied if IDataLabelFormat.ShowLabelValueFromCell property equals true.|
|as_ilayoutable|Returns ILayoutable interface.<br/>            Read-only [ILayoutable](/python-net/api-reference/aspose.slides.charts/ilayoutable/).|
|as_ioverridable_text|Returns IOverridableText interface.<br/>            Read-only [IOverridableText](/python-net/api-reference/aspose.slides.charts/ioverridabletext/).|
|as_iactual_layout|Returns IActualLayout interface.|
|x|Specifies the x location (left) of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|y|Specifies the top of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|width|Specifies the width of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|height|Specifies the height of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|right|Gets the right of the chart element as a fraction of the width of the chart.<br/>            Read-only|
|bottom|Gets the top of the chart element as a fraction of the height of the chart.<br/>            Read-only|
|chart|Returns the chart.<br/>            Read-only [IChart](/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
|text_frame_for_overriding|Can contain a rich formatted text. If this property is not null then this <br/>            formatted text value overrides auto-generated text.<br/>            Auto-generated text is an implicit property of the data label, the display <br/>            unit label of the value axis, the axis title, the chart title, the label of the trendline.<br/>            Auto-generated text is formatted with the IFormattedTextContainer.TextFormat property.<br/>            Read-only [ITextFrame](/python-net/api-reference/aspose.slides/itextframe/).|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|text_format|Returns chart text format.<br/>            Read-only [IChartTextFormat](/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|actual_x|Specifies actual x location (left) of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_y|Specifies actual top of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_width|Specifies actual width of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_height|Specifies actual height of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|hide()|Make data label hidden by setting all Show*-flags (ShowValue, ...) to false state.<br/>            IsVisible will be false after this.|
|get_actual_label_text()|Returns actual label text based on DataLabelFormat settings or TextFrameForOverriding.Text value.|
|add_text_frame_for_overriding(text)|Initialize TextFrameForOverriding with the text in paramener "text".<br/>            If TextFrameForOverriding is already initialized then simply changes its text.|
