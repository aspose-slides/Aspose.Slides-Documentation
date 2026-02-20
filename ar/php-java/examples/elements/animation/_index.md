---
title: الرسوم المتحركة
type: docs
weight: 100
url: /ar/php-java/examples/elements/animation/
keywords:
- تحريك
- إضافة تحريك
- الوصول إلى تحريك
- إزالة تحريك
- تسلسل التحريك
- أمثلة الشيفرة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في رسومات الشرائح المتحركة في PHP باستخدام Aspose.Slides: أضف، حرر، وأزل التأثيرات، التوقيتات، والمحفزات لإنشاء عروض تقديمية ديناميكية بصيغ PPT و PPTX و ODP."
---
يوضح كيفية إنشاء رسومات متحركة بسيطة وإدارة تسلسلها باستخدام **Aspose.Slides for PHP via Java**.

## **إضافة حركة**
إنشاء شكل مستطيل وتطبيق تأثير الظهر التدريجي عند النقر.

```php
function addAnimation() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

        // تأثير الظهور التدريجي.
        $slide->getTimeline()->getMainSequence()->addEffect($shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

        $presentation->save("animation.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **الوصول إلى حركة**
استرجاع أول تأثير حركي من خط زمني الشريحة.

```php
function accessAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // الوصول إلى أول تأثير تحريك.
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **إزالة حركة**
إزالة تأثير حركي من التسلسل.

```php
function removeAnimation() {
    $presentation = new Presentation("animation.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $effect = $slide->getTimeline()->getMainSequence()->get_Item(0);

        // إزالة التأثير.
        $slide->getTimeline()->getMainSequence()->remove($effect);

        $presentation->save("animation_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **تسلسل الحركات**
إضافة عدة تأثيرات وتوضيح الترتيب الذي تحدث فيه الحركات.

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