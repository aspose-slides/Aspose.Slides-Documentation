---
title: انیمیشن
type: docs
weight: 100
url: /fa/java/examples/elements/animation/
keywords:
- مثال کد
- انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مثال‌های انیمیشن Aspose.Slides for Java را بررسی کنید: افزودن، توالی‌بندی و سفارشی‌سازی اثرها و انتقال‌ها با Java برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه انیمیشن‌های ساده ایجاد کرده و توالی آن‌ها را با استفاده از **Aspose.Slides for Java** مدیریت کنید.

## **افزودن انیمیشن**

یک شکل مستطیل ایجاد کنید و یک اثر محو شدن که با کلیک فعال می‌شود، اعمال کنید.

```java
static void addAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

        // اثر محو شدن.
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick
        );
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به انیمیشن**

اولین اثر انیمیشن را از جدول زمان‌بندی اسلاید دریافت کنید.

```java
static void accessAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // دسترسی به اولین اثر انیمیشن.
        IEffect effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف انیمیشن**

یک اثر انیمیشن را از توالی حذف کنید.

```java
static void removeAnimation() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
        IEffect effect = slide.getTimeline().getMainSequence().addEffect(
                shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

        // حذف اثر.
        slide.getTimeline().getMainSequence().remove(effect);
    } finally {
        presentation.dispose();
    }
}
```

## **توالی‌بندی انیمیشن‌ها**

چندین اثر را اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

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