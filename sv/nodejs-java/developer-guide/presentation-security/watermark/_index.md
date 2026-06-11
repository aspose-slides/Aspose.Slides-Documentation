---
title: Lägg till vattenstämplar i presentationer i JavaScript
linktitle: Vattenstämpel
type: docs
weight: 40
url: /sv/nodejs-java/watermark/
keywords:
- vattenstämpel
- textvattenstämpel
- bildvattenstämpel
- lägg till vattenstämpel
- ändra vattenstämpel
- ta bort vattenstämpel
- radera vattenstämpel
- lägg till vattenstämpel i PPT
- lägg till vattenstämpel i PPTX
- lägg till vattenstämpel i ODP
- ta bort vattenstämpel från PPT
- ta bort vattenstämpel från PPTX
- ta bort vattenstämpel från ODP
- radera vattenstämpel från PPT
- radera vattenstämpel från PPTX
- radera vattenstämpel från ODP
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera text- och bildvattenstämplar i PowerPoint- och OpenDocument-presentationer i Node.js för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

En vattenstämpel i en presentation är en text- eller bildstämpel som används på en bild eller i hela presentationen. Vanligtvis används en vattenstämpel för att indikera att presentationen är ett utkast (t.ex. en "Utkast"-vattenstämpel), att den innehåller konfidentiell information (t.ex. en "Konfidentiell"-vattenstämpel), för att ange vilket företag den tillhör (t.ex. en "Företagsnamn"-vattenstämpel), för att identifiera författaren till presentationen osv. En vattenstämpel hjälper till att förhindra upphovsrättsintrång genom att ange att presentationen inte får kopieras. Vattenstämplar används både i PowerPoint- och OpenOffice-presentationformat. I Aspose.Slides kan du lägga till en vattenstämpel i PowerPoint PPT-, PPTX- och OpenOffice ODP-filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/nodejs-java/), finns det olika sätt att skapa vattenstämplar i PowerPoint- eller OpenOffice-dokument och ändra deras design och beteende. Det gemensamma är att för att lägga till textvattenstämplar bör du använda [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/)-typen, och för att lägga till bildvattenstämplar, använda [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/)-klassen eller fylla en vattenstämpel-form med en bild. `PictureFrame` implementerar [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)-typen, vilket gör att du kan använda alla flexibla inställningar för form‑objektet. Eftersom `TextFrame` inte är en form och dess inställningar är begränsade, är den omsluten i ett [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/)-objekt.

Det finns två sätt en vattenstämpel kan tillämpas: på en enskild bild eller på alla presentationsbilder. Slide Master används för att tillämpa en vattenstämpel på alla presentationsbilder – vattenstämpeln läggs till i Slide Master, designas helt där, och appliceras på alla bilder utan att påverka möjligheten att ändra vattenstämpeln på enskilda bilder.

En vattenstämpel anses vanligtvis vara otillgänglig för redigering av andra användare. För att förhindra att vattenstämpeln (eller snarare vattenstämpelns överordnade form) redigeras, tillhandahåller Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en normal bild eller på en Slide Master. När vattenstempelformen låses på Slide Master kommer den att vara låst på alla presentationsbilder.

Du kan sätta ett namn på vattenstämpeln så att du i framtiden, om du vill radera den, kan hitta den i bildens former efter namn.

Du kan designa vattenstämpeln på vilket sätt som helst; dock finns det vanligtvis gemensamma egenskaper i vattenstämplar, såsom centrering, rotation, placering framåt osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenstämpel**

### **Lägg till textvattenstämpel på bild**
För att lägga till en textvattenstämpel i PPT, PPTX eller ODP kan du först lägga till en form på bilden, sedan lägga till en textram i den formen. Textramen representeras av [**TextFrame**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame)-typen. Denna typ är inte ärvd från [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape), som har ett brett urval av egenskaper för att placera vattenstämpeln på ett flexibelt sätt. Därför är [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/TextFrame)-objektet omslutet i ett [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape)-objekt. För att lägga till vattenstempeltext i formen, använd metoden [**addTextFrame**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) med vattenstempeltexten som argument:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- Hur man använder [TextFrame](/slides/sv/nodejs-java/text-formatting/).
{{% /alert %}}

### **Lägg till textvattenstämpel i presentation**
Om du vill lägga till en textvattenstämpel i hela presentationen (dvs. alla bilder på en gång), lägg till den i [**MasterSlide**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/MasterSlide). Resten av logiken är densamma som när du lägger till en vattenstämpel på en enskild bild – skapa ett [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape)‑objekt och lägg sedan till vattenstämpeln med metoden [**addTextFrame**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder ](/slides/sv/nodejs-java/slide-master/)[Slide Master](/slides/sv/nodejs-java/slide-master/)
{{% /alert %}}

### **Ställ in formens genomskinlighet för vattenstämpeln**
Som standard är rektangelformen stylad med fyllnings- och linjefärger. Följande kodrader gör formen genomskinlig.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Ställ in teckensnittet för en textvattenstämpel**
Du kan ändra teckensnittet för textvattenstämpeln enligt nedan.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ställ in färgen på vattenstempeltexten**
För att sätta färgen på vattenstempeltexten, använd följande kod:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Centrera textvattenstämpel**
Det är möjligt att centrera vattenstämpeln på en bild och för det kan du göra följande:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Bilden nedan visar det slutgiltiga resultatet.

![Textvattenstämpel](text_watermark.png)

## **Bildvattenstämpel**

### **Lägg till en bildvattenstämpel i en presentation**
För att lägga till en bildvattenstämpel i alla presentationsbilder kan du göra följande:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Lås en vattenstämpel från redigering**
Om det är nödvändigt att förhindra att en vattenstämpel redigeras, använd metoden [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/AutoShape#getShapeLock--) på formen. Med denna egenskap kan du skydda formen från att väljas, storleksändras, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```javascript
// Lås vattenstämpelformen från att ändras
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Flytta en vattenstämpel framåt**
I Aspose.Slides kan Z-ordningen för former sättas via metoden [**SlideCollection.reorder**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka formreferensen och dess ordningsnummer till metoden. På så sätt är det möjligt att flytta en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera en vattenstämpel framför presentationen:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ställ in rotation för vattenstämpeln**
Här är ett kodexempel på hur du justerar rotationen av vattenstämpeln så att den placeras diagonalt över bilden:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Ange ett namn för en vattenstämpel**
Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller radera den. För att ange namn på vattenstempelformen, tilldela det via metoden [**AutoShape.getName**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Ta bort en vattenstämpel**
För att ta bort vattenstempelformen, använd metoden [AutoShape.getName](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Shape#getName--) för att hitta den bland bildens former. Sedan, skicka vattenstempelformen till metoden [**ShapeCollection.remove**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Vanliga frågor**

**Vad är en vattenstämpel och varför bör jag använda den?**

En vattenstämpel är ett text- eller bildöverlägg som appliceras på bilder och hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till en vattenstämpel på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig lägga till en vattenstämpel på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenstämplingsinställningarna individuellt.

**Hur kan jag justera vattenstämpelns genomskinlighet?**

Du kan justera vattenstämpelns genomskinlighet genom att modifiera [fyllningsinställningarna](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/getfillformat/) för formen. Detta säkerställer att vattenstämpeln är subtil och inte distraherar från innehållet i bilden.

**Vilka bildformat stöds för vattenstämplar?**

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och fler.

**Kan jag anpassa teckensnitt och stil för en textvattenstämpel?**

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att matcha designen i din presentation och upprätthålla varumärkeskonsistens.

**Hur ändrar jag position eller orientering för en vattenstämpel?**

Du kan justera position och orientering för vattenstämpeln genom att modifiera formens koordinater, storlek och rotationsegenskaper.