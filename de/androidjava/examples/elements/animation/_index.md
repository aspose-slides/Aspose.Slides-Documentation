---
title: Animation
type: docs
weight: 100
url: /de/androidjava/examples/elements/animation/
keywords:
- Codebeispiel
- Animation
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Entdecken Sie Animationsbeispiele von Aspose.Slides für Android: Hinzufügen, Sequenzieren und Anpassen von Effekten und Übergängen mit Java für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man einfache Animationen erstellt und ihre Sequenz verwaltet, wobei **Aspose.Slides for Android via Java** verwendet wird.

## **Animation hinzufügen**

Erstellen Sie eine Rechteckform und wenden Sie einen Einblendungseffekt an, der bei Klick ausgelöst wird.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Einblendeffekt.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf eine Animation**

Rufen Sie den ersten Animationseffekt aus der Folienzeitachse ab.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Greift auf den ersten Animationseffekt zu.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Eine Animation entfernen**

Entfernen Sie einen Animationseffekt aus der Sequenz.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Entfernt den Effekt.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Animationen sequenzieren**

Fügen Sie mehrere Effekte hinzu und demonstrieren Sie die Reihenfolge, in der die Animationen auftreten.

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