---
title: PowerPoint zu TIFF mit Notizen in JavaScript konvertieren
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/nodejs-java/convert-powerpoint-to-tiff-with-notes/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertieren Sie PowerPoint- und OpenDocument-Präsentationen mit Notizen in TIFF mithilfe von Aspose.Slides für Node.js via Java. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for Node.js via Java bietet eine einfache Lösung zum Konvertieren von PowerPoint- und OpenDocument-Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF-Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Rednernotizen exportieren, sondern auch Miniaturansichten der Folien in der Notizfolienansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern umzuwandeln und dabei Notizen und Layout beizubehalten.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation im TIFF‑Format mit Notizen mithilfe von Aspose.Slides for Node.js via Java umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
1. Konfigurieren Sie die Ausgabelayout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
1. Speichern Sie die Präsentation im TIFF-Format: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save)‑Methode.

Nehmen wir an, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Rednernotizen](slide_with_notes.png)

Der folgende Codeausschnitt zeigt, wie die Präsentation mithilfe der [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)‑Methode in ein TIFF‑Bild in der Notizfolienansicht konvertiert wird.
```js
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // Zeigt die Notizen unterhalb der Folie an.

    // Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation im TIFF-Format mit den Rednernotizen.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![Das TIFF‑Bild mit Rednernotizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Schauen Sie sich den [Kostenlosen PowerPoint-zu-Poster-Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) von Aspose an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils verbergen, auf eine einzelne Seite anpassen oder auf zusätzliche Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie einen angemessenen DPI‑Wert und, falls akzeptabel, verwenden Sie ein niedrigeres [pixel format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) (wie 8 bpp oder 1 bpp für monochrom). Eine leichte Verringerung der [image dimensions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setimagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Originalschriftarten nicht im System vorhanden sind?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/nodejs-java/font-selection-sequence/) aus, die Textmaße und Darstellung ändern kann. Um dies zu vermeiden, [supply the required fonts](/slides/de/nodejs-java/custom-font/) oder setzen Sie eine Standard-[fallback font](/slides/de/nodejs-java/fallback-font/), damit die vorgesehenen Schriften verwendet werden.