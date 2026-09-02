---
title: Optimera bildhantering i presentationer med JavaScript
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/nodejs-java/image/
keywords:
- lägg till bild
- lägg till bild
- ersätt bild
- bildsamling
- bildram
- länkad bild
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- SVG till former
- externa SVG-resurser
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du lägger till, återanvänder, länkar, ersätter och hanterar raster- och SVG-bilder i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java."
---
## **Introduktion**

Aspose.Slides for Node.js via Java erbjuder flera sätt att arbeta med bilder, och varje sätt har ett annat syfte. Du kan lagra en bild i en presentation, visa den i en bildram, använda den som bakgrund för en bild, länka till en extern bild, ersätta en delad bildresurs eller konvertera SVG‑innehåll till redigerbara former.

Denna artikel fokuserar på bildresurser och hur de används i en presentation. För beskärning, transparens, effekter, töjning och annan formatering som tillämpas på en enskild bildram, se [Bildram](/slides/sv/nodejs-java/picture-frame/).

## **Förstå bildmodellen**

Följande API‑koncept är nära besläktade men inte utbytbara:

- Den [presentation image collection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/) lagrar bildresurser som används av presentationen. Använd [ImageCollection.addImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/) för att lägga till bilddata och få en [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) resurs.
- En [bildram](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) är en form som visar en bild på en bild, layout eller master. Använd [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/) för att placera en bildresurs på en bild.
- En bildbakgrund använder en bild som en del av bildens fyllning snarare än som en form. Den beter sig därför inte som en bildram.
- [PPImage.replaceImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) ersätter en bildresurs. Om flera presentationselement använder den resursen, använder de alla ersättningen.
- Att konvertera en SVG till former skapar redigerbara bildformer. Efter konverteringen hanteras innehållet inte längre som en enda bildresurs.

Ett typiskt arbetsflöde är därför: lägg till bilddata i bildsamlingen, ta emot en [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/), och använd sedan den resursen i en eller flera bildramar eller fyllningar.

## **Lägg till en inbäddad bild**

För att infoga en lokal bild, läs in filen, lägg till den i bildsamlingen och skapa en bildram som använder den returnerade [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)-resursen.

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

Bilden som läggs till på detta sätt är inbäddad i presentationen, så den resulterande filen är inte beroende av att den ursprungliga bildfilen kvarstår tillgänglig.

### **Lägg till en bild från webben**

När en bild är tillgänglig via HTTP eller HTTPS, ladda ner dess bytes, lägg till dem i presentationens bildsamling och använd den returnerade bildresursen på samma sätt som en lokal bild.

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

I långlivade applikationer, återanvänd en HTTP‑klient eller en anslutningshanteringsstrategi som är lämplig för applikationen i stället för att upprepade gånger skapa onödig nätverksinfrastruktur. Validera också fjärr‑URL:er, svarsstorlekar och innehållstyper när källan inte är betrodd.

## **Återanvänd bilder i flera bilder**

Om samma bild behövs mer än en gång, lägg till den i presentationen en gång och återanvänd den returnerade [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) när du skapar ytterligare bildramar. Detta undviker att upprepade gånger läsa in samma källdata och gör förhållandet mellan den delade bildresursen och dess användningar tydligt.

För grafik som ska visas automatiskt på många bilder, till exempel en företagslogotyp, överväg att placera bildramen på en [bildmaster](/slides/sv/nodejs-java/slide-master/) eller layout i stället för att lägga till en motsvarande form på varje bild.

## **Använd en bild som bildbakgrund**

En bakgrundsbild tilldelas bildens fyllning; den läggs inte till som en bildramform. Detta är användbart när bilden ska täcka bildbakgrunden och inte ska manipuleras som ett normalt bildobjekt.

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

För ytterligare bakgrundsalternativ, inklusive master- och layoutbakgrunder, se [Presentationsbakgrund](/slides/sv/nodejs-java/presentation-background/).

## **Inbäddade bilder och länkade bilder**

Inbäddade och länkade bilder har olika portabilitets- och filstorleksavvägningar:

- **Inbäddad bild:** bilddata lagras i presentationen. Presentationen är självständig, men filstorleken inkluderar bilddata.
- **Länkad bild:** presentationen lagrar en sökväg eller URL till en extern bild. Detta kan minska presentationens storlek, men den externa resursen måste vara tillgänglig när presentationen öppnas eller renderas.

En länkad bild kan skapas genom att tilldela den externa sökvägen eller URL:en via [Picture.setLinkPathLong](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/) i stället för att bädda in bilddata.

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

Använd länkade bilder endast när distributionsmiljön på ett tillförlitligt sätt kan komma åt den externa resursen. För presentationer som måste fungera offline eller flyttas mellan system är inbäddade bilder vanligtvis säkrare.

## **Arbeta med SVG‑bilder**

SVG är ett vektorformat, så det kan vara användbart för ikoner, diagram och annan grafik som ska skalas utan samma detaljförlust som rasterbilder. Aspose.Slides stöder SVG både som en bildresurs och som källa för redigerbara bildformer.

### **Lägg till en SVG som bild**

Skapa en [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/), lägg till den i bildsamlingen och placera den resulterande bildresursen i en bildram.

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

### **SVG‑filer med externa resurser**

En SVG kan referera till externa bilder, stilmallar eller teckensnitt. För dessa fall erbjuder [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/) konstruktorer som accepterar en [ExternalResourceResolver](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/externalresourceresolver/) och en grund‑URI. Lösaren kan mappa en relativ URI till en tillåten absolut URI och returnera en ström för den begärda resursen.

Lösaren gör externa resurser tillgängliga medan Aspose.Slides bearbetar SVG‑filen, men den skriver inte om SVG‑filen till ett självständigt dokument. Om SVG‑filen måste förbli portabel, bädda in dess nödvändiga resurser i själva SVG‑filen, till exempel genom att använda `data:`‑URI:er för länkade bilder.

När SVG‑filer kommer från opålitliga källor, begränsa de scheman, filplatser och värdar som lösaren kan komma åt. Nätverks‑lösare bör också tillämpa tidsgränser, gränser för svarsstorlek och innehållsvalidering.

### **Konvertera SVG till redigerbara former**

Aspose.Slides kan konvertera en SVG till en grupp av redigerbara bildformer, liknande motsvarande PowerPoint‑kommando.

![PowerPoint Popup Menu](img_01_01.png)

Använd överlagringen av [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/) som accepterar en SVG‑bild för att utföra konverteringen.

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

Använd SVG‑till‑former‑konvertering när enskilda vektorelement måste redigeras som PowerPoint‑former. Om SVG‑filen bara behöver visas är det enklare att behålla den som en bild och undvika att skapa många separata former.

## **Ersätt en befintlig bildresurs**

Använd [PPImage.replaceImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) när du vill ersätta en befintlig bildresurs. Detta är särskilt användbart för delad grafik såsom logotyper.

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

Om flera bildramar, bakgrunder, masters eller layouter använder samma bildresurs, uppdaterar ersättningen av den resursen alla dessa användningar. Om bara en bildram ska ändras, tilldela en annan bild till den ramen i stället för att ersätta den delade resursen.

[PPImage.replaceImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) erbjuder också överlagringar som accepterar en byte‑array eller en annan [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/).

## **Praktisk vägledning för bildhantering**

### **Kontrollera presentationens storlek**

Stora rasterbilder kan göra en presentation onödigt stor. Använd källbilder med dimensioner som passar deras avsedda visningsstorlek, återanvänd delade bildresurser där det är möjligt och undvik att bädda in upprepade kopior av samma högupplösta grafik.

För rasterbilder som redan har placerats i bildramar kan [PictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/) minska bilddata enligt den valda upplösningen och beskärningsinställningarna. Detta är bildram‑bearbetning snarare än hantering av bildsamlingen, så se [Picture Frame](/slides/sv/nodejs-java/picture-frame/) för relaterade formateringsåtgärder.

### **Välj mellan inbäddat och länkat innehåll**

Inbäddning gör presentationen portabel eftersom all nödvändig bilddata följer med filen. Länkning kan minska filstorleken, men det inför ett externt beroende. Använd länkar endast när det beroendet är acceptabelt och stabilt.

### **Återanvänd delad varumärkesgrafik**

För upprepade logotyper, vattenmärken eller dekorativa grafiker, använd en bildresurs och återanvänd den. Om grafiken tillhör presentationsdesignen snarare än bildinnehållet, placera den på en master eller layout så att den ärvs av de relevanta bilderna.

### **Behåll SVG‑resurser portabla**

En självständig SVG är lättare att flytta och rendera konsekvent än en SVG som är beroende av externa filer eller nätverksresurser. När det är möjligt, bädda in nödvändiga resurser innan SVG‑filen importeras. Konvertera SVG till former endast när de enskilda vektorelementen måste redigeras.

### **Använd det moderna plattformsoberoende bild‑API‑et**

För ny Node.js via Java‑kod, använd Aspose.Slides [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) och [Images](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/images/) API:er i stället för det äldre offentliga API‑et baserat på `java.awt.image.BufferedImage`. Se [Modern API](/slides/sv/nodejs-java/modern-api/) för migrationsvägledning.

WMF och EMF kräver särskild hänsyn. När dessa format passerar genom en [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/), konverterar [ImageCollection.addImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/) metafilen till en raster‑PNG‑representation innan insättning. Om det är viktigt att bevara metafildata, använd en ström‑baserad [ImageCollection.addImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/)‑överlagring i stället. Generering av EMF‑innehåll från kalkylblad eller andra produkter är ett separat integrationsarbetsflöde och ligger utanför denna artikels omfattning.

## **FAQ**

**Vad är skillnaden mellan bildsamlingen och en bildram?**

Bildsamlingen lagrar återanvändbara bildresurser. En bildram är en bildform som visar en av dessa resurser och erbjuder bildspecifik formatering såsom beskärning och effekter.

**Vad är det bästa sättet att ersätta samma logotyp överallt?**

Om logotypen redan delas som en bildresurs, ersätt den resursen med [PPImage.replaceImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/). För varumärkesgrafik som gäller hela presentationen kan placering av logotypen på en master eller layout också minska duplicerat bildinnehåll.

**Varför försvinner en länkad bild på en annan dator?**

En länkad bild beror på sin externa fil eller URL. Om den resursen inte kan nås från den andra datorn kan den länkade bilden bli otillgänglig. Bädda in bilden när presentationen måste vara självständig.

**Kan en infogad SVG redigeras som PowerPoint‑former?**

Ja. Konvertera SVG‑filen med [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/); den resulterande gruppen innehåller redigerbara bildformer istället för en enda SVG‑bild.

**Hur kan jag hålla presentationer med många bilder mindre?**

Återanvänd delade bildresurser, undvik onödigt stora rasterkällor, komprimera lämpliga rasterbilder när det är lämpligt, håll upprepad varumärkesgrafik på masters eller layouter, och använd länkade bilder endast när ett externt beroende är acceptabelt.