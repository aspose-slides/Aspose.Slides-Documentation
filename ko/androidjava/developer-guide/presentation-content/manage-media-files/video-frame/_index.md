---
title: Android에서 프레젠테이션 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java을 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배우세요. 빠른 사용 가이드."
---
## **소개**

비디오는 아이디어를 설명하고 청중을 참여시키는 데 도움이 될 수 있습니다. Aspose.Slides for Android via Java을 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 삽입된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube 비디오와 같은 온라인 비디오에 대한 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해 Aspose.Slides는 [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) 인터페이스, [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 인터페이스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있다면, 비디오 프레임을 만들어 프레젠테이션에 비디오를 삽입할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 삽입하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. 스트림은 저장이 완료될 때까지 열려 있습니다. 이는 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) 가 프레젠테이션이 사용할 동안 스트림을 잠금 상태로 유지하기 때문입니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

또한 로컬 비디오 경로를 직접 [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-) 에 전달할 수 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 삽입합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **웹 소스의 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 은 프레젠테이션에서 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 연결되는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하십시오. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) 메서드는 자동 재생을 요청합니다. 썸네일을 다운로드하고 비디오를 재생하려면 인터넷 연결이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 소프트웨어 데모를 전체 화면 모드로 재생하여 청중이 세부 사항을 볼 수 있게 할 수 있습니다. 재생 중에 이 동작을 활성화하려면 `true` 로 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 을 호출하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 을 찾아 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로 [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 은 자동으로 시작할지 클릭 시 시작할지를 제어하고, [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset.Auto 혹은 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) 으로 설정하십시오. 예제는 기존 시작 및 반복 설정을 그대로 유지합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 처음으로 되돌리면 발표자가 다시 재생할 준비가 됩니다. 재생이 끝난 후 비디오를 처음으로 되돌리려면 `true` 로 [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 을 호출하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 을 찾아 되감기를 활성화합니다. 재생이 끝날 수 있도록 반복을 비활성화하고, 재생을 클릭 시 시작하도록 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

되감기는 비디오를 다시 시작하지 않고 처음으로 되돌립니다. 반대로 `true` 로 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 을 호출하면 재생이 자동으로 반복됩니다. 비디오가 끝나고 다시 재생할 준비가 되도록 하려면 반복을 비활성화하십시오. [setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 은 자동 시작 또는 클릭 시작을 독립적으로 제어합니다; 이 예제는 재생 시작을 발표자가 제어하도록 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) 을 사용합니다. 예제와 같이 반복 설정 후에 재생 모드를 설정하십시오. 되감기는 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 와는 독립적으로 동작합니다.

## **비디오 프레임 트리밍**

[IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 과 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 을 사용하여 재생 중 비디오 시작 부분이나 끝 부분을 건너뛸 수 있습니다. 두 값은 밀리초 단위입니다. 트리밍은 삽입된 비디오 데이터를 변경하지 않고 재생 설정을 변경합니다.

**트림 설정**

이 예제는 로컬 비디오를 삽입하고 재생 중 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 3.5초보다 긴 비디오를 사용하십시오.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**트림 설정 읽기**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 비디오 프레임의 트리밍 값을 밀리초 단위로 출력합니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 아무것도 출력되지 않습니다. 앞선 예제는 2500과 1000 값을 생성합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 메서드를 통해 제공됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 삽입하고 'English' 라벨이 붙은 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) 인터페이스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드에 있는 비디오 프레임의 모든 캡션 트랙을 별도의 WebVTT 파일로 저장합니다. 순차 번호를 사용하여 출력 파일을 구분합니다. 콘솔은 추출된 트랙 수를 보고합니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

각 [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) 객체는 캡션 식별자, 라벨, 바이너리 데이터 및 캡션 텍스트를 UTF-8 문자열로 노출합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드의 첫 번째 셰이프 위치에 있는 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 셰이프가 존재하고 해당 셰이프가 비디오 프레임이라고 가정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--) 대신 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 또는 [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 삽입된 비디오를 별도의 번호가 매겨진 바이너리 파일로 추출합니다. 링크된 비디오는 삽입된 데이터가 없으므로 건너뜁니다. 콘솔은 각 비디오의 MIME 유형과 총 개수를 출력합니다. 출력은 일반적인 `.bin` 확장자를 사용합니다; 필요에 따라 보고된 미디어 유형에 맞게 변경하십시오.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**비디오 프레임에서 변경할 수 있는 비디오 재생 매개변수는 무엇인가요?**

[재생 모드](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) (자동 또는 클릭)와 [반복](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) 객체의 메서드를 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 미치나요?**

예. 로컬 비디오를 삽입하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리보기 이미지가 저장되므로 크기 증가가 보통 더 작습니다.

**기존 비디오 프레임의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내부의 [video content](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 을 교체하면서 셰이프의 기하학적 형태를 유지할 수 있습니다; 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 상황입니다.

**삽입된 비디오의 콘텐츠 타입(MIME)을 확인할 수 있나요?**

예. 삽입된 비디오는 [content type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--) 을 가지고 있으며, 이를 읽어 디스크에 저장하는 등 활용할 수 있습니다.