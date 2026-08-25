---
title: PowerPoint-Präsentationen in TIFF in Java konvertieren
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
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für Java konvertieren, inklusive Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und detaillierte Bildwahrung bekannt ist. Designer, Fotografen und Desktop‑Publisher wählen häufig TIFF, um Ebenen, Farbgenauigkeit und Originaleinstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie mühelos Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen maximale visuelle Treue behalten. 

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-)‑Methode der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/)‑Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF umwandeln. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in TIFF konvertiert wird:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Präsentation in Schwarzweiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in der [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/)‑Klasse ermöglicht es, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarzweiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setCompressionType-int-)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Einstellung, die einen Pixel‑Konvertierungs‑Algorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form im Schwarz‑und‑Weiß‑Modus dargestellt wird, verwenden Sie [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.

{{% /alert %}}

Angenommen, wir haben die Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Code zeigt, wie die farbige Folie in ein Schwarzweiß‑TIFF konvertiert wird:

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

![Schwarzweiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Falls Sie ein TIFF‑Bild mit konkreten Abmessungen benötigen, können Sie die gewünschten Werte mit den Methoden der [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/)‑Klasse festlegen. Beispielsweise ermöglicht die [setImageSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-)‑Methode die Definition der Größe des resultierenden Bildes.

Dieser Code demonstriert, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Kompressionstyp festlegen.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das standardmäßige Kompressionsschema (LZW) an.
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Tiefe hängt vom Kompressionstyp ab und kann nicht manuell gesetzt werden.

    // Bild‑DPI festlegen.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Bildgröße festlegen.
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

## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/#setPixelFormat-int-)‑Methode der [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/)‑Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

```java
import com.aspose.slides.*;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bits pro Pixel, indiziert.
        Format8bppIndexed - 8 Bits pro Pixel, indiziert.
        Format24bppRgb    - 24 Bits pro Pixel, RGB.
        Format32bppArgb   - 32 Bits pro Pixel, ARGB.
    */
    
    // Speichern Sie die Präsentation als TIFF mit dem angegebenen Pixel‑Format.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="info" %}}

Probieren Sie Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkung für die Folienzahl fest. Sie können Präsentationen beliebiger Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF erhalten?**

Nein, TIFF ist ein statisches Bildformat. Deshalb werden Animationen und Übergangseffekte nicht erhalten; es werden nur statische Schnappschüsse der Folien exportiert.