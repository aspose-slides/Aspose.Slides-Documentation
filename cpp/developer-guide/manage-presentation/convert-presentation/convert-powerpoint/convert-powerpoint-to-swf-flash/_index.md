---
title: Convert PowerPoint to SWF Flash
type: docs
weight: 80
url: /cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Convert PowerPoint PPT, PPTX to SWF Flash format with Aspose.Slides API."
---

The [Save](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) method exposed by [Presentation](https://apireference.aspose.com/slides/cpp/class/aspose.slides.presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) class and [INotesCommentsLayoutingOptions ](https://apireference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

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
