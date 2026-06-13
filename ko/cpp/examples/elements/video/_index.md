---
title: 비디오
type: docs
weight: 80
url: /ko/cpp/examples/elements/video/
keywords:
- 코드 예제
- 비디오
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 비디오를 추가하고 제어합니다: 삽입, 재생, 트림, 포스터 프레임 설정 및 PPT, PPTX, ODP 프레젠테이션용 C++ 예제로 내보내기."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**

슬라이드에 빈 비디오 프레임을 삽입합니다.

```cpp
static void AddVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // 비디오를 추가합니다.
    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    presentation->Dispose();
}
```

## **비디오 프레임 접근**

슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```cpp
static void AccessVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 슬라이드에서 첫 번째 비디오 프레임에 접근합니다.
    auto firstVideo = SharedPtr<IVideoFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            firstVideo = ExplicitCast<IVideoFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **비디오 프레임 제거**

슬라이드에서 비디오 프레임을 삭제합니다.

```cpp
static void RemoveVideo()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 비디오 프레임을 제거합니다.
    slide->get_Shapes()->Remove(videoFrame);

    presentation->Dispose();
}
```

## **비디오 재생 설정**

슬라이드가 표시될 때 비디오가 자동으로 재생되도록 구성합니다.

```cpp
static void SetVideoPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 320, 240, u"video.mp4");

    // 비디오가 자동으로 재생되도록 구성합니다.
    videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

    presentation->Dispose();
}
```