---
title: 오디오
type: docs
weight: 70
url: /ko/python-java/examples/elements/audio/
keywords:
- 코드 예시
- 오디오
- 오디오 프레임
- 오디오 추가
- 오디오 접근
- 오디오 제거
- 오디오 재생
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 오디오 프레임을 추가하고, 접근하고, 제거하며, 구성합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 오디오 프레임을 삽입하고 재생을 제어하는 방법을 보여줍니다. 다음 예제에서는 기본 오디오 작업을 보여줍니다.

패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후에 API를 가져옵니다.

## **오디오 프레임 추가**

나중에 임베드된 사운드 데이터를 담을 수 있는 빈 오디오 프레임을 삽입합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)

    # 빈 오디오 프레임을 생성합니다 (오디오는 나중에 삽입됩니다).
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)
finally:
    presentation.dispose()
```

## **오디오 프레임 액세스**

이 코드는 슬라이드의 첫 번째 오디오 프레임을 가져옵니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioFrame, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 슬라이드에서 첫 번째 오디오 프레임에 접근합니다.
    first_audio = None
    for shape in slide.getShapes():
        if isinstance(shape, AudioFrame):
            first_audio = shape
            break

    if first_audio is None:
        print("The slide contains no audio frames.")
finally:
    presentation.dispose()
```

## **오디오 프레임 제거**

이전에 추가한 오디오 프레임을 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 오디오 프레임을 제거합니다.
    slide.getShapes().remove(audio_frame)
finally:
    presentation.dispose()
```

## **오디오 재생 설정**

슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 구성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.io import ByteArrayInputStream
from asposeslides.api import AudioPlayModePreset, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    audio_data = jpype.JArray(jpype.JByte)(0)
    audio_stream = ByteArrayInputStream(audio_data)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(50, 50, 100, 100, audio_stream)

    # 슬라이드가 표시될 때 자동으로 재생됩니다.
    audio_frame.setPlayMode(AudioPlayModePreset.Auto)
finally:
    presentation.dispose()
```