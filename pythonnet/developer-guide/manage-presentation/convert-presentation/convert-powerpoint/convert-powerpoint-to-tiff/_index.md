---
title: Convert PowerPoint to TIFF
type: docs
weight: 90
url: /pythonnet/convert-powerpoint-to-tiff/
keywords: "Convert PowerPoint Presentation, PowerPoint to TIFF, PPT to TIFF, PPTX to TIFF, Python, Aspose.Slides"
description: "Convert PowerPoint presentation to TIFF in Python."
---



TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for Python via .NET provides the support for converting presentations into TIFF document.

{{% alert title="Tip" color="primary" %}}

You may want to check out Aspose [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **Convert PowerPoint to TIFF with default size**
The [Save](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation) class can be called by developers to convert the whole presentation into TIFF document. Further, [TiffOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/tiffoptions) class exposes **ImageSize** property enabling the developer to define the size of the image if required. The following example shows how to convert a presentation into TIFF document with default options.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
presentation = slides.Presentation("pres.pptx")
# Saving the presentation to TIFF document
presentation.save("Tiffoutput_out.tiff", slides.export.SaveFormat.TIFF)
```



## **Convert PowerPoint to TIFF with custom size**

The following example shows how to convert a presentation into TIFF document with customized image size using [TiffOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/tiffoptions) class. 

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("pres.pptx")

# Instantiate the TiffOptions class
opts = slides.export.TiffOptions()

# Setting compression type
opts.compression_type = slides.export.TiffCompressionTypes.DEFAULT
opts.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# Setting image DPI
opts.dpi_x = 200
opts.dpi_y = 100

# Set Image Size
opts.image_size = drawing.Size(1728, 1078)

# Save the presentation to TIFF with specified image size
pres.save("TiffWithCustomSize_out.tiff", slides.export.SaveFormat.TIFF, opts)
```




## **Convert PowerPoint to TIFF with custom Image Pixel Format**
The following example shows how to convert a presentation into TIFF document with customized Image Pixel Format using [TiffOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/tiffoptions) class. You can also include comments in generated HTML by using [TiffOptions](https://apireference.aspose.com/slides/pythonnet/aspose.slides.export/tiffoptions) class and **INotesCommentsLayoutingOptions** interface.

```py
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("pres.pptx")

# Instantiate the TiffOptions class
options = slides.export.TiffOptions()

options.pixel_format = slides.export.ImagePixelFormat.FORMAT8BPP_INDEXED

# Save the presentation to TIFF with specified image size
pres.save("Tiff_With_Custom_Image_Pixel_Format_out.tiff", slides.export.SaveFormat.TIFF, options)
```

