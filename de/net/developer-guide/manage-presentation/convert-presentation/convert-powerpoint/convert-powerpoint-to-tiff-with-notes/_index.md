---
title: Konvertieren von PowerPoint‑Präsentationen in TIFF mit Notizen in .NET
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/net/convert-powerpoint-to-tiff-with-notes/
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
- Folie mit Notieren
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- .NET
- C#
- Aspose.Slides
description: "PowerPoint‑Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für .NET. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---
## **Einleitung**

Aspose.Slides für .NET bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Rednernotizen exportieren, sondern auch Folien‑Thumbnails in der Notizfolien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu transformieren und dabei Notizen und Layout beizubehalten.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation in TIFF mit Notizen mithilfe von Aspose.Slides für .NET umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/net/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/methods/save/index)‑Methode.

Nehmen wir an, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Rednernotizen](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei repräsentiert.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurieren Sie die TIFF‑Optionen mit Notiz‑Layout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Zeigt die Notizen unterhalb der Folie an.
        }
    };

    // Speichern Sie die Präsentation als TIFF mit den Rednernotizen.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```

Das Ergebnis:

![Das TIFF-Bild mit Rednernotizen](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Probieren Sie Aspose [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

### Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf einer einzelnen Seite anpassen oder erlauben, dass sie auf weitere Seiten übergehen.

### Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und verwenden Sie, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/pixelformat/) (wie 8 bpp oder 1 bpp für Monochrom). Das leichte Reduzieren der [image dimensions](https://reference.aspose.com/slides/de/net/aspose.slides.export/tiffoptions/imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

### Wirken sich fehlende Schriftarten in den Notizen auf das Ergebnis aus, wenn die Originalschriftarten im System fehlen?

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/net/font-selection-sequence/) aus, die Textmaße und das Erscheinungsbild ändern kann. Um dies zu vermeiden, [die erforderlichen Schriftarten bereitstellen](/slides/de/net/custom-font/) oder setzen Sie eine Standard‑[Fallback‑Schriftart](/slides/de/net/fallback-font/), sodass die vorgesehenen Schriftarten verwendet werden.