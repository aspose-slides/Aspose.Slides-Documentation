---
title: .NET에서 프레젠테이션의 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/net/video-frame/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배우세요. 빠른 사용 방법 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오를 추가하거나 삽입(머신에 저장된 비디오)
* 온라인 비디오 추가(YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 타입을 제공합니다. 

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있다면, 프레젠테이션에 비디오를 임베드하기 위해 비디오 프레임을 만들 수 있습니다. 

1. 프레젠테이션 [Presentation ](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideo/) 객체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.  
1. [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/) 객체를 추가하여 비디오 프레임을 생성합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 C# 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```c#
// Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("pres.pptx"))
{
    // 비디오를 로드합니다
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // 프레젠테이션을 디스크에 저장합니다
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
또는 파일 경로를 직접 [AddVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/addvideoframe/) 메서드에 전달하여 비디오를 추가할 수 있습니다:

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **웹 소스 비디오로 비디오 프레임 만들기**
Microsoft [PowerPoint 2013 및 이후 버전](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인(예: YouTube)에서 사용할 수 있다면, 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다. 

1. 프레젠테이션 [Presentation ](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideo/) 객체를 추가하고 비디오 링크를 전달합니다.  
1. 비디오 프레임의 썸네일을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 C# 코드는 웹에서 비디오를 가져와 PowerPoint 슬라이드에 추가하는 방법을 보여줍니다:

```c#
public static void Run()
{
    // 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // VideoFrame을 추가합니다
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // 썸네일을 로드합니다
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **비디오 캡션 관리**

Aspose.Slides는 PowerPoint 프레젠테이션에서 비디오 프레임의 폐쇄 캡션을 관리할 수 있도록 합니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/captiontracks/) 속성을 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. 프레젠테이션 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 프레젠테이션에 비디오를 추가합니다.  
1. 슬라이드에 [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. [CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/captiontracks/) 컬렉션을 사용하여 WebVTT 캡션 트랙을 추가합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/) 객체를 찾습니다.  
1. [CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/captiontracks/) 컬렉션을 순회합니다.  
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.  

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // 캡션 트랙을 WebVTT 파일로 저장합니다.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

각 [ICaptions](https://reference.aspose.com/slides/ko/net/aspose.slides/icaptions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/) 객체를 가져옵니다.  
1. [CaptionTracks](https://reference.aspose.com/slides/ko/net/aspose.slides/ivideoframe/captiontracks/) 컬렉션에서 캡션 트랙을 제거합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여줍니다:

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // 비디오 프레임에서 모든 캡션을 제거합니다.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

하나의 캡션 트랙만 제거해야 하는 경우, [Clear](https://reference.aspose.com/slides/ko/net/aspose.slides/captionscollection/clear/) 대신 [Remove](https://reference.aspose.com/slides/ko/net/aspose.slides/captionscollection/remove/) 또는 [RemoveAt](https://reference.aspose.com/slides/ko/net/aspose.slides/captionscollection/removeat/) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도, Aspose.Slides는 프레젠테이션에 임베드된 비디오를 추출할 수 있도록 합니다.

1. 비디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.  
2. 모든 [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide) 객체를 순회합니다.  
3. 모든 [IShape](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape) 객체를 순회하여 [VideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/videoframe)을 찾습니다.  
4. 비디오를 디스크에 저장합니다.  

다음 C# 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 
Presentation presentation = new Presentation("Video.pptx");

// 슬라이드를 순회합니다
foreach (ISlide slide in presentation.Slides)
{
    // 모양들을 순회합니다
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // 비디오를 포함하는 VideoFrame을 찾으면 비디오를 디스크에 저장합니다
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **자주 묻는 질문**

**VideoFrame의 재생 매개변수 중 어떤 것을 변경할 수 있나요?**

[재생 모드](https://reference.aspose.com/slides/ko/net/aspose.slides/videoframe/playmode/)(자동 또는 클릭 시)와 [반복 재생](https://reference.aspose.com/slides/ko/net/aspose.slides/videoframe/playloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 훨씬 작습니다.

**기존 VideoFrame의 위치와 크기를 변경하지 않고 비디오를 교체할 수 있나요?**

예. 프레임 내부의 [비디오 콘텐츠](https://reference.aspose.com/slides/ko/net/aspose.slides/videoframe/embeddedvideo/)를 교체하면서 형태의 기하학적 속성을 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 임베드된 비디오는 [콘텐츠 유형](https://reference.aspose.com/slides/ko/net/aspose.slides/video/contenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 등 다양한 용도로 사용할 수 있습니다.