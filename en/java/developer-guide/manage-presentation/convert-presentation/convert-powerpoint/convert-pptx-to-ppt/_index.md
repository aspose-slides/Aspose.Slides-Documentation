---
title: Convert PPTX to PPT in Java
linktitle: PPTX to PPT
type: docs
weight: 21
url: /java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Easily convert PPTX to PPT with Aspose.Slides for Java—ensure seamless compatibility with PowerPoint formats while preserving your presentation’s layout and quality."
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPTX format into PPT format using Java. The following topic is covered.

- Convert PPTX to PPT in Java

## **Convert PPTX to PPT in Java**

For Java sample code to convert PPTX to PPT, please see the section below i.e. [Convert PPTX to PPT](#convert-pptx-to-ppt). It just loads the PPTX file and saves in PPT format. By specifiying different save formats, you can also save PPTX file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles. 

- [Java Convert PPTX to PDF](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [Java Convert PPTX to XPS](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [Java Convert PPTX to HTML](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [Java Convert PPTX to ODP](https://docs.aspose.com/slides/java/save-presentation/)
- [Java Convert PPTX to Image](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
To convert a PPTX to PPT simply pass the file name and save format to the **Save** method of [**Presentation**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) class. The Java code sample below converts a Presentation from PPTX to PPT using default options.

```java
// instantiate a Presentation object that represents a PPTX file
Presentation presentation = new Presentation("template.pptx");

// save the presentation as PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Do all PPTX effects and features survive when saving to the legacy PPT (97–2003) format?**

Not always. The PPT format lacks some newer capabilities (e.g., certain effects, objects, and behaviors), so features may be simplified or rasterized during conversion.

**Can I convert only selected slides to PPT instead of the entire presentation?**

Direct saving targets the whole presentation. To convert specific slides, create a new presentation with just those slides and save it as PPT; alternatively, use a service/API that supports per-slide conversion parameters.

**Are password-protected presentations supported?**

Yes. You can detect whether a file is protected, open it with a password, and also [configure protection/encryption settings](/slides/java/password-protected-presentation/) for the saved PPT.
