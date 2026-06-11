---
title: Animacja
type: docs
weight: 100
url: /pl/cpp/examples/elements/animation/
keywords:
- przykład kodu
- animacja
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj przykłady animacji w Aspose.Slides dla C++: dodawaj, kolejkuj i dostosowuj efekty oraz przejścia w C++ dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak tworzyć proste animacje i zarządzać ich kolejnością przy użyciu **Aspose.Slides for C++**.

## **Dodaj animację**

Utwórz prostokątny kształt i zastosuj efekt fade‑in wyzwalany po kliknięciu.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Efekt zanikania.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do animacji**

Pobierz pierwszy efekt animacji z osi czasu slajdu.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Dostęp do pierwszego efektu animacji.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Usuń animację**

Usuń efekt animacji z kolejności.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Usuń efekt.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Sekwencja animacji**

Dodaj wiele efektów i pokaż kolejność, w jakiej animacje się odbywają.

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