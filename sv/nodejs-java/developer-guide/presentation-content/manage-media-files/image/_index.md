---
title: Optimera bildhantering i presentationer med JavaScript
linktitle: Hantera bilder
type: docs
weight: 10
url: /sv/nodejs-java/image/
keywords:
- lägg till bild
- lägg till foto
- lägg till bitmap
- ersätt bild
- ersätt foto
- från webben
- bakgrund
- lägg till PNG
- lägg till JPG
- lägg till SVG
- lägg till EMF
- lägg till WMF
- lägg till TIFF
- PowerPoint
- OpenDocument
- presentation
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Effektivisera bildhantering i PowerPoint och OpenDocument med JavaScript och Aspose.Slides för Node.js, optimera prestanda och automatisera ditt arbetsflöde."
---
## **Introduktion**

Bilder gör presentationer mer engagerande och intressanta. I Microsoft PowerPoint kan du infoga bilder från en fil, internet eller andra platser på bilder. På samma sätt tillåter Aspose.Slides dig att lägga till bilder på bilder i dina presentationer genom olika metoder. 

{{% alert  title="Tips" color="primary" %}} 

Aspose tillhandahåller gratis konverterare—[JPEG till PowerPoint](https://products.aspose.app/slides/sv/import/jpg-to-ppt) och [PNG till PowerPoint](https://products.aspose.app/slides/sv/import/png-to-ppt)—som låter användare skapa presentationer snabbt från bilder. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Om du vill lägga till en bild som ett ramobjekt—speciellt om du planerar att använda standardformateringsalternativ på den för att ändra storlek, lägga till effekter osv.—se [Bildram](https://docs.aspose.com/slides/sv/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides stöder operationer med bilder i dessa populära format: JPEG, PNG, GIF och andra. 

## **Lägga till bilder som lagras lokalt på bildspel**

Du kan lägga till en eller flera bilder på din dator på en bild i en presentation. Detta exempel i JavaScript visar hur du lägger till en bild på en bild:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägga till bilder från strömmen till bildspel**

Om bilden du vill lägga till på en bild inte finns på din dator kan du lägga till bilden direkt från webben. 

Detta exempel visar hur du lägger till en bild från webben på en bild i JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Hämtar den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Laddar en Excel-fil till en ström
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Skapar ett dataobjekt för inbäddning
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Lägger till en Ole Object Frame-form
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Skriver PPTX-filen till disk
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägga till bilder på bildmallar**

En bildmall är den översta bilden som lagrar och styr information (tema, layout osv.) om alla bilder under den. Så när du lägger till en bild på en bildmall visas den på varje bild under den bildmallen. 

Detta JavaScript‑exempel visar hur du lägger till en bild på en bildmall:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lägga till bilder som bildbakgrund**

Du kanske vill använda en bild som bakgrund för en specifik bild eller flera bilder. I så fall bör du se *[Ställa in bilder som bakgrunder för bilder](https://docs.aspose.com/slides/sv/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Lägga till SVG i presentationer**

Du kan lägga till eller infoga någon bild i en presentation genom att använda metoden [addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) som tillhör klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection).

För att skapa ett bildobjekt baserat på en SVG‑bild kan du göra så här:

1. Skapa ett SvgImage‑objekt för att infoga det i ImageShapeCollection
2. Skapa ett PPImage‑objekt från ISvgImage
3. Skapa ett PictureFrame‑objekt med hjälp av PPImage‑klassen

Detta exempel visar hur du implementerar stegen ovan för att lägga till en SVG‑bild i en presentation:
```javascript
// Skapa en Presentation‑instans som representerar en PPTX‑fil
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konvertera SVG till en uppsättning former**

Konverteringen av SVG till en uppsättning former i Aspose.Slides är liknande den PowerPoint‑funktionalitet som används för att arbeta med SVG‑bilder:

![PowerPoint popup‑meny](img_01_01.png)

Funktionaliteten tillhandahålls av en av överlagringarna av metoden [addGroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) i klassen [ShapeCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection) som tar ett [SvgImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SvgImage)‑objekt som första argument.

Detta exempel visar hur du använder den beskrivna metoden för att konvertera en SVG‑fil till en uppsättning former:
```javascript
// Skapa ny presentation
var presentation = new aspose.slides.Presentation();
try {
    // Läs SVG‑filens innehåll
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Skapa SvgImage‑objekt
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Hämta bildstorlek
    var slideSize = presentation.getSlideSize().getSize();
    // Konvertera SVG‑bild till en grupp av former och skala den till bildstorleken
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Spara presentationen i PPTX‑format
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Lägga till bilder som EMF i bildspel**
Aspose.Slides för Node.js via Java låter dig generera EMF‑bilder från Excelfiler och lägga till bilderna som EMF i bildspel med Aspose.Cells. 

Detta exempel visar hur du utför den beskrivna uppgiften:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Spara arbetsboken till ström
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ersätta bilder i bildsamlingen**

Aspose.Slides låter dig ersätta bilder som lagras i en presentations bildsamling (inklusive de som används av bildformer). Denna sektion visar flera tillvägagångssätt för att uppdatera bilder i samlingen. API‑et erbjuder enkla metoder för att ersätta en bild med rå byte‑data, en [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)‑instans eller en annan bild som redan finns i samlingen.

Följ stegen nedan:

1. Läs in presentationsfilen som innehåller bilder med klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Läs in en ny bild från en fil till en byte‑array.
3. Ersätt målbilden med den nya bilden genom att använda byte‑arrayen.
4. I det andra tillvägagångssättet läser du in bilden i ett [IImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/iimage/)‑objekt och ersätter målbilden med det objektet.
5. I det tredje tillvägagångssättet ersätter du målbilden med en bild som redan finns i presentationens bildsamling.
6. Skriv den modifierade presentationen som en PPTX‑fil.

```js
// Instansiera Presentation‑klassen som representerar en presentationsfil.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Det första sättet.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Det andra sättet.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
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

Genom att använda Aspose GRATIS [Text till GIF](https://products.aspose.app/slides/sv/text-to-gif)‑konverteraren kan du enkelt animera text, skapa GIF‑filer från text osv. 

{{% /alert %}}

## **FAQ**

**Behåller den ursprungliga bildens upplösning sin integritet efter infogning?**

Ja. Källpixelna bevaras, men det slutgiltiga utseendet beror på hur [bilden](/slides/sv/nodejs-java/picture-frame/) skalas på bilden och eventuell kompression som tillämpas vid sparning.

**Vad är det bästa sättet att ersätta samma logotyp på dussintals bilder samtidigt?**

Placera logotypen på mastern eller en layout och ersätt den i presentationens bildsamling – uppdateringar sprids till alla element som använder den resursen.

**Kan en infogad SVG konverteras till redigerbara former?**

Ja. Du kan konvertera en SVG till en grupp av former, varpå enskilda delar blir redigerbara med standardegenskaper för former.

**Hur kan jag ställa in en bild som bakgrund för flera bilder samtidigt?**

[Tilldela bilden som bakgrund](/slides/sv/nodejs-java/presentation-background/) på mastern eller den relevanta layouten – alla bilder som använder den mastern/layouten ärver bakgrunden.

**Hur förhindrar jag att presentationen "sväller" i storlek på grund av många bilder?**

Återanvänd en enda bildresurs istället för dubbletter, välj rimliga upplösningar, tillämpa kompression vid sparning och behåll återkommande grafik på mastern där det är lämpligt.