---
title: DataLabelCollection Class
type: docs
weight: 320
url: /python-net/api-reference/aspose.slides.charts/datalabelcollection/
---

Represents a series labels.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.DataLabelCollection



The DataLabelCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|chart|Returns the parent chart.<br/>            Read-only [IChart](/slides/python-net/api-reference/aspose.slides.charts/ichart/).|
|is_visible|False means that data label is not visible by default (and so all <br/>            Show*-flags (ShowValue, ...) of the DefaultDataLabelFormat property are false).<br/>            Read-only bool.|
|count_of_visible_data_labels|Gets the number of visible data labels in the collection.<br/>            Read-only|
|count|Gets the number of all data labels in the collection.<br/>            Read-only|
|default_data_label_format|Gets the default data label format.<br/>            Read-only [IDataLabelFormat](/slides/python-net/api-reference/aspose.slides.charts/idatalabelformat/).|
|parent_series|Gets the parent series.<br/>            Read-only [IChartSeries](/slides/python-net/api-reference/aspose.slides.charts/ichartseries/).|
|as_ichart_component|Allows to get base IChartComponent interface.<br/>            Read-only [IChartComponent](/slides/python-net/api-reference/aspose.slides.charts/ichartcomponent/).|
|as_ienumerable|Allows to get base IEnumerable interface.<br/>            Read-only list.|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the data label for the data point with the specified index.|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|hide()|Make data label hidden by default by setting all Show*-flags (ShowValue, ...) of the <br/>            DefaultDataLabelFormat property to false state.<br/>            IsVisible will be false after this.|
|index_of(value)|Returns an index of the specified DataLabel in the collection.|
