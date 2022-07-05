---
title: ChartPlotArea
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 220
url: /python-net/api-reference/aspose.slides.charts/chartplotarea/
---

## ChartPlotArea class

Represents rectangle where chart should be plotted.

The ChartPlotArea type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|format|Returns the format of a plot area.<br/>            Read-only [IFormat](/slides/python-net/api-reference/aspose.slides.charts/iformat/).|
|x|Returns or sets the x coordinate of the upper left corner of plot area bounding box as a fraction of the width of the chart (from 0 to 1).<br/>            Read/write|
|y|Returns or sets the y coordinate of the upper left corner of plot area bounding box as a fraction of the height of the chart (from 0 to 1).<br/>            Read/write|
|width|Returns or sets the width of a plot area bounding box as a fraction of the width of the chart (from 0 to 1).<br/>            Read/write|
|height|Returns or sets the height of a plot area bounding box as a fraction of the height of the chart (from 0 to 1).<br/>            Read/write|
|right|Right.<br/>            Read-only|
|bottom|Bottom.<br/>            Read-only|
|chart|Chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|is_location_autocalculated|Defines how location should be calculated: true – calculated automatically; defined by the X, Y, Width, Height properties.<br/>            Read-only bool.|
|layout_target_type|If layout of the plot area defined manually this property specifies whether <br/>             to layout the plot area by its inside (not including axis and axis labels) or outside<br/>             (including axis and axis labels).<br/>             Read/write [layout_target_type](/slides/python-net/api-reference/aspose.slides.charts/chartplotarea/).|
|actual_x|Specifies actual x location (left) of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_y|Specifies actual top of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_width|Specifies actual width of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_height|Specifies actual height of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|as_ilayoutable|Allows to get base ILayoutable interface.<br/>            Read-only [ILayoutable](/slides/python-net/api-reference/aspose.slides.charts/ilayoutable/).|
|as_iactual_layout|Returns IActualLayout interface.|
|as_ichart_component|Allows to get base IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

