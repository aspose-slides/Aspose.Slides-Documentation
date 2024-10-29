---
title: Convert PPTX to PPT in C++
linktitle: Convert PPTX to PPT
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ Convert PPTX to PPT, Convert PowerPoint Presentation, PPTX to PPT, Python, Aspose.Slides"
description: "Convert PowerPoint PPTX to PPT in C++"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPTX format into PPT format using C++. The following topic is covered.

- Convert PPTX to PPT in C++

## **C++ Convert PPTX to PPT**

For C++ sample code to convert PPTX to PPT, please see the section below i.e. [Convert PPTX to PPT](#convert-pptx-to-ppt). It just loads the PPTX file and saves in PPT format. By specifiying different save formats, you can also save PPTX file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles. 

- [C++ Convert PPTX to PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convert PPTX to XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convert PPTX to HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convert PPTX to ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convert PPTX to Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
To convert a PPTX to PPT simply pass the file name and save format to the **Save** method of [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) class. The C++ code sample below converts a Presentation from PPTX to PPT using default options.

```cpp
// Load the PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Save in PPT format.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
