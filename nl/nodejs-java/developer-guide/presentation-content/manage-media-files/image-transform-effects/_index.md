---
title: Beheer afbeeldingstransformatie‑effecten in presentaties met JavaScript
linktitle: Afbeeldingstransformatie‑effecten
type: docs
weight: 11
url: /nl/nodejs-java/image-transform-effects/
keywords:
- afbeeldingstransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijswaarden
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alfa‑effect
- effectketen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas afbeeldingstransformatie‑effecten toe, combineer, inspecteer, verwijder en verifieer ze voor afbeelding‑kaders met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides stelt afbeeldingsaanpassingen voor als een geordende verzameling van beeldtransformatie‑operaties. Voor een afbeelding‑kader begin je met de [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) van het kader en roep je [Picture.getImageTransform](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) aan. De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) laat je effecten toevoegen, opsommen, inspecteren, verwijderen en opruimen zonder de oorspronkelijke afbeeldingsbytes opnieuw te schrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX round‑trip verificatie.

## **Begrijp eigendom van effecten en hergebruik van afbeeldingen**

Een afbeelding‑resource en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) slaat de bronafbeeldingsgegevens op of verwijst ernaar en behoort tot de presentatie.
- [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) maakt deel uit van een opvul‑afbeelding en verwijst naar een afbeelding‑resource terwijl het de beeldtransformatie‑verzameling opslaat.
- [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is de dia‑vorm die de bijbehorende opvul‑afbeelding, geometrie, uitsnijdingsinstellingen en andere formattering op kadriveau bezit.

Daarom wijzigen beeldtransformatie‑operaties de bytes in [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) niet. Wanneer dezelfde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) meer dan één keer aan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/) wordt doorgegeven, krijgt elk nieuw afbeelding‑kader zijn eigen [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) en zijn eigen transformatie‑verzameling. Het toepassen van grijswaarden op één kader maakt de andere kaders niet grijs, zelfs niet wanneer ze allemaal dezelfde ingesloten afbeelding‑resource hergebruiken.

Hetzelfde [Picture.getImageTransform](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) model wordt ook gebruikt door andere opvul‑afbeeldingen, zoals een vorm‑ of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeelding‑kaders.

## **Gebruik geldige parameter‑bereiken en eenheden**

De getoonde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, zelfs als een bepaalde bibliotheekversie niet onmiddellijk elke out‑of‑range waarde weigert; het doel‑presentatieformaat kan gegevens normaliseren, weglaten of ongeldige gegevens weigeren tijdens het opslaan of wanneer PowerPoint het bestand opent.

| Operatie | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat de component ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Geen | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB‑ en alfa‑kanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; hoeveelheid (`amount`) is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Tint (`hue`) is `0` inclusief tot `360` exclusief, in graden; verzadiging en luminantie zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | De vervangingskleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfa‑waarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Straal is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd materiaal buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Niet‑negatief percentage. Gebruik `0` tot `100` voor gewone opaciteits‑schaling: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` tot `100`, procent opaciteit. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` tot `100`, procent alfa‑drempel. Waarden eronder worden transparant; waarden gelijk aan of hoger worden ondoorzichtig. |

Voor vaste alfa‑modulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfa‑modulatie‑bedrag van 65 %.

## **Pas helderheid en contrast toe**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) retourneert een [BrightnessContrast](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/) operatie. De scalaire instellingen worden meegegeven wanneer de operatie wordt aangemaakt. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/) geeft berekende alleen‑lezen waarden terug die kunnen worden geïnspecteerd of gelogd.

Het volgende voorbeeld verhoogt de helderheid met 15 % en het contrast met 20 %, waarna een voorbeeld wordt gerenderd zonder de ingesloten afbeelding te wijzigen:

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

[BrightnessContrast](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/) is een Office 2010 afbeelding‑effect extensie en is minder draagbaar dan het standaard DrawingML luminantie‑effect. Wanneer helderheid en contrast na een PPTX‑round‑trip bewerkbaar moeten blijven, gebruik [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) en verifieer het resultaat na het heropenen van het bestand. De sectie over format‑beperkingen legt dit onderscheid uitgebreider uit.

## **Pas kleurovergangen toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeelding‑kaders die dezelfde afbeelding‑resource hergebruiken. Het volgende voorbeeld maakt vijf kaders en past grijswaarden, duotone, tint, HSL‑aanpassing en kleur‑vervanging toe.

[Duotone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` wijst donkere pixels toe, terwijl `color2` lichte pixels wijst. Dit maakt het een nuttig voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalaire waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) vervangt de kleur van elke pixel door één vaste kleur terwijl alfa behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/), dat één bronkleur naar een andere afbeeldt en zowel bron‑ als doelkleurformaten blootlegt.

## **Voeg vervaging, transparantie en alfa‑effecten toe**

[addBlurEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitsteken.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/). Het vermenigvuldigt elke bestaande alfadeelwaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) wijst in plaats daarvan één alfadeelwaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) converteert alfa naar twee niveaus op basis van een drempel.

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

Andere alfa‑operaties zonder parameters omvatten [addAlphaCeilingEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/), die elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/), die elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/), die alfa wijzigt naar `100% - alpha`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe operatie toe aan het einde van de verzameling. De renderer gebruikt de verzameling als een geordende pijplijn: de uitvoer van operatie 0 wordt de invoer van operatie 1, enzovoort. Daardoor kan dezelfde reeks operaties in een andere volgorde een ander beeld opleveren.

Zo verwijdert grijswaarden gevolgd door tint eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat opnieuw. Tint gevolgd door grijswaarden verwijdert de tint opnieuw. Evenzo kan alfabewerking de alfabewerkingen van eerdere stappen overschrijven, terwijl alfabemodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier operaties, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de operatietypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsoperaties tot afzonderlijke ketens beperkt. Ze kunnen gecombineerd worden, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is gecreëerd; grijswaarden na duotone verwijdert de twee geselecteerde kleuren; en alfa‑ceiling, floor, vervanging of bi‑level operaties kunnen alfabetaalde details die eerder zijn gemaakt weggooien. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te behandelen als ongeordende formatterings‑vlaggen.

## **Inspecteer bewerkbare en effectieve waarden**

Een bewerkbare operatie is het object dat is opgeslagen in [Picture.getImageTransform](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/). Afhankelijk van het effect kan het rechtstreeks schrijfbare leden blootstellen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/blur/) stelt schrijfbare `radius`‑ en `grow`‑waarden bloot, [AlphaModulateFixed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/alphamodulatefixed/) stelt een schrijfbare `amount` bloot, en [AlphaBiLevel](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/alphabilevel/) stelt een schrijfbare `threshold` bloot. Kleureffecten zoals [Duotone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/duotone/) exposen mutabele [ColorFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/colorformat/) objecten.

Sommige operaties, waaronder [BrightnessContrast](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/tint/) en [AlphaReplace](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/alphareplace/), exposen hun creatiescalairen niet als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijder je de operatie en voeg je een vervanging toe op de vereiste positie.

Effectieve gegevens die door `getEffective()` worden geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig om themagebonden kleuren op te lossen en de genormaliseerde waarden te lezen die de renderer gebruikt, maar vormen geen extra bewerkingsoppervlak. Het volgende voorbeeld doorloopt de keten en inspecteert effectieve waarden waar de bijbehorende API ze aanbiedt:

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

Parameter‑vrije effecten zoals grijswaarden, alfa‑ceiling en alfa‑inverse hebben nog steeds een effectieve‑databron, maar er zijn geen scalaire instellingen om af te drukken. Hun aanwezigheid en positie in de verzameling zijn de belangrijke informatie.

## **Verwijder of maak afbeeldings‑transformaties leeg**

Gebruik [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) om één operatie te verwijderen op basis van index. Omdat indexen verschuiven na een verwijdering, zoek eerst het doel en verwijder het daarna na het doorlopen. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) om de gehele keten te verwijderen.

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

Het verwijderen of leegmaken van transformaties wijzigt alleen de afbeelding‑formatterings­eigenschappen. Het verwijdert, recomprimeert of wijzigt op andere wijze niet de hergebruikte [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) resource.

## **Houd rekening met presentatie‑formaten en export‑doelen**

Afbeeldings‑transformaties ontstaan in DrawingML, dus PPTX is het voorkeurs‑bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke operatie dezelfde portabiliteit:

- Standaard DrawingML‑operaties zoals luminantie, grijswaarden, duotone, tint, HSL, vervaging en gangbare alfa‑operaties hebben de grootste kans om een PPTX‑round‑trip te overleven. Open het gegenereerde bestand altijd opnieuw en inspecteer de verzameling wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML luminantie‑operatie. Het kan voor in‑memory rendering worden gebruikt, maar er is geen garantie dat het na opslaan en heropenen van PPTX bewerkbaar blijft als [BrightnessContrast](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/brightnesscontrast/) operatie. Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde operaties weglaten, een keten reduceren tot een ondersteunde subset, of een benadering van het uiterlijk geven. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Renderen naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele uitvoer past de ondersteunde keten toe op het gerenderde uiterlijk. Die uitvoer bevat geen bewerkbare [ImageTransformOperationCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagetransformoperationcollection/); rasterformaten flattenen het resultaat naar pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gelinkte afbeelding niet zelf‑voorzienend. Het renderen van een gelinkte afbeelding blijft afhankelijk van de beschikbaarheid van de gelinkte bron wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑operaties gecombineerd worden. Voor kritische uitvoer, test zowel de bewerkbare round‑trip als het uiteindelijke export‑formaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen afbeelding‑transformatie‑effecten de ingesloten afbeeldingsdata?**

Nee. De operaties behoren tot de [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) die door de opvul‑afbeelding wordt gebruikt. De onderliggende [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) bytes blijven ongewijzigd.

**Delen twee afbeelding‑kaders die dezelfde afbeelding hergebruiken hun effecten?**

Nee. Het hergebruiken van een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) vermijdt duplicatie van afbeeldingsdata, maar elk afbeelding‑kader heeft normaal gezien een eigen [Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) en eigen beeldtransformatie‑verzameling.

**Kunnen kleur‑, vervagings‑ en alfa‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Houd rekening met wat elke operatie doet met de uitvoer van de vorige, want vervang‑ en drempeloperaties kunnen eerdere kleur‑ of alfabeddetails weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve data representeert berekende waarden die voor rendering worden gebruikt, inclusief opgeloste kleuren. Bewerk de operatie die in de transformatie‑verzameling is opgeslagen waar schrijfbare leden bestaan; verwijder anders de operatie en voeg een vervanging toe met nieuwe creatie‑parameters.

**Welk formaat moet ik gebruiken om een transformatie‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Het legacy‑PPT‑formaat kan het volledige DrawingML‑effectmodel niet vertegenwoordigen, en gerenderde export‑formaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑operaties.