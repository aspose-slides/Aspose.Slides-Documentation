---
title: Convert PPT to PPTX
type: docs
weight: 20
url: /python-net/convert-ppt-to-pptx/
keywords: "Convert PowerPoint Presentation, PPT to PPTX, Python, Aspose.Slides"
description: "Convert PowerPoint PPT to PPTX in Python"
---

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
To convert a PPT to PPTX simply pass the file name and save format to the [**Save**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) method of [**Presentation**](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class. The code sample below converts a Presentation from PPT to PPTX using default options.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a PPTX file
pres = slides.Presentation("PPTtoPPTX.ppt")

# Saving the PPTX presentation to PPTX format
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```



Read more about [**PPT vs PPTX**](/slides/python-net/ppt-vs-pptx/) presentation formats and how [**Aspose.Slides supports PPT to PPTX conversion**](/slides/python-net/convert-ppt-to-pptx/).


