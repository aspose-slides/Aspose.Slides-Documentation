---
title: Animatie
type: docs
weight: 100
url: /nl/php-java/examples/elements/animation/
keywords:
- animatie
- animatie toevoegen
- animatie openen
- animatie verwijderen
- animatievolgorde
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheers dia-animaties in PHP met Aspose.Slides: voeg effecten, timing en triggers toe, bewerk ze en verwijder ze om dynamische presentaties te maken in PPT, PPTX en ODP."
---
Toont hoe eenvoudige animaties te maken en hun volgorde te beheren met **Aspose.Slides for PHP via Java**.

## **Animatie toevoegen**

Maak een rechthoekvorm en pas een fade-in-effect toe dat wordt geactiveerd bij klikken.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Vervaag-effect.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Toegang tot een animatie**

Haal het eerste animatie-effect op uit de tijdlijn van de dia.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het eerste animatie-effect.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animatie verwijderen**

Verwijder een animatie-effect uit de volgorde.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Verwijder het effect.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animaties in volgorde**

Voeg meerdere effecten toe en toon de volgorde waarin de animaties plaatsvinden.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```