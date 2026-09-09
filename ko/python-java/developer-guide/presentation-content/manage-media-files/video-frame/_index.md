---
title: Python을 사용해 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/python-java/video-frame/
keywords:
- 비디오 추가
- 비디오 만들기
- 비디오 삽입
- 비디오 추출
- 비디오 검색
- 비디오 프레임
- 웹 소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배우세요. 빠른 실무 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다.

PowerPoint에서는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:
* 로컬 비디오 추가 또는 삽입(내 컴퓨터에 저장된 비디오)
* 온라인 비디오 추가(YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 개체)를 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 비디오 프레임을 만들어 프레젠테이션에 비디오를 임베드할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. 비디오 파일 데이터를 전달하여 [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 개체를 추가하고 프레젠테이션에 비디오를 임베드합니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 추가하여 비디오 프레임을 생성합니다.
1. 수정된 프레젠테이션을 저장합니다.

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

또는 비디오 파일 경로를 직접 [addVideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/#addVideoFrame) 메서드에 전달하여 비디오를 추가할 수 있습니다:

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

Microsoft [PowerPoint 2013 및 이후 버전](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인에 제공되는 경우(예: YouTube), 해당 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 얻습니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 추가하고 비디오 링크를 전달합니다.
1. 비디오 프레임의 썸네일을 설정합니다.
1. 프레젠테이션을 저장합니다.

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

Aspose.Slides에서는 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromEnd) 메서드를 통해 trim-from-start와 trim-from-end 값을 설정함으로써 재생되는 비디오 부분을 제어할 수 있습니다. 두 값은 밀리초 단위로 지정되며 각각 비디오 시작 부분과 끝 부분에서 건너뛸 시간을 정의합니다. 이러한 설정은 프레젠테이션의 비디오 재생 설정을 변경하지만 임베드된 비디오 바이너리 데이터를 잘라내거나 수정하지는 않습니다.

**트림 설정 지정**

비디오 프레임을 만들고 트림 설정을 지정하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. [Video](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/) 개체를 프레젠테이션에 추가합니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 슬라이드에 추가합니다.
1. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setTrimFromEnd) 메서드를 통해 trim-from-start와 trim-from-end 값을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

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

**트림 설정 읽기**

기존 트림 설정을 확인하려면 프레젠테이션을 로드하고, 첫 번째 슬라이드의 도형 중에서 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 찾아 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getTrimFromStart) 및 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getTrimFromEnd) 메서드를 통해 값을 읽습니다.

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

Aspose.Slides에서는 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 비디오를 추가합니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 슬라이드에 추가합니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#getCaptionTracks) 로 반환된 [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 을 사용하여 WebVTT 캡션 트랙을 추가합니다.
1. 수정된 프레젠테이션을 저장합니다.

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
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 찾습니다.
1. [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 에 있는 캡션 트랙을 반복합니다.
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

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

각 [Captions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체를 가져옵니다.
1. [CaptionsCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/) 에서 캡션 트랙을 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

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

하나의 캡션 트랙만 제거해야 하는 경우 [clear](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/ko/python-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

비디오를 슬라이드에 추가하는 것 외에도 Aspose.Slides에서는 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 모든 [Slide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/) 객체를 반복합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 객체를 반복하여 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 를 찾습니다.
4. 비디오를 디스크에 저장합니다.

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

**VideoFrame에 대해 변경 가능한 비디오 재생 매개변수는 무엇입니까?**

[playback mode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setPlayMode) (자동 또는 클릭)와 [looping](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setPlayLoopMode)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/) 개체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 훨씬 작습니다.

**위치와 크기를 변경하지 않고 기존 VideoFrame의 비디오를 교체할 수 있습니까?**

예. 프레임 내에서 [video content](https://reference.aspose.com/slides/ko/python-java/aspose.slides/videoframe/#setEmbeddedVideo)를 교체하면 도형의 기하학적 속성을 유지하면서 미디어를 업데이트할 수 있는 일반적인 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있습니까?**

예. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/ko/python-java/aspose.slides/video/#getContentType)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 활용할 수 있습니다.