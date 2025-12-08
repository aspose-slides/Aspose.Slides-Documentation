---
title: PowerPoint in SWF Flash konvertieren
type: docs
weight: 80
url: /de/net/convert-powerpoint-to-swf-flash/
keywords: "PowerPoint konvertieren, Präsentation, PowerPoint zu SWF, SWF Flash PPT zu SWF, PPTX zu SWF, C#, Csharp, .NET"
description: "PowerPoint-Präsentation in SWF Flash mit C# oder .NET konvertieren"
---

## **Präsentationen in Flash konvertieren**

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode, die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können außerdem Kommentare im erzeugten SWF einbinden, indem Sie die [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) Klasse und das [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) Interface verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe der von der SWFOptions‑Klasse bereitgestellten Optionen in ein SWF‑Dokument konvertiert.
```c#
// Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Speichern der Präsentation und der Notizseiten
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **FAQ**

**Kann ich ausgeblendete Folien in das SWF einbinden?**

Ja. Aktivieren Sie die Option [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/) in [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Standardmäßig werden ausgeblendete Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie das Flag [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/) (standardmäßig aktiviert) und passen Sie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) an, um Dateigröße und Bildtreue zu balancieren.

**Wofür dient 'ViewerIncluded' und wann sollte ich es deaktivieren?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) fügt eine integrierte Player‑UI (Navigations‑Steuerelemente, Panels, Suche) hinzu. Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden möchten oder ein reines SWF‑Gerüst ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Computer fehlt?**

Aspose.Slides ersetzt die Schriftart durch die über [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) angegebene Schriftart, um ein unbeabsichtigtes Zurückfallen zu vermeiden.