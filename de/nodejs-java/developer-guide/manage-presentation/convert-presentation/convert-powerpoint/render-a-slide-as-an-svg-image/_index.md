---
title: Präsentationsfolien als SVG‑Bilder in JavaScript rendern
linktitle: Folie zu SVG
type: docs
weight: 50
url: /de/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint zu SVG
- Präsentation zu SVG
- Folie zu SVG
- PPT zu SVG
- PPTX zu SVG
- SVG‑Exportoptionen
- interaktives SVG
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportieren Sie PowerPoint‑Folien als SVG‑Bilder in JavaScript und steuern Sie Schriftarten, Text, Bilder, IDs und Ereignisse mit Aspose.Slides."
---
## **Übersicht**

SVG ist ein skalierbares XML‑basiertes Bildformat, das sich gut für die Webveröffentlichung, Folienbetrachter, Barrierefreiheits‑Workflows und automatisierte Nachbearbeitung eignet. Aspose.Slides for Node.js via Java exportiert jede Folie in eine separate SVG‑Datei und ermöglicht die Steuerung, wie Text, Schriftarten, Bilder und SVG‑Elemente geschrieben werden.

Verwenden Sie [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/), wenn das exportierte SVG kompakt, browsersübergreifend vorhersagbar oder für interaktive Verwendung bereit sein muss.

## **Exportieren einer Folie als SVG**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), wählen Sie eine Folie aus und schreiben Sie sie mit [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/) in einen Stream. Das folgende Beispiel exportiert jede Folie einer Präsentation als separate SVG‑Datei.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Der Dateiname verwendet [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/), statt des Schleifenindexes. Sie können außerdem eine einzelne Form mit [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) exportieren, wenn ein Folienbetrachter oder eine Webseite nur diese Form benötigt.

## **SVG‑Ausgabe konfigurieren**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) steuert das SVG‑Rendering. Für Textfelder schließt [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) das Textfeld in den Renderbereich ein, und [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) bestimmt, ob die Frame‑Rotation angewendet wird. Setzen Sie [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) auf `true`, wenn Text ohne Ligaturen gerendert werden muss.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Text und Schriftarten steuern**

Beim Exportieren von Folien nach SVG können Sie steuern, ob Text als Text erhalten bleibt oder in Vektorgrafiken konvertiert wird und wie externe Schriftarten eingebunden oder referenziert werden. Die folgenden Optionen helfen Ihnen, visuelle Konsistenz, Textauswahl und Schriftart‑Abhängigkeiten im exportierten SVG auszubalancieren.

### **Gesamten Text vektorisieren**

Setzen Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) auf `true`, um gesamten Folientext als Vektorgrafiken zu schreiben. Das eliminiert Schriftart‑Abhängigkeiten und sorgt für ein konsistenteres visuelles Ergebnis in verschiedenen Browsern, allerdings ist der Text dann nicht mehr als SVG‑Text auswähl‑ oder durchsuchbar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Auswahl der Behandlung externer Schriftarten**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) verwendet einen [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)-Wert für Schriftarten, die extern geladen werden. Wählen Sie `AddLinksToFontFiles`, um separate Schriftdateien zu referenzieren, `Embed`, um Schriftartdaten in das SVG einzubetten, oder `Vectorize`, um nur Text, der externe Schriftarten verwendet, als Grafiken zu rendern. Prüfen Sie die Lizenzbedingungen, bevor Sie Schriftarten einbetten.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Eingebettete Bildgröße reduzieren**

Verwenden Sie [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/), um die Auflösung eingebetteter Bilder zu reduzieren, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/), um beschnittene Quellbereiche wegzulassen, und [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/), um die JPEG‑Kodierungsqualität zu steuern. Diese Einstellungen verringern die Dateigröße zulasten der Bildtreue oder behalten weniger Bilddaten.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Auflösung der Metadatei‑Rasterisierung steuern**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) legt die untere Auflösungsgrenze für die Rasterisierung von Metadateien beim SVG‑Export fest. Verwenden Sie sie, um Detailgrad und Dateigröße bei der Rasterisierung einer EMF‑ oder WMF‑Grafik auszubalancieren. Sie definiert keinen globalen DPI‑Wert für das SVG und zwingt nicht jedes Objekt auf der Folie, zu einem Rasterbild zu werden.

Laden Sie [metafile-rasterization.pptx](metafile-rasterization.pptx) herunter, das ein EMF‑Bild mit eng beabstandeten diagonalen Linien enthält. Das folgende Beispiel exportiert seine erste Folie mit drei Rasterisierungs‑Auflösungen über [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Alle anderen Export‑Einstellungen bleiben identisch, sodass die Ergebnisse vergleichbar sind.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Im Ergebnis wurde das EMF in jedem SVG als eingebettetes PNG umgewandelt. Die folgenden Messungen beziehen sich auf die bereitgestellte Präsentation; sie stellen keine allgemeine Formel zur Umrechnung von DPI in Pixelmaße dar.

| Metadatei‑Rasterisierungs‑DPI | Eingebettete PNG‑Abmessungen | SVG‑Dateigröße (Bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Der Vergleich unten zeigt denselben Bereich des eingebetteten Rasters bei identischer vergrößerter Anzeigegröße. Die diagonalen Linien zeigen bei 72 DPI sichtbare Pixelung und bei höheren Auflösungen glattere Kanten, während die SVG‑Datei größer wird. Eine Erhöhung des Werts verbessert nicht zwingend jedes Detail oder ändert jedes exportierte Bild.

![Vergrößerte Diagonal‑Linien‑Details bei 72, 150 und 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) steuert die Reduktion der Bildauflösung und kann den Effekt einer geänderten Metadatei‑Rasterisierungs‑Auflösung maskieren. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) steuert die JPEG‑Kodierungsqualität, nicht die Rasterisierungs‑Auflösung der Metadatei.

## **Stabile IDs für Formen und Text zuweisen**

Übergeben Sie einen Formatierungs‑Controller an [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), um für jede SVG‑Form [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) zu setzen. Ein Controller, der auch Text‑Spans verarbeitet, kann Werte für [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) auf Text‑`tspan`‑Elementen festlegen.

Der folgende Controller verwendet [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), das während der Lebensdauer der Form stabil ist, und einen wiederholbaren Zähler für deren Text‑Spans. Damit eignen sich die generierten IDs für die Nachbearbeitung einer unveränderten Präsentation.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG‑Ereignishandler hinzufügen**

Rufen Sie in einem Formatierungs‑Controller [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) mit einem [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/)-Wert auf, um einem exportierten Objekt einen JavaScript‑Ereignishandler hinzuzufügen. Weisen Sie den Controller mit [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) zu und definieren Sie die JavaScript‑Funktion in der Seite oder dem SVG‑Dokument, das das Ergebnis hostet.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Die Host‑Seite kann die vom Handler referenzierte JavaScript‑Funktion definieren. Das Zuweisen von IDs und Ereignishandlern ermöglicht Folienbetrachter, Barrierefreiheits‑Erweiterungen und andere interaktive SVG‑Workflows.

## **FAQ**

**Wann sollte ich [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) statt [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) verwenden?**

Verwenden Sie [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), wenn sämtlicher Text unabhängig von Schriftarten sein muss. Verwenden Sie [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/), wenn nur Text, der externe Schriftarten nutzt, in Grafiken umgewandelt werden soll.

**Was ist der beste Weg, ein SVG kleiner zu machen?**

Beginnen Sie mit der Komprimierung eingebetteter Bilder, dem Löschen beschnittener Bildbereiche und der Wahl verknüpfter Schriftdateien, wenn die Zielumgebung diese bereitstellen kann. Testen Sie das Ergebnis, da niedrigere Bildauflösung, geringere JPEG‑Qualität und vektorisierter Text jeweils unterschiedliche Qualitäts‑ und Größen‑Kompromisse mit sich bringen.

**Kann ich exportierte SVG‑Elemente nach dem Export verändern?**

Ja. Weisen Sie IDs über einen Formatierungs‑Controller zu und wählen Sie anschließend die passenden SVG‑Elemente in Ihrem Nachbearbeitungs‑Tool oder Browserskript aus.