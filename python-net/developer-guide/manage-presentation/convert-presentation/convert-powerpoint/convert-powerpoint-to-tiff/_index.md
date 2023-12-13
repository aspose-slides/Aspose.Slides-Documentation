---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /python-net/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, Python, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in Python"
---

**TIFF** (Tagged Image File Format) is a lossless raster and high-quality image format. Professionals use TIFF for their design, photography, and desktop publishing purposes. For example, if you want to preserve layers and settings in your design or image, you may want to save your work as a TIFF image file. 

Aspose.Slides allows you to convert the slides in PowerPoint directly to TIFF. 

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose's [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF**

Using the [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) method exposed by the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the slides' default size. 

This Python code shows you how to convert PowerPoint to TIFF:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
presentation = slides.Presentation("pres.pptx")
# Saves the presentation as TIFF
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```

## **Convert PowerPoint to Black-and-White TIFF**

In Aspose.Slides 23.10, Aspose.Slides added a new property `bw_conversion_mode` to the [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) class to allow you to specify the algorithm that is followed when a colored slide or image is converted to a black-and-white TIFF. Note that this setting is applied only when the `compression_type` property is set to `CCITT4` or `CCITT3`.

This Python code shows you how to convert a colored slide or image to black-and-white TIFF: xxx

```python

```

## **Convert PowerPoint to TIFF with Custom Size**

If you require a TIFF image with defined dimensions, you can define your preferred figures through the properties provided under [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/). Using the `image_size` property, for example, you can set a size for the resulting image. 

This Python code shows you how to convert PowerPoint to TIFF images with custom size:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instantiates a Presentation object that represents a presentation file
pres = slides.Presentation("pres.pptx")

# Instantiates the TiffOptions class
opts = slides.export.TiffOptions()

# Sets the compression type
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Sets the image DPI
opts.dpi_x = 200
opts.dpi_y = 100

# Sets the Image Size
opts.image_size = drawing.Size(1728, 1078)

# Saves the presentation to TIFF with specified size
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```


## **Convert PowerPoint to TIFF with Custom Image Pixel Format**

Using the `pixel_format` property under the [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image. 

This Python code shows you how to convert PowerPoint to TIFF image with custom pixel format:

```python
import aspose.slides as slides

# Instantiates a Presentation object that represents a presentation file
pres = slides.Presentation("pres.pptx")

# Instantiates the TiffOptions class
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED

# Saves the presentation to TIFF with specified size
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```

