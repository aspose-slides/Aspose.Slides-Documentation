---
title: Ses
type: docs
weight: 70
url: /tr/net/examples/elements/audio/
keywords:
- ses
- ses çerçevesi
- ses ekle
- sese eriş
- sesi kaldır
- ses oynatma
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ses örneklerini keşfedin: PPT, PPTX ve ODP sunumlarında sesi ekleyin, çalın, kırpın ve çıkarın, net C# kodu ile."
---
Bu makale, **Aspose.Slides for .NET** kullanarak ses çerçevelerini gömmeyi ve oynatmayı kontrol etmeyi gösterir. Aşağıdaki örnekler temel ses işlemlerini göstermektedir.

## **Ses Çerçevesi Ekle**

Daha sonra gömülü ses verisi tutabilecek boş bir ses çerçevesi ekleyin.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Boş bir ses çerçevesi oluştur (ses daha sonra gömülecek).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Ses Çerçevesine Eriş**

Bu kod, bir slayttaki ilk ses çerçevesini alır.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Slayttaki ilk ses çerçevesine eriş.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini silin.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Ses çerçevesini kaldır.
    slide.Shapes.Remove(audioFrame);
}
```

## **Ses Oynatmayı Ayarla**

Ses çerçevesinin slayt göründüğünde otomatik olarak çalmasını yapılandırın.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Slayt göründüğünde otomatik olarak oynat.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```