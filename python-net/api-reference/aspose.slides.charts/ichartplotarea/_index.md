---
title: IChartPlotArea Class
type: docs
weight: 620
url: /python-net/api-reference/aspose.slides.charts/ichartplotarea/
---

Represents chart title properties.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IChartPlotArea



The IChartPlotArea type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|format|Returns the format of a plot area.<br/>            Read-only [IFormat](/slides/python-net/api-reference/aspose.slides.charts/iformat/).|
|as_ilayoutable|Allows to get base ILayoutable interface.<br/>            Read-only [ILayoutable](/slides/python-net/api-reference/aspose.slides.charts/ilayoutable/).|
|as_iactual_layout|Returns IActualLayout interface.|
|layout_target_type|If layout of the plot area defined manually this property specifies whether <br/>             to layout the plot area by its inside (not including axis and axis labels) or outside<br/>             (including axis and axis labels).<br/>             Read/write [layout_target_type](/slides/python-net/api-reference/aspose.slides.charts/ichartplotarea/).|
|x|Specifies the x location (left) of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|y|Specifies the top of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|width|Specifies the width of the chart element as a fraction of the width of the chart.<br/>            Read/write|
|height|Specifies the height of the chart element as a fraction of the height of the chart.<br/>            Read/write|
|right|Gets the right of the chart element as a fraction of the width of the chart.<br/>            Read-only|
|bottom|Gets the top of the chart element as a fraction of the height of the chart.<br/>            Read-only|
|as_ichart_component|Allows to get base IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|chart|Returns the chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
|actual_x|Specifies actual x location (left) of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_y|Specifies actual top of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_width|Specifies actual width of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_height|Specifies actual height of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
