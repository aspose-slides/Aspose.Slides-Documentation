---
title: Animacja
type: docs
weight: 100
url: /pl/php-java/examples/elements/animation/
keywords:
- animacja
- dodaj animację
- dostęp do animacji
- usuń animację
- sekwencja animacji
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj animacje slajdów w PHP z Aspose.Slides: dodawaj, edytuj i usuwaj efekty, czasy i wyzwalacze, aby tworzyć dynamiczne prezentacje w formatach PPT, PPTX i ODP."
---
Pokazuje, jak tworzyć proste animacje i zarządzać ich kolejnością przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj animację**

Utwórz prostokątny kształt i zastosuj efekt stopniowego pojawiania się wyzwalany po kliknięciu.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Efekt stopniowego pojawiania się.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do animacji**

Pobierz pierwszy efekt animacji z osi czasu slajdu.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego efektu animacji.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń animację**

Usuń efekt animacji z kolejności.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Usuń efekt.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Kolejność animacji**

Dodaj wiele efektów i pokaż kolejność, w jakiej animacje się odbywają.

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