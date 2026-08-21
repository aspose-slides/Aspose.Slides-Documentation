---
title: PowerPoint‑Präsentationen in TIFF konvertieren in Java
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
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
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mühelos in hochqualitative TIFF‑Bilder mit Aspose.Slides für Java konvertieren, anhand von Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und detaillierte Bildwiedergabe bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und Originaleinstellungen ihrer Bilder zu erhalten.

Mit Aspose.Slides können Sie PowerPoint‑Foli​en (PPT, PPTX) und OpenDocument‑Foli​en (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren und dabei sicherstellen, dass Ihre Präsentationen maximale visuelle Treue bewahren. 

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF umwandeln. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Präsentation in Schwarz‑Weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in der [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/)‑Klasse ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑Weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setCompressionType-int-)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Ebene‑Einstellung, die einen Pixel‑Konvertierungs‑Algorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form im Schwarz‑Weiß‑Anzeige‑Modus erscheinen soll, verwenden Sie [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Siehe [Control Black-and-White Rendering for Shapes](/java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei „sample.pptx“ mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Der folgende Code demonstriert, wie die farbige Folie in ein Schwarz‑Weiß‑TIFF konvertiert wird:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Schwarz‑Weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die [setImageSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)‑Methode die Definition der Größe des resultierenden Bildes.

Der folgende Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Setzen Sie den Kompressionstyp.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das standardmäßige Kompressionsschema an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

    // Setzen Sie die Bild-DPI.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Setzen Sie die Bildgröße.
    tiffOptions.setImageSize(new Dimension(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Präsentation in TIFF mit benutzerdefiniertem Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)‑Methode der [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/)‑Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Der folgende Code demonstriert, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bit pro Pixel, indiziert.
        Format8bppIndexed - 8 Bit pro Pixel, indiziert.
        Format24bppRgb    - 24 Bit pro Pixel, RGB.
        Format32bppArgb   - 32 Bit pro Pixel, ARGB.
    */
    
    // Speichern Sie die Präsentation als TIFF mit dem angegebenen Pixel-Format.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="info" %}}
Probieren Sie den KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter von Aspose aus: [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Folienzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht erhalten; es werden nur statische Momentaufnahmen der Folien exportiert.