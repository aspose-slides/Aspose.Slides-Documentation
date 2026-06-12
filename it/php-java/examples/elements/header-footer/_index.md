---
title: Intestazione e piè di pagina
type: docs
weight: 220
url: /it/php-java/examples/elements/header-footer/
keywords:
- intestazione piè di pagina
- aggiungi intestazione piè di pagina
- aggiorna intestazione piè di pagina
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci intestazioni e piè di pagina in PHP con Aspose.Slides: aggiungi o modifica data/ora, numeri delle diapositive e testo del piè di pagina, mostra o nascondi i segnaposti in PPT, PPTX e ODP."
---
Mostra come aggiungere i piè di pagina e aggiornare i segnaposto data e ora utilizzando **Aspose.Slides for PHP via Java**.

## **Aggiungi un piè di pagina**

Aggiungi testo all'area del piè di pagina di una diapositiva e rendilo visibile.

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

## **Aggiorna data e ora**

Modifica il segnaposto data e ora su una diapositiva.

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