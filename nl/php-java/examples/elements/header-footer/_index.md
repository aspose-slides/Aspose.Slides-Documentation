---
title: Koptekst en voettekst
type: docs
weight: 220
url: /nl/php-java/examples/elements/header-footer/
keywords:
- koptekst en voettekst
- koptekst en voettekst toevoegen
- koptekst en voettekst bijwerken
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer kopteksten en voetteksten in PHP met Aspose.Slides: voeg datum/tijd toe of bewerk deze, dia‑nummers en voettekst, toon of verberg plaatsaanduidingen in PPT, PPTX en ODP."
---
Toont hoe u voetteksten kunt toevoegen en datum- en tijd-plaatsaanduidingen kunt bijwerken met **Aspose.Slides for PHP via Java**.

## **Voettekst toevoegen**

Voeg tekst toe aan het voettekstgebied van een dia en maak deze zichtbaar.

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

## **Datum en tijd bijwerken**

Wijzig de datum- en tijd-plaatsaanduiding op een dia.

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