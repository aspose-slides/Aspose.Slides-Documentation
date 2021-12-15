---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 530
url: /python-net/api-reference/aspose.slides.charts/ichartdatapoint/
---

Represents series data point.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IChartDataPoint

**Assembly:**  Aspose.Slides Version: 21.11.0.0

The IChartDataPoint type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|xvalue|Returns the x value of chart data point.<br/>            Read-only [IStringOrDoubleChartValue](/python-net/api-reference/aspose.slides.charts/istringordoublechartvalue/).|
|yvalue|Returns the y value of chart data point.<br/>            Read-only [IDoubleChartValue](/python-net/api-reference/aspose.slides.charts/idoublechartvalue/).|
|bubble_size|Returns the bubble size of chart data point.<br/>            Read-only [IDoubleChartValue](/python-net/api-reference/aspose.slides.charts/idoublechartvalue/).|
|value|Returns the value of chart data point.<br/>            Read-only [IDoubleChartValue](/python-net/api-reference/aspose.slides.charts/idoublechartvalue/).|
|size_value|Returns the size value of chart data point.<br/>            Used with Treemap and Sunburst charts. <br/>            Read-only [IDoubleChartValue](/python-net/api-reference/aspose.slides.charts/idoublechartvalue/).|
|color_value|Returns the color value of chart data point.<br/>            Used with Map charts. <br/>            Read-only [IDoubleChartValue](/python-net/api-reference/aspose.slides.charts/idoublechartvalue/).|
|error_bars_custom_values|Represents series error bars values in case of Custom value type.<br/>            Read-only [IErrorBarsCustomValues](/python-net/api-reference/aspose.slides.charts/ierrorbarscustomvalues/).|
|label|Represents the lable of chart data point.<br/>            Read-only [IDataLabel](/python-net/api-reference/aspose.slides.charts/idatalabel/).|
|is_bubble3_d|Specifies that the bubbles have a 3-D effect applied to them.<br/>            Read/write bool.|
|explosion|Specifies the amount the data point shall be moved from the center of the pie.<br/>            Read/write|
|format|Represents the formatting properties.<br/>            Read/write [IFormat](/python-net/api-reference/aspose.slides.charts/iformat/).|
|marker|Specifies a data marker.<br/>            Read-only [IMarker](/python-net/api-reference/aspose.slides.charts/imarker/).|
|related_legend_entry|Properties of corresponding legend entry in case of chart type from this list:<br/>            ChartType.BarOfPie,<br/>            ChartType.ExplodedPie,<br/>            ChartType.ExplodedPie3D,<br/>            ChartType.Pie,<br/>            ChartType.Pie3D,<br/>            ChartType.PieOfPie.<br/>            Read-only [ILegendEntryProperties](/python-net/api-reference/aspose.slides.charts/ilegendentryproperties/).|
|set_as_total|Sets data point as total. Applied for Waterfall series type only.|
|invert_if_negative|Specifies the data point shall invert its colors if the value is negative.<br/>            Read/write bool.|
|data_point_levels|Returns container of  data point levels. Applied for Treeamp and Sunburst series.<br/>            Data point levels indexing is zero-based.|
|as_iactual_layout|Returns IActualLayout interface.|
|actual_x|Specifies actual x location (left) of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_y|Specifies actual top of the chart element relative to the left top corner of the chart.<br/>            Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_width|Specifies actual width of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
|actual_height|Specifies actual height of the chart element. Call method IChart.ValidateChartLayout() before to get actual values. <br/>            Read|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Removes DataPoint from chart series.|
|get_automatic_data_point_color()|Returns an automatic color of data point based on series index, data point index, ParentSeriesGroup.IsColorVaried propery and chart style. <br/>            This color is used by default if FillType equals NotDefined.|
