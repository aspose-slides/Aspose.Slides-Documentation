---
title: Hantera bildramar i presentationer med JavaScript
linktitle: Bildram
type: docs
weight: 10
url: /sv/nodejs-java/picture-frame/
keywords:
- bildram
- lägg till bildram
- skapa bildram
- inbäddad bild
- länkad bild
- extrahera bild
- rasterbild
- SVG-bild
- beskära bild
- ta bort beskurna områden
- komprimera bild
- StretchOffset
- bildramformatering
- relativ skala
- bildeffekt
- bildförhållande
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa, formatera, länka, beskära, extrahera och komprimera bildramar i presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

En bildram är en bildformsform på en bildspel som visar en bild. I Aspose.Slides är bildresursen och formen som visar den separata objekt: en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) äger inbäddade bildresurser via sin [ImageCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/), medan en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) styr bildens position, storlek, linjeformatering, rotation, beskärning, bild effekter och andra inställningar på ramnivå.

Denna separation är användbar när samma bild visas mer än en gång. Lägg till bilden i presentationen en gång, behåll den returnerade [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/), och använd den bildresursen när du skapar bildramar.

Bildramar kan innehålla rasterbilder såsom PNG eller JPEG och vektor‑SVG‑bilder. De kan också referera till länkade bilder i stället för att lagra bild‑bytarna i presentationen. Valet påverkar portabilitet, filstorlek, extraktion och exportbeteende, så det är bra att bestämma hur bilden ska lagras innan formatering eller optimering tillämpas.

## **Lägg till och formatera en inbäddad bild**

För en inbäddad bild lägger du till bilddata i presentationen och skapar en bildram med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Bilden blir en del av presentationspaketet, så presentationen förblir självständig när den flyttas till en annan dator.

Följande exempel lägger till en PNG‑bild, skapar en ram med bildens ursprungliga dimensioner och tillämpar linjeformatering och rotation:

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

Bildramen styr den visade geometrin; att ändra ramens storlek ändrar inte de ursprungliga pixeldimensionerna som lagras i den inbäddade bildresursen. Denna skillnad blir viktig när en bild beskärs eller komprimeras senare.

## **Använd relativ skalning**

[PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) exponerar relativ bredd‑ och höjds skalning för ramen via [setRelativeScaleWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) och [setRelativeScaleHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Ett värde på `1.0` motsvarar 100 % av den ursprungliga bildstorleken. Relativ skalning är användbar när ett arbetsflöde måste bevara ett förhållande till källbildens storlek i stället för att manuellt beräkna slutdimensionerna.

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

Relativ skalning ändrar ramens skalningsinställningar; den omprovtagar eller komprimerar inte den inbäddade bilden.

## **Inbäddade och länkade bilder**

En inbäddad bild lagrar bilddata i presentationen och är därför det säkraste valet för portabilitet och förutsägbar rendering. En länkad bild lagrar en extern plats via metoden [Picture.setLinkPathLong](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) i stället för att bädda in bilddata på samma sätt.

Länkade bilder kan minska mängden bilddata som lagras i PPTX, men de introducerar ett externt beroende. Den länkade filen måste förbli tillgänglig för programmet som öppnar eller renderar presentationen. Om sökvägen ändras, filen flyttas eller resursen blir otillgänglig, visas den länkade bilden kanske inte som förväntat. För presentationer som måste skickas via e‑post, arkiveras eller renderas i isolerade miljöer är inbäddade bilder vanligtvis mer pålitliga.

### **Lägg till en länkad bild**

Följande exempel skapar en bildram och pekar den på en lokal bildfil. Det behandlar enbart bildlänkning; videolänkning är ett separat mediaprocessflöde och är avsiktligt inte blandat i detta exempel.

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

Använd länkar när extern filhantering är avsiktlig. Använd dem inte enbart som ersättning för komprimering: en liten PPTX med brutna bildberoenden är vanligtvis mindre användbar än en större självständig presentation.

## **Extrahera bilder från bildramar**

Innan du extraherar en bild från en befintlig presentation, kontrollera att en form faktiskt är en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) och att den innehåller en inbäddad bild. Länkade bildramar kanske inte innehåller bild‑bytar som kan extraheras på samma sätt.

### **Extrahera en rasterbild**

Det moderna bild‑API‑et använder [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/) direkt. Följande exempel hittar den första inbäddade rasterbilden på en bild och sparar den som PNG:

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

Att spara via [IImage.save](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/#save) konverterar den extraherade bilden till det begärda utdataformatet. Om du behöver de kodade bytarna som lagras i presentationen snarare än en konverterad rasterfil, använd bildresursens binära data i stället.

### **Extrahera en SVG‑bild**

För en SVG‑bild exponerar [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) ett [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/)‑objekt. Detta låter dig hämta SVG‑data direkt i stället för att rasterisera bilden först.

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

Att behålla SVG‑innehållet som SVG bevarar den vektorkälla som finns i presentationen. Rasterexporter såsom PNG eller JPEG renderar nödvändigtvis den vektorgrafiken till pixlar. PDF‑ eller SVG‑bildexport är också en renderingsoperation, så de exporterade grafikerna bör inte betraktas som en exakt byte‑för‑byte‑kopiering av den ursprungliga inbäddade SVG:n; använd den inbäddade [SvgImage.getSvgData](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/#getSvgData--)‑datat när den ursprungliga vektorresursen själv krävs.

## **Beskär en bild**

Beskärning ändrar vilken del av en bild som är synlig i ramen. Beskärningsvärdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/) är procent av källbildens dimensioner. Beskärning tar inte initialt bort de dolda pixlarna från den inbäddade bilden; den ändrar bara den synliga regionen.

Följande exempel hittar en bildram på ett säkert sätt och applicerar beskärningsvärden:

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

Eftersom de dolda bilddatana fortfarande finns kvar kan beskärningen ändras senare utan att förlora de ursprungliga pixlarna. Om filstorlek är viktigare än återställbarhet kan de beskurna områdena fysiskt tas bort som beskrivs i nästa avsnitt.

## **Ta bort beskurna bilddata**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) tar bort bilddata utanför det aktuella beskärningsrektangeln och returnerar den resulterande bildresursen. Detta kan minska filstorleken, men det är en destruktiv optimering: efter att presentationen sparats är de borttagna pixlarna inte längre tillgängliga för en senare avbeskärning.

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

Metoden kan lägga till en ny bildresurs i presentationen. Om den ursprungliga bilden också används av andra bildramar behöver dessa ramars befintliga resurser fortfarande finnas, så att radera beskurna områden inte nödvändigtvis minskar det totala antalet bilder. Beskärning av WMF‑ eller EMF‑innehåll med denna metod rasteriserar det beskurna resultatet till PNG.

## **Komprimera rasterbilder**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) minskar rasterbildens upplösning i förhållande till den storlek som bilden visas i. Den kan också ta bort beskurna regioner i samma operation. Metoden returnerar `true` när bilden har ändrat storlek eller beskärts och `false` när ingen förändring var nödvändig.

Använd ett fördefinierat [PicturesCompression](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturescompression/)‑värde när en standardmålupplösning är tillräcklig:

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

Ett eget positivt DPI‑värde kan anges i stället för ett fördefinierat värde när ett specifikt mål krävs.

Komprimering är avsedd för rasterbilder. SVG‑ och metafil‑innehåll reduceras inte av detta rasterkomprimeringsflöde. Kom också ihåg att lägre upplösning och borttagna beskurna regioner inte kan återställas från den optimerade presentationen. Välj en målupplösning baserat på den största storlek som bilden faktiskt kommer att visas eller exporteras i, snarare än att globalt tillämpa lägsta DPI.

## **Hantera bildtransformeringseffekter**

För ett komplett arbetsflöde som täcker ljusstyrka, kontrast, färgtransformeringar, oskärpa, alfa‑effekter, ordnade kedjor, inspektion, borttagning och rundrese‑verifiering, se [Image Transform Effects](/slides/sv/nodejs-java/image-transform-effects/).

## **Lås bildramens geometri**

[PictureFrameLock](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframelock/)‑inställningarna styr vilka redigeringsåtgärder som är inaktiverade för en bildram. Till exempel bevarar [setAspectRatioLocked](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) formens proportioner medan den ändras i storlek.

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

Låset gäller bildramens form. Det tvingar inte källbilden att provtas eller permanent ändras till samma bildförhållande.

## **Justera StretchOffset‑värdena**

När bildfyllnadsläget är stretch definierar stretch‑offset‑värdena på [PictureFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/) fyllningsrektangeln relativt bildramens omgivande rektangel. Positiva procent skapar ett inskjut på en kant, medan negativa procent skapar ett utskjut.

Detta är annorlunda än beskärning. Beskärningsvärden väljer vilken del av källbilden som är synlig; stretch‑offset förändrar den rektangel som den synliga bildfyllnaden sträcks till.

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

Använd stretch‑offset för placering av fyllning. Använd beskärnings‑egenskaper när målet är att dölja kanterna på källbilden.

## **Lagring, filstorlek och exportaspekter**

De viktigaste avvägningarna blir enklare att hantera när bildlagring och bildram‑formatering behandlas separat:

- **Inbäddade bilder** gör presentationen självständig och är det mest pålitliga alternativet för delning och server‑sida rendering, men stora rasterbilder ökar PPTX‑storlek och minnesanvändning.
- **Länkade bilder** kan hålla paketet mindre, men presentationen är beroende av att externa filer förblir tillgängliga på de lagrade sökvägarna eller platserna.
- **Beskärning** är initialt icke‑destruktiv. De dolda pixlarna förblir inbäddade tills beskurna områden explicit tas bort eller tas bort under komprimering.
- **Komprimering** kan väsentligt minska filstorleken för för stora rasterbilder, men den offrar källupplösning. Den bör appliceras efter att den avsedda på‑bild‑storleken är känd.
- **SVG‑bilder** bör förbli SVG när vektorbevarande är viktigt. Extrahera den inbäddade SVG:n direkt när du behöver själva vektorresursen. Raster‑slide‑exporter konverterar alltid den renderade sliden till pixlar.
- **Upprepade bilder** bör återanvända en befintlig [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑resurs när det är möjligt i stället för att upprepade gånger läsa in samma fil i presentationsarbetsflödet.

För stora presentationer är bildoptimering vanligtvis mest effektiv när den utförs selektivt: håll logotyper och diagram som vektor­innehåll, komprimera fotografier efter deras faktiska visningsstorlek, ta bort beskurna pixlar endast när senare redigering inte krävs, och undvik externa länkar om inte beroendehantering är en del av distributionsdesignen.

## **Vanliga frågor**

**Vad är skillnaden mellan en bildram och en bildresurs?**

En [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) representerar en bildresurs som är kopplad till presentationen. En [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) är en form på en bild som visar en bild och lagrar ram‑nivå geometri och formatering såsom storlek, rotation, beskärningsvärden, effekter och lås.

**Bör jag bädda in eller länka bilder?**

Bädda in bilder när presentationen måste vara portabel, arkiverad eller renderas utan åtkomst till externa resurser. Länka bilder endast när det är avsiktligt att hålla bildfilerna utanför PPTX och de externa platserna kan underhållas på ett pålitligt sätt.

**Minskar beskärning PPTX‑filstorleken?**

Inte i sig. Normala beskärningsinställningar döljer delar av källbilden men behåller de underliggande pixlarna. Använd [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) eller bildkomprimering med borttagning av beskurna områden när dessa pixlar kan tas bort permanent.

**Kan jag återställa bildkvaliteten efter komprimering?**

Nej. Komprimering kan minska den lagrade rasterupplösningen, och borttagning av beskurna regioner kastar bilddata. Behåll den ursprungliga källbilden utanför presentationen om högupplöst redigering kan behövas senare.

**Hur bör SVG‑bilder hanteras?**

Behåll SVG‑innehållet som SVG när vektorfidelitet är viktig. Den inbäddade [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/svgimage/) kan extraheras direkt. Att rendera en slide till ett rasterformat som PNG eller JPEG rasteriserar SVG‑innehållet som en del av slide‑bilden.

**Hur kan jag undvika osäkra cast‑operationer när jag läser befintliga slides?**

Kontrollera formtypen innan du använder bildram‑specifika medlemmar. En `java.instanceOf`‑kontroll mot [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) undviker ogiltiga cast‑operationer och låter koden hantera slides som inte innehåller bildramar.