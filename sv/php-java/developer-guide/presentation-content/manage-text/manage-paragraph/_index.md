---
title: Hantera PowerPoint-textstycken i PHP
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/php-java/manage-paragraph/
aliases:
  - /php-java/paragraph/
  - /php-java/portion/
keywords:
  - lägg till text
  - lägg till stycke
  - hantera text
  - hantera stycke
  - hantera punkt
  - styckeindrag
  - hängande indrag
  - styckepunkt
  - numrerad lista
  - punktlista
  - styckeegenskaper
  - importera HTML
  - text till HTML
  - stycke till HTML
  - stycke till bild
  - text till bild
  - exportera stycke
  - PowerPoint
  - presentation
  - PHP
  - Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punkter, numrerade listor, indrag, HTML-innehåll och styckebilder med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java representerar text som en hierarki av textramar, stycken och delar:

* [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess styckesamling.
* [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess delar och formatering på styckesnivå.
* [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) representerar en textkörning inom ett stycke. Varje del kan ha egen text och teckenformatering.

Ett stycke kan därför innehålla text med olika teckensnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, där varje stycke innehåller tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta den aktuella bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Använd standardstycket och lägg till två ytterligare [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/)‑objekt i textramen.
6. Lägg till tillräckligt med [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)‑objekt så att varje stycke får tre delar. Standardstycket innehåller redan en tom del.
7. Ange texten för varje del.
8. Tillämpa teckenformatering via [Portion::getPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getPortionFormat--).
9. Spara den modifierade presentationen.

Detta PHP‑exempel implementerar stegen:

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

## **Skapa punkt- och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [BulletFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på den valda bilden.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) för en symbolpunkt.
7. Anropa [BulletFormat::setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) med [BulletType::Symbol](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/) och ange punkttecknet.
8. Ställ in styckestext, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och anropa [BulletFormat::setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) med [BulletType::Numbered](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta PHP‑exempel skapar en symbolpunkt och en numrerad punkt:

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

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller siffra.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) och hämta dess [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) och ange dess text.
7. Anropa [BulletFormat::setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) med [BulletType::Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/).
8. Tilldela bilden via [BulletFormat::getPicture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#getPicture--) och ange punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den modifierade presentationen.

Detta PHP‑exempel skapar en bildpunkt:

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

### **Skapa en flernivålista**

Ange [ParagraphFormat::setDepth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setDepth-short-) för att placera stycken på olika nivåer i en lista. Toppenivån har djupet `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och öppna en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkttecken.
4. Ange deras [ParagraphFormat::setDepth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setDepth-short-) till `0`, `1`, `2` respektive `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta PHP‑exempel skapar en fyranivåpunktlista:

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

### **Starta numrerade listobjekt på anpassade värden**

Använd [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) för att ange det inledande numret som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Använd [BulletFormat::setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) med `2`, `3` respektive `7` för de olika styckena.
5. Lägg till styckena i textramen och spara presentationen.

Detta PHP‑exempel tilldelar ett eget startnummer till varje stycke:

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

## **Styr layout och slutegenskaper för stycken**

### **Ange första‑radens indrag**

Använd [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-) för att kontrollera första‑radens indrag i ett stycke. Denna metod flyttar endast den första raden relativt styckets vänstra marginal. Ett positivt värde förflyttar den första raden åt höger, medan de resterande raderna behåller sin placering i styckets kropp.

Använd [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) när du vill flytta hela stycket. Använd [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑värden för att demonstrera hur första‑radens indrag påverkar styckeformateringen.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa flera stycken och ange olika [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

Detta PHP‑kodexempel visar hur du anger ett styckeindrag:

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

Resultatet:

![The first-line indent of the paragraphs](first_line_indent.png)

### **Ange hängande indrag**

Ett hängande indrag är en styckeformat där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-). Ange ett negativt värde för att flytta den första raden åt vänster relativt styckets kropp.

I praktiken definierar [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) den vänstra positionen för styckets kropp, och [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-) definierar den första radens position relativt denna marginal. För att skapa ett hängande indrag, ange ett positivt värde till `setMarginLeft` och ett negativt värde till `setIndent`.

Denna formatering är användbar för bibliografier, referenser, uppslagsord och andra stycken där radbrytningar ska linjeras under styckets kropp istället för under det första tecknet i första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) och ta bort standardstycket.
5. Skapa stycken och ange ett positivt värde till [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setMarginLeft-float-) för varje stycke.
6. Ange ett negativt värde till [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setIndent-float-) för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

Detta PHP‑kodexempel visar hur du anger ett hängande indrag för ett stycke:

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

Resultatet:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Ange slutegenskaper för styckeelement**

[Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) styr formateringen av styckets avslutningstecken. Följande PHP‑exempel tilldelar en teckenstorlek och ett latinskt teckensnitt till avslutningstecknet för det andra stycket:

1. Läs in en [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och öppna en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/) för det andra styckets avslutningstecken.
5. Ange [BasePortionFormat::setFontHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setFontHeight-float-) och [BasePortionFormat::setLatinFont](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. Tilldela formatet med [Paragraph::setEndParagraphPortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#setEndParagraphPortionFormat-com.aspose.slides.PortionFormat-) och spara presentationen.

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

## **Import och export av styckeinnehåll**

### **Importera HTML‑text till stycken**

Använd [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) för att konvertera HTML‑markup till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Öppna en bild och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
3. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) och rensa dess standardstycke.
4. Läs in käll‑HTML‑filen.
5. Skicka HTML‑strängen till [ParagraphCollection::addFromHtml](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. Spara den modifierade presentationen.

Detta PHP‑exempel importerar HTML till en textram:

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

### **Exportera styckettext till HTML**

Använd [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) för att exportera ett valt intervall av stycken som HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in önskad presentation.
2. Öppna bilden och hitta den [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) som innehåller texten.
3. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
4. Anropa [ParagraphCollection::exportToHtml](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) med start‑styckeindex och antal stycken att exportera.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta PHP‑exempel exporterar alla stycken från den första textformen:

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

### **Rendera ett stycke som bild**

[Paragraph::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getImage--) renderar ett enskilt stycke direkt och returnerar en [IImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/). Spara resultatet till en fil eller ström med [IImage::save](https://reference.aspose.com/slides/sv/php-java/aspose.slides/iimage/#save-java.lang.String-int-). Du behöver inte rendera den omgivande formen eller beskära en bitmap manuellt.

[Paragraph::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getImage--) kan returnera `null` om stycket inte finns i sin föräldrakollektion, saknar giltiga renderingsgränser eller inte kan renderas. Kontrollera resultatet innan du sparar det och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Anta att vi har en presentationsfil kallad sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![The text box with three paragraphs](paragraph_to_image_input.png)

Följande PHP‑exempel renderar det andra stycket i en vanlig textform i standardskala och sparar den returnerade bilden i PNG‑format. `finally`‑blocket säkerställer att bilden frigörs korrekt.

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

Resultatet:

![The paragraph image](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [Paragraph::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getImage-float-float-)‑overloaden som accepterar parametrarna `$scaleX` och `$scaleY` för att ange horisontella och vertikala skalningsfaktorer. Följande PHP‑exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor bredd och höjd som standard, och sparar resultatet som en PNG‑bild.

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

En skalningsfaktor på `1` behåller den axeln på dess standardpixelstorlek. Till exempel ger `2` för båda faktorerna en bild vars bredd och höjd är ungefär dubbelt så stora som standard, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger vanligtvis skarpare text för zoomning eller högupplöst output, men ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara bildens proportioner; olika horisontella och vertikala faktorer sträcker bilden oberoende.

Att rendera en hel form med [Shape::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage--) är fortfarande användbart när output ska inkludera formens fyllning, kantlinje eller annan visuell kontext. För enbart bild på stycke, använd [Paragraph::getImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getImage--).

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/#setWrapText-byte-) för att inaktivera inbrytning så att rader inte bryts vid textramens kanter.

**Hur får jag exakt slide‑position för ett specifikt stycke?**

Använd [Paragraph::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getRect--) för att hämta styckets omgivande rektangel. [Portion::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/#getRect--) ger gränserna för en enskild del.

**Var styrs styckejustering (vänster, höger, centrerad eller marginaljusterad)?**

[ParagraphFormat::setAlignment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setAlignment-int-) är en inställning på styckesnivå och tillämpas på hela stycket oavsett individuell del‑formattering.

**Kan jag ange korrekturläsningsspråk för en del av ett stycke?**

Ja. Använd [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) för enskilda delar, så att ett stycke kan innehålla text på flera språk.