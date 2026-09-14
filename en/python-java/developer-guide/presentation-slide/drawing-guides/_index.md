---
title: Manage Drawing Guides in Presentations in Python
linktitle: Drawing Guides
type: docs
weight: 85
url: /python-java/drawing-guides/
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
description: "Add, access, and clear horizontal and vertical drawing guides in PowerPoint presentations using Aspose.Slides for Python via Java."
---

## **Overview**

Drawing guides are adjustable horizontal and vertical lines that help users align shapes consistently while editing a presentation in PowerPoint. They are especially useful when an application generates a presentation that will later be refined manually: the application can save the same alignment aids that authors should follow when adding or moving content.

Drawing guides are editing aids, not slide content. They do not appear in a slide show or rendered output. Aspose.Slides for Python via Java exposes them through the [DrawingGuidesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/) class. A guide is represented by [DrawingGuide](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguide/) and has an orientation, a position, and a color.

The position is measured in points from the top-left corner of the relevant slide or master. A vertical guide uses a horizontal coordinate, typically between zero and the slide width. A horizontal guide uses a vertical coordinate, typically between zero and the slide height.

## **Add Guides to the Slide View**

Use [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) to manage guides displayed while editing normal slides. Call [DrawingGuidesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/#add) with an [Orientation](https://reference.aspose.com/slides/python-java/aspose.slides/orientation/) value and a position in points.

The following example adds one vertical guide to the right of the slide center and one horizontal guide below it:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access Drawing Guides**

The [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/#getCount) and [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/#get_Item) methods provide access to existing guides. The [DrawingGuide.getOrientation](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguide/#getPosition), and [DrawingGuide.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguide/#getColor) methods return values that can also be changed through the corresponding setter methods.

The following example reads the slide-view guides from the presentation created above:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Add Guides to Master and Layout Slides**

A slide master and each of its layout slides can have their own drawing-guide collections. Use [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getDrawingGuides) for a master slide and [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getDrawingGuides) for a layout slide.

The following example adds a vertical guide to the first master slide and a horizontal guide to the first layout slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Add Guides to Notes and Handout Masters**

Notes masters and handout masters also support drawing guides. Use [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/python-java/aspose.slides/masternotesslide/#getDrawingGuides) and [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) to access their collections. If a presentation does not contain one of these masters, `MasterNotesSlideManager.setDefaultMasterNotesSlide` or `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` creates the default master and returns it.

The following example adds a horizontal guide to a notes master and a vertical guide to a handout master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Clear Drawing Guides**

Call [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/#clear) to remove every guide from a particular collection. Clearing one collection does not affect guides stored in another scope.

The following example clears the slide-view guides and all guides on slide masters, layout slides, the notes master, and the handout master without creating missing masters:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Do drawing guides appear in a slide show or exported images?**

No. Drawing guides are alignment aids for editing and are not rendered as presentation content.

**Can a drawing guide be added directly to an individual normal slide?**

Normal-slide editing guides are stored in the presentation's slide-view properties. Separate guide collections are available for slide masters, layout slides, notes masters, and handout masters.

**Which units are used for guide positions?**

Positions are specified in points, where 72 points equal one inch. Vertical positions are measured from the left edge, and horizontal positions are measured from the top edge.

**Does clearing drawing guides remove shapes or change slide content?**

No. The [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/drawingguidescollection/#clear) method removes only the guides in the selected collection. Shapes and other slide content remain unchanged.
