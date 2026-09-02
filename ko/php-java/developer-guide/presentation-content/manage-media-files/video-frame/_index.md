---
title: PHP를 사용하여 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/php-java/video-frame/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 가이드."
---
## **소개**

프레젠테이션에 적절히 배치된 비디오는 메시지를 더욱 설득력 있게 만들고 청중과의 참여도를 높일 수 있습니다. 

PowerPoint는 프레젠테이션의 슬라이드에 비디오를 추가하는 두 가지 방법을 제공합니다:

* 로컬 비디오를 추가하거나 삽입(컴퓨터에 저장된)
* 온라인 비디오를 추가(YouTube와 같은 웹 소스에서).

프레젠테이션에 비디오(비디오 개체)를 추가할 수 있도록 Aspose.Slides는 [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 클래스 및 기타 관련 유형을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장된 경우, 비디오 프레임을 만들어 프레젠테이션에 비디오를 임베드할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 개체를 추가하고 비디오 파일 경로를 전달하여 프레젠테이션에 비디오를 임베드합니다.
1. [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 추가하여 비디오 프레임을 생성합니다.
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

## **웹 소스 비디오를 활용한 비디오 프레임 만들기**

Microsoft PowerPoint 2013 및 이후 버전은 프레젠테이션에서 YouTube 비디오를 지원합니다. 사용하려는 비디오가 온라인에 존재한다면(예: YouTube), 웹 링크를 통해 프레젠테이션에 추가할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스를 통해 슬라이드의 참조를 가져옵니다. 
1. [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 개체를 추가하고 비디오 링크를 전달합니다.
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

## **비디오 프레임 트리밍**

Aspose.Slides는 [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#setTrimFromEnd)를 통해 시작 및 끝에서 트리밍할 값을 밀리초 단위로 지정하여 비디오가 재생되는 부분을 제어할 수 있게 합니다. 두 값은 각각 비디오 시작과 끝에서 건너뛰는 시간을 정의합니다. 이 설정은 프레젠테이션 내 비디오 재생 설정을 변경하지만, 임베드된 비디오 바이너리 데이터를 자르거나 수정하지는 않습니다.

**Trim 설정 적용**

비디오 프레임을 만들고 트리밍 설정을 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 [Video](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/) 개체를 추가합니다.
1. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 추가합니다.
1. [VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#setTrimFromEnd)를 통해 트리밍 값을 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드 예시는 재생 시 임베드된 비디오의 처음 2.5초와 마지막 1초를 건너뜁니다:

```php
$presentation = new Presentation();
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $video = $presentation->getVideos()->addVideo(
        $videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);

    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

**Trim 설정 읽기**

기존 트리밍 설정을 확인하려면 프레젠테이션을 로드하고 첫 번째 슬라이드의 도형 중에서 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 찾아 [VideoFrame::getTrimFromStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getTrimFromStart) 및 [VideoFrame::getTrimFromEnd](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getTrimFromEnd)를 통해 값을 읽습니다.

다음 코드 예시는 첫 번째 슬라이드에서 첫 번째 비디오 프레임을 찾아 밀리초 단위의 트리밍 설정을 보고합니다:

```php
$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $trimFromStart = java_values($videoFrame->getTrimFromStart());
            $trimFromEnd = java_values($videoFrame->getTrimFromEnd());

            echo "Trim from start: " . $trimFromStart . " ms\n";
            echo "Trim from end: " . $trimFromEnd . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 접근할 수 있습니다.

**비디오 프레임에 캡션 추가**

비디오 프레임에 캡션을 추가하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션에 비디오를 추가합니다.
1. 슬라이드에 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 추가합니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks)으로 반환되는 [CaptionsCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/) 컬렉션을 사용해 WebVTT 캡션 트랙을 추가합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 코드는 비디오 프레임에 캡션을 추가하는 방법을 보여줍니다:

```php
$presentation = new Presentation();
try {
    $videoData = file_get_contents("video.mp4");
    $video = $presentation->getVideos()->addVideo($videoData);

    $slide = $presentation->getSlides()->get_Item(0);
    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);

    // WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
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
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 찾습니다.
1. [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/#getCaptionTracks) 컬렉션을 순회합니다.
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

각 [Captions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captions/) 객체는 캡션 식별자, 레이블, 바이너리 데이터 및 캡션 텍스트를 UTF-8 문자열로 노출합니다.

**비디오 프레임에서 캡션 제거**

비디오 프레임에서 캡션을 제거하려면:

1. 비디오가 포함된 프레젠테이션을 로드합니다.
1. 대상 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체를 가져옵니다.
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

하나의 캡션 트랙만 제거하려면 [clear] 대신 [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용합니다.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도, Aspose.Slides는 프레젠테이션에 임베드된 비디오를 추출할 수 있습니다.

1. 비디오가 포함된 프레젠테이션을 로드하려면 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 모든 [Slide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/) 개체를 순회합니다.
3. 모든 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 개체를 순회하여 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/)을 찾습니다.
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

**VideoFrame에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇입니까?**

[재생 모드](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setplaymode/) (자동 또는 클릭 시) 및 [반복](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setplayloopmode/)을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/) 개체의 속성을 통해 이용 가능합니다.

**비디오를 추가하면 PPTX 파일 크기에 영향을 줍니까?**

예. 로컬 비디오를 임베드하면 바이너리 데이터가 문서에 포함되어 파일 크기에 비례해 프레젠테이션 크기가 증가합니다. 온라인 비디오를 추가하면 링크와 썸네일만 임베드되므로 크기 증가가 적습니다.

**기존 VideoFrame의 비디오를 위치와 크기를 변경하지 않고 교체할 수 있나요?**

예. 프레임 내에서 [video content](https://reference.aspose.com/slides/ko/php-java/aspose.slides/videoframe/setembeddedvideo/)를 교체하면서 도형의 기하학을 유지할 수 있습니다; 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**임베드된 비디오의 콘텐츠 타입(MIME)을 확인할 수 있나요?**

예. 임베드된 비디오는 [content type](https://reference.aspose.com/slides/ko/php-java/aspose.slides/video/getcontenttype/)을 가지고 있으며 이를 읽어 디스크에 저장할 때 활용할 수 있습니다.