---
title: IDataLabelCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 740
url: /python-net/api-reference/aspose.slides.charts/idatalabelcollection/
---

## IDataLabelCollection class

Represents a series labels.

The IDataLabelCollection type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|default_data_label_format|Returns default format of all data labels in the collection.<br/>            Read-only [IDataLabelFormat](/slides/python-net/api-reference/aspose.slides.charts/idatalabelformat/).|
|is_visible|False means that data label is not visible by default (and so all <br/>            Show*-flags (ShowValue, ...) of the DefaultDataLabelFormat property are false).<br/>            Read-only bool.|
|count_of_visible_data_labels|Gets the number of visible data labels in the collection.<br/>            Read-only|
|count|Gets the number of all data labels in the collection.<br/>            Read-only|
|parent_series|Returns parent chart series.<br/>            Read-only [IChartSeries](/slides/python-net/api-reference/aspose.slides.charts/ichartseries/).|
|as_i_chart_component|Allows to get base IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_i_enumerable|Allows to get base IEnumerable interface.<br/>            Read-only list.|
|chart|Returns the chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|as_i_slide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_i_presentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
## Indexer
| Name | Description |
| :- | :- |
|[index]|Gets the data label for the data point with the specified index.|
## Methods
| Name | Description |
| :- | :- |
|hide()|Make data label hidden by default by setting all Show*-flags (ShowValue, ...) of the <br/>            DefaultDataLabelFormat property to false state.<br/>            IsVisible will be false after this.|
|index_of(value)|Returns an index of the specified DataLabel in the collection.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

