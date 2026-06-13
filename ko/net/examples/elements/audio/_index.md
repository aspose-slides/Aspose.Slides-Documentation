---
title: 오디오
type: docs
weight: 70
url: /ko/net/examples/elements/audio/
keywords:
- 오디오
- 오디오 프레임
- 오디오 추가
- 오디오 접근
- 오디오 제거
- 오디오 재생
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "명확한 C# 코드를 사용하여 PPT, PPTX 및 ODP 프레젠테이션에서 사운드를 삽입, 재생, 잘라내기 및 추출하는 Aspose.Slides for .NET 오디오 예제를 확인하세요."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 오디오 프레임을 삽입하고 재생을 제어하는 방법을 보여줍니다. 다음 예제에서는 기본 오디오 작업을 보여줍니다.

## **오디오 프레임 추가**

나중에 삽입된 사운드 데이터를 담을 수 있는 빈 오디오 프레임을 삽입합니다.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 빈 오디오 프레임을 생성합니다 (오디오는 나중에 삽입됩니다).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **오디오 프레임 접근**

이 코드는 슬라이드에서 첫 번째 오디오 프레임을 검색합니다.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 슬라이드에서 첫 번째 오디오 프레임에 접근합니다.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **오디오 프레임 제거**

이전에 추가된 오디오 프레임을 삭제합니다.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 오디오 프레임을 제거합니다.
    slide.Shapes.Remove(audioFrame);
}
```

## **오디오 재생 설정**

슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 구성합니다.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // 슬라이드가 표시될 때 자동으로 재생합니다.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```