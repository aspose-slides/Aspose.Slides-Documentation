---
title: Convert PowerPoint to SWF Flash
type: docs
weight: 80
url: /net/convert-powerpoint-to-swf-flash/
keywords: "Convert PowerPoint, Presentation, PowerPoint to SWF, SWF flash PPT to SWF, PPTX to SWF, C#, Csharp, .NET"
description: "Convert PowerPoint Presentation to SWF Flash in C# or .NET"
---

The [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) class and [INotesCommentsLayoutingOptions ](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Saving presentation and notes pages
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

