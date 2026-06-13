---
title: 오디오
type: docs
weight: 70
url: /ko/python-net/examples/elements/audio/
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
- Python
- Aspose.Slides
description: "Python에서 Aspose.Slides를 사용하여 오디오 작업: 사운드를 추가, 교체, 추출 및 트림하고, PowerPoint와 OpenDocument의 슬라이드 및 셰이프에 대한 볼륨과 재생을 설정합니다."
---
오디오 프레임을 삽입하고 재생을 제어하는 방법을 **Aspose.Slides for Python via .NET**을 사용하여 보여줍니다. 다음 예제에서는 기본 오디오 작업을 보여줍니다.

## **Add an Audio Frame**
아래 코드 예제는 프레젠테이션 슬라이드에 오디오 프레임을 추가합니다.

```py
def add_audio():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        with open("audio.wav", "rb") as audio_stream:
            audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)

        presentation.save("audio.pptx", slides.export.SaveFormat.PPTX)
```

## **Access an Audio Frame**
이 코드는 슬라이드에서 첫 번째 오디오 프레임을 가져옵니다.

```py
def access_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        first_audio_frame = None
        for shape in slide.shapes:
            if isinstance(shape, slides.AudioFrame):
                first_audio_frame = shape
                break
```

## **Remove an Audio Frame**
이전에 추가된 오디오 프레임을 삭제합니다.

```py
def remove_audio():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 쉐이프가 AudioFrame이라고 가정합니다.
        audio_frame = slide.shapes[0]

        # 오디오 프레임을 제거합니다.
        slide.shapes.remove(audio_frame)

        presentation.save("audio_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Set Audio Playback**
슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 설정합니다.

```py
def set_audio_playback():
    with slides.Presentation("audio.pptx") as presentation:
        slide = presentation.slides[0]

        # 첫 번째 쉐이프가 AudioFrame이라고 가정합니다.
        audio_frame = slide.shapes[0]

        # 슬라이드가 나타날 때 자동으로 재생합니다.
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO

        presentation.save("audio_playback.pptx", slides.export.SaveFormat.PPTX)
```