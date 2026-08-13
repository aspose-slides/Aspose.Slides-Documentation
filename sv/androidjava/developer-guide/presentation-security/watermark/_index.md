---
title: Lägg till vattenstämplar i presentationer på Android
linktitle: Vattenstämpel
type: docs
weight: 40
url: /sv/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Hantera text- och bildvattenstämplar i PowerPoint- och OpenDocument-presentationer på Android i Java för att ange ett utkast, konfidentiell information och mer."
---
## **Introduktion**

**En vattenstämpel** i en presentation är en text‑ eller bildstämpel som används på en bild eller på alla bildspelbilder. Vanligtvis används en vattenstämpel för att ange att presentationen är ett utkast (t.ex. en "Utkast"-vattenstämpel), att den innehåller konfidentiell information (t.ex. en "Konfidentiell"-vattenstämpel), för att specificera vilket företag den tillhör (t.ex. en "Företagsnamn"-vattenstämpel), för att identifiera presentationens författare osv. En vattenstämpel hjälper till att förhindra upphovsrättsbrott genom att visa att presentationen inte får kopieras. Vattenstämplar används i både PowerPoint‑ och OpenOffice‑presentationformat. I Aspose.Slides kan du lägga till en vattenstämpel i PowerPoint PPT, PPTX och OpenOffice ODP‑filformat.

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/android-java/) finns olika sätt du kan skapa vattenstämplar i PowerPoint‑ eller OpenOffice‑dokument och ändra deras design och beteende. Det gemensamma är att för att lägga till textvattenstämplar bör du använda gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/), och för att lägga till bildvattenstämplar, använda klassen [PictureFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pictureframe/) eller fylla en vattenstämpelform med en bild. `PictureFrame` implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/) och ger tillgång till alla flexibla inställningar för formobjektet. Eftersom `ITextFrame` inte är en form och dess inställningar är begränsade, omsluts den i ett [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/)‑objekt.

Det finns två sätt att tillämpa en vattenstämpel: på en enskild bild eller på alla bilder i presentationen. Bild‑masteren används för att applicera en vattenstämpel på alla bilder — vattenstämpeln läggs till i bild‑masteren, designas där fullt ut och appliceras på alla bilder utan att påverka möjligheten att ändra vattenstämpeln på enskilda bilder.

En vattenstämpel anses vanligtvis vara oåtkomlig för redigering av andra användare. För att förhindra att vattenstämpeln (eller snarare dess föräldrafom) redigeras, erbjuder Aspose.Slides funktionalitet för låsning av former. En specifik form kan låsas på en vanlig bild eller på en bild‑master. När vattenstämpelformen låses på bild‑masteren, låses den på alla presentationsbilder.

Du kan ange ett namn för vattenstämpeln så att du i framtiden, om du vill ta bort den, kan hitta den i bildens former efter namn.

Du kan designa vattenstämpeln på vilket sätt du vill; vanliga funktioner i vattenstämplar är dock t.ex. centrering, rotation, placering i förgrunden osv. Vi kommer att titta på hur man använder dessa i exemplen nedan.

## **Textvattenstämpel**

### **Lägg till en textvattenstämpel på en bild**

För att lägga till en textvattenstämpel i PPT, PPTX eller ODP kan du först lägga till en form på bilden och sedan lägga till en textram i den formen. Textramen representeras av gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/). Denna typ är inte ärvd från [IShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/), som har ett brett urval av egenskaper för att positionera vattenstämpeln på ett flexibelt sätt. Därför omsluts [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/)‑objektet i ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)‑objekt. För att lägga till vattenstämpeltext i formen, använd metoden [addTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) som visas nedan.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [Hur du använder TextFrame-klassen](/slides/sv/androidjava/text-formatting/)
{{% /alert %}}

### **Lägg till en textvattenstämpel i en presentation**

Om du vill lägga till en textvattenstämpel i hela presentationen (dvs. alla bilder på en gång) lägger du till den i [MasterSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/masterslide/). Resten av logiken är densamma som när du lägger till en vattenstämpel på en enskild bild — skapa ett [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/)‑objekt och lägg sedan till vattenstämpeln i det med metoden [addTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="See also" %}} 
- [Hur du använder bild‑mastern](/slides/sv/androidjava/slide-master/)
{{% /alert %}}

### **Ställ in formens transparens för vattenstämpeln**

Som standard är rektangelformen formaterad med fyllnings‑ och linjefärger. Följande kodrader gör formen transparent.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Ställ in teckensnittet för en textvattenstämpel**

Du kan ändra teckensnittet för textvattenstämpeln som visas nedan.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Ställ in färg för vattenstämpelns text**

För att ange färgen på vattenstämpelns text, använd följande kod:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Centrera en textvattenstämpel**

Det är möjligt att centrera vattenstämpeln på en bild, och för att göra det kan du göra följande:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Bilden nedan visar slutresultatet.

![Textvattenstämpeln](text_watermark.png)

## **Bildvattenstämpel**

### **Lägg till en bildvattenstämpel i en presentation**

För att lägga till en bildvattenstämpel på en presentationsbild kan du göra följande:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Lås en vattenstämpel från redigering**

Om det är nödvändigt att förhindra att en vattenstämpel redigeras, använd metoden [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) på formen. Med denna egenskap kan du skydda formen från att väljas, ändras storlek, flyttas, grupperas med andra element, låsa dess text från redigering och mycket mer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Lås vattenstämpelformen från att modifieras
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Flytta en vattenstämpel till förgrunden**

I Aspose.Slides kan Z‑ordningen för former ställas in via metoden [IShapeCollection.reorder](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). För att göra detta måste du anropa metoden från presentationsbildlistan och skicka in formreferensen samt dess ordningsnummer. På så sätt går det att föra en form till förgrunden eller skicka den till bakgrunden på bilden. Denna funktion är särskilt användbar om du behöver placera en vattenstämpel framför presentationen:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Ställ in rotation för vattenstämpeln**

Här är ett kodexempel som visar hur du justerar rotationen för vattenstämpeln så att den placeras diagonalt över bilden:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Ange ett namn för en vattenstämpel**

Aspose.Slides låter dig ange ett namn för en form. Genom att använda formens namn kan du i framtiden komma åt den för att ändra eller ta bort den. För att ange namn på vattenstämpelformen, tilldela det med metoden [IAutoShape.setName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Ta bort en vattenstämpel**

För att ta bort vattenstämpelformen, använd metoden [IAutoShape.getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getName--) för att hitta den i bildens former. Sedan skickar du vattenstämpelformen till metoden [IShapeCollection.remove](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

### Vad är en vattenstämpel och varför bör jag använda den?

En vattenstämpel är en text‑ eller bildöverlägg som appliceras på bilder och hjälper till att skydda immateriella rättigheter, stärka varumärkesigenkänning eller förhindra obehörig användning av presentationer.

### Kan jag lägga till en vattenstämpel på alla bilder i en presentation?

Ja, Aspose.Slides låter dig programatiskt lägga till en vattenstämpel på varje bild i en presentation. Du kan iterera igenom alla bilder och applicera vattenstämpelinställningarna individuellt.

### Hur kan jag justera transparensen för vattenstämpeln?

Du kan justera transparensen för vattenstämpeln genom att ändra fyllningsinställningarna ([getFillFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getFillFormat--)) för formen. Detta gör att vattenstämpeln blir subtil och inte distraherar från bildens innehåll.

### Vilka bildformat stöds för vattenstämplar?

Aspose.Slides stöder olika bildformat såsom PNG, JPEG, GIF, BMP, SVG och flera fler.

### Kan jag anpassa teckensnitt och stil för en textvattenstämpel?

Ja, du kan välja vilket teckensnitt, storlek och stil som helst för att matcha designen av din presentation och upprätthålla varumärkeskonsekvens.

### Hur ändrar jag position eller orientering för en vattenstämpel?

Du kan programatiskt justera position och orientering för vattenstämpeln genom att ändra formens koordinater, storlek och rotationsegenskaper.