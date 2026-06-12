---
title: Animazione
type: docs
weight: 100
url: /it/nodejs-java/examples/elements/animation/
keywords:
- esempio di codice
- animazione
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Esplora esempi di animazione di Aspose.Slides per Node.js: aggiungi, sequenza e personalizza effetti e transizioni con JavaScript per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come creare animazioni semplici e gestire la loro sequenza utilizzando **Aspose.Slides for Node.js via Java**.

## **Aggiungere un'animazione**
Crea una forma rettangolare e applica un effetto di dissolvenza attivato al clic.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Effetto di dissolvenza.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Accedere a un'animazione**
Recupera il primo effetto di animazione dalla timeline della diapositiva.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Accedi al primo effetto di animazione.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere un'animazione**
Rimuovi un effetto di animazione dalla sequenza.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Rimuovi il primo effetto.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Sequenza di animazioni**
Aggiungi più effetti e dimostra l'ordine in cui le animazioni si verificano.

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