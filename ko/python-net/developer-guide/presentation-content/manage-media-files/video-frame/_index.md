---
title: Python에서 프레젠테이션의 비디오 프레임 관리
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
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 가이드."
---
## **소개**

동영상은 아이디어를 설명하고 청중을 끌어들이는 데 도움이 될 수 있습니다. Aspose.Slides for Python via .NET을 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 포함된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube 비디오와 같은 온라인 비디오 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해, Aspose.Slides는 [Video](https://reference.aspose.com/slides/python-net/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 생성**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장된 경우, 프레젠테이션에 비디오를 임베드하기 위해 비디오 프레임을 생성할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 임베드하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. 스트림은 저장이 완료될 때까지 열려 있도록 유지되며, 이는 [LoadingStreamBehavior.KEEP_LOCKED](https://reference.aspose.com/slides/python-net/aspose.slides/loadingstreambehavior/)이 프레젠테이션이 사용할 때 잠금을 유지하기 때문입니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(video_stream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        slide.shapes.add_video_frame(10, 10, 150, 250, video)

        presentation.save("embedded_video.pptx", slides.export.SaveFormat.PPTX)
```

또한 로컬 비디오 경로를 [add_video_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_video_frame/)에 직접 전달할 수 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 임베드합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_video_frame(50, 150, 300, 150, "video.avi")

    presentation.save("video_from_path.pptx", slides.export.SaveFormat.PPTX)
```

## **웹 소스 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)은 프레젠테이션에서 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 연결되는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하세요. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/) 설정은 자동 재생을 요청합니다. 썸네일을 다운로드하고 비디오를 재생하려면 인터넷 접속이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```python
from urllib.request import urlopen
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    video_id = "aqz-KE-bpKQ"
    video_url = f"https://www.youtube.com/embed/{video_id}"
    video_frame = slide.shapes.add_video_frame(10, 10, 427, 240, video_url)
    video_frame.play_mode = slides.VideoPlayModePreset.AUTO

    thumbnail_url = f"https://img.youtube.com/vi/{video_id}/hqdefault.jpg"
    with urlopen(thumbnail_url) as response:
        thumbnail_data = response.read()
    thumbnail = presentation.images.add_image(thumbnail_data)
    video_frame.picture_format.picture.image = thumbnail

    presentation.save("online_video.pptx", slides.export.SaveFormat.PPTX)
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 청중이 세부 정보를 볼 수 있도록 전체 화면 모드로 소프트웨어 시연을 재생할 수 있습니다. 재생 중에 이 동작을 활성화하려면 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/)을 `True`로 설정하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)을 찾아 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 포함된 슬라이드가 최소 하나 있어야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.full_screen_mode = True
            break

    presentation.save("full_screen_video.pptx", slides.export.SaveFormat.PPTX)
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로, [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)은 자동 시작 여부 또는 클릭 시 시작 여부를 제어하고, [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset.AUTO or VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)으로 설정하십시오. 예제는 기존 시작 및 반복 설정을 유지합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 처음으로 되돌리면 발표자가 다시 재생할 준비가 됩니다. 재생이 끝난 후 비디오를 처음으로 되돌리려면 [rewind_video](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/rewind_video/)을 `True`로 설정하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/)을 찾아 되감기를 활성화합니다. 반복을 비활성화하여 재생이 끝날 수 있게 하고, 클릭 시 재생이 시작되도록 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 포함된 슬라이드가 최소 하나 있어야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("training.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            shape.rewind_video = True
            shape.play_loop_mode = False
            shape.play_mode = slides.VideoPlayModePreset.ON_CLICK
            break

    presentation.save("rewind_video.pptx", slides.export.SaveFormat.PPTX)
```

되감기는 비디오를 다시 시작하지 않고 처음으로 되돌립니다. 반면에 [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)을 활성화하면 재생이 자동으로 반복됩니다. 비디오가 끝나고 다시 재생할 준비가 되도록 하려면 반복을 비활성화하십시오. [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/)은 자동 또는 클릭 시 시작을 독립적으로 제어합니다; 이 예제는 [VideoPlayModePreset.ON_CLICK](https://reference.aspose.com/slides/python-net/aspose.slides/videoplaymodepreset/)을 사용하여 발표자가 재생 시작 시점을 제어하도록 합니다. 예제와 같이 루프 설정 후에 재생 모드를 설정하십시오. 되감기는 [full_screen_mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/full_screen_mode/)와 독립적으로 작동합니다.

## **비디오 프레임 잘라내기**

재생 중에 비디오의 시작 부분이나 끝 부분을 건너뛰려면 [VideoFrame.trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_start/) 및 [VideoFrame.trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/trim_from_end/)을 사용하십시오. 두 값은 밀리초 단위입니다. 잘라내기는 포함된 비디오 데이터를 수정하지 않고 재생 설정을 변경합니다.

**잘라내기 설정 지정**

이 예제는 로컬 비디오를 임베드하고 재생 중에 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 3.5초보다 긴 비디오를 사용하십시오.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(50, 50, 640, 360, video)
    video_frame.trim_from_start = 2500.0
    video_frame.trim_from_end = 1000.0

    presentation.save("video_with_trim.pptx", slides.export.SaveFormat.PPTX)
```

**잘라내기 설정 읽기**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 비디오 프레임의 잘라내기 값을 밀리초 단위로 출력합니다. 프레젠테이션에는 최소 하나의 슬라이드가 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 아무 것도 출력되지 않습니다. 이전 예제는 2500과 1000 값을 생성합니다.

```python
import aspose.slides as slides

with slides.Presentation("video_with_trim.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            print(f"Trim from start: {shape.trim_from_start} ms")
            print(f"Trim from end: {shape.trim_from_end} ms")
            break
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/caption_tracks/) 속성을 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 임베드하고 'English' 라벨이 붙은 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.mp4", "rb") as video_stream:
        video_data = video_stream.read()
    video = presentation.videos.add_video(video_data)

    video_frame = slide.shapes.add_video_frame(0, 0, 100, 100, video)
    video_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("video_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

[CaptionsCollection](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드의 비디오 프레임에서 모든 캡션 트랙을 별개의 WebVTT 파일로 저장합니다. 순차 번호를 사용해 출력 파일을 구분합니다. 콘솔은 추출된 트랙 수를 보고합니다. 프레젠테이션에는 최소 하나의 슬라이드가 있어야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    track_count = 0
    for shape in slide.shapes:
        if isinstance(shape, slides.VideoFrame):
            for caption_track in shape.caption_tracks:
                track_count += 1
                output_path = f"captions_{track_count}.vtt"
                with open(output_path, "wb") as track_stream:
                    track_stream.write(bytes(caption_track.binary_data))

    print(f"Caption tracks extracted: {track_count}")
```

각 [Captions](https://reference.aspose.com/slides/python-net/aspose.slides/captions/) 객체는 캡션 식별자, 라벨, 바이너리 데이터 및 캡션 텍스트(UTF-8 문자열)를 노출합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드의 첫 번째 도형 위치에 있는 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 도형이 존재하고 해당 도형이 비디오 프레임이라고 가정합니다.

```python
import aspose.slides as slides

with slides.Presentation("video_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    
    video_frame = slide.shapes[0]
    video_frame.caption_tracks.clear()

    presentation.save("video_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) 대신 [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) 또는 [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

비디오를 슬라이드에 추가하는 것 외에도, Aspose.Slides를 사용하면 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 임베드된 비디오를 별개의 번호가 매겨진 바이너리 파일로 추출합니다. 링크된 비디오는 임베드된 데이터가 없으므로 건너뜁니다. 콘솔은 각 비디오의 MIME 유형과 총 개수를 출력합니다. 출력 파일은 일반적인 `.bin` 확장자를 사용하며, 필요에 따라 보고된 미디어 유형에 맞게 변경하십시오.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_videos.pptx") as presentation:
    video_count = 0
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.VideoFrame):
                video = shape.embedded_video
                if video is None:
                    print("Skipped a linked video: no embedded data is available.")
                    continue

                video_count += 1
                output_path = f"extracted_video_{video_count}.bin"
                with open(output_path, "wb") as video_stream:
                    video_stream.write(bytes(video.binary_data))
                print(f"Video {video_count}: {video.content_type}")

    print(f"Embedded videos extracted: {video_count}")
```

## **FAQ**

**비디오 프레임에 대해 어떤 재생 매개변수를 변경할 수 있나요?**

재생 모드([playback mode](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_mode/))(자동 또는 클릭)와 [looping](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/play_loop_mode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 미치나요?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크비에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리보기 이미지가 저장되므로 크기 증가가 보통 작습니다.

**기존 비디오 프레임의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내부의 [video content](https://reference.aspose.com/slides/python-net/aspose.slides/videoframe/embedded_video/)를 교체하면서 도형의 형상을 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 흔히 사용하는 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/python-net/aspose.slides/video/content_type/)을 가지고 있으며, 이를 읽어 디스크에 저장하는 등 활용할 수 있습니다.