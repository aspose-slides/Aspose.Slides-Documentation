---
title: Dźwięk
type: docs
weight: 70
url: /pl/cpp/examples/elements/audio/
keywords:
- przykład kodu
- dźwięk
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj przykłady audio Aspose.Slides dla C++: wstawianie, odtwarzanie, przycinanie i wyodrębnianie dźwięku w prezentacjach PPT, PPTX i ODP przy użyciu przejrzystego kodu C++."
---
Ten artykuł demonstruje, jak osadzać ramki dźwiękowe i kontrolować odtwarzanie przy użyciu **Aspose.Slides for C++**. Poniższe przykłady prezentują podstawowe operacje audio.

## **Dodaj ramkę dźwiękową**

Wstaw pustą ramkę dźwiękową, która później może zawierać osadzone dane dźwiękowe.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Utwórz pustą ramkę dźwiękową (dźwięk zostanie osadzony później).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Uzyskaj dostęp do ramki dźwiękowej**

Ten kod pobiera pierwszą ramkę dźwiękową na slajdzie.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Uzyskaj dostęp do pierwszej ramki dźwiękowej na slajdzie.
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

## **Usuń ramkę dźwiękową**

Usuń wcześniej dodaną ramkę dźwiękową.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Usuń ramkę dźwiękową.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Ustaw odtwarzanie audio**

Skonfiguruj ramkę dźwiękową, aby odtwarzała się automatycznie, gdy slajd się pojawi.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Odtwarzaj automatycznie, gdy slajd się pojawi.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```