---
title: Аудио
type: docs
weight: 70
url: /ru/cpp/examples/elements/audio/
keywords:
- пример кода
- аудио
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Откройте для себя примеры работы с аудио в Aspose.Slides for C++: вставка, воспроизведение, обрезка и извлечение звука в презентациях PPT, PPTX и ODP с понятным кодом на C++."
---
В этой статье демонстрируется, как встраивать аудиофреймы и управлять воспроизведением с помощью **Aspose.Slides for C++**. Ниже приведены основные операции с аудио.

## **Добавить аудиофрейм**

Вставьте пустой аудиофрейм, который позже может содержать встроенные звуковые данные.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Создать пустой аудиофрейм (аудио будет встроено позже).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **Получить доступ к аудиофрейму**

Этот код извлекает первый аудиофрейм на слайде.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Получить первый аудиофрейм на слайде.
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

## **Удалить аудиофрейм**

Удалите ранее добавленный аудиофрейм.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Удалить аудиофрейм.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **Настроить воспроизведение аудио**

Настройте аудиофрейм для автоматического воспроизведения при появлении слайда.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // Воспроизводить автоматически при появлении слайда.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```