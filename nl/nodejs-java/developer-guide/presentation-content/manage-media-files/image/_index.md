---
title: Optimaliseer Beeldbeheer in Presentaties met JavaScript
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/nodejs-java/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- afbeelding vervangen
- afbeeldingscollectie
- foto-frame
- gelinkte afbeelding
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- SVG naar vormen
- externe SVG-bronnen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u raster- en SVG-afbeeldingen kunt toevoegen, hergebruiken, linken, vervangen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java."
---
## **Inleiding**

Aspose.Slides for Node.js via Java biedt verschillende manieren om met afbeeldingen te werken, en elke manier dient een ander doel. Je kunt een afbeelding opslaan in een presentatie, weergeven in een foto‑frame, gebruiken als een dia‑achtergrond, linken naar een externe afbeelding, een gedeelde afbeeldingsbron vervangen, of SVG‑inhoud omzetten naar bewerkbare vormen.

Dit artikel richt zich op afbeeldingsbronnen en hoe ze door een presentatie heen worden gebruikt. Voor bijsnijden, transparantie, effecten, uitrekking en andere opmaak die op een enkel foto‑frame wordt toegepast, zie [Foto‑frame](/slides/nl/nodejs-java/picture-frame/).

## **Begrijp het afbeeldingsmodel**

De volgende API‑concepten zijn nauw verwant maar niet uitwisselbaar:

- De [presentation image collection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/) slaat afbeeldingsbronnen op die door de presentatie worden gebruikt. Gebruik [ImageCollection.addImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/) om afbeeldingsdata toe te voegen en een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑resource te verkrijgen.
- Een [picture frame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) is een shape die een afbeelding op een dia, lay‑out of master weergeeft. Gebruik [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/) om een afbeeldingsresource op een dia te plaatsen.
- Een dia‑achtergrond gebruikt een afbeelding als onderdeel van de dia‑opvulling in plaats van als een shape. Het gedraagt zich dus niet als een foto‑frame.
- [PPImage.replaceImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) vervangt een afbeeldingsresource. Als verschillende presentatiedelen die resource gebruiken, gebruiken ze allemaal de vervanging.
- Het omzetten van een SVG naar vormen creëert bewerkbare dia‑vormen. Na de conversie wordt de inhoud niet langer beheerd als één foto‑resource.

Een typisch werkproces is daarom: voeg afbeeldingsdata toe aan de image collection, ontvang een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/), en gebruik die resource vervolgens in één of meer foto‑frames of vullingen.

## **Een ingebedde afbeelding toevoegen**

Om een lokale afbeelding in te voegen, laad je het bestand, voeg je het toe aan de image collection en maak je een foto‑frame dat de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/)‑resource gebruikt.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De op deze manier toegevoegde afbeelding wordt ingebed in de presentatie, zodat het eindbestand niet afhankelijk is van het oorspronkelijke afbeeldingsbestand.

### **Een afbeelding van het web toevoegen**

Wanneer een afbeelding beschikbaar is via HTTP of HTTPS, download je de bytes, voeg je ze toe aan de presentation image collection, en gebruik je de geretourneerde afbeeldingsresource op dezelfde manier als een lokale afbeelding.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

In langdurige toepassingen kun je beter een HTTP‑client of een connectiemanagement‑strategie hergebruiken die past bij de applicatie, in plaats van steeds opnieuw onnodige netwerk­infrastructuur op te zetten. Valideer bovendien externe URL‑s, responsgroottes en content‑types wanneer de bron niet vertrouwd wordt.

## **Afbeeldingen hergebruiken over verschillende dia’s**

Als dezelfde afbeelding meermaals nodig is, voeg je deze één keer toe aan de presentatie en hergebruik je de geretourneerde [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) bij het aanmaken van extra foto‑frames. Dit voorkomt herhaaldelijk laden van dezelfde brondata en maakt de relatie tussen de gedeelde afbeeldingsresource en het gebruik expliciet.

Voor grafische elementen die automatisch op veel dia’s moeten verschijnen, zoals een bedrijfslogo, overweeg dan om het foto‑frame op een [slide master](/slides/nl/nodejs-java/slide-master/) of lay‑out te plaatsen in plaats van een gelijkwaardige shape aan elke dia toe te voegen.

## **Een afbeelding als dia‑achtergrond gebruiken**

Een achtergrondafbeelding wordt toegewezen aan de dia‑opvulling; hij wordt niet toegevoegd als een foto‑frame‑shape. Dit is handig wanneer de afbeelding de hele dia‑achtergrond moet bedekken en niet moet worden gemanipuleerd als een normaal dia‑object.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor extra achtergrondopties, inclusief master‑ en lay‑out‑achtergronden, zie [Presentation Background](/slides/nl/nodejs-java/presentation-background/).

## **Ingebedde afbeeldingen en gelinkte afbeeldingen**

Ingebedde en gelinkte afbeeldingen hebben verschillende portabiliteits‑ en bestandsgrootte‑afwegingen:

- **Ingebedde afbeelding:** de afbeeldingsdata wordt opgeslagen binnen de presentatie. De presentatie is autonoom, maar de bestandsgrootte omvat de afbeeldingsdata.
- **Gelinkte afbeelding:** de presentatie slaat een pad of URL op naar een externe afbeelding. Dit kan de presentatiegrootte verkleinen, maar de externe bron moet beschikbaar blijven wanneer de presentatie wordt geopend of gerenderd.

Een gelinkte foto kan worden aangemaakt door het externe pad of de URL toe te wijzen via [Picture.setLinkPathLong](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/) in plaats van de afbeeldingsdata te embedden.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik gelinkte afbeeldingen alleen wanneer de implementatie‑omgeving betrouwbaar toegang heeft tot de externe bron. Voor presentaties die offline moeten werken of tussen systemen moeten worden verplaatst, zijn ingebedde afbeeldingen doorgaans veiliger.

## **Werken met SVG‑afbeeldingen**

SVG is een vectorformaat, waardoor het nuttig kan zijn voor pictogrammen, diagrammen en andere grafische elementen die zonder verlies van detail moeten schalen. Aspose.Slides ondersteunt SVG zowel als een afbeeldingsresource als als bron voor bewerkbare dia‑vormen.

### **Een SVG als afbeelding toevoegen**

Maak een [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/), voeg deze toe aan de image collection, en plaats de resulterende afbeeldingsresource in een foto‑frame.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑bestanden met externe bronnen**

Een SVG kan verwijzen naar externe afbeeldingen, stylesheets of fonts. Voor deze gevallen biedt [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/) constructors die een [ExternalResourceResolver](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/externalresourceresolver/) en een basis‑URI accepteren. De resolver kan een relatieve URI naar een toegestane absolute URI mappen en een stream retourneren voor de aangevraagde bron.

De resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt, maar herschrijft de SVG niet naar een autonoom document. Als de SVG portabel moet blijven, embed dan de benodigde bronnen in de SVG zelf, bijvoorbeeld door `data:`‑URI´s te gebruiken voor gelinkte afbeeldingen.

Wanneer SVG‑bestanden van onbetrouwbare bronnen komen, beperk dan de schema’s, bestandspaden en hosts die de resolver mag benaderen. Netwerk‑resolvers dienen tevens time‑outs, limieten voor respons‑grootte en content‑validatie toe te passen.

### **SVG omzetten naar bewerkbare vormen**

Aspose.Slides kan een SVG omzetten in een groep bewerkbare dia‑vormen, vergelijkbaar met de overeenkomstige PowerPoint‑opdracht.

![PowerPoint Popup Menu](img_01_01.png)

Gebruik de overload van [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/) die een SVG‑afbeelding accepteert om de conversie uit te voeren.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Gebruik de SVG‑naar‑vormen‑conversie wanneer individuele vector‑elementen bewerkt moeten worden als PowerPoint‑vormen. Als de SVG alleen moet worden weergegeven, is het eenvoudiger om deze als afbeelding te behouden en vermijd je het aanmaken van veel losse vormen.

## **Een bestaande afbeeldingsresource vervangen**

Gebruik [PPImage.replaceImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) wanneer je een bestaande afbeeldingsresource wilt vervangen. Dit is vooral handig voor gedeelde grafische elementen zoals logo’s.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Als meerdere foto‑frames, achtergronden, masters of lay‑outs dezelfde afbeelding gebruiken, werkt het vervangen van die resource alle genoemde toepassingen bij. Als alleen één foto‑frame moet wijzigen, wijs dan een andere afbeelding toe aan dat frame in plaats van de gedeelde resource te vervangen.

[PPImage.replaceImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) biedt ook overloads die een byte‑array of een andere [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) accepteren.

## **Praktische richtlijnen voor afbeeldingsbeheer**

### **Presentatiegrootte beheersen**

Grote raster‑afbeeldingen kunnen een presentatie onnodig groot maken. Gebruik bronafbeeldingen met afmetingen die passen bij de beoogde weergavegrootte, hergebruik gedeelde afbeeldingsbronnen waar mogelijk, en vermijd het embedden van meerdere kopieën van dezelfde afbeelding met volledige resolutie.

Voor raster‑afbeeldingen die al in foto‑frames zijn geplaatst, kan [PictureFillFormat.compressImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/) de afbeeldingsdata reduceren volgens de geselecteerde resolutie en bijsnijd‑instellingen. Dit is foto‑frame‑verwerking, geen image‑collection‑beheer, dus zie [Foto‑frame](/slides/nl/nodejs-java/picture-frame/) voor gerelateerde opmaakacties.

### **Kiezen tussen ingebedde en gelinkte inhoud**

Inbedden maakt de presentatie draagbaar omdat alle benodigde afbeeldingsdata met het bestand meereist. Linken kan de bestandsgrootte verkleinen, maar introduceert een externe afhankelijkheid. Gebruik links alleen wanneer die afhankelijkheid acceptabel en stabiel is.

### **Gedeelde branding hergebruiken**

Voor herhaalde logo’s, watermerken of decoratieve afbeeldingen, gebruik één afbeeldingsresource en hergebruik deze. Als de grafiek deel uitmaakt van het presentatiedesign in plaats van van de dia‑inhoud, plaats deze dan op een master of lay‑out zodat hij over de relevante dia’s wordt geërfd.

### **SVG‑bronnen draagbaar houden**

Een zelf‑bevatte SVG is makkelijker te verplaatsen en consistent te renderen dan een SVG die afhankelijk is van externe bestanden of netwerk‑bronnen. Waar mogelijk embed de benodigde bronnen voordat je de SVG importeert. Converteer SVG naar vormen alleen wanneer de afzonderlijke vector‑elementen bewerkt moeten worden.

### **De moderne cross‑platform afbeeldings‑API gebruiken**

Voor nieuwe Node.js‑via‑Java‑code, gebruik de Aspose.Slides [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) en [Images](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/images/) API’s in plaats van de verouderde publieke API gebaseerd op `java.awt.image.BufferedImage`. Zie [Modern API](/slides/nl/nodejs-java/modern-api/) voor migratierichtlijnen.

WMF en EMF vereisen speciale aandacht. Wanneer deze formaten via een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) worden verwerkt, converteert [ImageCollection.addImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/) het metafile naar een raster‑PNG‑representatie vóór invoeging. Als het behouden van de metafile‑data belangrijk is, gebruik dan de stream‑gebaseerde overload van [ImageCollection.addImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/). Het genereren van EMF‑content vanuit spreadsheets of andere producten is een apart integratiewerkproces en valt buiten de scope van dit artikel.

## **FAQ**

**Wat is het verschil tussen de image collection en een foto‑frame?**

De image collection slaat herbruikbare afbeeldingsbronnen op. Een foto‑frame is een dia‑shape die een van die bronnen weergeeft en foto‑specifieke opmaak biedt zoals bijsnijden en effecten.

**Wat is de beste manier om hetzelfde logo overal te vervangen?**

Als het logo al gedeeld wordt als één afbeeldingsresource, vervang die resource met [PPImage.replaceImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/). Voor presentatie‑brede branding kan het logo ook op een master of lay‑out worden geplaatst om duplicatie van dia‑inhoud te verminderen.

**Waarom verdwijnt een gelinkte afbeelding op een andere computer?**

Een gelinkte foto is afhankelijk van een extern bestand of een URL. Als die bron vanaf de andere computer niet bereikbaar is, is de gelinkte afbeelding niet beschikbaar. Embed de afbeelding wanneer de presentatie autonoom moet zijn.

**Kan een ingevoegde SVG worden bewerkt als PowerPoint‑vormen?**

Ja. Converteer de SVG met [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/); de resulterende groep bevat bewerkbare dia‑vormen in plaats van één SVG‑afbeelding.

**Hoe houd ik presentaties met veel afbeeldingen kleiner?**

Herbruik gedeelde afbeeldingsbronnen, vermijd onnodig grote raster‑bronnen, comprimeer geschikte raster‑afbeeldingen wanneer passend, plaats herhaalde branding op masters of lay‑outs, en gebruik gelinkte afbeeldingen alleen wanneer een externe afhankelijkheid acceptabel is.