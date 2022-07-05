---
title: Axis
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 30
url: /python-net/api-reference/aspose.slides.charts/axis/
---

## Axis class

Encapsulates the object that represents a chart's axis.

The Axis type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|chart|Returns the parent chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|axis_between_categories|Represents if the value axis crosses the category axis between categories.<br/>             This property applies only to category axes, and it doesn't apply to 3-D charts.<br/>             Read/write bool.|
|category_axis_type|Specifies the type of the category axis.<br/>            Read/write [CategoryAxisType](/slides/python-net/api-reference/aspose.slides.charts/categoryaxistype/).|
|cross_at|Represents the point on the axis where the perpendicular axis crosses it.<br/>             Read/write|
|display_unit|Specifies the scaling value of the display units for the value axis.<br/>             Read/write [DisplayUnitType](/slides/python-net/api-reference/aspose.slides.charts/displayunittype/).|
|actual_max_value|Specifies actual maximum value on the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|actual_min_value|Specifies actual minimum value on the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|actual_major_unit|Specifies actual major unit of the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|actual_minor_unit|Specifies actual minor unit of the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|actual_major_unit_scale|Specifies actual major unit scale of the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|actual_minor_unit_scale|Specifies actual minor unit scale of the axis. Call method IChart.ValidateChartLayout() previously to get actual value.|
|is_automatic_max_value|Indicates whether the max value is automatically assigned.<br/>             Read/write bool.|
|max_value|Represents the maximum value on the value axis.<br/>             Read/write float.|
|minor_unit|Represents the minor units for the date or value axis.<br/>             Read/write float.|
|is_automatic_minor_unit|Indicates whether the minor unit of the axis is automatically assigned.<br/>             Read/write bool.|
|major_unit|Represents the major units for the date or value axis.<br/>             Read/write float.|
|is_automatic_major_unit|Indicates whether the major unit of the axis is automatically assigned. <br/>            Read/write bool.|
|is_automatic_min_value|Indicates whether the min value is automatically assigned.<br/>             Read/write bool.|
|min_value|Represents the minimum value on the value axis.<br/>             Read/write float.|
|is_logarithmic|Represents if the value axis scale type is logarithmic or not.<br/>             Read/write bool.|
|log_base|Represents the logarithmic base. Default value is 10.<br/>             Read/write float.|
|is_plot_order_reversed|Represents if MS PowerPoint plots data points from last to first.<br/>             Read/write bool.|
|is_visible|Represents if the axis is visible.<br/>             Read/write bool.|
|major_tick_mark|Represents the type of major tick mark for the specified axis.<br/>             Read/write [TickMarkType](/slides/python-net/api-reference/aspose.slides.charts/tickmarktype/).|
|minor_tick_mark|Represents the type of minor tick mark for the specified axis.<br/>             Read/write [TickMarkType](/slides/python-net/api-reference/aspose.slides.charts/tickmarktype/).|
|tick_label_position|Represents the position of tick-mark labels on the specified axis.<br/>             Read/write [TickLabelPositionType](/slides/python-net/api-reference/aspose.slides.charts/ticklabelpositiontype/).|
|major_unit_scale|Represents the major unit scale for the date axis.<br/>             Read/write [TimeUnitType](/slides/python-net/api-reference/aspose.slides.charts/timeunittype/).|
|minor_unit_scale|Represents the major unit scale for the date axis.<br/>             Read/write [TimeUnitType](/slides/python-net/api-reference/aspose.slides.charts/timeunittype/).|
|base_unit_scale|Specifies the smallest time unit that is represented on the date axis.<br/>            Read/write [TimeUnitType](/slides/python-net/api-reference/aspose.slides.charts/timeunittype/).|
|minor_grid_lines_format|Represents minor gridlines format on a chart axis.<br/>             Read-only [IChartLinesFormat](/slides/python-net/api-reference/aspose.slides.charts/ichartlinesformat/).|
|major_grid_lines_format|Represents major gridlines format on a chart axis.<br/>             Read-only [IChartLinesFormat](/slides/python-net/api-reference/aspose.slides.charts/ichartlinesformat/).|
|show_minor_grid_lines|To hide minor gridline set MinorGridLinesFormat.Line.FillFormat.FillType to FillType.NoFill.<br/>            Read-only bool.|
|show_major_grid_lines|To hide major gridline set MajorGridLinesFormat.Line.FillFormat.FillType to FillType.NoFill.<br/>            Read-only bool.|
|format|Represents format of axis.<br/>             Read-only [IAxisFormat](/slides/python-net/api-reference/aspose.slides.charts/iaxisformat/).|
|text_format|Represents format of text.<br/>             Read-only [IChartTextFormat](/slides/python-net/api-reference/aspose.slides.charts/icharttextformat/).|
|title|Gets the axis' title.<br/>             Read-only [IChartTitle](/slides/python-net/api-reference/aspose.slides.charts/icharttitle/).|
|cross_type|Represents the CrossType on the specified axis where the other axis crosses.<br/>             Read/write [CrossesType](/slides/python-net/api-reference/aspose.slides.charts/crossestype/).|
|position|Represents position of axis.<br/>             Read/write [AxisPositionType](/slides/python-net/api-reference/aspose.slides.charts/axispositiontype/).|
|has_title|Determines whether a axis has a visible title.<br/>            Read/write bool.|
|number_format|Represents the format string for the Axis Labels.<br/>            Read/write string.|
|is_number_format_linked_to_source|Indicates whether the format is linked source data.<br/>            Read/write bool.|
|tick_label_rotation_angle|Represents the rotation angle of tick labels.<br/>            Read/write|
|tick_label_spacing|Specifies how many tick labels to skip between label that is drawn. Applied to category or series axis.<br/>            Read/write int.|
|is_automatic_tick_label_spacing|Specifies automatic tick label spacing value. If false: use TickLabelSpacing property.<br/>            Read/write bool.|
|tick_marks_spacing|Specifies how many tick marks shall be skipped before the next one shall be <br/>            drawn. Applied to category or series axis.<br/>            Read/write int.|
|is_automatic_tick_marks_spacing|Specifies automatic tick marks spacing value. If false: use TickMarksSpacing property.<br/>            Read/write bool.|
|label_offset|Specifies the distance of labels from the axis. Applied to category or date axis. Value must be between 0% and 1000%.<br/>            Read/write int.|
|aggregation_type|Represents aggregation type of category axis (binning). Applied to category. Used with Histogram or HistogramPareto series only.|
|bin_width|Specifies bin width when AggregationType property value setted to AxisAggregationType.ByBinWidth. <br/>            Applied to category axes. Used with Histogram or HistogramPareto series only.|
|number_of_bins|Specifies number of bins when AggregationType property value setted to AxisAggregationType.ByNumberOfBins. <br/>            Applied to category axes. Used with Histogram or HistogramPareto series only.|
|is_overflow_bin|Specifies if overflow bin applied. Use IsAutomaticOverflowBin and OverflowBin to adjust overflow bin value.|
|is_automatic_overflow_bin|Specifies automatic overflow bin value. If false: use OverflowBin property.|
|overflow_bin|Specifies overflow bin custom value. Applied when IsAutomaticOverflowBin property setted to false and IsOverflowBin property equals true.|
|is_underflow_bin|Specifies if underflow bin applied. Use IsAutomaticUnderflowBin and UnderflowBin to adjust underflow bin value.|
|is_automatic_underflow_bin|Specifies automatic underflow bin value. If false: use UnderflowBin property.|
|underflow_bin|Specifies underflow bin custom value. Applied when IsAutomaticUnderflowBin property setted to false and IsUnderflowBin property equals true.|
|as_iformatted_text_container|Allows to get base IFormattedTextContainer interface.<br/>            Read-only [IFormattedTextContainer](/slides/python-net/api-reference/aspose.slides.charts/iformattedtextcontainer/).|
|as_ichart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
## Methods
| Name | Description |
| :- | :- |
|set_category_axis_type_automatically()|Sets IAxis.CategoryAxisType property with a value that is automatically determined based on axis data.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

