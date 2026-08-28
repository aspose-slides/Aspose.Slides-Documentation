---
title: Hantera PowerPoint-textstycken på Android
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
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
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punktlistor, numrerade listor, indrag, HTML-innehåll och stycke-bilder med Aspose.Slides för Android via Java."
---
## **Översikt**

Aspose.Slides för Android via Java representerar text som en hierarki av textramar, stycken och delar:

* [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess styckesamling.
* [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess delar samt stycke‑nivåformatering.
* [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/) representerar en textkörning inom ett stycke. Varje del kan ha sin egen text och tecken‑nivåformatering.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, där varje innehåller tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Använd standardstycket och lägg till två ytterligare [IParagraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/)‑objekt till textramen.
6. Lägg till tillräckligt med [IPortion](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/)‑objekt så att varje stycke innehåller tre delar. Standardstycket innehåller redan en tom del.
7. Ställ in texten för varje del.
8. Applicera tecken‑nivåformatering via [IPortion.getPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Spara den modifierade presentationen.

Detta Android via Java‑exempel implementerar stegen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Skapa punkt- och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) till den valda bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) för en symbolpunkt.
7. Ställ in [IBulletFormat.setType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/bullettype/) och ange punkttecknet.
8. Ställ in styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och sätt [IBulletFormat.setType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta Android via Java‑exempel skapar en symbolpunkt och en numrerad punkt:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller ett nummer.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till den relevanta bilden via dess index.
3. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) och få åtkomst till dess [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ippimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraph/) och sätt dess text.
7. Ställ in [IBulletFormat.setType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setType-int-) till [BulletType.Picture](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/bullettype/).
8. Tilldela bilden via [IBulletFormat.getPicture](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#getPicture--) och sätt punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den modifierade presentationen.

Detta Android via Java‑exempel skapar en bildpunkt:

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

Använd [IParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) för att placera stycken på olika nivåer i en lista. Toppnivån har ett djup på `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och få åtkomst till en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) och rensa bort standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkt‑symboler.
4. Ställ in deras [IParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)‑värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta Android via Java‑exempel skapar en fyranivåpunktlista:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Använd [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) för att ange det initiala numret som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på en bild.
2. Rensa bort standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ställ in [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) till `2`, `3` och `7` för respektive stycke.
5. Lägg till styckena i textramen och spara presentationen.

Detta Android via Java‑exempel tilldelar ett eget startnummer till varje stycke:

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

## **Styr stycke‑layout och slut‑egenskaper**

### **Ställ in ett första rad‑indrag**

Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) för att styra första rad‑indraget i ett stycke. Denna metod flyttar endast den första raden relativt styckets vänstra marginal. Ett positivt värde förflyttar den första raden åt höger, medan de återstående raderna förblir justerade till styckets kropp.

Använd [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) när du behöver flytta hela stycket. Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) när du bara behöver flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [IParagraphFormat.setIndent]-värden för att demonstrera hur första rad‑indraget påverkar stycke‑layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [IParagraphFormat.setIndent]-värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Första rad‑indraget för styckena](first_line_indent.png)

### **Ställ in ett hängande indrag**

Ett hängande indrag är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [IParagraphFormat.setIndent]. Skicka ett negativt värde för att flytta den första raden åt vänster relativt styckets kropp.

I praktiken definierar [IParagraphFormat.setMarginLeft] den vänstra positionen för styckets kropp, och [IParagraphFormat.setIndent] definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, skicka ett positivt värde till `setMarginLeft` och ett negativt värde till `setIndent`.

Denna formatering är användbar för bibliografier, referenser, ordlistaposter och andra stycken där radbrytningar måste justeras under styckets kropp snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till mål‑bilden.
3. Lägg till en rektangulär [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) på bilden.
4. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) och ta bort standardstycket.
5. Skapa stycken och skicka ett positivt värde till [IParagraphFormat.setMarginLeft] för varje stycke.
6. Skicka ett negativt värde till [IParagraphFormat.setIndent] för att skapa det hängande indraget.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Det hängande indraget för styckena](hanging_indent.png)

### **Ställ in slut‑stycke‑körnings‑egenskaper**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) kontrollerar formateringen av styckets slutmarkering. Följande exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till slutmarkeringen för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och få åtkomst till en bild.
2. Lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portionformat/) för det andra styckets slutmarkering.
5. Ställ in [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) och [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Tilldela formatet med [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) och spara presentationen.

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

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text i stycken**

Använd [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) för att konvertera HTML‑markup till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/).
2. Få åtkomst till en bild och lägg till en [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/).
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Spara den modifierade presentationen.

Detta Android via Java‑exempel importerar HTML i en textram:

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

### **Exportera stycketext till HTML**

Använd [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) för att exportera ett valt intervall av stycken som HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) och läs in den önskade presentationen.
2. Få åtkomst till bilden och hitta den [IAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iautoshape/) som innehåller texten.
3. Få åtkomst till formens [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/).
4. Anropa [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) med start‑stycke‑indexet och antalet stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta Android via Java‑exempel exporterar alla stycken från den första textformen:

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

### **Rendera ett stycke som bild**

[IParagraph.getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/#getImage--) renderar ett enskilt stycke direkt och returnerar ett [IImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph.getImage] kan returnera `null` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och frisläpp den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG-format. `finally`‑blocket säkerställer att bilden frigörs korrekt.

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

![Stycke‑bilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [IParagraph.getImage]-överladdningen som accepterar `float scaleX` och `float scaleY`-parametrar för att ställa in horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så bred och hög som standard, och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln i dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger generellt skarpare text för zoomning eller högupplöst utskrift, men de ökar även minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker ut resultatet oberoende.

Att rendera en hel form med [IShape.getImage] är fortfarande användbart när utdata måste inkludera formens fyllning, kant eller annan visuell kontext. För en endast‑stycke‑bild, använd [IParagraph.getImage].

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ställ in [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) för att inaktivera radbrytning så att rader inte bryts vid textrams kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [IParagraph.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraph/#getRect--) för att hämta styckets avgränsande rektangel. [IPortion.getRect](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iportion/#getRect--) ger gränserna för en enskild del.

**Var styrs styckejustering (vänster, höger, centrerad eller justerad)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) är en stycke‑nivåinställning och gäller hela stycket oavsett individuell del‑formatering.

**Kan jag ange korrekturläsningsspråk för en del av ett stycke?**

Ja. Ställ in [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) för enskilda delar, så att ett stycke kan innehålla text på flera språk.