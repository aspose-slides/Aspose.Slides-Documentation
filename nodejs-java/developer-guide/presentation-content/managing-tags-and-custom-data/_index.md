---
title: Managing Tags and Custom Data
type: docs
weight: 300
url: /nodejs-java/managing-tags-and-custom-data

---

## Data Storage in Presentation Files

PPTX files—items with the .pptx extension—are stored in the PresentationML format, which is part of the Office Open XML specification. The Office Open XML format defines the structure for data contained in presentations. 

With a *slide* being one of the elements in presentations, a *slide part* contains the content of a single slide. A slide part is allowed to have explicit relationships to many parts—such as User Defined Tags—defined by ISO/IEC 29500. 

Custom data (specific to a presentation) or user can exist as tags ([TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)) and CustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)).

{{% alert color="primary" %}} 

Tags are essentially string-key pair values. 

{{% /alert %}} 

## Getting the Values for Tags

In slides, a tag corresponds to the [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) and [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) methods. This sample code shows you how to get a tag’s value with Aspose.Slides for Node.js via Java for [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation):

```javascript
    var pres = new aspose.slides.Presentation("pres.pptx");
    try {
        var keywords = pres.getDocumentProperties().getKeywords();
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## Adding Tags to Presentations

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items: 

- the name of a custom property - `MyTag` 
- the value of the custom property - `My Tag Value`

If you need to classify some presentations based on a specific rule or property, then you may benefit from adding tags to those presentations. For example, if you want to categorize or put all presentations from North American countries together, you can create a North American tag and then assign the relevant countries (the U.S., Mexico, and Canada) as the values. 

This sample code shows you how to add a tag to a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) using Aspose.Slides for Node.js via Java:

```javascript
    var pres = new aspose.slides.Presentation("pres.pptx");
    try {
        var tags = pres.getCustomData().getTags();
        pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

Tags also can be set for [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide):

```javascript
    var pres = new aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        slide.getCustomData().getTags().set_Item("tag", "value");
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

Or any individual [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape):

```javascript
    var pres = new aspose.slides.Presentation();
    try {
        var slide = pres.getSlides().get_Item(0);
        var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
        shape.getTextFrame().setText("My text");
        shape.getCustomData().getTags().set_Item("tag", "value");
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```
