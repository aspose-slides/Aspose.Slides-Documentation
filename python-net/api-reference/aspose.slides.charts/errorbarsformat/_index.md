---
title: ErrorBarsFormat
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 380
url: /python-net/api-reference/aspose.slides.charts/errorbarsformat/
---

## ErrorBarsFormat class

Represents error bars of chart series. ErrorBars custom values are in IChartDataPointCollection<br/>            (in [error_bars_custom_values](/slides/python-net/api-reference/aspose.slides.charts/ichartdatapoint/) property).

The ErrorBarsFormat type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|type|Gets or sets type of error bars. <br/>            Read/write [ErrorBarType](/slides/python-net/api-reference/aspose.slides.charts/errorbartype/).|
|value_type|Represents possible ways to determine the length of the error bars. <br/>            In case of custom value type to specify value use [error_bars_custom_values](/slides/python-net/api-reference/aspose.slides.charts/ichartdatapoint/) property of specific data point in DataPoints collection of series.<br/>            In case of Fixed, Percentage or StandardDeviation value type use Value property to specify value.  <br/>            Read/write [ErrorBarValueType](/slides/python-net/api-reference/aspose.slides.charts/errorbarvaluetype/).|
|has_end_cap|Specifies an end cap is not drawn on the error bars.<br/>            Read/write bool.|
|value|Gets or sets value which is used with Fixed, Percentage and StandardDeviation value types to determine the length of the error bars. <br/>            In any other case will return NaN.<br/>            Read/write|
|format|Represents the format of the error bars.<br/>            Read/write [IFormat](/slides/python-net/api-reference/aspose.slides.charts/iformat/).|
|chart|Returns the parent chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|is_visible|Gets or sets Error Bars visibility .<br/>            Read/write bool.|
|as_i_chart_component|Returns IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_i_slide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

