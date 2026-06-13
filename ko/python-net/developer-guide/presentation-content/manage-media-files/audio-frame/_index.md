---
title: 파이썬을 사용하여 프레젠테이션에서 오디오 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/python-net/audio-frame/
keywords:
- 오디오 추가
- 오디오 삽입
- 오디오 프레임
- 오디오 파일
- 오디오 속성
- 오디오 추출
- 오디오 가져오기
- 오디오 변경
- 재생 옵션
- 재생 모드
- 슬라이드 전체 재생
- 정지될 때까지 반복
- 쇼 중 숨기기
- 재생 후 되감기
- 오디오 볼륨
- 기본 이미지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PPT, PPTX 및 ODP에서 오디오 프레임을 손쉽게 추가, 추출 및 관리할 수 있습니다. 코드 예제를 살펴보고 오늘 프레젠테이션을 강화하세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 오디오 프레임을 사용하는 방법을 설명합니다. 슬라이드에 내장 오디오를 추가하고, 오디오 프레임 썸네일을 사용자 지정하며, 볼륨, 반복, 숨기기, 트리밍 및 페이드 지속 시간과 같은 재생 옵션을 구성하고, 슬라이드 쇼 전환에 사용되는 오디오를 추출하는 방법을 보여줍니다.

## **오디오 프레임 만들기**

Aspose.Slides for Python via .NET을 사용하면 오디오 파일을 슬라이드에 추가할 수 있습니다. 오디오 파일은 오디오 프레임으로 슬라이드에 내장됩니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드 참조를 가져옵니다.  
3. 슬라이드에 내장하려는 오디오 파일 스트림을 로드합니다.  
4. 오디오 파일을 포함하는 내장 오디오 프레임을 슬라이드에 추가합니다.  
5. [PlayMode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioplaymodepreset) 및 `Volume`을 [IAudioFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/) 객체에서 설정합니다.  
6. 수정된 프레젠테이션을 저장합니다.  

다음 Python 코드는 슬라이드에 내장 오디오 프레임을 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
with slides.Presentation() as pres:
    # 첫 번째 슬라이드를 가져옵니다
    sld = pres.slides[0]

    # wav 사운드 파일을 스트림으로 로드합니다
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # 오디오 프레임을 추가합니다
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # 오디오의 재생 모드와 볼륨을 설정합니다
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # PowerPoint 파일을 디스크에 저장합니다
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 프레임 썸네일 변경**

프레젠테이션에 오디오 파일을 추가하면 오디오가 표준 기본 이미지가 있는 프레임으로 표시됩니다(아래 섹션의 이미지를 참조). 오디오 프레임의 썸네일을 변경하여 원하는 이미지를 설정할 수 있습니다.

다음 Python 코드는 오디오 프레임의 썸네일 또는 미리보기 이미지를 변경하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 지정된 위치와 크기로 슬라이드에 오디오 프레임을 추가합니다.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # 프레젠테이션 리소스에 이미지를 추가합니다.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # 오디오 프레임의 이미지를 설정합니다.
        audioFrame.picture_format.picture.image = audioImage
        
        #수정된 프레젠테이션을 디스크에 저장합니다
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 재생 옵션 변경**

Aspose.Slides for Python via .NET을 사용하면 오디오 재생 또는 속성을 제어하는 옵션을 변경할 수 있습니다. 예를 들어 오디오 볼륨을 조정하고, 오디오를 루프 재생하도록 설정하거나, 오디오 아이콘을 숨길 수도 있습니다.

Microsoft PowerPoint의 **오디오 옵션** 창:

![example1_image](audio_frame_0.png)

PowerPoint **오디오 옵션**은 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/) 속성과 대응됩니다:

- **Start** 드롭다운 목록은 [AudioFrame.play_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/play_mode/) 속성과 일치합니다.  
- **Volume**은 [AudioFrame.volume](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/volume/) 속성과 일치합니다.  
- **Play Across Slides**은 [AudioFrame.play_across_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/play_across_slides/) 속성과 일치합니다.  
- **Loop until Stopped**은 [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/play_loop_mode/) 속성과 일치합니다.  
- **Hide During Show**은 [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/hide_at_showing/) 속성과 일치합니다.  
- **Rewind after Playing**은 [AudioFrame.rewind_audio](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/rewind_audio/) 속성과 일치합니다.  

PowerPoint **편집** 옵션은 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/) 속성과 대응됩니다:

- **Fade In**은 [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/fade_in_duration/) 속성과 일치합니다.  
- **Fade Out**은 [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/fade_out_duration/) 속성과 일치합니다.  
- **Trim Audio Start Time**은 [AudioFrame.trim_from_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/trim_from_start/) 속성과 일치합니다.  
- **Trim Audio End Time** 값은 오디오 전체 길이에서 [AudioFrame.trim_from_end](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/trim_from_end/) 속성 값을 뺀 값과 같습니다.  

PowerPoint 오디오 컨트롤 패널의 **볼륨 제어**는 [AudioFrame.volume_value](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/volume_value/) 속성과 대응됩니다. 이를 통해 오디오 볼륨을 백분율로 변경할 수 있습니다.

오디오 재생 옵션을 변경하는 방법은 다음과 같습니다:

1. [Create](#create-audio-frame) 또는 Audio Frame을 가져옵니다.  
2. 조정하려는 Audio Frame 속성에 새 값을 설정합니다.  
3. 수정된 PowerPoint 파일을 저장합니다.  

다음 Python 코드는 오디오 옵션을 조정하는 작업을 시연합니다:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # AudioFrame 모양을 가져옵니다
    audioFrame = pres.slides[0].shapes[0]

    # 재생 모드를 클릭 시 재생으로 설정합니다
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # 볼륨을 낮게 설정합니다
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # 오디오를 슬라이드 전체 재생하도록 설정합니다
    audioFrame.play_across_slides = True

    # 오디오의 반복을 비활성화합니다
    audioFrame.play_loop_mode = False

    # 슬라이드 쇼 중에 AudioFrame을 숨깁니다
    audioFrame.hide_at_showing = True

    # 재생 후 오디오를 시작 위치로 되감습니다
    audioFrame.rewind_audio = True

    # PowerPoint 파일을 디스크에 저장합니다
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

다음 Python 예제는 내장 오디오가 포함된 새 오디오 프레임을 추가하고, 트리밍하고, 페이드 지속 시간을 설정하는 방법을 보여줍니다:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # 트리밍 시작 오프셋을 1.5초로 설정합니다
    audio_frame.trim_from_start = 1500.0
    # 트리밍 종료 오프셋을 2초로 설정합니다
    audio_frame.trim_from_end = 2000.0

    # 페이드 인 지속 시간을 200밀리초로 설정합니다
    audio_frame.fade_in_duration = 200.0
    # 페이드 아웃 지속 시간을 500밀리초로 설정합니다
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

다음 코드 샘플은 내장 오디오가 포함된 오디오 프레임을 검색하고 볼륨을 85%로 설정하는 방법을 보여줍니다:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # 오디오 프레임 모양을 가져옵니다
    audio_frame = pres.slides[0].shapes[0]

    # 오디오 볼륨을 85%로 설정합니다
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 캡션 관리**

Aspose.Slides를 사용하면 [caption_tracks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/caption_tracks/) 속성을 통해 오디오 프레임에 폐쇄 캡션을 추가할 수 있습니다. 이 속성은 [CaptionsCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/)을 반환하며, 이를 통해 WebVTT 캡션 트랙을 추가하고, 기존 트랙을 순회하며, 필요시 제거할 수 있습니다.

### **오디오 캡션 추가**

[caption_tracks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/caption_tracks/) 속성을 사용하여 오디오 프레임에 하나 이상의 캡션 트랙을 연결합니다. 다음 예에서는 슬라이드에 오디오 파일을 추가한 후 `.vtt` 파일에서 새 캡션 트랙을 로드합니다.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **오디오 캡션 추출**

오디오 프레임에 연결된 캡션 트랙을 순회하면서 `.vtt` 파일로 저장할 수 있습니다. 각 캡션 트랙은 이진 데이터와 고유 식별자를 제공하며, 캡션을 내보낼 때 사용할 수 있습니다.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # 캡션 트랙을 .vtt 파일로 저장합니다.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

### **오디오 캡션 제거**

오디오 프레임에서 캡션을 제거하려면 [CaptionsCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/)에서 제공하는 메서드([clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/remove/), [remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/remove_at/))를 사용합니다. 다음 예제는 오디오 프레임에서 모든 캡션 트랙을 제거합니다.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # 타입: slides.AudioFrame

    # 오디오 프레임에서 모든 캡션 트랙을 제거합니다.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 추출**

Aspose.Slides for Python via .NET을 사용하면 슬라이드 쇼 전환에 사용되는 사운드를 추출할 수 있습니다. 예를 들어 특정 슬라이드에 사용된 사운드를 추출할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성하고 오디오가 포함된 프레젠테이션을 로드합니다.  
2. 인덱스를 통해 해당 슬라이드의 참조를 가져옵니다.  
3. 슬라이드의 슬라이드쇼 전환에 접근합니다.  
4. 바이트 데이터로 사운드를 추출합니다.  

다음 Python 코드는 슬라이드에 사용된 오디오를 추출하는 방법을 보여줍니다:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # 원하는 슬라이드에 접근합니다
    slide = pres.slides[0]  

    # 슬라이드의 슬라이드쇼 전환 효과를 가져옵니다
    transition = slide.slide_show_transition

    # 사운드를 바이트 배열로 추출합니다
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 자산을 재사용하면서 파일 크기가 늘어나지 않나요?**

예. 오디오를 프레젠테이션의 공유 [audio collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/audios/)에 한 번 추가한 다음 해당 자산을 참조하는 추가 오디오 프레임을 만들면 됩니다. 이렇게 하면 미디어 데이터가 중복되지 않아 프레젠테이션 크기를 제어할 수 있습니다.

**기존 오디오 프레임의 사운드를 형태를 다시 만들지 않고 교체할 수 있나요?**

예. 링크된 사운드인 경우 [link path](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/link_path_long/)를 새로운 파일을 가리키도록 업데이트하면 됩니다. 내장 사운드인 경우 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/audios/)에서 다른 [embedded audio](https://reference.aspose.com/slides/ko/python-net/aspose.slides/audioframe/embedded_audio/) 객체로 교체하면 됩니다. 프레임의 서식과 대부분의 재생 설정은 그대로 유지됩니다.

**트리밍이 프레젠테이션에 저장된 원본 오디오 데이터에 영향을 줍니까?**

아니요. 트리밍은 재생 경계만 조정합니다. 원본 오디오 바이트는 그대로 유지되며, 내장 오디오나 프레젠테이션의 오디오 컬렉션을 통해 접근할 수 있습니다.