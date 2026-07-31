---
title: Beheer PowerPoint-tekstalinea's in PHP
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
keywords:
  - tekst toevoegen
  - alinea toevoegen
  - tekst beheren
  - alinea beheren
  - opsommingstekens beheren
  - alinea-inspringing
  - hangende inspringing
  - alinea opsommingsteken
  - genummerde lijst
  - opsomminglijst
  - alinea-eigenschappen
  - HTML importeren
  - tekst naar HTML
  - alinea naar HTML
  - alinea naar afbeelding
  - tekst naar afbeelding
  - alinea exporteren
  - PowerPoint
  - OpenDocument
  - presentatie
  - PHP
  - Aspose.Slides
description: "Beheer alinea-opmaak met Aspose.Slides voor PHP via Java — optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP-presentaties."
---
## **Introductie**

Aspose.Slides biedt alle klassen die u nodig heeft om met PowerPoint-teksten, alinea's en gedeelten te werken.

* Aspose.Slides levert de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) klasse waarmee u objecten kunt toevoegen die een alinea vertegenwoordigen. Een `TextFame` object kan één of meerdere alinea's bevatten (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse waarmee u objecten kunt toevoegen die gedeelten vertegenwoordigen. Een `Paragraph` object kan één of meerdere gedeelten bevatten (een verzameling van gedeelte-objecten).
* Aspose.Slides levert de [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) klasse waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `Paragraph` object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `Portion` objecten.

## **Meerdere alinea's met meerdere gedeelten toevoegen**

Deze stappen laten zien hoe u een tekstvak toevoegt met 3 alinea's en elke alinea met 3 gedeelten:

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Haal het ITextFrame op dat hoort bij de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/).
5. Maak twee [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) objecten aan en voeg ze toe aan de alinea‑collectie van het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).
6. Maak drie [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) objecten voor elke nieuwe `Paragraph` (twee Portion-objecten voor de standaard Paragraph) en voeg elk `Portion` object toe aan de gedeelte‑collectie van elke `Paragraph`.
7. Stel tekst in voor elk gedeelte.
8. Pas uw gewenste opmaakfuncties toe op elk gedeelte met behulp van de opmaak‑eigenschappen die door het `Portion` object beschikbaar worden gesteld.
9. Sla de gewijzigde presentatie op.

```php
# Instantieer een Presentation-klasse die een PPTX‑bestand voorstelt
$pres = new Presentation();
try {
    # Toegang tot de eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van het type Rechthoek toe
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Toegang tot het TextFrame van de AutoShape
    $tf = $ashp->getTextFrame();
    # Create Paragraphs and Portions with different text formats
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # Schrijf PPTX naar schijf
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Alinea opsommingstekens beheren**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Alinea's met opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de AutoShape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse.
7. Stel het bullet `Type` voor de alinea in op `Symbol` en definieer het opsommingsteken.
8. Stel de alinea `Text` in.
9. Stel de alinea `Indent` in voor de bullet.
10. Stel een kleur in voor de bullet.
11. Stel een hoogte in voor de bullet.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal de stappen 7 tot 13.
14. Sla de presentatie op.

```php
# Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
$pres = new Presentation();
try {
    # Toegang tot de eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape toe en krijgt toegang tot deze
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Toegang tot het tekstframe van de autoshape
    $txtFrm = $aShp->getTextFrame();
    # Verwijdert de standaard alinea
    $txtFrm->getParagraphs()->removeAt(0);
    # Maakt een alinea aan
    $para = new Paragraph();
    # Stelt een alinea-bulletstijl en symbool in
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Stelt de alinea-tekst in
    $para->setText("Welcome to Aspose.Slides");
    # Stelt de inspringing van het bullet in
    $para->getParagraphFormat()->setIndent(25);
    # Stelt de kleur van het bullet in
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// stel IsBulletHardColor in op true om een eigen bulletkleur te gebruiken

    # Stelt de hoogte van het bullet in
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Voegt alinea toe aan het tekstframe
    $txtFrm->getParagraphs()->add($para);
    # Maakt een tweede alinea aan
    $para2 = new Paragraph();
    # Stelt het bullet-type en -stijl van de alinea in
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Voegt alinea-tekst toe
    $para2->setText("This is numbered bullet");
    # Stelt de inspringing van het bullet in
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// stel IsBulletHardColor in op true om een eigen bulletkleur te gebruiken

    # Stelt de hoogte van het bullet in
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Voegt alinea toe aan het tekstframe
    $txtFrm->getParagraphs()->add($para2);
    # Slaat de gewijzigde presentatie op
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Afbeeldings-bullets beheren**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Afbeeldingsalinea's zijn eenvoudig te lezen en te begrijpen.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de AutoShape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/).
8. Stel het bullet type in op [Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/#Picture) en geef de afbeelding op.
9. Stel de `Text` van de Paragraph in.
10. Stel de `Indent` van de Paragraph in voor de bullet.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de vorige stappen.
15. Sla de gewijzigde presentatie op.

```php
# Instantiëert een Presentation-klasse die een PPTX-bestand voorstelt
$presentation = new Presentation();
try {
    # Toegang tot de eerste dia
    $slide = $presentation->getSlides()->get_Item(0);
    # Instantiëert de afbeelding voor bullets
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Voegt een AutoShape toe en krijgt toegang tot deze
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Toegang tot het tekstframe van de autoshape
    $textFrame = $autoShape->getTextFrame();
    # Verwijdert de standaard alinea
    $textFrame->getParagraphs()->removeAt(0);
    # Maakt een nieuwe alinea aan
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Stelt de bulletstijl en afbeelding van de alinea in
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Stelt de bullethoogte in
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Voegt alinea toe aan het tekstframe
    $textFrame->getParagraphs()->add($paragraph);
    # Schrijft de presentatie weg als een PPTX-bestand
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Schrijft de presentatie weg als een PPT-bestand
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Meerlagige bullets beheren**

Opsommingstekens helpen u informatie snel en efficiënt te ordenen en te presenteren. Meerdere niveaus bullets zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe in de nieuwe dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de AutoShape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan via de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea aan via de `Paragraph` klasse en stel de diepte in op 1.
8. Maak de derde alinea aan via de `Paragraph` klasse en stel de diepte in op 2.
9. Maak de vierde alinea aan via de `Paragraph` klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de gewijzigde presentatie op.

```php
# Instantieert een Presentation-klasse die een PPTX-bestand voorstelt
$pres = new Presentation();
try {
    # Toegang tot de eerste dia
    $slide = $pres->getSlides()->get_Item(0);
    # Voegt een AutoShape toe en krijgt toegang tot deze
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Toegang tot het tekstframe van de aangemaakte autoshape
    $text = $aShp->addTextFrame("");
    # Verwijdert de standaard alinea
    $text->getParagraphs()->clear();
    # Voegt de eerste alinea toe
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Stelt het bullet niveau in
    $para1->getParagraphFormat()->setDepth(0);
    # Voegt de tweede alinea toe
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Stelt het bullet niveau in
    $para2->getParagraphFormat()->setDepth(1);
    # Voegt de derde alinea toe
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Stelt het bullet niveau in
    $para3->getParagraphFormat()->setDepth(2);
    # Voegt de vierde alinea toe
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Stelt het bullet niveau in
    $para4->getParagraphFormat()->setDepth(3);
    # Voegt alinea's toe aan de collectie
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Schrijft de presentatie weg als een PPTX-bestand
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [BulletFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/) klasse biedt de methode [setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) en andere die u in staat stellen alinea's met aangepaste nummering of opmaak te beheren.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de dia die de alinea bevat.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Toegang tot het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de AutoShape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan via de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) in op 2.
7. Maak de tweede alinea aan via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea aan via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de gewijzigde presentatie op.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Toegang tot het tekstframe van de aangemaakte autoshape
    $textFrame = $shape->getTextFrame();
    # Verwijdert de standaard bestaande alinea
    $textFrame->getParagraphs()->removeAt(0);
    # Eerste lijst
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Eerste‑regelinspringing voor een alinea instellen**

Gebruik de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) methode om de eerste‑regelinspringing van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt meerdere alinea's en past verschillende inspringingswaarden toe om te laten zien hoe de eerste‑regelinspringing de lay‑out beïnvloedt.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak meerdere alinea's aan en stel verschillende [Indent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) waarden in.
6. Voeg de alinea's toe aan het tekstvak.
7. Sla de gewijzigde presentatie op.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De eerste‑regelinspringing van de alinea's](first_line_indent.png)

## **Hangende inspringing voor een alinea instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel meer naar links begint dan de overige regels. In Aspose.Slides creëert u dit effect met de [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) methode. Stel een negatieve waarde in om de eerste regel naar links te verschuiven ten opzichte van de alinea‑inhoud.

In de praktijk definieert [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginleft/) de linkermarge van de alinea‑inhoud, en [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) de positie van de eerste regel ten opzichte van die marge. Voor een hangende inspringing stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is handig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij omgebroken regels onder de alinea‑inhoud moeten uitlijnen en niet onder het eerste teken van de eerste regel.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's aan en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setmarginleft/) waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setindent/) waarde in om het hangende effect te creëren.
7. Voeg de alinea's toe aan het tekstvak.
8. Sla de gewijzigde presentatie op.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De hangende inspringing van de alinea's](hanging_indent.png)

## **Eind‑alinea run‑eigenschappen beheren**

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Haal de referentie op voor de dia die de alinea bevat via de positie.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) met twee alinea's toe aan de rechthoek.
5. Stel de letterhoogte en het lettertype in voor de alinea's.
6. Stel de End‑eigenschappen in voor de alinea's.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **HTML-tekst importeren in alinea's**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML-tekst in alinea's.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Voeg de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van `AutoShape` toe en krijg toegang tot deze.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea aan via de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse.
8. Voeg de HTML‑bestandsinhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de gewijzigde presentatie op.

```php
# Maak lege presentatie‑instantie
$pres = new Presentation();
try {
    # Toegang tot de standaard eerste dia van de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Voeg de AutoShape toe om de HTML‑inhoud onder te brengen
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Voeg een tekstframe toe aan de vorm
    $ashape->addTextFrame("");
    # Wis alle alinea's in het toegevoegde tekstframe
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Laad het HTML‑bestand met een stream‑reader
    $tr = new StreamReader("file.html");
    # Voeg tekst uit de HTML‑stream‑reader toe aan het tekstframe
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Sla de presentatie op
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van teksten (in alinea's) naar HTML.

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Toegang tot de referentie van de betreffende dia via de index.
3. Toegang tot de vorm die de te exporteren tekst bevat.
4. Toegang tot de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm.
5. Maak een instantie aan van `StreamWriter` en voeg het nieuwe HTML‑bestand toe.
6. Geef een startindex door aan StreamWriter en exporteer de gewenste alinea's.

```php
# Laad het presentatiebestand
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Toegang tot de standaard eerste dia van de presentatie
    $slide = $pres->getSlides()->get_Item(0);
    # Gewenste index
    $index = 0;
    # Toegang tot de toegevoegde vorm
    $ashape = $slide->getShapes()->get_Item($index);
    # Maak het uitvoer‑HTML‑bestand aan
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Eerste alinea extraheren als HTML
    # Schrijf alinea‑gegevens naar HTML door het start‑index van de alinea en het totale aantal te kopiëren alinea's op te geven
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bekijken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) klasse, opslaat als afbeelding. Beide voorbeelden bevatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `getImage` methoden van de [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) klasse, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als een bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en als afzonderlijke afbeeldingen op te slaan, wat nuttig kan zijn voor later gebruik in verschillende scenario's.

Laten we aannemen dat we een presentatiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstvak van de vorm. De alinea wordt vervolgens opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is vooral handig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak behouden blijven.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Sla de vorm in het geheugen op als bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Maak een vorm‑bitmap vanuit het geheugen.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Bereken de coördinaten en grootte voor de uitvoer‑afbeelding (minimumgrootte - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Snijd het vorm‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Het resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te voegen aan de alinea‑afbeelding. De vorm wordt geëxtraheerd uit de presentatie en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een afbeelding met hogere resolutie bij het exporteren van de alinea. De grenzen van de alinea worden vervolgens berekend met inachtneming van de schaal. Schalen kan vooral nuttig zijn wanneer een gedetailleerdere afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige drukmaterialen.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Sla de vorm in het geheugen op als bitmap met schaling.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Maak een vorm‑bitmap vanuit het geheugen.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Bereken de grenzen van de tweede alinea.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Bereken de coördinaten en grootte voor de uitvoerafbeelding (minimumgrootte - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Snijd het vorm‑bitmap bij om alleen de alinea‑bitmap te krijgen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Kan ik regelomslag volledig uitschakelen binnen een tekstvak?**

Ja. Gebruik de omloopinstelling van het tekstvak ([setWrapText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/setwraptext/)) om omloop uit te schakelen zodat regels niet afbreken aan de rand van het vak.

**Hoe kan ik de exacte grenzen op de dia van een specifieke alinea krijgen?**

U kunt de begrenzingsrechthoek van de alinea (en zelfs van een enkel gedeelte) opvragen om de exacte positie en afmeting op de dia te kennen.

**Waar wordt de uitlijning van alinea's (links/rechts/midden/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/setalignment/) is een instelling op alinea‑niveau in [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/); het wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele gedeelten.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op het niveau van een gedeelte ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId)), zodat meerdere talen kunnen coëxisteren binnen één alinea.