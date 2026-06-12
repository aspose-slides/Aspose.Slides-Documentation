---
title: Animasi
type: docs
weight: 100
url: /id/java/examples/elements/animation/
keywords:
- contoh kode
- animasi
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Jelajahi contoh animasi Aspose.Slides for Java: tambahkan, susun urutan, dan sesuaikan efek serta transisi dengan Java untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara membuat animasi sederhana dan mengelola urutannya menggunakan **Aspose.Slides for Java**.

## **Add an Animation**

Buat bentuk persegi panjang dan terapkan efek fade yang dipicu saat diklik.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // Efek fade.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **Access an Animation**

Ambil efek animasi pertama dari timeline slide.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Akses efek animasi pertama.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **Remove an Animation**

Hapus efek animasi dari urutan.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // Hapus efek.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **Sequence Animations**

Tambahkan beberapa efek dan tunjukkan urutan terjadinya animasi.

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