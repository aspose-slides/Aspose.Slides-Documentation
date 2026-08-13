---
title: Lägg till vattenstämplar i presentationer i Java
linktitle: Vattenstämpel
type: docs
weight: 40
url: /sv/java/watermark/
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
- Java
- Aspose.Slides
description: "Hantera text- och bildvattenstämplar i PowerPoint- och OpenDocument-presentationer i Java för att indikera ett utkast, konfidentiell information, upphovsrätt och mer."
---
## **Introduktion**

Ett vattenstämpel i en presentation är en text‑ eller bildstämpel som används på en bild eller genom alla presentationsbilder. Vanligtvis används ett vattenstämpel för att indikera att presentationen är ett utkast (t.ex. ett "Draft"-vattenstämpel), att den innehåller konfidentiell information (t.ex. ett "Confidential"-vattenstämpel), för att ange vilket företag den tillhör (t.ex. ett "Company Name"-vattenstämpel), för att identifiera författaren till presentationen osv. Ett vattenstämpel hjälper till att förhindra upphovsrättsintrång genom att ange att presentationen inte får kopieras. Vattenstämplar används i både PowerPoint‑ och OpenOffice‑presentationsformat. I Aspose.Slides kan du lägga till ett vattenstämpel i PowerPoint PPT, PPTX och OpenOffice ODP‑filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/java/), finns det olika sätt att skapa vattenstämplar i PowerPoint‑ eller OpenOffice‑dokument och ändra deras design och beteende. Den gemensamma faktorn är att för att lägga till textvattenstämplar bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/), och för att lägga till bildvattenstämplar, använd klassen [PictureFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pictureframe/) eller fyll en vattenstämplingsform med en bild. `PictureFrame` implementerar interfacet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) och låter dig använda alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/)‑objekt.

Det finns två sätt att tillämpa ett vattenstämpel: på en enskild bild eller på alla presentationsbilder. Bildmästaren (Slide Master) används för att tillämpa ett vattenstämpel på alla presentationsbilder — vattenstämpeln läggs till i Slide Master, designas helt där och tillämpas på alla bilder utan att påverka möjligheten att ändra vattenstämpeln på enskilda bilder.

Ett vattenstämpel betraktas normalt som otillgängligt för redigering av andra användare. För att förhindra att vattenstämpeln (eller snarare dess föräldraform) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en normal bild eller på en Slide Master. När vattenstämpel‑formen låses på Slide Master, låses den på alla presentationsbilder.

Du kan ange ett namn för vattenstämpeln så att du i framtiden, om du vill ta bort den, kan hitta den bland bildens former med namn.

Du kan designa vattenstämpeln på vilket sätt som helst; det finns dock ofta gemensamma egenskaper för vattenstämplar, såsom centrering, rotation, framre position osv. Vi kommer att gå igenom hur man använder dessa i exemplen nedan.

## **Textvattenstämpel**

### **Lägg till ett textvattenstämpel på en bild**

För att lägga till ett textvattenstämpel i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/). Denna typ är intevsidd från [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/), som har ett brett urval av egenskaper för flexibel placering av vattenstämpeln. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/)-objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/)-objekt. För att lägga till vattenstämpel‑text i formen, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) enligt nedan.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Se även" %}} 
- [Hur man använder TextFrame‑klassen](/slides/sv/java/text-formatting/)
{{% /alert %}}

### **Lägg till ett textvattenstämpel i en presentation**

Om du vill lägga till ett textvattenstämpel i hela presentationen (dvs. alla bilder på en gång), lägg till det i [MasterSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/masterslide/). Resten av logiken är densamma som när ett vattenstämpel läggs till på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/)-objekt och lägg sedan till vattenstämpeln i det med metoden [addTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Se även" %}} 
- [Hur man använder Bildmästaren](/slides/sv/java/slide-master/)
{{% /alert %}}

### **Ställ in vattenstämpelns formgenomskinlighet**

Som standard är rektangelformen stiliserad med fyllnings‑ och linjefärger. Följande kodrader gör formen genomskinlig.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Ställ in teckensnittet för ett textvattenstämpel**

Du kan ändra teckensnittet för textvattenstämpeln enligt nedan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Ställ in färgen på vattenstämpelns text**

För att ange färgen på vattenstämpelns text, använd följande kod:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centrera ett textvattenstämpel**

Det är möjligt att centrera vattenstämpeln på en bild, och för att göra det kan du göra följande:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Bilden nedan visar det slutgiltiga resultatet.

![Textvattenstämpeln](text_watermark.png)

## **Bildvattenstämpel**

### **Lägg till ett bildvattenstämpel i en presentation**

För att lägga till ett bildvattenstämpel i en presentationsbild kan du göra följande:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Lås ett vattenstämpel från redigering**

Om det är nödvändigt att förhindra att ett vattenstämpel redigeras, använd metoden [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) på formen. Med denna egenskap kan du skydda formen så att den inte kan väljas, ändras i storlek, flyttas, grupperas med andra element, låsa dess text för redigering och mycket mer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Lås vattenstämpelns form från att ändras
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Flytta ett vattenstämpel framåt**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [IShapeCollection.reorder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka referensen till formen samt dess ordningsnummer till metoden. På så sätt kan du föra en form framåt eller skicka den bakåt på bilden. Denna funktion är särskilt användbar om du behöver placera ett vattenstämpel framför presentationen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Ställ in vattenstämpelns rotation**

Här är ett kodexempel som visar hur du justerar rotationen av vattenstämpeln så att den placeras diagonalt över bilden:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Ställ in ett namn för ett vattenstämpel**

Aspose.Slides låter dig ange namnet på en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namn på vattenstämpelns form, tilldela det med metoden [IAutoShape.setName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Ta bort ett vattenstämpel**

För att ta bort vattenstämpelns form, använd metoden [IAutoShape.getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getName--) för att hitta den bland bildens former. Skicka sedan vattenstämpelns form till metoden [IShapeCollection.remove](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **FAQ**

### Vad är ett vattenstämpel och varför bör jag använda det?

Ett vattenstämpel är ett text‑ eller bildöverlägg som appliceras på bilder och som hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

### Kan jag lägga till ett vattenstämpel på alla bilder i en presentation?

Ja, Aspose.Slides låter dig programatiskt lägga till ett vattenstämpel på varje bild i en presentation. Du kan iterera genom alla bilderna och tillämpa vattenstämpelinställningarna individuellt.

### Hur kan jag justera genomskinligheten för vattenstämpeln?

Du kan justera genomskinligheten för vattenstämpeln genom att modifiera fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getFillFormat--)) för formen. Detta säkerställer att vattenstämpeln är subtil och inte distraherar från bildens innehåll.

### Vilka bildformat stöds för vattenstämplar?

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och flera fler.

### Kan jag anpassa teckensnittet och stilen för ett textvattenstämpel?

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att passa designen av din presentation och upprätthålla varumärkeskonsistens.

### Hur ändrar jag positionen eller orienteringen för ett vattenstämpel?

Du kan programatiskt justera position och orientering för vattenstämpeln genom att ändra formens koordinater, storlek och rotationsegenskaper.