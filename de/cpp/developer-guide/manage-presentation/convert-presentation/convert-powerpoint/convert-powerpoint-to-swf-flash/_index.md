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
description: "PowerPoint (PPT/PPTX) in SWF-Flash mit C++ und Aspose.Slides konvertieren. Schritt-für-Schritt-Codebeispiele, schnelle hochwertige Ausgabe, keine PowerPoint-Automatisierung."
---

## **Präsentationen in Flash konvertieren**

Die [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) Methode, die von der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) Klasse bereitgestellt wird, kann verwendet werden, um die gesamte Präsentation in ein SWF‑Dokument zu konvertieren. Sie können außerdem Kommentare im erzeugten SWF einbinden, indem Sie die [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) Klasse und die [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) Schnittstelle verwenden. Das folgende Beispiel zeigt, wie man eine Präsentation mithilfe der von der SWFOptions‑Klasse bereitgestellten Optionen in ein SWF‑Dokument konvertiert.
``` cpp
// Der Pfad zum Dokumentenverzeichnis.
    System::String dataDir = GetDataPath();

    // Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Speichert Präsentation und Notizseiten
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **FAQ**

**Kann ich ausgeblendete Folien in das SWF einbinden?**

Ja. Verwenden Sie die [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/)‑Methode in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/). Standardmäßig werden ausgeblendete Folien nicht exportiert.

**Wie kann ich die Komprimierung und die endgültige SWF‑Größe steuern?**

Verwenden Sie die [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/)‑Methode und passen Sie die [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/)‑Einstellung an, um Dateigröße und Bildqualität auszubalancieren.

**Wofür ist 'set_ViewerIncluded' gedacht und wann sollte ich es verwenden?**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) fügt eine eingebettete Player‑Benutzeroberfläche (Navigations‑Steuerelemente, Paneele, Suche) hinzu. Deaktivieren Sie sie, wenn Sie Ihren eigenen Player verwenden möchten oder ein reines SWF‑Gerüst ohne UI benötigen.

**Was passiert, wenn eine Quellschriftart auf dem Exportrechner fehlt?**

Aspose.Slides ersetzt die Schriftart durch die von Ihnen über die [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)‑Methode in [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) angegebene Standardschriftart, um ein unbeabsichtigtes Fallback zu vermeiden.