---
title: Managing Tags and Custom Data
type: docs
weight: 300
url: /net/managing-tags-and-custom-data
keywords: "Tags, Custom data, Value for tags, Add tags, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Add tags and custom data to PowerPoint presentations in C# or .NET"
---

## Data Storage in Presentation Files

PPTX files—items with the .pptx extension—are stored in the PresentationML format, which is part of the Office Open XML specification. The Office Open XML format defines the structure for data contained in presentations. 

With a *slide* being one of the elements in presentations, a *slide part* contains the content of a single slide. A slide part is allowed to have explicit relationships to many parts—such as User Defined Tags—defined by ISO/IEC 29500. 

Custom data (specific to a presentation) or user can exist as tags ([ITagCollection](https://apireference.aspose.com/slides/net/aspose.slides/itagcollection)) and CustomXmlParts ([ICustomXmlPartCollection](https://apireference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)). 

{{% alert color="primary" %}} 

Tags are essentially string-key pair values. 

{{% /alert %}} 

## Getting the Values for Tags

In slides, a tag corresponds to the IDocumentProperties.Keywords property. This sample code shows you how to get a tag’s value with Aspose.Slides for .NET for [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation):

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## Adding Tags to Presentations

Aspose.Slides allows you to add tags to presentations. A tag typically consists of two items: 

- the name of a custom property - `MyTag` 
- the value of the custom property - `My Tag Value`

If you need to classify some presentations based on a specific rule or property, then you may benefit from adding tags to those presentations. For example, if you want to categorize or put all presentations from North American countries together, you can create a North American tag and then assign the relevant countries (the U.S., Mexico, and Canada) as the values. 

This sample code shows you how to add a tag to a [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) using Aspose.Slides for .NET:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

Tags also can be set for [Slide](https://apireference.aspose.com/slides/net/aspose.slides/slide):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

Or any individual [Shape](https://apireference.aspose.com/slides/net/aspose.slides/shape):

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```