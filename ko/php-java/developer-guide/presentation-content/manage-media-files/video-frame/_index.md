---
title: PHP를 사용한 프레젠테이션에서 비디오 프레임 관리
linktitle: 비디오 프레임
type: docs
weight: 10
url: /ko/php-java/video-frame/
keywords:
- 비디오 추가
- 비디오 생성
- 비디오 삽입
- 비디오 추출
- 비디오 가져오기
- 비디오 프레임
- 웹 소스
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 슬라이드에서 비디오 프레임을 프로그래밍 방식으로 추가하고 추출하는 방법을 배웁니다. 빠른 사용 가이드."
---
## **소개**

비디오는 아이디어를 설명하고 청중을 끌어들이는 데 도움이 될 수 있습니다. Aspose.Slides for PHP via Java를 사용하면 슬라이드에 비디오 프레임을 추가하고, 재생 설정을 조정하며, 캡션을 관리하고, 삽입된 비디오 데이터를 추출할 수 있습니다.

PowerPoint는 로컬 비디오와 YouTube 비디오와 같은 온라인 비디오에 대한 링크를 지원합니다.

비디오 데이터와 비디오 프레임을 나타내기 위해, Aspose.Slides는 [Video](https://reference.aspose.com/slides/php-java/aspose.slides/video/) 클래스, [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 클래스 및 기타 관련 형식을 제공합니다.

## **임베드된 비디오 프레임 만들기**

슬라이드에 추가하려는 비디오 파일이 로컬에 저장되어 있는 경우, 비디오를 프레젠테이션에 삽입하기 위한 비디오 프레임을 만들 수 있습니다.

이 예제는 기존 프레젠테이션의 첫 번째 슬라이드에 로컬 비디오를 삽입하고 결과를 저장합니다. 프레임 좌표와 크기는 포인트 단위입니다. 스트림은 저장이 완료될 때까지 열려 있게 되는데, 이는 [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/php-java/aspose.slides/loadingstreambehavior/)이 프레젠테이션이 사용할 때 스트림을 잠금 상태로 유지하기 때문입니다.

```php
use aspose\slides\LoadingStreamBehavior;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
$videoStream = null;
try {
    $videoStream = new Java("java.io.FileInputStream", "video.mp4");
    $slide = $presentation->getSlides()->get_Item(0);

    $video = $presentation->getVideos()->addVideo($videoStream, LoadingStreamBehavior::KeepLocked);
    $slide->getShapes()->addVideoFrame(10, 10, 150, 250, $video);

    $presentation->save("embedded_video.pptx", SaveFormat::Pptx);
} finally {
    if ($videoStream !== null) {
        $videoStream->close();
    }
    $presentation->dispose();
}
```

또한 로컬 비디오 경로를 [addVideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addVideoFrame)에 직접 전달할 수도 있습니다. 이 예제는 새 프레젠테이션의 첫 번째 슬라이드에 비디오를 삽입합니다. 비디오는 프레젠테이션이 저장될 때까지 접근 가능해야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addVideoFrame(50, 150, 300, 150, "video.avi");

    $presentation->save("video_from_path.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **웹 소스에서 비디오로 비디오 프레임 만들기**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site)는 프레젠테이션에서 온라인 비디오를 지원합니다. YouTube 비디오와 같은 온라인 비디오에 연결되는 비디오 프레임을 만들 수 있습니다.

이 예제는 첫 번째 슬라이드에 YouTube 비디오 링크와 썸네일을 추가합니다. 다른 비디오를 사용하려면 비디오 식별자를 교체하십시오. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 메서드는 자동 재생을 요청합니다. 썸네일을 다운로드하고 비디오를 재생하려면 인터넷 접속이 필요합니다. 프레젠테이션 뷰어도 온라인 비디오 재생을 지원해야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoId = "aqz-KE-bpKQ";
    $videoUrl = "https://www.youtube.com/embed/" . $videoId;
    $videoFrame = $slide->getShapes()->addVideoFrame(10, 10, 427, 240, $videoUrl);
    $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

    $thumbnailUrl = "https://img.youtube.com/vi/" . $videoId . "/hqdefault.jpg";
    $thumbnailLocation = new Java("java.net.URL", $thumbnailUrl);
    $thumbnailStream = $thumbnailLocation->openStream();
    try {
        $thumbnail = $presentation->getImages()->addImage($thumbnailStream);
        $videoFrame->getPictureFormat()->getPicture()->setImage($thumbnail);
    } finally {
        $thumbnailStream->close();
    }

    $presentation->save("online_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **전체 화면 모드에서 비디오 재생**

교육용 프레젠테이션에서 소프트웨어 시연을 전체 화면 모드로 재생하면 청중이 세부 사항을 볼 수 있습니다. 재생 중에 이 동작을 활성화하려면 `true`와 함께 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode)을 호출합니다.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)을 찾아 전체 화면 재생을 활성화합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setFullScreenMode(true);
            break;
        }
    }

    $presentation->save("full_screen_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

전체 화면 재생은 비디오가 표시되는 방식을 제어합니다. 별도로, [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 은 자동 재생 또는 클릭 시 시작을 제어하고, [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 은 반복 여부를 제어합니다. 시작 동작을 선택하려면 재생 모드를 [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) 로 설정합니다. 예제는 기존 시작 및 반복 설정을 보존합니다.

## **재생 후 비디오 되감기**

교육용 프레젠테이션에서 시연 비디오를 처음으로 되돌리면 발표자가 다시 재생할 준비가 됩니다. 재생이 끝난 후 비디오를 처음으로 되돌리려면 `true`와 함께 [setRewindVideo](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setRewindVideo) 을 호출합니다.

이 예제는 프레젠테이션을 열고, 첫 번째 슬라이드에서 첫 번째 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/)을 찾아 되감기를 활성화합니다. 반복을 비활성화하여 재생이 끝나게 하고, 클릭 시 시작하도록 재생을 설정합니다. 입력 프레젠테이션에는 첫 번째 슬라이드에 기존 비디오 프레임이 최소 하나 포함되어 있어야 합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\VideoPlayModePreset;

$presentation = new Presentation("training.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $videoFrame->setRewindVideo(true);
            $videoFrame->setPlayLoopMode(false);
            $videoFrame->setPlayMode(VideoPlayModePreset::OnClick);
            break;
        }
    }

    $presentation->save("rewind_video.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

되감기는 비디오를 다시 시작하지 않고 처음으로 되돌립니다. 반대로 `true`와 함께 [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 를 호출하면 자동으로 반복 재생됩니다. 비디오가 끝나고 다시 재생할 준비가 되도록 하려면 반복을 비활성화하세요. [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) 은 자동 또는 클릭 시 시작을 독립적으로 제어합니다; 이 예제는 발표자가 재생 시작 시점을 제어하도록 [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/php-java/aspose.slides/videoplaymodepreset/) 을 사용합니다. 예제와 같이 반복 설정 후에 재생 모드를 설정합니다. 되감기는 [setFullScreenMode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setFullScreenMode) 와는 독립적으로 작동합니다.

## **비디오 프레임 자르기**

[VideoFrame::setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromStart) 및 [VideoFrame::setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setTrimFromEnd) 을 사용하여 재생 중 비디오의 시작 또는 끝 부분을 건너뛸 수 있습니다. 두 값은 밀리초 단위입니다. 자르기는 삽입된 비디오 데이터를 수정하지 않고 재생 설정만 변경합니다.

**자르기 설정**

이 예제는 로컬 비디오를 삽입하고 재생 중 처음 2.5초와 마지막 1초를 건너뜁니다. 재생 가능한 구간이 남도록 3.5초보다 긴 비디오를 사용하십시오.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 640, 360, $video);
    $videoFrame->setTrimFromStart(2500);
    $videoFrame->setTrimFromEnd(1000);

    $presentation->save("video_with_trim.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**자르기 설정 읽기**

이 예제는 첫 번째 슬라이드의 첫 번째 비디오 프레임에 대한 자르기 값을 밀리초 단위로 출력합니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다. 해당 슬라이드에 비디오 프레임이 없으면 아무것도 출력되지 않습니다. 앞 예제는 2500과 1000 값을 생성합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_trim.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            echo "Trim from start: " . java_values($videoFrame->getTrimFromStart()) . " ms\n";
            echo "Trim from end: " . java_values($videoFrame->getTrimFromEnd()) . " ms\n";
            break;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **비디오 캡션 관리**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션의 비디오 프레임에 대한 폐쇄 캡션을 관리할 수 있습니다. 캡션은 WebVTT 형식으로 저장되며 [VideoFrame::getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#getCaptionTracks) 메서드를 통해 노출됩니다.

**비디오 프레임에 캡션 추가**

이 예제는 로컬 비디오를 삽입하고 English 라벨이 붙은 WebVTT 캡션 트랙을 추가합니다. 캡션 타임스탬프는 비디오와 일치해야 합니다. 저장된 프레젠테이션에는 비디오와 캡션이 모두 포함됩니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFile = new Java("java.io.File", "video.mp4");
    $videoPath = $videoFile->toPath();
    $videoData = java("java.nio.file.Files")->readAllBytes($videoPath);
    $video = $presentation->getVideos()->addVideo($videoData);

    $videoFrame = $slide->getShapes()->addVideoFrame(0, 0, 100, 100, $video);
    $videoFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("video_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/) 클래스는 스트림에서 캡션을 추가할 수 있는 오버로드도 제공합니다.

**비디오 프레임에서 캡션 추출**

이 예제는 첫 번째 슬라이드의 비디오 프레임에서 모든 캡션 트랙을 별도의 WebVTT 파일로 저장합니다. 순차 번호가 출력 파일을 구분합니다. 콘솔에 추출된 트랙 수가 표시됩니다. 프레젠테이션에는 최소 하나의 슬라이드가 포함되어 있어야 합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $trackCount = 0;
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
            $videoFrame = $shape;
            $captionCount = java_values($videoFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $captionCount; $trackIndex++) {
                $captionTrack = $videoFrame->getCaptionTracks()->get_Item($trackIndex);
                $trackCount++;
                $outputStream = new Java("java.io.FileOutputStream", "captions_" . $trackCount . ".vtt");
                try {
                    $outputStream->write($captionTrack->getBinaryData());
                } finally {
                    $outputStream->close();
                }
            }
        }
    }

    echo "Caption tracks extracted: " . $trackCount . "\n";
} finally {
    $presentation->dispose();
}
```

각 [Captions](https://reference.aspose.com/slides/php-java/aspose.slides/captions/) 객체는 캡션 식별자, 라벨, 이진 데이터 및 UTF-8 문자열 형태의 캡션 텍스트를 노출합니다.

**비디오 프레임에서 캡션 제거**

이 예제는 첫 번째 슬라이드의 첫 번째 도형 위치에 있는 비디오 프레임에서 모든 캡션을 제거하고 결과를 저장합니다. 슬라이드와 도형이 존재하고 해당 도형이 비디오 프레임이라고 가정합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("video_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $videoFrame = $slide->getShapes()->get_Item(0);
    $videoFrame->getCaptionTracks()->clear();

    $presentation->save("video_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

하나의 캡션 트랙만 제거하려면 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) 대신 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 메서드를 사용하십시오.

## **슬라이드에서 비디오 추출**

슬라이드에 비디오를 추가하는 것 외에도 Aspose.Slides를 사용하면 프레젠테이션에 삽입된 비디오를 추출할 수 있습니다.

이 예제는 모든 슬라이드에서 삽입된 비디오를 별도의 번호가 매겨진 이진 파일로 추출합니다. 링크된 비디오는 삽입된 데이터가 없으므로 건너뜁니다. 콘솔에 각 비디오의 MIME 유형과 총 개수가 출력됩니다. 출력 파일은 일반적인 `.bin` 확장자를 사용하며, 필요에 따라 보고된 미디어 유형에 맞게 변경하십시오.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_videos.pptx");
try {
    $videoCount = 0;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $videoFrame = $shape;
                $video = $videoFrame->getEmbeddedVideo();
                if (java_is_null($video)) {
                    echo "Skipped a linked video: no embedded data is available.\n";
                    continue;
                }

                $videoCount++;
                $outputStream = new Java("java.io.FileOutputStream", "extracted_video_" . $videoCount . ".bin");
                try {
                    $outputStream->write($video->getBinaryData());
                } finally {
                    $outputStream->close();
                }
                echo "Video " . $videoCount . ": " . java_values($video->getContentType()) . "\n";
            }
        }
    }

    echo "Embedded videos extracted: " . $videoCount . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**비디오 프레임에 대해 변경할 수 있는 비디오 재생 매개변수는 무엇입니까?**

[playback mode](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayMode) (자동 또는 클릭 시) 및 [looping](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setPlayLoopMode) 을 제어할 수 있습니다. 이러한 옵션은 [VideoFrame](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/) 객체의 메서드를 통해 사용할 수 있습니다.

**비디오를 추가하면 PPTX 파일 크기에 영향이 있나요?**

예. 로컬 비디오를 삽입하면 이진 데이터가 문서에 포함되므로 프레젠테이션 크기가 파일 크기에 비례하여 증가합니다. 온라인 비디오에 링크하고 썸네일을 추가하면 비디오 데이터 대신 링크와 미리보기 이미지가 저장되므로 크기 증가가 보통 작습니다.

**기존 비디오 프레임의 위치와 크기를 변경하지 않고 비디오를 교체할 수 있나요?**

예. 프레임 내부의 [video content](https://reference.aspose.com/slides/php-java/aspose.slides/videoframe/#setEmbeddedVideo) 를 교체하면서 도형의 기하학적 형태를 유지할 수 있습니다. 이는 기존 레이아웃에서 미디어를 업데이트하는 일반적인 시나리오입니다.

**삽입된 비디오의 콘텐츠 유형(MIME)을 확인할 수 있나요?**

예. 삽입된 비디오는 [content type](https://reference.aspose.com/slides/php-java/aspose.slides/video/#getContentType) 을 가지고 있으며, 이를 읽어 예를 들어 디스크에 저장할 때 활용할 수 있습니다.