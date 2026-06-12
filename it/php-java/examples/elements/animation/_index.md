---
title: Animazione
type: docs
weight: 100
url: /it/php-java/examples/elements/animation/
keywords:
- animazione
- aggiungi animazione
- accedi animazione
- rimuovi animazione
- sequenza animazione
- esempi di codice
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Padroneggia le animazioni delle diapositive in PHP con Aspose.Slides: aggiungi, modifica e rimuovi effetti, tempistiche e trigger per creare presentazioni dinamiche in PPT, PPTX e ODP."
---
Mostra come creare animazioni semplici e gestire la loro sequenza utilizzando **Aspose.Slides per PHP via Java**.

## **Aggiungi un'animazione**

Crea una forma rettangolare e applica un effetto dissolvenza in ingresso attivato al clic.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Effetto di dissolvenza in ingresso.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Accedi a un'animazione**

Recupera il primo effetto di animazione dalla timeline della diapositiva.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accedi al primo effetto di animazione.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Rimuovi un'animazione**

Rimuovi un effetto di animazione dalla sequenza.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Rimuovi l'effetto.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sequenza di animazioni**

Aggiungi più effetti e dimostra l'ordine in cui si verificano le animazioni.

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