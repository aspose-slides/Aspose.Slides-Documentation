---
title: PowerPoint-Präsentationen in SWF Flash in .NET konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/net/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu SWF
- Präsentation zu SWF
- Folie zu SWF
- PPT zu SWF
- PPTX zu SWF
- PowerPoint zu Flash
- Präsentation zu Flash
- Folie zu Flash
- PPT zu Flash
- PPTX zu Flash
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) in SWF Flash in .NET mit Aspose.Slides konvertieren. Schritt-für-Schritt C#-Codebeispiele, schnelle Qualitätsausgabe, keine PowerPoint-Automatisierung."
---

## **Präsentationen in Flash konvertieren**

Die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode, die von der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können auch Kommentare im erzeugten SWF einbinden, indem Sie die [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) Klasse und die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) Schnittstelle verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe der von der SWFOptions‑Klasse bereitgestellten Optionen in ein SWF‑Dokument konvertiert.
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


## **FAQ**

**Kann ich versteckte Folien in das SWF einbinden?**

Ja. Aktivieren Sie die [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/)‑Option in [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/). Standardmäßig werden versteckte Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie das [Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/)‑Flag (standardmäßig aktiviert) und passen Sie [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/) an, um Dateigröße und Bildqualität auszubalancieren.

**Wofür dient 'ViewerIncluded' und wann sollte ich es deaktivieren?**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/) fügt eine integrierte Player‑Benutzeroberfläche hinzu (Navigations‑Steuerelemente, Panels, Suche). Deaktivieren Sie es, wenn Sie einen eigenen Player verwenden wollen oder einen reinen SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn auf dem Export‑Computer eine Quellschriftart fehlt?**

Aspose.Slides ersetzt die Schriftart, die Sie über [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) angeben, um ein unbeabsichtigtes Fallback zu vermeiden.