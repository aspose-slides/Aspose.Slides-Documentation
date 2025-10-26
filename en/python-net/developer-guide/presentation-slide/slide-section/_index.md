---
title: Manage Slide Sections in Presentations with Python
linktitle: Slide Section
type: docs
weight: 100
url: /python-net/slide-section/
keywords:
- create section
- add section
- edit section
- change section
- section name
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Streamline slide sections in PowerPoint and OpenDocument with Aspose.Slides for Python — split, rename, and reorder to optimize PPTX and ODP workflows."
---

## **Overview**

With Aspose.Slides for Python, you can organize a PowerPoint presentation into sections that group specific slides.

You may want to create sections to organize or divide a presentation into logical parts in these situations:

- When you're working on a large presentation with a team and need to assign certain slides to specific colleagues.
- When you're dealing with a presentation that contains many slides and find it difficult to manage or edit everything at once.

Ideally, create sections that group related slides—those that share a theme, topic, or purpose—and give each section a name that clearly reflects its contents. 

## **Create Sections in Presentations**

To add a [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) that groups slides in a presentation, Aspose.Slides provides the [add_section](https://reference.aspose.com/slides/python-net/aspose.slides/sectioncollection/add_section/) method. It lets you specify the section name and the slide where the section begins.

The following Python example shows how to create a section in a presentation:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Section 1 ends at slide2; Section 2 starts at slide3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Change the Names of Sections**

After creating a [Section](https://reference.aspose.com/slides/python-net/aspose.slides/section/) in a PowerPoint presentation, you may decide to change its name.

The following Python example shows how to rename a section in a presentation:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. Only individual slides can be hidden. A section as an entity has no "hidden" state.

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**

Yes. A section is uniquely defined by its starting slide; given a slide you can determine which section it belongs to, and for a section you can access its first slide.
