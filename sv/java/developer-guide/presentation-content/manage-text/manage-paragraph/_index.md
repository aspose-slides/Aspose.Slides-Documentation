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
- lägga till text
- lägga till stycke
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
- Java
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, portioner, punkter, numrerade listor, indrag, HTML-innehåll och styckebilder med Aspose.Slides för Java."
---
## **Översikt**

Aspose.Slides for Java representerar text som en hierarki av textramar, stycken och portioner:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) representerar textbehållaren i en form och ger åtkomst till dess stycke‑samling.
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) representerar ett stycke i en textram och ger åtkomst till dess portioner och format på styckelnivå.
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) representerar ett textkörningssegment inom ett stycke. Varje portion kan ha sin egen text och teckenformat på teckennivå.

Ett stycke kan därför innehålla text med olika typsnitt, färger, storlekar och annat format genom att använda flera portioner.

## **Skapa och formatera stycken**

Skapa stycken i en formers textram och använd portioner för att formatera enskilda textkörningar. Detta avsnitt visar hur du kombinerar flera portioner inom varje stycke och tillämpar olika färger, teckenstorlekar och stilar.

### **Skapa stycken med flera portioner**

Följande Java‑exempel skapar tre stycken, var och en innehållande tre textkörningar i samlingen som returneras av [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--)‑samlingen. Det återanvänder standardstycket och dess tomma portion, för att sedan lägga till de återstående styckena och portionerna. Formatering appliceras via [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--): den första portionen i varje stycke är röd, fetstil och 15 punkter; den andra är blå, kursiv och 18 punkter. Den tredje portionen behåller sin standardformatering:

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

## **Skapa punktlistor och numrerade listor**

Organisera stycke‑text i listor med symboler, siffror eller anpassade bilder. Exemplen i detta avsnitt täcker punktformat, flernivålistor och anpassade startnummer.

### **Skapa en punktlista eller numrerad lista**

Punkter och numrering gör relaterade objekt lättare att skanna. I Aspose.Slides definieras listinställningar via [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/).

Detta Java‑exempel lägger till en symbolpunkt och ett numrerat objekt i samma textram. [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) väljer punkt‑typen, medan [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) anger symbolen och [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) väljer numreringsstilen. Båda objekten använder svarta punkter med en höjd på 100 procent och ett stycke‑indrag på 25 punkter:

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

Bildpunkter låter dig använda en anpassad bild i stället för en symbol eller siffra.

Detta Java‑exempel lägger till en bild i presentationens bildsamling som en [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) och använder den som styckepunkt. Det anropar [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) för att använda en bildpunkt och tilldelar bilden via [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) sätts till 100 procent för att dimensionera punkten relativt stycke‑texten:

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

Ställ in [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) för att placera stycken på olika nivåer i en lista. Toppenivån har ett djup på `0`.

Detta Java‑exempel tilldelar [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-)‑värden från 0 till 3 till fyra stycken, vilket skapar en hierarki inom en textram. Varje stycke använder en symbolpunkt, där [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) växlar mellan en rund punkt och ett bindestreck för att skilja närliggande nivåer:

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

### **Starta numrerade listobjekt med anpassade värden**

Använd [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) för att ange det initiala numret som visas för ett numrerat stycke.

Detta Java‑exempel ställer in [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) för att använda numrering i tre stycken och tilldelar [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) värdena 2, 3 och 7. Startvärdet konfigureras separat för varje stycke, så att de visade siffrorna kan hoppa över värden:

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

## **Styr stycke layout och slutegenskaper**

Justera styckemarginaler och indrag för att kontrollera positionen för den första raden och rader som radbryts. Du kan också formatera stycke‑slutmärket separat från de synliga textportionerna.

### **Ange indrag för första raden**

Använd metoden [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) för att kontrollera indraget för den första raden i ett stycke. Denna inställning flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade mot styckets huvudtext.

Använd [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) när du vill flytta hela stycket. Använd [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) när du bara vill flytta den första raden.

Följande exempel ger tre stycken samma [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) på 20 punkter och [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden på 0, 20 och 40 punkter. Första raderna börjar vid successivt större avstånd, medan radbrytade rader behåller samma vänstra marginal:

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

Ett hängande indrag är en stycke‑layout där den första raden startar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Sätt `Indent` till ett negativt värde för att flytta den första raden åt vänster relativt styckets huvudtext.

I praktiken definierar [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) den vänstra positionen för styckets huvudtext, och [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, ordlistposter och andra stycken där radbrytade rader måste justeras under styckets huvudtext snarare än under den första teckenpositionen i första raden.

Följande Java‑exempel parar ihop [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-)‑värden på 40 och 60 punkter med [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-)‑värden på –20 och –30 punkter. I varje stycke startar den första raden till vänster om de radbrytade raderna; det andra stycket har ett djupare hängande indrag:

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

![Det hängande indraget i styckena](hanging_indent.png)

### **Ange egenskaper för styckeslut**

Metoden [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) styr formateringen av styckeslutmärket. Följande exempel skapar ett [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) med [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) satt till 48 punkter och [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) satt till Times New Roman. Det tilldelar detta format till det andra styckets slutmärke, utan att ändra de synliga textportionerna:

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

## **Räkna renderade rader**

För styckeregler som påverkar automatisk radbrytning och interpunktion vid radslut, se [Control Line Breaking](/slides/sv/java/text-formatting/#control-line-breaking) och [Control Hanging Punctuation](/slides/sv/java/text-formatting/#control-hanging-punctuation).

Använd [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) för att räkna antalet rader som ett stycke upptar efter textlayout, inklusive automatisk radbrytning. Detta är användbart när du kontrollerar textlängd och layout i presentationsmallar.

Ett stycke är ett objekt i [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--), och det kan uppta flera renderade rader. Ett explicit radbrytningstecken i ett stycke tvingar en ny rad utan att skapa ett nytt stycke. Automatisk radbrytning skapar rader baserat på tillgänglig bredd utan att infoga explicita radbrytningstecken i texten. Att räkna stycken eller radbrytningstecken ger därför inte det renderade radantalet.

Följande exempel skapar en textruta, räknar dess rader, smalnar av formen och ersätter sedan texten med en kortare sträng. Exemplet aktiverar radbrytning med [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) och inaktiverar autofit med [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) så att formens bredd styr radbrytning utan att automatiskt minska texten eller storleken på formen. Varje mätning använder [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--). Formens dimensioner anges i punkter. Slutligen lägger exemplet till ett ytterligare stycke och summerar radantalet över hela textramen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

Med denna text och dessa dimensioner ökar radantalet när formen smalnas av, medan ersättning av texten med den korta strängen minskar det. Exakta siffror kan variera beroende på tillgängliga typsnitt och ersättningar, typsnittsstorlek, marginaler, indrag, radbrytning och autofit‑inställningar. Använd de typsnitt och layoutinställningar som är avsedda för målmiljön när du kontrollerar en mall.

Radantalet i sig avgör inte om texten överskrider sin behållare. Tillgänglig höjd, radhöjder, stycke‑ och radavstånd samt autofit‑beteende spelar också in; även en enstaka rad kan överskrida den tillgängliga bredden när radbrytning är inaktiverad.

## **Importera och exportera styckeinnehåll**

Använd HTML för att föra in text i en presentation eller exportera befintliga stycken för användning utanför den. Detta avsnitt visar också hur du renderar enskilda stycken som bilder, inklusive stycken i tabellceller.

### **Importera HTML-text till stycken**

Använd [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) för att konvertera HTML‑markup till stycken och portioner i en textram.

Detta Java‑exempel läser HTML från en fil och skickar markupen till [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). Det rensar textramens standardstycke så att ramen endast innehåller den importerade innehållet. Den rektangulära formen lämnar en marginal på 10 punkter på varje sida av bilden:

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

Använd [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) för att exportera ett valt intervall av stycken som HTML. När du återanvänder presentations‑text på en webbplats kan du vilja bevara lokal betoning utan att föra med dig presentationens typsnitt, storlek eller textrute‑stilar. Ställ in [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) för att kontrollera hur långt exportören följer format­arv.

Ladda ner [exempel‑presentationen](text-inheritance.pptx) och placera den i applikationens arbetskatalog. Dess första bild innehåller en textruta med texten "Inherited text; explicit red 18pt". Indatan använder avsiktligt flera formateringsnivåer:

- Presentationens standard‑textstil levererar Calibri i storlek 28 pt.
- Textrammens förstaspråks‑stil levererar blå text och kursiv.
- Stycket anger explicit fet stil.
- Den andra portionen, "explicit red 18pt", anger explicit röd text och storlek 18 pt.

Följande kompletta exempel exporterar samma stycken tre gånger. Det skickar [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) till export‑metoden och skriver varje resultat till en separat UTF‑8‑HTML‑fil:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
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

Den genererade HTML‑koden innehåller följande CSS för den första portionen, "Inherited text; ". Tabellen listar de relevanta deklarationerna; andra genererade egenskaper har utelämnats för tydlighet.

| Utdata | Relevant CSS för den första portionen | Utseende |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text på 28 pt i Calibri, om det typsnittet finns tillgängligt. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Blå, fet, kursiv text; omgivande sida eller webbläsare tillhandahåller typsnittsfamilj och storlek. |
| `ParagraphOnly.html` | `font-weight:bold` | Fet text; omgivande sida eller webbläsare tillhandahåller typsnittsfamilj, storlek, färg och kursiv stil. |

Den andra portionen behåller `color:#ff0000`, `font-size:18pt` och `font-weight:bold` i alla tre utdata. Den behåller också kursiv i `All` och `TextBox`, men inte i `ParagraphOnly`. Att begränsa arv tar alltså inte bort formatering som uttryckligen tilldelats ett stycke eller en portion.

Öppna filerna i samma webbläsare för att jämföra dem. I de två begränsade lägena fylls utelämnade CSS‑egenskaper i efterhand av destinationssidans stilar eller webbläsarstandarder, så det slutliga utseendet beror på var HTML‑filen används.

### **Rendera ett stycke som en bild**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) kan returnera `null` om stycket inte kan hittas i dess föräldrasamling, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke med standardskala**

Exemplet använder en presentation med en bild där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel väljer det andra stycket på index 1 och anropar [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) utan skalningsparametrar. Det kontrollerar att formen innehåller det begärda stycket och att renderingen returnerar en bild innan den anropar [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) för att spara den i PNG‑format. `finally`‑blocket frigör bilden efter användning.

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

![Stycke bilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-)‑överladdning som accepterar `float scaleX` och `float scaleY`‑parametrar för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt standardbredd och -höjd och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln i dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standarddimensionerna, vilket ger fyra gånger så många pixlar. Större faktorer ger generellt skarpare text för zoomning eller högupplöst utskrift, men de ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detaljrikedom. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker utskriften oberoende av varandra.

Att rendera en hel form med [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) är fortfarande användbart när utskriften måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart bild av ett stycke, använd [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--).

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i ett textram?**

Ja. Ställ in [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) för att inaktivera radbrytning så att rader inte bryts vid textrammens kanter.

**Hur kan jag få exakt på‑bild‑gräns för ett specifikt stycke?**

Använd [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) för att hämta styckets omgivande rektangel. [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) ger gränserna för en enskild portion.

**Var styrs styckejustering (vänster, höger, centrerat eller marginaljustering)?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) är en inställning på stycknivå och gäller hela stycket oavsett individuell portionsformatering.

För att vertikalt justera portioner med olika teckenstorlekar inom varje rad, se [Align Fonts Within a Line](/slides/sv/java/text-formatting/#align-fonts-within-a-line).

**Kan jag ange språkgranskning för en del av ett stycke?**

Ja. Ställ in [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) för enskilda portioner, så att ett stycke kan innehålla text på flera språk.