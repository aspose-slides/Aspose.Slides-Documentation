---
title: Audio
type: docs
weight: 70
url: /de/cpp/examples/elements/audio/
keywords:
- Codebeispiel
- Audio
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Audiodemonstrationen von Aspose.Slides für C++: Einfügen, Abspielen, Trimmen und Extrahieren von Sound in PPT-, PPTX- und ODP-Präsentationen mit klarem C++-Code."
---
Dieser Artikel demonstriert, wie Audio-Frames eingebettet und die Wiedergabe mit **Aspose.Slides for C++** gesteuert werden kann. Die folgenden Beispiele zeigen grundlegende Audio-Operationen.

## **Audio-Frame hinzufügen**

Fügen Sie einen leeren Audio-Frame ein, der später eingebettete Audiodaten enthalten kann.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Erstelle einen leeren Audio-Frame (Audio wird später eingebettet).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Zugriff auf einen Audio-Frame**

Dieser Code ruft den ersten Audio-Frame auf einer Folie ab.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Zugriff auf den ersten Audio-Frame auf der Folie.
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

## **Audio-Frame entfernen**

Löschen Sie einen zuvor hinzugefügten Audio-Frame.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Entferne den Audio-Frame.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Audio-Wiedergabe festlegen**

Konfigurieren Sie den Audio-Frame so, dass er automatisch wiedergegeben wird, wenn die Folie angezeigt wird.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Spiele automatisch, wenn die Folie erscheint.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```