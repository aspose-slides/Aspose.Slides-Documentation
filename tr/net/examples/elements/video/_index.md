---
title: Video
type: docs
weight: 80
url: /tr/net/examples/elements/video/
keywords:
- video
- video çerçevesi
- video ekle
- videoya eriş
- videoyu kaldır
- video oynatma
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile video ekleyin ve kontrol edin: ekleme, oynatma, kırpma, poster çerçeveleri ayarlama ve PPT, PPTX ve ODP sunumları için C# örnekleriyle dışa aktarma."
---
Bu makale, **Aspose.Slides for .NET** kullanarak video çerçevelerini nasıl yerleştireceğinizi ve oynatma seçeneklerini nasıl ayarlayacağınızı gösterir.

## **Video Çerçevesi Ekle**

Bir slayda boş bir video çerçevesi ekleyin.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Bir video ekle.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Video Çerçevesine Erişin**

Bir slayda eklenen ilk video çerçevesini alın.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Slayttaki ilk video çerçevesine eriş.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Video Çerçevesini Kaldır**

Slayttan bir video çerçevesini silin.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Video çerçevesini kaldır.
    slide.Shapes.Remove(videoFrame);
}
```

## **Video Oynatmayı Ayarla**

Slayt gösterildiğinde videonun otomatik olarak oynatılacak şekilde yapılandırın.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Videonun otomatik olarak oynatılması için yapılandır.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```