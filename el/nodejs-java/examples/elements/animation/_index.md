---
title: Κίνηση
type: docs
weight: 100
url: /el/nodejs-java/examples/elements/animation/
keywords:
- παράδειγμα κώδικα
- κίνηση
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κίνησης Aspose.Slides for Node.js: προσθήκη, ακολουθία και προσαρμογή εφέ και μεταβάσεων με JavaScript για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να δημιουργήσετε απλές κινήσεις και να διαχειριστείτε τη σειρά τους χρησιμοποιώντας **Aspose.Slides for Node.js via Java**.

## **Προσθήκη κίνησης**

Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ εξασθένισης που ενεργοποιείται με κλικ.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // Εφέ εξασθένισης.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Πρόσβαση στην κίνηση**

Ανακτήστε το πρώτο εφέ κίνησης από τη χρονογραμμή της διαφάνειας.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Πρόσβαση στο πρώτο εφέ κίνησης.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Αφαίρεση κίνησης**

Αφαιρέστε ένα εφέ κίνησης από τη σειρά.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // Αφαίρεση του πρώτου εφέ.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Σειρά κινήσεων**

Προσθέστε πολλαπλά εφέ και επιδείξτε τη σειρά με την οποία εκτελούνται οι κινήσεις.

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