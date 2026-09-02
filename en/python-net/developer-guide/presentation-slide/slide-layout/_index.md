---
title: Apply or Change Slide Layouts in Python
linktitle: Slide Layout
type: docs
weight: 60
url: /python-net/slide-layout/
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
- Aspose.Slides
description: "Apply, create, and modify slide layouts in Aspose.Slides for Python via .NET, add placeholders, remove unused layouts, and control footer visibility."
---

## **Overview**

A slide layout defines the positions and formatting of placeholders such as titles, text, pictures, charts, and tables. Applying a layout gives slides a consistent structure while allowing each slide to contain its own content.

The most common layouts include:

- **Title Slide**: Contains title and subtitle placeholders.
- **Title and Content**: Contains a title placeholder and a general-purpose content placeholder.
- **Blank**: Contains no content placeholders and is useful when every shape will be positioned manually.

## **Understand Layout Inheritance**

A presentation has three related levels:

1. A [master slide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
1. A [layout slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
1. A [normal slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [Slide Master](/slides/python-net/slide-master/).

## **Select and Apply a Slide Layout**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) property.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **Add a Layout Slide**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/add/) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **Add Placeholders to a Layout Slide**

The [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/) property provides a [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint Placeholder              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

The result:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.

{{% /alert %}}

## **Remove Unused Layout Slides**

Use the [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

To remove one specific layout, first use its [has_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/has_depending_slides/) property or [get_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/get_depending_slides/) method. Reassign any dependent slides before calling [LayoutSlide.remove](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/remove/). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/).

## **Control Footer Visibility on a Layout Slide**

A layout has its own footer, slide-number, and date-time placeholders. Use the [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/header_footer_manager/) property to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Control Footer Visibility on a Master and Its Child Layouts**

To apply consistent footer settings across a master hierarchy, use the [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/header_footer_manager/) property. The propagation methods of [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/masterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What Is the Difference Between a Master Slide and a Layout Slide?**

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**Can I Copy a Layout Slide from One Presentation to Another?**

Yes. Add a copy to the destination collection with the [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/globallayoutslidecollection/add_clone/) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**What Happens When I Modify a Layout That Is Already in Use?**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [get_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/get_depending_slides/) to identify the affected slides before editing the layout.

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides raises a [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) to remove only unreferenced layouts.
