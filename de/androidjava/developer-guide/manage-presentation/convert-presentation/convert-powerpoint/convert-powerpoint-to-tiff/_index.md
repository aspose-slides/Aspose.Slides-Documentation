---
title: PowerPoint-Präsentationen auf Android in TIFF konvertieren
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/androidjava/convert-powerpoint-to-tiff/
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
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mithilfe von Aspose.Slides für Android mit Java‑Beispielen einfach in hochwertige TIFF‑Bilder konvertieren können."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rastergrafikformat, das für seine außergewöhnliche Qualität und die detaillierte Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren und dabei sicherstellen, dass Ihre Präsentationen die maximale visuelle Treue beibehalten.

## **Präsentation in TIFF konvertieren**

Verwenden Sie die Methode [save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/), können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF konvertiert:

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

## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) ermöglicht es, den bei der Umwandlung einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendeten Algorithmus anzugeben. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Ebene‑Einstellung, die einen Pixel‑Konvertierungsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form dargestellt werden soll, wenn der Schwarz‑weiß‑Anzeigemodus aktiv ist, verwenden Sie [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Code zeigt, wie man die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert:

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

![Schwarz‑weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Zum Beispiel ermöglicht die Methode [setImageSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) die Definition der Größe des resultierenden Bildes.

Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Kompressionstyp festlegen.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default – Gibt das Standardschema für die Kompression an (LZW).
        None – Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

    // Bild-DPI festlegen.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Bildgröße festlegen.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **Präsentation in TIFF mit benutzerdefiniertem Bildpixel‑Format konvertieren**

Mit der Methode [setPixelFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie man eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:

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

{{% alert title="Tip" color="info" %}}
Schauen Sie sich Aspose's [Kostenlosen PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich anstelle einer gesamten PowerPoint‑Präsentation eine einzelne Folie in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht übernommen; es werden nur statische Schnappschüsse der Folien exportiert.