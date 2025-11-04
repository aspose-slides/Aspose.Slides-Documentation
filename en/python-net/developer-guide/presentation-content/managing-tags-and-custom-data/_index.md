---
title: Manage Tags and Custom Data in Presentations with Python
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /python-net/managing-tags-and-custom-data/
keywords:
- document properties
- tag
- custom data
- add tag
- pair values
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Learn how to add, read, update, and remove tags & custom data in Aspose.Slides for Python via .NET, with examples for PowerPoint and OpenDocument presentations."
---

## **Data Storage in Presentation Files**

PPTX files—items with the .pptx extension—are stored in the PresentationML format, which is part of the Office Open XML specification. The Office Open XML format defines the structure for data contained in presentations. 

With a *slide* being one of the elements in presentations, a *slide part* contains the content of a single slide. A slide part is allowed to have explicit relationships to many parts—such as User Defined Tags—defined by ISO/IEC 29500. 

Custom data (specific to a presentation) or user can exist as tags ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) and CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Tags are essentially string-key pair values. 

{{% /alert %}} 

## **Get the Values of Tags**

In slides, a tag corresponds to the IDocumentProperties.Keywords property. This sample code shows you how to get a tag’s value with Aspose.Slides for Python via .NET for [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items: 

- the name of a custom property - `MyTag` 
- the value of the custom property - `My Tag Value`

If you need to classify some presentations based on a specific rule or property, then you may benefit from adding tags to those presentations. For example, if you want to categorize or put all presentations from North American countries together, you can create a North American tag and then assign the relevant countries (the U.S., Mexico, and Canada) as the values. 

This sample code shows you how to add a tag to a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) using Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Tags also can be set for [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

Or any individual [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) operation that deletes all key–value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use the [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) operation on [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) on the [tag collection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); it returns an array of all tag names.
