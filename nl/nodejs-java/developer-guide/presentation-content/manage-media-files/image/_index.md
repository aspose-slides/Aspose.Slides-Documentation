---
title: Optimaliseer beeldbeheer in presentaties met JavaScript
linktitle: Afbeeldingen beheren
type: docs
weight: 10
url: /nl/nodejs-java/image/
keywords:
- afbeelding toevoegen
- foto toevoegen
- bitmap toevoegen
- afbeelding vervangen
- foto vervangen
- van internet
- achtergrond
- PNG toevoegen
- JPG toevoegen
- SVG toevoegen
- EMF toevoegen
- WMF toevoegen
- TIFF toevoegen
- PowerPoint
- OpenDocument
- presentatie
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Stroomlijn het beheer van afbeeldingen in PowerPoint en OpenDocument met JavaScript en Aspose.Slides voor Node.js, optimaliseer de prestaties en automatiseer je workflow."
---
## **Inleiding**

Afbeeldingen maken presentaties boeiender en interessanter. In Microsoft PowerPoint kun je afbeeldingen vanuit een bestand, het internet of andere locaties op dia's invoegen. Op dezelfde manier stelt Aspose.Slides je in staat om afbeeldingen aan dia's in je presentaties toe te voegen via verschillende procedures. 

{{% alert  title="Tip" color="primary" %}} 

Aspose biedt gratis converters—[JPEG to PowerPoint](https://products.aspose.app/slides/nl/import/jpg-to-ppt) en [PNG to PowerPoint](https://products.aspose.app/slides/nl/import/png-to-ppt)—die mensen in staat stellen snel presentaties te maken van afbeeldingen. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Als je een afbeelding wilt toevoegen als een frame‑object—vooral als je van plan bent standaard opmaakopties te gebruiken om de grootte te wijzigen, effecten toe te voegen, enzovoort—zie [Afbeeldingsframe](https://docs.aspose.com/slides/nl/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides ondersteunt bewerkingen met afbeeldingen in deze populaire formaten: JPEG, PNG, GIF en andere. 

## **Afbeeldingen die lokaal zijn opgeslagen toevoegen aan dia's**

Je kunt een of meerdere afbeeldingen op je computer aan een dia in een presentatie toevoegen. Deze voorbeeldcode in JavaScript laat zien hoe je een afbeelding aan een dia toevoegt:

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

## **Afbeeldingen vanuit een stream toevoegen aan dia's**

Als de afbeelding die je wilt toevoegen aan een dia niet beschikbaar is op je computer, kun je de afbeelding direct van het internet toevoegen. 

Deze voorbeeldcode laat zien hoe je een afbeelding van het internet aan een dia toevoegt in JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Laadt een Excel-bestand in een stream
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Creëert een data-object voor insluiting
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Voegt een OLE-objectframe-vorm toe
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Schrijft het PPTX-bestand naar schijf
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Afbeeldingen toevoegen aan dia‑masters**

Een dia‑master is de bovenste dia die informatie (thema, lay‑out, enz.) over alle onderliggende dia's opslaat en beheert. Dus wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt die afbeelding op elke dia onder die master. 

Deze JavaScript‑voorbeeldcode laat zien hoe je een afbeelding aan een dia‑master toevoegt:

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

## **Afbeeldingen als dia‑achtergrond toevoegen**

Je kunt ervoor kiezen een afbeelding als achtergrond voor een specifieke dia of meerdere dia's te gebruiken. In dat geval moet je *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nl/nodejs-java/presentation-background/#setting-images-as-background-for-slides)* bekijken.

## **SVG toevoegen aan presentaties**
Je kunt elke afbeelding toevoegen of invoegen in een presentatie met behulp van de [addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) methode die behoort tot de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection) klasse.

Om een afbeelding‑object op basis van een SVG‑afbeelding te maken, kun je het op de volgende manier doen:

1. Maak een SvgImage‑object om het in ImageShapeCollection in te voegen
2. Maak een PPImage‑object van ISvgImage
3. Maak een PictureFrame‑object met behulp van de PPImage‑klasse

Deze voorbeeldcode laat zien hoe je de bovenstaande stappen implementeert om een SVG‑afbeelding aan een presentatie toe te voegen:
```javascript
// Instantieer de Presentation-klasse die een PPTX-bestand vertegenwoordigt
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

## **SVG converteren naar een set vormen**
De conversie van SVG naar een set vormen in Aspose.Slides is vergelijkbaar met de PowerPoint‑functionaliteit die wordt gebruikt om met SVG‑afbeeldingen te werken:

![PowerPoint Pop‑upmenu](img_01_01.png)

De functionaliteit wordt geboden door een van de overloads van de [addGroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) methode van de [ShapeCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection) klasse die een [SvgImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SvgImage) object als eerste argument neemt.

Deze voorbeeldcode laat zien hoe je de beschreven methode gebruikt om een SVG‑bestand te converteren naar een set vormen:

```javascript
// Maak nieuwe presentatie
var presentation = new aspose.slides.Presentation();
try {
    // Lees SVG-bestandsinhoud
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Maak SvgImage-object
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Haal dia-grootte op
    var slideSize = presentation.getSlideSize().getSize();
    // Converteer SVG-afbeelding naar een groep vormen en schaal deze naar de dia-grootte
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Sla presentatie op in PPTX-formaat
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Afbeeldingen als EMF toevoegen aan dia's**
Aspose.Slides for Node.js via Java stelt je in staat om EMF‑afbeeldingen te genereren van Excel‑bladen en de afbeeldingen als EMF in dia's toe te voegen met Aspose.Cells. 

Deze voorbeeldcode laat zien hoe je de beschreven taak uitvoert:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
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

## **Afbeeldingen vervangen in de afbeeldingscollectie**

Aspose.Slides laat je afbeeldingen die in de afbeeldingscollectie van een presentatie zijn opgeslagen (inclusief die welke door dia‑vormen worden gebruikt) vervangen. Dit gedeelte toont verschillende benaderingen om afbeeldingen in de collectie bij te werken. De API biedt eenvoudige methoden om een afbeelding te vervangen met ruwe bytagegevens, een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) instantie, of een andere afbeelding die al in de collectie staat.

Volg de onderstaande stappen:

1. Laad het presentatiebestand dat afbeeldingen bevat met behulp van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) klasse.
2. Laad een nieuwe afbeelding vanuit een bestand in een byte‑array.
3. Vervang de doelafbeelding door de nieuwe afbeelding met behulp van de byte‑array.
4. In de tweede aanpak, laad de afbeelding in een [IImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/iimage/) object en vervang de doelafbeelding door dat object.
5. In de derde aanpak, vervang de doelafbeelding door een afbeelding die al bestaat in de afbeeldingscollectie van de presentatie.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```js
// Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // De eerste manier.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // De tweede manier.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // De derde manier.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Sla de presentatie op in een bestand.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Met de gratis Aspose Text to GIF‑converter kun je eenvoudig teksten animeren, GIF‑s maken van teksten, enzovoort. 

{{% /alert %}}

## **Veelgestelde vragen**

**Blijft de originele beeldresolutie behouden na het invoegen?**

Ja. De oorspronkelijke pixels worden bewaard, maar het uiteindelijke uiterlijk hangt af van hoe de [picture](/slides/nl/nodejs-java/picture-frame/) wordt geschaald op de dia en eventuele compressie bij het opslaan.

**Wat is de beste manier om hetzelfde logo in tientallen dia's in één keer te vervangen?**

Plaats het logo op de master‑dia of een lay‑out en vervang het in de afbeeldingscollectie van de presentatie—updates worden doorgevoerd naar alle elementen die die bron gebruiken.

**Kan een ingevoegde SVG worden geconverteerd naar bewerkbare vormen?**

Ja. Je kunt een SVG converteren naar een groep vormen; daarna worden individuele delen bewerkbaar met standaard vorm‑eigenschappen.

**Hoe kan ik een afbeelding instellen als achtergrond voor meerdere dia's tegelijk?**

[Stel de afbeelding in als achtergrond](/slides/nl/nodejs-java/presentation-background/) op de master‑dia of de relevante lay‑out—alle dia's die die master/lay‑out gebruiken, erven de achtergrond.

**Hoe voorkom ik dat de presentatie “opschuimt” in grootte door veel afbeeldingen?**

Gebruik één enkele afbeeldingsbron in plaats van duplicaten, kies redelijke resoluties, pas compressie toe bij het opslaan, en houd herhaalde grafieken op de master waar passend.