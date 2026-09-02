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
- Folien konvertieren
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
description: "Erfahren Sie, wie Sie PowerPoint‑Präsentationen (PPT, PPTX) ganz einfach in hochwertige TIFF‑Bilder mit Aspose.Slides für Node.js konvertieren, anhand von JavaScript‑Beispielcode."
---
## **Einführung**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detailgenaue Erhaltung von Grafiken bekannt ist. Designer, Fotografen und Desktop‑Publisher wählen TIFF häufig, um Ebenen, Farbgenauigkeit und Originaleinstellungen in ihren Bildern beizubehalten.

## **Präsentation in TIFF konvertieren**

Mit der [save](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)‑Methode der [Presentation](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **Präsentation in Schwarzweiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in der [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/)-Klasse ermöglicht es Ihnen, den Algorithmus anzugeben, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarzweiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die [setCompressionType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-)‑Methode auf `CCITT4` oder `CCITT3` gesetzt ist.

{{% alert color="info" title="Hinweis" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) ist eine Export‑Ebene‑Einstellung, die einen Pixel‑Konvertierungsalgorithmus für das gesamte TIFF‑Bild auswählt. Um festzulegen, wie eine einzelne Form angezeigt wird, wenn der Schwarzweiß‑Anzeigemodus aktiv ist, verwenden Sie [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/#setBlackWhiteMode). Siehe [Control Black-and-White Rendering for Shapes](/slides/de/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) für Beispiele.
{{% /alert %}}

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser JavaScript‑Code zeigt, wie Sie die farbige Folie in ein Schwarzweiß‑TIFF konvertieren:

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

![Schwarzweiß‑TIFF](TIFF_black_and_white.png)

## **Präsentation in TIFF mit benutzerdefinierter Größe konvertieren**

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie Ihre gewünschten Werte über die in [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Beispielsweise ermöglicht die [setImageSize](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setImageSize)-Methode, die Größe des resultierenden Bildes zu definieren.

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
        Default - Gibt das Standardschema für die Kompression an (LZW).
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe wird vom Pixelformat gesteuert (siehe das Beispiel unten); CCITT3 und CCITT4 erzeugen immer 1 Bit pro Pixel.

    // Bild‑DPI festlegen.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // Bildgröße festlegen.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // Präsentation mit der angegebenen Größe als TIFF speichern.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **Präsentation in TIFF mit benutzerdefiniertem Pixel‑Format konvertieren**

Mit der [setPixelFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat)-Methode der [TiffOptions](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tiffoptions/)-Klasse können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) repräsentiert.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat enthält die folgenden Werte (wie in der Dokumentation angegeben):
        Format1bppIndexed - 1 Bit pro Pixel, indiziert.
        Format4bppIndexed - 4 Bit pro Pixel, indiziert.
        Format8bppIndexed - 8 Bit pro Pixel, indiziert.
        Format24bppRgb    - 24 Bit pro Pixel, RGB.
        Format32bppArgb   - 32 Bit pro Pixel, ARGB.
    */

    /// Präsentation mit der angegebenen Bildgröße als TIFF speichern.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tipp" color="info" %}}
Schauen Sie sich Asposes [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/de/conversion/convert-ppt-to-poster-online) an.
{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es eine Begrenzung für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen jeder Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.