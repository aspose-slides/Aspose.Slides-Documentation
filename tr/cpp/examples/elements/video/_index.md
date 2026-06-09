---
title: Video
type: docs
weight: 80
url: /tr/cpp/examples/elements/video/
keywords:
- kod örneği
- video
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile videolar ekleyin ve kontrol edin: ekleme, oynatma, kırpma, poster çerçeveleri ayarlama ve PPT, PPTX ve ODP sunumları için C++ örnekleriyle dışa aktarma."
---
Bu makale, **Aspose.Slides for C++** kullanarak video çerçevelerini gömmeyi ve oynatma seçeneklerini ayarlamayı gösterir.

## **Video Çerçevesi Ekle**
Bir slayta boş bir video çerçevesi ekleyin.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Bir video ekleyin.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Video Çerçevesine Eriş**
Bir slayta eklenen ilk video çerçevesini alın.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Slayttaki ilk video çerçevesine erişin.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Video Çerçevesi Kaldır**
Slayttan bir video çerçevesini silin.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Video çerçevesini kaldır.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Video Oynatmayı Ayarla**
Slayt gösterildiğinde videonun otomatik olarak oynatılmasını yapılandırın.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Videonun otomatik olarak oynatılmasını yapılandır.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```