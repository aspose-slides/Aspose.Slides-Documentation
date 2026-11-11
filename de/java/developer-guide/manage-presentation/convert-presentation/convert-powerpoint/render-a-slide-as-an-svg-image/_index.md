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

SVG ist ein skalierbares XML‑basiertes Bildformat, das sich gut für Webpublikationen, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Kontrolle darüber, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, browserübergreifend vorhersehbar oder für interaktive Verwendung bereit sein muss.

## **Folie als SVG exportieren**

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

Der Dateiname verwendet [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) statt des Schleifenindexes. Sie können auch eine einzelne Form mit [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) steuert das SVG‑Rendering. Für Textrahmen berücksichtigt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) den Textrahmen im Renderbereich, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) bestimmt, ob die Rahmenrotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

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

## **Linienende‑Zuschneiden bei Pfeilspitzen steuern**

SVG 1.1 bietet keine Markereinsetzeinstellung, um zu bestimmen, wo eine Linie unterhalb einer Pfeilspitze enden soll. Standardmäßig verkürzt Aspose.Slides die exportierte Linie, sodass ihr Strich nicht durch den Marker hinausragt. Rufen Sie [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) mit `true` auf, um den Strich bis zum ursprünglichen Endpunkt der Linie zu zeichnen. Diese Einstellung wirkt sich nur auf die SVG‑Ausgabe aus. Die Linie behält Position und Länge auf der Folie bei.

Das Beispiel zeichnet Dreieck‑ und Rautenspitzpfeile auf Linien mit 2 und 10 Punkt Breite. Es exportiert dieselbe Folie zweimal und ändert nur die Zuschneidee‑Option.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Der Vergleich zeigt die dreieckige Pfeilspitze auf der 10‑Punkt‑Linie. Bei aktiviertem Zuschneiden ist die Spitze spitz. Bei deaktiviertem Zuschneiden ragt der Strich durch die schrägen Seiten des Markers und erzeugt ein flaches Ende.

![Vergrößertes 10‑Punkt‑Dreieck mit einer spitzen Spitze bei aktiviertem Zuschneiden und einer flachen Spitze bei deaktiviertem Zuschneiden](line-end-cropping.png)

In den anderen Linien des Beispiels ist der hervortretende Strich bei dem 2‑Punkt‑Dreieck weniger sichtbar. Der ausgefüllte Raute deckt das Strichende bei beiden Breiten ab.

## **Text und Schriftarten steuern**

Beim Export von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken konvertiert wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftart‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Alle Texte vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) auf `true`, um den gesamten Folientext als Vektorgrafik zu schreiben. Das eliminiert Schriftart‑Abhängigkeiten und sorgt für ein konsistenteres visuelles Ergebnis über Browser hinweg, jedoch ist der Text nicht mehr auswähl‑ oder durchsuchbar als SVG‑Text.

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

### **Auswahl, wie externe Schriftarten behandelt werden**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)-Wert für extern geladene Schriftarten. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten nutzt, als Grafik zu rendern. Prüfen Sie die Lizenzbedingungen, bevor Sie Schriftarten einbetten.

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

## **Eingebettete Bildgröße reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zulasten der Bildtreue oder der erhaltenen Bilddaten.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) legt die untere Auflösungsschranke für die Rasterisierung von Metadateien beim SVG‑Export fest. Nutzen Sie sie, um Detailgrad und Dateigröße auszubalancieren, wenn ein EMF‑ oder WMF‑Bild rasterisiert wird. Sie definiert kein globales DPI für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten Diagonal‑Linien enthält. Das folgende Beispiel exportiert die erste Folie mit drei Rasterisierungsauflösungen über [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Alle übrigen Export‑Einstellungen bleiben identisch, damit die Ergebnisse vergleichbar sind.

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

In der Ausgabe wurde das EMF in jedem SVG als eingebettetes PNG übernommen. Die nachfolgenden Messwerte beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei gleicher vergrößerter Anzeigengröße. Bei 72 DPI sind die Diagonal‑Linien pixelig sichtbar, bei höheren Auflösungen sind die Kanten glatter, während die SVG‑Datei wächst. Eine Erhöhung des Wertes verbessert nicht zwangsläufig jedes Detail oder verändert jedes exportierte Bild.

![Vergrößertes Diagonal‑Linien‑Detail bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) steuert die Reduktion der Bildauflösung und kann die Auswirkung einer geänderten Metadatei‑Rasterisierungs‑Auflösung maskieren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) steuert die JPEG‑Kodierungsqualität, nicht die Rasterisierungs‑Auflösung der Metadatei.

## **Stabile IDs für Formen und Text zuweisen**

Verwenden Sie [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), um für jede SVG‑Form [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) zu setzen. Um ebenfalls [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-)‑Werte für Text‑`tspan`‑Elemente zu setzen, implementieren Sie [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Ordnen Sie einen der Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu.

Der folgende Controller verwendet [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), das für die Lebensdauer der Form stabil ist, sowie einen wiederholbaren Zähler für deren Text‑Spans. So eignen sich die erzeugten IDs für die Nachbearbeitung einer unveränderten Präsentation.

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

## **SVG‑Ereignis‑Handler hinzufügen**

In einem [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) rufen Sie [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) mit einem [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/)‑Wert auf, um einem exportierten Shape einen JavaScript‑Ereignis‑Handler hinzuzufügen. Ordnen Sie den Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) zu und definieren Sie die JavaScript‑Funktion in der Seite oder im SVG‑Dokument, das das Ergebnis hostet.

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

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuordnen von IDs und Ereignis‑Handlern ermöglicht Folienbetrachter, Barrierefreiheits‑Erweiterungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) anstelle von [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Nutzen Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten verwendet, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG kleiner zu machen?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und dem Verwenden verlinkter Schriftdateien, wenn die Zielumgebung sie ausliefern kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größenkompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export noch ändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie dann die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browser‑Skript aus.