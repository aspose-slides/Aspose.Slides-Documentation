---
title: Hantera textdelar i presentationer med PHP
linktitle: Textdel
type: docs
weight: 70
url: /sv/php-java/portion/
keywords:
- textdel
- textdel
- textkoordinater
- textposition
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du hanterar textdelar i PowerPoint-presentationer med Aspose.Slides för PHP via Java, vilket förbättrar prestanda och anpassning."
---
## **Introduktion**

En textdel representerar ett specifikt fragment av text i ett stycke och gör det möjligt att arbeta med det fragmentet oberoende av omgivande innehåll. I Aspose.Slides kan portioner användas när du behöver hämta positionen för ett textfragment, tillämpa formatering på enbart en del av ett stycke eller kontrollera textbeteende på en mer detaljerad nivå.

## **Hämta koordinater för en textdel**
[**getCoordinates()**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/getcoordinates/)‑metoden har lagts till i klassen [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/) som möjliggör att hämta koordinaterna för början av delen.

```php
  # Instansiera Presentation-klass som representerar PPTX
  $pres = new Presentation();
  try {
    # Omforma kontexten för presentationen
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    foreach($textFrame->getParagraphs() as $paragraph) {
      foreach($paragraph->getPortions() as $portion) {
        $point = $portion->getCoordinates();
        echo("X: " . $point->$x . " Y: " . $point->$y);
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Kan jag tillämpa en hyperlänk på bara en del av texten i ett enda stycke?**

Ja, du kan [tilldela en hyperlänk](/slides/sv/php-java/manage-hyperlinks/) till en enskild del; endast det fragmentet blir klickbart, inte hela stycket.

**Hur fungerar stilarv: vad åsidosätter en Portion, och vad tas från Paragraph/TextFrame?**

Egenskaper på Portion‑nivå har högsta prioritet. Om en egenskap inte är angiven på [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/), hämtar motorn den från [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/); om den inte är angiven där heller, från [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) eller [theme](https://reference.aspose.com/slides/sv/php-java/aspose.slides/theme/)‑stilen.

**Vad händer om det typsnitt som angetts för en Portion saknas på målmaskinen/-servern?**

[Regler för typsnittsersättning](/slides/sv/php-java/font-selection-sequence/) tillämpas. Texten kan omflöda: mått, bindestreckning och bredd kan förändras, vilket är viktigt för exakt positionering.

**Kan jag ange en Portion‑specifik textfyllnads‑transparens eller gradient oberoende av resten av stycket?**

Ja, textfärg, fyllning och transparens på [Portion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portion/)-nivå kan skilja sig från intilliggande fragment.