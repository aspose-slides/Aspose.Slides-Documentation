---
title: Python을 사용하여 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/python-java/video-frame/
keywords:
- 비디오 추가
- 비디오 만들기
- 비디오 임베드
- 비디오 추출
- 비디오 검색
- 비디오 프레임
- 웹 소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 방법 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다.

PowerPoint는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오를 추가하거나 삽입합니다(컴퓨터에 저장된 비디오)
* 온라인 비디오를 추가합니다(YouTube와 같은 웹 소스에서).

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 클래스 및 기타 관련 형식을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 프레젠테이션에 비디오를 임베드하기 위해 비디오 프레임을 만들 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 객체를 추가하고 비디오 파일 데이터를 전달하여 프레젠테이션에 비디오를 임베드합니다.
4. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 추가하여 비디오 프레임을 만듭니다.
5. 수정된 프레젠테이션을 저장합니다.

This Python code shows you how to add a video stored locally to a presentation:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    video_data = Path("Wildlife.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video)
    presentation.save("pres-with-video.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alternatively, you can add a video by passing its file path directly to the [addVideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addVideoFrame) method:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi")
finally:
    presentation.dispose()
```

## **웹 소스 비디오를 사용한 비디오 프레임 만들기**

Microsoft [PowerPoint 2013 및 이후 버전](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인(예: YouTube)에서 제공되는 경우 해당 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 추가하고 비디오 링크를 전달합니다.
4. 비디오 프레임의 썸네일을 설정합니다.
5. 프레젠테이션을 저장합니다.

```python
from urllib.request import urlopen

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoPlayModePreset

video_id = "Tj75Arhq5ho"
presentation = Presentation()
try:
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + video_id)
    video_frame.setPlayMode(VideoPlayModePreset.Auto)

    # 썸네일을 로드합니다.
    thumbnail_uri = "https://img.youtube.com/vi/" + video_id + "/hqdefault.jpg"
    try:
        with urlopen(thumbnail_uri) as response:
            thumbnail_data = response.read()
        java_thumbnail_data = jpype.JArray(jpype.JByte)(thumbnail_data)
        thumbnail = presentation.getImages().addImage(java_thumbnail_data)
        video_frame.getPictureFormat().getPicture().setImage(thumbnail)
    except OSError as error:
        print("Could not load the thumbnail:", error)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **비디오 프레임 트리밍**

Aspose.Slides는 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromEnd) 를 통해 시작부터와 끝부터 트리밍 값을 설정함으로써 비디오의 재생 부분을 제어할 수 있게 합니다. 두 값은 밀리초 단위이며 각각 비디오 시작과 끝에서 건너뛸 시간을 정의합니다. 이러한 설정은 프레젠테이션 내 비디오 재생 방식을 변경하지만, 임베드된 비디오 바이너리 데이터를 자르거나 수정하지는 않습니다.

**트리밍 설정**

비디오 프레임을 만들고 트리밍 설정을 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션에 [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 객체를 추가합니다.
3. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 추가합니다.
4. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromEnd) 를 통해 트리밍 값을 설정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 코드 예제는 임베드된 비디오 재생 시 처음 2.5초와 마지막 1초를 건너뛰도록 설정합니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video)

    video_frame.setTrimFromStart(2500.0)
    video_frame.setTrimFromEnd(1000.0)
    presentation.save("video_with_trim.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**트리밍 설정 읽기**

기존 트리밍 설정을 확인하려면 프레젠테이션을 로드하고, 첫 번째 슬라이드의 셰이프 중 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 찾아 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getTrimFromStart) 및 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getTrimFromEnd) 를 통해 값을 읽습니다.

다음 코드 예제는 첫 번째 슬라이드에서 첫 번째 비디오 프레임을 찾아 트리밍 설정을 밀리초 단위로 출력합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_trim.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            trim_from_start = shape.getTrimFromStart()
            trim_from_end = shape.getTrimFromEnd()
            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
finally:
    presentation.dispose()
```

## **비디오 캡션 관리**

Aspose.Slides는 PowerPoint 프레젠테이션의 비디오 프레임에 대한 클로즈드 캡션을 관리할 수 있게 해줍니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 액세스할 수 있습니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션에 비디오를 추가합니다.
3. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 추가합니다.
4. [getCaptionTracks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getCaptionTracks) 로 반환된 [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 을 사용해 WebVTT 캡션 트랙을 추가합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.mp4").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video)

    # WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    video_frame.getCaptionTracks().add("English", "track.vtt")
    presentation.save("video_with_captions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
2. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 찾습니다.
3. [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 에 있는 캡션 트랙을 순회합니다.
4. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, VideoFrame):
            for caption_track in shape.getCaptionTracks():
                # 캡션 트랙을 WebVTT 파일에 저장합니다.
                file_path = Path(str(caption_track.getCaptionId()) + ".vtt")
                caption_data = bytes(caption_track.getBinaryData())
                file_path.write_bytes(caption_data)
finally:
    presentation.dispose()
```

각 [Captions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF‑8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 모든 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
2. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체를 가져옵니다.
3. [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 에서 캡션 트랙을 제거합니다.
4. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VideoFrame

presentation = Presentation("video_with_captions.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    video_frame = slide.getShapes().get_Item(0)
    if isinstance(video_frame, VideoFrame):
        # 비디오 프레임에서 모든 캡션을 제거합니다.
        video_frame.getCaptionTracks().clear()
        presentation.save("video_without_captions.pptx", SaveFormat.Pptx)
    else:
        print("The shape is not a video frame.")
finally:
    presentation.dispose()
```

단일 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

비디오를 슬라이드에 추가하는 것 외에도 Aspose.Slides는 프레젠테이션에 임베드된 비디오를 추출할 수 있게 합니다.

1. 비디오가 포함된 프레젠테이션을 로드하려면 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 모든 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 객체를 순회합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체를 순회하여 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 을 찾습니다.
4. 비디오를 디스크에 저장합니다.

다음 Python 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame

presentation = Presentation("VideoSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, VideoFrame):
                video = shape.getEmbeddedVideo()
                if video is not None:
                    content_type = str(video.getContentType())
                    file_extension = content_type.split("/", 1)[-1]
                    video_data = bytes(video.getBinaryData())
                    Path("testing2." + file_extension).write_bytes(video_data)
                else:
                    print("The video frame has no embedded video.")
finally:
    presentation.dispose()
```

## **FAQ**

**VideoFrame에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇인가요?**

[재생 모드](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setPlayMode) (자동 또는 클릭) 및 [반복 재생 모드](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setPlayLoopMode)를 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기가 증가하나요?**

네. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 커집니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 작습니다.

**기존 VideoFrame의 위치와 크기를 유지하면서 비디오를 교체할 수 있나요?**

네. 프레임 내부의 [video content](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setEmbeddedVideo) 를 교체하면서 셰이프의 기하학적 속성을 그대로 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 흔히 사용되는 시나리오입니다.

**임베드된 비디오의 MIME 타입을 확인할 수 있나요?**

네. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/#getContentType) 을 가지고 있으며, 이를 읽어 디스크에 저장하는 등 다양한 용도로 활용할 수 있습니다.