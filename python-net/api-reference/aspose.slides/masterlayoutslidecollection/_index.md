---
title: MasterLayoutSlideCollection Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 2990
url: /python-net/api-reference/aspose.slides/masterlayoutslidecollection/
---

Represents a collections of all layout slides of defined master slide.<br/>            Extends LayoutSlideCollection class with methods for adding/inserting/removing/cloning/reordering <br/>            layout slides in context of the individual collections of master's layout slides.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.MasterLayoutSlideCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The MasterLayoutSlideCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
|as_ilayout_slide_collection|Returns ILayoutSlideCollection interface.<br/>            Read-only [ILayoutSlideCollection](/python-net/api-reference/aspose.slides/ilayoutslidecollection/).|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Returns the layout slide by index.<br/>            Read-only [LayoutSlide](/python-net/api-reference/aspose.slides/layoutslide/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|get_by_type(type)|Returns the first layout slide of specified type.|
|remove(value)|Removes the element at the specified index of the collection.|
|remove_unused()|Removes unused layout slides (layout slides whose HasDependingSlides is false).|
|add_clone(source_layout)|Adds a copy of a specified layout slide to the end of the collection.|
|insert_clone(index, source_layout)|Inserts a copy of a specified layout slide to specified position of the collection.|
|add(layout_type, layout_name)|Adds a new layout slide to the end of the collection.|
|insert(index, layout_type, layout_name)|Inserts a new layout slide to specified position of the collection.|
|remove_at(index)|Removes the element at the specified index of the collection.|
|reorder(index, layout_slide)|Moves layout slide from the collection to the specified position.|
