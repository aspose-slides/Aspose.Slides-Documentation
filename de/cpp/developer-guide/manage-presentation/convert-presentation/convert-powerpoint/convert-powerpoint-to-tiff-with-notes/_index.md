---
title: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren in C++"
linktitle: "PowerPoint zu TIFF mit Notizen"
type: docs
weight: 100
url: /de/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- "PowerPoint konvertieren"
- "Präsentation konvertieren"
- "Folie konvertieren"
- "PPT konvertieren"
- "PPTX konvertieren"
- "PowerPoint zu TIFF"
- "Präsentation zu TIFF"
- "Folie zu TIFF"
- "PPT zu TIFF"
- "PPTX zu TIFF"
- "PPT als TIFF speichern"
- "PPTX als TIFF speichern"
- "PPT nach TIFF exportieren"
- "PPTX nach TIFF exportieren"
- "PowerPoint mit Notizen"
- "Präsentation mit Notizen"
- "Folie mit Notizen"
- "PPT mit Notizen"
- "PPTX mit Notizen"
- "TIFF mit Notizen"
- "C++"
- "Aspose.Slides"
description: "Konvertieren Sie PowerPoint-Präsentationen mit Notizen in TIFF mithilfe von Aspose.Slides für C++. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für C++ bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur ganze Präsentationen mit Sprecher‑Notizen exportieren, sondern auch Folien‑Thumbnails in der Notiz‑Folien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln, wobei Notizen und Layout erhalten bleiben.

## **Präsentation in TIFF mit Notizen konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen unter Verwendung von Aspose.Slides für C++ umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode.

Angenommen, wir haben eine Datei „speaker_notes.pptx“ mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecher-Notizen](slide_with_notes.png)

Das untenstehende Code‑Snippet zeigt, wie Sie die Präsentation in ein TIFF‑Bild in der Notiz‑Folien‑Ansicht mit der [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑Methode konvertieren.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zeigt die Notizen unterhalb der Folie an.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Das TIFF-Bild mit Sprecher-Notizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Schauen Sie sich den Aspose [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf einer einzigen Seite platzieren bzw. sie über weitere Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF-Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und verwenden Sie, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (wie 8 bpp oder 1 bpp für monochrom). Eine leichte Reduzierung der [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten auf dem System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/cpp/font-selection-sequence/) aus, die Textmaße und Aussehen verändern kann. Um das zu vermeiden, [supply the required fonts](/slides/de/cpp/custom-font/) oder setzen Sie eine Standard‑[fallback font](/slides/de/cpp/fallback-font/), damit die vorgesehenen Schriftarten verwendet werden.