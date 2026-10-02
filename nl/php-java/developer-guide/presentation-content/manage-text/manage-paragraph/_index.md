---
title: Beheer PowerPoint-tekst alinea's in PHP
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
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
- opsomming
- alinea-eigenschappen
- HTML importeren
- tekst naar HTML
- alinea naar HTML
- alinea naar afbeelding
- tekst naar afbeelding
- alinea exporteren
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u alinea's, delen, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen kunt maken en opmaken met Aspose.Slides for PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en delen:

* [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) vertegenwoordigt de tekstcontainer in een vorm en biedt toegang tot de alinea‑collectie.
* [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de delen en alinea‑niveau opmaak.
* [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) vertegenwoordigt een tekstfragment binnen een alinea. Elk deel kan eigen tekst en teken‑niveau opmaak hebben.

Een alinea kan daardoor tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere delen te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere delen**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie delen:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaard alinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)‑objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)‑objecten toe zodat elke alinea drie delen bevat. De standaard alinea bevat al één leeg deel.
7. Stel de tekst van elk deel in.
8. Pas teken‑niveau opmaak toe via [Portion::getPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getPortionFormat--).
9. Sla de gewijzigde presentatie op.

Dit PHP‑voorbeeld implementeert de stappen:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    $textFrame = $shape->getTextFrame();

    $firstParagraph = $textFrame->getParagraphs()->get_Item(0);
    $firstParagraph->getPortions()->add(new Portion());
    $firstParagraph->getPortions()->add(new Portion());

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $secondParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $thirdParagraph->getPortions()->add(new Portion());
    $textFrame->getParagraphs()->add($thirdParagraph);

    $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portion->setText("Portion " . ($paragraphIndex + 1) . "." . ($portionIndex + 1));

            if ($portionIndex == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($portionIndex == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }

    $presentation->save("paragraphs_with_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Opsommingstekens en genummerde lijsten maken**

### **Een opsomming met opsommingstekens of nummers maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/).

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaard alinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/) en geef het opsommingsteken‑teken op.
8. Stel de alinea‑tekst, inspringing, kleur van het opsommingsteken en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
11. Configureer de stijl van het genummerde opsommingsteken en voeg de alinea toe aan het tekstframe.
12. Sla de presentatie op.

Dit PHP‑voorbeeld maakt een symbool‑opsommingsteken en een genummerd opsommingsteken:

```php
use aspose\slides\BulletType;
use aspose\slides\ColorType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $symbolParagraph = new Paragraph();
    $symbolParagraph->setText("Welcome to Aspose.Slides");
    $symbolParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $symbolParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $symbolParagraph->getParagraphFormat()->setIndent(25);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $symbolParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $symbolParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $symbolParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($symbolParagraph);

    $numberedParagraph = new Paragraph();
    $numberedParagraph->setText("This is a numbered item");
    $numberedParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $numberedParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
    $numberedParagraph->getParagraphFormat()->setIndent(25);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $numberedParagraph->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $numberedParagraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $numberedParagraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($numberedParagraph);

    $presentation->save("bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Afbeeldings‑opsommingstekens gebruiken**

Afbeeldings‑opsommingstekens laten u een aangepast beeld gebruiken in plaats van een symbool of cijfer.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open de betreffende dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe en open zijn [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
4. Verwijder de standaard alinea uit het tekstframe.
5. Laad het opsommingsteken‑beeld en voeg het toe aan de afbeeldingscollectie van de presentatie als een [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture--) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit PHP‑voorbeeld maakt een afbeeldings‑opsommingsteken:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $bulletImage = Images::fromFile("bullets.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($bulletImage);
    } finally {
        $bulletImage->dispose();
    }

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($presentationImage);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $textFrame->getParagraphs()->add($paragraph);

    $presentation->save("picture_bullet.pptx", SaveFormat::Pptx);
    $presentation->save("picture_bullet.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

### **Een meerlagige lijst maken**

Stel [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth-short-)‑waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit PHP‑voorbeeld maakt een opsomming met vier niveaus:

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Content");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $firstParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setDepth(0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Second level");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $secondParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setDepth(1);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Third level");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $thirdParagraph->getParagraphFormat()->getBullet()->setChar("•");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->getParagraphFormat()->setDepth(2);

    $fourthParagraph = new Paragraph();
    $fourthParagraph->setText("Fourth level");
    $fourthParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $fourthParagraph->getParagraphFormat()->getBullet()->setChar('-');
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $fourthParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $fourthParagraph->getParagraphFormat()->setDepth(3);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);
    $textFrame->getParagraphs()->add($fourthParagraph);

    $presentation->save("multilevel_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Genummerde lijstitems starten met aangepaste waarden**

Gebruik [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) om het initiële getal in te stellen dat wordt weergegeven voor een genummerde alinea.

1. Maak een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaard alinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) in op `2`, `3` en `7` voor de respectieve alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit PHP‑voorbeeld wijst een aangepast startnummer toe aan elke alinea:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("Start at 2");
    $firstParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $firstParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $textFrame->getParagraphs()->add($firstParagraph);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Start at 3");
    $secondParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $secondParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $textFrame->getParagraphs()->add($secondParagraph);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("Start at 7");
    $thirdParagraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $thirdParagraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("custom_numbered_list.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Alinea‑indeling en eind‑eigenschappen beheren**

### **Eerste‑regels insprong instellen**

Gebruik [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) om de eerste‑regels insprong van een alinea te beheersen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) wanneer u de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt meerdere alinea's en past verschillende [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑waarden toe om te laten zien hoe de eerste‑regels insprong de alinea‑indeling beïnvloedt.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's en stel voor elk verschillende [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑waarden in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u een alinea‑insprong instelt:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Hangende insprong instellen**

Een hangende insprong is een alinea‑indeling waarbij de eerste regel links begint van de overige regels. In Aspose.Slides creëert u dit effect met [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-). Geef een negatieve waarde op om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) de linkse positie van de alinea‑inhoud, en bepaalt [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, geeft u een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is bruikbaar voor bibliografieën, referenties, woordenlijst‑items en andere alinea's waarbij ingesprongen regels moeten uitlijnen onder de alinea‑inhoud en niet onder het eerste teken van de eerste regel.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
5. Maak alinea's en geef voor elke alinea een positieve waarde aan [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-).
6. Geef een negatieve waarde aan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setIndent-float-) om het effect van een hangende insprong te verkrijgen.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Deze PHP‑code laat zien hoe u een hangende insprong voor een alinea instelt:

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
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

![The hanging indent of the paragraphs](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) regelt de opmaak van het einde‑teken van de alinea. Het volgende PHP‑voorbeeld wijst een lettergrootte en een Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe en verwijder de standaard alinea.
3. Maak twee alinea's en voeg tekstdelen toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) en [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) in.
6. Ken de opmaak toe met [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) en sla de presentatie op.

```php
use aspose\slides\FontData;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $firstParagraph = new Paragraph();
    $firstParagraph->getPortions()->add(new Portion("Sample text"));

    $secondParagraph = new Paragraph();
    $secondParagraph->getPortions()->add(new Portion("Sample text 2"));

    $endParagraphFormat = new PortionFormat();
    $endParagraphFormat->setFontHeight(48);
    $endParagraphFormat->setLatinFont(new FontData("Times New Roman"));
    $secondParagraph->setEndParagraphPortionFormat($endParagraphFormat);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("end_paragraph_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Renderde lijnen tellen**

Voor alinea‑regels die automatische regelafbreking en interpunctie aan het einde van regels beïnvloeden, zie [Control Line Breaking](/slides/nl/php-java/text-formatting/#control-line-breaking) en [Control Hanging Punctuation](/slides/nl/php-java/text-formatting/#control-hanging-punctuation).

Gebruik [Paragraph::getLinesCount](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getLinesCount--) om het aantal lijnen te tellen dat een alinea inneemt na de tekstopmaak, inclusief automatische regelafbreking. Dit is handig bij het controleren van tekstarme en indeling in presentatiesjablonen.

Een alinea is één item in [TextFrame::getParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs--) en kan meerdere gerenderde regels innemen. Een expliciete regelafbreking binnen een alinea dwingt een nieuwe regel af zonder een extra alinea te maken. Automatische regelafbreking maakt regels op basis van de beschikbare breedte zonder expliciete regelafbrekingen in de tekst in te voegen. Het tellen van alinea's of regel‑afbreek‑tekens geeft daarom niet het aantal gerenderde regels.

Het onderstaande voorbeeld maakt een tekstelement, telt de regels, verkleint het element en vervangt vervolgens de tekst door een kortere tekenreeks. Regelafbreking is ingeschakeld en autofit uitgeschakeld zodat de breedte van het element de regelafbreking regelt zonder de tekst automatisch te verkleinen of het element van grootte te wijzigen. De afmetingen van het element worden in punten opgegeven. Ten slotte voegt het voorbeeld een extra alinea toe en telt de regels van alle alinea's in het tekstframe op.

```php
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    echo "Original width: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $shape->setWidth(150);
    echo "Narrower shape: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $paragraph->setText("Short text.");
    echo "Shorter text: " . java_values($paragraph->getLinesCount()) . PHP_EOL;

    $secondParagraph = new Paragraph();
    $secondParagraph->setText("Another paragraph.");
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(20);
    $textFrame->getParagraphs()->add($secondParagraph);

    $totalLineCount = 0;
    for ($i = 0; $i < java_values($textFrame->getParagraphs()->getCount()); $i++) {
        $currentParagraph = $textFrame->getParagraphs()->get_Item($i);
        $totalLineCount += java_values($currentParagraph->getLinesCount());
    }
    echo "Total lines in the text frame: " . $totalLineCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Met deze tekst en afmetingen verhoogt het verkleinen van het element het aantal regels, terwijl het vervangen van de tekst door de korte tekenreeks dit aantal verlaagt. Exacte aantallen kunnen variëren afhankelijk van de beschikbaarheid en vervanging van lettertypen, lettergrootte, marges, inspringing, regelafbreking en autofit‑instellingen. Gebruik de lettertypen en indelingsinstellingen die bedoeld zijn voor de doelomgeving bij het controleren van een sjabloon.

Alleen het aantal regels bepaalt niet of de tekst buiten het element stroomt. De beschikbare hoogte, regelhoogtes, alinea‑ en regel‑afstand, en het gedrag van autofit zijn eveneens van belang; zelfs één regel kan de beschikbare breedte overschrijden wanneer regelafbreking uitgeschakeld is.

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) om HTML‑opmaak om te zetten naar alinea's en delen in een tekstframe.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) toe.
3. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaard alinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Sla de gewijzigde presentatie op.

Dit PHP‑voorbeeld importeert HTML in een tekstframe:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeWidth = java_values($presentation->getSlideSize()->getSize()->getWidth()) - 20;
    $shapeHeight = java_values($presentation->getSlideSize()->getSize()->getHeight()) - 20;
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $shapeWidth, $shapeHeight);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $html = file_get_contents("file.html");
    if ($html !== false) {
        $shape->getTextFrame()->getParagraphs()->addFromHtml($html);
        $presentation->save("html_text.pptx", SaveFormat::Pptx);
    } else {
        echo "The HTML file could not be read.";
    }
} finally {
    $presentation->dispose();
}
```

### **Alinea‑tekst exporteren naar HTML**

Gebruik [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) en laad de gewenste presentatie.
2. Open de dia en zoek de [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) die de tekst bevat.
3. Open het [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aan met de start‑alinea‑index en het aantal alinea's dat moet worden geëxporteerd.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit PHP‑voorbeeld exporteert alle alinea's uit de eerste tekstelement:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ExportingHTMLText.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame)) {
            $paragraphs = $textFrame->getParagraphs();
            $html = $paragraphs->exportToHtml(0, $paragraphs->getCount(), null);
            if (file_put_contents("paragraphs.html", $html) === false) {
                echo "The HTML file could not be written.";
            }
        } else {
            echo "The first shape does not contain a text frame.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

### **Een alinea renderen als afbeelding**

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) rendert rechtstreeks een individuele alinea en geeft een [IImage](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/) terug. Sla het resultaat op in een bestand of stream met [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Het is niet nodig om de omvattende vorm te renderen of handmatig een bitmap bij te snijden.

[Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--) kan `null` retourneren als de alinea niet in de bovenliggende collectie wordt gevonden, geen geldige renderafmetingen heeft of niet gerenderd kan worden. Controleer het resultaat voordat u het opslaat en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea renderen op de standaardschaal**

Stel dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waar de eerste vorm een tekstvak is dat drie alinea's bevat.

![The text box with three paragraphs](paragraph_to_image_input.png)

Het volgende PHP‑voorbeeld rendert de tweede alinea in een normaal tekstvak op de standaardschaal en slaat de teruggegeven afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
        $textFrame = $shape->getTextFrame();
        if (!java_is_null($textFrame) && java_values($textFrame->getParagraphs()->getCount()) > 1) {
            $paragraph = $textFrame->getParagraphs()->get_Item(1);
            $paragraphImage = $paragraph->getImage();

            if (!java_is_null($paragraphImage)) {
                try {
                    $paragraphImage->save("paragraph.png", ImageFormat::Png);
                } finally {
                    $paragraphImage->dispose();
                }
            } else {
                echo "The paragraph could not be rendered.";
            }
        } else {
            echo "The expected paragraph was not found.";
        }
    } else {
        echo "The first shape is not a text shape.";
    }
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The paragraph image](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schalen**

Gebruik de overload van [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage-float-float-) die de parameters `$scaleX` en `$scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het volgende PHP‑voorbeeld maakt een tabel, rendert de alinea in de eerste cel op het dubbele van de standaardbreedte en -hoogte, en slaat het resultaat op als een PNG‑afbeelding.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->addTable(50, 50, array(300), array(80));
    $paragraph = $table->get_Item(0, 0)->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->setText("Text in a table cell");

    $paragraphImage = $paragraph->getImage($scaleX, $scaleY);
    if (!java_is_null($paragraphImage)) {
        try {
            $paragraphImage->save("table_paragraph.png", ImageFormat::Png);
        } finally {
            $paragraphImage->dispose();
        }
    } else {
        echo "The paragraph could not be rendered.";
    }
} finally {
    $presentation->dispose();
}
```

Een schaalfactor van `1` behoudt die as op de standaardpixelgrootte. Bijvoorbeeld, `2` voor beide factoren produceert een afbeelding waarvan breedte en hoogte ongeveer twee keer de standaardafmetingen zijn, wat resulteert in vier keer zoveel pixels. Grotere factoren leveren doorgaans scherpere tekst voor inzoomen of hoge‑resolutie‑output, maar verhogen tevens het geheugenverbruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de uitvoer onafhankelijk uit.

Het renderen van een volledige vorm met [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage--) blijft nuttig wanneer de uitvoer de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding van alleen een alinea, gebruik [Paragraph::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getImage--).

## **Veelgestelde vragen**

**Kan ik regelafbreking volledig uitschakelen binnen een tekstframe?**

Ja. Stel [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText-byte-) in om afbreken uit te schakelen zodat regels niet bij de randen van het tekstframe worden afgebroken.

**Hoe kan ik de exacte bounds van een specifieke alinea op de dia verkrijgen?**

Gebruik [Paragraph::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getRect--) om de begrenzende rechthoek van de alinea op te halen. [Portion::getRect](https://reference.aspose.com/slides/php-java/aspose.slides/portion/#getRect--) levert de bounds van een individueel deel.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) aangestuurd?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment-int-) is een instelling op alinea‑niveau en wordt toegepast op de hele alinea, ongeacht de opmaak van individuele delen.

Om verticale uitlijning van delen met verschillende lettergroottes binnen elke regel te bereiken, zie [Align Fonts Within a Line](/slides/nl/php-java/text-formatting/#align-fonts-within-a-line).

**Kan ik de controle‑taal instellen voor een deel van een alinea?**

Ja. Stel [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in voor individuele delen, zodat één alinea tekst in meerdere talen kan bevatten.