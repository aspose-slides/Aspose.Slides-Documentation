---
title: Convert PPTX to PPT in .NET
linktitle: PPTX to PPT
type: docs
weight: 21
url: /net/convert-pptx-to-ppt/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPTX
- PPTX to PPT
- save PPTX as PPT
- export PPTX to PPT 
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Easily convert PPTX to PPT with Aspose.Slides for .NET—ensure seamless compatibility with PowerPoint formats while preserving your presentation’s layout and quality."
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPTX format into PPT format using C#. The following topic is covered.

- Convert PPTX to PPT in C#

## **Convert PPTX to PPT in .NET**

For C# sample code to convert PPTX to PPT, please see the section below i.e. [Convert PPTX to PPT](#convert-pptx-to-ppt). It just loads the PPTX file and saves in PPT format. By specifiying different save formats, you can also save PPTX file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles. 

- [Convert PPTX to PDF in .NET](/slides/net/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in .NET](/slides/net/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in .NET](/slides/net/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in .NET](/slides/net/save-presentation/)
- [Convert PPTX to PNG in .NET](/slides/net/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
To convert a PPTX to PPT simply pass the file name and save format to the [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) method of [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class. The C# code sample below converts a Presentation from PPTX to PPT using default options.

```c#
// Instantiate a Presentation object that represents a PPTX file
Presentation pres = new Presentation("presentation.pptx");

// Saving the PPTX presentation to PPT format
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **FAQ**

**Do all PPTX effects and features survive when saving to the legacy PPT (97–2003) format?**

Not always. The PPT format lacks some newer capabilities (e.g., certain effects, objects, and behaviors), so features may be simplified or rasterized during conversion.

**Can I convert only selected slides to PPT instead of the entire presentation?**

Direct saving targets the whole presentation. To convert specific slides, create a new presentation with just those slides and save it as PPT; alternatively, use a service/API that supports per-slide conversion parameters.

**Are password-protected presentations supported?**

Yes. You can detect whether a file is protected, open it with a password, and also [configure protection/encryption settings](/slides/net/password-protected-presentation/) for the saved PPT.
