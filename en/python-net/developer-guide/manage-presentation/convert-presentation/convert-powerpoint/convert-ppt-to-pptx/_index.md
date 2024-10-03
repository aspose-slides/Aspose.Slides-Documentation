---
title: Convert PPT to PPTX in Python
linktitle: Convert PPT to PPTX
type: docs
weight: 20
url: /python-net/convert-ppt-to-pptx/
keywords: "Python Convert PPT to PPTX, Convert PowerPoint Presentation, PPT to PPTX, Python, Aspose.Slides"
description: "Convert PowerPoint PPT to PPTX in Python"
---

## **Overview**

This article explains how to convert PowerPoint Presentation in PPT format into PPTX format using Python and with online PPT to PPTX conversion app. The following topic is covered.

- Convert PPT to PPTX in Python

## **Python Convert PPT to PPTX**

For Python sample code to convert PPT to PPTX, please see the section below i.e. [Convert PPT to PPTX](#convert-ppt-to-pptx). It just loads the PPT file and saves in PPTX format. By specifiying different save formats, you can also save PPT file into many other formats like PDF, XPS, ODP, HTML etc. as disscussed in these articles. 

- [Python Convert PPT to PDF](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-pdf/)
- [Python Convert PPT to XPS](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-xps/)
- [Python Convert PPT to HTML](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-html/)
- [Python Convert PPT to ODP](https://docs.aspose.com/slides/python-net/save-presentation/)
- [Python Convert PPT to Image](https://docs.aspose.com/slides/python-net/convert-powerpoint-to-png/)

## **About PPT to PPTX Conversion**
Convert old PPT format to PPTX with Aspose.Slides API. If you need to convert thousands of PPT presentations to PPTX format, the best solution is to do it programmatically. With Aspose.Slides API its possible to do it just in few lines of code. The API supports full compatibility to convert PPT presentation to PPTX and its possible to:

- Convert complicated structures of masters, layouts and slides.
- Convert presentation with charts.
- Convert presentation with group shapes, auto-shapes (like rectangles and ellipses), shapes with custom geometry.
- Convert presentation, having textures and pictures fill styles for auto-shapes.
- Convert presentation with placeholders, text frames and text holders.

{{% alert color="primary" %}} 

Take a look at [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/conversion/ppt-to-pptx) app:

[](https://products.aspose.app/slides/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/conversion/ppt-to-pptx)

This app is built based on **Aspose.Slides API**, so you may see alive example of basic PPT to PPTX conversion capabilities. Aspose.Slides Conversion is a web app, which allows to drop presentation file in PPT format and download it converted to PPTX.

Find other live [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) examples.
{{% /alert %}} 


## **Convert PPT to PPTX**
To convert a PPT to PPTX simply pass the file name and save format to the [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method of [**Presentation**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class. The Python code sample below converts a Presentation from PPT to PPTX using default options.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Saving the PPTX presentation to PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```



Read more about [**PPT vs PPTX**](/slides/python-net/ppt-vs-pptx/) presentation formats and how [**Aspose.Slides supports PPT to PPTX conversion**](/slides/python-net/convert-ppt-to-pptx/).



