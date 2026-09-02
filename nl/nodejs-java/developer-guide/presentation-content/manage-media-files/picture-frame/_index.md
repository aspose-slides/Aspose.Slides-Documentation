---
title: Beheer afbeeldingskaders in presentaties met JavaScript
linktitle: Afbeeldingskader
type: docs
weight: 10
url: /nl/nodejs-java/picture-frame/
keywords:
- afbeeldingskader
- afbeeldingskader toevoegen
- afbeeldingskader maken
- ingesloten afbeelding
- gekoppelde afbeelding
- afbeelding extraheren
- rasterafbeelding
- SVG-afbeelding
- afbeelding bijsnijden
- bijgesneden gebieden verwijderen
- afbeelding comprimeren
- StretchOffset
- opmaak van afbeeldingskader
- relatieve schaal
- afbeeldingseffect
- beeldverhouding
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak, formatteer, koppel, snijd bij, extraheer en comprimeer afbeeldingskaders in presentaties met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een afbeeldingskader is een dia‑vorm die een afbeelding weergeeft. In Aspose.Slides zijn de afbeeldingsbron en de vorm die deze weergeeft afzonderlijke objecten: een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) bezit ingesloten afbeeldingsbronnen via zijn [ImageCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/), terwijl een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) de positie, grootte, lijnopmaak, rotatie, bijsnijden, afbeeldingseffecten en andere kader‑niveau instellingen van de afbeelding beheert.

Deze scheiding is handig wanneer dezelfde afbeelding meer dan één keer wordt getoond. Voeg de afbeelding één keer toe aan de presentatie, bewaar de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/), en gebruik die afbeeldingsbron bij het aanmaken van afbeeldingskaders.

Afbeeldingskaders kunnen rasterafbeeldingen zoals PNG of JPEG en vector‑SVG‑afbeeldingen bevatten. Ze kunnen ook naar gekoppelde afbeeldingen verwijzen in plaats van de afbeeldingsbytes in de presentatie op te slaan. De keuze beïnvloedt draagbaarheid, bestandsgrootte, extractie en exportgedrag, dus het is handig om vooraf te bepalen hoe de afbeelding moet worden opgeslagen voordat opmaak of optimalisatie wordt toegepast.

## **Een Ingesloten Afbeelding Toevoegen en Opmaken**

Voor een ingesloten afbeelding voeg je de afbeeldingsdata toe aan de presentatie en maak je een afbeeldingskader aan met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). De afbeelding wordt onderdeel van het presentatiedossier, zodat de presentatie zelf‑voorzienend blijft wanneer deze naar een andere computer wordt verplaatst.

Het volgende voorbeeld voegt een PNG‑afbeelding toe, maakt een kader aan op de oorspronkelijke afmetingen van de afbeelding en past lijnopmaak en rotatie toe:

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

Het afbeeldingskader bestuurt de weergegeven geometrie; het wijzigen van de kadergrootte verandert niet de oorspronkelijke pixelafmetingen die in de ingesloten afbeeldingsbron zijn opgeslagen. Dit onderscheid wordt later belangrijk bij het bijsnijden of comprimeren van een afbeelding.

## **Relatieve Schaling Gebruiken**

[PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) biedt relatieve breedte‑ en hoogtescaling voor het kader via [setRelativeScaleWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) en [setRelativeScaleHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Een waarde van `1.0` komt overeen met 100 % van de oorspronkelijke afbeeldingsgrootte. Relatieve scaling is handig wanneer een workflow de relatie tot de oorspronkelijke afbeeldingsgrootte moet behouden in plaats van de uiteindelijke afmetingen handmatig te berekenen.

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

Relatieve scaling wijzigt de schaalinstellingen van het kader; het hersamplet of comprimeert de ingesloten afbeelding niet.

## **Ingesloten en Gekoppelde Afbeeldingen**

Een ingesloten afbeelding slaat afbeeldingsdata op binnen de presentatie en is daardoor de veiligste keuze voor draagbaarheid en voorspelbare weergave. Een gekoppelde afbeelding slaat een externe locatie op via de methode [Picture.setLinkPathLong](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) in plaats van de afbeeldingsdata op dezelfde manier in te sluiten.

Gekoppelde afbeeldingen kunnen de hoeveelheid afbeeldingsdata in het PPTX verminderen, maar ze introduceren een externe afhankelijkheid. Het gekoppelde bestand moet toegankelijk blijven voor de applicatie die de presentatie opent of rendert. Als het pad verandert, het bestand wordt verplaatst of de bron is niet beschikbaar, wordt de gekoppelde afbeelding mogelijk niet zoals verwacht weergegeven. Voor presentaties die per e‑mail moeten worden verstuurd, gearchiveerd of gerenderd in geïsoleerde omgevingen, zijn ingesloten afbeeldingen doorgaans betrouwbaarder.

### **Een Gekoppelde Afbeelding Toevoegen**

Het volgende voorbeeld maakt een afbeeldingskader aan en koppelt het aan een lokaal afbeeldingsbestand. Het behandelt alleen afbeeldingskoppeling; videokoppeling is een afzonderlijke mediastroom en wordt opzettelijk niet gemengd in dit voorbeeld.

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

Gebruik koppelingen wanneer extern bestandsbeheer opzettelijk is. Gebruik ze niet alleen als vervanging voor compressie: een klein PPTX met kapotte afbeeldingsafhankelijkheden is meestal minder bruikbaar dan een grotere zelfstandige presentatie.

## **Afbeeldingen uit Afbeeldingskaders Extraheren**

Voordat je een afbeelding uit een bestaande presentatie haalt, controleer of een vorm daadwerkelijk een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is en of deze een ingesloten afbeelding bevat. Gekoppelde afbeeldingskaders bevatten mogelijk niet de afbeeldingsbytes die op dezelfde manier geëxtraheerd kunnen worden.

### **Een Rasterafbeelding Extraheren**

De moderne afbeeldings‑API gebruikt direct [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/). Het volgende voorbeeld vindt de eerste ingesloten rasterafbeelding op een dia en slaat deze op als PNG:

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

Opslaan via [IImage.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/#save) converteert de geëxtraheerde afbeelding naar het aangevraagde uitvoerformaat. Als je de gecodeerde bytes die in de presentatie zijn opgeslagen nodig hebt in plaats van een geconverteerd rasterbestand, gebruik dan de binaire data van de afbeeldingsbron.

### **Een SVG‑Afbeelding Extraheren**

Voor een SVG‑afbeelding biedt de [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) een [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/)‑object. Hiermee kun je de SVG‑data direct ophalen in plaats van de afbeelding eerst te rasteren.

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

Het behouden van SVG‑inhoud als SVG bewaart de vectorbron binnen de presentatie. Raster‑exporten zoals PNG of JPEG renderen die vectorinhoud naar pixels. PDF‑ of SVG‑dia‑export is tevens een render‑operatie, dus de geëxporteerde graphics mogen niet worden behandeld als een exacte byte‑voor‑byte kopie van de oorspronkelijk ingesloten SVG; gebruik de ingesloten [SvgImage.getSvgData](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/#getSvgData--)‑data wanneer de oorspronkelijke vectorbron zelf nodig is.

## **Een Afbeelding Bijsnijden**

Bijsnijden wijzigt welk deel van een afbeelding zichtbaar is binnen het kader. De bijsnijdwaarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) zijn percentages van de afmetingen van de bronafbeelding. Bijsnijden verwijdert niet direct de verborgen pixels uit de ingesloten afbeelding; het verandert alleen het zichtbare gebied.

Het volgende voorbeeld vindt een afbeeldingskader veilig en past bijsnijdwaarden toe:

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

Omdat de verborgen afbeeldingsdata nog aanwezig is, kan de bijsnijding later worden aangepast zonder de oorspronkelijke pixels te verliezen. Als bestandsgrootte belangrijker is dan omkeerbaarheid, kunnen de bijgesneden gebieden fysiek worden verwijderd zoals beschreven in de volgende sectie.

## **Bijsneden Afbeeldingsdata Verwijderen**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) verwijdert afbeeldingsdata buiten de huidige bijsnijdrechthoek en retourneert de resulterende afbeeldingsbron. Dit kan de bestandsgrootte verkleinen, maar het is een destructieve optimalisatie: nadat de presentatie is opgeslagen, zijn de verwijderde pixels niet meer beschikbaar voor een later 'uncrop'-proces.

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

De methode kan een nieuwe afbeeldingsbron aan de presentatie toevoegen. Als de oorspronkelijke afbeelding ook door andere afbeeldingskaders wordt gebruikt, hebben die kaders hun bestaande bron nog steeds nodig, dus het verwijderen van bijgesneden gebieden vermindert niet per se het totale aantal afbeeldingen. Het bijsnijden van WMF‑ of EMF‑inhoud met deze methode rastert het bijgesneden resultaat naar PNG.

## **Rasterafbeeldingen Comprimeren**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) verlaagt de resolutie van rasterafbeeldingen ten opzichte van de grootte waarin de afbeelding wordt weergegeven. Het kan ook bijgesneden gebieden in dezelfde bewerking verwijderen. De methode retourneert `true` wanneer de afbeelding is herschaald of bijgesneden en `false` wanneer er geen wijziging nodig was.

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

Een aangepaste positieve DPI‑waarde kan worden opgegeven in plaats van een vooraf gedefinieerde waarde wanneer een specifieke doelresolutie vereist is.

Compressie is bedoeld voor rasterafbeeldingen. SVG‑ en metabestand‑inhoud wordt niet verminderd door deze rastercompressieworkflow. Vergeet ook niet dat een lagere resolutie en verwijderde bijgesneden gebieden niet kunnen worden hersteld uit de geoptimaliseerde presentatie. Kies een doelresolutie op basis van de grootste grootte waarin de afbeelding daadwerkelijk wordt bekeken of geëxporteerd, in plaats van overal de laagste DPI toe te passen.

## **Afbeeldingstransformatieteffecten Beheren**

Voor een volledige workflow die helderheid, contrast, kleurtransformaties, vervaging, alfabeelden, geordende ketens, inspectie, verwijdering en round‑trip verificatie omvat, zie [Image Transform Effects](/slides/nl/nodejs-java/image-transform-effects/).

## **Afbeeldingskader‑Geometrie Vergrendelen**

De instellingen van [PictureFrameLock](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/) bepalen welke bewerkingsbewerkingen zijn uitgeschakeld voor een afbeeldingskader. Bijvoorbeeld, [setAspectRatioLocked](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) behoudt de verhoudingen van de vorm tijdens het schalen.

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

De vergrendeling geldt voor de vorm van het afbeeldingskader. Het dwingt de bronafbeelding niet om opnieuw te worden gesampled of permanent te worden aangepast aan dezelfde verhoudingen.

## **De StretchOffset‑Waarden Aanpassen**

Wanneer de opvulmodus van de afbeelding 'stretch' is, definiëren de stretch‑offset waarden op [PictureFillFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) het vulrechthoek ten opzichte van de begrenzingsbox van het afbeeldingskader. Positieve percentages creëren een inspringing vanaf een rand, terwijl negatieve percentages een uitstulping creëren.

Dit verschilt van bijsnijden. Bijsnijdwaarden selecteren welk deel van de bronafbeelding zichtbaar is; stretch‑offsets veranderen het rechthoek waarin de zichtbare afbeelding wordt uitgerekt.

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

Gebruik stretch‑offsets voor het plaatsen van de vulling. Gebruik bijsnijd‑eigenschappen wanneer het doel is om de randen van de bronafbeelding te verbergen.

## **Opslag, Bestandsgrootte en Exportoverwegingen**

De belangrijkste afwegingen zijn makkelijker te beheren wanneer afbeeldingsopslag en afbeeldingskader‑opmaak afzonderlijk worden behandeld:

- **Ingesloten afbeeldingen** maken de presentatie zelf‑voorzienend en zijn het meest betrouwbaar voor delen en server‑side rendering, maar grote rasterafbeeldingen vergroten de PPTX‑grootte en het geheugenverbruik.
- **Gekoppelde afbeeldingen** kunnen het bestand kleiner houden, maar de presentatie is afhankelijk van externe bestanden die beschikbaar blijven op de opgeslagen paden of locaties.
- **Bijsnijden** is aanvankelijk niet‑destructief. De verborgen pixels blijven ingesloten totdat bijgesneden gebieden expliciet worden verwijderd of tijdens compressie verwijderd.
- **Compressie** kan de bestandsgrootte aanzienlijk verkleinen voor te grote rasterafbeeldingen, maar het gaat ten koste van de bronresolutie. Het moet worden toegepast nadat de beoogde grootte op de dia bekend is.
- **SVG‑afbeeldingen** moeten als SVG blijven wanneer vectorpreservatie belangrijk is. Extraheer de ingesloten SVG direct wanneer je de vectorbron zelf nodig hebt. Raster‑dia‑exports zetten altijd de gerenderde dia om naar pixels.
- **Herhaalde afbeeldingen** moeten een bestaande [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑bron hergebruiken wanneer mogelijk, in plaats van telkens hetzelfde bestand in de presentatie‑workflow te laden.

Voor grote presentaties is afbeeldingsoptimalisatie meestal het meest effectief wanneer deze selectief wordt uitgevoerd: houd logo's en diagrammen als vectorinhoud, comprimeer foto's volgens hun werkelijke weergavegrootte, verwijder bijgesneden pixels alleen wanneer latere bewerking niet nodig is, en vermijd externe koppelingen tenzij afhankelijkheidsbeheer deel uitmaakt van het implementatie‑ontwerp.

## **FAQ**

**Wat is het verschil tussen een afbeeldingskader en een afbeeldingsbron?**

Een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) vertegenwoordigt een afbeeldingsbron die aan de presentatie is gekoppeld. Een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is een vorm op een dia die een afbeelding weergeeft en kader‑niveau geometrie en opmaak opslaat, zoals grootte, rotatie, bijsnijdwaarden, effecten en vergrendelingen.

**Moet ik afbeeldingen insluiten of koppelen?**

Sluit afbeeldingen in wanneer de presentatie draagbaar, gearchiveerd of gerenderd moet kunnen worden zonder toegang tot externe bronnen. Koppel afbeeldingen alleen wanneer het opzettelijk is om afbeeldingsbestanden buiten het PPTX te houden en de externe locaties betrouwbaar beheerd kunnen worden.

**Vermindert bijsnijden de PPTX‑bestandsgrootte?**

Niet op zichzelf. Normale bijsnijdinstellingen verbergen delen van de bronafbeelding maar behouden de onderliggende pixels. Gebruik [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) of afbeeldingcompressie met verwijdering van bijgesneden gebieden wanneer die pixels permanent kunnen worden weggelaten.

**Kan ik de afbeeldingskwaliteit herstellen na compressie?**

Nee. Compressie kan de opgeslagen rasterresolutie verlagen, en het verwijderen van bijgesneden gebieden verliest afbeeldingsdata. Bewaar de oorspronkelijke bronafbeelding buiten de presentatie als later bewerken op hoge resolutie vereist kan zijn.

**Hoe moeten SVG‑afbeeldingen worden behandeld?**

Behoud SVG‑inhoud als SVG wanneer vectorpreservatie belangrijk is. De ingesloten [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/) kan direct worden geëxtraheerd wanneer je de vectorbron zelf nodig hebt. Het renderen van een dia naar een rasterformaat zoals PNG of JPEG rastert de SVG als onderdeel van de dia‑afbeelding.

**Hoe kan ik onveilige casts vermijden bij het lezen van bestaande dia's?**

Controleer het vormtype voordat je afbeeldingskader‑specifieke leden gebruikt. Een `java.instanceOf`‑controle tegen [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) voorkomt ongeldige casts en laat de code dia's die geen afbeeldingskaders bevatten passend afhandelen.