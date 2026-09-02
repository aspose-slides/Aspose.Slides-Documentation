---
title: Python에서 프레젠테이션에 비디오 추가
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/python-net/video-frame/
keywords:
- 비디오 추가
- 비디오 생성
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 실무 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint는 프레젠테이션 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오 추가 또는 삽입(컴퓨터에 저장된 비디오)
* 온라인 비디오 추가(YouTube와 같은 웹 소스에서).

비디오(비디오 객체)를 프레젠테이션에 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/python-net/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 클래스 및 기타 관련 형식을 제공합니다. 

## **내장 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 비디오 프레임을 만들어 프레젠테이션에 비디오를 삽입할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. [Video](https://reference.aspose.com/slides/ko/python-net/aspose.slides/video/) 객체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 삽입합니다. 
1. 비디오용 프레임을 만들기 위해 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 추가합니다.  
1. 변경된 프레젠테이션을 저장합니다. 

다음 Python 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation(path + "pres.pptx") as pres:
    with open("Wildlife.mp4", "br") as fileStream:
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)

        # 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
        pres.slides[0].shapes.add_video_frame(10, 10, 150, 250, video)

        # 프레젠테이션을 디스크에 저장합니다
        pres.save(path + "pres-with-video.pptx", slides.export.SaveFormat.PPTX)
```

또는 파일 경로를 `add_video_frame(x, y, width, height, fname)` 메서드에 직접 전달하여 비디오를 추가할 수 있습니다:

``` python
import aspose.slides as slides

with slides.Presentation() as pres:
    sld = pres.slides[0]
    vf = sld.shapes.add_video_frame(50, 150, 300, 150, "video1.avi")
```


## **웹 소스 비디오를 사용한 비디오 프레임 만들기**

새 버전의 Microsoft [PowerPoint](https://support.microsoft.com/en-us/office/insert-a-video-from-youtube-or-another-site-8340ec69-4cee-4fe1-ab96-4849154bc6db) 은 프레젠테이션에서 온라인 비디오를 지원합니다. 사용하려는 비디오가 온라인에 존재한다면(예: YouTube) 해당 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. [Video](https://reference.aspose.com/slides/ko/python-net/aspose.slides/video/) 객체를 추가하고 비디오 링크를 전달합니다.
1. 비디오 프레임의 썸네일을 설정합니다. 
1. 프레젠테이션을 저장합니다. 

다음 Python 코드는 웹에서 비디오를 가져와 PowerPoint 슬라이드에 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides
from urllib.request import urlopen

def add_video_from_youyube(pres, videoId):
    # 비디오 프레임을 추가합니다
    videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId)
    videoFrame.play_mode = slides.VideoPlayModePreset.AUTO

    # 썸네일을 로드합니다
    thumbnail_uri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg"
    f = urlopen(thumbnail_uri)
    videoFrame.picture_format.picture.image = pres.images.add_image(f.read())


with slides.Presentation() as pres:
    add_video_from_youyube(pres, "s5JbfQZ5Cc0")
    pres.save("AddVideoFrameFromWebSource_out.pptx", slides.export.SaveFormat.PPTX)
```

## **비디오 프레임 트리밍**

Aspose.Slides는 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_start/) 및 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_end/) 을 통해 시작부터와 끝부터 트림 값을 설정함으로써 재생되는 비디오 구간을 제어할 수 있게 합니다. 두 값은 밀리초 단위로 지정되며 각각 비디오 시작 부분과 종료 부분에서 건너뛸 시간을 정의합니다. 이러한 설정은 프레젠테이션의 비디오 재생 동작을 변경하지만, 삽입된 비디오 바이너리 데이터를 절단하거나 수정하지는 않습니다.

**트림 설정 지정**

비디오 프레임을 만들고 트림 설정을 지정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 [Video](https://reference.aspose.com/slides/ko/python-net/aspose.slides/video/) 객체를 추가합니다.
1. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 추가합니다.
1. [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_start/) 및 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_end/) 을 통해 시작/끝 트림 값을 설정합니다.
1. 변경된 프레젠테이션을 저장합니다.

다음 코드 예제는 삽입된 비디오 재생 시 처음 2.5초와 마지막 1초를 건너뛰도록 합니다:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)

    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**트림 설정 읽기**

기존 트림 설정을 확인하려면 프레젠테이션을 로드하고, 첫 번째 슬라이드의 도형 중 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 찾아 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_start/) 및 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/trim_from_end/) 값을 읽어보세요.

다음 코드 예제는 첫 번째 슬라이드에서 첫 번째 비디오 프레임을 찾아 트림 설정을 밀리초 단위로 보고합니다:

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            video_frame = shape
            trim_from_start = video_frame.trim_from_start
            trim_from_end = video_frame.trim_from_end

            print(f"Trim from start: {trim_from_start} ms")
            print(f"Trim from end: {trim_from_end} ms")
            break
```

## **비디오 캡션 관리**

Aspose.Slides는 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있게 합니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/caption_tracks/) 속성을 통해 접근할 수 있습니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 비디오를 추가합니다.
1. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 추가합니다.
1. [caption_tracks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/caption_tracks/) 이 반환하는 [CaptionsCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/) 을 사용해 WebVTT 캡션 트랙을 추가합니다.
1. 변경된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()

    video = presentation.videos.add_video(video_data)

    slide = presentation.slides[0]
    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)

    # WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 찾습니다.
1. [caption_tracks](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/caption_tracks/) 컬렉션을 반복합니다.
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                # 캡션 트랙을 WebVTT 파일로 저장합니다.
                file_path = f"{caption_track.caption_id}.vtt"
                with open(file_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))
```

각 [Captions](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체를 가져옵니다.
1. [CaptionsCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/) 에서 캡션 트랙을 제거합니다.
1. 변경된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    video_frame = slide.shapes[0]  # 타입: slides.VideoFrame

    # 비디오 프레임에서 모든 캡션을 제거합니다.
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/clear/) 대신 [remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/remove/) 혹은 [remove_at](https://reference.aspose.com/slides/ko/python-net/aspose.slides/captionscollection/remove_at/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides는 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하려면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 
2. 모든 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 객체를 반복합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 객체를 검사하여 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 을 찾습니다. 
4. 비디오를 디스크에 저장합니다.

다음 Python 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
with slides.Presentation(path + "Video.pptx") as presentation:
    for shape in presentation.slides[0].shapes:
        if type(shape) is slides.VideoFrame:
            type = shape.embedded_video.content_type
            buffer = shape.embedded_video.binary_data
            with open("NewVideo_out." + type[type.rfind('/') + 1:len(type)], "wb") as stream:
                stream.write(buffer)
```

## **FAQ**

**VideoFrame에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇인가요?**

[playback mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/play_mode/) (자동 또는 클릭) 및 [looping](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/play_loop_mode/) 을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 삽입하면 이진 데이터가 문서에 포함되어 파일 크기만큼 프레젠테이션 용량이 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 삽입되므로 크기 증가가 훨씬 작습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내의 [video content](https://reference.aspose.com/slides/ko/python-net/aspose.slides/videoframe/embedded_video/) 를 교체하면서 도형의 기하 정보를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 일반적인 시나리오입니다.

**내장 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 내장 비디오는 [content type](https://reference.aspose.com/slides/ko/python-net/aspose.slides/video/content_type/) 을 가지고 있으며 이를 읽어 디스크에 저장하는 등 다양한 용도로 사용할 수 있습니다.