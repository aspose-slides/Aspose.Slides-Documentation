---
title: Animation
type: docs
weight: 100
url: /sv/cpp/examples/elements/animation/
keywords:
- kodexempel
- animation
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Utforska Aspose.Slides för C++ animationsexempel: lägg till, sekvensa och anpassa effekter och övergångar med C++ för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du skapar enkla animationer och hanterar deras sekvens med **Aspose.Slides for C++**.

## **Lägg till en animation**
Skapa en rektangelform och applicera en fade-in-effekt som aktiveras vid klick.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Fade-effekt.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Kom åt en animation**
Hämta den första animationseffekten från bildens tidslinje.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Åtkomst till den första animationseffekten.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Ta bort en animation**
Ta bort en animationseffekt från sekvensen.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Ta bort effekten.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Animera i sekvens**
Lägg till flera effekter och demonstrera i vilken ordning animationerna sker.

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