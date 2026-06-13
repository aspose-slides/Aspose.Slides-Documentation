---
title: 비디오
type: docs
weight: 80
url: /ko/python-net/examples/elements/video/
keywords:
- 비디오
- 비디오 프레임
- 비디오 추가
- 비디오 액세스
- 비디오 제거
- 비디오 재생
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 비디오를 작업합니다: 삽입, 교체, 트림, 포스터 프레임 및 재생 옵션 설정, 그리고 PPT, PPTX 및 ODP용 프레젠테이션을 내보냅니다."
---
**Aspose.Slides for Python via .NET**를 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**
슬라이드에 빈 비디오 프레임을 삽입합니다.

```py
def add_video():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 비디오 프레임을 추가합니다.
        video_frame = slide.shapes.add_video_frame(50, 50, 320, 240, "video.mp4")

        presentation.save("video.pptx", slides.export.SaveFormat.PPTX)
```

## **비디오 프레임 액세스**
슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```py
def access_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 슬라이드에서 첫 번째 비디오 프레임에 액세스합니다.
        first_video = next(shape for shape in slide.shapes if isinstance(shape, slides.VideoFrame))
```

## **비디오 프레임 제거**
슬라이드에서 비디오 프레임을 삭제합니다.

```py
def remove_video():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 비디오 프레임이라고 가정합니다.
        video_frame = slide.shapes[0]

        # 비디오 프레임을 제거합니다.
        slide.shapes.remove(video_frame)

        presentation.save("video_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **비디오 재생 설정**
슬라이드가 표시될 때 비디오가 자동으로 재생되도록 구성합니다.

```py
def set_video_playback():
    with slides.Presentation("video.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 도형이 비디오 프레임이라고 가정합니다.
        video_frame = slide.shapes[0]

        # 비디오를 자동 재생하도록 구성합니다.
        video_frame.play_mode = slides.VideoPlayModePreset.AUTO

        presentation.save("video_playback.pptx", slides.export.SaveFormat.PPTX)
```