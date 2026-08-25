---
title: Hantera bildtransformeringseffekter i presentationer med JavaScript
linktitle: Bildtransformeringseffekter
type: docs
weight: 11
url: /sv/nodejs-java/image-transform-effects/
keywords:
- bildtransformering
- bildeffekt
- ljusstyrka
- kontrast
- gråskala
- duoton
- nyans
- HSL
- färgersättning
- oskärpa
- transparens
- alfateffekt
- effektkedja
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Applicera, kedja, inspektera, ta bort och verifiera bildtransformeringseffekter för bildramar med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides representerar bildjusteringar som en ordnad samling av bildtransformationsoperationer. För en bildram, börja med ramens [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) och gå till [Picture.getImageTransform](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/). Den returnerade [ImageTransformOperationCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) låter dig lägga till, enumerera, inspektera, ta bort och rensa effekter utan att skriva om de ursprungliga bildbytena.

Den här artikeln visar ett komplett arbetsflöde för ljusstyrka och kontrast, färgtransformeringar, oskärpa, transparens, ordnade effektkedjor, effektiva värden, borttagning och PPTX‑rundreses‑verifiering.

## **Förstå effektägarskap och bildåteranvändning**

En bildresurs och bilden som visar den är olika objekt:

- [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) lagrar eller refererar källbilddata som tillhör presentationen.
- [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) tillhör en bildfyllning och refererar en bildresurs samtidigt som den lagrar bildtransformationssamlingen.
- [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) är bildformen på sliden som äger den relevanta bildfyllningen, geometri, beskärningsinställningar och annan formateringsinformation på ramnivå.

Därför modifierar bildtransformationsoperationer inte bytena i [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/). När samma [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) skickas till [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/) mer än en gång, får varje ny bildram sin egen [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) och sin egen transformationssamling. Att applicera gråskala på en ram gör inte de andra ramarna gråskalade, även om alla återanvänder samma inbäddade bildresurs.

Samma modell för [Picture.getImageTransform](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) används också av andra bildfyllningar, såsom en form eller bildbakgrund. Exemplen nedan fokuserar på bildramar.

## **Använd giltiga parameterintervall och enheter**

De demonstrerade metoderna använder följande semantiska intervall och enheter. Håll värden inom dessa intervall även om en viss biblioteksversion inte avvisar varje värde utanför intervallet omedelbart; målpresentationens format kan normalisera, utelämna eller avvisa ogiltiga data vid sparande eller när PowerPoint öppnar filen.

| Operation | Parametrar | Giltigt intervall och enhet |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` till `100`, procent; `0` lämnar komponenten oförändrad. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Ingen | Inga numeriska parametrar. Alfa är oförändrad. |
| [addDuotoneEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Två färger för mörka och ljusa pixlar. RGB‑ och alfakanaler i `java.awt.Color` använder `0` till `255`. |
| [addTintEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Nyansen är `0` inklusiv till `360` exklusiv, i grader; mängden är `-100` till `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Nyansen är `0` inklusiv till `360` exklusiv, i grader; mättnad och luminans är `-100` till `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | Ersättningsfärgen använder kanalvärden från `0` till `255`. Existerande alfavärden förblir oförändrade. |
| [addBlurEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radien är icke‑negativ och mäts i punkter; `grow` är en Boolean som styr om suddigt innehåll får sträcka sig utanför den ursprungliga gränsen. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Icke‑negativ procent. Använd `0` till `100` för vanlig opacitetsskalning: `0` är helt transparent och `100` bevarar den befintliga alfan. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` till `100`, procent opacitet. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` till `100`, procent alfatröskel. Värden under blir transparenta; värden på eller över blir opaka. |

För fast alfamodulering är transparens och opacitet komplementära. Till exempel motsvarar 35 % transparens en alfamoduleringsmängd på 65 %.

## **Tillämpa ljusstyrka och kontrast**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) returnerar en [BrightnessContrast](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/)‑operation. Dess skalära inställningar ges när operationen skapas. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/) returnerar beräknade skrivskyddade värden som kan inspekteras eller loggas.

Följande exempel ökar ljusstyrkan med 15 % och kontrasten med 20 % och renderar sedan en förhandsgranskning utan att modifiera den inbäddade bilden:

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

[BrightnessContrast](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/) är en Office 2010‑effektutökning och är mindre portabel än den standardiserade DrawingML‑luminanseffekten. När ljusstyrka och kontrast måste förbli redigerbara efter en PPTX‑rundresa, använd [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) och verifiera resultatet efter att filen öppnats igen. Avsnittet om formatbegränsningar förklarar detta mer i detalj.

## **Tillämpa färgtransformeringar**

Färgeffekter kan appliceras oberoende på olika bildramar som återanvänder samma bildresurs. Följande exempel skapar fem ramar och applicerar gråskala, duotone, nyans, HSL‑justering och färgbyte.

[Duotone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/duotone/) innehåller två oberoende redigerbara färgparametrar: `color1` mappar mörka pixlar, medan `color2` mappar ljusa pixlar. Detta gör den till ett bra exempel på en effekt vars inställningar är mer komplexa än ett enkelt skalärt värde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) ersätter varje pixels färg med en fast färg samtidigt som alfavärdet bevaras. Det skiljer sig från [addColorChangeEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/), som mappar en källfärg till en annan och exponerar både käll‑ och målformat för färger.

## **Lägg till oskärpa, transparens och alfa‑effekter**

[addBlurEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) påverkar alla färgkanaler, inklusive alfa. Sätt `grow` till `true` när den suddade kanten kan sträcka sig utanför den ursprungliga bildramens gränser.

För enhetlig transparens, använd [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/). Den multiplicerar varje befintligt alfavärde, så delvis transparenta pixlar förblir proportionellt olika. [addAlphaReplaceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) tilldelar istället ett alfavärde till alla pixlar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) konverterar alfa till två nivåer baserat på en tröskel.

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

Andra alfa‑operationer utan parametrar inkluderar [addAlphaCeilingEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/), som gör varje icke‑noll alfa helt ogenomskinlig; [addAlphaFloorEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/), som gör varje alfa under 100 % helt transparent; och [addAlphaInverseEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/), som förändrar alfan till `100% - alpha`.

## **Bygg en ordnad effektkedja**

Varje `add...Effect`‑metod lägger till en ny operation i slutet av samlingen. Renderaren använder samlingen som en ordnad pipeline: utdata från operation 0 blir indata till operation 1 och så vidare. Därför kan samma operationer i annan ordning ge ett annat resultat.

Till exempel, gråskala följt av nyans tar först bort kromatisk information och färglägger sedan luminansresultatet. Nyans följt av gråskala tar bort nyansen igen. På liknande sätt kan alfa‑ersättning överskrida alfa‑värden beräknade av tidigare operationer, medan alfa‑modulering bevarar deras relativa skillnader.

Följande exempel bygger en kedja med fyra operationer, sparar den som PPTX, öppnar presentationen igen, kontrollerar både operationstyper och deras ordning samt renderar det återöppnade resultatet:

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

Samlingen påtvingar inte en kompatibilitetsmatris som begränsar färg‑, alfa‑ och oskärpeoperationer till separata kedjor. De kan kombineras, men kombinationerna är inte alltid meningsfulla. En fast färgbyte tar bort RGB‑variation som skapats av tidigare färgeffekter; gråskala efter duotone tar bort de två valda färgerna; och alfa‑tak, golv, ersättning eller tvånivå‑operationer kan förlora alfa‑detalj som skapats tidigare. Bygg kedjan enligt den önskade pixel‑bearbetningssekvensen snarare än att betrakta dess element som oordnade formateringsflaggor.

## **Inspektera redigerbara och effektiva värden**

En redigerbar operation är objektet lagrat i [Picture.getImageTransform](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/). Beroende på effekten kan den exponera skrivbara medlemmar direkt. Till exempel, [Blur](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/blur/) exponerar skrivbara `radius`‑ och `grow`‑värden, [AlphaModulateFixed](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/alphamodulatefixed/) exponerar en skrivbar `amount`, och [AlphaBiLevel](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/alphabilevel/) exponerar en skrivbar `threshold`. Färgeffekter såsom [Duotone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/duotone/) exponerar muterbara [ColorFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/colorformat/)-objekt.

Vissa operationer, inklusive [BrightnessContrast](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/tint/) och [AlphaReplace](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/alphareplace/), exponerar inte sina skapande‑skalärer som skrivbara egenskaper. För att ändra dessa inställningar, ta bort operationen och lägg till en ersättare på den önskade positionen.

Effektiva data som returneras av `getEffective()` är beräknade och skrivskyddade. De är användbara för att lösa temaberoende färger och läsa de normaliserade värden som renderaren använder, men de är inte en annan redigeringsyta. Följande exempel enumererar kedjan och inspekterar effektiva värden där motsvarande API tillhandahåller dem:

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

Parameterfria effekter såsom gråskala, alfa‑tak och alfa‑invers har fortfarande ett effekt‑datatobjekt, men det finns inga skalära inställningar att skriva ut. Deras närvaro och position i samlingen är den viktiga informationen.

## **Ta bort eller rensa bildtransformeringar**

Använd [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) för att ta bort en operation efter index. Eftersom index skiftar efter borttagning, sök först efter målet och ta sedan bort det efter enumeration. Använd [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) för att ta bort hela kedjan.

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

Att ta bort eller rensa transformationer ändrar bara bildformateringen. Det raderar inte, recomprimerar eller på annat sätt ändrar den återanvända [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑resursen.

## **Överväg presentationsformat och exporteringsmål**

Bildtransformeringar har sitt ursprung i DrawingML, så PPTX är det föredragna redigerbara formatet för effektkedjor. Även med PPTX har inte varje operation identisk portabilitet:

- Standard‑DrawingML‑operationer såsom luminans, gråskala, duotone, nyans, HSL, oskärpa och vanliga alfa‑operationer har bäst chans att överleva en PPTX‑rundresa. Öppna alltid den genererade filen igen och inspektera samlingen när bevarande är ett krav.
- [BrightnessContrast](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/) är en Office 2010‑utökning snarare än standard‑DrawingML‑luminansoperation. Den kan användas för rendering i minnet, men den garanteras inte att förbli en redigerbar [BrightnessContrast](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/brightnesscontrast/)‑operation efter sparande och återöppning av PPTX. Föredra [addLuminanceEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/) för beständiga ljusstyrke‑ och kontrastjusteringar.
- Det binära PPT‑formatet föregick den fullständiga DrawingML‑effektmodellen. Sparning till PPT kan utelämna icke‑stödda operationer, reducera en kedja till ett stöd­format subset eller approximera utseendet. Använd inte PPT som verifieringsformat för en komplex redigerbar kedja.
- Rendering till PNG, JPEG, TIFF, PDF, SVG, HTML eller andra visuella utdata applicerar den stödjade kedjan på det renderade utseendet. Dessa utdata innehåller inte en redigerbar [ImageTransformOperationCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagetransformoperationcollection/); rasterformat plattar ut resultatet till pixlar och dokument‑/vektor‑exporter lagrar sin egen renderingsrepresentation.
- Effekter gör inte en länkat bild självständig. Rendering av en länkat bild beror fortfarande på att den länkade resursen är tillgänglig när presentationen laddas.

Olika presentationskonsumenter kan rendera kantfall olika, särskilt när flera alfa‑ eller färg‑kvantiseringsoperationer kombineras. För kritisk output, testa både den redigerbara rundresan och det slutgiltiga exportformatet med samma Aspose.Slides‑version som används i produktion.

## **FAQ**

**Ändrar bildtransformeringseffekter den inbäddade bilddata?**

Nej. Operationerna tillhör det [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) som används av bildfyllningen. De underliggande [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑bytena förblir oförändrade.

**Kommer två bildramar som återanvänder samma bild att dela sina effekter?**

Nej. Återanvändning av ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) undviker duplicerad bilddata, men varje bildram har normalt en separat [Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) och en separat bildtransformationssamling.

**Kan färg‑, oskärpa‑ och alfa‑effekter kombineras?**

Ja. Samlingen accepterar dem i en ordnad kedja. Överväg vad varje operation gör med utdata från den föregående eftersom ersättnings‑ och tröskeloperationer kan förlora tidigare färg‑ eller alfadetaljer.

**Varför är effektiva värden skrivskyddade?**

Effektiva data representerar beräknade värden som används för rendering, inklusive lösta färger. Redigera den operation som lagras i transform‑samlingen där skrivbara medlemmar finns; annars ta bort den och lägg till en ersättare med nya skapande‑parametrar.

**Vilket format bör jag använda för att bevara en transform‑kedja?**

Använd PPTX och verifiera filen genom att öppna den igen. Äldre PPT kan inte representera hela DrawingML‑effektmodellen, och renderade exportformat bevarar bara utseendet snarare än redigerbara transform‑operationer.