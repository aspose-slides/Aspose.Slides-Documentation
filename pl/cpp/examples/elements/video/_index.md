---
title: Wideo
type: docs
weight: 80
url: /pl/cpp/examples/elements/video/
keywords:
- przykład kodu
- wideo
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Dodawaj i kontroluj wideo przy użyciu Aspose.Slides for C++: wstawiaj, odtwarzaj, przycinaj, ustawiaj ramki plakatu i eksportuj przy użyciu przykładów C++ dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje, jak osadzać ramki wideo i ustawiać opcje odtwarzania przy użyciu **Aspose.Slides for C++**.

## **Dodaj ramkę wideo**

Wstaw pustą ramkę wideo na slajd.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaj wideo.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do ramki wideo**

Pobierz pierwszą ramkę wideo dodaną do slajdu.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Uzyskaj dostęp do pierwszej ramki wideo na slajdzie.
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

## **Usuń ramkę wideo**

Usuń ramkę wideo ze slajdu.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Usuń ramkę wideo.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Ustaw odtwarzanie wideo**

Skonfiguruj odtwarzanie wideo, aby uruchamiało się automatycznie, gdy slajd jest wyświetlany.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Skonfiguruj wideo, aby odtwarzało się automatycznie.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```