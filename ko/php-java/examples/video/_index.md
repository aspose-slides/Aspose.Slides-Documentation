---
title: 비디오
type: docs
weight: 80
url: /ko/php-java/examples/elements/video/
keywords:
- 비디오
- 비디오 프레임
- 비디오 추가
- 비디오 접근
- 비디오 제거
- 비디오 재생
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 비디오 작업: 삽입, 교체, 트림, 포스터 프레임 및 재생 옵션 설정, PPT, PPTX 및 ODP용 프레젠테이션 내보내기."
---
**Aspose.Slides for PHP via Java**를 사용하여 비디오 프레임을 삽입하고 재생 옵션을 설정하는 방법을 보여줍니다.

## **비디오 프레임 추가**

슬라이드에 비디오 프레임을 삽입합니다.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 비디오 프레임을 추가합니다.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **비디오 프레임 접근**

슬라이드에 추가된 첫 번째 비디오 프레임을 가져옵니다.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 비디오 프레임에 접근합니다.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **비디오 프레임 제거**

슬라이드에서 비디오 프레임을 삭제합니다.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 비디오 프레임이라고 가정합니다.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 비디오 프레임을 제거합니다.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **비디오 재생 설정**

슬라이드가 표시될 때 비디오가 자동으로 재생되도록 구성합니다.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 비디오 프레임이라고 가정합니다.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // 비디오를 자동 재생하도록 구성합니다.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```