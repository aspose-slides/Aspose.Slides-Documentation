---
title: Verwalten von Bildtransformations-Effekten in Präsentationen mit JavaScript
linktitle: Bildtransformations-Effekte
type: docs
weight: 11
url: /de/nodejs-java/image-transform-effects/
keywords:
- Bildtransformation
- Bild-Effekt
- Helligkeit
- Kontrast
- Graustufen
- Duoton
- Farbton
- HSL
- Farbersetzung
- Weichzeichnen
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Anwenden, verketten, prüfen, entfernen und verifizieren von Bildtransformations-Effekten für Bildrahmen mit Aspose.Slides für Node.js via Java."
---
## **Übersicht**

Aspose.Slides stellt Bildanpassungen als geordnete Sammlung von Bildtransformations‑Operationen dar. Für einen Bildrahmen beginnen Sie mit dem [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) des Rahmens und greifen Sie auf [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) zu. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ermöglicht das Anhängen, Durchlaufen, Inspizieren, Entfernen und Leeren von Effekten, ohne die ursprünglichen Bildbytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Workflow für Helligkeit und Kontrast, Farbtransformationen, Weichzeichnen, Transparenz, geordnete Effektketten, effektive Werte, Entfernen und PPTX‑Round‑Trip‑Verifizierung.

## **Verstehen von Effekt‑Besitz und Bildwiederverwendung**

Eine Bildressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) speichert oder referenziert die Quellbilddaten, die zur Präsentation gehören.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bildressource, während es die Bildtransformations‑Sammlung speichert.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bildfüllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher ändern Bildtransformations‑Operationen die Bytes in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) nicht. Wenn dieselbe [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) mehr als einmal an [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) und seine eigene Transformations‑Sammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bildressource wiederverwenden.

Dasselbe [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)‑Modell wird auch von anderen Bildfüllungen verwendet, etwa einer Form‑ oder Folien‑Hintergrundfüllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden gültiger Parameterbereiche und Einheiten**

Die gezeigten Methoden nutzen die folgenden semantischen Bereiche und Einheiten. Halten Sie sich an diese Bereiche, auch wenn eine bestimmte Bibliotheksversion nicht sofort jeden Werte‑Ausreißer ablehnt; das Zielformat der Präsentation kann beim Speichern oder beim Öffnen in PowerPoint ungültige Daten normalisieren, weglassen oder ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` nutzen `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` excl., in Grad; Betrag ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` excl., in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Die Ersetzungsfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius ist nicht‑negativ und wird in Punkten gemessen; `grow` ist ein Boolean, der steuert, ob unscharfer Inhalt außerhalb der ursprünglichen Grenzen erweitert werden darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nicht‑negatives Prozent. Verwenden Sie `0` bis `100` für gewöhnliche Opazitäts‑Skalierung: `0` ist vollständig transparent und `100` erhält das vorhandene Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` bis `100`, Prozent‑Opazität. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwellenwert. Werte darunter werden transparent; Werte darüber oder gleich werden undurchsichtig. |

Für feste Alpha‑Modulation ergänzen Transparenz und Opazität einander. Beispiel: 35 % Transparenz entsprechen einem Alpha‑Modulations‑Betrag von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) gibt eine [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)‑Operation zurück. Ihre Skalar‑Einstellungen werden beim Erzeugen der Operation übergeben. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) liefert berechnete, schreibgeschützte Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 % und rendert anschließend eine Vorschau, ohne das eingebettete Bild zu verändern:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der standardmäßige DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einem PPTX‑Round‑Trip editierbar bleiben müssen, verwenden Sie [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) und prüfen Sie das Ergebnis nach dem erneuten Öffnen der Datei. Der Abschnitt zu Format‑Einschränkungen erklärt diesen Unterschied genauer.

## **Farbtransformationen anwenden**

Farbeffekte können unabhängig voneinander auf unterschiedliche Bildrahmen angewendet werden, die dieselbe Bildressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Tönung, HSL‑Anpassung und Farb­ersetzung an.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) enthält zwei unabhängig editierbare Farbparameter: `color1` ordnet dunklen Pixeln zu, während `color2` hellen Pixeln zugeordnet wird. Das macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ersetzt die Farbe jedes Pixels durch eine feste Farbe, wobei das Alpha erhalten bleibt. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), das eine Quellfarbe auf eine Ziel­farbe abbildet und beide Farbformate zugänglich macht.

### **Einen Luminanz‑Schwellenwert anwenden**

Ein Luminanz‑Schwellenwert kann schwache Markierungen auf einer gescannten Seite leichter vom Hintergrund abheben. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) bewahrt Zwischen­graustufen. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) ordnet die Luminanz Schwarz oder Weiß zu, während [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) einen Schwellenwert auf die Opazität anwendet.

Der Luminanz‑Schwellenwert reicht von 0 % bis 100 %, inklusiv. Pixel unter dem Schwellenwert werden schwarz. Pixel ab dem Schwellenwert werden weiß. Erhöht man den Schwellenwert, werden mehr Graustufen schwarz, weil mehr von ihnen unter die Grenze fallen.

Laden Sie [grayscale-swatches.png](grayscale-swatches.png) in das Arbeitsverzeichnis. Jede Beschriftung gibt den ursprünglichen Grauwert auf einer Skala von 0 bis 255 an. Das Beispiel platziert das Original neben zwei Kopien und speichert den Schwellenwert jeder Kopie in der Präsentation.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Öffnen Sie die Ausgabepäsentation in PowerPoint, um die drei Rahmen zu vergleichen. Das Farbfeld mit der Beschriftung 96 hat etwa 38 % Luminanz (96 von 255). Es wird bei einem Schwellenwert von 20 % weiß und bei 60 % schwarz.

![Originale Graustufen‑Farbfelder neben den Schwarz‑Weiß‑Ergebnissen bei Luminanz‑Schwellenwerten von 20 % und 60 %](luminance-threshold.png)

## **Weichzeichnen, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) wirkt auf alle Farbkanäle, inklusive Alpha. Setzen Sie `grow` auf `true`, wenn die unscharfe Kante über die ursprünglichen Bildgrenzen hinausreichen darf.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Dieser multipliziert jeden vorhandenen Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) weist hingegen allen Pixeln einen einzigen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) wandelt Alpha basierend auf einem Schwellenwert in zwei Stufen um.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Weitere parameter‑freie Alpha‑Operationen umfassen [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), das jedes ungleich null Alpha vollständig undurchsichtig macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), das jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode hängt eine neue Operation an das Ende der Sammlung an. Der Renderer nutzt die Sammlung als geordnete Pipeline: Die Ausgabe von Operation 0 wird zur Eingabe von Operation 1 usw. Folglich kann dieselbe Menge von Operationen in unterschiedlicher Reihenfolge ein unterschiedliches Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Tönung zuerst chromatische Informationen und färbt dann das luminanz‑Ergebnis neu. Tönung gefolgt von Graustufen entfernt die Tönung wieder. Ähnlich kann ein Alpha‑Ersetzungseffekt Alpha‑Werte früherer Operationen überschreiben, während Alpha‑Modulation deren relative Unterschiede bewahrt.

Das folgende Beispiel baut eine Kette mit vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das wiedergeöffnete Ergebnis:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Weichzeichnungs‑Operationen auf getrennte Ketten beschränkt. Sie können kombiniert werden, jedoch sind nicht alle Kombinationen sinnvoll. Eine feste Farb­ersetzung entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling, Floor, Replace oder BiLevel können Alpha‑Details, die zuvor erstellt wurden, verwerfen. Bauen Sie die Kette nach der gewünschten Pixel‑Verarbeitung‑Reihenfolge auf, anstatt ihre Elemente als ungeordnete Format‑Flags zu betrachten.


<!-- visual-explanation:image-transform-effects:start -->
[![Dasselbe Bild durchläuft zuerst Graustufen dann Tönung, bzw. Tönung dann Graustufen. Die beiden finalen Graustufen‑Bilder haben unterschiedliche Tönungen.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In dieser illustrativen Aspose.Slides for .NET 26.11‑Darstellung lässt ein 220°‑Tint bei 25 % das Graustufen‑Bild unverändert. Die Anwendung desselben Tints vor dem Graustufen‑Schritt erzeugt unterschiedliche Tönungen.*
<!-- visual-explanation:image-transform-effects:end -->

## **Editierbare und effektive Werte prüfen**

Eine editierbare Operation ist das Objekt, das in [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) gespeichert ist. Je nach Effekt kann es schreibbare Mitglieder direkt exponieren. Zum Beispiel exponiert [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) schreibbare `radius`‑ und `grow`‑Werte, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) exponiert ein schreibbares `amount` und [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) exponiert ein schreibbares `threshold`. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) exponieren veränderbare [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/)‑Objekte.

Einige Operationen, darunter [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/) und [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), geben ihre Erstellungs‑Skalare nicht als schreibbare Eigenschaften frei. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, bilden jedoch keine weitere Bearbeitungsoberfläche. Das folgende Beispiel durchläuft die Kette und prüft effektive Werte, sofern die entsprechende API sie bereitstellt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Parameter‑freie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein effektives Daten‑Objekt, aber es gibt keine Skalar‑Einstellungen zum Ausgeben. Ihre Existenz und Position in der Sammlung sind die relevanten Informationen.

## **Bildtransformen entfernen oder leeren**

Verwenden Sie [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), um eine Operation anhand ihres Index zu entfernen. Da sich Indizes nach einer Entfernung verschieben, sollten Sie zunächst das Ziel finden und es nach dem Durchlaufen entfernen. Mit [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) entfernen Sie die gesamte Kette.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Das Entfernen oder Leeren von Transformierungen ändert nur die Bildformatierung. Es löscht, komprimiert oder verändert die wiederverwendete [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑Ressource nicht.

## **Präsentationsformate und Exportziele berücksichtigen**

Bildtransformen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Selbst bei PPTX besitzt nicht jede Operation gleiche Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Tönung, HSL, Weichzeichnen und gängige Alpha‑Operationen haben die größte Chance, einen PPTX‑Round‑Trip zu überstehen. Öffnen Sie die erzeugte Datei immer erneut und prüfen Sie die Sammlung, wenn die Erhaltung ein Anspruch ist.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und kein Standard‑DrawingML‑Luminanz‑Effekt. Sie kann für In‑Memory‑Renderings verwendet werden, ist jedoch nicht garantiert als editierbarer [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) nach dem Speichern und erneuten Öffnen von PPTX erhalten zu bleiben. Verwenden Sie lieber [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) für persistente Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist dem vollständigen DrawingML‑Effektmodell voraus. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, die Kette auf ein unterstütztes Teilset reduziert oder das Aussehen approximiert werden. Nutzen Sie PPT nicht als Verifizierungsformat für eine komplexe editierbare Kette.
- Das Rendern zu PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten keine editierbare [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/); Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektorexporte speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin von der Verfügbarkeit der verknüpften Ressource beim Laden der Präsentation ab.

Verschiedene Präsentations‑Clients können Randfälle unterschiedlich rendern, besonders wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Round‑Trip als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Ändern Bildtransform‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zum [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) der Bildfüllung. Die zugrundeliegenden [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden einer [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) verhindert doppelte Bilddaten, aber jeder Bildrahmen besitzt normalerweise ein separates [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) und eine eigene Transformations‑Sammlung.

**Können Farb‑, Weichzeichnungs‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Berücksichtigen Sie, was jede Operation mit dem Ergebnis der vorherigen macht, da Ersetzungs‑ und Schwellenwert‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformations‑Sammlung gespeicherte Operation dort, wo schreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transform‑Kette zu erhalten?**

Verwenden Sie PPTX und verifizieren Sie die Datei, indem Sie sie erneut öffnen. Das Legacy‑PPT‑Format kann das vollständige DrawingML‑Effektmodell nicht darstellen, und gerenderte Exportformate bewahren nur das Aussehen, nicht editierbare Transform‑Operationen.