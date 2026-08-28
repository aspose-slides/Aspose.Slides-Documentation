---
title: Hantera PowerPoint-textstycken i Java
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- lägg till text
- lägg till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punkter, numrerade listor, indrag, HTML‑innehåll och styckebilder med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java representerar text som en hierarki av textramar, stycken och delar:

* [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess stycke‑samling.
* [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess delar och format på styckennivå.
* [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/) representerar en textrun inom ett stycke. Varje del kan ha sin egen text och teckensnittsformat på teckennivå.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, där varje stycke innehåller tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) till bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
5. Använd standardstycket och lägg till två ytterligare [IParagraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/)-objekt till textramen.
6. Lägg till tillräckligt med [IPortion](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/)-objekt för att varje stycke ska innehålla tre delar. Standardstycket innehåller redan en tom del.
7. Ange texten för varje del.
8. Applicera teckennivå‑formatering via [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skapa punkt‑ och numrerade listor**

### **Skapa en punkt‑ eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) till den valda bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) för en symbolpunkt.
7. Ange [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/) och specificera punkttecknet.
8. Ange styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och ange [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller siffra.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) och få åtkomst till dess [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ippimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraph/) och ange dess text.
7. Ange [IBulletFormat.setType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Picture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/bullettype/).
8. Tilldela bilden via [IBulletFormat.getPicture](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#getPicture--) och ange punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Skapa en flernivålista**

Ange [IParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setDepth-short-) för att placera stycken på olika nivåer i en lista. Översta nivån har ett djup på `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och öppna en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkttecken.
4. Ange deras [IParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setDepth-short-)‑värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Starta numrerade listobjekt med egna värden**

Använd [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) för att ange startnumret för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) till en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ange [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) till `2`, `3` och `7` för respektive stycke.
5. Lägg till styckena i textramen och spara presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr styckeslayout och slutegenskaper**

### **Ange indrag för första raden**

Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) för att styra indraget för första raden i ett stycke. Denna metod flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade till styckets kropp.

Använd [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) när du behöver flytta hela stycket. Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden för att demonstrera hur första‑radens indrag påverkar layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Öppna målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) till bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa flera stycken och ange olika [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Indrag för första raden i styckena](first_line_indent.png)

### **Ange hängande indrag**

Ett hängande indrag är en styckeslayout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Ange ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) den vänstra positionen för styckets kropp, och [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, ange ett positivt värde till `setMarginLeft` och ett negativt värde till `setIndent`.

Denna formatering är användbar för bibliografier, referenser, glossarposter och andra stycken där radbrytningar ska ligga under styckets kropp snarare än under den första tecknet i första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Öppna målbilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) till bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa stycken och ange ett positivt värde till [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) för varje stycke.
6. Ange ett negativt värde till [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setIndent-float-) för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Hängande indrag för styckena](hanging_indent.png)

### **Ange slut‑stycke‑körningsegenskaper**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) styr formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till slutmarkeringen för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och öppna en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/portionformat/) för slutmarkeringen av det andra stycket.
5. Ange [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) och [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Tilldela formatet med [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) och spara presentationen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Import och export av styckeinnehåll**

### **Importera HTML‑text till stycken**

Använd [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) för att konvertera HTML‑markup till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/).
2. Öppna en bild och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/).
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Exportera styckettext till HTML**

Använd [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) för att exportera ett markerat intervall av stycken som HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) och läs in önskad presentation.
2. Öppna bilden och hitta den [IAutoShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshape/) som innehåller texten.
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/).
4. Anropa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) med start‑stycke‑index och antalet stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Rendera ett stycke som en bild**

[IParagraph.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getImage--) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.save](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getImage--) kan returnera `null` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke med standardskala**

Anta att vi har en presentationsfil som heter *sample.pptx* med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta med standardskala och sparar den returnerade bilden i PNG‑format. `finally`‑blocket säkerställer att bilden frigörs korrekt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Resultatet:

![Bild av stycket](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd överlagringen av [IParagraph.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getImage-float-float-) som accepterar parametrarna `float scaleX` och `float scaleY` för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard, och sparar resultatet som en PNG‑bild.

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

En skalningsfaktor på `1` behåller den axeln i dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket ger fyra gånger så många pixlar. Större faktorer ger i allmänhet skarpare text för zoomning eller högupplöst utskrift, men ökar även minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detaljrikedom. Använd lika faktorer för att bevara bildförhållandet; olika horisontella och vertikala faktorer sträcker bilden oberoende.

Att rendera en hel form med [IShape.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getImage--) är fortfarande användbart när utdata måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart stycke‑bild, använd [IParagraph.getImage](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ange [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) för att inaktivera radbrytning så att rader inte bryts vid textrams kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraph/#getRect--) för att hämta styckets omgivande rektangel. [IPortion.getRect](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iportion/#getRect--) ger gränserna för en enskild del.

**Var styrs styckejusteringen (vänster, höger, centrerad eller marginaljusterad)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) är en inställning på styckennivå och gäller hela stycket oavsett formatering av enskilda delar.

**Kan jag ange korrekturspråk för en del av ett stycke?**

Ja. Ange [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) för enskilda delar, så att ett stycke kan innehålla text på flera språk.