---
title: Layout Slide
type: docs
weight: 20
url: /python-java/examples/elements/layout-slide/
keywords:
- code example
- layout slide
- add layout slide
- access layout slide
- remove layout slide
- unused layout slide
- clone layout slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Manage layout slides with Aspose.Slides for Python via Java: add, access, remove, clean up, and clone layouts in PowerPoint and OpenDocument presentations."
---

This article demonstrates how to work with **layout slides** using Aspose.Slides for Python via Java. A layout slide defines the design and formatting inherited by normal slides. You can add, access, clone, and remove layout slides, as well as clean up unused ones to reduce presentation size.

Install the package as described in [Installation](/slides/python-java/installation/). Each example imports `asposeslides` before starting the JVM, then imports the API after the JVM is running.

## **Add a Layout Slide**

Create a custom layout slide to define reusable formatting. The following example adds a text box to a new layout and then creates two slides that use it.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Create a layout slide with a blank layout type and a custom name.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Add a text box to the layout slide.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Add two slides that inherit the text from the layout.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Note 1:** Layout slides act as templates for individual slides. You can define common elements once and reuse them across many slides.

> 💡 **Note 2:** When you add shapes or text to a layout slide, all slides based on that layout display the shared content automatically.
> The screenshot below shows two slides that inherit a text box from the same layout slide.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Access a Layout Slide**

Access layout slides by index or by layout type, such as blank, title, or section header.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Access a layout slide by index.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Access a layout slide by type.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Remove a Layout Slide**

Remove a specific layout slide when it is no longer needed.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Remove Unused Layout Slides**

Remove layout slides that are not used by any normal slide to reduce the presentation size.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Clone a Layout Slide**

Duplicate a layout slide and add the copy to the end of the layout slide collection.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Summary:** Layout slides help maintain consistent formatting across a presentation. Aspose.Slides lets you create, manage, reuse, and clean up layouts as needed.
