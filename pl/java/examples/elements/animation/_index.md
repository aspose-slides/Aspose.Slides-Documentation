---
title: Animacja
type: docs
weight: 100
url: /pl/java/examples/elements/animation/
keywords:
- przykład kodu
- animacja
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj przykłady animacji w Aspose.Slides for Java: dodawanie, sekwencjonowanie i dostosowywanie efektów oraz przejść w Javie dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak tworzyć proste animacje i zarządzać ich kolejnością przy użyciu **Aspose.Slides for Java**.

## **Dodaj animację**

Utwórz kształt prostokąta i zastosuj efekt zanikania wyzwalany po kliknięciu.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Efekt zanikania.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do animacji**

Pobierz pierwszy efekt animacji z osi czasu slajdu.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Uzyskaj dostęp do pierwszego efektu animacji.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń animację**

Usuń efekt animacji z sekwencji.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Usuń efekt.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Sekwencja animacji**

Dodaj wiele efektów i pokaż kolejność, w jakiej animacje się odbywają.

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