---
title: Κίνηση
type: docs
weight: 100
url: /el/cpp/examples/elements/animation/
keywords:
- παράδειγμα κώδικα
- κίνηση
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Εξερευνήστε παραδείγματα κίνησης του Aspose.Slides for C++: προσθέστε, δημιουργήστε ακολουθίες και προσαρμόστε εφέ και μεταβάσεις με C++ για παρουσιάσεις PPT, PPTX και ODP."
---
Αυτό το άρθρο δείχνει πώς να δημιουργήσετε απλές κινήσεις και να διαχειριστείτε τη σειρά τους χρησιμοποιώντας **Aspose.Slides for C++**.

## **Προσθήκη Κίνησης**
Δημιουργήστε ένα σχήμα ορθογωνίου και εφαρμόστε ένα εφέ fade‑in που ενεργοποιείται με κλικ.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Εφέ εξασθένισης.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Πρόσβαση σε Κίνηση**
Ανακτήστε το πρώτο εφέ κίνησης από τη χρονογραμμή της διαφάνειας.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Πρόσβαση στο πρώτο εφέ κίνησης.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Αφαίρεση Κίνησης**
Αφαιρέστε ένα εφέ κίνησης από τη σειρά.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Αφαίρεση του εφέ.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Ακολουθία Κινήσεων**
Προσθέστε πολλαπλά εφέ και δείξτε τη σειρά με την οποία εκτελούνται οι κινήσεις.

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