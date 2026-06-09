---
title: Κίνηση
type: docs
weight: 100
url: /el/php-java/examples/elements/animation/
keywords:
- κίνηση
- προσθήκη κίνησης
- πρόσβαση κίνησης
- αφαίρεση κίνησης
- αλληλουχία κίνησης
- παραδείγματα κώδικα
- PowerPoint
- OpenDocument
- παρουσίαση
- PHP
- Aspose.Slides
description: "Κατακτήστε τις κινήσεις διαφανειών σε PHP με το Aspose.Slides: προσθέστε, επεξεργαστείτε και αφαιρέστε εφέ, χρόνους και ενεργοποιητές για να δημιουργήσετε δυναμικές παρουσιάσεις σε PPT, PPTX και ODP."
---
Δείχνει πώς να δημιουργήσετε απλές κινήσεις και να διαχειριστείτε τη σειρά τους χρησιμοποιώντας **Aspose.Slides for PHP via Java**.

## **Προσθήκη Κίνησης**

Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ εξασθένισης που ενεργοποιείται με κλικ.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // Εφέ εξασθένισης.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Πρόσβαση σε Κίνηση**

Ανακτήστε το πρώτο εφέ κίνησης από τη χρονογραμμή της διαφάνειας.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Πρόσβαση στο πρώτο εφέ κίνησης.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Αφαίρεση Κίνησης**

Αφαιρέστε ένα εφέ κίνησης από τη σειρά.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // Αφαίρεση του εφέ.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ακολουθία Κινήσεων**

Προσθέστε πολλαπλά εφέ και δείξτε τη σειρά κατά την οποία πραγματοποιούνται οι κινήσεις.

```php
function sequenceAnimations() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
        $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

        $sequence = $slide->getTimeline()->getMainSequence();
        $sequence->addEffect($shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
        $sequence->addEffect($shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

        $presentation->save("animation_sequence.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```