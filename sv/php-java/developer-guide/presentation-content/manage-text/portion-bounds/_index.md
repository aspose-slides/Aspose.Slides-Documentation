---
title: Hämta gränser för textdel i presentationer i PHP
linktitle: Delgränser
type: docs
weight: 47
url: /sv/php-java/portion-bounds/
keywords:
- gränser för textdel
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hämtar gränser för textdel i PowerPoint-presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

En textdel representerar ett specifikt fragment av text inom ett stycke och gör att du kan arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan delar användas när du behöver hämta gränserna för ett textfragment, applicera formatering på endast en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

Denna artikel visar hur du får den omslutande rektangeln för en del genom att använda [Portion::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/getrect/). Den visar också hur du får koordinaterna för början av en del genom att använda [Portion::getCoordinates](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/getcoordinates/). Dessutom belyser den vanliga scenarier relaterade till delar, såsom att applicera en hyperlänk på ett enskilt textfragment, förstå hur formatering löses genom del, stycke, textruta och tematisk arv, samt hantera situationer där ett specificerat teckensnitt saknas.

## **Hämta gränser för en textdel**

Använd [Portion::getRect](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/getrect/) för att hämta den omslutande rektangeln för en textdel:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Hämta koordinater för en textdel**

Använd [Portion::getCoordinates](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/getcoordinates/) för att hämta koordinaterna för början av en textdel:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Kan jag applicera en hyperlänk på bara en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/php-java/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad överskriver en del, och vad tas från ett stycke eller en textruta?**

Egenskaper på delnivå har högst prioritet. Om en egendom inte är angiven på [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/), hämtar Aspose.Slides den från [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/). Om den inte heller är angiven där, använder Aspose.Slides stilen från [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/theme/).

**Vad händer om det teckensnitt som anges för en del saknas på målmaskinen eller servern?**

[Regler för teckensnittssubstitution](/slides/sv/php-java/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, avstavning och bredd kan ändras, vilket är viktigt för exakt positionering.

**Kan jag ange delspecifik transparens eller ett gradientfyllning för texten oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) nivå kan skilja sig från intilliggande fragment.