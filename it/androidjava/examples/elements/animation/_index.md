---
title: Animazione
type: docs
weight: 100
url: /it/androidjava/examples/elements/animation/
keywords:
- esempio di codice
- animazione
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora gli esempi di animazione di Aspose.Slides per Android: aggiungi, sequenza e personalizza effetti e transizioni con Java per presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come creare animazioni semplici e gestire la loro sequenza utilizzando **Aspose.Slides for Android via Java**.

## **Aggiungere un'animazione**

Crea una forma rettangolare e applica un effetto di dissolvenza attivato al clic.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Effetto di dissolvenza.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Accedere a un'animazione**

Recupera il primo effetto di animazione dalla timeline della diapositiva.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Accedi al primo effetto di animazione.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Rimuovere un'animazione**

Rimuovi un effetto di animazione dalla sequenza.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Rimuovi l'effetto.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Sequenza di animazioni**

Aggiungi più effetti e dimostra l'ordine in cui avvengono le animazioni.

```java
static void sequenceAnimations() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

        ISequence sequence = slide.getTimeline().getMainSequence();
        sequence.addEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
        sequence.addEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    } finally {
        presentation.dispose();
    }
}
```