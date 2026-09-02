---
title: Beheer PowerPoint-tekst alinea’s op Android
linktitle: Alinea beheren
type: docs
weight: 40
url: /nl/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea insprong
- hangende insprong
- alinea opsommingsteken
- genummerde lijst
- opsomming met opsommingstekens
- alinea-eigenschappen
- HTML importeren
- tekst naar HTML
- alinea naar HTML
- alinea naar afbeelding
- tekst naar afbeelding
- alinea exporteren
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u alinea’s, porties, opsommingstekens, genummerde lijsten, inspringingen, HTML‑inhoud en alinea‑afbeeldingen kunt maken en opmaken met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea’s en porties:

* [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) vertegenwoordigt de tekstopslag in een vorm en biedt toegang tot de alinea‑collectie.
* [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de porties en alinea‑niveau opmaak.
* [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) vertegenwoordigt een tekstgedeelte binnen een alinea. Elke portie kan zijn eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst met verschillende lettertypes, kleuren, groottes en andere opmaak bevatten door meerdere porties te gebruiken.

## **Alinea’s maken en opmaken**

### **Alinea’s met meerdere porties maken**

De volgende stappen maken een tekstframe met drie alinea’s, elk met drie porties:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [IParagraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [IPortion](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/) objecten toe zodat elke alinea drie porties bevat. De standaardalinea bevat al één lege portie.
7. Stel de tekst van elke portie in.
8. Pas teken‑niveau opmaak toe via [IPortion.getPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getPortionFormat--).
9. Sla de gewijzigde presentatie op.

Dit Android‑via‑Java‑voorbeeld implementeert de stappen:

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

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items beter scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [IBulletFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/) en geef het opsommingsteken op.
8. Stel de alinea‑tekst, insprong, kleur en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/).
11. Configureer de genummerde opsommingstijlen en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit Android‑via‑Java‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

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

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten u een eigen afbeelding gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de gewenste dia via de index.
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe en verkrijg diens [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/).
4. Verwijder de standaardalinea uit het tekstframe.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingscollectie van de presentatie als een [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraph/) en stel de tekst in.
7. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-int-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/).
8. Koppel de afbeelding via [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#getPicture--) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit Android‑via‑Java‑voorbeeld maakt een afbeelding‑opsommingsteken:

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

Stel [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) in om alinea’s op verschillende niveaus van een lijst te plaatsen. Het hoogste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en open een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe en verwijder de standaardalinea uit het tekstframe.
3. Maak vier alinea’s en configureer hun opsommingstekensymbolen.
4. Stel hun [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit Android‑via‑Java‑voorbeeld maakt een vier‑niveau lijst:

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

### **Genummerde items starten met aangepaste waarden**

Gebruik [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) om het beginnummer van een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan een dia.
2. Verwijder de standaardalinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea’s.
4. Stel [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) in op `2`, `3` en `7` voor respectievelijk de alinea’s.
5. Voeg de alinea’s toe aan het tekstframe en sla de presentatie op.

Dit Android‑via‑Java‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen regelen**

### **Eerste‑regelig insprong instellen**

Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) om de eerste‑regelig insprong van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑body.

Gebruik [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) wanneer u de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea’s en past verschillende [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden toe om te laten zien hoe de eerste‑regelig insprong de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
5. Maak verschillende alinea’s en stel voor elk verschillende [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) waarden in.
6. Voeg de alinea’s toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een alinea‑insprong instelt:

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

Resultaat:

![De eerste‑regelig insprong van de alinea’s](first_line_indent.png)

### **Hangende insprong instellen**

Een hangende insprong is een alinea‑lay‑out waarbij de eerste regel links van de overige regels start. In Aspose.Slides creëert u dit effect met [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Geef een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑body.

In de praktijk bepaalt [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) de linkermarge van de alinea‑body, en [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Voor een hangende insprong geeft u een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is handig voor bibliografieën, referenties, verklarende woordenlijsten en andere alinea’s waarbij ingesprongen regels onder de alinea‑body moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea’s en geef voor elk een positieve waarde aan [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-).
6. Geef een negatieve waarde aan [IParagraphFormat.setIndent](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) om het hangende‑insprongeffect te verkrijgen.
7. Voeg de alinea’s toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze code laat zien hoe u een hangende insprong voor een alinea instelt:

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

Resultaat:

![De hangende insprong van de alinea’s](hanging_indent.png)

### **Einde‑alinea‑run‑eigenschappen instellen**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) bepaalt de opmaak van het eindteken van een alinea. Het volgende voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het eindteken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) en open een dia.
2. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe en verwijder de standaardalinea.
3. Maak twee alinea’s en voeg tekstporties toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portionformat/) voor het eindteken van de tweede alinea.
5. Stel [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) en [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) in.
6. Koppel de opmaak met [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) en sla de presentatie op.

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

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea’s**

Gebruik [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) om HTML‑opmaak om te zetten naar alinea’s en porties in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse.
2. Open een dia en voeg een [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) toe.
3. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm en verwijder de standaardalinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑tekst door aan [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Sla de gewijzigde presentatie op.

Dit Android‑via‑Java‑voorbeeld importeert HTML in een tekstframe:

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

Gebruik [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) om een geselecteerd bereik van alinea’s als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑klasse en laad de gewenste presentatie.
2. Open de dia en zoek de [IAutoShape](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iautoshape/) die de tekst bevat.
3. Verkrijg het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) van de vorm.
4. Roep [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aan met de start‑alinea‑index en het aantal te exporteren alinea’s.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit Android‑via‑Java‑voorbeeld exporteert alle alinea’s van de eerste tekstvorm:

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

[IParagraph.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getImage--) rendert een individuele alinea direct en retourneert een [IImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/). Sla het resultaat op in een bestand of stream met [IImage.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). Het is niet nodig om de omringende vorm te renderen of een bitmap handmatig bij te snijden.

[IParagraph.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getImage--) kan `null` teruggeven als de alinea niet in de bovenliggende collectie voorkomt, geen geldige render‑bounds heeft, of niet kan worden gerenderd. Controleer het resultaat voordat u het opslaat en verwijder de afbeelding na gebruik.

#### **Alinea renderen op de standaardschaal**

Stel dat we een presentatie‑bestand *sample.pptx* hebben met één dia, waarbij de eerste vorm een tekstvak is met drie alinea’s.

![Het tekstvak met drie alinea’s](paragraph_to_image_input.png)

Het volgende voorbeeld rendert de tweede alinea in een gewone tekstvorm op de standaardschaal en slaat de geretourneerde afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

#### **Alinea renderen in een tabelcel met schaling**

Gebruik de overload van [IParagraph.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) die `float scaleX` en `float scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt de standaardpixelgrootte. Bijvoorbeeld, `2` voor beide factoren levert een afbeelding op waarvan breedte en hoogte ongeveer dubbel zo groot zijn, wat vier keer zoveel pixels betekent. Grotere factoren geven over het algemeen scherpere tekst voor zoom of hoge resolutie, maar vragen meer geheugen en vergroten de bestandsgrootte. Factoren onder `1` leveren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de verhoudingen van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een hele vorm met [IShape.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getImage--) blijft nuttig wanneer de uitvoer ook de opvulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding *alleen* van de alinea, gebruik [IParagraph.getImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **FAQ**

**Kan ik het automatisch afbreken van regels binnen een tekstframe volledig uitschakelen?**

Ja. Stel [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) in om afbreken uit te schakelen zodat regels niet breken aan de randen van het tekstframe.

**Hoe krijg ik de exacte on‑slide‑afmetingen van een specifieke alinea?**

Gebruik [IParagraph.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getRect--) om de omtrek van de alinea op te halen. [IPortion.getRect](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iportion/#getRect--) geeft de afmetingen van een individuele portie.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) is een alinea‑niveau instelling en wordt toegepast op de volledige alinea, ongeacht de opmaak van individuele porties.

**Kan ik de proefleertaalspecificatie voor een deel van een alinea instellen?**

Ja. Stel [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) in voor individuele porties, zodat één alinea tekst in meerdere talen kan bevatten.