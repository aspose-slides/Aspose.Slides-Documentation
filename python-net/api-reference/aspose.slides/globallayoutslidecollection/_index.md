---
title: GlobalLayoutSlideCollection
second_title: Aspose.Sildes for Python via .NET API Reference
description: 
type: docs
weight: 620
url: /python-net/api-reference/aspose.slides/globallayoutslidecollection/
---

## GlobalLayoutSlideCollection class

Represents a collection of all layout slides in presentation.<br/>            Extends LayoutSlideCollection class with methods for adding/cloning <br/>            layout slides in context of uniting of the individual collections of master's layout slides.

The GlobalLayoutSlideCollection type exposes the following members:
## Properties
| Name | Description |
| :- | :- |
|as_i_collection|Returns ICollection class.|
|as_i_enumerable|Returns IEnumerable class.|
|as_i_layout_slide_collection|Returns ILayoutSlideCollection interface.<br/>            Read-only [ILayoutSlideCollection](/slides/python-net/api-reference/aspose.slides/ilayoutslidecollection/).|
## Indexer
| Name | Description |
| :- | :- |
|[index]|Returns the layout slide by index.<br/>            Read-only [LayoutSlide](/slides/python-net/api-reference/aspose.slides/layoutslide/).|
## Methods
| Name | Description |
| :- | :- |
|add_clone(source_layout)|Adds a copy of a specified layout slide to the presentation.|
|add_clone(source_layout, dest_master)|Adds a copy of a specified layout slide to the presentation.|
|get_by_type(type)|Returns the first layout slide of specified type.|
|remove(value)|Removes a layout from the collection.|
|remove_unused()|Removes unused layout slides (layout slides whose HasDependingSlides is false).|
|add(master, layout_type, layout_name)|Adds a new layout slide to the presentation.|

### See Also

* namespace [aspose.slides](/slides/python-net/api-reference/aspose.slides/)
* assembly [Aspose.Slides](/slides/python-net/api-reference/)

