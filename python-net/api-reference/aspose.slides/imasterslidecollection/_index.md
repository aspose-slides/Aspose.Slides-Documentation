---
title: IMasterSlideCollection Class
type: docs
weight: 1900
url: /python-net/api-reference/aspose.slides/imasterslidecollection/
---

Represents a collection of master slides.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IMasterSlideCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The IMasterSlideCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the element at the specified index.<br/>            Read-only [IMasterSlide](/slides/python-net/api-reference/aspose.slides/imasterslide/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove(value)|Removes the first occurrence of a specific object from the collection.|
|remove_at(index)|Removes the element at the specified index of the collection.|
|remove_unused(ignore_preserve_field)|Removes unused master slides.|
|add_clone(source_master)|Adds a copy of a specified master slide to the end of the collection.<br/>            Linked layout slides will be copied too.|
|insert_clone(index, source_master)|Inserts a copy of a specified master slide to specified position of the collection.<br/>            Linked layout slides will be copied too.|
