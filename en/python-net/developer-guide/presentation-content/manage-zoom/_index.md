---
title: Manage Presentation Zoom with Python
linktitle: Manage Zoom
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
description: "Create and customize Zoom with Aspose.Slides for Python via .NET — jump between sections, add thumbnails and transitions in PowerPoint presentations."
---

## **Introduction**

PowerPoint zooms let you navigate between specific slides and sections during a slide show. With Aspose.Slides for Python via .NET, you can create slide, section, and summary zooms and customize their previews, borders, and transitions.

![PowerPoint zoom overview](overview.png)

* To summarize an entire presentation on a single slide, use a [Summary Zoom](#summary-zoom).
* To show selected slides only, use a [Slide Zoom](#slide-zoom).
* To show a single section only, use a [Section Zoom](#section-zoom).

## **Slide Zoom**

A slide zoom can make your presentation more dynamic, allowing you to navigate freely between slides in any order you choose without interrupting the flow of your presentation. Slide zooms are great for short presentations without many sections, but you can still use them in different presentation scenarios.

Slide zooms let you explore related information from a single overview slide.

![Selecting slides for a slide zoom](slidezoomsel.png)

For slide zoom objects, Aspose.Slides provides the [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/) enumeration, the [ZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) class, and methods on the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Create Zoom Frames**

Use [ShapeCollection.add_zoom_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_zoom_frame/) to place links to individual slides on an overview slide. This example creates two target slides with distinct backgrounds and labels, then adds a preview of each to the first slide and saves the presentation as PPTX. Frame positions and dimensions are specified in points.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    second_slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    third_slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)

    second_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    second_slide.background.fill_format.fill_type = slides.FillType.SOLID
    second_slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    text_box = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    text_box.text_frame.text = "Second Slide"

    third_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    third_slide.background.fill_format.fill_type = slides.FillType.SOLID
    third_slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    text_box = third_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    text_box.text_frame.text = "Third Slide"

    overview_slide.shapes.add_zoom_frame(20, 20, 250, 200, second_slide)
    overview_slide.shapes.add_zoom_frame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Create Zoom Frames with Custom Images**

Pass a custom image to [ShapeCollection.add_zoom_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_zoom_frame/) to replace the target slide's default preview. This example requires a local image, loads it with [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/), and adds it to the presentation using [ImageCollection.add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). The resulting frame displays that image while still linking to the second slide.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    text_box.text_frame.text = "Second Slide"

    with slides.Images.from_file("image.png") as image:
        preview_image = presentation.images.add_image(image)

    overview_slide.shapes.add_zoom_frame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Format Zoom Frames**

This example customizes two slide zoom frames. It assigns a local image to the first frame through [ZoomObject.zoom_image](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/zoom_image/), and gives the second frame a five-point, dash-dot pink border through [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/). Setting [ZoomObject.show_background](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/show_background/) to `False` hides the second frame's background. A local image is required for the custom preview; both frames retain their slide targets in the saved PPTX.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    second_slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    third_slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)

    second_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    second_slide.background.fill_format.fill_type = slides.FillType.SOLID
    second_slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    text_box = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    text_box.text_frame.text = "Second Slide"

    third_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    third_slide.background.fill_format.fill_type = slides.FillType.SOLID
    third_slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    text_box = third_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    text_box.text_frame.text = "Third Slide"

    first_zoom_frame = overview_slide.shapes.add_zoom_frame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.shapes.add_zoom_frame(200, 250, 250, 200, third_slide)

    with slides.Images.from_file("image.png") as image:
        preview_image = presentation.images.add_image(image)

    first_zoom_frame.zoom_image = preview_image

    second_zoom_frame.line_format.width = 5
    second_zoom_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    second_zoom_frame.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    second_zoom_frame.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    second_zoom_frame.show_background = False

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Section Zoom**

A section zoom links to a section in your presentation. Use it to revisit a topic or show how different parts of the presentation connect.

![Selecting a section for a section zoom](seczoomsel.png)

For section zoom objects, Aspose.Slides provides the [SectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) class and methods on the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Create Section Zoom Frames**

Create a section with [SectionCollection.add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/), then pass the returned section to [ShapeCollection.add_section_zoom_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_section_zoom_frame/). This example places a section zoom on the first slide and links it to a section beginning with a colored slide. The frame's position and dimensions are specified in points, and the presentation is saved as PPTX.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    section = presentation.sections.add_section("Section 1", slide)
    section_zoom_frame = overview_slide.shapes.add_section_zoom_frame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Create Section Zoom Frames with Custom Images**

The image overload of [ShapeCollection.add_section_zoom_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_section_zoom_frame/) lets you display a custom preview without changing the destination section. This example requires a local image, which is loaded with [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) and added through [ImageCollection.add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/). The saved presentation contains a section zoom on the first slide linked to the newly created section.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    with slides.Images.from_file("image.png") as image:
        preview_image = presentation.images.add_image(image)

    section = presentation.sections.add_section("Section 1", slide)
    section_zoom_frame = overview_slide.shapes.add_section_zoom_frame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Change a Section Zoom's Target Section**

Use [SectionZoomFrame.target_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/target_section/) to redirect an existing section zoom without recreating it. Choose a populated section from the same presentation's [sections](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/sections/) collection. Assigning an empty section leaves the current target unchanged, so check [Section.get_slides_list_of_section](https://reference.aspose.com/slides/python-net/aspose.slides/section/get_slides_list_of_section/) before assigning it. See [Manage Slide Sections](/slides/python-net/slide-section/) for more about sections.

The following example loads a presentation file, which must contain multiple populated sections, an existing section zoom named `Section navigation`, and a section with the unique name `Results`. It searches all slides for the zoom and finds the destination by name rather than by a collection index that can change when sections are reordered. If names are not unique, use [Section.section_id](https://reference.aspose.com/slides/python-net/aspose.slides/section/section_id/) to identify the destination instead.

```python
import aspose.slides as slides

with slides.Presentation("section-zoom.pptx") as presentation:
    zoom = None
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.SectionZoomFrame) and shape.name == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = next((section for section in presentation.sections if section.name == "Results"), None)

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif len(target_section.get_slides_list_of_section()) == 0:
        print("The destination section is empty.")
    else:
        if zoom.target_section is not None:
            print(f"Current section: {zoom.target_section.name}")
        zoom.target_section = target_section
        presentation.save("section-zoom-updated.pptx", slides.export.SaveFormat.PPTX)
```

### **Format Section Zoom Frames**

This example moves and resizes a section zoom to 100 by 75 points, assigns a local image through [ZoomObject.zoom_image](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/zoom_image/), and applies a 2.5-point, dash-dot brown border. It enables [ZoomObject.return_to_parent](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/return_to_parent/) to return to the originating slide after the section, disables [ZoomObject.show_background](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/show_background/), and sets [ZoomObject.transition_duration](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/transition_duration/) to 1.5 seconds. A local image is required for the custom preview.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    section = presentation.sections.add_section("Section 1", slide)

    section_zoom_frame = overview_slide.shapes.add_section_zoom_frame(20, 20, 300, 200, section)
    section_zoom_frame.x = 100
    section_zoom_frame.y = 300
    section_zoom_frame.width = 100
    section_zoom_frame.height = 75

    with slides.Images.from_file("image.png") as image:
        preview_image = presentation.images.add_image(image)

    section_zoom_frame.zoom_image = preview_image

    section_zoom_frame.return_to_parent = True
    section_zoom_frame.show_background = False

    section_zoom_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    section_zoom_frame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    section_zoom_frame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    section_zoom_frame.line_format.width = 2.5

    section_zoom_frame.transition_duration = 1.5

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Summary Zoom**

A summary zoom provides an overview of presentation sections. During a slide show, you can use it to jump to a section, skip ahead, or revisit a topic without following the slide order.

![Selecting sections for a summary zoom](sumzoomsel.png)

For summary zoom objects, Aspose.Slides provides the [SummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/), and [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/) classes and methods on the [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) class.

### **Create a Summary Zoom**

Use [ShapeCollection.add_summary_zoom_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_summary_zoom_frame/) to create an overview of the presentation's sections. This example creates four sections with distinct slide backgrounds and adds a summary zoom to the first slide. The frame's position and dimensions are specified in points, and the resulting overview is saved in a PPTX presentation.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 1", slide)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 2", slide)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 3", slide)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.dark_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 4", slide)

    summary_zoom_frame = overview_slide.shapes.add_summary_zoom_frame(150, 50, 300, 200)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Add and Remove a Summary Zoom Section**

A summary zoom stores its [SummaryZoomSection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsection/) objects in [SummaryZoomFrame.summary_zoom_collection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/summary_zoom_collection/). This example creates an overview of two sections, adds a third section using [SummaryZoomSectionCollection.add_summary_zoom_section](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/add_summary_zoom_section/), and removes the first section's entry using [SummaryZoomSectionCollection.remove_summary_zoom_section](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomsectioncollection/remove_summary_zoom_section/). Removing the entry leaves the presentation section and its slides intact.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    first_section = presentation.sections.add_section("Section 1", slide)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 2", slide)

    summary_zoom_frame = overview_slide.shapes.add_summary_zoom_frame(150, 50, 300, 200)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    third_section = presentation.sections.add_section("Section 3", slide)

    summary_zoom_frame.summary_zoom_collection.add_summary_zoom_section(third_section)

    summary_zoom_frame.summary_zoom_collection.remove_summary_zoom_section(first_section)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Format Summary Zoom Sections**

This example formats the first entry in [SummaryZoomFrame.summary_zoom_collection](https://reference.aspose.com/slides/python-net/aspose.slides/summaryzoomframe/summary_zoom_collection/), using the zero-based index `0`. It requires a local image for [ZoomObject.zoom_image](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/zoom_image/), applies a 1.5-point, dash-dot black border, and sets [ZoomObject.transition_duration](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/transition_duration/) to 1.5 seconds. Setting [ZoomObject.return_to_parent](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/return_to_parent/) to `False` disables the automatic return to the summary slide for this entry.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    overview_slide = presentation.slides[0]

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 1", slide)

    slide = presentation.slides.add_empty_slide(overview_slide.layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    presentation.sections.add_section("Section 2", slide)

    summary_zoom_frame = overview_slide.shapes.add_summary_zoom_frame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.summary_zoom_collection[0]

    with slides.Images.from_file("image.png") as image:
        preview_image = presentation.images.add_image(image)

    summary_section.zoom_image = preview_image
    summary_section.return_to_parent = False

    summary_section.line_format.fill_format.fill_type = slides.FillType.SOLID
    summary_section.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summary_section.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summary_section.line_format.width = 1.5

    summary_section.transition_duration = 1.5

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Can I control returning to the 'parent' slide after showing the target?**

Yes. Set [ZoomObject.return_to_parent](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/return_to_parent/) to `True` to return to the originating slide after the target content is shown.

**Can I adjust the 'speed' or duration of the Zoom transition?**

Yes. Set [ZoomObject.transition_duration](https://reference.aspose.com/slides/python-net/aspose.slides/zoomobject/transition_duration/) to control the transition duration in seconds.

**Are there limits on how many Zoom objects a presentation can contain?**

There is no hard API limit documented. Practical limits depend on overall presentation complexity and the viewer's performance. You can add many Zoom frames, but consider file size and rendering time.
