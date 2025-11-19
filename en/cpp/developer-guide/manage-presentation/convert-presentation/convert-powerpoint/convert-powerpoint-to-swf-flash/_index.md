---
title: Convert PowerPoint Presentations to SWF Flash in C++
linktitle: PowerPoint to SWF
type: docs
weight: 80
url: /cpp/convert-powerpoint-to-swf-flash/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to SWF
- presentation to SWF
- slide to SWF
- PPT to SWF
- PPTX to SWF
- PowerPoint to Flash
- presentation to Flash
- slide to Flash
- PPT to Flash
- PPTX to Flash
- save PPT as SWF
- save PPTX as SWF
- export PPT to SWF
- export PPTX to SWF
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Convert PowerPoint (PPT/PPTX) to SWF Flash in C++ with Aspose.Slides. Step‑by‑step code samples, fast quality output, no PowerPoint automation."
---

The [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) class and [INotesCommentsLayoutingOptions ](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

``` cpp
// The path to the documents directory.
    System::String dataDir = GetDataPath();

    // Instantiate a Presentation object that represents a presentation file
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Saving presentation and notes pages
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```
