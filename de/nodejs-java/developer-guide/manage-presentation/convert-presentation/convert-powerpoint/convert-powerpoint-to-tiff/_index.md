---
title: PowerPoint-Präsentationen in TIFF konvertieren mit JavaScript
titlelink: PowerPoint zu TIFF
type: docs
weight: 90
url: /de/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint konvertieren
- OpenDocument konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PowerPoint zu TIFF
- OpenDocument zu TIFF
- Präsentation zu TIFF
- Folie zu TIFF
- PPT zu TIFF
- PPTX zu TIFF
- ODP zu TIFF
- Node.js
- JavaScript
- Aspose.Slides
description: "Erfahren Sie, wie Sie PowerPoint- (PPT, PPTX) und OpenDocument- (ODP) Präsentationen mit Aspose.Slides für Node.js über Java einfach in hochwertige TIFF-Bilder konvertieren können. Schritt-für-Schritt-Anleitung mit Code-Beispielen."
---

## **Übersicht**

TIFF (**Tagged Image File Format**) ist ein weit verbreitetes, verlustfreies Rasterbildformat, das für seine außergewöhnliche Qualität und die detailgetreue Bewahrung von Grafiken bekannt ist. Designer, Fotografen und Desktop-Publisher wählen häufig TIFF, um Ebenen, Farbtreue und die ursprünglichen Einstellungen ihrer Bilder beizubehalten.

Mit Aspose.Slides können Sie Ihre PowerPoint‑Folien (PPT, PPTX) und OpenDocument‑Folien (ODP) mühelos direkt in hochwertige TIFF‑Bilder konvertieren, wodurch Ihre Präsentationen maximale visuelle Treue bewahren.

## **Präsentation in TIFF konvertieren**

Durch die Verwendung der [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-)‑Methode der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)-Klasse können Sie schnell eine gesamte PowerPoint‑Präsentation in TIFF konvertieren. Die resultierenden TIFF‑Bilder entsprechen der Standard‑Foliengröße.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF konvertiert:
```js
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // Speichern Sie die Präsentation als TIFF.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```


## **Präsentation in Schwarz‑weiß‑TIFF konvertieren**

Die Methode [setBwConversionMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) in der Klasse [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) ermöglicht es Ihnen, den Algorithmus festzulegen, der beim Konvertieren einer farbigen Folie oder eines Bildes in ein Schwarz‑weiß‑TIFF verwendet wird. Beachten Sie, dass diese Einstellung nur gilt, wenn die Methode [setCompressionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) auf `CCITT4` oder `CCITT3` gesetzt ist.

Angenommen, wir haben eine Datei "sample.pptx" mit der folgenden Folie:

![Eine Präsentationsfolie](slide_black_and_white.png)

Dieser JavaScript‑Code zeigt, wie man die farbige Folie in ein Schwarz‑weiß‑TIFF konvertiert:
```js
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

Wenn Sie ein TIFF‑Bild mit bestimmten Abmessungen benötigen, können Sie Ihre gewünschten Werte mit den in [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) verfügbaren Methoden festlegen. Zum Beispiel ermöglicht die Methode [setImageSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setImageSize), die Größe des resultierenden Bildes zu definieren.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in TIFF‑Bilder mit benutzerdefinierter Größe konvertiert:
```js
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // Legen Sie den Kompressionstyp fest.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    Kompressionstypen:
        Default - Gibt das Standard-Kompressionsschema (LZW) an.
        None - Gibt an, dass keine Kompression verwendet wird.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // Die Farbtiefe hängt vom Kompressionstyp ab und kann nicht manuell festgelegt werden.

    // Legen Sie die Bild-DPI fest.
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


## **Präsentation in TIFF mit benutzerdefiniertem Bild‑Pixel‑Format konvertieren**

Durch die Verwendung der Methode [setPixelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) der Klasse [TiffOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/) können Sie das gewünschte Pixel‑Format für das resultierende TIFF‑Bild festlegen.

Dieser JavaScript‑Code zeigt, wie man eine PowerPoint‑Präsentation in ein TIFF‑Bild mit benutzerdefiniertem Pixel‑Format konvertiert:
```js
// Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei (PPT, PPTX, ODP usw.) darstellt.
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

    /// Speichern Sie die Präsentation als TIFF mit der angegebenen Bildgröße.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Tip" color="primary" %}}

Schauen Sie sich Aspose's [KOSTENLOSEN PowerPoint‑zu‑Poster‑Konverter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) an.

{{% /alert %}}

## **FAQ**

**Kann ich eine einzelne Folie anstelle der gesamten PowerPoint‑Präsentation in TIFF konvertieren?**

Ja. Aspose.Slides ermöglicht es Ihnen, einzelne Folien aus PowerPoint‑ und OpenDocument‑Präsentationen separat in TIFF‑Bilder zu konvertieren.

**Gibt es ein Limit für die Anzahl der Folien beim Konvertieren einer Präsentation in TIFF?**

Nein, Aspose.Slides legt keine Beschränkungen für die Anzahl der Folien fest. Sie können Präsentationen beliebiger Größe in das TIFF‑Format konvertieren.

**Werden PowerPoint‑Animationen und Übergangseffekte beim Konvertieren von Folien in TIFF beibehalten?**

Nein, TIFF ist ein statisches Bildformat. Daher werden Animationen und Übergangseffekte nicht beibehalten; es werden nur statische Schnappschüsse der Folien exportiert.