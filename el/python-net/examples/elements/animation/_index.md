---
title: Κινούμενα σχέδια
type: docs
weight: 100
url: /el/python-net/examples/elements/animation/
keywords:
- κίνηση
- προσθήκη κίνησης
- πρόσβαση κίνησης
- αφαίρεση κίνησης
- ακολουθία κίνησης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Aspose.Slides
description: "Διαχειριστείτε τις κινούμενες εικόνες διαφανειών σε Python με το Aspose.Slides: προσθέστε, επεξεργαστείτε και αφαιρέστε εφέ, χρονισμούς και ενεργοποιητές για να δημιουργήσετε δυναμικές παρουσιάσεις σε PPT, PPTX και ODP."
---
Δείχνει πώς να δημιουργήσετε απλές κινούμενες εικόνες και να διαχειριστείτε τη σειρά τους χρησιμοποιώντας **Aspose.Slides for Python via .NET**.

## **Προσθήκη Ανιμέ이션**

Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ εξασθένισης που ενεργοποιείται με κλικ.

```py
def add_animation():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)

        # Προσθήκη εφέ εξασθένισης.
        slide.timeline.main_sequence.add_effect(
            shape,
            slides.animation.EffectType.FADE,
            slides.animation.EffectSubtype.NONE,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation.pptx", slides.export.SaveFormat.PPTX)
```

## **Πρόσβαση σε Ανιμέ이션**

Ανακτήστε το πρώτο εφέ κίνησης από τη χρονογραμμή της διαφάνειας.

```py
def access_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Πρόσβαση στο πρώτο εφέ κίνησης.
        effect = slide.timeline.main_sequence[0]
```

## **Αφαίρεση Ανιμέ이션**

Αφαιρέστε ένα εφέ κίνησης από τη σειρά.

```py
def remove_animation():
    with slides.Presentation("animation.pptx") as presentation:
        slide = presentation.slides[0]

        # Υπόθεση ότι η κύρια ακολουθία περιέχει τουλάχιστον ένα εφέ.
        effect = slide.timeline.main_sequence[0]

        # Αφαίρεση του εφέ.
        slide.timeline.main_sequence.remove(effect)

        presentation.save("animation_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ακολουθία Ανιμέ이션**

Προσθέστε πολλαπλά εφέ και επιδείξτε τη σειρά με την οποία εκτελούνται οι κινήσεις.

```py
def sequence_animations():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 100)
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 200, 50, 100, 100)

        sequence = slide.timeline.main_sequence
        sequence.add_effect(
            shape1,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)
        sequence.add_effect(
            shape2,
            slides.animation.EffectType.FLY,
            slides.animation.EffectSubtype.BOTTOM,
            slides.animation.EffectTriggerType.ON_CLICK)

        presentation.save("animation_sequence.pptx", slides.export.SaveFormat.PPTX)
```