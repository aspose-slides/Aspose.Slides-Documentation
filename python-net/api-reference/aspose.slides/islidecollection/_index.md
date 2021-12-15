---
title: ISlideCollection Class - Aspose.Slides for Python via .NET - API Reference
type: docs
weight: 2490
url: /python-net/api-reference/aspose.slides/islidecollection/
---

Represents a collection of a slides.

**Namespace:** [aspose.slides](/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.ISlideCollection

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ISlideCollection type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|as_icollection|Returns ICollection class.|
|as_ienumerable|Returns IEnumerable class.|
## **Indexer**
|**Name**|**Description**|
| :- | :- |
|[index]|Gets the element at the specified index.<br/>            Read-only [ISlide](/python-net/api-reference/aspose.slides/islide/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_clone(source_slide)|Adds a copy of a specified slide to the end of the collection.|
|add_clone(source_slide, section)|Adds a copy of a specified slide to the end of the specified section.|
|add_clone(source_slide, dest_layout)|Adds a copy of a specified slide to the end of the collection.|
|add_clone(source_slide, dest_master, allow_clone_missing_layout)|Adds a copy of a specified source slide to the end of the collection.<br/>            Appropriate layout will be selected automatically from the specified <br/>            master (appropriate layout is the layout with the same Type or Name as <br/>            of layout of the source slide). If there is no appropriate layout then<br/>            layout of the source slide will be cloned (if allowCloneMissingLayout <br/>            is true) or PptxEditException will be thrown (if allowCloneMissingLayout<br/>            is false).|
|insert_clone(index, source_slide)|Inserts a copy of a specified slide to specified position of the collection.|
|insert_clone(index, source_slide, dest_layout)|Inserts a copy of a specified slide to specified position of the collection.|
|insert_clone(index, source_slide, dest_master, allow_clone_missing_layout)|Inserts a copy of a specified source slide to specified position of the collection.<br/>            Appropriate layout will be selected automatically from the specified <br/>            master (appropriate layout is the layout with the same Type or Name as <br/>            of layout of the source slide). If there is no appropriate layout then<br/>            layout of the source slide will be cloned (if allowCloneMissingLayout <br/>            is true) or PptxEditException will be thrown (if allowCloneMissingLayout<br/>            is false).|
|to_array()|Creates and returns an array with all slides in it.|
|to_array(start_index, count)|Creates and returns an array with all slides from the specified range in it.|
|reorder(index, slide)|Moves slide from the collection to the specified position.|
|reorder(index, slides)|Moves slides from the collection to the specified position.<br/>            Slides will be placed starting from index in order they appear in list.|
|add_from_pdf(path)|Creates slides from the PDF document and adds them to the end of the collection.|
|add_from_pdf(pdf_stream)|Creates slides from the PDF document and adds them to the end of the collection.|
|add_from_html(html_text, resolver, uri)|Creates slides from HTML text and adds them to the end of the collection.|
|add_from_html(html_text)|Creates slides from HTML text and adds them to the end of the collection.|
|add_from_html(html_stream, resolver, uri)|Creates slides from HTML text and adds them to the end of the collection.|
|add_from_html(html_stream)|Creates slides from HTML text and adds them to the end of the collection.|
|insert_from_html(index, html_text, resolver, uri)|Creates slides from HTML text and inserts them to the collection at the specified position.|
|insert_from_html(index, html_text)|Creates slides from HTML text and inserts them to the collection at the specified position.|
|insert_from_html(index, html_stream, resolver, uri)|Creates slides from HTML text and inserts them to the collection at the specified position.|
|insert_from_html(index, html_stream)|Creates slides from HTML text and inserts them to the collection at the specified position.|
|add_empty_slide(layout)|Adds a new empty slide to the end of the collection.|
|insert_empty_slide(index, layout)|Inserts a copy of a specified slide to specified position of the collection.|
|remove(value)|Removes the first occurrence of a specific object from the collection.|
|remove_at(index)|Removes the element at the specified index of the collection.|
|index_of(slide)|Returns an index of the specified slide in the collection.|
