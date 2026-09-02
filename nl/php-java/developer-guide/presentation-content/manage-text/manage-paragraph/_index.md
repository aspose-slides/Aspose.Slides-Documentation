---
title: Beheer PowerPoint-tekstalinea's in PHP
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
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe je alinea's, Portion's, opsommingstekens, genummerde lijsten, inspringingen, HTML-inhoud en alinea-afbeeldingen maakt en opmaakt met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java vertegenwoordigt tekst als een hiërarchie van tekstframes, alinea's en Portion's:

* [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) vertegenwoordigt de tekstdocumentcontainer in een vorm en biedt toegang tot de alinea‑verzameling.
* [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) vertegenwoordigt één alinea in een tekstframe en biedt toegang tot de Portion's en de alinea‑opmaak.
* [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) vertegenwoordigt een tekstrun binnen een alinea. Elke Portion kan eigen tekst en karakter‑opmaak hebben.

Een alinea kan daardoor tekst bevatten met verschillende lettertypen, kleuren, groottes en andere opmaak door meerdere Portion's te gebruiken.

## **Alinea's maken en opmaken**

### **Alinea's maken met meerdere Portion's**

De volgende stappen maken een tekstframe met drie alinea's, elk met drie Portion's:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm.
5. Gebruik de standaardalinea en voeg twee extra [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) objecten toe aan het tekstframe.
6. Voeg voldoende [Portion](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/) objecten toe zodat elke alinea drie Portion's bevat. De standaardalinea bevat al één lege Portion.
7. Stel de tekst van elke Portion in.
8. Pas karakter‑opmaak toe via [Portion::getPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getPortionFormat--).
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

## **Opsommingstekens en nummering maken**

### **Een opsomming of genummerde lijst maken**

Opsommingstekens en nummering maken gerelateerde items makkelijker scanbaar. In Aspose.Slides worden lijstinstellingen gedefinieerd via [BulletFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/).

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm.
5. Verwijder de standaardalinea uit het tekstframe.
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) voor een symbool‑opsommingsteken.
7. Stel [BulletFormat::setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Symbol](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/) en specificeer het opsommingsteken‑karakter.
8. Stel de alinea‑tekst, inspringing, kleur en hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Maak een tweede alinea en stel [BulletFormat::setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Numbered](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/).
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

Afbeeldings‑opsommingstekens laten je een eigen afbeelding gebruiken in plaats van een symbool of nummer.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de gewenste dia via de index.
3. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe en open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).
4. Verwijder de standaardalinea uit het tekstframe.
5. Laad de opsommingsteken‑afbeelding en voeg deze toe aan de afbeeldingsverzameling van de presentatie als een [PPImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/ppimage/).
6. Maak een [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/) en stel de tekst in.
7. Stel [BulletFormat::setType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setType-int-) in op [BulletType::Picture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bullettype/).
8. Wijs de afbeelding toe via [BulletFormat::getPicture](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#getPicture--) en stel de hoogte van het opsommingsteken in.
9. Voeg de alinea toe aan het tekstframe.
10. Sla de gewijzigde presentatie op.

Dit PHP‑voorbeeld maakt een afbeelding‑opsommingsteken:

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

Stel [ParagraphFormat::setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setDepth-short-) in om alinea's op verschillende niveaus van een lijst te plaatsen. Het bovenste niveau heeft een diepte van `0`.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe en verwijder de standaardalinea uit het tekstframe.
3. Maak vier alinea's en configureer hun opsommingsteken‑symbolen.
4. Stel hun [ParagraphFormat::setDepth](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setDepth-short-) waarden in op `0`, `1`, `2` en `3`.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit PHP‑voorbeeld maakt een vierlagen‑opsomming:

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

### **Genummerde lijstitems laten starten met aangepaste waarden**

Gebruik [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) om het beginnummer voor een genummerde alinea in te stellen.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) en voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan een dia.
2. Verwijder de standaardalinea uit het tekstframe van de vorm.
3. Maak drie genummerde alinea's.
4. Stel [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/nl/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) in op `2`, `3` en `7` voor respectievelijk de alinea's.
5. Voeg de alinea's toe aan het tekstframe en sla de presentatie op.

Dit PHP‑voorbeeld kent een aangepast startnummer toe aan elke alinea:

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

## **Alinea‑lay‑out en eind‑eigenschappen beheren**

### **Een eerste‑regels‑inspringing instellen**

Gebruik [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) om de eerste‑regels‑inspringing van een alinea te bepalen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑lichaam.

Gebruik [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) wanneer je de hele alinea wilt verplaatsen. Gebruik [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) wanneer je alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt verschillende alinea's en past verschillende [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) waarden toe om te laten zien hoe de eerste‑regels‑inspringing de alinea‑lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak verschillende alinea's en stel verschillende [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) waarden in.
6. Voeg de alinea's toe aan het tekstframe.
7. Sla de gewijzigde presentatie op.

Dit PHP‑codefragment toont hoe je een alinea‑inspringing instelt:

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

![De eerste‑regels‑inspringing van de alinea's](first_line_indent.png)

### **Een hangende inspringing instellen**

Een hangende inspringing is een alinea‑lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëer je dit effect met [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-). Geef een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk bepaalt [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) de linkermarge van het alinea‑lichaam, en [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) de positie van de eerste regel ten opzichte van die marge. Voor een hangende inspringing geef je een positieve waarde aan `setMarginLeft` en een negatieve waarde aan `setIndent`.

Deze opmaak is handig voor bibliografieën, referenties, glossarium‑items en andere alinea's waarbij de regelomslag onder het alinea‑lichaam moet uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open de doeldia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
5. Maak alinea's en geef een positieve waarde aan [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) voor elke alinea.
6. Geef een negatieve waarde aan [ParagraphFormat::setIndent](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setIndent-float-) om het hangende‑inspringingseffect te verkrijgen.
7. Voeg de alinea's toe aan het tekstframe.
8. Sla de gewijzigde presentatie op.

Dit PHP‑codefragment toont hoe je een hangende inspringing voor een alinea instelt:

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

![De hangende inspringing van de alinea's](hanging_indent.png)

### **Eind‑alinea‑run‑eigenschappen instellen**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) regelt de opmaak van het einde‑teken van een alinea. Het onderstaande PHP‑voorbeeld kent een lettergrootte en een Latijns lettertype toe aan het einde‑teken van de tweede alinea:

1. Laad een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) en open een dia.
2. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe en verwijder de standaardalinea.
3. Maak twee alinea's en voeg tekst‑Portion's toe.
4. Maak een [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/) voor het einde‑teken van de tweede alinea.
5. Stel [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) en [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) in.
6. Ken de opmaak toe met [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) en sla de presentatie op.

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

## **Alinea‑inhoud importeren en exporteren**

### **HTML‑tekst importeren in alinea's**

Gebruik [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) om HTML‑opmaak om te zetten in alinea's en Portion's in een tekstframe.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse.
2. Open een dia en voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) toe.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm en verwijder de standaardalinea.
4. Lees het bron‑HTML‑bestand.
5. Geef de HTML‑string door aan [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
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

Gebruik [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) om een geselecteerd bereik van alinea's als HTML te exporteren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Open de dia en zoek de [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) die de tekst bevat.
3. Open het [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/) van de vorm.
4. Roep [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) aan met het start‑alinea‑index en het aantal te exporteren alinea's.
5. Schrijf de geretourneerde HTML‑string naar een bestand.

Dit PHP‑voorbeeld exporteert alle alinea's uit de eerste tekstvorm:

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

[Paragraph::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getImage--) renderen een individuele alinea direct en geeft een [IImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/) terug. Sla het resultaat op in een bestand of stream met [IImage::save](https://reference.aspose.com/slides/nl/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Je hoeft de omvattende vorm niet te renderen of een bitmap handmatig te croppen.

[Paragraph::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getImage--) kan `null` retourneren als de alinea niet wordt gevonden in de bovenliggende verzameling, geen geldige renderingsgrenzen heeft, of niet kan worden gerenderd. Controleer het resultaat vóór het opslaan en maak de geretourneerde afbeelding na gebruik vrij.

#### **Een alinea renderen op de standaardschaal**

Stel dat we een presentatied bestand `sample.pptx` hebben met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

Het onderstaande PHP‑voorbeeld rendert de tweede alinea in een reguliere tekstvorm op de standaardschaal en slaat de verkregen afbeelding op in PNG‑formaat. Het `finally`‑blok zorgt ervoor dat de afbeelding correct wordt vrijgegeven.

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

![De alinea‑afbeelding](paragraph_to_image_output.png)

#### **Een alinea renderen in een tabelcel met schaling**

Gebruik de overload van [Paragraph::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getImage-float-float-) die de parameters `$scaleX` en `$scaleY` accepteert om de horizontale en verticale schaalfactoren in te stellen. Het onderstaande PHP‑voorbeeld maakt een tabel, rendert de alinea in de eerste cel op dubbel de standaardbreedte en -hoogte, en slaat het resultaat op als PNG‑afbeelding.

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

Een schaalfactor van `1` behoudt die as op de standaardpixelgrootte. Bijvoorbeeld `2` voor beide factoren resulteert in een afbeelding waarvan breedte en hoogte ongeveer het dubbele zijn van de standaardafmetingen, wat vier keer zoveel pixels oplevert. Grotere factoren geven doorgaans scherpere tekst bij inzoomen of hoge‑resolutie‑output, maar verhogen ook het geheugenverbruik en de bestandsgrootte. Factoren onder `1` produceren kleinere afbeeldingen met minder detail. Gebruik gelijke factoren om de beeldverhouding van de alinea te behouden; verschillende horizontale en verticale factoren rekken de output onafhankelijk uit.

Een volledige vorm renderen met [Shape::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage--) blijft nuttig wanneer de output de vulling, rand of andere visuele context van de vorm moet bevatten. Voor een afbeelding uitsluitend van een alinea, gebruik [Paragraph::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Kan ik het regelomloop volledig uitschakelen binnen een tekstframe?**

Ja. Stel [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setWrapText-byte-) in om omloop te vermijden zodat regels niet afgebroken worden aan de randen van het tekstframe.

**Hoe krijg ik de exacte on‑dia‑grenzen van een specifieke alinea?**

Gebruik [Paragraph::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getRect--) om de begrenzende rechthoek van de alinea op te halen. [Portion::getRect](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portion/#getRect--) geeft de grenzen van een individuele Portion.

**Waar wordt de alinea‑uitlijning (links, rechts, gecentreerd of uitgevuld) geregeld?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setAlignment-int-) is een alinea‑niveau instelling en geldt voor de volledige alinea ongeacht de opmaak van individuele Portion's.

**Kan ik de proefleestoets voor een deel van een alinea instellen?**

Ja. Stel [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) in voor individuele Portion's, zodat één alinea tekst in meerdere talen kan bevatten.