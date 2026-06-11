---
title: Lägg till vattenmärken i presentationer i Java
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/java/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägga till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägga till vattenmärke i PPT
- lägga till vattenmärke i PPTX
- lägga till vattenmärke i ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer i Java för att ange ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text‑ eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenmärke för att indikera att presentationen är ett utkast (t.ex. ett "Draft"-vattenmärke), att den innehåller konfidentiell information (t.ex. ett "Confidential"-vattenmärke), för att specificera vilket företag den tillhör (t.ex. ett "Company Name"-vattenmärke), för att identifiera presentationens författare osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att indikera att presentationen inte får kopieras. Vattenmärken används i både PowerPoint‑ och OpenOffice‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint‑PPT, PPTX och OpenOffice‑ODP‑filformat.

På [**Aspose.Slides**](https://products.aspose.com/slides/sv/java/) finns det flera sätt att skapa vattenmärken i PowerPoint‑ eller OpenOffice‑dokument och ändra deras design och beteende. Den gemensamma aspekten är att för att lägga till textvattenmärken ska du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/), och för att lägga till bildvattenmärken, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/) eller fyll en vattenmärkesform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑objekt.

Det finns två sätt att applicera ett vattenmärke: på en enskild bild eller på alla presentationsbilder. Slide Master används för att applicera ett vattenmärke på alla bilder — vattenmärket läggs till i Slide Master, designas helt där och appliceras på alla bilder utan att påverka möjligheten att redigera vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare dess överordnade form) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en vanlig bild eller på en Slide Master. När vattenmärkesformen är låst på Slide Master, kommer den att vara låst på alla presentationsbilder.

Du kan ge vattenmärket ett namn så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens former med namn.

Du kan utforma vattenmärket på vilket sätt du vill; dock finns det vanligtvis gemensamma egenskaper för vattenmärken, såsom mittjustering, rotation, framre position osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram på den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/). Denna typ är inte ärvd från [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/), som har ett brett urval av egenskaper för att placera vattenmärket på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/)-objekt. För att lägga till vattenmärketext till formen, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) som visas nedan.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder TextFrame‑klassen](/slides/sv/java/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/)-objekt och lägg sedan till vattenmärket med metoden [addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder Slide Master](/slides/sv/java/slide-master/)
{{% /alert %}}

### **Ställ in vattenmärkesformens transparens**

Standard är att rektangelformen har fyllnings‑ och linjefärger. Följande kodrader gör formen genomskinlig.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ställ in typsnittet för ett textvattenmärke**

Du kan ändra typsnittet för textvattenmärket som visas nedan.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ställ in färg för vattenmärketexten**

För att sätta färg på vattenmärketexten, använd följande kod:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för detta kan du göra följande:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Bild nedan visar slutresultatet.

![Textvattenmärket](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

För att lägga till ett bildvattenmärke på en presentationsbild kan du göra följande:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Lås ett vattenmärke för redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd metoden [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) på formen. Med denna egenskap kan du skydda formen från att väljas, ändra storlek, flyttas, grupperas med andra element, låsa dess text för redigering och mycket mer:

```java
// Lås vattenmärkesformen från att ändras
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Flytta ett vattenmärke framåt**

I Aspose.Slides kan Z‑ordningen för former sättas via metoden [IShapeCollection.reorder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka in formreferensen och dess ordningsnummer. På så sätt är det möjligt att flytta en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ställ in vattenmärkets rotation**

Här är ett kodexempel på hur du justerar rotationen av vattenmärket så att det placeras diagonalt över bilden:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namnet på vattenmärkesformen, tilldela det med metoden [IAutoShape.setName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen, använd metoden [IAutoShape.getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getName--) för att hitta den bland bildens former. Passa sedan in vattenmärkesformen till metoden [IShapeCollection.remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**Vad är ett vattenmärke och varför bör jag använda det?**

Ett vattenmärke är ett text‑ eller bildöverlagring som appliceras på bilder och som hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera genom alla bilder och applicera vattenmärkesinställningarna individuellt.

**Hur kan jag justera transparensen för vattenmärket?**

Du kan justera transparensen för vattenmärket genom att ändra fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getFillFormat--)) för formen. Detta säkerställer att vattenmärket är diskret och inte stör bildens innehåll.

**Vilka bildformat stöds för vattenmärken?**

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG med flera.

**Kan jag anpassa typsnitt och stil för ett textvattenmärke?**

Ja, du kan välja valfritt typsnitt, storlek och stil för att matcha designen på din presentation och upprätthålla varumärkeskonsekvens.

**Hur ändrar jag positionen eller orienteringen av ett vattenmärke?**

Du kan justera positionen och orienteringen av vattenmärket programatiskt genom att ändra formens koordinater, storlek och rotationsegenskaper.