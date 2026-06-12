---
title: Beheer opsommingstekens en genummerde lijsten in presentaties op Android
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/androidjava/manage-lists/
keywords:
- opsommingsteken
- opsomminglijst
- genummerde lijst
- symbool opsomming
- afbeelding opsomming
- aangepast opsommingsteken
- meerlagige lijst
- opsomming maken
- opsomming toevoegen
- lijst toevoegen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u opsommingstekens, afbeelding‑, meerlagige‑ en genummerde lijsten maakt en opmaakt in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides for Android via Java stelt u in staat om opsommingstekens en genummerde lijsten aan te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingsteken‑instellingen worden beheerd via de alinea‑opmaak.

Gebruik de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)‑methode om de lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), dat een [IBulletFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeelding als opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie bekijkt en wijzigt

## **Een opsomming maken**

Om een opsomming te maken, voegt u alinea’s toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) en stelt u [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/). Vervolgens kunt u [IBulletFormat.setChar](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#getColor--) en [IBulletFormat.setHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) gebruiken om het uiterlijk van het opsommingsteken te regelen.

De volgende Java‑code laat zien hoe u een opsomming maakt in een dia:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
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

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van de items van belang is. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/). U kunt ook een nummeringsformaat kiezen met [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) of [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) gebruiken wanneer de lijst moet beginnen met een waarde anders dan 1.

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

![De genummerde opsommingstekens](numbered_bullets.png)

## **Een afbeelding‑opsommingsteken maken**

Aspose.Slides stelt u in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het beste met eenvoudige afbeeldingen die ook op een kleine grootte leesbaar blijven, zoals pictogrammen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als u van plan bent het gewone opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige afbeelding met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding tot een zeer kleine grootte wordt verkleind. Om die reden raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation.getImages](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getImages--) en kent u het geretourneerde [IPPImage](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ippimage/)‑object toe aan [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/bullettype/) vóór u de afbeelding toewijst.

Stel dat we een “image.png” hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende Java‑code laat zien hoe u afbeelding‑opsommingstekens maakt in een dia:

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

![De afbeelding‑opsommingstekens](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 zit eronder genest, enzovoort.

De volgende Java‑code laat zien hoe u een meerlagige opsomming maakt:

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

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, bereikt u de gewenste alinea en werkt u de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑instellingen bij. Dezelfde methoden die gebruikt worden om lijsten te maken, kunnen ook worden ingezet om lijsten die uit een PPT, PPTX of ODP‑bestand geladen zijn te inspecteren of aan te passen.

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

**Kunnen opsomming- en genummerde lijsten geëxporteerd worden naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de bijbehorende tekstindeling en opsommingsteken‑eigenschappen ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de doel‑alinea, bekijk of werk de [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--)‑instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van een lijstitem kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de benodigde tekens ondersteunen.