---
title: C++를 사용한 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 슬라이드에 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 가이드."
---
## **소개**

비디오는 아이디어를 설명하고 청중을 참여시키는 데 도움이 될 수 있습니다. Aspose.Slides for C++를 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 포함된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube와 같은 온라인 비디오에 대한 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다.

## **내장 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 프레젠테이션에 비디오를 포함시키는 비디오 프레임을 만들 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 삽입하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. 스트림은 저장이 완료될 때까지 열려 있습니다. 이는 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/)이 프레젠테이션이 스트림을 사용하는 동안 잠금을 유지하기 때문입니다.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

또한 로컬 비디오 경로를 직접 [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/)에 전달할 수 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 삽입합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **웹 소스에서 비디오를 사용하여 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)은 프레젠테이션에 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 연결되는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하십시오. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) 메서드는 자동 재생을 요청합니다. 썸네일을 다운로드하고 비디오를 재생하려면 인터넷 연결이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 소프트웨어 시연을 전체 화면 모드로 재생하면 청중이 세부 사항을 볼 수 있습니다. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/)은 `true`를 받아 재생 중 이 동작을 활성화합니다.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)을 찾아 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 있어야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로 [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)은 자동 재생 또는 클릭 시 재생을 제어하고, [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/)은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)으로 설정하십시오. 예제는 기존 시작 및 반복 설정을 유지합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 처음 상태로 되돌리면 발표자가 다시 재생할 준비가 됩니다. 재생이 끝난 후 비디오를 처음으로 되돌리려면 `true`와 함께 [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/)를 호출하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)을 찾아 되감기를 활성화합니다. 순환을 비활성화하여 재생이 끝나도록 하고 클릭 시 재생하도록 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 있어야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

되감기는 비디오를 다시 시작하지 않고 처음으로 되돌립니다. 반대로 [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/)을 활성화하면 재생이 자동으로 반복됩니다. 비디오가 끝나고 다시 재생할 준비가 되도록 하려면 반복을 비활성화하십시오. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)은 자동 또는 클릭 시 시작을 별도로 제어합니다. 이 예제는 발표자가 재생 시작 시기를 제어할 수 있도록 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/)을 사용합니다. 루프 설정 후에 재생 모드를 설정하십시오(예제 참조). 되감기는 [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/)와 독립적으로 작동합니다.

## **비디오 프레임 자르기**

재생 중 비디오의 시작 부분이나 끝 부분을 건너뛰려면 [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/)와 [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/)를 사용하십시오. 두 값은 밀리초 단위이며, 트리밍은 포함된 비디오 데이터를 수정하지 않고 재생 설정만 변경합니다.

**Trim 설정 지정**

이 예제는 로컬 비디오를 삽입하고 재생 중 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 비디오 길이는 3.5초보다 길어야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Trim 설정 읽기**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 비디오 프레임의 트리밍 값을 밀리초 단위로 출력합니다. 프레젠테이션에는 최소 한 개의 슬라이드가 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 출력되지 않습니다. 앞 예제는 2500과 1000 값을 생성합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 삽입하고 English 라벨이 지정된 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드에 있는 비디오 프레임의 모든 캡션 트랙을 별도의 WebVTT 파일로 저장합니다. 순차 번호를 사용해 출력 파일을 구분합니다. 콘솔은 추출된 트랙 수를 보고합니다. 프레젠테이션에는 최소 한 개의 슬라이드가 있어야 합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

각 [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) 객체는 캡션 식별자, 라벨, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 도형 위치의 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 도형이 존재하고 도형이 비디오 프레임이라고 가정합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

하나의 캡션 트랙만 제거하려면 [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) 대신 [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) 또는 [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 포함된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 포함된 비디오를 별도의 번호가 매겨진 바이너리 파일로 추출합니다. 링크된 비디오는 포함된 데이터가 없으므로 건너뜁니다. 콘솔은 각 비디오의 MIME 유형과 총 개수를 출력합니다. 출력 파일은 일반적인 `.bin` 확장자를 사용하며, 필요에 따라 보고된 미디어 유형에 맞게 변경하십시오.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**비디오 프레임에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇인가요?**

[playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (자동 또는 클릭)과 [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) 객체의 메서드를 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 삽입하면 바이너리 데이터가 문서에 포함되어 파일 크기가 비디오 파일 크기만큼 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리보기 이미지가 저장되므로 일반적으로 크기 증가가 적습니다.

**기존 비디오 프레임의 위치와 크기를 변경하지 않고 비디오를 교체할 수 있나요?**

예. 프레임 내의 [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/)를 교체하면 도형의 기하학적 특성을 유지하면서 미디어를 업데이트할 수 있습니다. 이는 레이아웃을 유지해야 할 때 흔히 사용되는 시나리오입니다.

**포함된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 포함된 비디오는 [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 활용할 수 있습니다.