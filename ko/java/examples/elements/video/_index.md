---
title: 비디오
type: docs
weight: 80
url: /ko/java/examples/elements/video/
keywords:
- 코드 예제
- 비디오
- 파워포인트
- 오픈문서
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 비디오를 추가하고 제어합니다: 삽입, 재생, 트리밍, 포스터 프레임 설정, 그리고 PPT, PPTX 및 ODP 프레젠테이션에 대한 Java 예제로 내보내기."
---
이 문서에서는 **Aspose.Slides for Java**를 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 비디오를 추가합니다.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 프레임 가져오기**

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // 슬라이드에서 첫 번째 비디오 프레임에 접근합니다.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 프레임 제거**

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // 비디오 프레임을 제거합니다.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **비디오 재생 설정**

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // 비디오를 자동으로 재생하도록 설정합니다.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```