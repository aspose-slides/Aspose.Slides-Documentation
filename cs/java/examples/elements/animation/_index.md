---
title: Animace
type: docs
weight: 100
url: /cs/java/examples/elements/animation/
keywords:
- příklad kódu
- animace
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Prozkoumejte příklady animací v Aspose.Slides pro Java: přidávejte, řaďte sekvence a přizpůsobujte efekty a přechody pomocí Javy pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vytvářet jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for Java**.

## **Přidat animaci**

Vytvořte obdélníkový tvar a použijte efekt rozplynutí spuštěný kliknutím.

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

Získáte první animační efekt ze časové osy snímku.

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

## **Odstranit animaci**

Odstraňte animační efekt ze sekvence.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Odstranit efekt.
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