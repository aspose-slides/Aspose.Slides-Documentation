---
title: Video
type: docs
weight: 80
url: /sv/cpp/examples/elements/video/
keywords:
- kodexempel
- video
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lägg till och kontrollera videor med Aspose.Slides for C++: infoga, spela upp, trimma, ställ in posterbilder och exportera med C++-exempel för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur man bäddar in videoramar och ställer in uppspelningsalternativ med **Aspose.Slides for C++**.

## **Add a Video Frame**
Infoga en tom videoram på en bild.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägg till en video.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Access a Video Frame**
Hämta den första videoramen som lagts till på en bild.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Åtkomst till den första videoramen på bilden.
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
Ta bort en videoram från bilden.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Ta bort videoramen.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Set Video Playback**
Konfigurera videon så att den spelas upp automatiskt när bilden visas.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Konfigurera videon så att den spelas upp automatiskt.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```