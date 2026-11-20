---
title: Python을 사용하여 프레젠테이션에서 오디오 프레임 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/python-net/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- WebVTT
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하며, 재생을 구성하고, WebVTT 캡션을 관리하고, 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for Python via .NET를 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하며, 재생을 조정하고 캡션을 첨부할 수 있습니다. 또한 슬라이드 전환에 할당된 사운드를 검색할 수도 있습니다.

## **오디오 프레임 만들기**

첫 번째 슬라이드에 로컬 오디오 클립을 삽입하려면 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 을 사용합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제에서는 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 을 자동으로 클립을 시작하도록 설정하고 [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) 을 큰 사전 설정으로 설정합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 지정 썸네일을 표시하려면 [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) 으로 프레젠테이션에 이미지를 추가하고 해당 이미지를 프레임의 [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) 속성에 할당합니다. 예제에서는 임베드된 오디오 클립의 썸네일로 JPEG를 사용합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 재생 옵션 변경**

PowerPoint의 **Audio Options** 컨트롤은 클립이 언제 시작하고, 얼마나 크게 들리며, 슬라이드 쇼 중에 어떻게 동작하는지를 결정합니다.

![오디오 프레임에 대한 PowerPoint 오디오 옵션 컨트롤](audio_frame_0.png)

| PowerPoint 컨트롤 | Aspose.Slides property |
| --- | --- |
| 시작 | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| 볼륨 사전 설정 | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| 슬라이드 전체 재생 | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| 중지될 때까지 반복 | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| 쇼 중 숨기기 | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| 재생 후 되감기 | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| 페이드 인 | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| 페이드 아웃 | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| 오디오 시작 시점 자르기 | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| 오디오 종료 시점 자르기 | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| 볼륨 슬라이더 | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

예제에서는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 찾아 [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) 을 클릭 시 재생 시작으로 설정하고 낮은 볼륨 사전 설정을 선택합니다. 루프를 비활성화한 상태에서 클립은 슬라이드 전체에 걸쳐 재생됩니다. 아이콘은 쇼 중에 숨겨지고, 재생 후 클립이 되감깁니다.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

길이가 3.5초를 초과하는 클립의 경우, 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 은 클립 끝에서 생략할 기간을 측정합니다. PowerPoint에 표시되는 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 잘라낸 클립은 200밀리초 동안 페이드 인하고 500밀리초 동안 페이드 아웃합니다. 네 가지 속성 모두 밀리초 단위 값을 사용합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

재생 볼륨을 특정 비율로 설정하려면 [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) 을 사용합니다. 이 예제에서는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85%로 설정합니다.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **오디오 캡션 관리**

각 오디오 프레임에는 [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) 컬렉션이 있습니다. 이를 사용하여 클립에 WebVTT 캡션을 첨부하거나 기존 트랙을 내보내거나 제거할 수 있습니다.

### **오디오 캡션 추가**

예제에서는 첫 번째 슬라이드에 오디오 클립을 삽입하고 [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) 을 사용하여 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인수는 트랙 레이블을 제공하고, 두 번째 인수는 타이밍 캡션이 포함된 파일을 지정합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드에 있는 오디오 프레임에 첨부된 각 캡션 트랙을 내보냅니다. 트랙의 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) 를 WebVTT 파일에 기록하고, [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) 를 파일 이름으로 사용하여 각 트랙이 별도의 출력 파일을 갖도록 합니다.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **오디오 캡션 제거**

[remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 또는 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 를 사용하여 개별 트랙을 삭제합니다. 예제에서는 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) 를 사용하여 클립은 유지하면서 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거합니다.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 라인을 찾으려면 각 트랙의 [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) 을 메모리에서 읽습니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인에 `-->` 가 포함되고, 그 뒤에 캡션 라인이 이어지며, 빈 줄이 큐를 종료합니다. 이 예제는 트랙 레이블과 “café” 를 포함하는 각 캡션 라인을 출력합니다.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **오디오 추출**

슬라이드 전환에는 자체 사운드가 있을 수 있습니다. 이를 검색하려면 전환의 [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) 속성을 읽습니다. 예제에서는 사운드의 [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) 에 접근하고 바이트 단위 크기를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **FAQ**

**같은 오디오 클립을 여러 슬라이드에서 중복 없이 재사용할 수 있나요?**

예. 클립을 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) 에 한 번 추가하고 각 슬라이드에 대해 동일한 오디오 객체를 [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) 에 전달하면 됩니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 링크된 사운드의 경우 [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) 을 교체 파일을 가리키도록 업데이트합니다. 임베드된 사운드의 경우 프레젠테이션의 오디오 컬렉션에서 다른 클립을 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) 에 할당합니다. 두 방법 모두 기존 프레임을 유지합니다.

**트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니오. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) 과 [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) 은 재생 경계를 설정합니다. 여전히 [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) 에서 전체 클립을 가져올 수 있습니다.