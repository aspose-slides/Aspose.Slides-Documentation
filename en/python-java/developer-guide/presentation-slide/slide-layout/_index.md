---
title: Apply or Change Slide Layouts in Python via Java
linktitle: Slide Layout
type: docs
weight: 60
url: /python-java/slide-layout/
keywords:
- slide layout
- content layout
- placeholder
- presentation design
- slide design
- unused layout
- footer visibility
- title slide
- title and content
- section header
- two content
- comparison
- title only
- blank layout
- content with caption
- picture with caption
- title and vertical text
- vertical title and text
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Apply, create, and modify slide layouts in Aspose.Slides for Python via Java, add placeholders, remove unused layouts, and control footer visibility."
---

## **Overview**

A slide layout defines the positions and formatting of placeholders such as titles, text, pictures, charts, and tables. Applying a layout gives slides a consistent structure while allowing each slide to contain its own content.

The most common layouts include:

- **Title Slide**: Contains title and subtitle placeholders.
- **Title and Content**: Contains a title placeholder and a general-purpose content placeholder.
- **Blank**: Contains no content placeholders and is useful when every shape will be positioned manually.

## **Understand Layout Inheritance**

A presentation has three related levels:

1. A [master slide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
1. A [layout slide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
1. A [normal slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [Slide Master](/slides/python-java/slide-master/).

## **Select and Apply a Slide Layout**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second check for `None` is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [Slide.setLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#setLayoutSlide) method.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **Add a Layout Slide**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/masterlayoutslidecollection/#add) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **Add Placeholders to a Layout Slide**

The [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getPlaceholderManager) method provides a [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint Placeholder              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/) Method |
| ----------------------------------- | ---------------------------------- |
| ![Content](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [addTextPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [addPicturePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [addChartPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [addTablePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.

{{% /alert %}}

## **Remove Unused Layout Slides**

Use the [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

To remove one specific layout, first use its [hasDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#hasDependingSlides) or [getDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getDependingSlides) method. Reassign any dependent slides before calling [LayoutSlide.remove](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#remove). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/).

## **Control Footer Visibility on a Layout Slide**

A layout has its own footer, slide-number, and date-time placeholders. Use the [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) method to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Control Footer Visibility on a Master and Its Child Layouts**

To apply consistent footer settings across a master hierarchy, use the [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#getHeaderFooterManager) method. The propagation methods of [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/python-java/aspose.slides/masterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**What Is the Difference Between a Master Slide and a Layout Slide?**

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**Can I Copy a Layout Slide from One Presentation to Another?**

Yes. Add a copy to the destination collection with the [addClone](https://reference.aspose.com/slides/python-java/aspose.slides/globallayoutslidecollection/#addClone) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**What Happens When I Modify a Layout That Is Already in Use?**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [getDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getDependingSlides) to identify the affected slides before editing the layout.

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides throws a [PptxEditException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [removeUnusedLayoutSlides](https://reference.aspose.com/slides/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) to remove only unreferenced layouts.
