---
title: PowerPoint-Präsentationen auf Android mit Notizen in TIFF konvertieren
linktitle: PowerPoint zu TIFF mit Notizen
type: docs
weight: 100
url: /de/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "PowerPoint-Präsentationen mit Notizen mithilfe von Aspose.Slides für Android via Java in TIFF konvertieren. Erfahren Sie, wie Sie Folien mit Sprecher-Notizen effizient exportieren."
---

## **Übersicht**

Aspose.Slides für Android via Java bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur gesamte Präsentationen mit Sprecher‑Notizen exportieren, sondern auch Miniaturansichten der Folien in der Notizfolien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern umzuwandeln und dabei Notizen und Layout beizubehalten.

## **Präsentation mit Notizen in TIFF konvertieren**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mithilfe von Aspose.Slides für Android via Java umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)‑Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.  
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/)‑Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.  
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑Methode.

Angenommen, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Sprecher‑Notizen](slide_with_notes.png)

```java
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Zeigt die Notizen unterhalb der Folie an.

    // Konfigurieren Sie die TIFF-Optionen mit Notiz-Layout.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als TIFF mit den Sprecher-Notizen.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


Das Ergebnis:

![Das TIFF‑Bild mit Sprecher‑Notizen](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
Schauen Sie sich den kostenlosen Aspose [PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **Häufig gestellte Fragen**

**Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?**

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) , um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf einer einzelnen Seite anpassen oder sie auf zusätzliche Seiten fließen lassen.

**Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?**

Wählen Sie eine [efficient compression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (z. B. `LZW` oder `RLE`), setzen Sie eine angemessene DPI und verwenden Sie, falls akzeptabel, ein niedrigeres [pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (z. B. 8 bpp oder 1 bpp für Monochrom). Eine leichte Reduzierung der [image dimensions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

**Wirkt sich die Schriftart in den Notizen auf das Ergebnis aus, wenn die ursprünglichen Schriftarten im System fehlen?**

Ja. Fehlende Schriftarten lösen eine [substitution](/slides/de/androidjava/font-selection-sequence/) aus, die Textmaße und Aussehen ändern kann. Um dies zu vermeiden, [liefern Sie die erforderlichen Schriftarten](/slides/de/androidjava/custom-font/) oder setzen Sie eine Standard-[fallback font](/slides/de/androidjava/fallback-font/), damit die gewünschten Schriftarten verwendet werden.