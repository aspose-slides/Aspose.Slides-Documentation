---
title: StringChartValue Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 1040
url: /python-net/api-reference/aspose.slides.charts/stringchartvalue/
---

Represent string value which can be stored in pptx presentation document in two ways:<br/>            1) in cell/cells of workbook related to chart;<br/>            2) as literal value.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.StringChartValue

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The StringChartValue type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|data_source_type|Specifies whether AsCell, AsCells, AsLiteralString or AsLiteralDouble <br/>            property is actual in descendants. In other words it specifies the type <br/>            of value of the Data property.<br/>            Read/write [DataSourceType](/python-net/api-reference/aspose.slides.charts/datasourcetype/).|
|data|Returns or sets Data object.<br/>            Read/write object.|
|as_cells|Null value assigning is not allowed.<br/>            Returning value always is not null.<br/>            Read/write [IChartCellCollection](/python-net/api-reference/aspose.slides.charts/ichartcellcollection/).|
|as_literal_string|Returns or sets value as literal string.<br/>            Read/write string.|
|as_imultiple_cell_chart_value|Allows to get base IMultipleCellChartValue interface.<br/>            Read-only [IMultipleCellChartValue](/python-net/api-reference/aspose.slides.charts/imultiplecellchartvalue/).|
|as_ibase_chart_value|Allows to get base IBaseChartValue interface.<br/>            Read-only [IBaseChartValue](/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|set_from_one_cell(cell)|Sets value from specified cell.|
|get_cells_address_in_workbook()|If DataSourceType property is DataSourceType.Worksheet then this method returns address<br/>            of the cells in workbook which represent the string data. Otherwise return<br/>            empty string.|
