---
title: IErrorBarsFormat Class
type: docs
weight: 800
url: /python-net/api-reference/aspose.slides.charts/ierrorbarsformat/
---

Represents error bars of chart series. ErrorBars custom values are in IChartDataPointCollection<br/>            (in [error_bars_custom_values](/python-net/api-reference/aspose.slides.charts/ichartdatapoint/) property).

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IErrorBarsFormat

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IErrorBarsFormat type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|type|Gets or sets type of error bars. <br/>            Read/write [ErrorBarType](/python-net/api-reference/aspose.slides.charts/errorbartype/).|
|value_type|Represents possible ways to determine the length of the error bars. <br/>            In case of custom value type to specify value use [error_bars_custom_values](/python-net/api-reference/aspose.slides.charts/ichartdatapoint/) property of specific data point in DataPoints collection of series.  <br/>            Read/write [ErrorBarValueType](/python-net/api-reference/aspose.slides.charts/errorbarvaluetype/).|
|has_end_cap|Specifies an end cap is not drawn on the error bars.<br/>            Read/write bool.|
|value|Gets or sets value which is used with Fixed, Percentage and StandardDeviation value types to determine the length of the error bars. <br/>            Read/write|
|format|Represents the format of the error bars.<br/>            Read/write [IFormat](/python-net/api-reference/aspose.slides.charts/iformat/).|
|is_visible|Gets or sets Error Bars visibility.<br/>            Read/write bool.|
|as_ichart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|chart|Returns the chart.<br/>            Read-only [IChart](/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
