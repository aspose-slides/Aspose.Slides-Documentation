---
title: Manage Zooms in Presentations with Python
linktitle: Zoom
type: docs
weight: 60
url: /python-net/manage-zoom/
keywords:
- zoom
- zoom frame
- slide zoom
- section zoom
- summary zoom
- add zoom
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Create and customize Zoom with Aspose.Slides for Python via .NET — jump between sections, add thumbnails and transitions across PPT, PPTX and ODP presentations."
---

## **Overview**
Zooms in PowerPoint allow you to jump to and from specific slides, sections, and portions of a presentation. When you are presenting, this ability to navigate quickly across content might prove very useful. 

![overview](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#Summary-Zoom).
* To show selected slides only, use a [Slide Zoom](#Slide-Zoom).
* To show a single section only, use a [Section Zoom](#Section-Zoom).

## **Slide Zoom**

A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms help you drill into multiple pieces of information while you feel like you are on a single canvas. 

![slidezoomsel](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) enumeration, the [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) class, and some methods in the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Creating Zoom Frames**
You can add a zoom frame on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
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
### **Creating Zoom Frames with Custom Images**
With Aspose.Slides for Python via .NET, you can create a zoom frame with an image other than the slide preview image this way: 
1.	Create an instance of the `Presentation` class.
2.	Create a new slide to which you intend to link. 
3.	Add an identification text and background to created slide.
4.  Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
5.  Add zoom frames (containing the reference to created slide) into the first slide.
6.	Write the modified presentation as a PPTX file.

This python code shows you how to create a zoom frame with a different image:

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
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Add the ZoomFrame object
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Save the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatting Zoom Frames**
In the previous sections (above), we showed you how to create simple zoom frames. To create more complicated zoom frames, you have to alter the frames' formatting. There are several formatting settings you can apply on a zoom frame. 

You can control the formatting of a zoom frame in a slide this way:

1.	Create an instance of the `Presentation` class.
2.	Create new slides to link to.
3.	Add identification text and background to created slides.
4.  Add zoom frames (containing the references to created slides) into the first slide.
5.  Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the Presentation object that will be used to fill the frame.
6.  Set a custom image for the first zoom frame object.
7.  Change the line format for the second zoom frame object.
8.  Remove the background from an image of the second zoom frame object.
5.	Write the modified presentation as a PPTX file.

This python sample code shows you how to change the formatting of a zoom frame: 

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
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
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

## **Section Zoom**

A section zoom is a link to a section in your presentation. You can use section zooms to go back to sections you want to really emphasize. Or you can use them to highlight how certain pieces of your presentation connect. 

![seczoomsel](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) class and some methods under the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Creating Section Zoom Frames**

You can add a section zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide. 
3.	Add an identification background to the created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Add a section zoom frame (containing references to the created section) to the first slide.
6.	Write the modified presentation as a PPTX file.

This python code shows you how to create a zoom frame on a slide:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Adds a new Section to the presentation
    pres.sections.add_section("Section 1", slide)

    # Adds a SectionZoomFrame object
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Creating Section Zoom Frames with Custom Images**

Using Aspose.Slides for Python, you can create a section zoom frame with a different slide preview image this way: 

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide.
3.	Add an identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
6.	Add a section zoom frame (containing a reference to the created section) to the first slide.
7.	Write the modified presentation as a PPTX file.

This python code shows you how to create a zoom frame with a different image:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Adds a new Section to the presentation
    pres.sections.add_section("Section 1", slide)

    # Creates a new image for the zoom object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Adds a SectionZoomFrame object
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatting Section Zoom Frames**

To create more complicated section zoom frames, you have to alter a simple frame's formatting. There are several formatting options you can apply to a section zoom frame. 

You can control a section zoom frame's formatting on a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create a new slide.
3.	Add identification background to created slide.
4.	Create a new section to which you intend to link the zoom frame. 
5.	Add a section zoom frame (containing references to created section) to the first slide.
6.	Change the size and position for the created section zoom object.
7.	Create a [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) object by adding an image to the Images collection associated with the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
8.	Set a custom image for the created section zoom frame object.
9.	Set the *return to the original slide from the linked section* ability. 
10.	Remove the background from an image of the section zoom frame object.
11.	Change the line format for the second zoom frame object.
12.	Change the transition duration.
13.	Write the modified presentation as a PPTX file.

This python code shows you how to change a section zoom frame's formatting:

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new Section to the presentation
    pres.sections.add_section("Section 1", slide)

    # Add SectionZoomFrame object
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatting for SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Summary Zoom**

A summary zoom is like a landing page where all the pieces of your presentation are displayed at once. When you're presenting, you can use the zoom to go from one place in your presentation to another in any order you like. You can get creative, skip ahead, or revisit pieces of your slide show without interrupting the flow of your presentation.

![overview_image](summaryzoom.png)

For summary zoom objects, Aspose.Slides provides the [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), and [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) class and some methods under the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Creating Summary Zoom**

You can add a summary zoom frame to a slide this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add the summary zoom frame to the first slide.
4.	Write the modified presentation as a PPTX file.

This python code shows you how to create a summary zoom frame on a slide:

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

### **Adding and Removing Summary Zoom Section**

All sections in a summary zoom frame are represented by [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) objects, which are stored in the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) object. You can add or remove a summary zoom section object through the [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) class this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame into the first slide.
4.	Add a new slide and section to the presentation.
5.	Add the created section to the summary zoom frame.
6.	Remove the first section from the summary zoom frame.
7.	Write the modified presentation as a PPTX file.

This python code shows you how to add and remove sections in a summary zoom frame:

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    pres.sections.add_section("Section 1", slide)

    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    pres.sections.add_section("Section 2", slide)

    # Adds SummaryZoomFrame object
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    section3 = pres.sections.add_section("Section 3", slide)

    # Adds a section to the Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Removes section from the Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatting Summary Zoom Sections**

To create more complicated summary zoom section objects, you have to alter a simple frame's formatting. There are several formatting options you can apply to a summary zoom section object. 

You can control the formatting for a summary zoom section object in a summary zoom frame this way:

1.	Create an instance of the [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
2.	Create new slides with identification background and new sections for created slides.
3.	Add a summary zoom frame to the first slide.
4.	Get a summary zoom section object for the first object from the `SummaryZoomSectionCollection`.
5.	Create a `PPImage` object by adding an image to the images collection associated with the  [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) object that will be used to fill the frame.
6.	Set a custom image for the created section zoom frame object.
7.	Set the *return to the original slide from the linked section* ability. 
8.	Change the line format for the second zoom frame object.
9.	Change the transition duration.
10.	Write the modified presentation as a PPTX file.

This python code shows you how to change the formatting for a summary zoom section object:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    pres.sections.add_section("Section 1", slide)

    #Adds a new slide to the presentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Adds a new section to the presentation
    pres.sections.add_section("Section 2", slide)

    # Adds a SummaryZoomFrame object
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Gets the first SummaryZoomSection object
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatting for SummaryZoomSection object
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Saves the presentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. The [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) or [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) has a `return_to_parent` behavior that, when enabled, sends viewers back to the originating slide after they visit the target content.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Zoom supports setting a `transition_duration` so you can control how long the jump animation takes.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.
