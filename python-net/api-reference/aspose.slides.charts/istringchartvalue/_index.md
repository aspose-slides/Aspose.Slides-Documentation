---
title: IStringChartValue
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 930
url: /python-net/api-reference/aspose.slides.charts/istringchartvalue/
---

## IStringChartValue class

Represent string value which can be stored in pptx presentation document in two ways:<br/>            1) in cell/cells of workbook related to chart;<br/>            2) as literal value.

The IStringChartValue type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|as_literal_string|Returns or sets the literal string if DataSourceType property is DataSourceType.StringLiterals.<br/>            Read/write string.|
|as_i_multiple_cell_chart_value|Allows to get base IMultipleCellChartValue interface.<br/>            Read-only [IMultipleCellChartValue](/slides/python-net/api-reference/aspose.slides.charts/imultiplecellchartvalue/).|
|as_cells|Returns or sets the collection of chart cells.<br/>            Read/write [IChartCellCollection](/slides/python-net/api-reference/aspose.slides.charts/ichartcellcollection/).|
|as_i_base_chart_value|Allows to get base IBaseChartValue interface.<br/>            Read-only [IBaseChartValue](/slides/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
|data_source_type|Specifies whether AsCell or AsLiteralString or AsLiteralDouble property <br/>            is actual. In other words it specifies the type of value of the Data property.<br/>            This property is read-only. For changing value of this property you can use<br/>            one of the ChartDataPointCollection.DataSourceTypeFor<...> properties.<br/>            Read/write [data_source_type](/slides/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
|data|Read/write object.|
## Methods
| Name | Description |
| :- | :- |
|to_string()|Returns string representation.|
|set_from_one_cell(cell)|Sets value from specified cell.|
|get_cells_address_in_workbook()|If DataSourceType property is DataSourceType.Worksheet then this method returns address<br/>            of the cells in workbook which represent the string data. Otherwise return<br/>            empty string.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

