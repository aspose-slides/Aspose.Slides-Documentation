---
title: Slide Section
type: docs
weight: 90
url: /net/slide-section/
---

## **Add or Remove Section in Slide**
Aspose.Slides for .NET now allows developers to add a section or remove the section where a group of slides can be added or removed. Developers can also add a section on any desired location in the presentation. The code snippet below demonstrates how to use this feature.

```c#
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

