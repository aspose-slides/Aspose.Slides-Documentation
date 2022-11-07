---
title: Create Presentation
type: docs
weight: 10
url: /net/create-presentation/
keywords: "Create PowerPoint, PPTX, PPT, Create Presentation, Initialize Presentation, C#, .NET"
description: "Open PowerPoint Presentation in C# or .NET"
---

## **Create PowerPoint Presentation**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

1. Create an instance of Presentation class.
1. Obtain the reference of a slide by using its Index.
1. Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object.
1. Write the modified presentation as a PPTX file.

In the example given below, we have added a line to the first slide of the presentation.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation())
{
    // Get the first slide
    ISlide slide = presentation.Slides[0];

    // Add an autoshape of type line
    slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
    presentation.Save("NewPresentation_out.pptx", SaveFormat.Pptx);
}
```

## **Create and Save Presentation**

<a name="csharp-create-save-presentation"><strong>Steps: Create and Save Presentation in C#</strong></a>

1. Create an instance of [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Save _Presentation_ to any format supported by [**SaveFormat**](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## **Open and Save Presentation**

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class with any format i.e. PPT, PPTX, ODP etc.
2. Save _Presentation_ to any format supported by [**SaveFormat**](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Load any supported file in Presentation e.g. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```
