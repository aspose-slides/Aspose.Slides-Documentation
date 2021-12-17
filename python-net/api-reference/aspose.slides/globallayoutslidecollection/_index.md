---
title: GlobalLayoutSlideCollection Class
type: docs
weight: 620
url: /python-net/api-reference/aspose.slides/globallayoutslidecollection/
---

Represents a collection of all layout slides in presentation.<br/>            Extends LayoutSlideCollection class with methods for adding/cloning <br/>            layout slides in context of uniting of the individual collections of master's layout slides.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.GlobalLayoutSlideCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The GlobalLayoutSlideCollection type exposes the following members:
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
|add_clone(source_layout)|Adds a copy of a specified layout slide to the presentation.|
|add_clone(source_layout, dest_master)|Adds a copy of a specified layout slide to the presentation.|
|get_by_type(type)|Returns the first layout slide of specified type.|
|remove(value)|Removes a layout from the collection.|
|remove_unused()|Removes unused layout slides (layout slides whose HasDependingSlides is false).|
|add(master, layout_type, layout_name)|Adds a new layout slide to the presentation.|
