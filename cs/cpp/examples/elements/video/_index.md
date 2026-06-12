---
title: Video
type: docs
weight: 80
url: /cs/cpp/examples/elements/video/
keywords:
- ukázkový kód
- video
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Přidávejte a ovládejte videa pomocí Aspose.Slides for C++: vkládejte, přehrávejte, ořezávejte, nastavujte posterové snímky a exportujte s příklady v C++ pro prezentace PPT, PPTX a ODP."
---
Tento článek ukazuje, jak vložit video snímky a nastavit možnosti přehrávání pomocí **Aspose.Slides for C++**.

## **Přidat video snímek**

Vložte prázdný video snímek na snímek.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidejte video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Přístup k video snímku**

Získejte první video snímek přidaný na snímek.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Přístup k prvnímu video snímku na snímku.
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

## **Odstranit video snímek**

Smažte video snímek ze snímku.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Odstraňte video snímek.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Nastavit přehrávání videa**

Nakonfigurujte video tak, aby se spustilo automaticky při zobrazení snímku.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Nastavte video tak, aby se přehrávalo automaticky.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```