---
title: Convert Slide
type: docs
weight: 41
url: /python-net/convert-slide/
keywords: "Convert slide to image, export slide as image, save slide as image, slide to image, slide to PNG, slide to JPEG, slide to Bitmap, Python, Aspose.Slides"
description: "Convert PowerPoint slide to image (Bitmap, PNG, or JPG) in Python"
---

Aspose.Slides for Python via .NET allows you to convert slides (in presentations) to images. These are the supported image formats: BMP, PNG, JPG (JPEG), GIF, and others. 

To convert a slide to an image, do this: 

1. First,
   * convert the slide to a Bitmap first by using the [get_thumbnail](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method or
   * render the slide to a Graphics object by using the [render_to_graphics](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method from the [ISlide](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) interface.

2. Second, set additional options for conversion and convertible slide objects through
   * the [ITiffOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/itiffoptions/) interface or
   * the [IRenderingOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/irenderingoptions/) interface. 

## **About Bitmap and Other Image Formats**

In .NET, a [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) is an object that allows you to work with images defined by pixel data. You can use an instance of this class to save images in a wide range of formats (BMP, JPG, PNG, etc.).

## **Converting Slides to Bitmap and Saving the Images in PNG**

This Python code shows you how to convert the first slide of a presentation to a bitmap object and then how to then save the image in the PNG format:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Converts the first slide in the presentation to a Bitmap object
    with pres.slides[0].get_thumbnail() as bmp:
        # Saves the image in the PNG format
        bmp.save("Slide_0.png", draw.imaging.ImageFormat.png)
```

This sample code shows you how to convert the first slide of a presentation to a bitmap object using the [render_to_graphics](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Gets the presentation slide size
    slideSize = pres.slide_size.size

    # Creates a Bitmap with the slide size
    with draw.Bitmap(slideSize.width, slideSize.height) as slideImage:
        # Renders the first slide to the Graphics object
        with draw.Graphics.from_image(slideImage) as graphics:
            pres.slides[0].render_to_graphics(slides.export.RenderingOptions(), graphics)

        slideImage.save("Slide_1.png", draw.imaging.ImageFormat.png)
```

{{% alert title="Tip" color="primary" %}} 

You can convert a slide to a bitmap object and then use the object directly somewhere. Or you can convert a slide to a bitmap and then save the image in JPEG or any other format you prefer. 

{{% /alert %}}  

## **Converting Slides to Images with Custom Sizes**

You may need to get an image of a certain size. Using an overload from the [get_thumbnail](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) or [render_to_graphics](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method, you can convert a slide to an image with specific dimensions (length and width). 

This sample code demonstrates the proposed conversion using the [get_thumbnail](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method in Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Converts the first slide in the presentation to a Bitmap with the specified size
    with pres.slides[0].get_thumbnail(draw.Size(1820, 1040)) as bmp:
        # Saves the image in the JPEG format
        bmp.save("Slide_0.jpg", draw.imaging.ImageFormat.jpeg)
```

This Python code demonstrates how to convert the first slide to the framed image with the [render_to_graphics](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    slideSize = draw.Size(1820, 1040)

    # Creates a Bitmap with the specified size (slide size + fields)
    with draw.Bitmap(slideSize.width + 50, slideSize.height + 50) as slideImage:
        with draw.Graphics.from_image(slideImage) as graphics:
            # Fills and translates Graphics to create a frame around the slide
            graphics.clear(draw.Color.red)
            graphics.translate_transform(25, 25)

            # Renders the first slide to Graphics
            pres.slides[0].render_to_graphics(slides.export.RenderingOptions(), graphics, slideSize)

        # Saves the image in the JPEG format
        slideImage.save("FramedSlide_0.jpg", draw.imaging.ImageFormat.jpeg)
```

## **Converting Slides With Notes and Comments to Images**

Some slides contain notes and comments. 

Aspose.Slides provides two interfaces—[ITiffOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/itiffoptions/) and [IRenderingOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/irenderingoptions/)—that allow you to control the rendering of presentation slides to images. Both interfaces house the [INotesCommentsLayoutingOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/inotescommentslayoutingoptions/) interface that allows you to add notes and comments on a slide when you are converting that slide to an image.

{{% alert title="Info" color="info" %}} 

With the [INotesCommentsLayoutingOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/inotescommentslayoutingoptions/) interface, you get to specify your preferred position for notes and comments in the resulting image. 

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
    bmp = pres.slides[0].get_thumbnail(options, 2, 2)

    # Saves the image in the GIF format
    bmp.save("Slide_Notes_Comments_0.gif", draw.imaging.ImageFormat.gif)
```

This Python code demonstrates the conversion process for a slide with notes using the [render_to_graphics](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/islide/) method:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # Gets the presentation notes size
    notesSize = pres.notes_size.size.to_size()

    # Creates the rendering options
    options = slides.export.RenderingOptions()

    # Sets the position of the notes
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # Creates a Bitmap with the notes' size
    with draw.Bitmap(notesSize.width, notesSize.height) as slideImage:
        # Renders the first slide to Graphics
        with draw.Graphics.from_image(slideImage) as graphics:
            pres.slides[0].render_to_graphics(options, graphics, notesSize)

        # Saves the image in PNG format
        slideImage.save("Slide_Notes_0.png", draw.imaging.ImageFormat.png)
```

{{% alert title="Note" color="warning" %}} 

In any slide to image conversion process, the [NotesPositions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/inotescommentslayoutingoptions/) property cannot be set to BottomFull (to specify the position for notes) because a note's text may be large, which means it might not fit into the specified image size. 

{{% /alert %}} 

## **Converting Slides to Images Using ITiffOptions**

The [ITiffOptions](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides.export/itiffoptions/) interface gives you more control (in terms of parameters) over the resulting image. Using this interface, you get to specify the size, resolution, color palette, and other parameters for the resulting image. 

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
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT1BPP_INDEXED

    # Sets the resolution
    options.dpi_x = 300
    options.dpi_y = 300

    # Converts the slide to a Bitmap object
    with slide.get_thumbnail(options) as bmp:
        # Saves the image in BMP format
        bmp.save("PresentationNotesComments.tiff", draw.imaging.ImageFormat.tiff)
```

## **Converting All Slides to Images**

Aspose.Slides allows you to convert all slides in a single presentation to images. Essentially, you get to convert the presentation (in its entirety) to images. 

This sample code shows you how to convert all slides in a presentation to images in Python:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # Renders presentation to images array slide by slide
    for i in range(len(pres.slides)):
        # Specifies the setting for hidden slides (do not render hidden slides)
        if pres.slides[i].hidden:
            continue

        # Converts the slide to a Bitmap object
        with pres.slides[i].get_thumbnail(2, 2) as bmp:
            # Saves the image in the JPEG format
            bmp.save("image_{0}.jpeg".format(i), draw.imaging.ImageFormat.jpeg)
```

