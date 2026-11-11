---
title: Präsentationsfolien als SVG-Bilder in PHP rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG-Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in PHP und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML-basiertes Bildformat, das sich gut für Webveröffentlichungen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, über Browser hinweg vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Exportieren einer Folie als SVG**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber), anstatt des Schleifenindex. Sie können auch eine einzelne Form mit [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) steuert das Rendern von SVG. Für Textrahmen schließt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) den Textrahmen in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Beschneiden von Linienenden an Pfeilspitzen steuern**

SVG 1.1 verfügt über keine Marker‑Inset-Einstellung, um anzugeben, wo eine Linie unterhalb einer Pfeilspitze enden soll. Standardmäßig verkürzt Aspose.Slides die exportierte Linie, sodass ihre Kontur nicht durch den Marker hinausragt. Rufen Sie [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) mit `true` auf, um die Kontur bis zum ursprünglichen Endpunkt der Linie zu zeichnen. Diese Einstellung wirkt nur auf die SVG‑Ausgabe. Die Linie behält ihre Position und Länge auf der Folie bei.

Das Beispiel zeichnet Dreieck‑ und Rauten‑Pfeilspitzen auf Linien mit einer Breite von 2 bzw. 10 Punkten. Es exportiert dieselbe Folie zweimal und ändert dabei nur die Beschneidungsoption.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Der Vergleich zeigt die dreieckige Pfeilspitze auf der 10‑Punkte‑Linie. Bei aktivierter Beschneidung ist die Spitze scharf. Bei deaktivierter Beschneidung ragt die Kontur durch die schrägen Seiten des Markers und hinterlässt ein flaches Ende.

![Vergrößertes 10‑Punkte‑Dreieck mit scharfer Spitze bei aktivierter Beschneidung und flachem Ende bei deaktivierter Beschneidung](line-end-cropping.png)

In den anderen Linien des Beispiels ist die hervorragende Kontur beim 2‑Punkte‑Dreieck weniger sichtbar. Der ausgefüllte Raute deckt das Ende der Kontur bei beiden Breiten ab.

## **Text und Schriftarten steuern**

Beim Exportieren von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken umgewandelt wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftartabhängigkeiten im exportierten SVG auszubalancieren.

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftartabhängigkeiten und das visuelle Ergebnis wird über Browser hinweg konsistenter, jedoch ist der Text nicht mehr als SVG‑Text auswähl- oder durchsuchbar.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Auswahl der Handhabung externer Schriftarten**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)‑Wert für extern geladene Schriftarten. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Einbettungsgröße von Bildern reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verkleinern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Auflösung der Metadatei‑Rasterung steuern**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterisierung von Metadateien beim SVG‑Export fest. Verwenden Sie diese Einstellung, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert kein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonallinien enthält. Das folgende Beispiel exportiert seine erste Folie mit drei Rasterungsauflösungen über [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Alle anderen Export‑Einstellungen bleiben identisch, damit die Ergebnisse vergleichbar sind.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

In der Ausgabe wurde das EMF in jedem SVG zu einem eingebetteten PNG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonallinien zeigen bei 72 DPI eine sichtbare Pixelung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Wertes verbessert nicht zwangsläufig jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Liniendetails bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) steuert die Reduzierung der Bildauflösung und kann die Auswirkung einer Änderung der Metadatei‑Rasterungs‑Auflösung maskieren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) steuert die JPEG‑Kodierungsqualität, nicht die Metadatei‑Rasterungs‑Auflösung.

## **Stabile IDs für Formen und Text zuweisen**

Stellen Sie einen Formatierungs‑Callback für [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) bereit, um [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) für jede SVG‑Form festzulegen. Der Callback kann auch [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId)‑Werte für Text‑`tspan`‑Elemente setzen.

PhpJavaBridge kann keinen PHP‑Callback von `writeAsSvg` aus aufrufen, wenn es im Stream‑Modus läuft. Platzieren Sie die Formatierungslogik in einer kleinen Java‑Hilfsklasse, kompilieren Sie sie und fügen Sie die resultierende JAR‑Datei dem Bridge‑Klassenpfad hinzu. Die Hilfsklasse kann [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId) verwenden, das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für deren Text‑Spans. Siehe die [Java implementation of `StableSvgIdController`](/slides/de/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) für den Hilfscode.

Nach dem Hinzufügen der kompilierten `com.example.slides.StableSvgIdController`‑Klasse zum Bridge‑Klassenpfad, instanziieren Sie sie aus PHP und weisen sie `SVGOptions` zu:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG‑Ereignishandler hinzufügen**

In einem Formatierungs‑Callback rufen Sie [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) mit einem [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/)‑Wert auf, um einem exportierten Objekt einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Callback mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

Wie bei stabilen IDs implementieren Sie den Callback in einer Java‑Hilfsklasse, wenn PhpJavaBridge den Stream‑Modus verwendet. Die [Java implementation of `SvgEventController`](/slides/de/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) weist einer Form namens `ActionButton` eine ID und einen `OnClick`‑Handler zu. Kompilieren Sie diese Hilfsklasse, fügen Sie sie dem Bridge‑Klassenpfad als `com.example.slides.SvgEventController` hinzu und verwenden Sie sie in PHP wie folgt:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheits‑Erweiterungen und weitere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Wie lässt sich ein SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, sofern die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualität‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export bearbeiten?**

Ja. Weisen Sie IDs über einen Formatierungs‑Callback zu und wählen Sie dann die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.