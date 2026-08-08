---
title: Optimera bildhantering i presentationer med JavaScript
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/nodejs-java/image/
keywords:
- lägg till bild
- lägg till bild
- lägg till bitmap
- ersätt bild
- ersätt bild
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- externa SVG-resurser
- SVG-resolver
- länkade SVG-bilder
- SVG-teckensnitt
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Strömlinjeforma bildhantering i PowerPoint och OpenDocument med Aspose.Slides för Node.js via Java, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och visuellt tilltalande. I Microsoft PowerPoint kan du infoga bilder på bilder från filer, internet eller andra källor. På samma sätt låter Aspose.Slides dig lägga till bilder i presentationsbilder på flera sätt.

{{% alert  title="Tip" color="primary" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter dig snabbt skapa presentationer från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som en bildram—särskilt om du planerar att ändra storlek, tillämpa effekter eller använda andra standardformateringsalternativ—se [Picture Frame](/slides/sv/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Du kan konvertera bilder från ett format till ett annat. Se följande sidor: konvertera [image to JPG](https://products.aspose.com/slides/sv/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/sv/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/sv/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/sv/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/sv/nodejs-java/conversion/png-to-svg/), och [SVG to PNG](https://products.aspose.com/slides/sv/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides stöder bilder i populära format som JPEG, PNG, BMP, GIF och andra. 

## **Lägg till bilder lagrade lokalt i bilder**

Du kan lägga till en eller flera bilder som lagras på din dator till en presentationsbild. Följande JavaScript-exempel visar hur du lägger till en bild i en bild:

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

## **Lägg till bilder från webben i bilder**

Om bilden du vill lägga till i en bild inte är lagrad på din dator kan du lägga till den direkt från webben. 

Följande JavaScript-exempel visar hur du lägger till en bild från webben i en bild:

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

## **Lägg till bilder i bildmaster**

En bildmaster lagrar och styr information som tema och layout för de bilder som använder den. När du lägger till en bild i en bildmaster visas bilden på varje bild som baseras på den mastern. 

Följande JavaScript-exempel visar hur du lägger till en bild i en bildmaster:

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

## **Lägg till bilder som bildbakgrund**

Du kan använda en bild som bakgrund för en eller flera bilder. För detaljer, se *[Setting Images as Backgrounds for Slides](/slides/sv/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägg till SVG i presentationer**

SVG-innehåll kan läggas till i en presentation med hjälp av klassen [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/). Det resulterande SVG-bildobjektet kan sedan läggas till i presentationens bildsamling och användas för att skapa en bildram.

Följande JavaScript‑exempel importerar en självständig SVG-sträng. Alla bilder, stilar och andra resurser som används av denna SVG är inbäddade direkt i SVG‑innehållet.

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

## **Importera SVG-innehåll med externa resurser**

SVG-filer som exporteras från designverktyg, diagramredigerare, ikonsystem och webb‑pipelines kan referera till resurser som lagras utanför SVG-dokumentet. Till exempel kan en SVG innehålla en bildlänk såsom `images/photo.png`, ett CSS‑`url(...)`‑värde eller en teckensnitts‑URL.

För att importera sådant SVG-innehåll, tillhandahåll en extern resurs‑resolver och skicka den, tillsammans med en bas‑URI, till en lämplig [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/)‑konstruktor. Bas‑URI identifierar placeringen av SVG-dokumentet och används för att lösa relativa länkar.

`SvgImage`‑klassen ger åtkomst till information om den importerade SVG‑filen:

- `getSvgContent()` returnerar SVG‑markup som en sträng.
- `getSvgData()` returnerar SVG‑innehållet som en byte‑array.
- `getBaseUri()` returnerar bas‑URI som används för relativa länkar.
- `getExternalResourceResolver()` returnerar den resolver som tilldelats SVG‑bilden.

### **Implementera en extern resurs‑resolver**

Resolvren har två metoder:

- `resolveUri` kombinerar bas‑URI och en relativ resurslänk och returnerar en absolut URI. Returnera `null` när länken inte kan lösas eller inte är tillåten.
- `getEntity` returnerar en läsbar Java‑ström för en absolut resurs‑URI. Returnera `null` när resursen saknas, är blockerad eller otillgänglig. En reserv‑ström kan också returneras när det är lämpligt.

Följande hjälparprogram skapar en resolver som laddar länkade resurser endast från en tillåten lokal katalog. Nätverksresurser och sökvägar utanför den tillåtna katalogen blockeras. En valfri reservbild returneras för olösta bildlänkar.

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

                // Denna resolver tillåter avsiktligt endast lokala filer.
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

                // Använd en reserv endast för bildresurser. Att returnera en bildström
                // för en saknad typsnitt eller stilark skulle inte vara giltig.
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

### **Lös länka resurser under SVG‑import**

Anta att `assets/diagram.svg` innehåller en relativ referens såsom:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Följande JavaScript‑exempel skickar SVG‑fil‑URI:n som bas‑URI och tillhandahåller en anpassad resolver. Resolvren konverterar den relativa bildlänken till en absolut URI och returnerar en ström som innehåller den länkade resursen medan Aspose.Slides bearbetar SVG:n.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Bas-URI:n representerar platsen för SVG-dokumentet.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exponerar källinnehållet, binär data, bas-URI och resolvern.
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

`SvgImage`‑klassen erbjuder också överlagringar som accepterar SVG‑data som en byte‑array, samt ström‑baserade fabrikmetoder, tillsammans med en extern resurs‑resolver och en bas‑URI.

{{% alert title="Important" color="warning" %}}

Resolvren gör externa resurser tillgängliga medan Aspose.Slides bearbetar och renderar SVG‑filen. Den ändrar inte den ursprungliga SVG‑markuppen eller bäddar automatiskt in de lösta resurserna i den.

När en SVG‑bild läggs till i presentationens bildsamling kan PPTX‑filen innehålla både den ursprungliga SVG‑representationen och en raster‑reservbild. En länkad resurs kan visas i den genererade reservbilden medan en relativ länk såsom `images/photo.png` förblir oförändrad i den lagrade SVG‑filen. En applikation som renderar den native SVG‑representationen kan därför utelämna det länkade innehållet när den ursprungliga externa resursen är otillgänglig.

{{% /alert %}}

### **Skapa en portabel SVG‑bild**

För att skapa en SVG‑bild som inte är beroende av externa filer, gör SVG:n självständig innan du skapar `SvgImage`. Till exempel, ersätt länkade bild‑URL:er med `data:`‑URI:er som innehåller bilddata:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

När alla nödvändiga resurser är inbäddade i SVG‑innehållet, skapa `SvgImage`, lägg till den i presentationens bildsamling och infoga den i en bildram som visat i föregående exempel.

### **Hantera saknade eller blockerade resurser**

Returnera `null` från `resolveUri` när en resurs‑URI är ogiltig, förbjuden eller inte kan lösas. Returnera `null` från `getEntity` när resursen inte kan läsas. Aspose.Slides fortsätter att bearbeta SVG:n utan den resursen när det är möjligt.

En reserv‑ström kan returneras för en saknad resurs, men dess innehåll måste vara kompatibelt med den begärda resurstypen. Till exempel, returnera en bildström endast för en saknad bild, inte för ett teckensnitt eller en stilfil.

{{% alert title="Security" color="warning" %}}

Lös inte godtyckliga filsökvägar eller obegränsade nätverks‑URL:er från opålitliga SVG‑filer. Begränsa tillåtna scheman, kataloger och värdar. För nätverksresurser, tillämpa också anslutningstidsgränser, svarsstorleksbegränsningar och innehållsvalidering.

{{% /alert %}}

## **Konvertera SVG till en uppsättning former**

Aspose.Slides kan konvertera en SVG till en uppsättning former, liknande motsvarande funktion i PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Denna funktionalitet tillhandahålls av en överlagring av metoden [addGroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection) som tar ett SVG‑bildobjekt som sitt första argument.

Följande JavaScript‑exempel visar hur man använder denna metod för att konvertera en SVG‑fil till en uppsättning former:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Käll SVG-filnamn.
const svgFileName = "sample.svg";

// Utdata presentationsfilnamn.
const outPptxPath = "presentation.pptx";

// Skapa en ny presentation.
const presentation = new aspose.slides.Presentation();
try {
    // Läs SVG-filens innehåll.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Skapa ett SvgImage-objekt.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Hämta bildens storlek.
    const slideSize = presentation.getSlideSize().getSize();

    // Konvertera SVG-bilden till en grupp former och skala den till bildens storlek.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Spara presentationen i PPTX-format.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lägg till bilder som EMF i bilder**

Aspose.Slides för Node.js via Java låter dig generera EMF‑bilder från Excel‑arbetsblad med Aspose.Cells och lägga till dem i presentationsbilder.

Följande JavaScript‑exempel visar hur man gör detta:

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

// Spara arbetsboken till en ström.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Lägg till filen som den är så att bilden förblir en vektor-EMF istället för att rasteriseras.
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

## **Byt ut bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling, inklusive bilder som används av bildformer. Det här avsnittet beskriver flera sätt att uppdatera bilder i samlingen. Du kan ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)-instans eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Läs in presentationsfilen som innehåller bilder med hjälp av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt mål­bilden med den nya bilden med byte‑arrayen.
4. I det andra tillvägagångssättet, läs in bilden i ett [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)-objekt och ersätt mål­bilden med det objektet.
5. I det tredje tillvägagångssättet, ersätt mål­bilden med en bild som redan finns i presentationens bildsamling.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Instansiera Presentation-klassen som representerar en presentationsfil.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Det första sättet.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Det andra sättet.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Det tredje sättet.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Spara presentationen till en fil.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Med Asposes gratis [Text to GIF](https://products.aspose.app/slides/sv/text-to-gif)-konverterare kan du enkelt animera text och skapa GIF‑ar från text. 

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildupplösningen sin integritet efter infogning?**

Ja. Källpixelna bevaras, men det slutgiltiga utseendet beror på hur [picture](/slides/sv/nodejs-java/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparande.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder på en gång?**

Placera logotypen på master‑bilden eller en layout och ersätt den i presentationens bildsamling – uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varefter enskilda delar blir redigerbara med standardformsegenskaper.

**Hur kan jag ange en bild som bakgrund för flera bilder på en gång?**

[Tilldela bilden som bakgrund](/slides/sv/nodejs-java/presentation-background/) på master‑bilden eller den relevanta layouten – alla bilder som använder den master/layouten ärver bakgrunden.

**Hur förhindrar jag att en presentation blir för stor på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubletter, välj rimliga upplösningar, tillämpa kompression vid sparande och håll återkommande grafik på master‑bilden där det är lämpligt.