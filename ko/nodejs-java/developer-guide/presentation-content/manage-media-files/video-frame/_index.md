---
title: JavaScript를 사용하여 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/nodejs-java/video-frame/
keywords:
- 비디오 추가
- 비디오 생성
- 비디오 임베드
- 비디오 추출
- 비디오 검색
- 비디오 프레임
- 웹 소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 Java를 통해 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 실무 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 보다 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint는 프레젠테이션 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오를 추가하거나 임베드(컴퓨터에 저장된 비디오)
* 온라인 비디오를 추가(YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 개체)를 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있으면 비디오 프레임을 만들어 프레젠테이션에 비디오를 임베드할 수 있습니다. 

1. [Presentation ](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation)class의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. [Video](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/video/) 개체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.
4. [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 추가하여 비디오 프레임을 만듭니다.
5. 수정된 프레젠테이션을 저장합니다. 

이 JavaScript 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여 줍니다:

```javascript
// Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 비디오를 로드합니다
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

또는 비디오 파일 경로를 직접 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) 메서드에 전달하여 비디오를 추가할 수 있습니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **웹 소스 비디오 프레임 만들기**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인(예: YouTube)에 있다면 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다. 

1. [Presentation ](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation)class의 인스턴스를 생성합니다
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
3. [Video](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/video/) 개체를 추가하고 비디오 링크를 전달합니다.
4. 비디오 프레임의 썸네일을 설정합니다. 
5. 프레젠테이션을 저장합니다. 

이 JavaScript 코드는 웹에서 비디오를 가져와 PowerPoint 슬라이드에 추가하는 방법을 보여 줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **비디오 프레임 자르기**

Aspose.Slides는 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/settrimfromend/) 메서드를 사용하여 trim-from-start 및 trim-from-end 값을 설정함으로써 재생할 비디오 부분을 제어할 수 있습니다. 두 값은 밀리초 단위이며 각각 비디오 시작과 끝에서 건너뛸 시간을 정의합니다. 이 설정은 프레젠테이션의 비디오 재생 설정을 변경하지만, 임베드된 비디오 바이너리 데이터를 자르거나 수정하지는 않습니다.

**Trim 설정 지정**

비디오 프레임을 만들고 Trim 설정을 지정하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) class의 인스턴스를 생성합니다.
2. 프레젠테이션에 [Video](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/video/) 개체를 추가합니다.
3. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 추가합니다.
4. [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 및 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/settrimfromend/)을 통해 trim-from-start 및 trim-from-end 값을 설정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 코드 예제는 재생 중에 임베드된 비디오의 처음 2.5초와 마지막 1초를 건너뛰게 합니다:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Trim 설정 읽기**

기존 Trim 설정을 확인하려면 프레젠테이션을 로드하고 첫 번째 슬라이드의 도형 중에서 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 찾아 [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) 및 [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/gettrimfromend/)을 통해 값을 읽습니다.

다음 코드 예제는 첫 번째 슬라이드에서 첫 번째 비디오 프레임을 찾아 그 Trim 설정을 밀리초 단위로 보고합니다:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides는 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있게 합니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 접근할 수 있습니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) class의 인스턴스를 생성합니다.
2. 프레젠테이션에 비디오를 추가합니다.
3. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 추가합니다.
4. [CaptionsCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/) 컬렉션을 사용하여 WebVTT 캡션 트랙을 추가합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여 줍니다:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가할 수 있는 [addFromStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/#addFromStream) 메서드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
2. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 찾습니다.
3. [CaptionsCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/) 컬렉션을 반복합니다.
4. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여 줍니다:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // 캡션 트랙을 WebVTT 파일에 저장합니다.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

각 [Captions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captions/) 개체는 캡션 식별자, 레이블, 바이너리 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 제공합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
2. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체를 가져옵니다.
3. [CaptionsCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/) 컬렉션에서 캡션 트랙을 제거합니다.
4. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여 줍니다:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // 유형: com.aspose.slides.VideoFrame

    // 비디오 프레임에서 모든 캡션을 제거합니다.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가할 뿐만 아니라, Aspose.Slides는 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) class의 인스턴스를 생성합니다.
2. 모든 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/) 개체를 반복합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/) 개체를 반복하여 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/)을 찾습니다.
4. 비디오를 디스크에 저장합니다.

이 JavaScript 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여 줍니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // 파일 확장자를 가져옵니다
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**VideoFrame에서 변경할 수 있는 비디오 재생 매개변수는 무엇입니까?**

[playback mode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/setplaymode/) (자동 또는 클릭)와 [looping](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/setplayloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/) 개체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 적습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있습니까?**

예. 프레임 내에서 [video content](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)를 교체하면서 도형의 형태를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트할 때 흔히 사용되는 시나리오입니다.

**임베드된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있습니까?**

예. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/video/getcontenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 등 활용할 수 있습니다.