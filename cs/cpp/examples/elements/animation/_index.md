---
title: Animace
type: docs
weight: 100
url: /cs/cpp/examples/elements/animation/
keywords:
- příklad kódu
- animace
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Prozkoumejte ukázky animací Aspose.Slides pro C++: přidávejte, řaďte a přizpůsobujte efekty a přechody v C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vytvořit jednoduché animace a spravovat jejich sekvenci pomocí **Aspose.Slides for C++**.

## **Přidat animaci**

Vytvořte obdélníkový tvar a použijte efekt postupného objevení (fade‑in), který se spustí po kliknutí.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Efekt postupného zobrazení.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Přístup k animaci**

Získejte první animační efekt ze časové osy snímku.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Přístup k prvnímu animačnímu efektu.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Odstranit animaci**

Odstraňte animační efekt ze sekvence.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Odstraňte efekt.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Sekvence animací**

Přidejte více efektů a ukažte pořadí, ve kterém se animace odehrávají.

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