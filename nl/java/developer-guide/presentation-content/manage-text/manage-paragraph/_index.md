---
title: Beheer PowerPoint-tekstalinea's in Java
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingsteken beheren
- alinea-insprong
- hangende insprong
- alinea-opsommingsteken
- genummerde lijst
- opsommingslijst
- alinea-eigenschappen
- HTML importeren
- tekst naar HTML
- alinea naar HTML
- alinea naar afbeelding
- tekst naar afbeelding
- alinea exporteren
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java stelt tekst voor als een hiërarchie van tekstframes, alinea’s en delen:

* [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑collectie.
* [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de delen en alinea‑niveau opmaak.
* [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) vertegenwoordigt een tekstreeks binnen een alinea. Elk deel kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan dus tekst met verschillende lettertypen, kleuren, groottes en andere opmaak bevatten door meerdere delen te gebruiken.

## **Alinea’s maken en opmaken**

### **Alinea’s maken met meerdere delen**

De volgende stappen maken een tekstframe met drie alinea’s, elk met drie delen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via het indexnummer.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat reeds één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getPortionFormat--).
9. Sla de gewijzigde presentatie op.

Dit Java‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken verwante items makkelijker scanbaar. In Aspose.Slides worden lijstop­stellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via het indexnummer.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de gekozen dia.
4. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/) en geef het opsommingsteken op.
8. Stel de alinea‑tekst, inspringing, opsommingstekstkleur en opsommingstekengrootte in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/).
11. Configureer de stijl van het genummerde opsommingsteken en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit Java‑voorbeeld maakt een symbool‑opsomming en een genummerde opsomming:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten u een aangepast beeld in plaats van een symbool of nummer gebruiken.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via het indexnummer.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe en open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad het opsommingsteken‑beeld en voeg het toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ippimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraph/) en stel de tekst in.
7. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/).
8. Koppel het beeld via [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#getPicture--) en stel de opsommingstekengrootte in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit Java‑voorbeeld maakt een afbeeldings‑opsommingsteken:

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

### **Een meerlagige lijst maken**

Stel [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) in om alinea’s op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) en open een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea’s en configureer hun opsommingstekensymbolen.
4. Stel hun [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit Java‑voorbeeld maakt een vier‑niveaus opsomming:

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

### **Genummerde lijstitems starten met aangepaste waarden**

Gebruik [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) om het initiële nummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea’s.
4. Stel [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) in op `2`, `3` en `7` voor de respectieve alinea’s.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit Java‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen beheren**

### **Een eerste‑regels‑insprong instellen**

Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) om de eerste‑regels‑insprong van een alinea te bepalen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de resterende regels op de alinea‑lichaam blijven uitgelijnd.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de volledige alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea’s en past verschillende [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden toe om te laten zien hoe de eerste‑regels‑insprong de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak diverse alinea’s en stel verschillende [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden in.
6. Voeg de alinea’s toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insprong instelt:

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

Resultaat:

![De eerste‑regels‑insprong van de alinea’s](first_line_indent.png)

### **Een hangende insprong instellen**

Een hangende insprong is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Geef een negatieve waarde door om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk bepaalt [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkermarge van het alinea‑lichaam, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Voor een hangende insprong geeft u een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenregisters en andere alinea’s waarbij de regelomslag onder het alinea‑lichaam moet uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe aan de dia.
4. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea’s en geef een positieve waarde door aan [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) voor elke alinea.
6. Geef een negatieve waarde door aan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setIndent-float-) om het hangende‑insprong‑effect te verkrijgen.
7. Voeg de alinea’s toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insprong voor een alinea instelt:

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

Resultaat:

![De hangende insprong van de alinea’s](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) bepaalt de opmaak van het einde‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) en open een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe en wis de standaard alinea.
3. Maak twee alinea’s en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) en [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) in.
6. Koppel het formaat met [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) en sla de presentatie op.

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

## **Aantal gerenderde regels tellen**

Gebruik [IParagraph.getLinesCount](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getLinesCount--) om het aantal regels te bepalen dat een alinea in beslag neemt na de tekst‑lay‑out, inclusief automatische regelomslag. Dit is nuttig bij het controleren van tekenslengte en lay‑out in presentatiesjablonen.

Een alinea is één item in [ITextFrame.getParagraphs](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getParagraphs--), en kan meerdere gerenderde regels beslaan. Een expliciete regeleinde‑invoer binnen een alinea dwingt een nieuwe regel zonder een nieuwe alinea te maken. Automatische regelomslag creëert regels op basis van de beschikbare breedte zonder expliciete regeleinde‑tekens in de tekst. Het tellen van alinea’s of regeleinde‑karakters geeft daarom niet het gerenderde aantal regels.

Het volgende voorbeeld maakt een tekst­vorm, telt de regels, verkleint de vorm en vervangt vervolgens de tekst door een kortere string. Omwikkeling is ingeschakeld en autofit uitgeschakeld zodat de vormbreedte de omwikkeling bepaalt zonder de tekst automatisch te verkleinen of de vorm te herschalen. Vormafmetingen zijn in punten. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regels van het hele tekstframe op.

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

Met deze tekst en afmetingen leidt het versmallen van de vorm tot een hoger regel‑aantal, terwijl het vervangen van de tekst door de korte string dit verlaagt. Exacte aantallen kunnen variëren afhankelijk van de beschikbare lettertypen, substitutie, lettergrootte, marges, inspringing, omwikkeling en autofit‑instellingen. Gebruik de lettertypen en lay‑out‑instellingen die voor de doelomgeving bedoeld zijn bij het controleren van een sjabloon.

Het aantal regels alleen bepaalt niet of de tekst buiten de container stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand, en autofit‑gedrag zijn eveneens van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer omwikkeling uitgeschakeld is.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea’s**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) om HTML‑opmaak om te zetten in alinea’s en delen binnen een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse.
2. Open een dia en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) toe.
3. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm en wis de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑tekst door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Sla de gewijzigde presentatie op.

Dit Java‑voorbeeld importeert HTML in een tekstframe:

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

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) om een geselecteerd bereik van alinea’s als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑klasse en laad de gewenste presentatie.
2. Open de dia en vind de [IAutoShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iautoshape/) die de tekst bevat.
3. Open het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aan met de start‑alinea‑index en het aantal alinea’s dat geëxporteerd moet worden.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Java‑voorbeeld exporteert alle alinea’s van de eerste tekstvorm:

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

### **Een alinea renderen als afbeelding**

[IParagraph.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getImage--) rendert een enkele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/). Sla het resultaat op in een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iimage/#save-java.lang.String-int-). U hoeft de omvattende vorm niet te renderen of handmatig een bitmap bij te snijden.

[IParagraph.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getImage--) kan `null` retourneren als de alinea niet gevonden wordt in de bovenliggende collectie, geen geldige render‑bounds heeft, of niet gerenderd kan worden. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding vrij na gebruik.

#### **Een alinea renderen op de standaard schaal**

Stel dat we een presentatie‑bestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is met drie alinea’s.

![Het tekstvak met drie alinea’s](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een regulier tekstvak op de standaard schaal en slaat de verkregen afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

Resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaling**

Gebruik de overload van [IParagraph.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getImage-float-float-) die `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaard breedte en hoogte, en slaat het resultaat op als een PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding op waarvan breedte en hoogte ongeveer het dubbele zijn, oftewel vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor zoomen of hoge‑resolutie‑output, maar verhogen ook het geheugen‑ en bestandsgroottegebruik. Factoren onder `1` leveren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Het renderen van een volledige vorm met [IShape.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getImage--) blijft nuttig wanneer het resultaat ook de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een uitsluitend alinea‑afbeelding gebruikt u [IParagraph.getImage](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Kan ik regelomslagen binnen een tekstframe volledig uitschakelen?**

Ja. Stel [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) in om omwikkeling te deactiveren zodat regels niet breken aan de randen van het tekstframe.

**Hoe krijg ik de exacte on‑dia‑bounds van een specifieke alinea?**

Gebruik [IParagraph.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getRect--) om het begrenzende rechthoek van de alinea op te halen. [IPortion.getRect](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/#getRect--) geeft de bounds van een individueel deel.

**Waar wordt alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) is een alinea‑niveau instelling en wordt toegepast op de volledige alinea, ongeacht de opmaak van individuele delen.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.