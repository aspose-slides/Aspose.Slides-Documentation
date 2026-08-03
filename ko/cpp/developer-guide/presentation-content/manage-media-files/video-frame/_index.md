---
title: C++를 사용한 프레젠테이션 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다.

PowerPoint에서는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:
* 로컬 비디오 추가 또는 포함(컴퓨터에 저장된 비디오)
* 온라인 비디오 추가(YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다.

## **임베디드 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 프레젠테이션에 비디오를 임베드하기 위한 비디오 프레임을 만들 수 있습니다.

1. [Presentation ] 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
1. [IVideo] 객체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.
1. [IVideoFrame] 객체를 추가하여 비디오용 프레임을 생성합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 C++ 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// 비디오를 로드합니다
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// 프레젠테이션을 디스크에 저장합니다
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

또는 비디오 파일 경로를 직접 [AddVideoFrame()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addvideoframe/) 메서드에 전달하여 비디오를 추가할 수도 있습니다:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **웹 소스에서 비디오를 사용한 비디오 프레임 만들기**

Microsoft 최신 버전의 [PowerPoint]은 프레젠테이션에서 온라인 비디오를 지원합니다. 사용하려는 비디오가 온라인에 존재한다면(예: YouTube), 해당 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다.

1. [Presentation ] 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
1. [IVideo] 객체를 추가하고 비디오 링크를 전달합니다.
1. 비디오 프레임의 썸네일을 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 C++ 코드는 웹에서 비디오를 가져와 PowerPoint 프레젠테이션의 슬라이드에 추가하는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 비디오 프레임을 추가합니다 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 비디오의 재생 모드와 볼륨을 설정합니다
vf->set_PlayMode(VideoPlayModePreset::Auto);

//프레젠테이션을 디스크에 저장합니다
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **비디오 프레임 자르기**

Aspose.Slides를 사용하면 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/set_trimfromstart/) 및 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/set_trimfromend/) 메서드로 trim-from-start 및 trim-from-end 값을 설정하여 비디오 재생 부분을 제어할 수 있습니다. 두 값은 밀리초 단위로 지정되며 각각 비디오의 시작과 끝에서 건너뛰는 시간을 정의합니다. 이러한 설정은 프레젠테이션의 비디오 재생 설정을 변경하지만, 임베드된 비디오 바이너리 데이터를 잘라내거나 수정하지는 않습니다.

**Trim 설정 지정**

비디오 프레임을 만들고 Trim 설정을 지정하려면:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 [IVideo] 객체를 추가합니다.
1. 슬라이드에 [IVideoFrame] 객체를 추가합니다.
1. [IVideoFrame::set_TrimFromStart] 및 [IVideoFrame::set_TrimFromEnd]를 통해 trim-from-start 및 trim-from-end 값을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드 예제는 재생 중에 임베드된 비디오의 처음 2.5초와 마지막 1초를 건너뛰도록 설정합니다:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Trim 설정 읽기**

기존의 Trim 설정을 확인하려면 프레젠테이션을 로드하고, 첫 번째 슬라이드의 도형 중에서 [IVideoFrame] 객체를 찾은 뒤, [IVideoFrame::get_TrimFromStart] 및 [IVideoFrame::get_TrimFromEnd]를 통해 값을 읽어야 합니다.

다음 코드 예제는 첫 번째 슬라이드에서 첫 번째 비디오 프레임을 찾아 밀리초 단위의 Trim 설정을 보고합니다:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame::get_CaptionTracks] 메서드를 통해 접근할 수 있습니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 비디오를 추가합니다.
1. 슬라이드에 [IVideoFrame] 객체를 추가합니다.
1. [get_CaptionTracks]가 반환하는 [ICaptionsCollection]을 사용하여 WebVTT 캡션 트랙을 추가합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection] 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [IVideoFrame] 객체를 찾습니다.
1. [get_CaptionTracks]가 반환한 캡션 트랙을 반복합니다.
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // 캡션 트랙을 WebVTT 파일로 저장합니다.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

각 [ICaptions] 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 캡션 데이터를 UTF-8 문자열로 제공합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [IVideoFrame] 객체를 가져옵니다.
1. [get_CaptionTracks]가 반환하는 컬렉션에서 캡션 트랙을 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// 비디오 프레임에서 모든 캡션을 제거합니다.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

하나의 캡션 트랙만 제거해야 하는 경우, [Clear] 대신 [Remove] 또는 [RemoveAt] 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도, Aspose.Slides는 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation] 클래스의 인스턴스를 생성합니다.
2. 모든 [ISlide] 객체를 반복합니다.
3. 모든 [IShape] 객체를 반복하여 [VideoFrame]을 찾습니다.
4. 비디오를 디스크에 저장합니다.

다음 C++ 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```c++
// 문서 디렉터리 경로.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**VideoFrame에서 변경 가능한 비디오 재생 매개변수는 무엇입니까?**

You can control the [재생 모드](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/set_playmode/) (auto or on click) and [반복 재생](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/set_playloopmode/). These options are available via the [VideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/) object's properties.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일이 임베드되므로 크기 증가가 더 작습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내의 [비디오 콘텐츠](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/set_embeddedvideo/)를 교체하면서 도형의 위치와 크기를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 임베드된 비디오는 [콘텐츠 타입](https://reference.aspose.com/slides/ko/cpp/aspose.slides/video/get_contenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 등 활용할 수 있습니다.