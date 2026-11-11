---
title: Präsentationsfolien als SVG-Bilder in Java rendern
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

SVG ist ein skalierbares XML-basiertes Bildformat, das sich gut für Web-Publishing, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Nutzung bereit sein muss.

## **Eine Folie als SVG exportieren**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

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

Der Dateiname verwendet [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) anstelle des Schleifenindexes. Sie können auch eine einzelne Form mit [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG-Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) steuert das Rendern von SVG. Für Textrahmen fügt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) den Textrahmen in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken konvertiert wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftartabhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) auf `true`, um sämtlichen Folientext als Vektorgrafiken zu schreiben. Das eliminiert Schriftartabhängigkeiten und sorgt für ein konsistenteres visuelles Ergebnis über verschiedene Browser hinweg, jedoch ist der Text nicht mehr als SVG‑Text auswähl- oder durchsuchbar.

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

### **Wählen Sie, wie externe Schriftarten behandelt werden**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)‑Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzierung der Schriftarten, bevor Sie sie einbetten.

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

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) , um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zugunsten der Bildtreue oder gespeicherter Bilddaten.

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

## **Rasterisierungsauflösung von Metadateien steuern**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) legt die untere Auflösungsgrenze für das Rasterisieren von Metadateien beim SVG‑Export fest. Verwenden Sie diese Einstellung, um Details und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert keinen globalen DPI‑Wert für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonallinien enthält. Das folgende Beispiel exportiert dessen erste Folie mit drei Rasterisierungsauflösungen über [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Alle anderen Exporteinstellungen bleiben identisch, sodass die Ergebnisse verglichen werden können.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

Im Ergebnis wurde das EMF in jedem SVG zu einem eingebetteten PNG. Die folgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Rasterisierungs‑DPI der Metadatei | Abmessungen eingebetteter PNG | SVG-Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigegröße. Die Diagonallinien zeigen bei 72 DPI eine sichtbare Pixelung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Werts verbessert nicht zwangsläufig jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonallinien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) steuert die Reduzierung der Bildauflösung und kann die Auswirkung einer Änderung der Metadatei‑Rasterisierungsauflösung verdecken. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) steuert die JPEG‑Kodierungsqualität, nicht die Rasterisierungsauflösung der Metadatei.

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), um [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) für jede SVG‑Form festzulegen. Um ebenfalls Werte für [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) bei Text‑`tspan`‑Elementen zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Weisen Sie einen der Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu.

Der folgende Controller verwendet [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), das während der Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für seine Text‑Spans. Dadurch sind die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation geeignet.

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

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) mit einem [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/)‑Wert auf, um einem exportierten Objekt einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheits‑Verbesserungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Wie kann man ein SVG am besten verkleinern?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Entfernen beschnittener Bildbereiche und der Wahl verlinkter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse darstellen.

**Kann ich exportierte SVG‑Elemente nach dem Export bearbeiten?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie dann die entsprechenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.