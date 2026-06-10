---
title: Animáció
type: docs
weight: 100
url: /hu/cpp/examples/elements/animation/
keywords:
- kódpélda
- animáció
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ animációs példákat: adjon hozzá, sorozza és testreszabja a hatásokat és átmeneteket C++‑ban PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet egyszerű animációkat létrehozni és kezelni azok sorozatát a **Aspose.Slides for C++** használatával.

## **Animáció hozzáadása**

Hozzon létre egy téglalap alakzatot, és alkalmazzon egy kattintásra indított halványuló hatást.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Halványulási effektus.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Animáció elérése**

Hozza ki az első animációs hatást a diá idővonalából.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Az első animációs hatás elérése.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Animáció eltávolítása**

Távolítson el egy animációs hatást a sorozatból.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Az effektus eltávolítása.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Animációk sorozása**

Adjon hozzá több hatást, és mutassa be, milyen sorrendben zajlanak az animációk.

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