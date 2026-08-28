---
title: Beheer PowerPoint‑tekstalinea's in Java
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
- alinea‑inspringing
- hangende inspringing
- alinea‑opsommingsteken
- genummerde lijst
- opsomminglijst
- alinea‑eigenschappen
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
description: "Leer hoe u alinea's, segmenten, opsommingstekens, genummerde lijsten, inspringingen, HTML‑inhoud en alinea‑afbeeldingen kunt maken en opmaken met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en segmenten:

* [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea‑collectie.
* [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de segmenten en alinea‑niveau opmaak.
* [IPortion](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iportion/) vertegenwoordigt een tekstrun binnen een alinea. Elk segment kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere segmenten te gebruiken.

## **Alinea's Maken en Opmaken**

### **Alinea's Maken met Meerdere Segmenten**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie segmenten:

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot de relevante dia via de index.
3. Voeg een rechthoekige [IAutoShape] toe aan de dia.
4. Toegang tot de [ITextFrame] van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [IParagraph] objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion] objecten toe zodat elke alinea drie segmenten bevat. De standaard alinea bevat al één leeg segment.
7. Stel de tekst van elk segment in.
8. Pas teken‑niveau opmaak toe via [IPortion.getPortionFormat].
9. Sla de aangepaste presentatie op.

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

## **Opsommingstekens en Genummerde Lijsten Maken**

### **Een Opsomming met Opsommingstekens of Nummering Maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [IBulletFormat].

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot de relevante dia via de index.
3. Voeg een [IAutoShape] toe aan de geselecteerde dia.
4. Toegang tot de [ITextFrame] van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph] voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat.setType] in op [BulletType.Symbol] en geef het opsommingsteken‑teken op.
8. Stel de alinea‑tekst, inspringing, opsommingsteken‑kleur en opsommingsteken‑hoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat.setType] in op [BulletType.Numbered].
11. Configureer de genummerde opsommingsteken‑stijl en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

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

### **Afbeeldingsopsommingstekens Gebruiken**

Afbeeldingsopsommingstekens laten je een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot de relevante dia via de index.
3. Voeg een [IAutoShape] toe en krijg toegang tot de [ITextFrame].
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de beeldcollectie van de presentatie als een [IPPImage].
6. Maak een [Paragraph] en stel de tekst in.
7. Stel [IBulletFormat.setType] in op [BulletType.Picture].
8. Wijs de afbeelding toe via [IBulletFormat.getPicture] en stel de opsommingsteken‑hoogte in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de aangepaste presentatie op.

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

### **Een Meerniveaulijst Maken**

Stel [IParagraphFormat.setDepth] in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation] en krijg toegang tot een dia.
2. Voeg een [IAutoShape] toe en maak de standaard alinea uit het tekstframe leeg.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [IParagraphFormat.setDepth] waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

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

### **Genummerde Lijstitems Beginnen met Aangepaste Waarden**

Gebruik [IBulletFormat.setNumberedBulletStartWith] om het initiële nummer in te stellen dat voor een genummerde alinea wordt weergegeven.

1. Maak een [Presentation] en voeg een [IAutoShape] toe aan een dia.
2. Maak de standaard alinea uit het tekstframe van de vorm leeg.
3. Maak drie genummerde alinea's.
4. Stel [IBulletFormat.setNumberedBulletStartWith] in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

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

## **Alinea-indeling en Eind-eigenschappen Beheersen**

### **Stel een Eerste‑Regel Inspringing In**

Gebruik [IParagraphFormat.setIndent] om de eerste‑regel inspringing van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑tekst.

Gebruik [IParagraphFormat.setMarginLeft] wanneer je de gehele alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent] wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's en past verschillende [IParagraphFormat.setIndent] waarden toe om te laten zien hoe de eerste‑regel inspringing de alinea‑indeling beïnvloedt.

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [IAutoShape] toe aan de dia.
4. Toegang tot de [ITextFrame] van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel verschillende [IParagraphFormat.setIndent] waarden voor hen in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de aangepaste presentatie op.

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

Het resultaat:

![De eerste‑regel inspringing van de alinea's](first_line_indent.png)

### **Stel een Hangende Inspringing In**

Een hangende inspringing is een alinea‑indeling waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met [IParagraphFormat.setIndent]. Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑tekst.

In de praktijk definieert [IParagraphFormat.setMarginLeft] de linkse positie van de alinea‑tekst, en definieert [IParagraphFormat.setIndent] de positie van de eerste regel ten opzichte van die marge. Om een hangende inspringing te maken, geef een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij omsluite regels moeten uitlijnen onder de alinea‑tekst in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [IAutoShape] toe aan de dia.
4. Toegang tot de [ITextFrame] van de vorm en verwijder de standaard alinea.
5. Maak alinea's en geef een positieve waarde aan [IParagraphFormat.setMarginLeft] voor elke alinea.
6. Geef een negatieve waarde aan [IParagraphFormat.setIndent] om het hangende‑inspringing‑effect te creëren.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de aangepaste presentatie op.

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

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑Alinea Run‑Eigenschappen Instellen**

[IParagraph.setEndParagraphPortionFormat] regelt de opmaak van het eind‑teken van een alinea. Het volgende voorbeeld kent een lettergrootte en Latijns lettertype toe aan het eind‑teken van de tweede alinea:

1. Laad een [Presentation] en krijg toegang tot een dia.
2. Voeg een [IAutoShape] toe en maak de standaard alinea leeg.
3. Maak twee alinea's en voeg tekstdelen toe.
4. Maak een [PortionFormat] voor het eind‑teken van de tweede alinea.
5. Stel [IBasePortionFormat.setFontHeight] en [IBasePortionFormat.setLatinFont] in.
6. Ken het format toe met [IParagraph.setEndParagraphPortionFormat] en sla de presentatie op.

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

## **Alinea-inhoud Importeren en Exporteren**

### **HTML-tekst Importeren in Alinea's**

Gebruik [ParagraphCollection.addFromHtml] om HTML‑opmaak om te zetten in alinea's en segmenten in een tekstframe.

1. Maak een instantie van de [Presentation] klasse.
2. Toegang tot een dia en voeg een [IAutoShape] toe.
3. Toegang tot de [ITextFrame] van de vorm en maak de standaard alinea leeg.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection.addFromHtml].
6. Sla de aangepaste presentatie op.

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

### **Alinea-tekst Exporteren naar HTML**

Gebruik [ParagraphCollection.exportToHtml] om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation] klasse en laad de gewenste presentatie.
2. Toegang tot de dia en vind de [IAutoShape] die de tekst bevat.
3. Toegang tot de [ITextFrame] van de vorm.
4. Roep [ParagraphCollection.exportToHtml] aan met de start‑alinea‑index en het aantal alinea's om te exporteren.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

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

### **Een Alinea Renderen als Afbeelding**

[IParagraph.getImage] rendert een individuele alinea direct en retourneert een [IImage]. Sla het resultaat op in een bestand of stream met [IImage.save]. Je hoeft niet het omvattende object te renderen of handmatig een bitmap bij te snijden.

[IParagraph.getImage] kan `null` retourneren als de alinea niet in de oudercollectie wordt gevonden, geen geldige renderingsgrenzen heeft, of niet kan worden gerenderd. Controleer het resultaat voordat je het opslaat en maak de geretourneerde afbeelding na gebruik weer vrij.

#### **Een Alinea Renderen op de Standaard Schaal**

Stel dat we een presentatie‑bestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het onderstaande voorbeeld rendert de tweede alinea in een regulier tekstvak op de standaard schaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

Het resultaat:

![De alinea-afbeelding](paragraph_to_image_output.png)

#### **Een Alinea Renderen in een Tabelcel met Schalen**

Gebruik de overload van [IParagraph.getImage] die `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het onderstaande voorbeeld maakt een tabel, rendert de alinea in de eerste cel op twee keer de standaard breedte en hoogte, en slaat het resultaat op als een PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaard pixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaard afmetingen zijn, wat vier keer zoveel pixels oplevert. Grotere factoren geven doorgaans scherpere tekst voor inzoomen of hoge‑resolutie‑uitvoer, maar verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` geven kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de aspect‑ratio van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige vorm met [IShape.getImage] blijft nuttig wanneer de uitvoer de opvulling, rand of andere visuele context van de vorm moet bevatten. Voor een alleen‑alinea‑afbeelding, gebruik [IParagraph.getImage].

## **FAQ**

**Kan ik het regelomslag in een tekstframe volledig uitschakelen?**

Ja. Stel [ITextFrameFormat.setWrapText] in om afbreken uit te schakelen zodat regels niet breken aan de randen van het tekstframe.

**Hoe kan ik de exacte on‑slide‑grenzen van een specifieke alinea verkrijgen?**

Gebruik [IParagraph.getRect] om de omtrek van de alinea op te halen. [IPortion.getRect] geeft de grenzen van een individueel segment.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[IParagraphFormat.setAlignment] is een alinea‑niveau instelling en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele segmenten.

**Kan ik de proefleestaal voor een deel van een alinea instellen?**

Ja. Stel [IBasePortionFormat.setLanguageId] in voor individuele segmenten, zodat één alinea tekst in meerdere talen kan bevatten.