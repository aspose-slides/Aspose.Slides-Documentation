---
title: NagłówekStopka
type: docs
weight: 220
url: /pl/php-java/examples/elements/header-footer/
keywords:
- nagłówek stopka
- dodaj nagłówek i stopkę
- zaktualizuj nagłówek i stopkę
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Kontroluj nagłówki i stopki w PHP za pomocą Aspose.Slides: dodawaj lub edytuj datę/godzinę, numery slajdów i tekst stopki, pokaż lub ukryj pola zastępcze w formatach PPT, PPTX i ODP."
---
Pokazuje, jak dodać stopki i zaktualizować pola zastępcze daty i godziny przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj stopkę**

Dodaj tekst do obszaru stopki slajdu i spraw, aby był widoczny.

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

## **Zaktualizuj datę i godzinę**

Zmodyfikuj pole zastępcze daty i godziny na slajdzie.

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