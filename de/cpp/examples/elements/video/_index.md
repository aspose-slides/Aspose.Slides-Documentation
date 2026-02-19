---
title: Video
type: docs
weight: 80
url: /de/cpp/examples/elements/video/
keywords:
- Codebeispiel
- Video
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Videos mit Aspose.Slides für C++ hinzufügen und steuern: Einfügen, abspielen, zuschneiden, Poster-Frames festlegen und mit C++-Beispielen für PPT-, PPTX- und ODP-Präsentationen exportieren."
---
Dieser Artikel zeigt, wie man Video‑Frames einbettet und Wiedergabeoptionen mit **Aspose.Slides for C++** einstellt.

## **Video‑Frame hinzufügen**

Fügen Sie einen leeren Video‑Frame zu einer Folie hinzu.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ein Video hinzufügen.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **Zugriff auf einen Video‑Frame**

Rufen Sie den ersten zu einer Folie hinzugefügten Video‑Frame ab.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Greift auf den ersten Video‑Frame auf der Folie zu.
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

## **Video‑Frame entfernen**

Löschen Sie einen Video‑Frame von der Folie.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Entfernt den Video-Frame.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **Video‑Wiedergabe einstellen**

Konfigurieren Sie das Video so, dass es automatisch abgespielt wird, wenn die Folie angezeigt wird.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // Konfiguriert das Video für die automatische Wiedergabe.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```