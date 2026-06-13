---
title: انیمیشن
type: docs
weight: 100
url: /fa/nodejs-java/examples/elements/animation/
keywords:
- مثال کد
- انیمیشن
- پاورپوینت
- سند باز
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مثال‌های انیمیشن Aspose.Slides برای Node.js را بررسی کنید: افزودن، توالی‌بندی و سفارشی‌سازی اثرها و انتقال‌ها با JavaScript برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه انیمیشن‌های ساده ایجاد کرده و توالی آن‌ها را با استفاده از **Aspose.Slides for Node.js via Java** مدیریت کنید.

## **افزودن انیمیشن**
یک شکل مستطیل ایجاد کنید و اثر محو را که با کلیک فعال می‌شود، اعمال کنید.

```js
function addAnimation() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100);

        // اثر محو.
        slide.getTimeline().getMainSequence().addEffect(
            shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

        presentation.save("animation.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به انیمیشن**
اولین اثر انیمیشن را از خط زمان اسلاید بازیابی کنید.

```js
function accessAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به اولین اثر انیمیشن.
        let effect = slide.getTimeline().getMainSequence().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف انیمیشن**
یک اثر انیمیشن را از توالی حذف کنید.

```js
function removeAnimation() {
    let presentation = new aspose.slides.Presentation("animation.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getTimeline().getMainSequence().length > 0) {
            // حذف اولین اثر.
            slide.getTimeline().getMainSequence().removeAt(0);
        }

        presentation.save("animation_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **توالی‌سازی انیمیشن‌ها**
چندین اثر اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

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