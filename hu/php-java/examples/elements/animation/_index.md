---
title: Animáció
type: docs
weight: 100
url: /hu/php-java/examples/elements/animation/
keywords:
- animáció
- animáció hozzáadása
- animáció elérése
- animáció eltávolítása
- animáció sorozat
- kód példák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Mesterszintű diák animációk PHP-ben az Aspose.Slides segítségével: hatások, időzítések és trigger-ek hozzáadása, szerkesztése és eltávolítása dinamikus prezentációk létrehozásához PPT, PPTX és ODP formátumban."
---
Bemutatja, hogyan hozhat létre egyszerű animációkat, és kezelheti azok sorrendjét a **Aspose.Slides for PHP via Java** használatával.

## **Animáció hozzáadása**

Hozzon létre egy téglalap alakzatot, és alkalmazzon egy kattintásra aktiválódó fade-in hatást.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Áttűnés hatás.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animáció elérése**

Szerezze meg az első animációs effektust a diák idővonaláról.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Első animációs effektus elérése.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animáció eltávolítása**

Töröljön egy animációs effektust a sorozatból.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Az effektus eltávolítása.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animációk szekvenciája**

Tegyen hozzá több effektust, és mutassa be, milyen sorrendben zajlanak az animációk.

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