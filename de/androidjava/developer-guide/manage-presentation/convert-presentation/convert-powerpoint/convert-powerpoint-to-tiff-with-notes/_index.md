---
title: PowerPoint-Präsentationen mit Notizen auf Android in TIFF konvertieren
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
description: "PowerPoint-Präsentationen mit Notizen in TIFF konvertieren mithilfe von Aspose.Slides für Android über Java. Erfahren Sie, wie Sie Folien mit Rednernotizen effizient exportieren."
---
## **Einleitung**

Aspose.Slides für Android über Java bietet eine einfache Lösung zum Konvertieren von PowerPoint‑ und OpenDocument‑Präsentationen (PPT, PPTX und ODP) mit Notizen in das TIFF‑Format. Dieses Format wird häufig für die hochwertige Bildspeicherung, den Druck und die Dokumentenarchivierung verwendet. Mit Aspose.Slides können Sie nicht nur ganze Präsentationen mit Rednernotizen exportieren, sondern auch Miniaturansichten der Folien in der Notizfolien‑Ansicht erzeugen. Der Konvertierungsprozess ist einfach und effizient und nutzt die `save`‑Methode der [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Klasse, um die gesamte Präsentation in eine Reihe von TIFF‑Bildern zu transformieren, wobei Notizen und Layout erhalten bleiben.

## **Konvertieren einer Präsentation in TIFF mit Notizen**

Das Speichern einer PowerPoint‑ oder OpenDocument‑Präsentation als TIFF mit Notizen mittels Aspose.Slides für Android über Java umfasst die folgenden Schritte:

1. Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/)-Klasse: Laden Sie eine PowerPoint‑ oder OpenDocument‑Datei.
2. Konfigurieren Sie die Ausgabe‑Layout‑Optionen: Verwenden Sie die [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/notescommentslayoutingoptions/)-Klasse, um festzulegen, wie Notizen und Kommentare angezeigt werden sollen.
3. Speichern Sie die Präsentation als TIFF: Übergeben Sie die konfigurierten Optionen an die [save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)-Methode.

Angenommen, wir haben eine Datei "speaker_notes.pptx" mit der folgenden Folie:

![Die Präsentationsfolie mit Rednernotizen](slide_with_notes.png)

Das folgende Code‑Snippet zeigt, wie man die Präsentation in ein TIFF‑Bild in der Notizfolien‑Ansicht konvertiert, indem man die [setSlidesLayoutOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)-Methode verwendet.

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // Anzeige der Notizen unterhalb der Folie.

    // Konfigurieren Sie die TIFF-Optionen mit Notizen-Layout.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als TIFF mit den Rednernotizen.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Das TIFF‑Bild mit Rednernotizen](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
Schauen Sie sich den Aspose [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

### Kann ich die Position des Notizbereichs im resultierenden TIFF steuern?

Ja. Verwenden Sie die [notes layout settings](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-)-Einstellungen, um zwischen Optionen wie `None`, `BottomTruncated` oder `BottomFull` zu wählen, die jeweils Notizen ausblenden, sie auf eine einzelne Seite anpassen oder erlauben, dass sie auf zusätzliche Seiten fließen.

### Wie kann ich die Größe einer TIFF‑Datei mit Notizen reduzieren, ohne sichtbaren Qualitätsverlust?

Wählen Sie eine [effiziente Komprimierung](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (z. B. `LZW` oder `RLE`), setzen Sie einen angemessenen DPI‑Wert und, falls akzeptabel, verwenden Sie ein niedrigeres [Pixel‑Format](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (wie 8 bpp oder 1 bpp für Monochrom). Eine leichte Verringerung der [Bildabmessungen](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) kann ebenfalls helfen, ohne die Lesbarkeit merklich zu beeinträchtigen.

### Beeinflusst die Schriftart in den Notizen das Ergebnis, wenn die ursprünglichen Schriftarten im System fehlen?

Ja. Fehlende Schriftarten lösen eine [Substitution](/slides/de/androidjava/font-selection-sequence/)-Ersetzung aus, die Textmetriken und Aussehen ändern kann. Um dies zu vermeiden, [erforderlichen Schriftarten bereitstellen](/slides/de/androidjava/custom-font/) oder eine standardmäßige [Fallback‑Schriftart](/slides/de/androidjava/fallback-font/) festlegen, sodass die beabsichtigten Schriftarten verwendet werden.