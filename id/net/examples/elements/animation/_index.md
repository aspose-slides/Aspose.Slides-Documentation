---
title: Animasi
type: docs
weight: 100
url: /id/net/examples/elements/animation/
keywords:
- animasi
- menambahkan animasi
- mengakses animasi
- menghapus animasi
- urutan animasi
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Jelajahi contoh animasi Aspose.Slides untuk .NET: menambah, mengurutkan, dan menyesuaikan efek serta transisi dengan C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara membuat animasi sederhana dan mengelola urutannya menggunakan **Aspose.Slides for .NET**.

## **Tambah Animasi**

Buat bentuk persegi panjang dan terapkan efek memudar yang dipicu saat diklik.

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // Efek memudar.
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **Akses Animasi**

Ambil efek animasi pertama dari linimasa slide.

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Akses efek animasi pertama.
    var effect = slide.Timeline.MainSequence[0];
}
```

## **Hapus Animasi**

Hapus efek animasi dari urutan.

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hapus efek.
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **Urutkan Animasi**

Tambahkan beberapa efek dan tunjukkan urutan terjadinya animasi.

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```