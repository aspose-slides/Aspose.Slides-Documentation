---
title: ISmartArtNode Class
type: docs
weight: 20
url: /python-net/api-reference/aspose.slides.smartart/ismartartnode/
---

Represents node of a SmartArt diagram.

**Namespace:** [aspose.slides.smartart](/slides/python-net/api-reference/aspose.slides.smartart/)

**Full Class Name:** aspose.slides.smartart.ISmartArtNode

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The ISmartArtNode type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|child_nodes|Returns collections of all child nodes of current node.<br/>            Read-only [ISmartArtNodeCollection](/slides/python-net/api-reference/aspose.slides.smartart/ismartartnodecollection/).|
|shapes|Returns collections of all shapes associated with the node.<br/>            Read-only [ISmartArtShapeCollection](/slides/python-net/api-reference/aspose.slides.smartart/ismartartshapecollection/).|
|text_frame|Returns or sets text of the node.<br/>            Read-only [ITextFrame](/slides/python-net/api-reference/aspose.slides/itextframe/).|
|is_assistant|Returns or sets the node as assistant.<br/>            Read/write bool.|
|level|Returns nesting level of the node.<br/>            Read-only|
|bullet_fill_format|Returns the FillFormat object that contains fill formatting properties for a node bullet.<br/>            Note: can return null for certain types of SmartArt layout which does not provide bullets for nodes.<br/>            Read-only [IFillFormat](/slides/python-net/api-reference/aspose.slides/ifillformat/).|
|position|Returns or sets zero-based position of the node among sibling nodes.<br/>            Read/write|
|is_hidden|Returns true if this node is a hidden node in the data model.<br/>            Read-only bool.|
|organization_chart_layout|Returns or sets organization chart layout type associated with current node.<br/>            Read/write [OrganizationChartLayoutType](/slides/python-net/api-reference/aspose.slides.smartart/organizationchartlayouttype/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Remove current node.|
