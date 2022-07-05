---
title: IGlobalLayoutSlideCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 1490
url: /python-net/api-reference/aspose.slides/igloballayoutslidecollection/
---

## IGlobalLayoutSlideCollection class

Represents a collection of all layout slides in presentation.<br/>            Extends ILayoutSlideCollection interface with methods for adding/cloning <br/>            layout slides in context of uniting of the individual collections of master's layout slides.

The IGlobalLayoutSlideCollection type exposes the following members:
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
|add_clone(source_layout)|Adds a copy of a specified layout slide to the presentation.|
|add_clone(source_layout, dest_master)|Adds a copy of a specified layout slide to the presentation.|
|add(master, layout_type, layout_name)|Adds a new layout slide to the presentation.|
|get_by_type(type)|Returns the first layout slide of specified type.|
|remove(value)|Removes a layout from the collection.|
|remove_unused()|Removes unused layout slides (layout slides whose HasDependingSlides is false).|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

