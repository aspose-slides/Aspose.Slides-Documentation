---
title: Animation
type: docs
weight: 100
url: /sv/java/examples/elements/animation/
keywords:
- kodexempel
- animation
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Utforska Aspose.Slides for Java animationsexempel: lägg till, sekvensera och anpassa effekter och övergångar med Java för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du skapar enkla animationer och hanterar deras sekvens med **Aspose.Slides for Java**.

## **Lägg till en animation**

Skapa en rektangelform och applicera en toningseffekt som triggas vid klick.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Toningseffekt.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Få åtkomst till en animation**

Hämta den första animationseffekten från bildens tidslinje.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Åtkomst till den första animationseffekten.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en animation**

Ta bort en animationseffekt från sekvensen.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Ta bort effekten.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Animera i sekvens**

Lägg till flera effekter och demonstrera i vilken ordning animationerna sker.

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