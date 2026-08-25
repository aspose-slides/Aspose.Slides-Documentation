---
title: Beheer afbeeldingframes in presentaties met JavaScript
linktitle: Afbeeldingsframe
type: docs
weight: 10
url: /nl/nodejs-java/picture-frame/
keywords:
- afbeeldingframe
- afbeeldingframe toevoegen
- afbeeldingframe maken
- ingebedde afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingframe
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingframes in presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een afbeeldingframe is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsresource en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) bezit ingebedde afbeeldingsresources via zijn [ImageCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere instellingen op frame‑niveau regelt.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/), en gebruik die afbeeldingsresource bij het aanmaken van afbeeldingframes.

Afbeeldingsframes kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook verwijzen naar gekoppelde afbeeldingen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is nuttig om vóór het toepassen van opmaak of optimalisatie te bepalen hoe de afbeelding moet worden opgeslagen.

## **Een Ingebedde Afbeelding Toevoegen en Opmaken**

Voor een ingebedde afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een afbeeldingframe met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). De afbeelding wordt onderdeel van het presentatiedossier, zodat de presentatie zelf‑voorzien blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een PNG‑afbeelding toe, maakt een frame op de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het afbeeldingframe bepaalt de weergegeven geometrie; het wijzigen van de frame‑grootte verandert de oorspronkelijke pixelafmetingen die in de ingebedde afbeeldingsresource zijn opgeslagen. Dit onderscheid wordt belangrijk bij later bijsnijden of comprimeren van een afbeelding.

## **Relatieve Schaling Gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) biedt relatieve breedte‑ en hoogte‑schaling voor het frame via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve schaal is nuttig wanneer een workflow een verhouding tot de bronafbeelding moet behouden in plaats van de eindafmetingen handmatig te berekenen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Relatieve schaal wijzigt de schaalinstellingen van het frame; het herzamplet of comprimeert de ingebedde afbeelding niet.

## **Ingebedde en Gekoppelde Afbeeldingen**

Een ingebedde afbeelding slaat afbeeldingsdata op binnen de presentatie en is daarom de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via de [Picture.setLinkPathLong](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-)‑methode in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingdata in het PPTX‑bestand verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de toepassing die de presentatie opent of weergeeft. Als het pad verandert, het bestand wordt verplaatst of de bron niet beschikbaar is, wordt de gekoppelde afbeelding mogelijk niet zoals verwacht getoond. Voor presentaties die moeten worden gemaild, gearchiveerd of weergegeven in geïsoleerde omgevingen zijn ingebedde afbeeldingen doorgaans betrouwbaarder.

### **Een Gekoppelde Afbeelding Toevoegen**

Het volgende voorbeeld maakt een afbeeldingframe en wijst het naar een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppelingen; videokoppelingen vormen een aparte mediastream en worden opzettelijk niet in dit voorbeeld gemengd.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet louter als vervanging voor compressie: een klein PPTX‑bestand met gebroken afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere, zelf‑voorzienende presentatie.

## **Afbeeldingen Uit Afbeeldingsframes Extraheren**

Voordat je een afbeelding uit een bestaande presentatie extraheert, controleer je of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is en of deze een ingebedde afbeelding bevat. Gekoppelde afbeeldingframes bevatten mogelijk geen afbeeldingsbytes die op dezelfde manier kunnen worden geëxtraheerd.

### **Een Rasterafbeelding Extraheren**

De moderne afbeelding‑API gebruikt direct [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/). Het volgende voorbeeld zoekt de eerste ingebedde rasterafbeelding op een dia en slaat deze op als PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Opslaan via [IImage.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) converteert de geëxtraheerde afbeelding naar het gevraagde uitvoerformaat. Als je de gecodeerde bytes wilt die in de presentatie zijn opgeslagen in plaats van een geconverteerd rasterbestand, gebruik je de binaire data van de afbeeldingsresource.

### **Een SVG‑Afbeelding Extraheren**

Voor een SVG‑afbeelding biedt de [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/)-object. Hiermee kun je de SVG‑data rechtstreeks ophalen in plaats van de afbeelding eerst te rasteren.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG‑inhoud als SVG bewaren behoudt de vectorbron in de presentatie. Raster‑exports zoals PNG of JPEG moeten die vectorinhoud naar pixels renderen. PDF‑ of SVG‑dia‑export is eveneens een render‑operatie, dus de geëxporteerde graphics moeten niet worden beschouwd als een bit‑voor‑bit kopie van de oorspronkelijke ingebedde SVG; gebruik de ingebedde [SvgImage.getSvgData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/#getSvgData--)‑data wanneer de oorspronkelijke vectorresource zelf nodig is.

## **Een Afbeelding Bijsnijden**

Bijsnijden wijzigt welk deel van een afbeelding zichtbaar is binnen het frame. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) zijn percentages van de bronafbeeldingsafmetingen. Bijsnijden verwijdert de verborgen pixels niet direct uit de ingebedde afbeelding; het verandert alleen het zichtbare gebied.

Het volgende voorbeeld zoekt veilig een afbeeldingframe en past bijsnijdwaarden toe:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Omdat de verborgen afbeeldingsdata nog steeds aanwezig is, kan het bijsnijden later worden aangepast zonder de oorspronkelijke pixels te verliezen. Als bestandsgrootte belangrijker is dan herroepbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsnede‑Afbeeldingsdata Verwijderen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) verwijdert afbeeldingsdata buiten de huidige bijsnijd‑rechthoek en retourneert de resulterende afbeeldingsresource. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet langer beschikbaar voor een latere “uncrop”‑bewerking.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

De methode kan een nieuwe afbeeldingsresource aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingframes wordt gebruikt, hebben die frames nog steeds hun bestaande resource nodig, zodat het verwijderen van bijgesneden gebieden niet per se het totaal aantal afbeeldingen vermindert. Het bijsnijden van WMF‑ of EMF‑content met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen Comprimeren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) verkleint de rasterresolutie relatief ten opzichte van de grootte waarop de afbeelding wordt weergegeven. Het kan tevens bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is herschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

Gebruik een vooraf gedefinieerde [PicturesCompression](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturescompression/)‑waarde wanneer een standaard doelresolutie voldoende is:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Een aangepaste positieve DPI‑waarde kan in plaats van een vooraf gedefinieerde waarde worden doorgegeven wanneer een specifiek doel vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metabestand‑content worden niet verminderd door deze raster‑compressieworkflow. Denk er ook aan dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste grootte waarop de afbeelding werkelijk zal worden bekeken of geëxporteerd, in plaats van globaal de laagste DPI toe te passen.

## **Afbeelding‑Transformaties Beheren**

Voor een volledige workflow die helderheid, contrast, kleurtransformaties, vervaging, alfa‑effecten, geordende ketens, inspectie, verwijdering en round‑trip‑verificatie omvat, zie [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Afbeeldingsframe‑Geometrie Vergrendelen**

De instellingen van [PictureFrameLock](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/) bepalen welke bewerkingsbewerkingen voor een afbeeldingframe zijn uitgeschakeld. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) behoudt de verhoudingen van de vorm terwijl deze wordt vergroot of verkleind.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De vergrendeling geldt voor de afbeeldingframe‑vorm. Het dwingt de bronafbeelding niet om te worden hersampled of permanent te worden aangepast aan dezelfde beeldverhouding.

## **De StretchOffset‑Waarden Aanpassen**

Wanneer de opvulmodus van de afbeelding “stretch” is, definiëren de stretch‑offset‑waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) het opvul‑rechthoek relatief ten opzichte van de begrenzing van het afbeeldingframe. Positieve percentages creëren een inset vanaf een rand, terwijl negatieve percentages een outset creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden bepalen welk deel van de bronafbeelding zichtbaar is; stretch‑offsets wijzigen het rechthoek waarin de zichtbare afbeelding‑opvulling wordt uitgerekt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik stretch‑offsets voor het plaatsen van de opvulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om randen van de bronafbeelding te verbergen.

## **Opslag, Bestandsgrootte en Exportoverwegingen**

De belangrijkste afwegingen zijn eenvoudiger te beheren wanneer opslag van afbeeldingen en opmaak van afbeeldingframes apart worden behandeld:

- **Ingebedde afbeeldingen** maken de presentatie zelf‑voorzienend en zijn het meest betrouwbaar voor delen en server‑side weergave, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het pakket kleiner houden, maar de presentatie is afhankelijk van externe bestanden die op de opgeslagen paden of locaties beschikbaar blijven.
- **Bijsnijden** is in eerste instantie niet‑destructief. De verborgen pixels blijven ingebed totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie worden weggehaald.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar het vermindert de bronresolutie. Het moet worden toegepast nadat de uiteindelijke weergavegrootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer behoud van vectorkwaliteit belangrijk is. Extraheer de ingebedde SVG rechtstreeks wanneer je de vectorresource zelf nodig hebt. Raster‑dia‑exports converteren altijd de gerenderde dia naar pixels.
- **Herhaalde afbeeldingen** moeten waar mogelijk een bestaande [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑resource hergebruiken in plaats van herhaaldelijk hetzelfde bestand in de presentatieworkflow te laden.

Voor grote presentaties is beeldoptimalisatie meestal het meest effectief wanneer deze selectief wordt uitgevoerd: houd logo’s en diagrammen als vectorinhoud, comprimeer foto’s volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet vereist is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer onderdeel is van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingframe en een afbeeldingsresource?**

Een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsresource die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en frame‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen inbedden of koppelen?**

Embed afbeeldingen wanneer de presentatie draagbaar, gearchiveerd of weergegeven moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten het PPTX te houden en de externe locaties betrouwbaar kunnen worden beheerd.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) of beeldcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden verwijderd.

**Kan ik de beeldkwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verminderen, en het verwijderen van bijgesneden gebieden wist afbeeldingsdata. Houd de originele bronafbeelding buiten de presentatie als latere bewerkingen met hoge resolutie vereist kunnen zijn.

**Hoe moet ik met SVG‑afbeeldingen omgaan?**

Behoud SVG‑content als SVG wanneer vector‑fidelity belangrijk is. De ingebedde [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/) kan rechtstreeks worden geëxtraheerd. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia’s?**

Controleer het vormtype voordat je leden gebruikt die specifiek zijn voor afbeeldingframes. Een `java.instanceOf`‑controle tegen [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) voorkomt ongeldige casts en stelt de code in staat om dia’s die geen afbeeldingframes bevatten correct af te handelen.