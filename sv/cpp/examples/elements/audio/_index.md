---
title: Ljud
type: docs
weight: 70
url: /sv/cpp/examples/elements/audio/
keywords:
- kodexempel
- ljud
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck Aspose.Slides för C++ ljudexempel: infoga, spela upp, trimma och extrahera ljud i PPT-, PPTX- och ODP-presentationer med tydlig C++-kod."
---
Den här artikeln visar hur man bäddar in ljudramar och styr uppspelning med **Aspose.Slides for C++**. Följande exempel visar grundläggande ljudoperationer.

## **Lägg till en ljudram**

Infoga en tom ljudram som senare kan innehålla inbäddade ljuddata.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Skapa en tom ljudram (ljudet kommer att bäddas in senare).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Åtkomst till en ljudram**

Den här koden hämtar den första ljudramen på en bild.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Åtkomst till den första ljudramen på bilden.
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

## **Ta bort en ljudram**

Ta bort en tidigare tillagd ljudram.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Ta bort ljudramen.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Ställ in ljuduppspelning**

Konfigurera ljudramen så att den spelas upp automatiskt när bilden visas.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Spela upp automatiskt när bilden visas.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```