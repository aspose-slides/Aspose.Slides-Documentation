---
title: Convert Slide
type: docs
weight: 41
url: /python-net/convert-slide/
keywords: 
- convert slide to image
- export slide as image
- save slide as image
- slide to image
- slide to PNG
- slide to JPEG
- slide to bitmap
- PHP
- Aspose.Slides for Python via .NET
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in Python"
---

Aspose.Slides for Python via .NET allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First, set the conversion parameters and the slide objects to convert using:
   * the [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) interface or
   * the [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/) interface. 

2. Second, convert the slide to an image by using the [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method. 

## **About Bitmap and Other Image Formats**

In .NET, a [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose recently developed an online [Text to GIF](https://products.aspose.app/slides/text-to-gif) converter. 

{{% /alert %}}

## **Converting Slides to Bitmap and Saving the Images in PNG**

This Python code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Converts the first slide in the presentation to a Bitmap object
    with pres.slides[0].get_image() as bmp:
        # Saves the image in the PNG format
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) method in Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Converts the first slide in the presentation to a Bitmap with the specified size
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # Saves the image in the JPEG format
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) and [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) interface, you get to specify your preferred position for notes and comments in the resulting image. 

{{% /alert %}} 

This Python code demonstrates the conversion process for a slide with notes and comments:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Creates the rendering options
    options = slides.export.RenderingOptions()
                
    # Sets the position of the notes on the page
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # Sets the position of the comments on the page 
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # Sets the width of the comment output area
    options.notes_comments_layouting.comments_area_width = 500
                
    # Sets the color for the comments area
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # Converts the first slide of the presentation to a Bitmap object
    bmp = pres.slides[0].get_image(options, 2, 2)

    # Saves the image in the GIF format
    bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

This Python code demonstrates a conversion process where ITiffOptions is used to output a black and white image with a 300dpi resolution and 2160 × 2800 size:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # Gets a slide by its index
    slide = pres.slides[0]

    # Creates a TiffOptions object
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # Set the font used in case source font is not found
    options.default_regular_font = "Arial Black"

    # Set the position of the notes on the page 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Sets the pixel format (black and white)
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # Sets the resolution
    options.dpi_x = 300
    options.dpi_y = 300

    # Converts the slide to a Bitmap object
    with slide.get_image(options) as bmp:
        # Saves the image in BMP format
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in Python:

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Renders presentation to images array slide by slide
    for i in range(len(pres.slides)):
        # Specifies the setting for hidden slides (do not render hidden slides)
        if pres.slides[i].hidden:
            continue

        # Converts the slide to a Bitmap object
        with pres.slides[i].get_image2) as bmp:
            # Saves the image in the JPEG format
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```

