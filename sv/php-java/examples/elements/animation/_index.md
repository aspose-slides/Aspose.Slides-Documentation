---
title: Animation
type: docs
weight: 100
url: /sv/php-java/examples/elements/animation/
keywords:
- animation
- lägg till animation
- åtkomst till animation
- ta bort animation
- animationssekvens
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Behärska bildanimationer i PHP med Aspose.Slides: lägg till, redigera och ta bort effekter, tidsinställningar och triggers för att skapa dynamiska presentationer i PPT, PPTX och ODP."
---
Visar hur man skapar enkla animationer och hanterar deras sekvens med **Aspose.Slides for PHP via Java**.

## **Lägg till en animation**

Skapa en rektangelform och applicera en toningseffekt som triggas vid klick.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Toningseffekt.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första animationseffekten.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Ta bort effekten.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sekvensera animationer**

Lägg till flera effekter och visa i vilken ordning animationerna sker.

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