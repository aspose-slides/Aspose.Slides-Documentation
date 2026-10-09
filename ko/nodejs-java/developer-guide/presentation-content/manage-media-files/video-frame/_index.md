---
title: Node.js를 사용하여 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/nodejs-java/video-frame/
keywords:
- 비디오 추가
- 비디오 만들기
- 비디오 삽입
- 비디오 추출
- 비디오 가져오기
- 비디오 프레임
- 웹 소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용법 가이드."
---
## **소개**

비디오는 아이디어를 설명하고 청중을 참여시키는 데 도움이 될 수 있습니다. Aspose.Slides for Node.js via Java를 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 삽입된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube 비디오와 같은 온라인 비디오에 대한 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해 Aspose.Slides는 [비디오](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **삽입된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 비디오 프레임을 만들어 프레젠테이션에 비디오를 삽입할 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 삽입하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/)이 프레젠테이션이 사용 중인 동안 스트림을 잠금 상태로 유지하므로 저장이 완료될 때까지 스트림이 열려 있습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

로컬 비디오 경로를 직접 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/)에 전달할 수도 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 삽입합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **웹 소스 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)은 프레젠테이션에서 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 링크하는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하십시오. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 메서드는 자동 재생을 요청합니다. 썸네일을 다운로드하고 비디오를 재생하려면 인터넷 연결이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 소프트웨어 시연을 전체 화면 모드로 재생하면 청중이 세부 정보를 볼 수 있습니다. 재생 중에 이 동작을 활성화하려면 `true`와 함께 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/)를 호출하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)을 찾은 다음 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로, [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)은 자동 재생 또는 클릭 재생 여부를 제어하고, [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset.Auto 또는 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)으로 설정하십시오. 예제는 기존 시작 및 반복 설정을 보존합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 시작 지점으로 되돌리면 발표자가 다시 재생할 준비가 됩니다. 재생이 끝난 후 비디오를 시작 지점으로 되돌리려면 `true`와 함께 [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/)를 호출하십시오.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)을 찾은 다음 되감기를 활성화합니다. 루프를 비활성화하여 재생이 종료될 수 있게 하고, 클릭 시 재생하도록 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

되감기는 비디오를 다시 시작하지 않고 시작 지점으로 되돌립니다. 반면에 `true`와 함께 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)을 호출하면 재생이 자동으로 반복됩니다. 비디오가 종료되고 다시 재생할 준비가 되도록 하려면 반복을 비활성화하십시오. [setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)은 자동 또는 클릭 시작을 독립적으로 제어하며, 이 예제는 발표자가 재생 시작 시점을 제어하도록 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)을 사용합니다. 예제에 표시된 대로 루프 설정 후에 재생 모드를 설정하십시오. 되감기는 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/)과 독립적으로 작동합니다.

## **비디오 프레임 자르기**

[VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/)을 사용하여 재생 중 비디오 시작 부분이나 끝 부분을 건너뛸 수 있습니다. 두 값은 밀리초 단위입니다. 자르기는 삽입된 비디오 데이터를 변경하지 않고 재생 설정만 변경합니다.

**자르기 설정 설정**

이 예제는 로컬 비디오를 삽입하고 재생 중 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 3.5초보다 긴 비디오를 사용하십시오.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**자르기 설정 읽기**

이 예제는 첫 번째 슬라이드에 있는 첫 번째 비디오 프레임의 자르기 값을 밀리초 단위로 출력합니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 아무 것도 출력되지 않습니다. 이전 예제는 2500과 1000의 값을 생성합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 삽입하고 영어 레이블이 지정된 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가하기 위한 [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) 메서드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드에 있는 비디오 프레임에서 모든 캡션 트랙을 별도의 WebVTT 파일로 저장합니다. 순차 번호를 사용하여 출력 파일을 구분합니다. 콘솔은 추출된 트랙 수를 보고합니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

각 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드의 첫 번째 셰이프 위치에 있는 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 셰이프가 존재하고 해당 셰이프가 비디오 프레임이라고 가정합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

비디오를 슬라이드에 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 삽입된 비디오를 별도의 번호가 매겨진 바이너리 파일로 추출합니다. 링크된 비디오는 삽입된 데이터가 없으므로 건너뜁니다. 콘솔은 각 비디오의 MIME 유형과 총 개수를 출력합니다. 출력은 일반적인 `.bin` 확장자를 사용하며 필요에 따라 보고된 미디어 유형에 맞게 변경할 수 있습니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**비디오 프레임의 재생 매개변수 중 어떤 것을 변경할 수 있습니까?**  
재생 모드(자동 또는 클릭)와 반복을 [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)와 [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 객체의 메서드를 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기가 커지나요?**  
예. 로컬 비디오를 삽입하면 바이너리 데이터가 문서에 포함되므로 프레젠테이션 크기가 파일 크비례하여 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리 보기 이미지가 저장되므로 크기 증가가 보통 작습니다.

**기존 비디오 프레임의 위치와 크기를 변경하지 않고 비디오만 교체할 수 있나요?**  
예. 프레임 내에서 [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)를 교체하면서 셰이프의 기하학적 속성을 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 흔히 사용되는 시나리오입니다.

**삽입된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**  
예. 삽입된 비디오는 [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장하는 등 다양한 용도로 사용할 수 있습니다.