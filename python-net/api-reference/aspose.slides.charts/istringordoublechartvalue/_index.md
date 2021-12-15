---
title: {0} Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 940
url: /python-net/api-reference/aspose.slides.charts/istringordoublechartvalue/
---

Represent string or double value which can be stored in pptx presentation document in two ways:<br/>            1) in cell/cells of workbook related to chart;<br/>            2) as literal value.

**Namespace:** [aspose.slides.charts](/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IStringOrDoubleChartValue

**Assembly:**  Aspose.Slides Version: 21.11.0.0

The IStringOrDoubleChartValue type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_literal_string|Returns or sets the literal string if DataSourceType property is DataSourceType.StringLiterals.<br/>            Read/write string.|
|as_literal_double|Returns or sets the literal double if DataSourceType property is DataSourceType.DoubleLiterals.<br/>            Read/write float.|
|as_isingle_cell_chart_value|Allows to get base ISingleCellChartValue interface.<br/>            Read-only [ISingleCellChartValue](/python-net/api-reference/aspose.slides.charts/isinglecellchartvalue/).|
|as_cell|Returns or sets chart data cell.<br/>            Read/write [IChartDataCell](/python-net/api-reference/aspose.slides.charts/ichartdatacell/).|
|as_ibase_chart_value|Allows to get base IBaseChartValue interface.<br/>            Read-only [IBaseChartValue](/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
|data_source_type|Specifies whether AsCell or AsLiteralString or AsLiteralDouble property <br/>            is actual. In other words it specifies the type of value of the Data property.<br/>            This property is read-only. For changing value of this property you can use<br/>            one of the ChartDataPointCollection.DataSourceTypeFor<...> properties.<br/>            Read/write [data_source_type](/python-net/api-reference/aspose.slides.charts/ibasechartvalue/).|
|data|Read/write object.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|to_double()|Converts value to double.|
