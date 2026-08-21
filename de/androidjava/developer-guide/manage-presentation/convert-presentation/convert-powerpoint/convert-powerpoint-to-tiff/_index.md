---
title: PowerPoint-Präsentationen nach TIFF auf Android konvertieren
titlelink: PowerPoint nach TIFF
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
- PowerPoint nach TIFF
- Präsentation nach TIFF
- Folie nach TIFF
- PPT nach TIFF
- PPTX nach TIFF
- PPT als TIFF speichern
- PPTX als TIFF speichern
- PPT nach TIFF exportieren
- PPTX nach TIFF exportieren
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) ganz einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für Android konvertieren, inklusive Java‑Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und detailgenaue Bildwahrung bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und originale Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, sodass Ihre Präsentationen maximale visuelle Treue behalten. 

## **Präsentation in TIFF konvertieren**

Verwenden Sie die Methode [save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/), um schnell eine gesamte PowerPoint‑Präsentation in TIFF zu konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

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

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) ermöglicht es Ihnen, den beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarzweiß‑TIFF verwendeten Algorithmus anzugeben. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Ebene‑Einstellung, die einen Pixel‑Konvertierungsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form angezeigt werden soll, wenn der Schwarz‑Weiß‑Anzeigemodus aktiv ist, verwenden Sie [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-). Siehe [Control Black-and-White Rendering for Shapes](/androidjava/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

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

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie Ihre gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die Methode [setImageSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-), die Größe des resultierenden Bildes zu definieren.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert wird:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Setzen Sie den Kompressionstyp.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standardschema für die Komprimierung an (LZW).
        None - Gibt an, dass keine Komprimierung erfolgt.
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

## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Durch die Verwendung der Methode [setPixelFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) können Sie das bevorzugte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert wird:

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
        Format4bppIndexed - 4 Bits pro Pixel, indiziert.
        Format8bppIndexed - 8 Bits pro Pixel, indiziert.
        Format24bppRgb    - 24 Bits pro Pixel, RGB.
        Format32bppArgb   - 32 Bits pro Pixel, ARGB.
    */
    
    // Speichern Sie die Präsentation als TIFF mit dem angegebenen Pixel-Format.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="info" %}}
Schauen Sie sich Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle einer gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung der Folienzahl beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keinerlei Beschränkungen für die Folienzahl fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.