---
title: C++를 사용한 프레젠테이션의 비디오 프레임 관리
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
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 방법 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다.  

PowerPoint는 프레젠테이션 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오를 추가하거나 삽입하기(컴퓨터에 저장된 비디오)
* 온라인 비디오 추가(예: YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다. 

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있으면 비디오 프레임을 만들어 프레젠테이션에 비디오를 임베드할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideo/) 객체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.  
1. 비디오 프레임을 만들기 위해 [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 C++ 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

또는 비디오 파일 경로를 직접 [AddVideoFrame()](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishapecollection/addvideoframe/) 메서드에 전달하여 비디오를 추가할 수도 있습니다:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **웹 소스 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint 2013 및 이후 버전](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인(예: YouTube)에 있다면 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideo/) 객체를 추가하고 비디오 링크를 전달합니다.  
1. 비디오 프레임의 썸네일을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 C++ 코드는 웹에서 비디오를 가져와 PowerPoint 슬라이드에 추가하는 방법을 보여줍니다:

```c++
// 문서 디렉터리의 경로.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 첫 번째 슬라이드에 접근합니다.
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 비디오 프레임을 추가합니다.
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 비디오의 재생 모드와 볼륨을 설정합니다.
vf->set_PlayMode(VideoPlayModePreset::Auto);

//프레젠테이션을 디스크에 저장합니다.
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 클로즈드 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/get_captiontracks/) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 프레젠테이션에 비디오를 추가합니다.  
1. 슬라이드에 [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/get_captiontracks/)이 반환하는 [ICaptionsCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/)을 사용해 WebVTT 캡션 트랙을 추가합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 객체를 찾습니다.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/get_captiontracks/)이 반환하는 캡션 트랙을 순회합니다.  
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
            // 캡션 트랙을 WebVTT 파일에 저장합니다.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

각 [ICaptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 캡션 데이터를 UTF-8 문자열로 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/) 객체를 가져옵니다.  
1. [get_CaptionTracks](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ivideoframe/get_captiontracks/)이 반환하는 컬렉션에서 캡션 트랙을 제거합니다.  
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

하나의 캡션 트랙만 제거하려면 [Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/clear/) 대신 [Remove](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/remove/) 또는 [RemoveAt](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icaptionscollection/removeat/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하려면 [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 모든 [ISlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islide/) 객체를 순회합니다.  
3. 모든 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 객체를 순회하여 [VideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/)을 찾습니다.  
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

**VideoFrame에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇인가요?**  
재생 모드(자동 또는 클릭 시)와 [루핑](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/set_playloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.  

**비디오를 추가하면 PPTX 파일 크기에 영향을 미칩니까?**  
예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 적습니다.  

**기존 VideoFrame의 위치와 크기를 변경하지 않고 비디오를 교체할 수 있나요?**  
예. 프레임 내부의 [비디오 내용](https://reference.aspose.com/slides/ko/cpp/aspose.slides/videoframe/set_embeddedvideo/)을 교체하면서 도형의 크기와 위치를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 흔히 사용되는 시나리오입니다.  

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**  
예. 임베드된 비디오는 [콘텐츠 유형](https://reference.aspose.com/slides/ko/cpp/aspose.slides/video/get_contenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 등 다양하게 활용할 수 있습니다.