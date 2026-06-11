---
title: Hantera presentationsformer i JavaScript
linktitle: Formmanipulering
type: docs
weight: 40
url: /sv/nodejs-java/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formens layoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig att skapa, redigera och optimera former med JavaScript och Aspose.Slides för Node.js via Java och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, hämtar dess Interop‑form‑ID och anger alternativ text för identifiering och vidare bearbetning.

Den täcker också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder flip‑egenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om kombination av former, staplingsordning och låsning av former.

## **Hitta form i bild**
Detta ämne beskriver en enkel teknik för att underlätta för utvecklare att hitta en specifik form på en bild utan att använda dess interna Id. Det är viktigt att veta att PowerPoint‑presentationsfiler inte har något sätt att identifiera former på en bild förutom ett internt unikt Id. Det kan vara svårt för utvecklare att hitta en form med hjälp av dess interna unika Id. Alla former som läggs till i bilderna har någon alternativ text. Vi rekommenderar att utvecklare använder alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

Efter att du har angett den alternativa texten för en önskad form kan du öppna presentationen med Aspose.Slides för Node.js via Java och iterera igenom alla former som lagts till på en bild. Under varje iteration kan du kontrollera formens alternativa text och den form vars alternativa text matchar är den du söker. För att demonstrera tekniken på ett bättre sätt har vi skapat en metod, [findShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) som löser att hitta en specifik form i en bild och sedan helt enkelt returnerar den formen.

```javascript
// Instansiera en Presentation-klass som representerar presentationsfilen
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Alternativ text för den form som ska hittas
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Klona form**
För att klona en form till en bild med Aspose.Slides för Node.js via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Få åtkomst till källbildens form‑samling.
4. Lägg till en ny bild i presentationen.
5. Klona former från källbildens form‑samling till den nya bilden.
6. Spara den modifierade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```javascript
// Instansiera Presentation-klassen
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Skriv PPTX-filen till disk
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ta bort form**
Aspose.Slides för Node.js via Java låter utvecklare ta bort valfri form. För att ta bort formen från en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Ta bort formen.
5. Spara filen till disk.

```javascript
// Skapa Presentation-objekt
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till autogestalt av rektangeltyp
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Spara presentationen till disk
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dölj form**
Aspose.Slides för Node.js via Java låter utvecklare dölja valfri form. För att dölja formen från en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Hitta formen med specifik AlternativeText.
4. Dölj formen.
5. Spara filen till disk.

```javascript
// Instansiera Presentation-klass som representerar PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till autogestalt av rektangeltyp
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Spara presentationen till disk
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ändra ordning på former**
Aspose.Slides för Node.js via Java låter utvecklare omordna former. Att omordna en form specificerar vilken form som är längst fram eller längst bak. För att omordna formerna på en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Lägg till en form.
4. Lägg till lite text i formens textrutor.
5. Lägg till en annan form med samma ko‑ordinater.
6. Omordna formerna.
7. Spara filen till disk.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hämta Interop‑form‑ID**
Aspose.Slides för Node.js via Java låter utvecklare hämta ett unikt form‑identifierare i bild‑omfång i motsats till metoden [getUniqueId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getUniqueId--) som ger ett unikt identifierare i presentations‑omfång. Metoden [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) lades till i klassen [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape) och motsvarande klass. Värdet som returneras av [getOfficeInteropShapeId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) motsvarar Id‑värdet för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan ges ett exempel på kod.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Hämtar unik formidentifierare i bildomfång
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ange alternativ text för form**
Aspose.Slides för Node.js via Java låter utvecklare ange AlternateText för en form. Former i en presentation kan särskiljas med hjälp av [AlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) eller [Shape Name](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) metoden. Metoderna [setAlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) och [getAlternativeText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getAlternativeText--) kan läsas eller skrivas med både Aspose.Slides och Microsoft PowerPoint. Med hjälp av denna metod kan du märka en form och utföra olika operationer såsom att ta bort en form, dölja en form eller omordna former på en bild. För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation).
2. Få åtkomst till den första bilden.
3. Lägg till någon form på bilden.
4. Gör något arbete med den nylagda formen.
5. Gå igenom formerna för att hitta en form.
6. Ange AlternativeText.
7. Spara filen till disk.

```javascript
// Instansiera Presentation-klass som representerar PPTX
var pres = new aspose.slides.Presentation();
try {
    // Hämta den första bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till autogestalt av rektangeltyp
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Spara presentationen till disk
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Få åtkomst till layoutformat för form**
Aspose.Slides för Node.js via Java tillhandahåller ett enkelt API för att få åtkomst till layoutformat för en form. Denna artikel demonstrerar hur du kan komma åt layoutformat.

Nedan ges exempel på kod.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rendera form som SVG**
Nu stödjer Aspose.Slides för Node.js via Java rendering av en form som SVG. Metoden [writeAsSvg](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (och dess överlagring) har lagts till i klassen [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape). Denna metod möjliggör att spara innehållet i en form som en SVG‑fil. Kodsnutten nedan visar hur du exporterar en bilds form till en SVG‑fil.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Formjustering**
Aspose.Slides låter dig justera former antingen i förhållande till bildens marginaler eller i förhållande till varandra. För detta ändamål har den överlagrade metoden [SlidesUtil.alignShape()](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) lagts till. Enumerationen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapesAlignmentType) definierar möjliga justeringsalternativ.

**Exempel 1**

Källkoden nedan justerar former med index 1, 2 och 4 längs bildens överkant.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Exempel 2**

Exemplet nedan visar hur du justerar hela samlingen av former i förhållande till den nedersta formen i samlingen.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Flip‑egenskaper**

I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via dess `flipH`‑ och `flipV`‑egenskaper. Båda egenskaperna är av typ `byte` och kan ha värdet `1` för spegling, `0` för ingen spegling eller `-1` för standardbeteende. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getFrame).

För att ändra flip‑inställningarna skapas en ny [ShapeFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapeframe/)-instans med formens nuvarande position och storlek, önskade värden för `flipH` och `flipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getFrame) och spara presentationen appliceras speglingarna och de sparas i utdatafilen.

Anta att vi har en fil sample.pptx där den första bilden innehåller en enda form med standard‑flip‑inställningar, som visas nedan.

![Formen som ska speglas](shape_to_be_flipped.png)

Följande kodexempel hämtar formens nuvarande flip‑egenskaper och speglar den både horisontellt och vertikalt.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Hämta den horisontella flip-egenskapen för formen.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Hämta den vertikala flip-egenskapen för formen.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Flippa horisontellt.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Flippa vertikalt.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den speglade formen](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en skrivbordsredigerare?**

Det finns inget inbyggt API för booleska operationer. Du kan approximera det genom att konstruera den önskade konturen själv – t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort originalen.

**Hur kan jag kontrollera staplingsordningen (z-order) så att en form alltid ligger “överst”?**

Ändra infognings‑/flyttningsordningen inom bildens [shapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getShapes)-samling. För förutsägbara resultat, slutför z‑ordningen efter alla andra bildmodifieringar.

**Kan jag ”låsa” en form för att hindra användare från att redigera den i PowerPoint?**

Ja. Ställ in skyddsflaggor på formnivå (t.ex. lås markering, rörelse, storleksändring, textredigering). Om behövt, spegla begränsningarna på master‑ eller layoutnivå. Observera att detta är ett UI‑skydd, inte en säkerhetsfunktion; för starkare skydd kombinera med fil‑nivå restriktioner såsom rekommendationer om skrivskydd eller lösenord ([read‑only recommendations or passwords](/slides/sv/nodejs-java/password-protected-presentation/)).