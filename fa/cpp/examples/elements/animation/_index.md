---
title: انیمیشن
type: docs
weight: 100
url: /fa/cpp/examples/elements/animation/
keywords:
- مثال کد
- انیمیشن
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "نمونه‌های انیمیشن Aspose.Slides for C++ را بررسی کنید: افزودن، توالی‌بندی و سفارشی‌سازی افکت‌ها و انتقال‌ها با C++ برای ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد چگونه انیمیشن‌های ساده ایجاد و توالی آن‌ها را با استفاده از **Aspose.Slides for C++** مدیریت کنید.

## **افزودن یک انیمیشن**

یک شکل مستطیلی ایجاد کنید و اثر محو‌شدن (fade‑in) را که با کلیک فعال می‌شود، اعمال کنید.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // افکت محو.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **دسترسی به یک انیمیشن**

اولین اثر انیمیشن را از خط زمان اسلاید بازیابی کنید.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // دسترسی به اولین اثر انیمیشن.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **حذف یک انیمیشن**

یک اثر انیمیشن را از توالی حذف کنید.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // حذف اثر.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **توالی‌سازی انیمیشن‌ها**

چندین اثر اضافه کنید و ترتیب وقوع انیمیشن‌ها را نشان دهید.

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