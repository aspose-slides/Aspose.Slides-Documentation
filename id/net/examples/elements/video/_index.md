---
title: Video
type: docs
weight: 80
url: /id/net/examples/elements/video/
keywords:
- video
- bingkai video
- menambahkan video
- mengakses video
- menghapus video
- pemutaran video
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Menambahkan dan mengontrol video dengan Aspose.Slides untuk .NET: menyisipkan, memutar, memotong, mengatur bingkai poster, serta mengekspor dengan contoh C# untuk presentasi PPT, PPTX, dan ODP."
---
Artikel ini menunjukkan cara menyematkan bingkai video dan mengatur opsi pemutaran menggunakan **Aspose.Slides for .NET**.

## **Tambahkan Bingkai Video**

Sisipkan bingkai video kosong ke dalam slide.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Tambahkan video.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Akses Bingkai Video**

Ambil bingkai video pertama yang ditambahkan ke slide.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Akses bingkai video pertama pada slide.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Hapus Bingkai Video**

Hapus bingkai video dari slide.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Hapus bingkai video.
    slide.Shapes.Remove(videoFrame);
}
```

## **Atur Pemutaran Video**

Konfigurasikan video agar diputar secara otomatis saat slide ditampilkan.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Atur video agar diputar secara otomatis.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```