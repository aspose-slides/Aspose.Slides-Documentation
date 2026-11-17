---
title: Beheer afbeeldingstransformatie-effecten in presentaties met JavaScript
linktitle: Afbeeldingstransformatie-effecten
type: docs
weight: 11
url: /nl/nodejs-java/image-transform-effects/
keywords:
- afbeeldingstransformatie
- afbeeldingseffect
- helderheid
- contrast
- grijstinten
- duotoon
- tint
- HSL
- kleurvervanging
- vervaging
- transparantie
- alfadeffect
- effectketen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas afbeeldingstransformatie-effecten toe, koppel ze, inspecteer, verwijder en verifieer afbeeldingstransformaties voor afbeelding-frames met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Aspose.Slides vertegenwoordigt afbeeldingsaanpassingen als een geordende collectie van beeldtransformatie‑bewerkingen. Voor een afbeelding‑frame start u met het frame‑[Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) en krijgt toegang tot [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). De geretourneerde [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) laat u bewerkingen toevoegen, opsommen, inspecteren, verwijderen en wissen zonder de oorspronkelijke afbeeldingsbytes te herschrijven.

Dit artikel toont een volledige workflow voor helderheid en contrast, kleurtransformaties, vervaging, transparantie, geordende effectketens, effectieve waarden, verwijdering en PPTX round‑trip verificatie.

## **Begrijp eigendom van effect en hergebruik van afbeeldingen**

Een afbeeldingsbron en de afbeelding die deze weergeeft zijn verschillende objecten:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) bewaart of verwijst naar de bronafbeeldingsdata die eigendom is van de presentatie.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) behoort tot een afbeelding‑vulling en verwijst naar een afbeeldingsresource terwijl het de collectie van beeldtransformaties opslaat.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) is de dia‑vorm die de bijbehorende afbeelding‑vulling, geometrie, uitsnijdingsinstellingen en andere op frame‑niveau opmaak bezit.

Daarom wijzigen beeldtransformatie‑bewerkingen de bytes in [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) niet. Wanneer dezelfde [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) meer dan één keer wordt doorgegeven aan [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/), ontvangt elk nieuw afbeelding‑frame zijn eigen [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) en zijn eigen transformatieverzameling. Het toepassen van grijstinten op één frame maakt de andere frames niet grijstinten, zelfs niet wanneer ze allemaal dezelfde ingesloten afbeeldingsresource hergebruiken.

Hetzelfde [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)‑model wordt ook gebruikt door andere afbeelding‑vullingen, zoals een vorm of dia‑achtergrond. De onderstaande voorbeelden richten zich op afbeelding‑frames.

## **Gebruik geldige parameterbereiken en eenheden**

De gedemonstreerde methoden gebruiken de volgende semantische bereiken en eenheden. Houd waarden binnen deze bereiken, ook al wijst een bepaalde bibliotheekversie niet onmiddellijk elke out‑of‑range‑waarde af; het doel‑presentatieformaat kan tijdens het opslaan of wanneer PowerPoint het bestand opent, ongeldige gegevens normaliseren, weglaten of afwijzen.

| Bewerking | Parameters | Geldig bereik en eenheid |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` tot `100`, procent; `0` laat het onderdeel ongewijzigd. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | Geen numerieke parameters. Alfa blijft ongewijzigd. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Twee kleuren voor donkere en lichte pixels. RGB- en alfacanalen in `java.awt.Color` gebruiken `0` tot `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | Hue is `0` inclusief tot `360` exclusief, in graden; amount is `-100` tot `100`, procent. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | Hue is `0` inclusief tot `360` exclusief, in graden; saturation en luminance zijn `-100` tot `100`, procent. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | De vervangende kleur gebruikt kanaalwaarden van `0` tot `255`. Bestaande alfabwaarden blijven ongewijzigd. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Radius is niet‑negatief en wordt gemeten in points; `grow` is een Boolean die bepaalt of vervaagd inhoud buiten de oorspronkelijke grenzen mag uitsteken. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Niet‑negatief procent. Gebruik `0` tot `100` voor gewone opaciteitsschaal: `0` is volledig transparant en `100` behoudt de bestaande alfa. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` tot `100`, procent opaciteit. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` tot `100`, procent alfa‑drempel. Waarden eronder worden transparant; waarden op of boven de drempel worden ondoorzichtig. |

Voor vaste alfamodulatie zijn transparantie en opaciteit complementair. Bijvoorbeeld, 35 % transparantie komt overeen met een alfa‑modulatie‑hoeveelheid van 65 %.

## **Pas helderheid en contrast toe**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) retourneert een [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)‑bewerking. De scalare instellingen worden opgegeven wanneer de bewerking wordt gecreëerd. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) retourneert berekende alleen‑lezen waarden die geïnspecteerd of gelogd kunnen worden.

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

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) is een Office 2010‑afbeelding‑effect‑extensie en is minder draagbaar dan het standaard DrawingML‑luminantie‑effect. Wanneer helderheid en contrast na een PPTX round‑trip bewerkbaar moeten blijven, gebruik dan [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) en verifieer het resultaat na het heropenen van het bestand. De sectie over formaatbeperkingen legt dit onderscheid nader uit.

## **Pas kleurtransformaties toe**

Kleureffecten kunnen onafhankelijk worden toegepast op verschillende afbeelding‑frames die één afbeeldingsresource hergebruiken. Het volgende voorbeeld maakt vijf frames en past grijstinten, duotoon, tint, HSL‑aanpassing en kleurvervanging toe.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) bevat twee onafhankelijk bewerkbare kleurparameters: `color1` mappt donkere pixels, terwijl `color2` lichte pixels mappt. Dit maakt het een bruikbaar voorbeeld van een effect waarvan de instellingen complexer zijn dan een enkele scalare waarde.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) vervangt elke pixelkleur door één vaste kleur terwijl alfa behouden blijft. Het verschilt van [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), dat één bronkleur naar een andere mappt en zowel bron‑ als doel‑kleurformaten blootstelt.

### **Pas een luminantiedrempel toe**

Een luminantiedrempel kan vage markeringen op een gescande pagina beter onderscheidbaar maken ten opzichte van de achtergrond. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) behoudt tussenliggende grijstinten. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) zet luminantie om in zwart of wit, terwijl [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) een drempel toepast op de opaciteit.

De luminantiedrempel varieert van 0 % tot 100 %, inclusief. Pixels onder de drempel worden zwart. Pixels op of boven de drempel worden wit. Het verhogen van de drempel maakt meer tinten zwart omdat meer van hen onder de cutoff vallen.

Download [grayscale-swatches.png](grayscale-swatches.png) naar de werkmap. Elk label geeft het oorspronkelijke grijsniveau weer op een schaal van 0 tot 255. Het voorbeeld plaatst het origineel naast twee kopieën en slaat de drempel van elke kopie op in de presentatie.

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

Open de gegenereerde presentatie in PowerPoint om de drie frames te vergelijken. Het swatch‑label 96 heeft ongeveer 38 % luminantie (96 van 255). Het wordt wit bij de 20 %‑drempel en zwart bij de 60 %‑drempel.

![Originele grijstinten‑swatches naast de zwart‑wit resultaten bij luminantiedrempels van 20 % en 60 %](luminance-threshold.png)

## **Voeg vervaging, transparantie en alfa‑effecten toe**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) beïnvloedt alle kleurkanalen, inclusief alfa. Stel `grow` in op `true` wanneer de vervaagde rand buiten de oorspronkelijke afbeeldingsgrenzen mag uitsteken.

Voor uniforme transparantie, gebruik [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Het vermenigvuldigt elke bestaande alfabwaarde, zodat gedeeltelijk transparante pixels proportioneel verschillend blijven. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) kent in plaats daarvan één alfabwaarde toe aan alle pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) zet alfa om in twee niveaus op basis van een drempel.

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

Andere alfa‑bewerkingen zonder parameters zijn onder meer [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), dat elke niet‑nul alfa volledig ondoorzichtig maakt; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), dat elke alfa onder 100 % volledig transparant maakt; en [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), dat alfa verandert naar `100 % - alfa`.

## **Bouw een geordende effectketen**

Elke `add...Effect`‑methode voegt een nieuwe bewerking toe aan het einde van de collectie. De renderer gebruikt de collectie als een geordende pijplijn: de output van bewerking 0 wordt de input van bewerking 1, enzovoort. Daarom kan dezelfde set bewerkingen in een andere volgorde een ander beeld opleveren.

Bijvoorbeeld, grijstinten gevolgd door tint verwijdert eerst chromatische informatie en kleurt vervolgens het luminantie‑resultaat. Tint gevolgd door grijstinten verwijdert de tint opnieuw. Evenzo kan alfa‑vervanging alfa‑waarden die door eerdere bewerkingen zijn berekend overschrijven, terwijl alfamodulatie hun relatieve verschillen behoudt.

Het volgende voorbeeld bouwt een keten van vier bewerkingen, slaat deze op als PPTX, opent de presentatie opnieuw, controleert zowel de bewerkingstypen als hun volgorde, en rendert het heropende resultaat:

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

De collectie legt geen compatibiliteitsmatrix op die kleur‑, alfa‑ en vervagingsbewerkingen tot afzonderlijke ketens beperkt. Ze kunnen worden gecombineerd, maar combinaties zijn niet altijd nuttig. Een vaste kleurvervanging verwijdert RGB‑variatie die door eerdere kleureffecten is geproduceerd; grijstinten na duotoon verwijdert de twee geselecteerde kleuren; en alfa‑ceil, floor, replacement of bi‑level‑bewerkingen kunnen alfade­tail die eerder is gecreëerd verwijderen. Bouw de keten volgens de gewenste pixel‑verwerkingsvolgorde in plaats van de items te zien als ongeordende opmaak‑vlaggen.

<!-- visual-explanation:image-transform-effects:start -->
[![Dezelfde afbeelding gaat eerst door grijstinten dan tint, en dan door tint dan grijstinten. De twee uiteindelijke grijstinten‑afbeeldingen hebben verschillende tinten.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In deze illustratieve Aspose.Slides for .NET 26.11‑rendering laat een tint van 220° op 25 % de grijstinten‑afbeelding ongewijzigd. Het toepassen van dezelfde tint vóór grijstinten levert andere tinten op.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspect bewerkbare en effectieve waarden**

Een bewerkbare bewerking is het object dat is opgeslagen in [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Afhankelijk van het effect kan het direct schrijfbare leden blootstellen. Bijvoorbeeld, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) blootstelt schrijfbare `radius`‑ en `grow`‑waarden, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) een schrijfbare `amount`, en [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) een schrijfbare `threshold`. Kleur‑effecten zoals [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) exposeren mutabele [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/)‑objecten.

Sommige bewerkingen, inclusief [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), en [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), geven hun creatiescalaren niet bloot als schrijfbare eigenschappen. Om die instellingen te wijzigen, verwijdert u de bewerking en voegt u een vervanging toe op de vereiste positie.

Effectieve gegevens die door `getEffective()` worden geretourneerd, zijn berekend en alleen‑lezen. Ze zijn nuttig voor het oplossen van thema‑afhankelijke kleuren en het lezen van de genormaliseerde waarden die de renderer gebruikt, maar vormen geen extra bewerkingsoppervlak. Het volgende voorbeeld somt de keten op en inspecteert effectieve waarden waar de corresponderende API ze levert:

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

Effecten zonder parameters, zoals grijstinten, alfa‑ceil en alfa‑inverse, hebben nog steeds een effectieve‑datobject, maar er zijn geen scalare instellingen om af te drukken. Hun aanwezigheid en positie in de collectie zijn de belangrijke informatie.

## **Verwijder of wis beeldtransformaties**

Gebruik [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) om één bewerking op index te verwijderen. Omdat indexen verschuiven na verwijdering, zoekt u eerst naar het doel en verwijdert u het na opsomming. Gebruik [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) om de volledige keten te verwijderen.

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

Het verwijderen of wissen van transformaties verandert alleen de afbeelding‑opmaak. Het verwijdert, recomprimeert of wijzigt de hergebruikte [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑resource niet.

## **Overweeg presentatiefomaten en exportdoelen**

Beeldtransformaties ontstaan in DrawingML, dus PPTX is het geprefereerde bewerkbare formaat voor effectketens. Zelfs met PPTX heeft niet elke bewerking identieke draagbaarheid:

- Standaard DrawingML‑bewerkingen zoals luminantie, grijstinten, duotoon, tint, HSL, vervaging en veelvoorkomende alfa‑bewerkingen hebben de beste kans om een PPTX‑round‑trip te overleven. Open het gegenereerde bestand altijd opnieuw en inspecteer de collectie wanneer behoud een vereiste is.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) is een Office 2010‑extensie in plaats van de standaard DrawingML‑luminantie‑bewerking. Het kan worden gebruikt voor in‑memory rendering, maar wordt niet gegarandeerd bewerkbaar behouden als [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)‑bewerking na opslaan en heropenen van PPTX. Geef de voorkeur aan [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) voor blijvende helderheids‑ en contrast‑aanpassingen.
- Het binaire PPT‑formaat bestaat vóór het volledige DrawingML‑effectmodel. Opslaan naar PPT kan niet‑ondersteunde bewerkingen weglaten, een keten reduceren tot een ondersteunde subset, of het uiterlijk benaderen. Gebruik PPT niet als verificatie‑formaat voor een complexe bewerkbare keten.
- Rendering naar PNG, JPEG, TIFF, PDF, SVG, HTML of andere visuele uitvoer past de ondersteunde keten toe op het gerenderde uiterlijk. Die uitvoer bevat geen bewerkbare [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/); rasterformaten flattenen het resultaat tot pixels, en document‑/vector‑exports slaan hun eigen renderrepresentatie op.
- Effecten maken een gekoppelde afbeelding niet zelf‑voorzienend. Het renderen van een gekoppelde afbeelding blijft afhankelijk van de beschikbaarheid van de gekoppelde resource wanneer de presentatie wordt geladen.

Verschillende presentatie‑consumenten kunnen randgevallen anders renderen, vooral wanneer meerdere alfa‑ of kleur‑kwantisatie‑bewerkingen worden gecombineerd. Voor kritieke output test zowel de bewerkbare round‑trip als het uiteindelijke exportformaat met dezelfde Aspose.Slides‑versie die in productie wordt gebruikt.

## **FAQ**

**Wijzigen beeldtransformatie‑effecten de ingesloten afbeeldingsdata?**

Nee. De bewerkingen behoren tot de [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) die wordt gebruikt door de afbeelding‑vulling. De onderliggende [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)‑bytes blijven ongewijzigd.

**Delen twee afbeelding‑frames die dezelfde afbeelding hergebruiken hun effectinstellingen?**

Nee. Het hergebruiken van een [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) voorkomt dubbele afbeeldingsdata, maar elk afbeelding‑frame heeft normaal gesproken een apart [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) en een eigen beeldtransformatie‑collectie.

**Kunnen kleur‑, vervagings‑ en alfa‑effecten gecombineerd worden?**

Ja. De collectie accepteert ze in één geordende keten. Overweeg wat elke bewerking doet met de output van de vorige, omdat vervangings‑ en drempel‑bewerkingen eerdere kleur‑ of alfade­tail kunnen weggooien.

**Waarom zijn effectieve waarden alleen‑lezen?**

Effectieve gegevens vertegenwoordigen berekende waarden die worden gebruikt voor rendering, inclusief opgeloste kleuren. Bewerk de bewerking die in de transformatie‑collectie is opgeslagen waar schrijfbare leden bestaan; anders verwijdert u deze en voegt u een vervanging met nieuwe creatie‑parameters toe.

**Welk formaat moet ik gebruiken om een transform‑keten te behouden?**

Gebruik PPTX en verifieer het bestand door het opnieuw te openen. Legacy PPT kan het volledige DrawingML‑effectmodel niet weergeven, en gerenderde exportformaten behouden alleen het uiterlijk, niet de bewerkbare transformatie‑bewerkingen.