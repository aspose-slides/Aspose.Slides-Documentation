---
title: Präsentationsfolien als SVG-Bilder auf Android rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑Folien als SVG‑Bilder auf Android und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML-basiertes Bildformat, das sich gut für Web-Veröffentlichungen, Folien-Betrachter, Barrierefrei-Arbeitsabläufe und automatisierte Nachbearbeitung eignet. Aspose.Slides für Android via Java exportiert jede Folie in eine separate SVG-Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG-Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, in verschiedenen Browsern vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [ISlide.writeAsSvg](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG-Datei.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Der Dateiname verwendet [ISlide.getSlideNumber](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/islide/#getSlideNumber--), anstatt des Schleifenindex. Sie können außerdem ein einzelnes Shape mit [IShape.writeAsSvg](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) exportieren, wenn ein Folien-Betrachter oder eine Webseite nur dieses Shape benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/) steuert das Rendern von SVG. Für Textrahmen fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) den Textrahmen in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Text und Schriftarten steuern**

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftartabhängigkeiten und das visuelle Ergebnis ist in verschiedenen Browsern konsistenter, jedoch ist der Text nicht mehr als SVG-Text auswählbar oder durchsuchbar.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/), um separate Schriftdateien zu referenzieren, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/), um Schriftartdaten in das SVG einzubetten, oder [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/), um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Überprüfen Sie die Schriftlizenzierung, bevor Sie Schriftarten einbetten.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Größe eingebetteter Bilder reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), um zugeschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-), um die JPEG-Kodierungsqualität zu steuern. Diese Einstellungen verkleinern die Dateigröße auf Kosten der Bildtreue oder der erhaltenen Bilddaten.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Stabile IDs für Shapes und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), um für jedes SVG-Shape [ISvgShape.setId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) festzulegen. Um ebenfalls [ISvgTSpan.setId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) Werte auf Text-`tspan`-Elementen zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu.

Der folgende Controller verwendet [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), das für die Lebensdauer des Shapes stabil ist, und einen wiederholbaren Zähler für dessen Text-Spans. Dadurch eignen sich die generierten IDs für die Nachbearbeitung einer unveränderten Präsentation.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **SVG-Ereignis-Handler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.setEventHandler](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) mit einem [SvgEvent](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgevent/)-Wert auf, um einem exportierten Shape einen JavaScript-Ereignis-Handler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu und definieren Sie die JavaScript-Funktion in der Seite oder im SVG-Dokument, das das Ergebnis hostet.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Die Host-Seite kann die vom Handler referenzierte JavaScript-Funktion definieren. Das Zuweisen von IDs und Ereignis-Handlern ermöglicht Folien-Betrachter, Barrierefrei-Verbesserungen und weitere interaktive SVG-Arbeitsabläufe.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Wie kann ich ein SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Entfernen zugeschnittener Bildbereiche und der Auswahl verlinkter Schriftdateien, sofern die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da eine niedrigere Bildauflösung, geringere JPEG-Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts- und Größenkompromisse darstellen.

**Kann ich exportierte SVG-Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs-Controller zu und wählen Sie anschließend die passenden SVG-Elemente in Ihrem Nachbearbeitungs-Tool oder Browserskript aus.