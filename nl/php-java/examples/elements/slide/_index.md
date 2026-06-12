---
title: Dia
type: docs
weight: 10
url: /nl/php-java/examples/elements/slide/
keywords:
- dia
- dia toevoegen
- dia benaderen
- dia index
- dia dupliceren
- dia's herschikken
- dia verwijderen
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer dia's in PHP met Aspose.Slides: maak, dupliceer, herschik, verberg, stel achtergronden en grootte in, pas overgangen toe en exporteer naar PowerPoint en OpenDocument."
---
Dit artikel biedt een reeks voorbeelden die laten zien hoe u met dia's kunt werken met **Aspose.Slides for PHP via Java**. U leert hoe u dia's kunt toevoegen, benaderen, dupliceren, herschikken en verwijderen met behulp van de `Presentation`‑klasse.

Elk voorbeeld hieronder bevat een korte uitleg, gevolgd door een codefragment in PHP.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank`‑lay-out en voegen we een lege dia toe aan de presentatie.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Elke dia is gebaseerd op een lay-out, die zelf gebaseerd is op een masterdia.
        // Gebruik de Blank lay-out om een nieuwe dia te maken.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Voeg een nieuwe lege dia toe met de geselecteerde lay-out.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** Elke dia‑lay-out is afgeleid van een masterdia, die het algemene ontwerp en de plaatsaanduidingsstructuur definieert. De afbeelding hieronder toont hoe masterdia's en hun bijbehorende lay‑outs zijn georganiseerd in PowerPoint.

![Relatie tussen masterdia en lay-out](master-layout-slide.png)

## **Dia's benaderen op index**

U kunt dia's benaderen met hun index.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Toegang tot een dia via index.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dia dupliceren**

Dit voorbeeld laat zien hoe u een bestaande dia kunt dupliceren. De gedupliceerde dia wordt automatisch aan het einde van de dia‑collectie toegevoegd.

```php
function cloneSlide() {
    // Standaard bevat de presentatie één lege dia.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dupliceer de eerste dia; deze wordt aan het einde van de presentatie toegevoegd.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // De index van de gedupliceerde dia is 1 (tweede dia in de presentatie).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dia's herschikken**

U kunt de volgorde van dia's wijzigen door er een naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een dia naar de eerste positie.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Verplaats de dia naar de eerste positie (andere dia's schuiven naar beneden).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dia verwijderen**

Om een dia te verwijderen, verwijst u er eenvoudignaar en roept u `remove` aan. Dit voorbeeld verwijdert dia's op basis van index en referentie.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Verwijder een dia via index.
        $presentation->getSlides()->removeAt(0);

        // Verwijder een dia via referentie.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```