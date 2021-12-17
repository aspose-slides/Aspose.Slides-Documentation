---
title: ISectionCollection Class
type: docs
weight: 2370
url: /python-net/api-reference/aspose.slides/isectioncollection/
---

Represents a collection of sections.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ISectionCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ISectionCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the element at the specified index.<br/>            Read-only [ISection](/python-net/api-reference/aspose.slides/isection/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_section(name, started_from_slide)|Add new section started form specific slide.|
|add_empty_section(name, index)|Add empty section to specified position of the collection.|
|remove_section_with_slides(section)|Remove section and slides contained in the section.|
|remove_section(section)|Remove section and slides contained in the section.|
|reorder_section_with_slides(section, index)|Moves section and its slides from the collection to the specified position.|
|append_empty_section(name)|Add empty section to the end of the collection.|
|index_of(section)|Returns an index of the specified section in the collection.|
|clear()|Removes all sections from the collection.|
