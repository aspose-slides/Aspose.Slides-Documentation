---
title: Lägg till vattenmärken i presentationer på Android
linktitle: Vattenmärke
type: docs
weight: 40
url: /sv/androidjava/watermark/
keywords:
- vattenmärke
- textvattenmärke
- bildvattenmärke
- lägg till vattenmärke
- ändra vattenmärke
- ta bort vattenmärke
- radera vattenmärke
- lägg till vattenmärke i PPT
- lägg till vattenmärke i PPTX
- lägg till vattenmärke i ODP
- ta bort vattenmärke från PPT
- ta bort vattenmärke från PPTX
- ta bort vattenmärke från ODP
- radera vattenmärke från PPT
- radera vattenmärke från PPTX
- radera vattenmärke från ODP
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera text- och bildvattenmärken i PowerPoint- och OpenDocument-presentationer på Android i Java för att indikera ett utkast, konfidentiell information och mer."
---
## **Introduktion**

**Ett vattenmärke** i en presentation är en text‑ eller bildstämpel som används på en bild eller på alla bilder i presentationen. Vanligtvis används ett vattenmärke för att indikera att presentationen är ett utkast (t.ex. ett “Draft”-vattenmärke), att den innehåller konfidentiell information (t.ex. ett “Confidential”-vattenmärke), för att specificera vilket företag den tillhör (t.ex. ett “Company Name”-vattenmärke), för att identifiera författaren till presentationen osv. Ett vattenmärke hjälper till att förhindra upphovsrättsintrång genom att ange att presentationen inte får kopieras. Vattenmärken används både i PowerPoint‑ och OpenOffice‑presentationer. I Aspose.Slides kan du lägga till ett vattenmärke i PowerPoint‑PPT, PPTX och OpenOffice‑ODP‑filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/android-java/) finns det olika sätt att skapa vattenmärken i PowerPoint‑ eller OpenOffice‑dokument och ändra deras design och beteende. Den gemensamma faktorn är att för att lägga till textvattenmärken bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/), och för att lägga till bildvattenmärken, använda klassen [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/) eller fylla en vattenmärkesform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) vilket gör att du kan använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑objekt.

Det finns två sätt att applicera ett vattenmärke: på en enskild bild eller på alla bilder i presentationen. Slide Master används för att applicera ett vattenmärke på alla bilder — vattenmärket läggs till i Slide Master, designas där helt och appliceras på alla bilder utan att påverka möjligheten att ändra vattenmärket på enskilda bilder.

Ett vattenmärke anses vanligtvis vara otillgängligt för redigering av andra användare. För att förhindra att vattenmärket (eller snarare dess överordnade form) redigeras erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en vanlig bild eller på en Slide Master. När vattenmärkesformen låses på Slide Master låses den på alla bilder i presentationen.

Du kan sätta ett namn på vattenmärket så att du i framtiden, om du vill ta bort det, kan hitta det bland bildens former via namn.

Du kan designa vattenmärket på vilket sätt som helst; det finns dock vanligtvis gemensamma egenskaper för vattenmärken, såsom centrering, rotation, framre position osv. Vi kommer att titta på hur dessa används i exemplen nedan.

## **Textvattenmärke**

### **Lägg till ett textvattenmärke på en bild**

För att lägga till ett textvattenmärke i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/). Denna typ är intevderad från [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/), som har ett brett urval av egenskaper för att placera vattenmärket på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)-objekt. För att lägga till vattenmärketext till formen, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) som visas nedan.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder TextFrame-klassen](/slides/sv/androidjava/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenmärke i en presentation**

Om du vill lägga till ett textvattenmärke i hela presentationen (dvs. alla bilder på en gång) lägger du till det i [MasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till ett vattenmärke på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)-objekt och lägg sedan till vattenmärket i det med metoden [addTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Se även" %}} 
- [Hur man använder Slide Master](/slides/sv/androidjava/slide-master/)
{{% /alert %}}

### **Ställ in vattenmärkesformens transparens**

Som standard är rektangelformen stylad med fyllnings‑ och linjefärger. Följande kodrader gör formen transparent.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Ställ in teckensnitt för ett textvattenmärke**

Du kan ändra teckensnittet för textvattenmärket enligt nedan.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Ställ in textfärgen för vattenmärket**

För att sätta färgen på vattenmärketexten, använd följande kod:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Centrera ett textvattenmärke**

Det är möjligt att centrera vattenmärket på en bild, och för att göra det kan du följa följande:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![Textvattenmärket](text_watermark.png)

## **Bildvattenmärke**

### **Lägg till ett bildvattenmärke i en presentation**

För att lägga till ett bildvattenmärke i en presentationsbild kan du göra följande:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Låsa ett vattenmärke för redigering**

Om det är nödvändigt att förhindra att ett vattenmärke redigeras, använd metoden [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) på formen. Med den här egenskapen kan du skydda formen från att väljas, ändras i storlek, flyttas, grupperas med andra element, låsa dess text för redigering och mycket mer:

```java
// Lås vattenmärkesformen från att modifieras
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Flytta ett vattenmärke framåt**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [IShapeCollection.reorder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka in formreferensen samt dess ordningsnummer i metoden. På så sätt är det möjligt att flytta en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenmärke framför presentationen:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Ställ in vatten märkesrotation**

Här är ett kodexempel på hur du justerar rotationen på vattenmärket så att det placeras diagonalt över bilden:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Ange ett namn för ett vattenmärke**

Aspose.Slides låter dig ange namnet på en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att sätta namnet på vattenmärkesformen, tilldela det med metoden [IAutoShape.setName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Ta bort ett vattenmärke**

För att ta bort vattenmärkesformen, använd metoden [IAutoShape.getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) för att hitta den i bildens former. Passa sedan vattenmärkesformen till metoden [IShapeCollection.remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Vanliga frågor**

**Vad är ett vattenmärke och varför bör jag använda det?**

Ett vattenmärke är en text‑ eller bildöverlagring som appliceras på bilder och som hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

**Kan jag lägga till ett vattenmärke på alla bilder i en presentation?**

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenmärke på varje bild i en presentation. Du kan iterera genom alla bilder och tillämpa vattenmärkesinställningarna individuellt.

**Hur kan jag justera transparensen för vattenmärket?**

Du kan justera transparensen för vattenmärket genom att ändra fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getFillFormat--)) för formen. Detta säkerställer att vattenmärket är subtilt och inte stör bildens innehåll.

**Vilka bildformat stöds för vattenmärken?**

Aspose.Slides stödjer olika bildformat som PNG, JPEG, GIF, BMP, SVG och fler.

**Kan jag anpassa teckensnitt och stil för ett textvattenmärke?**

Ja, du kan välja valfritt teckensnitt, storlek och stil för att matcha designen av din presentation och upprätthålla varumärkesens konsistens.

**Hur ändrar jag positionen eller orienteringen av ett vattenmärke?**

Du kan justera positionen och orienteringen av vattenmärket programatiskt genom att ändra formens koordinater, storlek och rotations‑egenskaper.