---
title: Manage Zoom
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords: "Zoom, Zoom frame, Add zoom, Format zoom frame, Summary zoom, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Add zoom or zoom frames to PowerPoint presentations in Python"
---

## **Overview**
A slide zoom can help you make your presentation more dynamic. It allows you to navigate freely between slides in any order without interruptions to the flow of your presentation. 

With a slide zoom, you get to deeply examine several information parts while feeling like you were on a single canvas. 

![overview_image](Overview.png)

To allow you use zoom objects, Aspose.Slides provides the [ZoomImageType](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/zoomimagetype/) enumeration, the [IZoomFrame](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/izoomframe/) interface, and some methods in the [IShapeCollection](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ishapecollection/) interface.

## **Creating Zoom Frames**
Zoom frame is one of the shapes offered by Aspose.Slides for Python via .NET. We intend to provide simple steps and examples to show you how to add zoom frames to slides. 

You can add a zoom frame in a slide using Aspose.Slides for Python via .NET this way:

1.	Create an instance of the [Presentation](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/presentation/) class.
2.	Create new slides to which you intend to link. 
3.	Add an identification text and background to the created slides.
4.  Add zoom frames (containing the references to created slides) into the first slide.
5.	Write the modified presentation as a PPTX file.

This sample code shows you how to create a zoom frame in a slide:
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Add new slides to the presentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Create a background for the second slide
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Create a text box for the second slide
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Create a background for the third slide
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Create a text box for the third slide
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame objects
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Save the presentation
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
## **Creating Zoom Frames with Custom Images**
With Aspose.Slides for Python via .NET, you can create a zoom frame with an image other than the slide preview image this way: 
1.	Create an instance of the `Presentation` class.
2.	Create a new slide to which you intend to link. 
3.	Add an identification text and background to created slide.
4.  Create an [IPPImage](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ippimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
5.  Add zoom frames (containing the reference to created slide) into the first slide.
6.	Write the modified presentation as a PPTX file.

This sample code shows you how to create a zoom frame with a different image:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Add a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Create a background for the second slide
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Create a text box for the third slide
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Create a new image for the zoom object
    image = pres.images.add_image(draw.Image.from_file("img.jpeg"))

    #Add the ZoomFrame object
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Save the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Formatting Zoom Frames**
In the previous sections (above), we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter the frames' formatting. There are several formatting settings you can apply on a zoom frame. 

You can control the formatting of a zoom frame in a slide this way:

1.	Create an instance of the `Presentation` class.
2.	Create new slides to link to.
3.	Add identification text and background to created slides.
4.  Add zoom frames (containing the references to created slides) into the first slide.
5.  Create an [IPPImage](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/ippimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
6.  Set a custom image for the first zoom frame object.
7.  Change the line format for the second zoom frame object.
8.  Remove the background from an image of the second zoom frame object.
5.	Write the modified presentation as a PPTX file.

This sample code shows you how to change the formatting of a zoom frame: 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Add new slides to presentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Create a background for the second slide
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Create a text box for the second slide
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Create a background for the third slide
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Create a text box for the third slide
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Add ZoomFrame objects
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Create a new image for the zoom object
    image = pres.images.add_image(draw.Image.from_file("img.jpeg"))
    # Set custom image for zoomFrame1 object
    zoomFrame1.image = image

    # Set a zoom frame format for the zoomFrame2 object
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Do not show background for zoomFrame2 object
    zoomFrame2.show_background = False

    # Save the presentation
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Creating a Summary Zoom**
A summary zoom is like a landing page that allows you to see all the parts of your presentation at once. By adding a summary zoom to your presentation, you get to jump in and out of different slides or move between them in any order. 

![overview_image](SummaryZoom.png)

Aspose.Slides for Python via .NET has no methods for creating a summary zoom, but it has an API that allows you to achieve the same effect and do even more. 

You can create a summary zoom in a slide this way:

1.	Create an instance of the `Presentation` class.
2.	Create new slides to which you intend to link. 
3.	Add an identification text and background to the created slides.
6.  Add zoom frames (containing the references to created slides) into the first slide.
5.  Set the [ReturnToParent](https://docs.aspose.com/slides/python-net/api-reference/aspose.slides/izoomframe/) property of every zoom frame object to `true`.

**Note**: If you have your own custom algorithm for placing zoom frame objects on a slide, you can use it. 

This sample code shows you how to create a summary zoom using Aspose.Slides for Python via .NET:

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Create slides array
    for slideNumber in range(5):
        #Add new slides to presentation
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Create a background for the slide
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Create a text box for the slide
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Create zoom objects for all slides in the first slide
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Set the ReturnToParent property to return to the first slide
        zoomFrame.return_to_parent = True

    # Save the presentation
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

  