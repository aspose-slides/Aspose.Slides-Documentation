---
title: CombinableSeriesTypesGroup
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1160
url: /python-net/api-reference/aspose.slides.charts/combinableseriestypesgroup/
---

## CombinableSeriesTypesGroup enumeration

Enumeration of groups of combinable series types.<br/>            Each element relates to group of types of chart series that can persist simultaneously in one ChartSeriesGroup.<br/>            For example: ChartType.PercentsStackedArea series cannot be simultaneously with ChartType.StackedArea series <br/>            in one ChartSeriesGroup. But two or more ChartType.PercentsStackedArea can be in one ChartSeriesGroup <br/>            simultaneously (CombinableSeriesTypesGroup.AreaChart_PercentsStackedArea). And ChartType.Line series can be <br/>            with ChartType.LineWithMarkers series simultaneously in one CombinableSeriesTypesGroup.LineChart_Line <br/>            ChartSeriesGroup.

## Members
| Member name | Description |
| :- | :- |
|AREA_CHART_AREA|Groups this set of series types:<br/>            { ChartType.Area }|
|AREA_CHART_PERCENTS_STACKED_AREA|Groups this set of series types:<br/>            { ChartType.PercentsStackedArea }|
|AREA_CHART_STACKED_AREA|Groups this set of series types:<br/>            { ChartType.StackedArea }|
|AREA_CHART_AREA3_D|Groups this set of series types:<br/>            { ChartType.Area3D }|
|AREA_CHART_STACKED_AREA3_D|Groups this set of series types:<br/>            { ChartType.StackedArea3D }|
|AREA_CHART_PERCENTS_STACKED_AREA3_D|Groups this set of series types:<br/>            { ChartType.PercentsStackedArea3D }|
|LINE_CHART_LINE|Groups this set of series types:<br/>            { ChartType.Line, ChartType.LineWithMarkers }|
|LINE_CHART_STACKED_LINE|Groups this set of series types:<br/>            { ChartType.StackedLine, ChartType.StackedLineWithMarkers }|
|LINE_CHART_PERCENTS_STACKED_LINE|Groups this set of series types:<br/>            { ChartType.PercentsStackedLine, ChartType.PercentsStackedLineWithMarkers }|
|LINE3_DCHART|Groups this set of series types:<br/>            { ChartType.Line3D }|
|STOCK_HIGH_LOW_CLOSE|Groups this set of series types:<br/>            { ChartType.HighLowClose }|
|STOCK_OPEN_HIGH_LOW_CLOSE|Groups this set of series types:<br/>            { ChartType.OpenHighLowClose }|
|STOCK_VOLUME_HIGH_LOW_CLOSE|Groups this set of series types:<br/>            { ChartType.VolumeHighLowClose }|
|STOCK_VOLUME_OPEN_HIGH_LOW_CLOSE|Groups this set of series types:<br/>            { ChartType.VolumeOpenHighLowClose }|
|RADAR_CHART|Groups this set of series types:<br/>            { ChartType.Radar, ChartType.RadarWithMarkers }|
|FILLED_RADAR_CHART|Groups this set of series types:<br/>            { ChartType.FilledRadar }|
|SCATTER_STRAIGHT_MARKER|Groups this set of series types:<br/>            { ChartType.ScatterWithMarkers, ChartType.ScatterWithStraightLines, ChartType.ScatterWithStraightLinesAndMarkers }|
|SCATTER_SMOOTH_MARKER|Groups this set of series types:<br/>            { ChartType.ScatterWithSmoothLines, ChartType.ScatterWithSmoothLinesAndMarkers }|
|PIE_CHART|Groups this set of series types:<br/>            { ChartType.Pie, ChartType.ExplodedPie }|
|PIE3_DCHART|Groups this set of series types:<br/>            { ChartType.Pie3D, ChartType.ExplodedPie3D }|
|DOUGHNUT_CHART|Groups this set of series types:<br/>            { ChartType.Doughnut, ChartType.ExplodedDoughnut }|
|BAR_CHART_VERT_CLUSTERED|Groups this set of series types:<br/>            { ChartType.ClusteredColumn }|
|BAR_CHART_VERT_STACKED|Groups this set of series types:<br/>            { ChartType.StackedColumn }|
|BAR_CHART_VERT_PERCENTS_STACKED|Groups this set of series types:<br/>            { ChartType.PercentsStackedColumn }|
|BAR_CHART_HORIZ_CLUSTERED|Groups this set of series types:<br/>            { ChartType.ClusteredBar }|
|BAR_CHART_HORIZ_STACKED|Groups this set of series types:<br/>            { ChartType.StackedBar }|
|BAR_CHART_HORIZ_PERCENTS_STACKED|Groups this set of series types:<br/>            { ChartType.PercentsStackedBar }|
|BAR3_DCHART_VERT|Groups this set of series types:<br/>            { ChartType.Column3D, ChartType.Cylinder3D, ChartType.Cone3D, ChartType.Pyramid3D }|
|BAR3_DCHART_VERT_CLUSTERED|Groups this set of series types:<br/>            { ChartType.ClusteredColumn3D, ChartType.ClusteredCone, ChartType.ClusteredCylinder, ChartType.ClusteredPyramid }|
|BAR3_DCHART_VERT_PERCENTS_STACKED_COLUMN3_D|Groups this set of series types:<br/>            { ChartType.PercentsStackedColumn3D }|
|BAR3_DCHART_VERT_PERCENTS_STACKED_CONE|Groups this set of series types:<br/>            { ChartType.PercentsStackedCone }|
|BAR3_DCHART_VERT_PERCENTS_STACKED_CYLINDER|Groups this set of series types:<br/>            { ChartType.PercentsStackedCylinder }|
|BAR3_DCHART_VERT_PERCENTS_STACKED_PYRAMID|Groups this set of series types:<br/>            { ChartType.PercentsStackedPyramid }|
|BAR3_DCHART_VERT_STACKED_COLUMN3_D|Groups this set of series types:<br/>            { ChartType.StackedColumn3D }|
|BAR3_DCHART_VERT_STACKED_CONE|Groups this set of series types:<br/>            { ChartType.StackedCone }|
|BAR3_DCHART_VERT_STACKED_CYLINDER|Groups this set of series types:<br/>            { ChartType.StackedCylinder }|
|BAR3_DCHART_VERT_STACKED_PYRAMID|Groups this set of series types:<br/>            { ChartType.StackedPyramid }|
|BAR3_DCHART_HORIZ_CLUSTERED|Groups this set of series types:<br/>            { ChartType.ClusteredBar3D, ChartType.ClusteredHorizontalCone, ChartType.ClusteredHorizontalCylinder, ChartType.ClusteredHorizontalPyramid }|
|BAR3_DCHART_HORIZ_STACKED_BAR3_D|Groups this set of series types:<br/>            { ChartType.StackedBar3D }|
|BAR3_DCHART_HORIZ_STACKED_CONE|Groups this set of series types:<br/>            { ChartType.StackedHorizontalCone }|
|BAR3_DCHART_HORIZ_STACKED_CYLINDER|Groups this set of series types:<br/>            { ChartType.StackedHorizontalCylinder }|
|BAR3_DCHART_HORIZ_STACKED_PYRAMID|Groups this set of series types:<br/>            { ChartType.StackedHorizontalPyramid }|
|BAR3_DCHART_HORIZ_PERCENTS_STACKED_BAR3_D|Groups this set of series types:<br/>            { ChartType.PercentsStackedBar3D }|
|BAR3_DCHART_HORIZ_PERCENTS_STACKED_CONE|Groups this set of series types:<br/>            { ChartType.PercentsStackedHorizontalCone }|
|BAR3_DCHART_HORIZ_PERCENTS_STACKED_CYLINDER|Groups this set of series types:<br/>            { ChartType.PercentsStackedHorizontalCylinder }|
|BAR3_DCHART_HORIZ_PERCENTS_STACKED_PYRAMID|Groups this set of series types:<br/>            { ChartType.PercentsStackedHorizontalPyramid }|
|BAR_OF_PIE_CHART|Groups this set of series types:<br/>            { ChartType.BarOfPie }|
|PIE_OF_PIE_CHART|Groups this set of series types:<br/>            { ChartType.PieOfPie }|
|SURFACE_CHART_CONTOUR|Groups this set of series types:<br/>            { ChartType.Contour }|
|SURFACE_CHART_WIREFRAME_CONTOUR|Groups this set of series types:<br/>            { ChartType.WireframeContour }|
|SURFACE_CHART_SURFACE3_D|Groups this set of series types:<br/>            { ChartType.Surface3D }|
|SURFACE_CHART_WIREFRAME_SURFACE3_D|Groups this set of series types:<br/>            { ChartType.WireframeSurface3D }|
|BUBBLE_CHART|Groups this set of series types:<br/>            { ChartType.Bubble, ChartType.BubbleWith3D }|
|HISTOGRAM_CHART|Groups this set of series types:<br/>            { ChartType.Histogram }|
|PARETO_LINE_CHART|Groups this set of series types:<br/>            { ChartType.ParetoLine }|
|BOX_AND_WHISKER_CHART|Groups this set of series types:<br/>            { ChartType.BoxAndWhisker }|
|WATERFALL_CHART|Groups this set of series types:<br/>            { ChartType.Waterfall }|
|FUNNEL_CHART|Groups this set of series types:<br/>            { ChartType.Funnel }|
|TREEMAP_CHART|Groups this set of series types:<br/>            { ChartType.Treemap }|
|MAP_CHART|Groups this set of series types:<br/>            { ChartType.Map }|
|SUNBURST_CHART|Groups this set of series types:<br/>            { ChartType.Sunburst }|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

