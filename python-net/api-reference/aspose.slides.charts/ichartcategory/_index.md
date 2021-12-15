---
title: IChartCategory Class
type: docs
weight: 460
url: /python-net/api-reference/aspose.slides.charts/ichartcategory/
---

Represents chart categories.

**Namespace:** [aspose.slides.charts](/slides/python-net/api-reference/aspose.slides.charts/)

**Full Class Name:** aspose.slides.charts.IChartCategory

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IChartCategory type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|use_cell|If true then AsCell property is actual. In other words, worksheet is used for <br/>            storing category (this case supports a multi-level category).<br/>            If false then AsLiteral property is actual. In other words, worksheet is NOT used <br/>            for storing category (and this case doesn't support a multi-level categories).<br/>            Read-only bool.|
|as_cell|Returns or sets IChartDataCell object.<br/>            If category is multi-level then used IChartDataCell object for level "0".<br/>            Read/write [IChartDataCell](/python-net/api-reference/aspose.slides.charts/ichartdatacell/).|
|as_literal|Returns or sets AsLiteral if UseCell is false.<br/>            Read/write object.|
|value|If UseCell is true then this property represents AsCell.Value property.<br/>            If UseCell is false then this property represents AsLiteral property.<br/>            Read/write object.|
|grouping_levels|Managed container of the values of the chart category grouping levels.<br/>            Multi-level category contain more then one grouping level.<br/>            Grouping levels indexing is zero-based.<br/>            Read-only [IChartCategoryLevelsManager](/python-net/api-reference/aspose.slides.charts/ichartcategorylevelsmanager/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Removes category from chart.|
