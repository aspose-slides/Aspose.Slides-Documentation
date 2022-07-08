---
title: StringChartValue
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1040
url: /python-net/api-reference/aspose.slides.charts/stringchartvalue/
---

## StringChartValue class

Represent string value which can be stored in pptx presentation document in two ways:<br/>            1) in cell/cells of workbook related to chart;<br/>            2) as literal value.

The StringChartValue type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|data_source_type|Specifies whether AsCell, AsCells, AsLiteralString or AsLiteralDouble <br/>            property is actual in descendants. In other words it specifies the type <br/>            of value of the Data property.<br/>            Read/write [DataSourceType](/slides/python-net/api-reference/aspose.slides.charts/datasourcetype/).|
|data|Returns or sets Data object.<br/>            Read/write object.|
|as_cells|Null value assigning is not allowed.<br/>            Returning value always is not null.<br/>            Read/write [IChartCellCollection](/slides/python-net/api-reference/aspose.slides.charts/ichartcellcollection/).|
|as_literal_string|Returns or sets value as literal string.<br/>            Read/write string.|
|as_i_multiple_cell_chart_value|Allows to get base IMultipleCellChartValue interface.<br/>            Read-only [IMultipleCellChartValue](/slides/python-net/api-reference/aspose.slides.charts/imultiplecellchartvalue/).|
|as_i_base_chart_value|Allows to get base IBaseChartValue interface.<br/>            Read-only [IBaseChartValue](/slides/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
## Methods
| Name | Description |
| :- | :- |
|set_from_one_cell(cell)|Sets value from specified cell.|
|get_cells_address_in_workbook()|If DataSourceType property is DataSourceType.Worksheet then this method returns address<br/>            of the cells in workbook which represent the string data. Otherwise return<br/>            empty string.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

