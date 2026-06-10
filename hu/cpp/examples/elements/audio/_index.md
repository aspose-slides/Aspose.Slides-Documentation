---
title: Hang
type: docs
weight: 70
url: /hu/cpp/examples/elements/audio/
keywords:
- kód példa
- hang
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ hangpéldákat: hang beillesztése, lejátszása, vágása és kinyerése PPT, PPTX és ODP prezentációkban, egyértelmű C++ kóddal."
---
Ez a cikk bemutatja, hogyan lehet hangkereteket beágyazni és a lejátszást vezérelni az **Aspose.Slides for C++** segítségével. A következő példák az alapvető audio műveleteket mutatják be.

## **Hangkeret hozzáadása**

Helyezzen be egy üres hangkeretet, amely később beágyazott hangadatot tartalmazhat.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Hozzon létre egy üres hangkeretet (a hang később lesz beágyazva).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Hangkeret elérése**

Ez a kód lekéri az első hangkeretet egy dián.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Eléri a dián lévő első hangkeretet.
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

## **Hangkeret eltávolítása**

Törölje a korábban hozzáadott hangkeretet.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Távolítsa el a hangkeretet.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Hanglejátszás beállítása**

Állítsa be a hangkeretet úgy, hogy automatikusan lejátszódjon, amikor a dia megjelenik.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Lejátszás automatikusan, amikor a dia megjelenik.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```