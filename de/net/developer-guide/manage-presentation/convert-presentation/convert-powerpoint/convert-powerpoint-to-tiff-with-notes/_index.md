---
title: PowerPoint-Präsentationen mit Notizen in TIFF konvertieren in .NET
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
description: "Konvertieren Sie PowerPoint-Präsentationen in TIFF mit Notizen mithilfe von Aspose.Slides für .NET. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für .NET bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur ganze Präsentationen mit Sprecheranmerkungen exportieren, sondern auch Folienminiaturen in der Notes‑Slide‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `Save`-Methode der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) , um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu transformieren, wobei Notizen und Layout erhalten bleiben.

## **Präsentation in TIFF mit Notizen konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides für .NET umfasst die folgenden Schritte:

1. Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) : Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die Klasse [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) , um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die Methode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

Angenommen, wir haben eine Datei „speaker_notes.pptx“ mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecheranmerkungen](slide_with_notes.png)

Der untenstehende Code‑Abschnitt zeigt, wie die Präsentation in ein TIFF‑Bild in der Notes‑Slide‑Ansicht konvertiert wird, indem die Eigenschaft [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) verwendet wird.
```c#
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei repräsentiert.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // Konfigurieren Sie die TIFF-Optionen mit Noten-Layout.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Zeigen Sie die Notizen unterhalb der Folie an.
        }
    };

    // Speichern Sie die Präsentation als TIFF mit den Sprecher-Notizen.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


Das Ergebnis:

![Das TIFF‑Bild mit Sprecheranmerkungen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

Probieren Sie Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) , um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf einer einzigen Seite einpassen oder zulassen, dass sie auf zusätzliche Seiten übergehen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und nutzen Sie, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) (wie 8 bpp oder 1 bpp für Monochrom). Eine leichte Reduzierung der [image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/net/font-selection-sequence/) aus, die Textmaße und das Erscheinungsbild ändern kann. Um dies zu vermeiden, [supply the required fonts](/slides/de/net/custom-font/) oder setzen Sie eine Standard‑[fallback font](/slides/de/net/fallback-font/), damit die gewünschten Schriftarten verwendet werden.