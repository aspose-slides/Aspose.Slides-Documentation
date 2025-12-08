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

## **Convert Presentations to Flash**

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

## **FAQ**

**Can I include hidden slides in the SWF?**

Yes. Use the [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) method in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). By default, hidden slides are not exported.

**How can I control compression and the final SWF size?**

Use the [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) method and adjust [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) to balance file size and image fidelity.

**What is 'set_ViewerIncluded' for, and when should I use it?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) adds an embedded player UI (navigation controls, panels, search). Disable it if you plan to use your own player or need a bare SWF frame without UI.

**What happens if a source font is missing on the export machine?**

Aspose.Slides will substitute the font you specify via [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) to avoid an unintended fallback.
