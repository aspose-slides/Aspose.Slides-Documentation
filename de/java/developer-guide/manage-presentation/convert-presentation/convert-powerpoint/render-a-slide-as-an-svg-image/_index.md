---
title: Präsentationsfolien in Java als SVG-Bilder rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "Exportieren Sie PowerPoint-Folien als SVG-Bilder in Java und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML‑basiertes Bildformat, das sich gut für Web‑Publishing, Folien‑Viewer, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Steuerung, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, Browser‑übergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [ISlide.writeAsSvg](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation in eine separate SVG‑Datei.

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

Der Dateiname verwendet [ISlide.getSlideNumber](https://reference.aspose.com/slides/de/java/com.aspose.slides/islide/#getSlideNumber--), anstatt des Schleifen‑Index. Sie können auch ein einzelnes Shape mit [IShape.writeAsSvg](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) exportieren, wenn ein Folien‑Viewer oder eine Webseite nur dieses Shape benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/) steuert das Rendering von SVG. Für Textfelder fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) den Textrahmen in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) legt fest, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) auf `true`, um den gesamten Folientext als Vektorgrafiken zu schreiben. Dadurch entfallen Schriftart‑Abhängigkeiten und das visuelle Ergebnis wird über verschiedene Browser hinweg konsistenter, jedoch ist der Text nicht mehr auswähl‑ oder durchsuchbar als SVG‑Text.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-), um die Auflösung eingebetteter Bilder zu verringern, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setJpegQuality-int-), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen reduzieren die Dateigröße zulasten der Bildtreue oder der erhaltenen Bilddaten.

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

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgshapeformattingcontroller/), um für jedes SVG‑Shape [ISvgShape.setId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) festzulegen. Um zusätzlich [ISvgTSpan.setId](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) Werte für Text‑`tspan`‑Elemente zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu.

Der folgende Controller verwendet [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/de/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), das für die Lebensdauer des Shapes stabil ist, sowie einen wiederholbaren Zähler für seine Text‑Spans. Dadurch eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

## **SVG‑Ereignishandler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.setEventHandler](https://reference.aspose.com/slides/de/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) mit einem [SvgEvent](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgevent/)-Wert auf, um einem exportierten Shape einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folien‑Viewer, Barrierefrei‑Verbesserungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) statt [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/de/java/com.aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten nutzt, in Grafiken konvertiert werden soll.

**Wie mache ich ein SVG am besten kleiner?**

Beginnen Sie damit, eingebettete Bilder zu komprimieren, beschnittene Bildbereiche zu löschen und verlinkte Schriftdateien zu wählen, sofern die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisiertes Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie anschließend die entsprechenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browserskript aus.