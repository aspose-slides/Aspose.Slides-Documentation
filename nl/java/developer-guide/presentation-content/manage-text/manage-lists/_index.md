---
title: Beheer opsommingstekens en genummerde lijsten in presentaties in Java
linktitle: Beheer lijsten
type: docs
weight: 60
url: /nl/java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeelding opsommingsteken
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
description: "Leer hoe u opsommingstekens, afbeelding‑opsommingstekens, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides for Java."
---
## **Overzicht**

Aspose.Slides for Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingsteken‑instellingen worden beheerd via de alinea‑indeling.

Gebruik de [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/#getParagraphFormat--)‑methode om lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--), die een [IBulletFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeelding‑opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie bekijkt en wijzigt

## **Een opsomming maken**

Om een opsomming te maken, voegt u [IParagraph](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraph/)‑objecten toe aan een [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) en stelt u [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Symbol). Vervolgens kunt u [IBulletFormat.setChar](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#getColor--) en [IBulletFormat.setHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setHeight-float-) instellen om het uiterlijk van het opsommingsteken te regelen.

De volgende Java‑code toont hoe u een opsomming in een dia maakt:

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

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Numbered). U kunt ook een nummeringsformaat kiezen met [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) of [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) instellen wanneer de lijst moet beginnen met een waarde anders dan 1.

De volgende Java‑code laat zien hoe u een genummerde lijst in een dia maakt:

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

## **Een afbeelding‑opsommingsteken maken**

Aspose.Slides maakt het mogelijk om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het best met eenvoudige afbeeldingen die ook op een kleine grootte leesbaar blijven, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="info" %}}
Idealiter, als u van plan bent het normale opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige grafiek met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer klein formaat. Om die reden raden wij sterk aan een afbeelding te kiezen die duidelijk en visueel effectief blijft wanneer deze als opsommingsteken in een lijst wordt gebruikt.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation.getImages](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getImages--) en kent u het geretourneerde afbeeldingsobject toe aan [IBulletFormat.getPicture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#getPicture--). Stel [IBulletFormat.setType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibulletformat/#setType-byte-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/java/com.aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel dat we een “image.png” hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende Java‑code toont hoe u afbeelding‑opsommingstekens in een dia maakt:

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

## **Een meerlagige lijst maken**

Gebruik [IParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 staat eronder genest, enzovoort.

De volgende Java‑code laat zien hoe u een meerlagige opsomming maakt:

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

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijgt u de desbetreffende alinea en werkt u de instellingen van [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--) bij. Dezelfde eigenschappen die worden gebruikt om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT, PPTX of ODP‑bestand zijn geladen, te bekijken of te wijzigen.

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

### Kunnen opsommingstekens en genummerde lijsten worden geëxporteerd naar PDF of afbeeldingen?

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel‑formaat de bijbehorende tekstopmaak en opsommingsteken‑functies ondersteunt.

### Kan ik lijsten bewerken in bestaande presentaties?

Ja. Laad de presentatie, benader de desbetreffende alinea, bekijk of werk de instellingen van [IParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iparagraphformat/#getBullet--) bij, en sla de presentatie vervolgens op.

### Kunnen lijsten niet‑Latijnse tekst bevatten?

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de gebruikte lettertypen in de presentatie de tekens die u nodig heeft ondersteunen.