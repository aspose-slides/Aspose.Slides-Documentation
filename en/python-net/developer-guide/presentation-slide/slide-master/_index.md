---
title: Manage Presentation Slide Masters in Python
linktitle: Slide Master
type: docs
weight: 80
url: /python-net/slide-master/
keywords:
- slide master
- master slide
- PPT master slide
- multiple master slides
- compare master slides
- background
- placeholder
- clone master slide
- copy master slide
- duplicate master slide
- unused master slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage slide masters in Aspose.Slides for Python via .NET: access, edit, clone, compare, and remove master slides in PowerPoint and OpenDocument presentations."
---

## **Overview**

A **slide master** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for Python via .NET supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **Slide master** - defines the shared design and theme.
1. **Layout slide** - defines a specific arrangement of placeholders and layout-level formatting.
1. **Normal slide** - contains the actual presentation content and uses one layout slide.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) class. All master slides in a presentation are available through the `Presentation.masters` collection.

{{% alert color="info" title="Inheritance" %}}

When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [Apply or Change Slide Layouts](/slides/python-net/slide-layout/).

{{% /alert %}}

## **Access Slide Masters**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides, use the `masters` collection to access master slides:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

You can also get the master slide used by a normal slide through its layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **What a Slide Master Contains**

A master slide is a slide-like object. It inherits common slide behavior from the [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) class, so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) API page.

Commonly used master slide members include:

| Member | Purpose |
| --- | --- |
| `background` | Sets the master-level slide background. |
| `shapes` | Stores shapes placed on the master, such as logos, picture frames, and shared text. |
| `layout_slides` | Stores the layout slides that belong to the master. |
| `theme_manager` | Provides access to the master theme APIs. |
| `header_footer_manager` | Controls headers, footers, dates, and slide numbers for the master and its child layouts. |
| `get_depending_slides` | Returns normal slides that depend on the master through their layouts. |

## **Add an Image to a Slide Master**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

For more information about picture frames, see [Picture Frame](/slides/python-net/picture-frame/).

## **Control the Visibility of Master Graphics**

Use [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/show_master_shapes/) to hide inherited master graphics, such as logos or decorative shapes, without deleting them from the master. Set [Slide.show_master_shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/show_master_shapes/) to `False` on the slide that should omit those graphics and keep it `True` on slides that should display them.

The following self-contained example creates a blue decorative band on a master and two slides that use the same blank layout. The band is visible on the first slide and hidden on the second. No input presentation or image is required.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

The example uses the **Blank** layout supplied with a new presentation and removes the initial slide's own placeholders.

### **Choose the Scope of the Setting**

A normal slide uses its master through [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) and [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Setting the property on an individual slide affects only that slide. Setting [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/show_master_shapes/) to `False` hides master graphics for slides that use that shared layout, even if their own setting is `True`. To hide graphics on just one slide, change the slide property and leave the shared layout unchanged.

The setting is not supported as a visibility control on the master slide itself. On a master it always returns `False`, and assigning `True` raises an exception. Apply it to a normal slide or a layout instead.

### **Distinguish Graphics from the Background**

| Operation | Effect |
| --- | --- |
| Hide master graphics | Controls the visibility of inherited master shapes without deleting them or changing the slide's own shapes. |
| Change the slide background fill | Changes the background color, gradient, or image. Master graphics are separate shapes and can remain visible over that background. See [Presentation Background](/slides/python-net/presentation-background/). |
| Delete a shape from the master | Removes the shared source shape, so it is no longer available to any slide using that master. |

## **Work with Placeholders**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

For more placeholder and text formatting options, see [Set Prompt Text in Placeholder](/slides/python-net/manage-placeholder/) and [Text Formatting](/slides/python-net/text-formatting/).

## **Change a Slide Master Background**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

For related topics, see [Presentation Background](/slides/python-net/presentation-background/) and [Presentation Theme](/slides/python-net/presentation-theme/).

## **Clone a Slide Master to Another Presentation**

Use the `add_clone` method on the [MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) class to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

If you need to clone normal slides together with their master, see [Clone Slides](/slides/python-net/clone-slides/).

## **Add Multiple Slide Masters**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, gets a blank layout under that cloned master, and adds a new slide based on that layout:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Compare Slide Masters**

Master slides can be compared with the `equals` method inherited from the [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) class. The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

For more information, see [Compare Presentation Slides](/slides/python-net/compare-slides/).

## **Set Slide Master View as the Default View**

Use the `last_view` property on the presentation [ViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

For more view settings, see [Save Presentation](/slides/python-net/save-presentation/).

## **Remove Unused Master Slides**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use `remove_unused` to remove unused masters from the `masters` collection:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

You can also use the low-code `remove_unused_master_slides` method from the [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) class:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**What is the difference between a slide master and a layout slide?**

A slide master defines shared design settings such as theme, background, common shapes, and text styles. A layout slide belongs to a master slide and defines a specific arrangement of placeholders. A normal slide uses a layout slide, so it inherits from both the layout and the master.

**Can one presentation contain several slide masters?**

Yes. A presentation can contain several slide masters. Use multiple masters when different sections need different visual systems or branding.

**Should I add placeholders to a master slide or a layout slide?**

In most cases, add placeholders to layout slides. Put shared visual elements and shared formatting on the master slide, then put content placeholders on the layouts that normal slides will use.

**Can I delete a master slide that is still used?**

No. A master slide that has dependent slides cannot be safely removed directly. First move those slides to layouts under another master, or use an unused-master cleanup method that removes only masters that are not in use.
