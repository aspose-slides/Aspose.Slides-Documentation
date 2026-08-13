---
title: Beheer opsommingstekens en genummerde lijsten in presentaties op Android
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/androidjava/manage-lists/
keywords:
- opsommingsteken
- opsommingstekenslijst
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- maak opsommingsteken
- voeg opsommingsteken toe
- voeg lijst toe
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u opsommingsteken-, afbeelding-, meerlagige- en genummerde lijsten maakt en formatteert in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides voor Android via Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en te formatteren in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingsteken‑instellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)‑methode om toegang te krijgen tot lijstinstellingen op alinea‑niveau. Het belangrijkste toegangspunt is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), die een [IBulletFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, het symbool, de afbeelding, de kleur, de grootte, de nummeringsstijl en het startnummer instellen.

Dit artikel laat zien hoe u:

- een lijst met opsommingstekens maakt met een aangepast symbool
- een afbeelding‑opsommingsteken maakt
- een meerlaagse lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijst‑opmaak in een bestaande presentatie inspecteert en wijzigt

## **Maak een lijst met opsommingstekens**

Om een lijst met opsommingstekens te maken, voegt u alinea’s toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) en stelt u [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/). Vervolgens kunt u [IBulletFormat.setChar](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#getColor--) en [IBulletFormat.setHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) instellen om het uiterlijk van het opsommingsteken te bepalen.

De volgende Java‑code laat zien hoe u een lijst met opsommingstekens maakt in een dia:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De symbool‑opsommingstekens](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/). U kunt tevens een nummeringsformaat kiezen met [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) of [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) instellen wanneer de lijst moet beginnen met een andere waarde dan 1.

De volgende Java‑code laat zien hoe u een genummerde lijst maakt in een dia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Maak een afbeelding‑opsommingsteken**

Aspose.Slides maakt het mogelijk een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die ook op een kleine grootte nog goed leesbaar zijn, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="info" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u best een eenvoudige tekening met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine grootte. Daarom raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze wordt gebruikt als opsommingsteken in een lijst.

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe via [Presentation.getImages](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getImages--) en kent u het teruggegeven [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/)‑object toe aan [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/) voordat u de afbeelding toewijst.

Stel, we hebben een “image.png”:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende Java‑code laat zien hoe u afbeelding‑opsommingstekens maakt in een dia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Maak een meerlaagse lijst**

Gebruik [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is eronder genest, enzovoort.

De volgende Java‑code laat zien hoe u een meerlaagse lijst maakt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De meerlaagse lijst](multilevel_list.png)

## **Wijzig een bestaande lijst**

Om de lijst‑opmaak in een bestaande presentatie te wijzigen, opent u de gewenste alinea en werkt u de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑instellingen bij. Dezelfde methoden die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT, PPTX of ODP‑bestand zijn geladen, te inspecteren of aan te passen.

De volgende Java‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Kunnen lijsten met opsommingstekens en genummerde lijsten geëxporteerd worden naar PDF of afbeeldingen?

Ja. Aspose.Slides behoudt de lijst‑opmaak wanneer het doelformaat de overeenkomstige tekstopmaak en opsommingsteken‑functies ondersteunt.

### Kan ik lijsten bewerken in bestaande presentaties?

Ja. Laad de presentatie, open de gewenste alinea, inspecteer of werk de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑instellingen bij, en sla de presentatie op.

### Kunnen lijsten niet‑Latijnse tekst bevatten?

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen de benodigde tekens ondersteunen.