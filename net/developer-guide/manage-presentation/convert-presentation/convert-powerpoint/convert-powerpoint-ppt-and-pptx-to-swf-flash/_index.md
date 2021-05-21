---
title: Convert PowerPoint PPT and PPTX to SWF Flash
type: docs
weight: 80
url: /net/convert-powerpoint-ppt-and-pptx-to-swf-flash/
keywords: "PPT, PPTX to SWF"
description: "Convert PowerPoint PPT, PPTX to SWF Flash format with Aspose.Slides API."
---

The [Save](https://apireference.aspose.com/net/slides/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://apireference.aspose.com/net/slides/aspose.slides.export/swfoptions) class and [INotesCommentsLayoutingOptions ](https://apireference.aspose.com/net/slides/aspose.slides.export/inotescommentslayoutingoptions)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

```c#
// The path to the documents directory.
string dataDir = RunExamples.GetDataDir_Conversion();

// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation(dataDir + "HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Saving presentation and notes pages
    presentation.Save(dataDir + "SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save(dataDir + "SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


