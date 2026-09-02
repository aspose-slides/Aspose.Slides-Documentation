---
title: Optimaliseer afbeeldingbeheer in presentaties met JavaScript
linktitle: Beheer afbeeldingen
type: docs
weight: 10
url: /nl/nodejs-java/image/
keywords:
- afbeelding toevoegen
- afbeelding toevoegen
- bitmap toevoegen
- afbeelding vervangen
- afbeelding vervangen
- van web
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- externe SVG-bronnen
- SVG-resolver
- gekoppelde SVG-afbeeldingen
- SVG-lettertypen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met Aspose.Slides voor Node.js via Java, verbeter de prestaties en automatiseer uw workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en visueel aantrekkelijker. In Microsoft PowerPoint kun je afbeeldingen op dia's invoegen vanuit bestanden, het internet of andere bronnen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen op presentatiedia's toe te voegen op verschillende manieren.

{{% alert title="Tip" color="primary" %}} 
Aspose biedt gratis converters—[JPEG naar PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG naar PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die je snel presentaties uit afbeeldingen laten maken. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Wil je een afbeelding toevoegen als afbeeldingsframe—bijvoorbeeld wanneer je deze wilt schalen, effecten wilt toepassen of andere standaardopmaakopties wilt gebruiken—zie dan [Afbeeldingsframe](/slides/nl/nodejs-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Opmerking" color="warning" %}}
Je kunt afbeeldingen van het ene formaat naar het andere converteren. Zie de volgende pagina's: converteer [afbeelding naar JPG](https://products.aspose.com/slides/nl/nodejs-java/conversion/image-to-jpg/), [JPG naar afbeelding](https://products.aspose.com/slides/nl/nodejs-java/conversion/jpg-to-image/), [JPG naar PNG](https://products.aspose.com/slides/nl/nodejs-java/conversion/jpg-to-png/), [PNG naar JPG](https://products.aspose.com/slides/nl/nodejs-java/conversion/png-to-jpg/), [PNG naar SVG](https://products.aspose.com/slides/nl/nodejs-java/conversion/png-to-svg/), en [SVG naar PNG](https://products.aspose.com/slides/nl/nodejs-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides ondersteunt afbeeldingen in populaire formaten zoals JPEG, PNG, BMP, GIF en anderen. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt één of meerdere afbeeldingen die op je computer staan toevoegen aan een presentatiedia. De volgende JavaScript‑voorbeeldcode toont hoe je een afbeelding aan een dia toevoegt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen van het internet toevoegen aan dia's**

Als de afbeelding die je wilt toevoegen niet op je computer staat, kun je deze rechtstreeks van het internet invoegen. 

De volgende JavaScript‑voorbeeldcode toont hoe je een afbeelding van het web aan een dia toevoegt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master slaat informatie op en beheert zaken zoals thema en lay‑out voor de dia's die er gebruik van maken. Wanneer je een afbeelding aan een dia‑master toevoegt, verschijnt de afbeelding op elke dia die op die master is gebaseerd. 

De volgende JavaScript‑voorbeeldcode toont hoe je een afbeelding aan een dia‑master toevoegt:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen gebruiken als achtergrond voor dia's**

Je kunt een afbeelding als achtergrond voor één of meerdere dia's gebruiken. Zie voor details *[Afbeeldingen instellen als achtergrond voor dia's](/slides/nl/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **SVG toevoegen aan presentaties**

SVG‑inhoud kan worden toegevoegd aan een presentatie met de [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/)‑klasse. Het resulterende SVG‑afbeeldingsobject kan vervolgens worden toegevoegd aan de afbeeldingscollectie van de presentatie en worden gebruikt om een afbeeldingsframe te maken.

De volgende JavaScript‑voorbeeldcode importeert een zelf‑bevattende SVG‑tekst. Alle afbeeldingen, stijlen en andere bronnen die door deze SVG worden gebruikt, zijn rechtstreeks in de SVG‑inhoud opgenomen.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SVG‑inhoud met externe bronnen importeren**

SVG‑bestanden die vanuit ontwerptools, diagrameditors, icoonsystemen of web‑pipelines worden geëxporteerd, kunnen verwijzingen bevatten naar bronnen die buiten het SVG‑document zijn opgeslagen. Bijvoorbeeld, een SVG kan een afbeeldingslink bevatten zoals `images/photo.png`, een CSS `url(...)`‑waarde, of een lettertype‑URL.

Om dergelijke SVG‑inhoud te importeren, geef je een externe bron‑resolver op en lever je die, samen met een basis‑URI, aan een geschikte [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/svgimage/)‑constructor. De basis‑URI identificeert de locatie van het SVG‑document en wordt gebruikt om relatieve koppelingen op te lossen.

De `SvgImage`‑klasse biedt toegang tot informatie over de geïmporteerde SVG:

- `getSvgContent()` geeft de SVG‑markup terug als een string.
- `getSvgData()` geeft de SVG‑inhoud terug als een byte‑array.
- `getBaseUri()` geeft de basis‑URI terug die wordt gebruikt voor relatieve koppelingen.
- `getExternalResourceResolver()` geeft de resolver terug die aan de SVG‑afbeelding is toegewezen.

### **Een externe bron‑resolver implementeren**

De resolver heeft twee methoden:

- `resolveUri` combineert de basis‑URI en een relatieve bron‑link en geeft een absolute URI terug. Retourneer `null` wanneer de link niet kan worden opgelost of niet is toegestaan.
- `getEntity` retourneert een leesbare Java‑stream voor een absolute bron‑URI. Retourneer `null` wanneer de bron ontbreekt, geblokkeerd of niet beschikbaar is. Een fallback‑stream kan ook worden teruggegeven wanneer dat passend is.

De volgende helper maakt een resolver die gekoppelde bronnen alleen laadt vanuit een toegestane lokale map. Netwerkbronnen en paden buiten de toegestane map worden geblokkeerd. Een optionele fallback‑afbeelding wordt geretourneerd voor onopgeloste afbeeldingskoppelingen.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Deze resolver staat opzettelijk alleen lokale bestanden toe.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Gebruik een fallback alleen voor afbeeldingsbronnen. Het retourneren van een afbeeldingsstream
                // voor een ontbrekend lettertype of stylesheet zou niet geldig zijn.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Gekoppelde bronnen oplossen tijdens SVG‑import**

Stel dat `assets/diagram.svg` een relatieve verwijzing bevat zoals:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

De volgende JavaScript‑voorbeeldcode geeft de SVG‑bestand‑URI door als basis‑URI en levert een aangepaste resolver. De resolver zet de relatieve afbeeldingslink om in een absolute URI en retourneert een stream met de gekoppelde bron terwijl Aspose.Slides de SVG verwerkt.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// De basis-URI vertegenwoordigt de locatie van het SVG-document.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De `SvgImage`‑klasse biedt ook overloads die SVG‑data als byte‑array accepteren, evenals stream‑gebaseerde factory‑methoden, samen met een externe bron‑resolver en een basis‑URI.

{{% alert title="Belangrijk" color="warning" %}}
De bron‑resolver maakt externe bronnen beschikbaar terwijl Aspose.Slides de SVG verwerkt en rendert. Hij wijzigt de oorspronkelijke SVG‑markup niet en embedde de opgeloste bronnen niet automatisch.
Wanneer een SVG‑afbeelding wordt toegevoegd aan de afbeeldingscollectie van de presentatie, kan het PPTX‑bestand zowel de originele SVG‑representatie als een raster‑fallback‑afbeelding bevatten. Een gekoppelde bron kan verschijnen in de gegenereerde fallback‑afbeelding, terwijl een relatieve link zoals `images/photo.png` ongewijzigd blijft in de opgeslagen SVG. Een applicatie die de native SVG‑representatie rendert, kan de gekoppelde inhoud daarom weglaten wanneer de oorspronkelijke externe bron niet beschikbaar is.
{{% /alert %}}

### **Een draagbare SVG‑afbeelding maken**

Om een SVG‑afbeelding te maken die niet afhankelijk is van externe bestanden, maak je de SVG zelf‑bevattend voordat je de `SvgImage` maakt. Vervang bijvoorbeeld gekoppelde afbeeldings‑URL's door `data:`‑URI's die de afbeeldingsdata bevatten:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Nadat alle vereiste bronnen in de SVG‑inhoud zijn ingebed, maak je de `SvgImage`, voeg je deze toe aan de afbeeldingscollectie van de presentatie en voeg je hem in een afbeeldingsframe in zoals in het vorige voorbeeld.

### **Ontbrekende of geblokkeerde bronnen afhandelen**

Retourneer `null` vanuit `resolveUri` wanneer een bron‑URI ongeldig, verboden of niet oplosbaar is. Retourneer `null` vanuit `getEntity` wanneer de bron niet gelezen kan worden. Aspose.Slides blijft de SVG verwerken zonder die bron wanneer dat mogelijk is.

Een fallback‑stream kan worden geretourneerd voor een ontbrekende bron, maar de inhoud moet compatibel zijn met het gevraagde bron‑type. Bijvoorbeeld, retourneer een afbeeldings‑stream alleen voor een ontbrekende afbeelding, niet voor een lettertype of stylesheet.

{{% alert title="Beveiliging" color="warning" %}}
Los geen willekeurige bestandspaden of onbeperkte netwerk‑URL's op uit onbetrouwbare SVG‑bestanden. Beperk toegestane schema's, mappen en hosts. Voor netwerkbronnen gelden ook time‑outs, limieten voor de responsgrootte en inhoudsvalidatie.
{{% /alert %}}

## **SVG converteren naar een reeks vormen**

Aspose.Slides kan een SVG converteren naar een reeks vormen, vergelijkbaar met de overeenkomstige functionaliteit in PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Deze functionaliteit wordt geleverd door een overload van de [addGroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-)‑methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection)‑klasse die een SVG‑afbeeldingsobject als eerste argument neemt.

De volgende JavaScript‑voorbeeldcode toont hoe je deze methode gebruikt om een SVG‑bestand te converteren naar een reeks vormen:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Bron SVG-bestandsnaam.
const svgFileName = "sample.svg";

// Uitvoerpresentatiebestandsnaam.
const outPptxPath = "presentation.pptx";

// Maak een nieuwe presentatie aan.
const presentation = new aspose.slides.Presentation();
try {
    // Lees de SVG-bestandsinhoud.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Maak een SvgImage-object aan.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Haal de dia-grootte op.
    const slideSize = presentation.getSlideSize().getSize();

    // Converteer de SVG-afbeelding naar een groep vormen en schaal deze naar de dia-grootte.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Sla de presentatie op in PPTX-indeling.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Afbeeldingen toevoegen als EMF aan dia's**

Aspose.Slides voor Node.js via Java stelt je in staat om EMF‑afbeeldingen te genereren vanuit Excel‑werkbladen met Aspose.Cells en deze toe te voegen aan presentatiedia's.

De volgende JavaScript‑voorbeeldcode laat zien hoe je dit doet:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Sla het werkboek op naar een stream.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Voeg het bestand toe zoals het is zodat de afbeelding een vector EMF blijft in plaats van gerasterd te worden.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Afbeeldingen vervangen in de afbeeldingscollectie**

Aspose.Slides laat je afbeeldingen die in de afbeeldingscollectie van een presentatie zijn opgeslagen, inclusief afbeeldingen die door dia‑vormen worden gebruikt, vervangen. Deze sectie beschrijft verschillende manieren om afbeeldingen in de collectie bij te werken. Je kunt een afbeelding vervangen met ruwe byte‑data, een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/)-instantie, of een andere afbeelding die al in de collectie bestaat.

Volg de onderstaande stappen:

1. Laad het presentatie‑bestand dat afbeeldingen bevat met de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)-klasse.
1. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
1. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
1. In de tweede benadering laad je de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/)-object en vervang je de doelafbeelding door dat object.
1. In de derde benadering vervang je de doelafbeelding door een afbeelding die al in de afbeeldingscollectie van de presentatie bestaat.
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // De eerste manier.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // De tweede manier.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // De derde manier.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Sla de presentatie op naar een bestand.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Met Aspose's gratis [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter kun je eenvoudig tekst animeren en GIF's maken van tekst. 
{{% /alert %}}

## **FAQ**

**Blijft de oorspronkelijke resolutie van de afbeelding behouden na invoegen?**

Ja. De bronpixels worden bewaard, maar het uiteindelijke uiterlijk hangt af van hoe het [picture](/slides/nl/nodejs-java/picture-frame/) op de dia wordt geschaald en van eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's in één keer te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden omgerekend naar bewerkbare vormen?**

Ja. Je kunt een SVG omzetten naar een groep vormen; daarna kunnen afzonderlijke delen bewerkt worden met de standaard vorm‑eigenschappen.

**Hoe stel ik een afbeelding tegelijk in als achtergrond voor meerdere dia's?**

[Ken de afbeelding toe als achtergrond](/slides/nl/nodejs-java/presentation-background/) op de master‑dia of de betreffende lay‑out—alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat een presentatie te groot wordt door veel afbeeldingen?**

Herbruik één enkele afbeeldingsbron in plaats van duplicaten, kies een redelijke resolutie, pas compressie toe bij het opslaan, en houd herhaalde graphics bij voorkeur op de master.