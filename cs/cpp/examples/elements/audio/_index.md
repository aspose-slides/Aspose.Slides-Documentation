---
title: Zvuk
type: docs
weight: 70
url: /cs/cpp/examples/elements/audio/
keywords:
- ukázka kódu
- zvuk
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte ukázky audia pro Aspose.Slides for C++: vkládání, přehrávání, ořezávání a extrahování zvuku v prezentacích PPT, PPTX a ODP s přehledným C++ kódem."
---
Tento článek ukazuje, jak vložit audio snímky a řídit jejich přehrávání pomocí **Aspose.Slides for C++**. Následující příklady ukazují základní operace s audiem.

## **Přidat audio snímek**

Vložte prázdný audio snímek, který může později obsahovat vložená zvuková data.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Vytvořte prázdný audio snímek (audio bude vloženo později).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Přístup k audio snímku**

Tento kód získá první audio snímek na snímku.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Přístup k prvnímu audio snímku na snímku.
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

## **Odstranit audio snímek**

Smažte dříve přidaný audio snímek.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Odstraňte audio snímek.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Nastavit přehrávání audia**

Nastavte audio snímek tak, aby se přehrával automaticky při zobrazení snímku.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Přehrát automaticky při zobrazení snímku.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```