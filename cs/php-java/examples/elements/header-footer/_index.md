---
title: Záhlaví a zápatí
type: docs
weight: 220
url: /cs/php-java/examples/elements/header-footer/
keywords:
- záhlaví a zápatí
- přidat záhlaví a zápatí
- aktualizovat záhlaví a zápatí
- ukázky kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládejte záhlaví a zápatí v PHP pomocí Aspose.Slides: přidejte nebo upravte datum/čas, čísla snímků a text zápatí, zobrazte nebo skryjte zástupné texty v PPT, PPTX a ODP."
---
Ukazuje, jak přidat zápatí a aktualizovat zástupce data a času pomocí **Aspose.Slides for PHP via Java**.

## **Přidat zápatí**

Přidejte text do oblasti zápatí snímku a zobrazte jej.

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

## **Aktualizovat datum a čas**

Upravte zástupce data a času na snímku.

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