---
title: Manage Tags and Custom Data in Presentations on Android
linktitle: Tags and Custom Data
type: docs
weight: 300
url: /androidjava/managing-tags-and-custom-data
keywords:
- document properties
- tag
- custom data
- add tag
- pair values
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Add, read, update, and remove tags & custom data in Aspose.Slides for Android, with Java examples for PowerPoint and OpenDocument presentations."
---

## **Data Storage in Presentation Files**

PPTX files—items with the .pptx extension—are stored in the PresentationML format, which is part of the Office Open XML specification. The Office Open XML format defines the structure for data contained in presentations. 

With a *slide* being one of the elements in presentations, a *slide part* contains the content of a single slide. A slide part is allowed to have explicit relationships to many parts—such as User Defined Tags—defined by ISO/IEC 29500. 

Custom data (specific to a presentation) or user can exist as tags ([ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)) and CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

Tags are essentially string-key pair values. 

{{% /alert %}} 

## **Get Values of Tags**

In slides, a tag corresponds to the [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) and [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) methods. This sample code shows you how to get a tag’s value with Aspose.Slides for Android via Java for [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Tags to Presentations**

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items: 

- the name of a custom property - `MyTag` 
- the value of the custom property - `My Tag Value`

If you need to classify some presentations based on a specific rule or property, then you may benefit from adding tags to those presentations. For example, if you want to categorize or put all presentations from North American countries together, you can create a North American tag and then assign the relevant countries (the U.S., Mexico, and Canada) as the values. 

This sample code shows you how to add a tag to a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) using Aspose.Slides for Android via Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

Tags also can be set for [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

Or any individual [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape):

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I remove all tags from a presentation, slide, or shape in one operation?**

Yes. The [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) supports a [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) operation that deletes all key–value pairs at once.

**How do I delete a single tag by its name without iterating over the whole collection?**

Use the [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) operation on [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) to delete the tag by its key.

**How can I retrieve the complete list of tag names for analytics or filtering?**

Use [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) on the [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/); it returns an array of all tag names.
