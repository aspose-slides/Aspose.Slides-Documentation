---
title: Bild-Transformations-Effekte in Präsentationen mit JavaScript verwalten
linktitle: Bild-Transformations-Effekte
type: docs
weight: 11
url: /de/nodejs-java/image-transform-effects/
keywords:
- Bildtransformations
- Bild-Effekt
- Helligkeit
- Kontrast
- Graustufen
- Duotone
- Farbton
- HSL
- Farb-Ersetzung
- Weichzeichnen
- Transparenz
- Alpha-Effekt
- Effektkette
- PowerPoint
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Bild-Transformations-Effekte für Bildrahmen mit Aspose.Slides für Node.js über Java anwenden, verketten, inspizieren, entfernen und verifizieren."
---
## **Übersicht**

Aspose.Slides stellt Bild‑Anpassungen als geordnete Sammlung von Bild‑Transformationsoperationen dar. Für einen Bildrahmen beginnen Sie mit dem Rahmen‑[Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) und greifen auf [Picture.getImageTransform](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) zu. Die zurückgegebene [ImageTransformOperationCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) ermöglicht das Anhängen, Aufzählen, Inspizieren, Entfernen und Löschen von Effekten, ohne die ursprünglichen Bild‑Bytes neu zu schreiben.

Dieser Artikel demonstriert einen vollständigen Arbeitsablauf für Helligkeit und Kontrast, Farb‑Transformationen, Weichzeichnung, Transparenz, geordnete Effektketten, effektive Werte, Entfernung und PPTX‑Rundreise‑Verifizierung.

## **Verstehen von Effekt‑Eigentum und Bild‑Wiederverwendung**

Eine Bild‑Ressource und das Bild, das sie anzeigt, sind unterschiedliche Objekte:

- [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) speichert oder referenziert die Quell‑Bilddaten, die der Präsentation gehören.
- [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) gehört zu einer Bildfüllung und verweist auf eine Bild‑Ressource, wobei die Bild‑Transformationssammlung gespeichert wird.
- [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) ist die Folienform, die die zugehörige Bild‑Füllung, Geometrie, Zuschnitt‑Einstellungen und weitere rahmenbezogene Formatierungen besitzt.

Daher ändern Bild‑Transformationsoperationen die Bytes in [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) nicht. Wenn dieselbe [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) mehr als einmal an [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shapecollection/) übergeben wird, erhält jeder neue Bildrahmen sein eigenes [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) und seine eigene Transformationssammlung. Das Anwenden von Graustufen auf einen Rahmen macht die anderen Rahmen nicht grau, obwohl alle dieselbe eingebettete Bild‑Ressource wiederverwenden.

Dasselbe [Picture.getImageTransform](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/)‑Modell wird auch von anderen Bild‑Füllungen verwendet, etwa einer Form‑ oder Folienhintergrund‑Füllung. Die nachfolgenden Beispiele konzentrieren sich auf Bildrahmen.

## **Verwenden Sie gültige Parameterbereiche und Einheiten**

Die gezeigten Methoden verwenden die folgenden semantischen Bereiche und Einheiten. Halten Sie Werte in diesen Bereichen, selbst wenn eine bestimmte Bibliotheksversion nicht sofort jeden Wertebereich ablehnt; das Ziel‑Präsentationsformat kann während des Speicherns oder beim Öffnen der Datei in PowerPoint normalisieren, weglassen oder ungültige Daten ablehnen.

| Operation | Parameter | Gültiger Bereich und Einheit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` bis `100`, Prozent; `0` lässt die Komponente unverändert. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Keine | Keine numerischen Parameter. Alpha bleibt unverändert. |
| [addDuotoneEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Zwei Farben für dunkle bzw. helle Pixel. RGB‑ und Alpha‑Kanäle in `java.awt.Color` verwenden Werte von `0` bis `255`. |
| [addTintEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Farbton ist `0` inkl. bis `360` exklusiv, in Grad; Menge ist `-100` bis `100`, Prozent. |
| [addHSLEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Farbton ist `0` inkl. bis `360` exklusiv, in Grad; Sättigung und Luminanz sind `-100` bis `100`, Prozent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Die Ersetzungsfarbe verwendet Kanalwerte von `0` bis `255`. Vorhandene Alpha‑Werte bleiben unverändert. |
| [addBlurEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius ist nicht‑negativ und wird in Punkten gemessen; `grow` ist ein Boolescher Wert, der steuert, ob verwischter Inhalt außerhalb der ursprünglichen Grenzen ausdehnen darf. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Nicht‑negative Prozent. Verwenden Sie `0` bis `100` für übliche Deckkraft‑Skalierung: `0` ist vollständig transparent und `100` erhält das bestehende Alpha. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` bis `100`, Prozent‑Deckkraft. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` bis `100`, Prozent‑Alpha‑Schwellenwert. Werte darunter werden transparent; Werte darüber oder gleich werden opaq. |

Für feste Alpha‑Modulation gelten Transparenz und Deckkraft als komplementär. Beispielsweise entspricht 35 % Transparenz einem Alpha‑Modulationswert von 65 %.

## **Helligkeit und Kontrast anwenden**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) gibt eine [BrightnessContrast](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/brightnesscontrast/)‑Operation zurück. Ihre Skalar‑Einstellungen werden beim Erstellen der Operation übergeben. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/brightnesscontrast/) liefert berechnete Nur‑Lese‑Werte, die inspiziert oder protokolliert werden können.

Das folgende Beispiel erhöht die Helligkeit um 15 % und den Kontrast um 20 %, dann wird eine Vorschau gerendert, ohne das eingebettete Bild zu verändern:

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

[BrightnessContrast](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Bild‑Effekt‑Erweiterung und weniger portabel als der Standard‑DrawingML‑Luminanz‑Effekt. Wenn Helligkeit und Kontrast nach einer PPTX‑Rundreise editierbar bleiben müssen, verwenden Sie [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) und prüfen Sie das Ergebnis nach erneutem Öffnen der Datei. Der Abschnitt zu Format‑Beschränkungen erklärt diesen Unterschied genauer.

## **Farb‑Transformationen anwenden**

Farbeffekte können unabhängig auf verschiedene Bildrahmen angewendet werden, die dieselbe Bild‑Ressource wiederverwenden. Das folgende Beispiel erstellt fünf Rahmen und wendet Graustufen, Duotone, Farbton, HSL‑Anpassung und Farb‑Ersetzung an.

[Duotone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/duotone/) enthält zwei unabhängig editierbare Farb‑Parameter: `color1` ordnet dunklen Pixeln zu, `color2` hellen Pixeln. Dies macht es zu einem nützlichen Beispiel für einen Effekt, dessen Einstellungen komplexer sind als ein einzelner Skalarwert.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) ersetzt die Farbe jedes Pixels durch eine feste Farbe und erhält das Alpha. Es unterscheidet sich von [addColorChangeEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), das eine Quell‑Farbe auf eine Ziel‑Farbe abbildet und beide Farb‑Formate offenlegt.

## **Weichzeichnung, Transparenz und Alpha‑Effekte hinzufügen**

[addBlurEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) betrifft alle Farbkanäle, einschließlich Alpha. Setzen Sie `grow` auf `true`, wenn die verwischte Kante über die ursprünglichen Bild‑Grenzen hinausreichen kann.

Für einheitliche Transparenz verwenden Sie [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/). Es multipliziert jeden bestehenden Alpha‑Wert, sodass teilweise transparente Pixel proportional unterschiedlich bleiben. [addAlphaReplaceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) hingegen weist allen Pixeln einen einzigen Alpha‑Wert zu. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) wandelt Alpha anhand eines Schwellenwerts in zwei Stufen um.

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

Weitere parameterfreie Alpha‑Operationen umfassen [addAlphaCeilingEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), das jedes von Null verschiedene Alpha vollständig opa­k macht; [addAlphaFloorEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), das jedes Alpha unter 100 % vollständig transparent macht; und [addAlphaInverseEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), das Alpha zu `100% - alpha` ändert.

## **Eine geordnete Effektkette aufbauen**

Jede `add...Effect`‑Methode fügt am Ende der Sammlung eine neue Operation hinzu. Der Renderer nutzt die Sammlung als geordnete Pipeline: Der Ausgang von Operation 0 wird Eingang von Operation 1 usw. Daher kann dieselbe Menge von Operationen in anderer Reihenfolge ein anderes Bild erzeugen.

Beispielsweise entfernt Graustufen gefolgt von Farbton zunächst chromatische Informationen und färbt dann das Luminanz‑Ergebnis. Farbton gefolgt von Graustufen entfernt den Farbton wieder. Ebenso kann Alpha‑Ersetzung Alpha‑Werte überschreiben, die durch frühere Operationen berechnet wurden, während Alpha‑Modulation deren relative Unterschiede beibehält.

Das folgende Beispiel baut eine Kette aus vier Operationen, speichert sie als PPTX, öffnet die Präsentation erneut, prüft sowohl die Operationstypen als auch deren Reihenfolge und rendert das wiedergeöffnete Ergebnis:

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

Die Sammlung erzwingt keine Kompatibilitätsmatrix, die Farb‑, Alpha‑ und Weichzeichnungs‑Operationen auf separate Ketten beschränkt. Sie können kombiniert werden, jedoch sind Kombinationen nicht immer sinnvoll. Eine feste Farb‑Ersetzung entfernt RGB‑Variationen, die frühere Farbeffekte erzeugt haben; Graustufen nach Duotone entfernen die beiden ausgewählten Farben; und Alpha‑Ceiling,‑Floor,‑Replacement oder‑BiLevel‑Operationen können Alpha‑Details verwerfen, die zuvor erzeugt wurden. Bauen Sie die Kette gemäß der gewünschten Pixel‑Verarbeitungsreihenfolge auf, anstatt ihre Elemente als ungeordnete Format‑Flags zu behandeln.

## **Editierbare und effektive Werte inspizieren**

Eine editierbare Operation ist das Objekt, das in [Picture.getImageTransform](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) gespeichert ist. Je nach Effekt kann sie beschreibbare Mitglieder direkt freigeben. Zum Beispiel gibt [Blur](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/blur/) die beschreibbaren Werte `radius` und `grow` frei, [AlphaModulateFixed](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/alphamodulatefixed/) gibt ein beschreibbares `amount` frei, und [AlphaBiLevel](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/alphabilevel/) gibt ein beschreibbares `threshold` frei. Farbeffekte wie [Duotone](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/duotone/) geben mutable [ColorFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/colorformat/)‑Objekte frei.

Einige Operationen, darunter [BrightnessContrast](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/tint/) und [AlphaReplace](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/alphareplace/), stellen ihre Erstellungs‑Skalare nicht als beschreibbare Eigenschaften zur Verfügung. Um diese Einstellungen zu ändern, entfernen Sie die Operation und fügen Sie an der gewünschten Position eine Ersatz‑Operation hinzu.

Effektive Daten, die von `getEffective()` zurückgegeben werden, sind berechnet und schreibgeschützt. Sie sind nützlich, um themenabhängige Farben aufzulösen und die normalisierten Werte zu lesen, die der Renderer verwendet, bilden jedoch keine weitere Bearbeitungsoberfläche. Das folgende Beispiel durchläuft die Kette und inspiziert effektive Werte, sofern die entsprechende API sie bereitstellt:

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

Parameterfreie Effekte wie Graustufen, Alpha‑Ceiling und Alpha‑Inverse besitzen ebenfalls ein effektives Datenobjekt, jedoch gibt es keine skalaren Einstellungen zu drucken. Ihre Präsenz und Position in der Sammlung sind die wesentlichen Informationen.

## **Bild‑Transformationen entfernen oder löschen**

Verwenden Sie [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), um eine Operation anhand ihres Index zu entfernen. Da Indizes nach einer Entfernung verschoben werden, suchen Sie zuerst das Ziel und entfernen es nach dem Durchlaufen. Nutzen Sie [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/), um die gesamte Kette zu entfernen.

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

Das Entfernen oder Löschen von Transformationen ändert nur die Bild‑Formatierung. Es löscht, komprimiert oder verändert nicht die wiederverwendete [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Ressource.

## **Präsentationsformate und Exportziele berücksichtigen**

Bild‑Transformationen stammen aus DrawingML, daher ist PPTX das bevorzugte editierbare Format für Effektketten. Auch bei PPTX hat jedoch nicht jede Operation identische Portabilität:

- Standard‑DrawingML‑Operationen wie Luminanz, Graustufen, Duotone, Farbton, HSL, Weichzeichnung und gängige Alpha‑Operationen haben die beste Chance, einen PPTX‑Rundtrip zu überstehen. Öffnen Sie die erzeugte Datei stets erneut und prüfen Sie die Sammlung, wenn die Erhaltung erforderlich ist.
- [BrightnessContrast](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/brightnesscontrast/) ist eine Office‑2010‑Erweiterung und nicht der Standard‑DrawingML‑Luminanz‑Effekt. Sie kann für In‑Memory‑Renderings genutzt werden, ist jedoch nicht garantiert, nach dem Speichern und erneuten Öffnen von PPTX editierbar zu bleiben. Verwenden Sie [addLuminanceEffect](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/) für dauerhafte Helligkeits‑ und Kontrast‑Anpassungen.
- Das binäre PPT‑Format ist älter als das vollständige DrawingML‑Effekt‑Modell. Beim Speichern nach PPT können nicht unterstützte Operationen weggelassen, eine Kette auf ein unterstütztes Teil‑Set reduziert oder das Aussehen approximiert werden. Nutzen Sie PPT nicht als Verifizierungsformat für komplexe editierbare Ketten.
- Das Rendern nach PNG, JPEG, TIFF, PDF, SVG, HTML oder anderen visuellen Ausgaben wendet die unterstützte Kette auf das gerenderte Erscheinungsbild an. Diese Ausgaben enthalten kein editierbares [ImageTransformOperationCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagetransformoperationcollection/); Rasterformate flachen das Ergebnis in Pixel ab, und Dokument‑/Vektor‑Exporte speichern ihre eigene Rendering‑Darstellung.
- Effekte machen ein verknüpftes Bild nicht eigenständig. Das Rendern eines verknüpften Bildes hängt weiterhin davon ab, dass die verknüpfte Ressource beim Laden der Präsentation verfügbar ist.

Verschiedene Präsentations‑Viewer können Randfälle unterschiedlich rendern, insbesondere wenn mehrere Alpha‑ oder Farb‑Quantisierungs‑Operationen kombiniert werden. Für kritische Ausgaben testen Sie sowohl den editierbaren Rundtrip als auch das endgültige Exportformat mit derselben Aspose.Slides‑Version, die in der Produktion eingesetzt wird.

## **FAQ**

**Ändern Bild‑Transformations‑Effekte die eingebetteten Bilddaten?**

Nein. Die Operationen gehören zu dem [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) der Bild‑Füllung. Die zugrunde liegenden [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Bytes bleiben unverändert.

**Teilen zwei Bildrahmen, die dasselbe Bild wiederverwenden, ihre Effekte?**

Nein. Das Wiederverwenden einer [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) vermeidet doppelte Bilddaten, aber jeder Bildrahmen besitzt in der Regel ein separates [Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/picture/) und eine eigene Bild‑Transformationssammlung.

**Können Farb‑, Weichzeichnungs‑ und Alpha‑Effekte kombiniert werden?**

Ja. Die Sammlung akzeptiert sie in einer geordneten Kette. Beachten Sie, was jede Operation mit dem Ausgang der vorherigen macht, da Ersetzungs‑ und Schwellenwert‑Operationen frühere Farb‑ oder Alpha‑Details verwerfen können.

**Warum sind effektive Werte schreibgeschützt?**

Effektive Daten repräsentieren berechnete Werte, die für das Rendering verwendet werden, einschließlich aufgelöster Farben. Bearbeiten Sie die in der Transformationssammlung gespeicherte Operation, wo beschreibbare Mitglieder existieren; andernfalls entfernen Sie sie und fügen Sie eine Ersatz‑Operation mit neuen Erstellungs‑Parametern hinzu.

**Welches Format sollte ich verwenden, um eine Transformationskette zu erhalten?**

Verwenden Sie PPTX und überprüfen Sie die Datei, indem Sie sie erneut öffnen. Das alte PPT‑Format kann das vollständige DrawingML‑Effekt‑Modell nicht darstellen, und gerenderte Exportformate bewahren nur das Aussehen, nicht editierbare Transformations‑Operationen.