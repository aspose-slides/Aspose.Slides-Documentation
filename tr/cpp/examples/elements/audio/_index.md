---
title: Ses
type: docs
weight: 70
url: /tr/cpp/examples/elements/audio/
keywords:
- kod örneği
- ses
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ses örneklerini keşfedin: PPT, PPTX ve ODP sunumlarında sesi ekleme, çalma, kırpma ve çıkarma işlemlerini net C++ kodu ile gerçekleştirin."
---
Bu makale, **Aspose.Slides for C++** kullanarak ses çerçevelerini nasıl gömeceğinizi ve oynatmayı nasıl kontrol edeceğinizi gösterir. Aşağıdaki örnekler temel ses işlemlerini gösterir.

## **Ses Çerçevesi Ekle**

Daha sonra gömülü ses verilerini tutabilecek boş bir ses çerçevesi ekleyin.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Boş bir ses çerçevesi oluştur (ses daha sonra gömülecek).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Ses Çerçevesine Erişim**

Bu kod, bir slayttaki ilk ses çerçevesini getirir.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Slayttaki ilk ses çerçevesine eriş.
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini silin.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Ses çerçevesini kaldır.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Ses Oynatmayı Ayarla**

Ses çerçevesini, slayt göründüğünde otomatik olarak çalacak şekilde yapılandırın.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Slayt göründüğünde otomatik olarak oynat.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```