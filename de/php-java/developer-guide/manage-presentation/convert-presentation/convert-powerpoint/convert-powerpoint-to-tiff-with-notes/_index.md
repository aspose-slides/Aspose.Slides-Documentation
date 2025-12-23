---
title: PowerPoint-Präsentationen zu TIFF mit Notizen in PHP konvertieren
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "Konvertieren Sie PowerPoint-Präsentationen zu TIFF mit Notizen mithilfe von Aspose.Slides für PHP via Java. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides for PHP via Java bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Rednernotizen exportieren, sondern auch Miniaturansichten der Folien in der Notiz‑Folien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu verwandeln, wobei Notizen und Layout erhalten bleiben.

## **Präsentation in TIFF mit Notizen konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides for PHP via Java umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save)‑Methode.

Angenommen, wir haben eine Datei **speaker_notes.pptx** mit der folgenden Folie:

![Die Präsentationsfolie mit Notizen des Redners](slide_with_notes.png)

Der nachfolgende Codeausschnitt demonstriert, wie Sie die Präsentation in ein TIFF‑Bild in der Notiz‑Folien‑Ansicht konvertieren, indem Sie die [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions)‑Methode verwenden.
```php
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // Zeigt die Notizen unterhalb der Folie an.

    // Konfigurieren Sie die TIFF-Optionen mit Notizenlayout.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // Speichern Sie die Präsentation als TIFF mit den Rednernotizen.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


Das Ergebnis:

![Das TIFF-Bild mit Notizen des Redners](TIFF_with_notes.png)

{{% alert title="Hinweis" color="primary" %}}
Schauen Sie sich den kostenlosen Aspose [PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich die Position des Notizen‑Bereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions), um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die Notizen jeweils ausblenden, auf einer einzigen Seite anpassen oder auf zusätzliche Seiten ausdehnen.

**Wie kann ich die Dateigröße eines TIFFs mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [effiziente Kompression](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setcompressiontype/) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und, falls akzeptabel, ein niedrigeres [Pixel‑Format](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/) (wie 8 bpp oder 1 bpp für Monochrom). Eine leichte Verringerung der [Bildabmessungen](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die Original‑Schriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/php-java/font-selection-sequence/) aus, die Textmaße und Aussehen ändern kann. Um dies zu vermeiden, [stellen Sie die benötigten Schriftarten bereit](/slides/de/php-java/custom-font/) oder definieren Sie eine Standard‑[Fallback‑Schriftart](/slides/de/php-java/fallback-font/), sodass die gewünschten Schriftarten verwendet werden.