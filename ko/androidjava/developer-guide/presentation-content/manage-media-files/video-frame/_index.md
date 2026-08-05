---
title: "Android에서 프레젠테이션의 비디오 프레임 관리"
linktitle: "비디오 프레임"
type: docs
weight: 10
url: /ko/androidjava/video-frame/
keywords:
- "비디오 추가"
- "비디오 생성"
- "비디오 임베드"
- "비디오 추출"
- "비디오 검색"
- "비디오 프레임"
- "웹 소스"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Java를 사용하여 Android용 Aspose.Slides로 PowerPoint 및 OpenDocument 슬라이드에 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용법 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint에서는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오 추가 또는 삽입 (컴퓨터에 저장된 파일)  
* 온라인 비디오 추가 (YouTube와 같은 웹 소스에서)  

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장된 경우, 프레젠테이션에 비디오를 임베드하기 위해 비디오 프레임을 만들 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드의 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideo/) 객체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.  
1. 비디오 프레임을 만들기 위해 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 Java 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```java
// Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("pres.pptx");
try {
    // 비디오를 로드합니다
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

또는 파일 경로를 직접 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 메서드에 전달하여 비디오를 추가할 수도 있습니다:

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **웹 소스에서 비디오를 사용한 비디오 프레임 만들기**

Microsoft의 최신 버전 [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)에서는 프레젠테이션에 온라인 비디오를 지원합니다. 사용하려는 비디오가 온라인(예: YouTube)에서 제공되는 경우, 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드의 인덱스를 통해 슬라이드 참조를 가져옵니다.  
1. [IVideo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideo/) 객체를 추가하고 비디오 링크를 전달합니다.  
1. 비디오 프레임의 썸네일을 설정합니다.  
1. 프레젠테이션을 저장합니다.  

다음 Java 코드는 웹에서 비디오를 가져와 PowerPoint 프레젠테이션의 슬라이드에 추가하는 방법을 보여줍니다:

```java
// Presentation 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // 비디오 프레임을 추가합니다
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // 썸네일을 로드합니다
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **비디오 프레임 자르기**

Aspose.Slides에서는 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 및 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 메서드를 통해 시작점과 끝점의 트림 값을 설정하여 비디오 재생 부분을 제어할 수 있습니다. 두 값은 밀리초 단위로 지정되며 각각 비디오의 시작과 끝에서 건너뛸 시간을 정의합니다. 이러한 설정은 프레젠테이션의 비디오 재생 설정을 변경하지만, 임베드된 비디오 바이너리 데이터를 자르거나 수정하지는 않습니다.

**Trim 설정 지정**

비디오 프레임을 생성하고 트림 설정을 지정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 프레젠테이션에 [IVideo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideo/) 객체를 추가합니다.  
1. 슬라이드에 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 및 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-)을 통해 시작 및 끝 트림 값을 설정합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드 예제는 임베드된 비디오 재생 시 처음 2.5초와 마지막 1초를 건너뜁니다:

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Trim 설정 읽기**

기존 트림 설정을 확인하려면 프레젠테이션을 로드하고 첫 번째 슬라이드의 도형 중 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 찾아 [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) 및 [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--)을 통해 값을 읽습니다.

다음 코드 예제는 첫 번째 슬라이드에서 최초의 비디오 프레임을 찾아 트림 설정을 밀리초 단위로 보고합니다:

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides에서는 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
1. 프레젠테이션에 비디오를 추가합니다.  
1. 슬라이드에 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 추가합니다.  
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)이 반환하는 [ICaptionsCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/)을 사용해 WebVTT 캡션 트랙을 추가합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 새 캡션 트랙을 WebVTT 파일에서 추가합니다.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 찾습니다.  
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)이 반환하는 캡션 트랙을 순회합니다.  
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.  

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 캡션 트랙을 WebVTT 파일에 저장합니다.
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

각 [ICaptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 데이터를 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.  
1. 대상 [IVideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/) 객체를 가져옵니다.  
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--)이 반환하는 컬렉션에서 캡션 트랙을 제거합니다.  
1. 수정된 프레젠테이션을 저장합니다.  

다음 코드는 비디오 프레임의 모든 캡션을 제거하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // 비디오 프레임에서 모든 캡션을 제거합니다.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#clear--) 대신 [remove](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 또는 [removeAt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
2. 모든 [ISlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) 객체를 순회합니다.  
3. 모든 [IShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/) 객체를 순회하여 [VideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoframe/)을 찾습니다.  
4. 비디오를 디스크에 저장합니다.  

다음 Java 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // 파일 확장자를 가져옵니다
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**VideoFrame에 대해 변경 가능한 비디오 재생 매개변수는 무엇입니까?**

[playback mode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)(자동 또는 클릭 시)와 [looping](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 훨씬 작습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있습니까?**

예. 프레임 내에서 [video content](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)를 교체하면서 도형의 기하학적 형태를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있습니까?**

예. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/video/#getContentType--)을 가지고 있으며, 이를 읽어 디스크에 저장하는 등 다양한 용도로 사용할 수 있습니다.