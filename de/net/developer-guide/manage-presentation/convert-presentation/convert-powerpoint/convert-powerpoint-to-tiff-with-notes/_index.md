---
title: PowerPoint‑Präsentationen in TIFF mit Notizen in .NET konvertieren
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
- Folie mit Notizen
- PPT mit Notizen
- PPTX mit Notizen
- TIFF mit Notizen
- .NET
- C#
- Aspose.Slides
description: "PowerPoint‑Präsentationen mit Notizen in TIFF konvertieren mit Aspose.Slides für .NET. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für .NET bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur komplette Präsentationen mit Rednernotizen exportieren, sondern auch Folienminiaturen in der Notizfolienansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`‑Methode der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln und dabei Notizen und Layout beizubehalten.

## **Eine Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides für .NET umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)‑Methode.

Angenommen, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Rednernotizen](slide_with_notes.png)

Der nachstehende Codeabschnitt zeigt, wie die Präsentation mithilfe der [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/)‑Eigenschaft in ein TIFF‑Bild in der Notizfolienansicht konvertiert wird.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Anzeigen der Notizen unterhalb der Folie.
        }
    };

    // Speichern Sie die Präsentation als TIFF mit den Rednernotizen.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


Das Ergebnis:

![Das TIFF‑Bild mit Rednernotizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Schauen Sie sich Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [Notiz‑Layout‑Einstellungen](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils die Notizen ausblenden, sie auf einer einzelnen Seite anpassen oder erlauben, dass sie auf weitere Seiten fließen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und verwenden Sie, falls akzeptabel, ein niedrigeres [Pixel‑Format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) (z. B. 8 bpp oder 1 bpp für monochrom). Eine leichte Reduzierung der [Bildabmessungen](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die ursprünglichen Schriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/net/font-selection-sequence/) aus, die Textmetriken und das Aussehen ändern kann. Um dies zu vermeiden, [stellen Sie die erforderlichen Schriftarten bereit](/slides/de/net/custom-font/) oder setzen Sie eine Standard‑[Fallback‑Schriftart](/slides/de/net/fallback-font/), damit die gewünschten Schriftarten verwendet werden.