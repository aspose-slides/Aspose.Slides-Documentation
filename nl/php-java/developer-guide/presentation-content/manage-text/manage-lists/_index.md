---
title: Beheer opsommingstekens en genummerde lijsten in presentaties met PHP
linktitle: Lijsten beheren
type: docs
weight: 60
url: /nl/php-java/manage-lists/
keywords:
- opsommingsteken
- opsommingslijst
- genummerde lijst
- symbool opsommingsteken
- afbeeldings-opsommingsteken
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
description: "Leer hoe u opsommingstekens, afbeeldings-, meerlagige en genummerde lijsten kunt maken en opmaken in PowerPoint- en OpenDocument-presentaties met Aspose.Slides for PHP via Java."
---
## **Overzicht**

Aspose.Slides for PHP via Java stelt u in staat om opsommingstekens en genummerde lijsten te maken en op te maken in PowerPoint‑ en OpenDocument‑presentaties. Een lijstitem is een alinea waarvan de opsommingstekeninstellingen worden gecontroleerd via de alinea‑opmaak.

Gebruik de [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat)‑methode om lijstinstellingen op alinea‑niveau te benaderen. Het belangrijkste startpunt is [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet) dat een [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/)‑object retourneert. Met dit object kunt u het type opsommingsteken, symbool, afbeelding, kleur, grootte, nummeringsstijl en startnummer instellen.

Dit artikel laat zien hoe u:

- een opsomming met een aangepast symbool maakt
- een afbeeldings‑opsommingsteken maakt
- een meerlagige lijst maakt door de alinea‑diepte in te stellen
- een genummerde lijst maakt
- de lijstopmaak in een bestaande presentatie inspecteert en wijzigt
- de werkelijke lijstmarkeringen en nummers leest naast de alinea‑tekst

## **Een opsomming maken**

Om een opsomming te maken, voegt u [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)‑objecten toe aan een [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) en stelt u [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) in op [BulletType::Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol). Vervolgens kunt u [BulletFormat::setChar](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setChar), [BulletFormat::getColor](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getColor) en [BulletFormat::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setHeight) gebruiken om het uiterlijk van het opsommingsteken te regelen.

De volgende PHP‑code laat zien hoe u een opsomming maakt in een dia:

```php
use aspose\slides\BulletType;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Het resultaat:

![The symbol bullets](symbol_bullets.png)

## **Een genummerde lijst maken**

Gebruik genummerde lijsten wanneer de volgorde van de items belangrijk is. Stel [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) in op [BulletType::Numbered](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Numbered). U kunt ook een nummeringsformaat kiezen met [BulletFormat::setNumberedBulletStyle](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle) of [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith) wanneer de lijst moet beginnen bij een andere waarde dan 1.

De volgende PHP‑code laat zien hoe u een genummerde lijst maakt in een dia:

```php
use aspose\slides\BulletType;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Het resultaat:

![The numbered bullets](numbered_bullets.png)

## **Een afbeeldings‑opsommingsteken maken**

Aspose.Slides maakt het mogelijk om een regulier opsommingsteken te vervangen door een afbeelding. Afbeeldings‑opsommingstekens werken het best met eenvoudige afbeeldingen die leesbaar blijven op een kleine grootte, zoals iconen of kleine transparante PNG‑bestanden.

{{% alert color="info" title="Note" %}}
Idealiter kiest u, als u van plan bent het reguliere opsommingsteken te vervangen door een afbeelding, een eenvoudige grafiek met een transparante achtergrond. Dergelijke afbeeldingen werken goed als aangepaste opsommingstekens.
{{% /alert %}}

Houd er rekening mee dat de afbeelding wordt verkleind tot een zeer kleine afmeting. Daarom raden wij sterk aan een afbeelding te selecteren die duidelijk en visueel effectief blijft wanneer deze wordt gebruikt als opsommingsteken in een lijst.

Om een afbeeldings‑opsommingsteken te maken, voegt u een afbeelding toe aan [Presentation::getImages](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getImages) en wijst u het geretourneerde [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑object toe aan [BulletFormat::getPicture](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#getPicture). Stel [BulletFormat::setType](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/#setType) in op [BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) voordat u de afbeelding toewijst.

Stel, we hebben een “image.png”:

![A picture for the bullets](picture_for_bullets.png)

De volgende PHP‑code laat zien hoe u afbeeldings‑opsommingstekens maakt in een dia:

```php
use aspose\slides\BulletType;
use aspose\slides\Images;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Het resultaat:

![The picture bullets](picture_bullets.png)

## **Een meerlagige lijst maken**

Gebruik [ParagraphFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDepth) om lijstitems op verschillende niveaus te plaatsen. Niveau 0 is het bovenste niveau, niveau 1 is genest onder niveau 0, enzovoort.

De volgende PHP‑code laat zien hoe u een meerlagige opsomming maakt:

```php
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

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
    $presentation->dispose();
}
```

Het resultaat:

![The multilevel list](multilevel_list.png)

## **Een bestaande lijst wijzigen**

Om de lijstopmaak in een bestaande presentatie te wijzigen, benadert u de desbetreffende alinea en werkt u de [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet)‑instellingen bij. Dezelfde eigenschappen die gebruikt worden om lijsten te maken, kunnen ook worden gebruikt om lijsten die geladen zijn uit een PPT, PPTX of ODP‑bestand te inspecteren of aan te passen.

De volgende PHP‑code wijzigt de eerste alinea in een tekstvak zodat deze een genummerde lijststijl gebruikt:

```php
use aspose\slides\BulletType;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
    $presentation->dispose();
}
```

## **Werkelijke opsommingstekens lezen**

Bij het extraheren van presentatietekst houdt u lijstmarkeringen naast de alinea‑tekst. Roep [ParagraphFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getEffective) aan en benader [ParagraphFormatEffectiveData::getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) om het effectieve opsommingstekenformaat te verkrijgen. Controleer eerst de [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) voordat u [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) leest.

Voor genummerde lijsten onderscheidt u deze drie waarden:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) bepaalt het formaat, bijvoorbeeld Arabische cijfers gevolgd door een punt of kleine letters gevolgd door een punt.
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) geeft het startnummer voor een groep genummerde alinea’s aan.
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retourneert de opgemaakte markering voor een specifieke alinea. Bijvoorbeeld, het tweede item in een lijst die bij 5 begint, geeft `6.` terug.

Behoud [getDepth](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDepth) bij elke alinea om het inspringniveau te behouden. De werkelijke markering encodeert niet de volledige hiërarchie: een genest item kan `c.` retourneren in plaats van een gecombineerde label zoals `6.c.`.

De volgende zelfstandige voorbeeldcode maakt lijsten, slaat ze op in een presentatie, en laadt de presentatie opnieuw om voor elke alinea de tekst, diepte, opsommingstype en werkelijke waarde te rapporteren. De kleine blauwe afbeeldingsmarkering wordt gemaakt vanuit inline SVG.

```php
use aspose\slides\BulletType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\NumberedBulletStyle;
use aspose\slides\Paragraph;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 440, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20, 660, 400);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    // Maak een afbeelding‑markering zonder extern afbeeldingsbestand.
    $svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    $bulletImage = $presentation->getImages()->addImage($svg);

    $black = new Java("java.awt.Color", 0, 0, 0);
    $addParagraph = function ($text, $depth, $type, $start, $style) use ($textFrame, $bulletImage, $black) {
        $paragraph = new Paragraph();
        $paragraph->setText($text);

        $format = $paragraph->getParagraphFormat();
        $format->setDepth($depth);
        $format->setMarginLeft(30 + $depth * 40);
        $format->setIndent(-28);
        $format->setSpaceAfter(8);
        $format->getDefaultPortionFormat()->setFontHeight(22);
        $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $format->getBullet()->setType($type);
        $format->getBullet()->setBulletHardColor(NullableBool::True);
        $format->getBullet()->getColor()->setColor($black);
        if ($type == BulletType::Numbered) {
            $format->getBullet()->setNumberedBulletStyle($style);
            $format->getBullet()->setNumberedBulletStartWith($start);
        } else if ($type == BulletType::Symbol) {
            $format->getBullet()->setChar("\u{2022}");
        } else if ($type == BulletType::Picture) {
            $format->getBullet()->getPicture()->setImage($bulletImage);
        }

        $textFrame->getParagraphs()->add($paragraph);
    };

    $addParagraph("First item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Second item", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Next nested item", 1, BulletType::Numbered, 3, NumberedBulletStyle::BulletAlphaLCPeriod);
    $addParagraph("Deep item", 2, BulletType::Numbered, 4, NumberedBulletStyle::BulletRomanLCPeriod);
    $addParagraph("Back to top level", 0, BulletType::Numbered, 5, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Symbol marker", 0, BulletType::Symbol, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("No bullet", 0, BulletType::None, 1, NumberedBulletStyle::BulletArabicPeriod);
    $addParagraph("Picture marker", 0, BulletType::Picture, 1, NumberedBulletStyle::BulletArabicPeriod);
    $presentation->save("actual_bullet_values.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    $loadedShape = $loadedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Text | Depth | Type | Actual value\n";
    $paragraphs = $loadedShape->getTextFrame()->getParagraphs();
    for ($i = 0; $i < java_values($paragraphs->getCount()); $i++) {
        $paragraph = $paragraphs->get_Item($i);
        $bullet = $paragraph->getParagraphFormat()->getEffective()->getBullet();
        switch (java_values($bullet->getType())) {
            case BulletType::Numbered:
            case BulletType::Symbol:
                $marker = $bullet->getActualBulletValue();
                break;
            case BulletType::None:
                $marker = "null (no bullet)";
                break;
            case BulletType::Picture:
                $marker = "null (image required)";
                break;
            default:
                $marker = "unsupported bullet type";
                break;
        }
        $typeNames = [BulletType::Numbered => "Numbered", BulletType::Symbol => "Symbol", BulletType::None => "None", BulletType::Picture => "Picture"];
        $typeName = $typeNames[java_values($bullet->getType())] ?? "Unknown";
        echo $paragraph->getText() . " | " . $paragraph->getParagraphFormat()->getDepth() . " | " . $typeName . " | " . $marker . "\n";
    }
} finally {
    $loadedPresentation->dispose();
}
```

De bronlijsten worden hieronder getoond.

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

Het rapport komt overeen met de markeringen die in PowerPoint worden weergegeven:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

Voor [BulletType::None and BulletType::Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) retourneert `null`, niet een lege tekenreeks. Behandel deze types apart: de eerste heeft geen markering, terwijl de tweede vereist dat het opsommingsteken‑beeld apart wordt geëxtraheerd. Een afbeeldings‑opsommingsteken kan niet uitsluitend worden gereproduceerd door een tekst‑markering te extraheren.

## **FAQ**

**Kunnen opsommingstekens en genummerde lijsten geëxporteerd worden naar PDF of afbeeldingen?**

Ja. Aspose.Slides behoudt de lijstopmaak wanneer het doel‑formaat de overeenkomstige tekstlay-out en opsommingsteek‑functies ondersteunt.

**Kan ik lijsten bewerken in bestaande presentaties?**

Ja. Laad de presentatie, benader de desbetreffende alinea, inspecteer of werk de [ParagraphFormat::getBullet](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getBullet)‑instellingen bij, en sla de presentatie op.

**Kunnen lijsten niet‑Latijnse tekst bevatten?**

Ja. De tekst van lijstitems kan Unicode‑tekens bevatten, zodat u lijsten kunt maken in meertalige presentaties. Zorg ervoor dat de lettertypen die in de presentatie worden gebruikt de benodigde tekens ondersteunen.