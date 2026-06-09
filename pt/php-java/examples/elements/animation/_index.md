---
title: Animação
type: docs
weight: 100
url: /pt/php-java/examples/elements/animation/
keywords:
- animação
- adicionar animação
- acessar animação
- remover animação
- sequência de animação
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Domine as animações de slides em PHP com Aspose.Slides: adicione, edite e remova efeitos, temporizações e gatilhos para criar apresentações dinâmicas em PPT, PPTX e ODP."
---
Mostra como criar animações simples e gerenciar sua sequência usando **Aspose.Slides for PHP via Java**.

## **Adicionar uma Animação**

Crie uma forma retangular e aplique um efeito de fade-in acionado ao clicar.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Efeito de fade in.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar uma Animação**

Recupere o primeiro efeito de animação da linha do tempo do slide.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse o primeiro efeito de animação.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover uma Animação**

Remova um efeito de animação da sequência.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Remova o efeito.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sequenciar Animações**

Adicione vários efeitos e demonstre a ordem em que as animações ocorrem.

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