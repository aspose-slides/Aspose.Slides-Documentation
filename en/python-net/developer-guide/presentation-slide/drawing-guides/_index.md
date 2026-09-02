---
title: Manage Drawing Guides in Presentations in Python
linktitle: Drawing Guides
type: docs
weight: 85
url: /python-net/drawing-guides/
keywords:
- drawing guide
- horizontal guide
- vertical guide
- alignment guide
- slide view
- master slide
- layout slide
- notes master
- handout master
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for Python via .NET."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for Python via .NET exposes them through the [IDrawingGuidesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguidescollection/) interface. A guide is represented by [IDrawingGuide](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) to manage guides displayed while editing normal slides. Call [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguidescollection/add/) with an [Orientation](https://reference.aspose.com/slides/python-net/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Access Drawing Guides**

The [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguidescollection/count/) property and indexer provide access to existing guides. The [IDrawingGuide.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguide/position/), and [IDrawingGuide.color](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguide/color/) properties can be read or changed.

The following example reads the slide-view guides from the presentation created above:

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/drawing_guides/) for a master slide and [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/python-net/aspose.slides/ilayoutslide/drawing_guides/) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslide/drawing_guides/) and [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) to access their collections. If a presentation does not contain one of these masters, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) or [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Clear Drawing Guides**

Call [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/idrawingguidescollection/clear/) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The `clear` method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
