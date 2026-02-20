---
title: Animation
type: docs
weight: 100
url: /de/php-java/examples/elements/animation/
keywords:
- Animation
- Animation hinzufügen
- Auf Animation zugreifen
- Animation entfernen
- Animationssequenz
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Meistern Sie Folienanimationen in PHP mit Aspose.Slides: Fügen Sie Effekte, Zeitsteuerungen und Trigger hinzu, bearbeiten und entfernen Sie sie, um dynamische Präsentationen in PPT, PPTX und ODP zu erstellen."
---
Zeigt, wie einfache Animationen erstellt und ihre Reihenfolge verwaltet werden können mit **Aspose.Slides for PHP via Java**.

## **Animation hinzufügen**

Ein Rechteck erstellen und einen Fade-in-Effekt hinzufügen, der bei Klick ausgelöst wird.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Fade-In-Effekt.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Auf eine Animation zugreifen**

Den ersten Animationseffekt aus der Folien-Zeitleiste abrufen.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Greifen Sie auf den ersten Animationseffekt zu.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animation entfernen**

Einen Animationseffekt aus der Sequenz entfernen.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Effekt entfernen.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Animationen sequenzieren**

Mehrere Effekte hinzufügen und die Reihenfolge zeigen, in der Animationen ablaufen.

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