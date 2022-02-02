---
title: IControl Class
type: docs
weight: 1180
url: /python-net/api-reference/aspose.slides/icontrol/
---

Represents an ActiveX control.

**Namespace:** [aspose.slides](/slides/python-net/api-reference/aspose.slides/)

**Full Class Name:** aspose.slides.IControl



The IControl type exposes the following members:
## **Properties**
|**Name**|**Description**|
| :- | :- |
|name|Returns the name of this control.<br/>            Read/write string.|
|class_id|Gets class id of this control.<br/>            Read-only string.|
|substitute_picture_format|Returns ControlEx image fill properties object.<br/>            Read-only [IPictureFillFormat](/slides/python-net/api-reference/aspose.slides/ipicturefillformat/).|
|frame|Returns or sets control's frame.<br/>            Read/write [IShapeFrame](/slides/python-net/api-reference/aspose.slides/ishapeframe/).|
|properties|Returns a collection of ActiveX properties.<br/>            Read-only [IControlPropertiesCollection](/slides/python-net/api-reference/aspose.slides/icontrolpropertiescollection/).|
|persistence|Gets the method used to store properties of the ActiveX control.<br/>            Read only [PersistenceType](/slides/python-net/api-reference/aspose.slides/persistencetype/).|
|active_xcontrol_binary|Specifies the persistence of an ActiveX control when the method used to persist is either PersistStream, PersistStreamInit or PersistStorage.|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/slides/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/slides/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/slides/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/slides/python-net/api-reference/aspose.slides/ipresentation/).|
