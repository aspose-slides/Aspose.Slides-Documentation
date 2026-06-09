---
title: Κίνηση
type: docs
weight: 100
url: /el/java/examples/elements/animation/
keywords:
- παράδειγμα κώδικα
- κίνηση
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κινήσεων Aspose.Slides for Java: προσθέστε, δημιουργήστε σειρά και προσαρμόστε εφέ και μεταβάσεις με Java για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να δημιουργήσετε απλές κινήσεις και να διαχειριστείτε τη σειρά τους χρησιμοποιώντας **Aspose.Slides for Java**.

## **Προσθήκη κίνησης**

Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ εξασθένισης που ενεργοποιείται με κλικ.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Εφέ εξασθένισης.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση σε κίνηση**

Ανακτήστε το πρώτο εφέ κίνησης από τη χρονογραμμή της διαφάνειας.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Πρόσβαση στο πρώτο εφέ κίνησης.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση κίνησης**

Αφαιρέστε ένα εφέ κίνησης από τη σειρά.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Αφαίρεση του εφέ.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Σειρά κινήσεων**

Προσθέστε πολλαπλά εφέ και επιδείξτε τη σειρά με την οποία εκτελούνται οι κινήσεις.

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