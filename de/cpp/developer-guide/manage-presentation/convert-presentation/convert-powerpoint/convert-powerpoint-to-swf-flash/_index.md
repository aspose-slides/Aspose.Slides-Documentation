---
title: PowerPoint-Präsentationen in SWF-Flash mit C++ konvertieren
linktitle: PowerPoint zu SWF
type: docs
weight: 80
url: /de/cpp/convert-powerpoint-to-swf-flash/
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
- PPT als SWF speichern
- PPTX als SWF speichern
- PPT nach SWF exportieren
- PPTX nach SWF exportieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) mit Aspose.Slides in SWF-Flash mit C++ konvertieren. Schritt-für-Schritt-Code-Beispiele, schnelle qualitativ hochwertige Ausgabe, keine PowerPoint-Automatisierung."
---

## **Präsentationen in Flash konvertieren**

Die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑Methode, die von der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können zudem Kommentare im erzeugten SWF einbinden, indem Sie die Klassen [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) und [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) verwenden. Das folgende Beispiel zeigt, wie Sie eine Präsentation mit den von der Klasse SWFOptions bereitgestellten Optionen in ein SWF‑Dokument konvertieren.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
    System::String dataDir = GetDataPath();

    // Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Speichern der Präsentation und Notizseiten
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **FAQ**

**Kann ich versteckte Folien in das SWF einbinden?**

Ja. Verwenden Sie die [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/)‑Methode in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). Standardmäßig werden versteckte Folien nicht exportiert.

**Wie kann ich die Kompression und die endgültige SWF‑Größe steuern?**

Verwenden Sie die [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/)‑Methode und passen Sie die [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) an, um Dateigröße und Bildtreue auszubalancieren.

**Wofür dient 'set_ViewerIncluded' und wann sollte ich es verwenden?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) fügt eine eingebettete Player‑UI (Navigations‑Steuerungen, Panels, Suche) hinzu. Deaktivieren Sie sie, wenn Sie Ihren eigenen Player verwenden oder einen reinen SWF‑Rahmen ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Export‑Computer fehlt?**

Aspose.Slides ersetzt die Schriftart durch die über [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) angegebene Schriftart, um ein unbeabsichtigtes Fallback zu vermeiden.