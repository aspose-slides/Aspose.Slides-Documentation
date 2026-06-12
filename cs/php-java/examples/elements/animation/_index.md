---
title: Animace
type: docs
weight: 100
url: /cs/php-java/examples/elements/animation/
keywords:
- animace
- přidat animaci
- přístup k animaci
- odstranit animaci
- sekvence animací
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládejte animace snímků v PHP s Aspose.Slides: přidávejte, upravujte a odstraňujte efekty, načasování a spouštěče pro tvorbu dynamických prezentací ve formátech PPT, PPTX a ODP."
---
Ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for PHP via Java**.

## **Přidat animaci**

Vytvořte tvar obdélníku a použijte efekt postupného objevení (fade‑in) spouštěný kliknutím.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Efekt postupného objevení.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Přístup k prvnímu animačnímu efektu.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit animaci**

Odstraňte animační efekt ze sekvence.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Odstranit efekt.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sekvence animací**

Přidejte více efektů a ukažte pořadí, v jakém se animace provádějí.

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