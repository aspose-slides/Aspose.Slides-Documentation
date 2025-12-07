---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren (C++)
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT zu TIFF exportieren
- PPTX zu TIFF exportieren
- PowerPoint mit Notizen
- Präsentation mit Notizen
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für C++. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for C++ bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Archivierung von Dokumenten verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Rednernotizen exportieren, sondern auch Folien‑Vorschaubilder in der Notizfolien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln, wobei Notizen und Layout erhalten bleiben.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides for C++ erfolgt in den folgenden Schritten:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabelayout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode.

Angenommen, wir haben eine Datei „speaker_notes.pptx“ mit der folgenden Folie:

![Die Präsentationsfolie mit Rednernotizen](slide_with_notes.png)

Der nachstehende Code‑Auszug zeigt, wie die Präsentation mithilfe der [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑Methode in ein TIFF‑Bild in der Notizfolien‑Ansicht konvertiert.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Anzeige der Notizen unterhalb der Folie.

// Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit den Rednernotizen.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Das TIFF‑Bild mit Rednernotizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Probieren Sie den kostenlosen Aspose PowerPoint‑zu‑Poster‑Konverter.

{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizenbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils ausblenden, auf einer einzigen Seite anpassen oder auf weitere Seiten fortsetzen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (e.g. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (wie 8 bpp oder 1 bpp für monochrome). Eine leichte Reduzierung der [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die ursprünglichen Schriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/cpp/font-selection-sequence/) aus, die Textmetriken und das Aussehen ändern kann. Um dies zu vermeiden, [supply the required fonts](/slides/de/cpp/custom-font/) oder setzen Sie eine Standard‑[fallback font](/slides/de/cpp/fallback-font/), damit die beabsichtigten Schriftarten verwendet werden.