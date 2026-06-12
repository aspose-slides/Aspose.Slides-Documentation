---
title: Audio
type: docs
weight: 70
url: /id/net/examples/elements/audio/
keywords:
- audio
- frame audio
- menambahkan audio
- mengakses audio
- menghapus audio
- pemutaran audio
- contoh kode
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Temukan contoh audio Aspose.Slides untuk .NET: sisipkan, putar, potong, dan ekstrak suara dalam presentasi PPT, PPTX, dan ODP dengan kode C# yang jelas."
---
Artikel ini menunjukkan cara menyematkan frame audio dan mengendalikan pemutaran dengan **Aspose.Slides for .NET**. Contoh-contoh berikut menampilkan operasi audio dasar.

## **Menambahkan Frame Audio**

Menyisipkan frame audio kosong yang nantinya dapat menampung data suara yang disematkan.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Membuat frame audio kosong (audio akan disematkan nanti).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Mengakses Frame Audio**

Kode ini mengambil frame audio pertama pada slide.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Mengakses frame audio pertama pada slide.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Menghapus Frame Audio**

Menghapus frame audio yang telah ditambahkan sebelumnya.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Hapus frame audio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Mengatur Pemutaran Audio**

Mengkonfigurasi frame audio untuk diputar secara otomatis saat slide muncul.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Putar secara otomatis saat slide muncul.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```