---
title: Hantera PowerPoint-textstycken i PHP
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/php-java/manage-paragraph/
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
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska styckeformatering med Aspose.Slides för PHP via Java — optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla klasser du behöver för att arbeta med PowerPoint-texter, stycken och portioner.

* Aspose.Slides tillhandahåller klassen [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) för att låta dig lägga till objekt som representerar ett stycke. Ett `TextFame`‑objekt kan ha ett eller flera stycken (varje stycke skapas genom ett radbrytningstecken).
* Aspose.Slides tillhandahåller klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) för att låta dig lägga till objekt som representerar portioner. Ett `Paragraph`‑objekt kan ha en eller flera portioner (samling av portionsobjekt).
* Aspose.Slides tillhandahåller klassen [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) för att låta dig lägga till objekt som representerar texter och deras formateringsegenskaper.

Ett `Paragraph`‑objekt kan hantera texter med olika formateringsegenskaper via sina underliggande `Portion`‑objekt.

## **Lägg till flera stycken som innehåller flera portioner**

Dessa steg visar hur du lägger till en textruta som innehåller 3 stycken och varje stycke innehåller 3 portioner:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Hämta ITextFrame som är associerad med [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/).
5. Skapa två [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/)‑objekt och lägg till dem i stycke‑samlingen för [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
6. Skapa tre [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)‑objekt för varje nytt `Paragraph` (två Portion‑objekt för standard‑Paragraph) och lägg varje `Portion`‑objekt i portionssamlingen för respektive `Paragraph`.
7. Ange text för varje portion.
8. Tillämpa önskade formateringsfunktioner på varje portion med hjälp av formateringsegenskaperna som erbjuds av `Portion`‑objektet.
9. Spara den modifierade presentationen.

Denna PHP‑kod är en implementation av stegen för att lägga till stycken som innehåller portioner:

```php
# Instansiera en Presentation-klass som representerar en PPTX-fil
$pres = new Presentation();
try {
    # Hämtar första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägg till en AutoShape av rektangeltyp
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Hämtar TextFrame för AutoShape
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
    # Spara PPTX till disk
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Hantera stycke‑punkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Punktmarkerade stycken är alltid lättare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till den valda bilden.
4. Hämta autoformens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standard‑stycket i `TextFrame`.
6. Skapa det första stycket med hjälp av klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/).
7. Ange punktens `Type` för stycket till `Symbol` och sätt punkttecknet.
8. Ange styckets `Text`.
9. Ange styckets `Indent` för punkten.
10. Ange en färg för punkten.
11. Ange en höjd för punkten.
12. Lägg till det nya stycket i `TextFrame`‑styckesamlingen.
13. Lägg till det andra stycket och upprepa processen som beskrivs i steg 7‑13.
14. Spara presentationen.

Denna PHP‑kod visar hur du lägger till en stycke‑punkt:

```php
# Instansierar en Presentation-klass som representerar en PPTX-fil
$pres = new Presentation();
try {
    # Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till och hämtar Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Hämtar autoshapens textruta
    $txtFrm = $aShp->getTextFrame();
    # Tar bort standard‑stycket
    $txtFrm->getParagraphs()->removeAt(0);
    # Skapar ett stycke
    $para = new Paragraph();
    # Ställer in ett styckepunktformat och symbol
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Ställer in styckets text
    $para->setText("Welcome to Aspose.Slides");
    # Ställer in punktindrag
    $para->getParagraphFormat()->setIndent(25);
    # Ställer in punktfärg
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// sätt IsBulletHardColor till true för att använda egen punktfärg
    # Ställer in punktens höjd
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Lägger till stycke i textrutan
    $txtFrm->getParagraphs()->add($para);
    # Skapar andra stycket
    $para2 = new Paragraph();
    # Ställer in stycke-punktens typ och stil
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Lägger till stycke-text
    $para2->setText("This is numbered bullet");
    # Ställer in punktindrag
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// sätt IsBulletHardColor till true för att använda egen punktfärg
    # Ställer in punktens höjd
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Lägger till stycke i textrutan
    $txtFrm->getParagraphs()->add($para2);
    # Sparar den modifierade presentationen
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildstycken är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Hämta autoformens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standard‑stycket i `TextFrame`.
6. Skapa det första stycket med hjälp av klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/).
7. Läs in bilden i [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/).
8. Ställ in punktens typ till [Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/#Picture) och ange bilden.
9. Ange styckets `Text`.
10. Ange styckets `Indent` för punkten.
11. Ange en färg för punkten.
12. Ange en höjd för punkten.
13. Lägg till det nya stycket i `TextFrame`‑styckesamlingen.
14. Lägg till det andra stycket och upprepa processen baserat på föregående steg.
15. Spara den modifierade presentationen.

Denna PHP‑kod visar hur du lägger till och hanterar bildpunkter:

```php
# Instansierar en Presentation-klass som representerar en PPTX-fil
$presentation = new Presentation();
try {
    # Hämtar den första bilden
    $slide = $presentation->getSlides()->get_Item(0);
    # Instansierar bilden för punkter
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Lägger till och hämtar Autoshape
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Hämtar autoshapens textruta
    $textFrame = $autoShape->getTextFrame();
    # Tar bort standard‑stycket
    $textFrame->getParagraphs()->removeAt(0);
    # Skapar ett nytt stycke
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Ställer in styckepunktstil och bild
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Ställer in punktens höjd
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Lägger till stycke i textrutan
    $textFrame->getParagraphs()->add($paragraph);
    # Sparar presentationen som en PPTX-fil
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Sparar presentationen som en PPT-fil
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Hantera flernivå‑punkter**

Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivå‑punkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) i den nya bilden.
4. Hämta autoformens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standard‑stycket i `TextFrame`.
6. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa det andra stycket via `Paragraph`‑klassen och sätt djupet till 1.
8. Skapa det tredje stycket via `Paragraph`‑klassen och sätt djupet till 2.
9. Skapa det fjärde stycket via `Paragraph`‑klassen och sätt djupet till 3.
10. Lägg till de nya styckena i `TextFrame`‑styckesamlingen.
11. Spara den modifierade presentationen.

Denna PHP‑kod visar hur du lägger till och hanterar flernivå‑punkter:

```php
# Instansierar en Presentation-klass som representerar en PPTX-fil
$pres = new Presentation();
try {
    # Hämtar den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till och hämtar Autoshape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Hämtar textrutan för den skapade autoshapen
    $text = $aShp->addTextFrame("");
    # Rensar standard‑stycket
    $text->getParagraphs()->clear();
    # Lägger till det första stycket
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ställer in punktnivån
    $para1->getParagraphFormat()->setDepth(0);
    # Lägger till det andra stycket
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ställer in punktnivån
    $para2->getParagraphFormat()->setDepth(1);
    # Lägger till det tredje stycket
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ställer in punktnivån
    $para3->getParagraphFormat()->setDepth(2);
    # Lägger till det fjärde stycket
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Ställer in punktnivån
    $para4->getParagraphFormat()->setDepth(3);
    # Lägger till stycken i samlingen
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Sparar presentationen som en PPTX-fil
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Hantera ett stycke med en anpassad numrerad lista**

Klassen [BulletFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/) tillhandahåller metoden [setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) och andra som låter dig hantera stycken med anpassad numrering eller formatering.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta bilden som innehåller stycket.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Hämta autoformens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standard‑stycket i `TextFrame`.
6. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/) och sätt [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) till 2.
7. Skapa det andra stycket via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 3.
8. Skapa det tredje stycket via `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya styckena i `TextFrame`‑styckesamlingen.
10. Spara den modifierade presentationen.

Denna PHP‑kod visar hur du lägger till och hanterar stycken med anpassad numrering eller formatering:

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Hämtar textrutan för den skapade autoshapen
    $textFrame = $shape->getTextFrame();
    # Tar bort standard-stycket
    $textFrame->getParagraphs()->removeAt(0);
    # Första listan
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

## **Ställ in första‑rad‑indrag för ett stycke**

Använd metoden [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/) för att kontrollera första‑rad‑indraget för ett stycke. Denna metod flyttar bara den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade med styckeskroppen.

Använd [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginleft/) när du behöver flytta hela stycket. Använd [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och tillämpar olika indragsvärden för att demonstrera hur första‑rad‑indraget påverkar stycke‑layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) till formen och ta bort standard‑stycket.
5. Skapa flera stycken och sätt olika [Indent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/)‑värden för dem.
6. Lägg till styckena i textrutan.
7. Spara den modifierade presentationen.

Denna kod visar hur du anger ett styckeindrag:

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

Resultatet:

![Första radens indrag av styckena](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med metoden [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/). Sätt indraget till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginleft/) den vänstra positionen för styckeskroppen, och [ParagraphFormat::setIndent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, uppslagsord och andra stycken där radbrytningar måste linjera under styckets kropp snarare än under första tecknet i första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) till formen och ta bort standard‑stycket.
5. Skapa stycken och sätt ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setmarginleft/)‑värde för varje stycke.
6. Sätt ett negativt [Indent](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setindent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textrutan.
8. Spara den modifierade presentationen.

Denna kod visar hur du anger ett hängande indrag för ett stycke:

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

Resultatet:

![Hängande indrag av styckena](hanging_indent.png)

## **Hantera slut‑stycke‑körnings‑egenskaper**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta referensen till bilden som innehåller stycket via dess position.
1. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
1. Lägg till en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) med två stycken till rektangeln.
1. Ställ in teckenhöjd och teckensnittstyp för styckena.
1. Ställ in slut‑egenskaperna för styckena.
1. Spara den modifierade presentationen som en PPTX‑fil.

Denna PHP‑kod visar hur du anger slut‑egenskaper för stycken i PowerPoint:

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

## **Importera HTML‑text till stycken**

Aspose.Slides erbjuder förbättrat stöd för att importera HTML‑text till stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
2. Hämta referensen till den aktuella bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) till bilden.
4. Lägg till och hämta `AutoShape`‑ens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Ta bort standard‑stycket i `TextFrame`.
6. Läs in käll‑HTML‑filen i en TextReader.
7. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll från den lästa TextReadern till TextFrame‑s [ParagraphCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphcollection/).
9. Spara den modifierade presentationen.

Denna PHP‑kod är en implementation av stegen för att importera HTML‑texter i stycken:

```php
# Skapa tom presentation‑instans
$pres = new Presentation();
try {
    # Hämta standardförsta bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till AutoShape för att rymma HTML‑innehållet
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Lägger till textruta i formen
    $ashape->addTextFrame("");
    # Rensar alla stycken i den tillagda textrutan
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Laddar HTML‑filen med stream‑läsare
    $tr = new StreamReader("file.html");
    # Lägger till text från HTML‑stream‑läsaren i textrutan
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Sparar presentationen
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Exportera stycke‑text till HTML**

Aspose.Slides erbjuder förbättrat stöd för att exportera texter (innehållande i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) och läs in önskad presentation.
2. Hämta referensen till den aktuella bilden via dess index.
3. Hämta formen som innehåller texten som ska exporteras till HTML.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett startindex till StreamWriter och exportera de önskade styckena.

Denna PHP‑kod visar hur du exporterar PowerPoint‑stycketexter till HTML:

```php
# Läs in presentationsfilen
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Hämta standardförsta bilden i presentationen
    $slide = $pres->getSlides()->get_Item(0);
    # Önskat index
    $index = 0;
    # Hämtar den tillagda formen
    $ashape = $slide->getShapes()->get_Item($index);
    # Skapar utdata‑HTML‑fil
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extraherar första stycket som HTML
    # Skriver stycke‑data till HTML genom att ange startindex för stycket, totalt antal stycken som ska kopieras
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Spara ett stycke som bild**

I detta avsnitt utforskar vi två exempel som visar hur man sparar ett textstycke, representerat av klassen [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/), som en bild. Båda exemplen inkluderar att hämta bilden av en form som innehåller stycket med `getImage`‑metoderna från klassen [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/), beräkna styckets gränser inom formen och exportera det som en bitmap‑bild. Dessa tillvägagångssätt möjliggör att extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenarier.

Låt oss anta att vi har en presentationsfil kallad sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![Textrutan med tre stycken](paragraph_to_image_input.png)

**Exempel 1**

I detta exempel hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bildens form från den första bilden i presentationen och beräknar sedan gränserna för det andra stycket i formens textruta. Stycket ritas sedan om på en ny bitmap‑bild som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar exakt dimension och formatering.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Spara formen i minnet som en bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Skapa en bitmap av formen från minnet.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Beräkna koordinaterna och storleken för utdata-bilden (minsta storlek - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Beskär formens bitmap för att bara få stycke-bitmapen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Resultatet:

![Styckebilden](paragraph_to_image_output.png)

**Exempel 2**

I detta exempel utvidgar vi föregående metod genom att lägga till skalningsfaktorer till styckebilden. Formen extraheras från presentationen och sparas som en bild med en skalningsfaktor på `2`. Detta möjliggör en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalan. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, till exempel för högkvalitativt tryck.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Spara formen i minnet som en bitmap med skalning.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Skapa en bitmap av formen från minnet.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Beräkna gränserna för det andra stycket.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Beräkna koordinaterna och storleken för utdata-bilden (minsta storlek - 1x1 pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Beskär formens bitmap för att endast få stycke-bitmapen.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textruta?**

Ja. Använd textrutans radbrytningsinställning ([setWrapText](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/setwraptext/)) för att stänga av radbrytning så att raderna inte bryts vid ramens kanter.

**Hur får jag exakt position på en viss paragraf på bilden?**

Du kan hämta styckets (och även en enskild portions) avgränsningsrektangel för att veta dess exakta position och storlek på bilden.

**Var styrs styckejustering (vänster/höger/centrerat/justify)?**

[Alignment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/setalignment/) är en inställning på styckelnivå i [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/); den gäller hela stycket oavsett individuell portionsformatering.

**Kan jag ange ett stavningsspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket sätts på portionsnivå ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId)), så flera språk kan samexistera inom ett och samma stycke.