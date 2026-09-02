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
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in PHP und steuern Sie Schriften, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares, XML-basiertes Bildformat, das sich gut für Webpublikationen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriften, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/) wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#writeAsSvg) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

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

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/de/php-java/aspose.slides/slide/#getSlideNumber), anstatt des Schleifenindex. Sie können zudem eine einzelne Form mit [Shape.writeAsSvg](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#writeAsSvg) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/) steuert das Rendering von SVG. Für Textrahmen fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setUseFrameSize) den Textrahmen in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setUseFrameRotation) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Text und Schriften steuern**

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setVectorizeText) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftabhängigkeiten und das visuelle Ergebnis wird über verschiedene Browser hinweg konsistenter, jedoch ist der Text nicht mehr auswählbar oder durchsuchbar als SVG‑Text.

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

### **Auswahl der Handhabung externer Schriften**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgexternalfontshandling/)‑Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriften verwendet, als Grafik zu rendern. Überprüfen Sie die Lizenzierung der Schriften, bevor Sie Schriften einbetten.

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

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setPicturesCompression), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setJpegQuality), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

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

## **Stabile IDs für Formen und Text zuweisen**

Stellen Sie einen Formatierungs‑Callback für [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setShapeFormattingController) bereit, um [SvgShape.setId](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgshape/#setId) für jede SVG‑Form festzulegen. Der Callback kann zudem [SvgTSpan.setId](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgtspan/#setId)‑Werte für Text‑`tspan`‑Elemente setzen.

PhpJavaBridge kann keinen PHP‑Callback von `writeAsSvg` aus aufrufen, wenn es im Stream‑Modus läuft. Platzieren Sie die Formatierungslogik in einer kleinen Java‑Hilfsklasse, kompilieren Sie sie und fügen Sie die resultierende JAR‑Datei dem Bridge‑Klassenpfad hinzu. Der Helfer kann [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/#getOfficeInteropShapeId) verwenden, das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für ihre Text‑Spans. Siehe die Java‑Implementierung von `StableSvgIdController` für den Hilfscode.

Nachdem Sie die kompilierte Klasse `com.example.slides.StableSvgIdController` dem Bridge‑Klassenpfad hinzugefügt haben, instanziieren Sie sie aus PHP und weisen Sie sie `SVGOptions` zu:

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

## **SVG-Ereignis-Handler hinzufügen**

Rufen Sie in einem Formatierungs‑Callback [SvgShape.setEventHandler](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgshape/#setEventHandler) mit einem [SvgEvent](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignis‑Handler hinzuzufügen. Weisen Sie den Callback mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setShapeFormattingController) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

Wie bei stabilen IDs, implementieren Sie den Callback in einem Java‑Helfer, wenn PhpJavaBridge den Stream‑Modus verwendet. Die Java‑Implementierung von `SvgEventController` weist einer Form namens `ActionButton` eine ID und einen `OnClick`‑Handler zu. Kompilieren Sie diesen Helfer, fügen Sie ihn dem Bridge‑Klassenpfad als `com.example.slides.SvgEventController` hinzu und verwenden Sie ihn aus PHP wie folgt:

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignis‑Handlern ermöglicht Folienbetrachter, Barrierefreiheits‑Erweiterungen und weitere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setVectorizeText) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgoptions/#setVectorizeText), wenn sämtlicher Text von Schriftarten unabhängig sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/php-java/aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriften verwendet, in Grafiken umgewandelt werden soll.

**Wie mache ich ein SVG am besten kleiner?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Entfernen beschnittener Bildbereiche und der Auswahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Callback zu und wählen Sie anschließend die entsprechenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browserskript aus.