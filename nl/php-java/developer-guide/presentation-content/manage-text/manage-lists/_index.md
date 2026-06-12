---
title: Beheer opsommingstekens en genummerde lijsten in presentaties met PHP
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/php-java/manage-lists/
keywords:
- opsommingsteken
- opsommingstekenlijst
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
- PHP
- Aspose.Slides
description: "Leer hoe u opsommingsteken-, afbeelding-, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt je in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint- en OpenDocument-presentaties. Een lijstitem is een alinea waarvan de opsomminginstellingen worden beheerd via de alinea‑opmaak.

Gebruik de [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getParagraphFormat--) methode om lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste toegangspunt is [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getBullet--) die een [BulletFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/) object retourneert. Met dit object kun je het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummerstijl en startnummer instellen.

Dit artikel laat zien hoe je:

- een opsommingstekenlijst maken met een aangepast symbool
- een afbeelding‑opsommingsteken maken
- een meerlagige lijst maken door de alinea‑diepte in te stellen
- een genummerde lijst maken
- lijstopmaak inspecteren en wijzigen in een bestaande presentatie

## **Maak een opsommingstekenlijst**

Om een opsommingstekenlijst te maken, voeg je [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) objecten toe aan een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) en stel je [BulletFormat.setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType.Symbol](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/#Symbol). Je kunt vervolgens [BulletFormat.setChar](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#getColor--), en [BulletFormat.setHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setHeight-float-) instellen om het uiterlijk van het opsommingsteken te controleren.

De volgende PHP‑code toont hoe je een opsommingstekenlijst maakt in een dia:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Het resultaat:

![De symbool opsommingstekens](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van items van belang is. Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType.Numbered](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/#Numbered). Je kunt ook een nummeropmaak kiezen met [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) of [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) instellen als de lijst moet beginnen met een andere waarde dan 1.

De volgende PHP‑code laat zien hoe je een genummerde lijst maakt in een dia:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Het resultaat:

![De genummerde opsommingstekens](numbered_bullets.png)

## **Een afbeelding‑opsommingsteken maken**

Aspose.Slides stelt je in staat om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldingsopsommingstekens werken het beste met eenvoudige afbeeldingen die leesbaar blijven op een kleine afmeting, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="primary" %}}
Idealiter, als je van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, is het het beste een eenvoudige grafiek met een transparante achtergrond te kiezen. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Om een afbeelding‑opsommingsteken te maken, voeg je een afbeelding toe via [Presentation.getImages](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getImages--) en wijs je het geretourneerde [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/) object toe aan [BulletFormat.getPicture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#getPicture--). Stel [BulletFormat.setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType.Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/#Picture) voordat je de afbeelding toewijst.

Stel dat we een "image.png" hebben:

![Een afbeelding voor de opsommingstekens](picture_for_bullets.png)

De volgende PHP‑code laat zien hoe je afbeelding‑opsommingstekens maakt in een dia:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Het resultaat:

![De afbeelding opsommingstekens](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setDepth-short-) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het hoogste niveau, niveau 1 is eronder genest, enzovoort.

De volgende PHP‑code laat zien hoe je een meerlagige opsommingstekenlijst maakt:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Het resultaat:

![De meerlagige lijst](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, krijg je toegang tot de betreffende alinea en werk je de [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getBullet--) instellingen bij. Dezelfde eigenschappen die gebruikt worden om lijsten te maken, kunnen ook worden gebruikt om lijsten die uit een PPT, PPTX, of ODP‑bestand zijn geladen te inspecteren of te wijzigen.

De volgende PHP‑code wijzigt de eerste alinea in een tekstframe zodat deze een genummerde lijststijl gebruikt:

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Kunnen opsommingsteken‑ en genummerde lijsten geëxporteerd worden naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doelformaat de corresponderende tekstlay‑out en opsommingstekenfuncties ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, krijg toegang tot de betreffende alinea, inspecteer of werk de [ParagraphFormat.getBullet](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getBullet--) instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat je lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de fonts die in de presentatie worden gebruikt de benodigde tekens ondersteunen.