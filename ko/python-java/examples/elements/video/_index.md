---
title: 비디오
type: docs
weight: 80
url: /ko/python-java/examples/elements/video/
keywords:
- 코드 예제
- 비디오
- 비디오 프레임
- 비디오 추가
- 비디오 액세스
- 비디오 제거
- 비디오 재생
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 비디오 프레임을 추가, 액세스, 제거 및 구성합니다."
---
이 문서는 **Aspose.Slides for Python via Java**를 사용하여 비디오 프레임을 추가하고 재생 옵션을 설정하는 방법을 보여줍니다.
패키지는 [Installation](/slides/ko/python-java/installation/)에 설명된 대로 설치합니다. 각 예제는 JVM을 시작하기 전에 `asposeslides`를 가져오고, JVM이 실행된 후 API를 가져옵니다.

## **비디오 프레임 추가**
외부 비디오 파일을 참조하는 비디오 프레임을 삽입합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 비디오 파일에 연결된 비디오 프레임을 추가합니다.
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")
finally:
    presentation.dispose()
```

## **비디오 프레임 액세스**
슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 슬라이드의 첫 번째 비디오 프레임에 액세스합니다.
    first_video = None
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            first_video = shape
            break

    if first_video is None:
        print("The slide contains no video frames.")
finally:
    presentation.dispose()
```

## **비디오 프레임 제거**
슬라이드에서 비디오 프레임을 삭제합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 비디오 프레임을 제거합니다.
    slide.getShapes().remove(video_frame)
finally:
    presentation.dispose()
```

## **비디오 재생 설정**
슬라이드가 표시될 때 비디오가 자동으로 재생되도록 구성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoPlayModePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4")

    # 비디오를 자동 재생하도록 구성합니다.
    video_frame.setPlayMode(VideoPlayModePreset.Auto)
finally:
    presentation.dispose()
```