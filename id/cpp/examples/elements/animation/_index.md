---
title: Animasi
type: docs
weight: 100
url: /id/cpp/examples/elements/animation/
keywords:
- contoh kode
- animasi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Jelajahi contoh animasi Aspose.Slides for C++: tambahkan, urutkan, dan sesuaikan efek serta transisi dengan C++ untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara membuat animasi sederhana dan mengelola urutannya menggunakan **Aspose.Slides for C++**.

## **Tambah Animasi**

Buat bentuk persegi panjang dan terapkan efek fade-in yang dipicu pada klik.

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // Efek fade.
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **Akses Animasi**

Ambil efek animasi pertama dari timeline slide.

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Akses efek animasi pertama.
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **Hapus Animasi**

Hapus efek animasi dari urutan.

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // Hapus efek.
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **Urutan Animasi**

Tambahkan beberapa efek dan tunjukkan urutan terjadinya animasi.

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