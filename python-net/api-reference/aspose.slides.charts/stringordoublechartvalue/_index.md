---
title: StringOrDoubleChartValue Class
type: docs
weight: 1050
url: /slides/python-net/api-reference/aspose.slides.charts/stringordoublechartvalue/
---

Represent string or double value which can be stored in pptx presentation document in two ways:<br/>            1) in cell/cells of workbook related to chart;<br/>            2) as literal value.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.StringOrDoubleChartValue

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The StringOrDoubleChartValue type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|data_source_type|Specifies whether AsCell, AsCells, AsLiteralString or AsLiteralDouble <br/>            property is actual in descendants. In other words it specifies the type <br/>            of value of the Data property.<br/>            Read/write [DataSourceType](/python-net/api-reference/aspose.slides.charts/datasourcetype/).|
|data|Returns or sets Data object.<br/>            Read/write object.|
|as_cell|Returns or sets chart data cell.<br/>            Read/write [IChartDataCell](/python-net/api-reference/aspose.slides.charts/ichartdatacell/).|
|as_literal_string|Returns or sets value as literal string.<br/>            Read/write string.|
|as_literal_double|Returns or sets value as literal double.<br/>            Read/write float.|
|as_isingle_cell_chart_value|Allows to get base ISingleCellChartValue interface.<br/>            Read-only [ISingleCellChartValue](/python-net/api-reference/aspose.slides.charts/isinglecellchartvalue/).|
|as_ibase_chart_value|Allows to get base IBaseChartValue interface.<br/>            Read-only [IBaseChartValue](/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|to_double()|Converts to double.|
