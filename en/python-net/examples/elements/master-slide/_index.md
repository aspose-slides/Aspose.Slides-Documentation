---
title: Master Slide
type: docs
weight: 30
url: /python-net/examples/elements/master-slide/
keywords:
- master slide
- add master slide
- access master slide
- remove master slide
- unused master slide
- code examples
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Manage master slides in Python with Aspose.Slides: create, edit, clone, and format themes, backgrounds, placeholders to unify slides in PowerPoint and OpenDocument."
---

Master slides form the top level of the slide inheritance hierarchy in PowerPoint. A **master slide** defines common design elements such as backgrounds, logos, and text formatting. **Layout slides** inherit from master slides, and **normal slides** inherit from layout slides.

This article demonstrates how to create, modify, and manage master slides using Aspose.Slides for Python via .NET.

## **Add a Master Slide**

This example shows how to create a new master slide by cloning the default one.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Clone the default master slide.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Master slides provide a way to apply consistent branding or shared design elements across all slides. Any changes made to the master will automatically reflect on dependent layout and normal slides.

> 💡 **Tip 2:** Any shapes or formatting added to a master slide are inherited by layout slides and, in turn, all normal slides using those layouts.
> The image below illustrates how a text box added on a master slide is automatically rendered on the final slide.

![Master Inheritance Example](master-slide-banner.png)

## **Access a Master Slide**

You can access master slides using the `Presentation.masters` collection. Here’s how to retrieve and work with them:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Access the first master slide.
        first_master_slide = presentation.masters[0]
```

## **Remove a Master Slide**

Master slides can be removed either by index or by reference.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Remove by index.
        presentation.masters.remove_at(0)

        # Or remove by reference.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove Unused Master Slides**

Some presentations contain master slides that are not in use. Removing these slides can help reduce file size.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Remove all unused master slides (even those marked as Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Tip:** Use `remove_unused(True)` to clean up unused master slides and minimize the presentation size.
