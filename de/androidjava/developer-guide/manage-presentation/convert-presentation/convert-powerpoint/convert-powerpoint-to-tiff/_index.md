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
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) mithilfe von Aspose.Slides für Android einfach in hochwertige TIFF‑Bilder konvertieren, inklusive Java‑Code‑Beispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detailgetreue Aufbewahrung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen in ihren Bildern beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren und dabei sicherstellen, dass Ihre Präsentationen maximale visuelle Treue bewahren. 

## **Eine Präsentation in TIFF konvertieren**

Mit der von der Klasse [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/) bereitgestellten Methode [save](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) können Sie schnell eine komplette PowerPoint‑Präsentation in TIFF konvertieren. Die erzeugten TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in TIFF konvertieren:

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

## **Eine Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) ermöglicht es Ihnen, den beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendeten Algorithmus festzulegen. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser Code zeigt, wie Sie die farbige Folie in ein Schwarz‑weiß‑TIFF konvertieren:

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

## **Eine Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte mithilfe der in [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht Ihnen die Methode [setImageSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-), die Größe des resultierenden Bildes zu definieren.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertieren:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // Legen Sie den Kompressionstyp fest.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standardschema für die Kompression an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell gesetzt werden.

    // Legen Sie die Bild‑DPI fest.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Legen Sie die Bildgröße fest.
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

## **Eine Präsentation in TIFF mit benutzerdefiniertem Bildpixel‑Format konvertieren**

Mit der Methode [setPixelFormat](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) der Klasse [TiffOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser Code zeigt, wie Sie eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertieren:

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
        Format4bppIndexed - 4 Bit pro Pixel, indiziert.
        Format8bppIndexed - 8 Bit pro Pixel, indiziert.
        Format24bppRgb    - 24 Bit pro Pixel, RGB.
        Format32bppArgb   - 32 Bit pro Pixel, ARGB.
    */
    
    // Speichern Sie die Präsentation als TIFF mit dem angegebenen Pixelformat.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Hinweis" color="info" %}}
Schauen Sie sich Aspose's [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

### Kann ich eine einzelne Folie anstelle einer gesamten PowerPoint‑Präsentation in TIFF konvertieren?

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

### Gibt es ein Limit für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?

Nein, Aspose.Slides setzt keinerlei Beschränkungen für die Anzahl der Folien. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

### Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Momentaufnahmen der Folien exportiert.