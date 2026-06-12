---
title: Audio
type: docs
weight: 70
url: /nl/cpp/examples/elements/audio/
keywords:
- codevoorbeeld
- audio
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek audio-voorbeelden van Aspose.Slides voor C++: invoegen, afspelen, trimmen en geluid extraheren in PPT-, PPTX- en ODP-presentaties met heldere C++-code."
---
Dit artikel toont hoe u audio-frames kunt insluiten en de weergave kunt regelen met **Aspose.Slides for C++**. De volgende voorbeelden laten basis-audio-bewerkingen zien.

## **Audio-frame toevoegen**

Voeg een leeg audio-frame in dat later geluid kan bevatten.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Maak een leeg audio-frame (audio zal later worden ingesloten).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Toegang tot een audio-frame**

Deze code haalt het eerste audio-frame op een dia op.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Toegang tot het eerste audio-frame op de dia.
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

## **Audio-frame verwijderen**

Verwijder een eerder toegevoegd audio-frame.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Verwijder het audio-frame.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Audio-weergave instellen**

Stel het audio-frame in om automatisch af te spelen wanneer de dia verschijnt.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Speel automatisch af wanneer de dia verschijnt.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```