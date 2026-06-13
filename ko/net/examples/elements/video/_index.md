---
title: 비디오
type: docs
weight: 80
url: /ko/net/examples/elements/video/
keywords:
- 비디오
- 비디오 프레임
- 비디오 추가
- 비디오 접근
- 비디오 제거
- 비디오 재생
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 비디오를 추가하고 제어합니다: 삽입, 재생, 트리밍, 포스터 프레임 설정, 그리고 PPT, PPTX, ODP 프레젠테이션에 대한 C# 예제로 내보내기."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**

슬라이드에 빈 비디오 프레임을 삽입합니다.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // 비디오를 추가합니다.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **비디오 프레임 가져오기**

슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 슬라이드에서 첫 번째 비디오 프레임에 접근합니다.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **비디오 프레임 제거**

슬라이드에서 비디오 프레임을 삭제합니다.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 비디오 프레임을 제거합니다.
    slide.Shapes.Remove(videoFrame);
}
```

## **비디오 재생 설정**

슬라이드가 표시될 때 비디오가 자동으로 재생되도록 설정합니다.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // 비디오가 자동으로 재생되도록 구성합니다.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```