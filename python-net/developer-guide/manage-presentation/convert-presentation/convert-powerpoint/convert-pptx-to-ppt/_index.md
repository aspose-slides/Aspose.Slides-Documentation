---
title: Convert PPTX to PPT in Python
linktitle: Convert PPTX to PPT
type: docs
weight: 21
url: /python-net/convert-pptx-to-ppt/
keywords: "Python Convert PPTX to PPT, Convert PowerPoint Presentation, PPTX to PPT, Python, Aspose.Slides"
description: "Convert PowerPoint PPTX to PPT in Python"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPTX format into PPT format using Python. The following topic is covered.

- Convert PPTX to PPT in Python

## **Python Convert PPTX to PPT**

For Python sample code to convert PPTX to PPT, please see the section below i.e. [Convert PPTX to PPT](#convert-pptx-to-ppt). It just loads the PPTX file and saves in PPT format. By specifiying different save formats, you can also save PPTX file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles. 

- [Python Convert PPTX to PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convert PPTX to XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convert PPTX to HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convert PPTX to ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convert PPTX to Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**
To convert a PPTX to PPT simply pass the file name and save format to the [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method of [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. The Python code sample below converts a Presentation from PPTX to PPT using default options.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
pres = slides.Presentation("presentation.pptx")

# Saving the PPTX presentation to PPT format
pres.save("presentation.ppt", slides.export.SaveFormat.PPT)
```
