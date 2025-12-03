---
title: Manage Slide Sections in Presentations in .NET
linktitle: Slide Section
type: docs
weight: 100
url: /net/slide-section/
keywords:
- create section
- add section
- edit section
- change section
- section name
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Streamline slide sections in PowerPoint and OpenDocument with Aspose.Slides for .NET — split, rename, and reorder to optimize PPTX and ODP workflows."
---

With Aspose.Slides for .NET, you can organize a PowerPoint Presentation into sections. You get to create sections that contain specific slides. 

You may want to create sections and use them to organize or divide slides in a presentation into logical parts in these situations:

- When you are working on a large presentation with other people or a team—and you need to assign certain slides to a colleague or some team members. 
- When you are dealing with a presentation that contains many slides—and you are struggling to manage or edit its contents at once.

Ideally, you should create a section that houses similar slides—the slides have something in common or they can exist in a group based on a rule—and give the section a name that describes the slides inside it. 

## **Create Sections in Presentations**

To add a section that will house slides in a presentation, Aspose.Slides for .NET provides the AddSection method that allows you to specify the name of the section you intend to create and the slide from which the section starts. 

This sample code shows you to create a section in a presentation in C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide defaultSlide = pres.Slides[0];
    ISlide newSlide1 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide2 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide3 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
    ISlide newSlide4 = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

    ISection section1 = pres.Sections.AddSection("Section 1", newSlide1);
    ISection section2 = pres.Sections.AddSection("Section 2", newSlide3); // section1 will be ended at newSlide2 and after it section2 will start   
    
    pres.Save("pres-sections.pptx", SaveFormat.Pptx);
    
    pres.Sections.ReorderSectionWithSlides(section2, 0);
    pres.Save("pres-sections-moved.pptx", SaveFormat.Pptx);
    
    pres.Sections.RemoveSectionWithSlides(section2);
    
    pres.Sections.AppendEmptySection("Last empty section");
    
    pres.Save("pres-section-with-empty.pptx",SaveFormat.Pptx);
}
```

## **Change the Names of Sections**

After you create a section in a PowerPoint presentation, you may decide to change its name. 

This sample code shows you how to change the name of a section in a presentation in C# using Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ISection section = pres.Sections[0];
   section.Name = "My section";
}
```

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. Only individual slides can be hidden. A section as an entity has no "hidden" state.

**Can I quickly find a section by a slide and, conversely, the first slide of a section?**

Yes. A section is uniquely defined by its starting slide; given a slide you can determine which section it belongs to, and for a section you can access its first slide.
