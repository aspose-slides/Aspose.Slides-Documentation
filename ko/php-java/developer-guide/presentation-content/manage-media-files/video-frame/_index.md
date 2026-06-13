---
title: PHP를 사용하여 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 실무 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint에서는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오 추가 또는 삽입(컴퓨터에 저장된 비디오)
* 온라인 비디오 추가(YouTube와 같은 웹 소스에서)

프레젠테이션에 비디오(비디오 객체)를 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **삽입된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 비디오 프레임을 생성하여 프레젠테이션에 비디오를 삽입할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. 프레젠테이션에 비디오를 삽입하기 위해 [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 객체를 추가하고 비디오 파일 경로를 전달합니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 객체를 추가하여 비디오 프레임을 만듭니다.
1. 수정된 프레젠테이션을 저장합니다. 

다음 PHP 코드는 로컬에 저장된 비디오를 프레젠테이션에 추가하는 방법을 보여줍니다:

```php
  # Presentation 클래스를 인스턴스화합니다
  $pres = new Presentation("pres.pptx");
  try {
    # 비디오를 로드합니다
    $fileStream = new Java("java.io.FileInputStream", "Wildlife.mp4");
    $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
    # 첫 번째 슬라이드를 가져와 비디오 프레임을 추가합니다
    $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(10, 10, 150, 250, $video);
    # 프레젠테이션을 디스크에 저장합니다
    $pres->save("pres-with-video.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

또는 비디오 파일 경로를 직접 [addVideoFrame(float x, float y, float width, float height, Video video)](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shapecollection/addvideoframe/) 메서드에 전달하여 비디오를 추가할 수 있습니다:

```php
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    $vf = $sld->getShapes()->addVideoFrame(50, 150, 300, 150, "video1.avi");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **웹 소스 비디오를 사용한 비디오 프레임 만들기**

Microsoft [PowerPoint 2013 및 이후 버전](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)에서는 프레젠테이션에 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인에 존재한다면(예: YouTube), 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 객체를 추가하고 비디오 링크를 전달합니다.
1. 비디오 프레임의 썸네일을 설정합니다. 
1. 프레젠테이션을 저장합니다. 

다음 PHP 코드는 웹에서 비디오를 가져와 PowerPoint 프레젠테이션의 슬라이드에 추가하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation();
  try {
    addVideoFromYouTube($pres, "Tj75Arhq5ho");
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 제공됩니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 비디오를 추가합니다.
1. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 객체를 추가합니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 가 반환하는 [CaptionsCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/) 컬렉션을 사용하여 WebVTT 캡션 트랙을 추가합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // WebVTT 파일에서 새 캡션 트랙을 추가합니다.
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/) 클래스는 스트림으로부터 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

비디오 프레임에서 캡션을 추출하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 객체를 찾습니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 컬렉션을 반복합니다.
1. 각 캡션 트랙을 `.vtt` 파일로 저장합니다.

다음 코드는 비디오 프레임에서 캡션을 추출하는 방법을 보여줍니다:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trackCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                // 캡션 트랙을 WebVTT 파일에 저장합니다.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

각 [Captions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captions/) 객체는 캡션 식별자, 라벨, 바이너리 데이터 및 캡션 텍스트를 UTF-8 문자열로 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 객체를 가져옵니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 컬렉션에서 캡션 트랙을 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에서 모든 캡션을 제거하는 방법을 보여줍니다:

```php
$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->get_Item(0); // 유형: VideoFrame

    // 비디오 프레임에서 모든 캡션을 제거합니다.
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

단일 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도, Aspose.Slides를 사용하면 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성하여 비디오가 포함된 프레젠테이션을 로드합니다.
2. 모든 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 객체를 반복합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 객체를 반복하여 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/)을 찾습니다.
4. 비디오를 디스크에 저장합니다.

다음 PHP 코드는 프레젠테이션 슬라이드에서 비디오를 추출하는 방법을 보여줍니다:

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation("VideoSample.pptx");
  try {
    foreach($pres->getSlides() as $slide) {
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
          $vf = $shape;
          $type = $vf->getEmbeddedVideo()->getContentType();
          $ss = $type->lastIndexOf('-');
          $buffer = $vf->getEmbeddedVideo()->getBinaryData();
          # 파일 확장자를 가져옵니다
          $charIndex = $type->indexOf("/");
          $type = $type->substring($charIndex + 1);
          $fop = new Java("java.io.FileOutputStream", "testing2." . $type);
          $fop->write($buffer);
          $fop->flush();
          $fop->close();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**VideoFrame의 어떤 비디오 재생 매개변수를 변경할 수 있나요?**

[playback mode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setplaymode/) (자동 또는 클릭 시)와 [looping](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setplayloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 객체의 속성을 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 미치나요?**

예. 로컬 비디오를 삽입하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 삽입되므로 크기 증가가 적습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내에서 [video content](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setembeddedvideo/)를 교체하면서 쉐이프의 기하학적 특성을 유지할 수 있습니다. 이는 기존 레이아웃의 미디어를 업데이트할 때 흔히 사용되는 시나리오입니다.

**삽입된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 삽입된 비디오는 [content type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/getcontenttype/)을 가지고 있으며, 이를 읽어 디스크에 저장할 때 등 활용할 수 있습니다.