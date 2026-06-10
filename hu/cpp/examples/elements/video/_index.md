---
title: Videó
type: docs
weight: 80
url: /hu/cpp/examples/elements/video/
keywords:
- kód példa
- videó
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Videók hozzáadása és vezérlése az Aspose.Slides for C++ használatával: beszúrás, lejátszás, vágás, poszterkeretek beállítása és exportálás C++ példákkal PPT, PPTX és ODP prezentációkhoz."
---
Ez a cikk bemutatja, hogyan lehet videókereteket beágyazni és lejátszási beállításokat megadni az **Aspose.Slides for C++** használatával.

## **Videókeret hozzáadása**

Helyezz egy üres videókeretet egy diára.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Videót ad hozzá.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Videókeret elérése**

Szerezd meg az első, a diára hozzáadott videókeretet.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Az első videókeret elérése a dián.
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

## **Videókeret eltávolítása**

Töröld a videókeretet a diáról.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Videókeret eltávolítása.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Videólejátszás beállítása**

Állítsd be a videót, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // A videó automatikus lejátszásának beállítása.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```