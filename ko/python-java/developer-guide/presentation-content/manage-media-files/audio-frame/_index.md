---
title: Python을 사용하여 프레젠테이션에서 오디오 프레임 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/python-java/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하며, 재생을 구성하고, WebVTT 캡션을 관리하고, 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for Python via Java를 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하고, 재생을 조정하며, 캡션을 첨부할 수 있습니다. 또한 슬라이드 전환에 할당된 사운드를 검색할 수도 있습니다.

## **오디오 프레임 만들기**

`audio.wav` 파일의 바이트를 프레젠테이션의 오디오 컬렉션에 추가한 다음 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 을 사용하여 첫 번째 슬라이드에 로컬 오디오 클립을 삽입합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제는 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 을 호출하여 클립을 자동으로 시작하고, [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) 을 호출하여 큰 볼륨 사전 설정을 선택합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 150, 100, 100, audio)

    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
    audio_frame.setVolume(AudioVolumeMode.Loud)

    presentation.save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 지정 썸네일을 표시하려면 [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) 로 프레젠테이션에 이미지를 추가하고, [setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage) 로 프레임의 그림에 설정합니다. 예제는 삽입된 오디오 클립의 썸네일로 JPEG를 사용합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(150, 100, 50, 50, audio)

    image = Images.fromFile("eagle.jpeg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    audio_frame.getPictureFormat().getPicture().setImage(picture)

    presentation.save("example_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **오디오 재생 옵션 변경**

PowerPoint의 **Audio Options** 컨트롤은 클립이 시작되는 시점, 소리 크기 및 슬라이드 쇼 동안의 동작을 결정합니다.

![오디오 프레임에 대한 PowerPoint 오디오 옵션 컨트롤](audio_frame_0.png)

| PowerPoint 컨트롤 | Aspose.Slides for Python via Java 메서드 |
| --- | --- |
| 시작 | [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) |
| 볼륨 사전 설정 | [setVolume](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolume) |
| 슬라이드 전체 재생 | [setPlayAcrossSlides](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayAcrossSlides) |
| 정지될 때까지 반복 | [setPlayLoopMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayLoopMode) |
| 쇼 동안 숨기기 | [setHideAtShowing](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setHideAtShowing) |
| 재생 후 되감기 | [setRewindAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setRewindAudio) |
| 페이드 인 | [setFadeInDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeInDuration) |
| 페이드 아웃 | [setFadeOutDuration](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 오디오 시작 시간 자르기 | [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) |
| 오디오 종료 시간 자르기 | [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 볼륨 슬라이더 | [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) |

예제는 첫 번째 슬라이드에서 첫 번째 오디오 프레임을 찾은 다음 [setPlayMode](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setPlayMode) 을 호출해 클릭 시 재생을 시작하고 낮은 볼륨 사전 설정을 선택합니다. 클립은 슬라이드 전체에서 재생되지만 반복은 비활성화됩니다. 아이콘은 쇼 동안 숨겨지고, 재생이 끝난 후 클립이 되감깁니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, AudioPlayModePreset, AudioVolumeMode, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        # 클릭 시 저음량으로 재생하며, 슬라이드 전체에서 재생하고, 반복하지 않음.
        audio_frame.setPlayMode(AudioPlayModePreset.OnClick)
        audio_frame.setVolume(AudioVolumeMode.Low)
        audio_frame.setPlayAcrossSlides(True)
        audio_frame.setPlayLoopMode(False)
        # 슬라이드 쇼 중에 프레임을 숨기고 재생 후 되감음.
        audio_frame.setHideAtShowing(True)
        audio_frame.setRewindAudio(True)

        presentation.save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

클립 길이가 3.5초를 초과하는 경우 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 은 클립 끝에서 생략할 지속 시간을 지정합니다. PowerPoint에 표시된 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 잘린 클립은 200밀리초에 걸쳐 페이드 인하고 500밀리초에 걸쳐 페이드 아웃합니다. 네 가지 메서드 모두 밀리초 단위 값을 사용합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio)

    # 시작부터 1.5초, 끝부터 2초를 잘라냅니다.
    audio_frame.setTrimFromStart(1500.0)
    audio_frame.setTrimFromEnd(2000.0)
    # 페이드 인을 200ms, 페이드 아웃을 500ms로 설정합니다.
    audio_frame.setFadeInDuration(200.0)
    audio_frame.setFadeOutDuration(500.0)

    presentation.save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

재생 볼륨을 특정 비율로 설정하려면 [setVolumeValue](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setVolumeValue) 를 사용합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85% 볼륨으로 설정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("AudioFrameEmbed_out.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.setVolumeValue(85.0)
        presentation.save("AudioFrameValue_out.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

## **오디오 캡션 관리**

각 오디오 프레임은 [getCaptionTracks](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getCaptionTracks) 을 통해 캡션 트랙에 접근할 수 있습니다. 컬렉션을 사용해 WebVTT 캡션을 클립에 첨부하거나 기존 트랙을 내보내거나 제거할 수 있습니다.

### **오디오 캡션 추가**

예제는 첫 번째 슬라이드에 오디오 클립을 삽입하고 [add](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#add) 을 사용해 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인자는 트랙 라벨을 제공하고, 두 번째 인자는 타임캡션이 포함된 파일을 지정합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("audio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(10, 10, 50, 50, audio)

    # WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    audio_frame.getCaptionTracks().add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드의 오디오 프레임에 연결된 각 캡션 트랙을 내보냅니다. [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getBinaryData) 로 반환된 바이트를 WebVTT 파일에 기록하고, [getCaptionId](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getCaptionId) 로 반환된 식별자를 파일 이름으로 사용하여 트랙마다 별도 출력이 생성되게 합니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            for caption_track in shape.getCaptionTracks():
                # 캡션 트랙을 .vtt 파일로 저장합니다.
                file_path = Path(f"{caption_track.getCaptionId()}.vtt")
                caption_data = bytes(caption_track.getBinaryData())
finally:
    presentation.dispose()
```

### **오디오 캡션 제거**

[remove](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#removeAt) 로 개별 트랙을 삭제합니다. 예제는 [clear](https://reference.aspose.com/slides/python-java/aspose.slides/captionscollection/#clear) 를 사용해 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거하면서 클립은 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation, SaveFormat

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    audio_frame = next((shape for shape in slide.getShapes() if isinstance(shape, AudioFrame)), None)
    if audio_frame is not None:
        audio_frame.getCaptionTracks().clear()
        presentation.save("audio_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The first slide has no audio frame.")
finally:
    presentation.dispose()
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 특정 라인을 찾으려면 메모리 상에 있는 [getDataAsString](https://reference.aspose.com/slides/python-java/aspose.slides/captions/#getDataAsString) 로 반환된 텍스트를 검색합니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인에 `-->` 가 포함되고, 그 다음에 캡션 라인이 오며, 빈 라인으로 큐가 끝납니다. 이 예제는 트랙 라벨과 “café” 를 포함하는 각 캡션 라인을 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AudioFrame, Presentation

presentation = Presentation("audio_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, AudioFrame):
            continue
        for track in shape.getCaptionTracks():
            in_cue = False
            captions = str(track.getDataAsString())
            for line in captions.splitlines():
                if not line:
                    in_cue = False
                elif "-->" in line:
                    in_cue = True
                elif in_cue and "café" in line.casefold():
                    print(f"{track.getLabel()}: {line}")
finally:
    presentation.dispose()
```

## **오디오 추출**

슬라이드 전환에 고유한 사운드가 있을 수 있습니다. 이를 가져오려면 슬라이드 전환에서 [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSound) 를 호출합니다. 예제는 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData) 로 반환된 바이트에 접근해 바이트 수를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AudioSlide.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    transition = slide.getSlideShowTransition()
    sound = transition.getSound()
    if sound is not None:
        audio_data = sound.getBinaryData()
        print(f"Transition sound: {len(audio_data)} bytes.")
    else:
        print("The slide transition has no sound.")
finally:
    presentation.dispose()
```

## **FAQ**

**오디오 클립을 여러 슬라이드에서 중복 없이 재사용할 수 있나요?**

예. 클립을 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getAudios) 에 한 번 추가하고 각 슬라이드에 대해 동일한 오디오 객체를 [addAudioFrameEmbedded](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) 에 전달합니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 링크된 사운드의 경우 [setLinkPathLong](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setLinkPathLong) 를 사용해 교체 파일을 지정합니다. 삽입된 사운드의 경우 [setEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setEmbeddedAudio) 로 프레젠테이션의 오디오 컬렉션에서 다른 클립을 선택합니다. 두 방법 모두 기존 프레임을 유지합니다.

**트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니오. [setTrimFromStart](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromStart) 와 [setTrimFromEnd](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#setTrimFromEnd) 은 재생 경계를 설정할 뿐이며, 전체 클립은 [getEmbeddedAudio](https://reference.aspose.com/slides/python-java/aspose.slides/audioframe/#getEmbeddedAudio) 로 여전히 가져올 수 있습니다.