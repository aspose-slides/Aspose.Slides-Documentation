---  
title: الرسوم المتحركة  
type: docs  
weight: 100  
url: /ar/cpp/examples/elements/animation/  
keywords:  
- مثال على الكود  
- رسوم متحركة  
- PowerPoint  
- OpenDocument  
- عرض تقديمي  
- C++  
- Aspose.Slides  
description: "استكشف أمثلة الرسوم المتحركة في Aspose.Slides for C++: إضافة، تسلسل، وتخصيص التأثيرات والانتقالات باستخدام C++ لعروض PPT و PPTX و ODP."  
---
توضح هذه المقالة كيفية إنشاء رسوم متحركة بسيطة وإدارة تسلسلها باستخدام **Aspose.Slides for C++**.

## **إضافة رسوم متحركة**

قم بإنشاء شكل مستطيل وتطبيق تأثير ظهور تدريجي يتم تشغيله عند النقر.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // تأثير التلاشي.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **الوصول إلى رسوم متحركة**

استرجع أول تأثير رسوم متحركة من جدول زمني الشريحة.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // الوصول إلى أول تأثير رسوم متحركة.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **إزالة رسوم متحركة**

قم بإزالة تأثير الرسوم المتحركة من التسلسل.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // إزالة التأثير.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **تسلسل الرسوم المتحركة**

أضف تأثيرات متعددة وأظهر الترتيب الذي تحدث به الرسوم المتحركة.

```cpp
static void SequenceAnimations()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

    auto sequence = slide->get_Timeline()->get_MainSequence();
    sequence->AddEffect(shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    sequence->AddEffect(shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```