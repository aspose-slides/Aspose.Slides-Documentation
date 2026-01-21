---
title: Manage Tags and Custom Data in Presentations Using C++
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /cpp/managing-tags-and-custom-data/
keywords:
- document properties
- tag
- custom data
- add tag
- pair values
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Learn how to add, read, update, and remove tags & custom data in Aspose.Slides for C++, with examples for PowerPoint and OpenDocument presentations."
---

## **Data Storage in Presentation Files**

PPTX files—items with the .pptx extension—are stored in the PresentationML format, which is part of the Office Open XML specification. The Office Open XML format defines the structure for data contained in presentations. 

With a *slide* being one of the elements in presentations, a *slide part* contains the content of a single slide. A slide part is allowed to have explicit relationships to many parts—such as User Defined Tags—defined by ISO/IEC 29500. 

Custom data (specific to a presentation) or user can exist as tags ([ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)) and CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Tags are essentially string-key pair values. 

{{% /alert %}} 

## **Get Values of Tags**

In slides, a tag corresponds to the IDocumentProperties.Keywords property. This sample code shows you how to get a tag’s value with Aspose.Slides for C++ for [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items: 

- the name of a custom property - `MyTag` 
- the value of the custom property - `My Tag Value`

If you need to classify some presentations based on a specific rule or property, then you may benefit from adding tags to those presentations. For example, if you want to categorize or put all presentations from North American countries together, you can create a North American tag and then assign the relevant countries (the U.S., Mexico, and Canada) as the values. 

This sample code shows you how to add a tag to a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) using Aspose.Slides for C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Tags also can be set for [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

Or any individual [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) operation that deletes all key–value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use the [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) operation on [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) on the [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); it returns an array of all tag names.
