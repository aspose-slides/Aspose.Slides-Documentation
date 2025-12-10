---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren in C++
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
- Folie mit Notieren
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für C++. Erfahren Sie, wie Sie Folien mit Sprechernotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for C++ bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Archivierung von Dokumenten verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Sprechernotizen exportieren, sondern auch Miniaturbilder der Folien in der Notiz‑Folien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln, wobei Notizen und Layout erhalten bleiben.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides for C++ erfolgt in den folgenden Schritten:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)-Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode.

Angenommen, wir haben die Datei **speaker_notes.pptx** mit der folgenden Folie:

![The presentation slide with speaker notes](slide_with_notes.png)

Der nachfolgende Code‑Auszug demonstriert, wie die Präsentation in ein TIFF‑Bild in der Notiz‑Folien‑Ansicht mit der [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑Methode konvertiert wird.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zeigt die Notizen unterhalb der Folie an.

// Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit den Sprechernotizen.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tipp" color="primary" %}}
Schauen Sie sich den Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils ausblenden, auf einer einzigen Seite einpassen oder auf zusätzliche Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und, falls akzeptabel, verwenden Sie ein niedrigeres [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (wie 8 bpp oder 1 bpp für Monochrom). Ein leichtes Verringern der [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/cpp/font-selection-sequence/) aus, die Textmaße und Erscheinungsbild verändern kann. Um dies zu vermeiden, [supply the required fonts](/slides/de/cpp/custom-font/) oder setzen Sie eine Standard‑[fallback font](/slides/de/cpp/fallback-font/), damit die vorgesehenen Schriftarten verwendet werden.