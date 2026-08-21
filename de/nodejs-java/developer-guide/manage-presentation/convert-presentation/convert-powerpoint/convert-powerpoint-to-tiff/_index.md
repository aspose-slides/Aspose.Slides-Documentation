---
title: PowerPoint-Präsentationen in TIFF mit JavaScript konvertieren
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/nodejs-java/convert-powerpoint-to-tiff/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) ganz einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für Node.js konvertieren, inklusive JavaScript‑Codebeispielen."
---
## **Einleitung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rastergrafikformat, das für seine außergewöhnliche Qualität und die detailgetreue Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und ursprüngliche Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren und sicherstellen, dass Ihre Präsentationen die maximale visuelle Treue beibehalten.

## **Präsentation in TIFF konvertieren**

Durch die Verwendung der [save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)‑Methode der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die entstehenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF konvertiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in der [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/)-Klasse ermöglicht es, den Algorithmus anzugeben, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Einstellung, die einen Pixel‑Konvertierungsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form aussieht, wenn der Schwarz‑weiß‑Anzeigemodus aktiv ist, verwenden Sie [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Siehe [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser JavaScript‑Code zeigt, wie man die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

Das Ergebnis:

![Schwarz‑weiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie die gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die Methode [setImageSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setImageSize), die Größe des entstehenden Bildes zu definieren.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Legen Sie den Kompressionstyp fest.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standardskompressionsschema (LZW) an.
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe wird durch das Pixel‑Format gesteuert (siehe das Beispiel unten); CCITT3 und CCITT4 erzeugen immer 1 Bit pro Pixel.

    // Legen Sie die Bild‑DPI fest.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Legen Sie die Bildgröße fest.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Speichern Sie die Präsentation als TIFF mit der angegebenen Größe.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Präsentation in TIFF mit benutzerdefiniertem Bildpixel‑format konvertieren**

Durch die Verwendung der [setPixelFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat)‑Methode aus der [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/)-Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bits pro Pixel, indiziert.
        Format8bppIndexed - 8 Bits pro Pixel, indiziert.
        Format24bppRgb    - 24 Bits pro Pixel, RGB.
        Format32bppArgb   - 32 Bits pro Pixel, ARGB.
    */

    /// Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Schauen Sie sich Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie statt der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Momentaufnahmen der Folien exportiert.