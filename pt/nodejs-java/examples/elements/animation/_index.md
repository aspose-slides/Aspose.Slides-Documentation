---
title: Animação
type: docs
weight: 100
url: /pt/nodejs-java/examples/elements/animation/
keywords:
- exemplo de código
- animação
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Explore exemplos de animação do Aspose.Slides para Node.js: adicione, sequencie e personalize efeitos e transições com JavaScript para apresentações PPT, PPTX e ODP."
---
Este artigo demonstra como criar animações simples e gerenciar sua sequência usando **Aspose.Slides for Node.js via Java**.

## **Adicionar uma Animação**

Crie um retângulo e aplique um efeito de desvanecimento acionado ao clicar.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Efeito de desvanecimento.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Acessar uma Animação**

Recupere o primeiro efeito de animação da linha do tempo do slide.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Acesse o primeiro efeito de animação.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remover uma Animação**

Remova um efeito de animação da sequência.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Remova o primeiro efeito.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sequenciar Animações**

Adicione múltiplos efeitos e demonstre a ordem em que as animações ocorrem.

```js
function sequenceAnimations() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);
        let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 200, 50, 100, 100);

        let sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(
            shape1, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
        sequence.addEffect(
            shape2, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation_sequence.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```