---
title: PowerPoint in TIFF mit Notizen in C#
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint zu TIFF konvertieren
- Präsentation zu TIFF konvertieren
- Folie zu TIFF konvertieren
- PPT zu TIFF konvertieren
- PPTX zu TIFF konvertieren
- ODP zu TIFF konvertieren
- PowerPoint zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- ODP zu TIFF
- PowerPoint mit Notizen
- Präsentation mit Notizen
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- ODP mit Notizen
- TIFF mit Notizen
- C#
- .NET
- Aspose.Slides
description: "PowerPoint- und OpenDocument-Präsentationen mit Notizen mithilfe von Aspose.Slides für .NET in TIFF konvertieren. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für .NET bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur komplette Präsentationen mit Sprecher‑Notizen exportieren, sondern auch Folien‑Thumbnails in der Notiz‑Folien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu transformieren, wobei Notizen und Layout erhalten bleiben.

## **Konvertieren einer Präsentation in TIFF mit Notizen**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides für .NET umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Optionen für das Ausgabelayout: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)‑Methode.

Angenommen, wir haben die Datei **speaker_notes.pptx** mit der folgenden Folie:

![The presentation slide with speaker notes](slide_with_notes.png)

Der nachstehende Codeausschnitt zeigt, wie die Präsentation in ein TIFF‑Bild in der Notiz‑Folien‑Ansicht konvertiert wird, indem die [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/)‑Eigenschaft verwendet wird.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurieren Sie die TIFF-Optionen mit Notiz-Layout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Notizen unterhalb der Folie anzeigen.
        }
    };

    // Speichern Sie die Präsentation als TIFF mit den Sprecher-Notizen.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


Das Ergebnis:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tipp" color="primary" %}}
Sehen Sie sich den kostenlosen Aspose [PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils ausblenden, in eine einzelne Seite einpassen oder auf zusätzliche Seiten ausdehnen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und, falls akzeptabel, verwenden Sie ein niedrigeres [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) (wie 8 bpp oder 1 bpp für monochrom). Ein leichtes Reduzieren der [image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/net/font-selection-sequence/) aus, die Textmetriken und das Erscheinungsbild verändern kann. Um dies zu vermeiden, [stellen Sie die erforderlichen Schriftarten bereit](/slides/de/net/custom-font/) oder setzen Sie eine Standard‑[fallback font](/slides/de/net/fallback-font/), sodass die gewünschten Schriftarten verwendet werden.