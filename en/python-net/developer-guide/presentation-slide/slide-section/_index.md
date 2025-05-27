---
title: Manage Slide Sections in Presentations with Python
titlelink: Slide Section
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

With Aspose.Slides for Python via .NET, you can organize a PowerPoint Presentation into sections. You get to create sections that contain specific slides. 

You may want to create sections and use them to organize or divide slides in a presentation into logical parts in these situations:

- When you are working on a large presentation with other people or a team—and you need to assign certain slides to a colleague or some team members. 
- When you are dealing with a presentation that contains many slides—and you are struggling to manage or edit its contents at once.

Ideally, you should create a section that houses similar slides—the slides have something in common or they can exist in a group based on a rule—and give the section a name that describes the slides inside it. 

## Creating Sections in Presentations

To add a section that will house slides in a presentation, Aspose.Slides for Python via .NET provides the AddSection method that allows you to specify the name of the section you intend to create and the slide from which the section starts. 

This sample code shows you to create a section in a presentation in Python:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    defaultSlide = pres.slides[0]
    newSlide1 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide2 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide3 = pres.slides.add_empty_slide(pres.layout_slides[0])
    newSlide4 = pres.slides.add_empty_slide(pres.layout_slides[0])

    section1 = pres.sections.add_section("Section 1", newSlide1)
    # section1 will be ended at newSlide2 and after it section2 will start 
    section2 = pres.sections.add_section("Section 2", newSlide3) 
      
    
    pres.save("pres-sections.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.reorder_section_with_slides(section2, 0)
    pres.save("pres-sections-moved.pptx", slides.export.SaveFormat.PPTX)
    
    pres.sections.remove_section_with_slides(section2)
    
    pres.sections.append_empty_section("Last empty section")
    
    pres.save("pres-section-with-empty.pptx",slides.export.SaveFormat.PPTX)
```

## Changing the Names of Sections

After you create a section in a PowerPoint presentation, you may decide to change its name. 

This sample code shows you how to change the name of a section in a presentation in Python using Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("pres-sections.pptx") as pres:
   section = pres.sections[0]
   section.name = "My section"
```

