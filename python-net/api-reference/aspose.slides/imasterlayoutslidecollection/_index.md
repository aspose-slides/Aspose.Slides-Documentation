---
title: IMasterLayoutSlideCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1850
url: /python-net/api-reference/aspose.slides/imasterlayoutslidecollection/
---

## IMasterLayoutSlideCollection class

Represents a collections of all layout slides of defined master slide.<br/>            Extends ILayoutSlideCollection interface with methods for adding/inserting/removing/cloning <br/>            layout slides in context of the individual collections of master's layout slides.

The IMasterLayoutSlideCollection type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|as_ilayout_slide_collection|Returns ILayoutSlideCollection interface.<br/>            Read-only [ILayoutSlideCollection](/slides/python-net/api-reference/aspose.slides/ilayoutslidecollection/).|
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## Indexer
| Name | Description |
| :- | :- |
|[index]|Returns the layout slide by index.<br/>            Read-only [ILayoutSlide](/slides/python-net/api-reference/aspose.slides/ilayoutslide/).|
## Methods
| Name | Description |
| :- | :- |
|add_clone(source_layout)|Adds a copy of a specified layout slide to the end of the collection.|
|insert_clone(index, source_layout)|Inserts a copy of a specified layout slide to specified position of the collection.|
|add(layout_type, layout_name)|Adds a new layout slide to the end of the collection.|
|insert(index, layout_type, layout_name)|Inserts a new layout slide to specified position of the collection.|
|remove_at(index)|Removes the element at the specified index of the collection.|
|reorder(index, layout_slide)|Moves layout slide from the collection to the specified position.|
|get_by_type(type)|Returns the first layout slide of specified type.|
|remove(value)|Removes the element at the specified index of the collection.|
|remove_unused()|Removes unused layout slides (layout slides whose HasDependingSlides is false).|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

