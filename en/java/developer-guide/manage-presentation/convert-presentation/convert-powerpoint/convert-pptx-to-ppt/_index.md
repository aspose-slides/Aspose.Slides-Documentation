---
title: Convert PPTX to PPT in Java
linktitle: Convert PPTX to PPT
type: docs
weight: 21
url: /java/convert-pptx-to-ppt/
keywords: "Java Convert PPTX to PPT, Convert PowerPoint Presentation, PPTX to PPT, Java, Aspose.Slides"
description: "Convert PowerPoint PPTX to PPT in Java"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPTX format into PPT format using Java. The following topic is covered.

- Convert PPTX to PPT in Java

## **Java Convert PPTX to PPT**

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