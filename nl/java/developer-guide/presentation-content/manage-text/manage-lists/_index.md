---
title: Beheer opsomming- en genummerde lijsten in presentaties in Java
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeeldingsopsommingsteken
- aangepast opsommingsteken
- meerlagige lijst
- opsommingsteken maken
- opsommingsteken toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u opsomming-, afbeelding-, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides for Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getParagraphFormat--) methode om lijstinstellingen op alinea‑niveau te benaderen. Het hoofdtoegangspunt is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--), die een [IBulletFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/) object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en begingetal instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeeldingsbullet maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak inspecteert en wijzigt in een bestaande presentatie

## **Maak een opsomming**

Om een opsomming te maken, voegt u [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/) objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) en stelt u [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Symbol). Vervolgens kunt u [IBulletFormat.setChar](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#getColor--) en [IBulletFormat.setHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setHeight-float-) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende Java‑code demonstreert hoe u een opsomming maakt in een dia:

```java
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

![The symbol bullets](symbol_bullets.png)

## **Maak een genummerde lijst**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Numbered). U kunt ook een nummeringsformaat kiezen met [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) of [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) instellen wanneer de lijst moet beginnen met een waarde anders dan 1.

De volgende Java‑code toont hoe u een genummerde lijst maakt in een dia:

```java
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

![The numbered bullets](numbered_bullets.png)

## **Maak een afbeeldingsbullet**

Aspose.Slides stelt u in staat een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldingsbullets werken het beste met eenvoudige afbeeldingen die leesbaar blijven op een kleine grootte, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, kiest u het beste een eenvoudige afbeelding met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding verkleind wordt tot een zeer kleine afmeting. Daarom raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.
{{% /alert %}}

Om een afbeeldingsbullet te maken, voegt u een afbeelding toe aan [Presentation.getImages](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getImages--) en kent u het geretourneerde beeldobject toe aan [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#getPicture--). Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel dat we een “image.png” hebben:

![A picture for the bullets](picture_for_bullets.png)

De volgende Java‑code toont hoe u afbeeldingsbullets maakt in een dia:

```java
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

![The picture bullets](picture_bullets.png)

## **Maak een meerlagige lijst**

Gebruik [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende Java‑code toont hoe u een meerlagige opsomming maakt:

```java
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

![The multilevel list](multilevel_list.png)

## **Wijzig een bestaande lijst**

Om de lijstopmaak in een bestaande presentatie te wijzigen, benader u de doel­alinea en werk zijn [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--) instellingen bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die zijn geladen uit een PPT, PPTX‑ of ODP‑bestand te inspecteren of aan te passen.

De volgende Java‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```java
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

**Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de overeenkomstige tekstopmaak en opsommingsteken‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, benader de doel­alinea, inspecteer of werk de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--) instellingen bij en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de in de presentatie gebruikte lettertypen de benodigde tekens ondersteunen.