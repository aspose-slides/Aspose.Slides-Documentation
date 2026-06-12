---
title: Animace
type: docs
weight: 100
url: /cs/androidjava/examples/elements/animation/
keywords:
- ukázka kódu
- animace
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Prozkoumejte příklady animací Aspose.Slides pro Android: přidávejte, řaďte a přizpůsobujte efekty a přechody v jazyce Java pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for Android via Java**.

## **Přidat animaci**

Vytvořte obdélníkový tvar a aplikujte efekt postupného miznutí, který se spustí po kliknutí.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Efekt rozplynutí.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Přístup k prvnímu animačnímu efektu.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Odebrat animaci**

Odeberte animační efekt ze sekvence.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Odebrat efekt.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Sekvence animací**

Přidejte více efektů a ukažte pořadí, ve kterém se animace provádějí.

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