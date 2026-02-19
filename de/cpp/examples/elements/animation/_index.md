---
title: Animation
type: docs
weight: 100
url: /de/cpp/examples/elements/animation/
keywords:
- Codebeispiel
- Animation
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Beispiele für Animationen mit Aspose.Slides für C++: Hinzufügen, Sequenzieren und Anpassen von Effekten und Übergängen mit C++ für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man einfache Animationen erstellt und ihre Reihenfolge verwaltet, wobei **Aspose.Slides for C++** verwendet wird.

## **Animation hinzufügen**

Erstellen Sie eine Rechteckform und wenden Sie einen Fade-in-Effekt an, der bei einem Klick ausgelöst wird.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Fade-Effekt.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Auf eine Animation zugreifen**

Rufen Sie den ersten Animationseffekt aus der Folien‑Zeitleiste ab.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Zugriff auf den ersten Animationseffekt.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Animation entfernen**

Entfernen Sie einen Animationseffekt aus der Sequenz.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Effekt entfernen.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Animationen sequenzieren**

Fügen Sie mehrere Effekte hinzu und demonstrieren Sie die Reihenfolge, in der die Animationen ablaufen.

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