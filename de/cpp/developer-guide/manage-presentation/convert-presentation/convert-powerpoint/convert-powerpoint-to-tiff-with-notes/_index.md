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
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- PowerPoint mit Notizen
- Präsentation mit Notizen
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- C++
- Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen mithilfe von Aspose.Slides für C++ in TIFF konvertieren. Erfahren Sie, wie Sie Folien mit Referentennotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for C++ bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur ganze Präsentationen mit Referenten‑Notizen exportieren, sondern auch Folien‑Thumbnails in der Notizen‑Folien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln, wobei Notizen und Layout erhalten bleiben.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides for C++ erfolgt in den folgenden Schritten:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.  
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.  
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/)‑Methode.

Angenommen, wir haben eine Datei „speaker_notes.pptx“ mit der folgenden Folie:

![Die Präsentationsfolie mit Referenten‑Notizen](slide_with_notes.png)

Der Codeausschnitt unten zeigt, wie die Präsentation in ein TIFF‑Bild in der Notizen‑Folien‑Ansicht konvertiert wird, indem die [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/)‑Methode verwendet wird.
```cpp
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Zeigt die Notizen unterhalb der Folie an.

// Konfigurieren Sie die TIFF-Optionen mit Notizenlayout.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Speichern Sie die Präsentation als TIFF mit den Referentennotizen.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


Das Ergebnis:

![Das TIFF‑Bild mit Referenten‑Notizen](TIFF_with_notes.png)

{{% alert title="Hinweis" color="primary" %}}

Probieren Sie den Aspose [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) aus.

{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils ausblenden, auf einer einzigen Seite anpassen oder über mehrere Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und, falls akzeptabel, verwenden Sie ein niedrigeres [Pixel‑Format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) (wie 8 bpp oder 1 bpp für monochrom). Das leichte Reduzieren der [Bildabmessungen](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Wirkt sich die Schriftart in den Notizen auf das Ergebnis aus, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/cpp/font-selection-sequence/) aus, die Textmaße und das Aussehen ändern kann. Um dies zu vermeiden, [stellen Sie die erforderlichen Schriftarten bereit](/slides/de/cpp/custom-font/) oder setzen Sie eine Standard‑[Fallback‑Schriftart](/slides/de/cpp/fallback-font/), damit die vorgesehenen Schriftarten verwendet werden.