---
title: Slide Section
type: docs
weight: 90
url: /net/slide-section/
---

With Aspose.Slides for .NET, you can organize a PowerPoint Presentation into sections. You get to create sections that contain specific slides. 

You may want to create sections and use them to organize or divide slides from a presentation into logical parts in these situations:

- When you are working on a large presentation with other people or a team—and you and need to assign certain slides to a colleague or some team members. 
- When you are dealing with a presentation that contains many slides—and you are struggling to manage or edit its content all at once.

Ideally, you should create a section that houses similar slides—the slides have something in common or they can exist in a group based on a rule—and give the section a name that describes the slides inside it. 

## Creating Sections in Presentations

To add sections, Aspose.Slides for .NET provides the AddSection method that allows you to specify the name of the section you intend to create and the slide from which the section starts. 

This sample code shows you to create a section in a presentation in C#:

```c#
Provide a better code if possible--and delete this text

// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Slides_Presentations_CRUD();

Presentation pres = new Presentation(path+"Presentation1.pptx");
ISection section = pres.Sections[2];
pres.Sections.ReorderSectionWithSlides(section, 0);
pres.Sections.RemoveSectionWithSlides(pres.Sections[0]);
pres.Sections.AppendEmptySection("Last empty section");
pres.Sections.AddSection("First empty", pres.Slides[0]);
pres.Sections[0].Name = "New section name";
pres.Save(path+"resultsection1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);

```

## Changing the Names of Sections

After you create a section in a PowerPoint presentation, you may decide to change its name. 

This sample code shows you how to change the name of a section in a presentation in C# using Aspose.Slides:

```c#
using (Presentation pres = new Presentation("pres.pptx"))

{

   ISection section = pres.Sections[0];

   section.Name = "My section";

}
```

