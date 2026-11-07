---
title: ".NET에서 프레젠테이션 비디오 프레임 관리"
linktitle: "비디오 프레임"
type: docs
weight: 10
url: /ko/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배우세요. 빠른 사용 방법 가이드."
---
## **소개**

동영상은 아이디어를 설명하고 청중을 참여시키는 데 도움이 될 수 있습니다. Aspose.Slides for .NET을 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 삽입된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube 비디오와 같은 온라인 비디오 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 프레젠테이션에 비디오를 삽입하기 위한 비디오 프레임을 만들 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 삽입하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. 스트림은 저장이 완료될 때까지 열려 있으며, 이는 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/)이 프레젠테이션이 사용할 때 스트림을 잠금 상태로 유지하기 때문입니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

[AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/)에 로컬 비디오 경로를 직접 전달할 수도 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 삽입합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **비디오 볼륨 정확하게 설정하기**

Aspose.Slides for .NET 26.11 이상에서는 [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/)가 0부터 100까지의 부동 소수점 백분율을 설정합니다. [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) 사전 설정이 너무 거친 경우에 사용하십시오. 예를 들어 `75.5f`는 75.5% 볼륨을 요청합니다.

이 예제는 [Aspose.Slides for .NET](/slides/ko/net/installation/) 26.11 이상과 로컬 `video.mp4`가 필요합니다. 비디오를 삽입하고, 재생을 명시적으로 초기화한 뒤, 프레젠테이션을 저장하고 저장된 백분율을 다시 읽습니다.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

입력을 직접 검증하십시오; 설정자가 문서화된 범위를 벗어나는 값을 거부한다는 것에 의존하지 마세요. Low, Medium, Loud 사전 설정은 26.11에서 각각 20, 50, 80에 해당합니다. 사전 설정을 적용하면 이전 백분율이 대체될 수 있으므로 정확한 값을 필요로 할 때는 백분율을 마지막에 할당하세요. 명시적인 음소거 설정을 위해서는 [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/)를 사용하십시오; 숫자 0과 사전 설정 열거형은 서로 교환 가능한 상태가 아닙니다.

링크된 비디오를 구성할 때도 [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/)을 명시적으로 설정하고, 미디어 파일을 시청자가 사용할 수 있도록 유지하십시오. 저장 후 다시 열면 저장된 설정이 확인됩니다; 실제 재생 및 음량은 프레젠테이션 플레이어와 그 오디오 설정에 따라 달라집니다.

## **웹 소스 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)는 프레젠테이션에서 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 링크되는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하십시오. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) 설정은 자동 재생을 요청합니다. 썸네일 다운로드와 비디오 재생에는 인터넷 접근이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 소프트웨어 시연을 전체 화면 모드로 재생하면 청중이 세부 사항을 볼 수 있습니다. 재생 중에 이 동작을 활성화하려면 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)을 `true`로 설정하십시오.

이 예제는 프레젠테이션을 열고 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)을 찾아 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)은 자동 시작인지 클릭 시작인지를 제어하고, [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset.Auto 또는 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)으로 설정하십시오. 이 예제는 기존 시작 및 반복 설정을 유지합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 처음으로 되돌리면 발표자가 다시 재생할 수 있습니다. 재생이 끝난 후 비디오를 처음으로 되돌리려면 [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/)을 `true`로 설정하십시오.

이 예제는 프레젠테이션을 열고 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/)을 찾아 되감기를 활성화합니다. 루프를 비활성화하여 재생이 끝날 수 있게 하고, 클릭 시 시작하도록 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

되감기는 비디오를 다시 시작하지 않고 처음으로 되돌립니다. 반면에 [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)을 활성화하면 재생이 자동으로 반복됩니다. 비디오가 끝나고 다시 재생할 준비가 되도록 하려면 루프를 비활성화하십시오. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/)은 자동 시작 또는 클릭 시작을 독립적으로 제어합니다; 이 예제는 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/)을 사용하여 발표자가 재생 시작 시점을 제어합니다. 예제와 같이 루프 설정 후에 재생 모드를 설정하십시오. 되감기는 [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/)와 독립적으로 작동합니다.

## **비디오 프레임 트림**

[IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/)와 [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/)을 사용하면 재생 중 비디오의 시작이나 끝 부분을 건너뛸 수 있습니다. 두 값은 밀리초 단위입니다. 트림은 삽입된 비디오 데이터를 변경하지 않고 재생 설정만 변경합니다.

**트림 설정 지정**

이 예제는 로컬 비디오를 삽입하고 재생 중 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 3.5초보다 긴 비디오를 사용하십시오.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**트림 설정 읽기**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 비디오 프레임의 트림 값을 밀리초 단위로 출력합니다. 프레젠테이션には 최소 하나의 슬라이드가 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 아무 것도 출력되지 않습니다. 앞 예제는 2500과 1000 값을 생성합니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/) 속성을 통해 제공됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 삽입하고 영어 라벨이 붙은 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

[ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드의 비디오 프레임에서 모든 캡션 트랙을 별개의 WebVTT 파일로 저장합니다. 연속 번호를 사용해 출력 파일을 구분합니다. 콘솔은 추출된 트랙 수를 보고합니다. 프레젠테이션에는 최소 하나의 슬라이드가 있어야 합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

각 [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) 객체는 캡션 식별자, 라벨, 바이너리 데이터 및 UTF-8 문자열로 된 캡션 텍스트를 제공합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드의 첫 번째 도형 위치에 있는 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 도형이 존재하고 도형이 비디오 프레임이라고 가정합니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

하나의 캡션 트랙만 제거하려면 [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/) 대신 [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) 또는 [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 삽입된 비디오를 별도의 번호가 매겨진 바이너리 파일로 추출합니다. 링크된 비디오는 삽입된 데이터가 없기 때문에 건너뜁니다. 콘솔은 각 비디오의 MIME 유형과 전체 개수를 출력합니다. 출력 파일은 일반적인 `.bin` 확장자를 사용하며, 필요에 따라 보고된 미디어 유형에 맞게 변경하십시오.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**비디오 프레임에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇입니까?**

재생 모드(자동 또는 클릭)와 반복을 [playback mode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) 및 [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/)으로 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 삽입하면 바이너리 데이터가 문서에 포함되어 프레젠테이션 크기가 파일 크기에 비례해 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리보기 이미지가 저장되므로 일반적으로 크기 증가가 더 작습니다.

**기존 비디오 프레임의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있습니까?**

예. 프레임 내의 [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/)를 교체하면서 도형의 형상을 유지할 수 있습니다; 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**삽입된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있습니까?**

예. 삽입된 비디오는 [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/)을 가지고 있으며 이를 읽어 디스크에 저장하는 등 사용할 수 있습니다.