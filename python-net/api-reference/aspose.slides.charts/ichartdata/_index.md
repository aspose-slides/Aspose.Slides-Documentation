---
title: IChartData Class
type: docs
weight: 510
url: /python-net/api-reference/aspose.slides.charts/ichartdata/
---

Represents data used for a chart plotting.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IChartData

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IChartData type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|chart_data_workbook|Gets the cells factory to create cells used for chart series or categories.<br/>            Read-only [IChartDataWorkbook](/python-net/api-reference/aspose.slides.charts/ichartdataworkbook/).|
|series|Gets the series.<br/>            Read-only [IChartSeriesCollection](/python-net/api-reference/aspose.slides.charts/ichartseriescollection/).|
|series_groups|Gets the groups of series.<br/>            Read-only [IChartSeriesGroupCollection](/python-net/api-reference/aspose.slides.charts/ichartseriesgroupcollection/).|
|categories|Gets the primary categories (or both primary and secondary categories <br/>            if [use_secondary_categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property is false).<br/>            Read-only [IChartCategoryCollection](/python-net/api-reference/aspose.slides.charts/ichartcategorycollection/).|
|use_secondary_categories|If false then [secondary_categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property return null and data <br/>            in [categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property is used both for primary and secondary series.<br/>            If true then data in [secondary_categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property is used for secondary series and data <br/>            in [categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property is used for primary series.<br/>            Read/write bool.|
|secondary_categories|Gets the secondary categories if [use_secondary_categories](/python-net/api-reference/aspose.slides.charts/ichartdata/) property is true.<br/>            Read-only [IChartCategoryCollection](/python-net/api-reference/aspose.slides.charts/ichartcategorycollection/).|
|data_source_type|Represents data source of the chart|
|external_workbook_path|Represents external workbook path if data source is external, null otherwise|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|set_external_workbook(workbook_path)|Sets external workbook as a data source for the chart. Chart data will be updated from the target workbook.|
|set_external_workbook(workbook_path, update_chart_data)|Sets external workbook as a data source for the chart.|
|set_range(formula)|Set chart data range. Series and categories will be updated based on new data range.<br/>            If amount of series in data range greater than count of series in the chart data then additional series with the same type<br/>            as a last series in the current collection will be added to the end of the collection.|
|get_range()|Gets chart data range.|
|switch_row_column()|Swap the data over the axis.<br/>            Data being charted on the X axis will move to the Y axis and vice versa.|