---
title: Sidhuvud och sidfot
type: docs
weight: 220
url: /sv/php-java/examples/elements/header-footer/
keywords:
- sidhuvud och sidfot
- lägga till sidhuvud och sidfot
- uppdatera sidhuvud och sidfot
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Kontrollera sidhuvuden och sidfötter i PHP med Aspose.Slides: lägg till eller redigera datum/tid, bildnummer och sidfotstext, visa eller dölj platshållare i PPT, PPTX och ODP."
---
Visar hur man lägger till sidfot och uppdaterar datum- och tidsplatshållare med **Aspose.Slides for PHP via Java**.

## **Lägg till en sidfot**

Lägg till text i sidfotområdet på en bild och gör den synlig.

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uppdatera datum och tid**

Ändra datum- och tidsplatshållaren på en bild.

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```