---
title: PowerPoint in SWF Flash umwandeln
type: docs
weight: 80
url: /de/net/convert-powerpoint-to-swf-flash/
keywords: "PowerPoint umwandeln, Präsentation, PowerPoint in SWF, SWF Flash PPT in SWF, PPTX in SWF, C#, Csharp, .NET"
description: "PowerPoint-Präsentation in SWF Flash in C# oder .NET umwandeln"
---

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode, die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF-Dokument umzuwandeln. Sie können auch Kommentare im generierten SWF mithilfe der [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) Klasse und der [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) Schnittstelle einfügen. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe der von der SWFOptions-Klasse bereitgestellten Optionen in ein SWF-Dokument umwandelt.

```c#
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Speichern der Präsentation und der Notizenseiten
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```