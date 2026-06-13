---
title: 오디오
type: docs
weight: 70
url: /ko/cpp/examples/elements/audio/
keywords:
- 코드 예제
- 오디오
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "명확한 C++ 코드를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 사운드를 삽입, 재생, 트림 및 추출하는 Aspose.Slides for C++ 오디오 예제를 확인하세요."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 오디오 프레임을 삽입하고 재생을 제어하는 방법을 보여줍니다. 다음 예제에서는 기본 오디오 작업을 설명합니다.

## **오디오 프레임 추가**

나중에 삽입된 사운드 데이터를 포함할 수 있는 빈 오디오 프레임을 삽입합니다.

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 빈 오디오 프레임을 생성합니다 (오디오는 나중에 삽입됩니다).
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **오디오 프레임 접근**

이 코드는 슬라이드에서 첫 번째 오디오 프레임을 가져옵니다.

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 슬라이드의 첫 번째 오디오 프레임에 접근합니다.
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

## **오디오 프레임 제거**

이전에 추가된 오디오 프레임을 삭제합니다.

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 오디오 프레임을 제거합니다.
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **오디오 재생 설정**

슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 설정합니다.

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // 슬라이드가 표시될 때 자동으로 재생됩니다.
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```