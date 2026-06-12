---
title: Video
type: docs
weight: 80
url: /nl/cpp/examples/elements/video/
keywords:
- codevoorbeeld
- video
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Video's toevoegen en beheren met Aspose.Slides for C++: invoegen, afspelen, bijsnijden, posterframes instellen en exporteren met C++-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u videoframes kunt insluiten en afspeelopties kunt instellen met **Aspose.Slides for C++**.

## **Videoframe toevoegen**

Voeg een lege videoframe toe aan een dia.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voeg een video toe.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Toegang tot een videoframe**

Haal de eerste videoframe op die aan een dia is toegevoegd.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Toegang tot het eerste videoframe op de dia.
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

## **Videoframe verwijderen**

Verwijder een videoframe van de dia.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Verwijder het videoframe.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Videoweergave instellen**

Configureer de video om automatisch af te spelen wanneer de dia wordt weergegeven.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Stel de video in om automatisch af te spelen.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```