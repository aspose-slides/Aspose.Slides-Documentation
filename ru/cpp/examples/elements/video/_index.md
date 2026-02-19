---
title: Видео
type: docs
weight: 80
url: /ru/cpp/examples/elements/video/
keywords:
- пример кода
- видео
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Добавляйте и управляйте видеороликами с помощью Aspose.Slides for C++: вставляйте, воспроизводите, обрезайте, задавайте постер-кадры и экспортируйте с примерами C++ для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует, как встраивать видеокадры и задавать параметры воспроизведения с помощью **Aspose.Slides for C++**.

## **Add a Video Frame**
Вставьте пустой видеокадр на слайд.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Добавить видео.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Access a Video Frame**
Получите первый видеокадр, добавленный на слайд.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Получить первый видеокадр на слайде.
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

## **Remove a Video Frame**
Удалите видеокадр со слайда.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Удалить видеокадр.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Set Video Playback**
Настройте воспроизведение видео автоматически при отображении слайда.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Настроить автоматическое воспроизведение видео.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```