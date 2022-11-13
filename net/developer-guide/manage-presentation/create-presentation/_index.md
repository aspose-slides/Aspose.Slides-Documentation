---
title: Create Presentation in .NET
linktitle: Create Presentation
type: docs
weight: 10
url: /net/create-presentation/
keywords: "Create PowerPoint, PPTX, PPT, Create Presentation, Initialize Presentation, C#, .NET"
description: "Creating PowerPoint Presentations Programmatically in C# e.g. PPT, PPTX, ODP etc."
---

## Overview

This article is part of the following three articles.

- [Create Presentation](https://docs.aspose.com/slides/net/create-presentation/)
- [Open Presentation](https://docs.aspose.com/slides/net/open-presentation/)
- [Save Presentation](https://docs.aspose.com/slides/net/save-presentation/)

<strong>Topics Covered</strong>

The above articles together cover many topics. e.g.

- [C# Creating PowerPoint Presentations Programmatically](#csharp-create-save-presentation)
- [C# Create PPT Presentation from Scratch](#csharp-create-save-presentation)
- [C# Convert PPT to ODP](#csharp-open-save-presentation)
- [C# Convert ODP to PPTX](#csharp-open-save-presentation)
- [See Also](#see-also)

## Create PowerPoint Presentation
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

## Create and Save Presentation

<a name="csharp-create-save-presentation"><strong>Steps: Create and Save Presentation in C#</strong></a>

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. Save _Presentation_ to any format supported by [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
Presentation presentation = new Presentation();

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## Open and Save Presentation

<a name="csharp-open-save-presentation"><strong>Steps: Open and Save Presentation in C#</strong></a>

1. Create an instance of [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class with any format i.e. PPT, PPTX, ODP etc.
2. Save _Presentation_ to any format supported by [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)

```c#
// Load any supported file in Presentation e.g. ppt, pptx, odp etc.
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```

## See Also 

This article also covers these topics. The codes are same as above.

_Format_: **PowerPoint - Scratch**
- [C# Create Presentation from Scratch](#csharp-create-save-presentation)
- [C# Create PowerPoint from Scratch](#csharp-create-save-presentation)
- [C# Create PPT from Scratch](#csharp-create-save-presentation)
- [C# Create PPTX from Scratch](#csharp-create-save-presentation)
- [C# Create ODP from Scratch](#csharp-create-save-presentation)

_Format_: **PPTX**
- [C# PPTX to PPT](#csharp-open-save-presentation)
- [C# PPTX to ODP](#csharp-open-save-presentation)
- [C# PPTX to PPS](#csharp-open-save-presentation)
- [C# PPTX to PDF](#csharp-open-save-presentation)
- [C# PPTX to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPTX to PPT](#csharp-open-save-presentation)
- [C# Convert PPTX to ODP](#csharp-open-save-presentation)
- [C# Convert PPTX to PPS](#csharp-open-save-presentation)
- [C# Convert PPTX to PDF](#csharp-open-save-presentation)
- [C# Convert PPTX to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPTX to PPT Programmatically](#csharp-open-save-presentation)
- [C# PPTX to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPTX to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPTX to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPTX to PPT API](#csharp-open-save-presentation)
- [C# PPTX to ODP API](#csharp-open-save-presentation)
- [C# PPTX to PPS API](#csharp-open-save-presentation)
- [C# PPTX to PDF API](#csharp-open-save-presentation)
- [C# PPTX to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPTX to PPT Code](#csharp-open-save-presentation)
- [C# PPTX to ODP Code](#csharp-open-save-presentation)
- [C# PPTX to PPS Code](#csharp-open-save-presentation)
- [C# PPTX to PDF Code](#csharp-open-save-presentation)
- [C# PPTX to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPTX to PPT Library](#csharp-open-save-presentation)
- [C# PPTX to ODP Library](#csharp-open-save-presentation)
- [C# PPTX to PPS Library](#csharp-open-save-presentation)
- [C# PPTX to PDF Library](#csharp-open-save-presentation)
- [C# PPTX to XPS Library](#csharp-open-save-presentation)

_Format_: **PPT**
- [C# PPT to PPTX](#csharp-open-save-presentation)
- [C# PPT to ODP](#csharp-open-save-presentation)
- [C# PPT to PPS](#csharp-open-save-presentation)
- [C# PPT to PDF](#csharp-open-save-presentation)
- [C# PPT to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert PPT to PPTX](#csharp-open-save-presentation)
- [C# Convert PPT to ODP](#csharp-open-save-presentation)
- [C# Convert PPT to PPS](#csharp-open-save-presentation)
- [C# Convert PPT to PDF](#csharp-open-save-presentation)
- [C# Convert PPT to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# PPT to PPTX Programmatically](#csharp-open-save-presentation)
- [C# PPT to ODP Programmatically](#csharp-open-save-presentation)
- [C# PPT to PPS Programmatically](#csharp-open-save-presentation)
- [C# PPT to PDF Programmatically](#csharp-open-save-presentation)
- [C# PPT to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# PPT to PPTX API](#csharp-open-save-presentation)
- [C# PPT to ODP API](#csharp-open-save-presentation)
- [C# PPT to PPS API](#csharp-open-save-presentation)
- [C# PPT to PDF API](#csharp-open-save-presentation)
- [C# PPT to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# PPT to PPTX Code](#csharp-open-save-presentation)
- [C# PPT to ODP Code](#csharp-open-save-presentation)
- [C# PPT to PPS Code](#csharp-open-save-presentation)
- [C# PPT to PDF Code](#csharp-open-save-presentation)
- [C# PPT to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# PPT to PPTX Library](#csharp-open-save-presentation)
- [C# PPT to ODP Library](#csharp-open-save-presentation)
- [C# PPT to PPS Library](#csharp-open-save-presentation)
- [C# PPT to PDF Library](#csharp-open-save-presentation)
- [C# PPT to XPS Library](#csharp-open-save-presentation)

_Format_: **ODP**
- [C# ODP to PPTX](#csharp-open-save-presentation)
- [C# ODP to PPT](#csharp-open-save-presentation)
- [C# ODP to PPS](#csharp-open-save-presentation)
- [C# ODP to PDF](#csharp-open-save-presentation)
- [C# ODP to XPS](#csharp-open-save-presentation)
- _Convert_
- [C# Convert ODP to PPTX](#csharp-open-save-presentation)
- [C# Convert ODP to PPT](#csharp-open-save-presentation)
- [C# Convert ODP to PPS](#csharp-open-save-presentation)
- [C# Convert ODP to PDF](#csharp-open-save-presentation)
- [C# Convert ODP to XPS](#csharp-open-save-presentation)
- _Programmatically_
- [C# ODP to PPTX Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPT Programmatically](#csharp-open-save-presentation)
- [C# ODP to PPS Programmatically](#csharp-open-save-presentation)
- [C# ODP to PDF Programmatically](#csharp-open-save-presentation)
- [C# ODP to XPS Programmatically](#csharp-open-save-presentation)
- _API_
- [C# ODP to PPTX API](#csharp-open-save-presentation)
- [C# ODP to PPT API](#csharp-open-save-presentation)
- [C# ODP to PPS API](#csharp-open-save-presentation)
- [C# ODP to PDF API](#csharp-open-save-presentation)
- [C# ODP to XPS API](#csharp-open-save-presentation)
- _Code_
- [C# ODP to PPTX Code](#csharp-open-save-presentation)
- [C# ODP to PPT Code](#csharp-open-save-presentation)
- [C# ODP to PPS Code](#csharp-open-save-presentation)
- [C# ODP to PDF Code](#csharp-open-save-presentation)
- [C# ODP to XPS Code](#csharp-open-save-presentation)
- _Library_
- [C# ODP to PPTX Library](#csharp-open-save-presentation)
- [C# ODP to PPT Library](#csharp-open-save-presentation)
- [C# ODP to PPS Library](#csharp-open-save-presentation)
- [C# ODP to PDF Library](#csharp-open-save-presentation)
- [C# ODP to XPS Library](#csharp-open-save-presentation)
