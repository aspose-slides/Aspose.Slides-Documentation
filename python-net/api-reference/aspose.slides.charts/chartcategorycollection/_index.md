---
title: ChartCategoryCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 90
url: /python-net/api-reference/aspose.slides.charts/chartcategorycollection/
---

## ChartCategoryCollection class

Represents collection of [ChartCategory](/slides/python-net/api-reference/aspose.slides.charts/chartcategory/)

The ChartCategoryCollection type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|use_cells|If true then worksheet is used for storing categories (this case supports a multi-level categories).<br/>            If false then worksheet is NOT used for storing values (and this case doesn't support a <br/>            multi-level categories).<br/>            Read/write bool.|
|grouping_level_count|Returns count of category grouping levels used.<br/>            Is more then one for multilevel categories.<br/>            Read-only|
|as_i_collection|Returns ICollection class.|
|as_i_enumerable|Returns IEnumerable class.|
## Indexer
| Name | Description |
| :- | :- |
|[index]|Gets the element at the specified index.|
## Methods
| Name | Description |
| :- | :- |
|add(chart_data_cell)|If category exists in collection, return it. Else creates new chart category from <br/>            [IChartDataCell](/slides/python-net/api-reference/aspose.slides.charts/ichartdatacell/) and adds it to the collection.|
|add(value)|Creates new [ChartCategory](/slides/python-net/api-reference/aspose.slides.charts/chartcategory/) from value and adds it to the collection.|
|index_of(value)|Searches for the specified [ChartCategory](/slides/python-net/api-reference/aspose.slides.charts/chartcategory/) and returns the zero-based index of the first occurrence within the entire Collection.|
|remove(value)|Removes the specified value.|
|remove_at(index)|Removes the element at the given index.|
|clear()|Removes all elements from the collection.|

### See Also

* namespace [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

