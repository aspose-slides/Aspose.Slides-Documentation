---
title: MathPortion Class
type: docs
weight: 760
url: /python-net/api-reference/aspose.slides.mathtext/mathportion/
---

Represents a portion with mathematical context inside.

**Namespace:** [aspose.slides.mathtext](/slides/python-net/api-reference/aspose.slides.mathtext/)

**Full Class Name:** aspose.slides.mathtext.MathPortion

**Assembly:**  Aspose.Slides Version: 21.12.0.0

The MathPortion type exposes the following members:
## **Constructors**
|**Name**|**Description**|
| :- | :- |
|MathPortion()|Initializes a new instance of the MathPortion class.|
## **Properties**
|**Name**|**Description**|
| :- | :- |
|portion_format|Returns oformatting bject which contains explicitly set formatting properties of the text portion with no inheritance applied.<br/>            Read-only [IPortionFormat](/python-net/api-reference/aspose.slides/iportionformat/).|
|text|Gets or sets the plain text of a portion.<br/>            Read/write string.|
|field|Returns a field of this portion.<br/>            Read-only [IField](/python-net/api-reference/aspose.slides/ifield/).|
|math_paragraph|Math paragraph|
|as_islide_component|Allows to get base ISlideComponent interface.<br/>            Read-only [ISlideComponent](/python-net/api-reference/aspose.slides/islidecomponent/).|
|slide|Returns the base slide.<br/>            Read-only [IBaseSlide](/python-net/api-reference/aspose.slides/ibaseslide/).|
|as_ipresentation_component|Allows to get base IPresentationComponent interface.<br/>            Read-only [IPresentationComponent](/python-net/api-reference/aspose.slides/ipresentationcomponent/).|
|presentation|Returns the presentation. <br/>            Read-only [IPresentation](/python-net/api-reference/aspose.slides/ipresentation/).|
## **Methods**
|**Name**|**Description**|
| :- | :- |
|add_field(field_type)|Converts this portion to the automaticaly updated field.|
|add_field(internal_string)|Converts this portion to the automaticaly updated field.|
|remove_field()|Converts this field portion to the simple portion.|
|get_rect()|Get coordinates of rect that bounds portion. The rect includes all the lines of<br/>             text in portion, including empty ones.|
|get_coordinates()|Get coordinates of the beginning of the portion. The X coordinate of point represents the <br/>            portion beginning from the first character including left side bearing. The Y coordinate <br/>            includes top side bearing.|
