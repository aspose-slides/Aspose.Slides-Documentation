---
title: انیمیشن
type: docs
weight: 100
url: /fa/php-java/examples/elements/animation/
keywords:
- انیمیشن
- افزودن انیمیشن
- دسترسی به انیمیشن
- حذف انیمیشن
- توالی انیمیشن
- مثال‌های کد
- پاورپوینت
- OpenDocument
- ارائه
- PHP
- Aspose.Slides
description: "انیمیشن‌های اسلاید را در PHP با Aspose.Slides به‌طور کامل مسلط شوید: افزودن، ویرایش و حذف اثرها، زمان‌بندی‌ها و محرک‌ها برای ایجاد ارائه‌های پویا در PPT، PPTX و ODP."
---
نشان می‌دهد چگونه انیمیشن‌های ساده ایجاد کرده و توالی آن‌ها را با استفاده از **Aspose.Slides for PHP via Java** مدیریت کنیم.

## **Add an Animation**
یک شکل مستطیل ایجاد کنید و اثر محو شدن در هنگام کلیک را اعمال نمایید.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // اثر محو شدن.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access an Animation**
اولین اثر انیمیشن را از خط زمان اسلاید بازیابی کنید.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // دسترسی به اولین اثر انیمیشن.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove an Animation**
یک اثر انیمیشن را از توالی حذف کنید.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // حذف اثر.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Sequence Animations**
چندین اثر اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

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