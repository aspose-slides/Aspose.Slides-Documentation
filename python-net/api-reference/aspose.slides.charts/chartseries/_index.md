---
title: ChartSeries Class
type: docs
weight: 240
url: /python-net/api-reference/aspose.slides.charts/chartseries/
---

Represents a chart series.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.ChartSeries

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ChartSeries type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|chart|Returns the parent chart.<br/>            Read-only [IChart](/python-net/api-reference/aspose.slides.charts/ichart/).|
|explosion|The distance of an open pie slice from the center of the pie chart is expressed as a percentage of the pie diameter.<br/>             Read/write|
|smooth|Represents curve smoothing. True if curve smoothing is turned on for the line chart or scatter chart.<br/>            Applies only to line and scatter connected by lines charts.<br/>            Read/write bool.|
|name|Return series name.<br/>            Read-only [IStringChartValue](/python-net/api-reference/aspose.slides.charts/istringchartvalue/).|
|data_points|Returns collection of data points of this series.<br/>            Read-only [IChartDataPointCollection](/python-net/api-reference/aspose.slides.charts/ichartdatapointcollection/).|
|type|Returns a type of this series.<br/>            Read/write [ChartType](/python-net/api-reference/aspose.slides.charts/charttype/).|
|plot_on_second_axis|Indicates if this series is plotted on secondary axis.<br/>            Read/write bool.|
|parent_series_group|ParentSeriesGroup.<br/>            Read-only [IChartSeriesGroup](/python-net/api-reference/aspose.slides.charts/ichartseriesgroup/).|
|format|Returns the format of a series.<br/>            Read-only [IFormat](/python-net/api-reference/aspose.slides.charts/iformat/).|
|order|Returns the order of a series.<br/>            Read/write|
|labels|Returns the Labels of a series.<br/>            Read-only [IDataLabelCollection](/python-net/api-reference/aspose.slides.charts/idatalabelcollection/).|
|trend_lines|Collection of series trend lines.<br/>            Read-only [ITrendlineCollection](/python-net/api-reference/aspose.slides.charts/itrendlinecollection/).|
|error_bars_xformat|Represents ErrorBars of series with derection X.|
|error_bars_yformat|Represents ErrorBars of series with derection Y.|
|related_legend_entry|Represents legend entry related with this series<br/>            Read-only [ILegendEntryProperties](/python-net/api-reference/aspose.slides.charts/ilegendentryproperties/).|
|number_format_of_values|NumberFormatOfValues.<br/>            Read/write string.|
|number_format_of_xvalues|NumberFormatOfXValues.<br/>            Read/write string.|
|number_format_of_yvalues|NumberFormatOfYValues.<br/>            Read/write string.|
|number_format_of_bubble_sizes|NumberFormatOfBubbleSizes.<br/>            Read/write string.|
|marker|Marker.<br/>            Read-only [IMarker](/python-net/api-reference/aspose.slides.charts/imarker/).|
|bar3_dshape|Specifies the shape of a series of a 3-D bar chart.<br/>            Changing of value of this property can cause to automatically changing Type of series.<br/>            Read/write [ChartShapeType](/python-net/api-reference/aspose.slides.charts/chartshapetype/).|
|invert_if_negative|Specifies the bar, column or bubble series shall invert its colors if the value is negative.<br/>            Read/write bool.|
|inverted_solid_fill_color|Specifies invert solid color for series. To apply color setting set series format FillType to FillType.Solid.<br/>            Read/write [ColorFormat](/python-net/api-reference/aspose.slides/colorformat/).|
|show_inner_points|Represents inner points. True if inner points are shown on the BoxAndWhisker chart. Applies only to BoxAndWhisker charts.<br/>            Read/write bool.|
|show_outlier_points|Represents outlier points. True if outlier points are shown on the BoxAndWhisker chart. Applies only to BoxAndWhisker charts.<br/>            Read/write bool.|
|show_mean_markers|Represents mean markers. True if mean markers are shown on the BoxAndWhisker chart. Applies only to BoxAndWhisker charts.<br/>            Read/write bool.|
|show_mean_line|Represents mean line. True if mean line are shown on the BoxAndWhisker chart. Applies only to BoxAndWhisker charts.<br/>            Read/write bool.|
|quartile_method|Represents quartile method. Applies only to BoxAndWhisker charts.|
|show_connector_lines|Represents connector lines. Applies only to Waterfall charts.|
|parent_label_layout|Represents layout of parent category labels.   Applies only to Treemap charts.|
|has_up_down_bars|Determines whether Line- or Stock-chart has a up/down bars.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.UpDownBars.HasUpDownBars read/write property for change value.<br/>            Use ParentSeriesGroup.UpDownBars property for format up/down bars.<br/>            Read-only bool.|
|gap_width|Specifies the space between bar or column clusters, as a percentage of the bar or column width.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.GapWidth read/write property for change value.<br/>            Read-only|
|gap_depth|Returns or sets the distance, as a percentage of the marker width, between the data series in a 3D chart.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.GapDepth read/write property for change value.<br/>            Read-only|
|first_slice_angle|Specifies the angle of the first pie or doughnut chart slice, <br/>            in degrees (clockwise from up, from 0 to 360 degrees).<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.FirstSliceAngle read/write property for change value.<br/>            Read-only int.|
|doughnut_hole_size|Specifies the size of the hole in a doughnut chart (can be between 10 and 90 percents <br/>            of the size of the plot area.).<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.DoughnutHoleSize read/write property for change value.<br/>            Read-only int.|
|overlap|Specifies how much bars and columns shall overlap on 2-D charts (from -100 to 100).<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.Overlap read/write property for change value.<br/>            Read-only int.|
|second_pie_size|Specifies the size of the second pie or bar of a pie-of-pie chart or <br/>            a bar-of-pie chart, as a percentage of the size of the first pie (can <br/>            be between 5 and 200 percents).<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.SecondPieSize read/write property for change value.<br/>            Read-only int.|
|has_series_lines|Determines whether there are series lines for this series and kindred series.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.HasSeriesLines read/write property for change value.<br/>            Use ParentSeriesGroup.SeriesLinesFormat property for format series lines.<br/>            Read-only bool.|
|bubble_size_representation|Specifies how the bubble size values are represented on the bubble chart.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.BubbleSizeRepresentation read/write property for change value.|
|pie_split_position|Specifies a value that shall be used to determine which data points <br/>            are in the second pie or bar on a pie-of-pie or bar-of-pie chart. <br/>            Is used together with PieSplitBy property.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.PieSplitPosition read/write property for change value.<br/>            Read-only float.|
|pie_split_by|Specifies how to determine which data points are in the second pie or bar <br/>            on a pie-of-pie or bar-of-pie chart.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.PieSplitBy read/write property for change value.<br/>            Read-only [PieSplitType](/python-net/api-reference/aspose.slides.charts/piesplittype/).|
|pie_split_custom_points|The custom split information for a pie-of-pie or bar-of-pie chart with a custom split.<br/>            Contains data points that shall be drawn in the second pie or bar in a pie-of-pie or <br/>            bar-of-pie chart.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property<br/>            Read-only [PieSplitCustomPointCollection](/python-net/api-reference/aspose.slides.charts/piesplitcustompointcollection/).|
|is_color_varied|Specifies that each data marker in the series has a different color.<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.IsColorVaried read/write property for change value.<br/>            Read-only bool.|
|bubble_size_scale|Specifies the scale factor for the bubble chart (can be <br/>            between 0 and 300 percents of the default size).<br/>            This is the property not only of this series but of all series of parent series <br/>            group - this is projection of appropriate group property. And so this property <br/>            is read-only.<br/>            Use ParentSeriesGroup property for access to parent series group.<br/>            Use ParentSeriesGroup.BubbleSizeScale read/write property for change value.|
|as_ichart_component|Allows to get base IChartComponent interface.<br/>            Read-only [IChartComponent](/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_automatic_series_color()|Returns an automatic color of series based on series index and chart style. This color is used by default if FillType equals NotDefined.|
