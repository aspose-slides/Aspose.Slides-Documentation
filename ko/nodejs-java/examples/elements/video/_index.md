---
title: 비디오
type: docs
weight: 80
url: /ko/nodejs-java/examples/elements/video/
keywords:
- 코드 예제
- 비디오
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 비디오를 추가하고 제어합니다: 삽입, 재생, 트림, 포스터 프레임 설정, 그리고 PPT, PPTX 및 ODP 프레젠테이션 예제와 함께 내보내기."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**

슬라이드에 비디오 프레임을 추가합니다.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 비디오를 추가합니다.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 프레임 접근**

슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // 슬라이드에서 첫 번째 비디오 프레임에 접근합니다.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 프레임 제거**

슬라이드에서 비디오 프레임을 삭제합니다.

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 쉐이프가 비디오 프레임이라고 가정합니다.
        let videoFrame = slide.getShapes().get_Item(0);

        // 비디오 프레임을 제거합니다.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 재생 설정**

슬라이드가 표시될 때 비디오가 자동으로 재생되도록 구성합니다.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 첫 번째 쉐이프가 비디오 프레임이라고 가정합니다.
        let videoFrame = slide.getShapes().get_Item(0);

        // 비디오가 자동으로 재생되도록 구성합니다.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```