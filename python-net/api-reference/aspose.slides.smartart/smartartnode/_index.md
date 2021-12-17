---
title: SmartArtNode Class
type: docs
weight: 70
url: /python-net/api-reference/aspose.slides.smartart/smartartnode/
---

Represents node of a SmartArt object

**Namespace:** [aspose.slides.smartart](/slides/python-net/api-reference/aspose.slides.smartart/)

**Full Class Name:** aspose.slides.smartart.SmartArtNode

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The SmartArtNode type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|child_nodes|Returns collections of all child nodes of the current node.<br/>            Read-only [ISmartArtNodeCollection](/python-net/api-reference/aspose.slides.smartart/ismartartnodecollection/).|
|shapes|Returns collections of all shapes associated with the node.<br/>            Read-only [ISmartArtShapeCollection](/python-net/api-reference/aspose.slides.smartart/ismartartshapecollection/).|
|text_frame|Returns or sets text of the node.<br/>            Read-only [ITextFrame](/python-net/api-reference/aspose.slides/itextframe/).|
|is_assistant|Returns or sets the node as assistant.<br/>            Read/write bool.|
|level|Returns nesting level of the node.<br/>            Read-only|
|bullet_fill_format|Returns the FillFormat object that contains fill formatting properties for a node bullet.<br/>            Note: can return null for certain types of SmartArt layout which does not provide bullets for nodes.<br/>            Read-only [IFillFormat](/python-net/api-reference/aspose.slides/ifillformat/).|
|position|Returns or sets zero-based position of node among sibling nodes.<br/>            Read/write|
|is_hidden|Returns true if this node is a hidden node in the data model.<br/>            Read-only bool.|
|organization_chart_layout|Returns or sets organization chart layout type associated with current node.<br/>            Read/write [OrganizationChartLayoutType](/python-net/api-reference/aspose.slides.smartart/organizationchartlayouttype/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|remove()|Remove current node.|
