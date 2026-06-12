---
title: Transisi Slide
type: docs
weight: 110
url: /id/net/examples/elements/slide-transition/
keywords:
- transisi slide
- menambahkan transisi slide
- mengakses transisi slide
- menghapus transisi slide
- durasi transisi
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kuasi transisi slide di Aspose.Slides untuk .NET: tambahkan, sesuaikan, dan urutkan efek serta durasi dengan contoh C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menerapkan efek transisi slide dan pengaturannya dengan **Aspose.Slides for .NET**.

## **Menambahkan Transisi Slide**
Terapkan efek transisi memudar pada slide pertama.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Terapkan transisi memudar.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Mengakses Transisi Slide**
Baca jenis transisi yang saat ini ditetapkan pada slide.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Akses jenis transisi.
    var type = slide.SlideShowTransition.Type;
}
```

## **Menghapus Transisi Slide**
Hapus semua efek transisi dengan mengatur jenis menjadi `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Hapus transisi dengan mengatur menjadi none.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Mengatur Durasi Transisi**
Tentukan berapa lama slide ditampilkan sebelum beralih secara otomatis.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // dalam milidetik
}
```