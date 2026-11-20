---
title: PHP를 사용하여 프레젠테이션의 오디오 프레임 관리
linktitle: 오디오 프레임
type: docs
weight: 10
url: /ko/php-java/audio-frame/
keywords:
- 오디오
- 오디오 프레임
- 썸네일
- 오디오 추가
- 오디오 속성
- 오디오 옵션
- 오디오 추출
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 슬라이드에 오디오를 삽입하고, 오디오 아이콘을 변경하며, 재생을 구성하고, WebVTT 캡션을 관리하며, 슬라이드 전환 사운드를 추출합니다."
---
## **개요**

오디오 프레임을 사용하면 슬라이드에서 사운드를 재생할 수 있습니다. Aspose.Slides for PHP via Java를 사용하면 오디오 클립을 삽입하고, 이를 나타내는 이미지를 선택하며, 재생을 조정하고 캡션을 첨부할 수 있습니다. 또한 슬라이드 전환에 할당된 사운드를 가져올 수도 있습니다.

## **오디오 프레임 만들기**

첫 번째 슬라이드에 로컬 오디오 클립을 삽입하려면 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/)를 사용합니다. 처음 두 좌표는 프레임을 슬라이드에 배치하고, 다음 두 값은 너비와 높이를 포인트 단위로 설정합니다. 이 예제에서는 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/)을 호출하여 클립을 자동으로 시작하고, [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/)을 호출하여 큰 볼륨 프리셋을 선택합니다.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setPlayMode(AudioPlayModePreset::Auto);
    $audioFrame->setVolume(AudioVolumeMode::Loud);

    $presentation->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **오디오 프레임 썸네일 변경**

기본적으로 오디오 프레임은 스피커 아이콘을 표시합니다. 사용자 지정 썸네일을 표시하려면 [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/)를 사용하여 프레젠테이션에 이미지를 추가하고, [setImage](https://reference.aspose.com/slides/php-java/aspose.slides/picture/setimage/)를 사용하여 프레임의 그림에 설정합니다. 이 예제에서는 임베드된 오디오 클립의 썸네일로 JPEG를 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }

    $imageStream = new Java("java.io.FileInputStream", "eagle.jpeg");
    try {
        $thumbnail = $presentation->getImages()->addImage($imageStream);
    } finally {
        $imageStream->close();
    }
    $audioFrame->getPictureFormat()->getPicture()->setImage($thumbnail);

    $presentation->save("example_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **오디오 재생 옵션 변경**

PowerPoint의 **오디오 옵션** 컨트롤은 클립이 언제 시작되는지, 소리가 얼마나 크게 들리는지, 그리고 슬라이드 쇼 중에 어떻게 동작하는지를 결정합니다.

![오디오 프레임에 대한 PowerPoint 오디오 옵션 컨트롤](audio_frame_0.png)

| PowerPoint 컨트롤 | Aspose.Slides for PHP via Java 메서드 |
| --- | --- |
| 시작 | [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/) |
| 볼륨 프리셋 | [setVolume](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setvolume/) |
| 슬라이드 전체 재생 | [setPlayAcrossSlides](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayacrossslides/) |
| 정지될 때까지 반복 | [setPlayLoopMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplayloopmode/) |
| 쇼 동안 숨기기 | [setHideAtShowing](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/sethideatshowing/) |
| 재생 후 되감기 | [setRewindAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setrewindaudio/) |
| 페이드 인 | [setFadeInDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeInDuration) |
| 페이드 아웃 | [setFadeOutDuration](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setFadeOutDuration) |
| 오디오 시작 시간 자르기 | [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) |
| 오디오 종료 시간 자르기 | [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) |
| 볼륨 슬라이더 | [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) |

이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 찾은 다음, 클릭 시 재생을 시작하도록 [setPlayMode](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setplaymode/)을 호출하고 낮은 볼륨 프리셋을 선택합니다. 루프가 비활성화된 상태에서 클립은 슬라이드 전체에 걸쳐 계속 재생됩니다. 아이콘은 쇼 동안 숨겨지고, 클립은 재생 후 되감기됩니다.

```php
use aspose\slides\AudioPlayModePreset;
use aspose\slides\AudioVolumeMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setPlayAcrossSlides(true);
        $audioFrame->setPlayLoopMode(false);
        $audioFrame->setPlayMode(AudioPlayModePreset::OnClick);
        $audioFrame->setVolume(AudioVolumeMode::Low);
        $audioFrame->setHideAtShowing(true);
        $audioFrame->setRewindAudio(true);

        $presentation->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

길이가 3.5초를 초과하는 클립에 대해 이 예제는 처음 1.5초와 마지막 2초를 건너뜁니다. [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 은 클립 끝에서 제외할 지속 시간을 지정합니다. PowerPoint에 표시된 종료 시간을 얻으려면 전체 클립 길이에서 해당 오프셋을 빼면 됩니다. 트림된 클립은 200밀리초에 걸쳐 페이드 인하고 500밀리초에 걸쳐 페이드 아웃합니다. 네 메서드 모두 밀리초 단위 값을 사용합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->setTrimFromStart(1500);
    $audioFrame->setTrimFromEnd(2000);
    $audioFrame->setFadeInDuration(200);
    $audioFrame->setFadeOutDuration(500);

    $presentation->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

재생 볼륨을 특정 퍼센트로 설정하려면 [setVolumeValue](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setVolumeValue) 를 사용합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 오디오 프레임을 85%로 설정합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->setVolumeValue(85);
        $presentation->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **오디오 캡션 관리**

각 오디오 프레임은 [getCaptionTracks](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#getCaptionTracks) 을 통해 캡션 트랙에 접근할 수 있습니다. 컬렉션을 사용하여 클립에 WebVTT 캡션을 첨부하거나, 기존 트랙을 내보내거나, 제거할 수 있습니다.

### **오디오 캡션 추가**

이 예제는 첫 번째 슬라이드에 오디오 클립을 삽입하고 [add](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#add) 을 사용하여 로컬 WebVTT 트랙을 첨부합니다. 첫 번째 인자는 트랙 레이블을 제공하고, 두 번째 인자는 타임캡션이 포함된 파일을 지정합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioStream = new Java("java.io.FileInputStream", "audio.wav");
    try {
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audioStream);
    } finally {
        $audioStream->close();
    }
    $audioFrame->getCaptionTracks()->add("English", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **오디오 캡션 추출**

이 예제는 첫 번째 슬라이드의 오디오 프레임에 첨부된 각 캡션 트랙을 내보냅니다. [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getBinaryData) 가 반환하는 바이트를 WebVTT 파일에 기록하고, [getCaptionId](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getCaptionId) 가 반환하는 식별자를 파일 이름으로 사용하여 각 트랙이 별도의 출력 파일을 갖도록 합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $fileName = $track->getCaptionId() . ".vtt";
            $audioCaptions = $track->getBinaryData();
            $output = new Java("java.io.FileOutputStream", $fileName);
            try {
                $output->write($audioCaptions);
            } finally {
                $output->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

### **오디오 캡션 제거**

개별 트랙을 삭제하려면 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#remove) 또는 [removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#removeAt) 을 사용합니다. 이 예제는 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/captionscollection/#clear) 를 사용하여 클립은 유지하면서 첫 번째 슬라이드의 첫 번째 오디오 프레임에서 모든 캡션을 제거합니다.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $audioFrame = null;
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (java_instanceof($shape, $audioFrameType)) {
            $audioFrame = $shape;
            break;
        }
    }

    if ($audioFrame !== null) {
        $audioFrame->getCaptionTracks()->clear();
        $presentation->save("audio_without_captions.pptx", SaveFormat::Pptx);
    } else {
        echo "The first slide has no audio frame.\n";
    }
} finally {
    $presentation->dispose();
}
```

### **오디오 캡션에서 라인 찾기**

첫 번째 슬라이드의 오디오 캡션에서 라인을 찾으려면 메모리 내에서 [getDataAsString](https://reference.aspose.com/slides/php-java/aspose.slides/captions/#getDataAsString) 이 반환하는 텍스트를 검색합니다. 일반 텍스트 WebVTT 큐에서는 타이밍 라인에 `-->` 가 포함되고, 그 뒤에 캡션 라인이 오며, 빈 라인이 큐를 종료합니다. 이 예제는 트랙 레이블과 “café” 가 포함된 각 캡션 라인을 출력합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $audioFrameType = new JavaClass("com.aspose.slides.AudioFrame");
    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($i = 0; $i < $shapeCount; $i++) {
        $shape = $shapes->get_Item($i);
        if (!java_instanceof($shape, $audioFrameType)) {
            continue;
        }
        $tracks = $shape->getCaptionTracks();
        $trackCount = java_values($tracks->getCount());
        for ($j = 0; $j < $trackCount; $j++) {
            $track = $tracks->get_Item($j);
            $inCue = false;
            $captions = (string) $track->getDataAsString();
            foreach (preg_split('/\R/u', $captions) as $line) {
                if ($line === "") {
                    $inCue = false;
                } elseif (strpos($line, "-->") !== false) {
                    $inCue = true;
                } elseif ($inCue && preg_match('/café/iu', $line)) {
                    echo $track->getLabel() . ": " . $line . "\n";
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **오디오 추출**

슬라이드 전환에는 자체 사운드가 있을 수 있습니다. 이를 가져오려면 슬라이드 전환에서 [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/slideshowtransition/getsound/) 을 호출합니다. 이 예제는 [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/) 가 반환하는 바이트에 접근하고 바이트 수를 출력합니다. 첫 번째 슬라이드에 전환 사운드가 없으면 대신 메시지를 출력합니다.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AudioSlide.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $sound = $slide->getSlideShowTransition()->getSound();
    if (java_is_null($sound)) {
        echo "The first slide has no transition sound.\n";
    } else {
        $audioData = $sound->getBinaryData();
        $array = new JavaClass("java.lang.reflect.Array");
        echo "Transition sound: " . $array->getLength($audioData) . " bytes.\n";
    }
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**여러 슬라이드에서 같은 오디오 클립을 중복 없이 재사용할 수 있나요?**

예. 클립을 프레젠테이션의 [오디오 컬렉션](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getaudios/)에 한 번 추가하고, 각 슬라이드에 대해 동일한 오디오 객체를 [addAudioFrameEmbedded](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addaudioframeembedded/)에 전달하면 됩니다.

**기존 오디오 프레임의 사운드를 교체할 수 있나요?**

예. 연결된 사운드의 경우 [setLinkPathLong](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setlinkpathlong/) 을 사용하여 교체 파일을 지정합니다. 임베드된 사운드의 경우 프레젠테이션의 오디오 컬렉션에서 다른 클립을 [setEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/setembeddedaudio/) 로 선택합니다. 두 방법 모두 기존 프레임을 유지합니다.

**트리밍이 프레젠테이션에 저장된 오디오 데이터를 변경합니까?**

아니오. [setTrimFromStart](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromStart) 및 [setTrimFromEnd](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/#setTrimFromEnd) 은 재생 경계를 설정합니다. 전체 클립은 여전히 [getEmbeddedAudio](https://reference.aspose.com/slides/php-java/aspose.slides/audioframe/getembeddedaudio/) 을 통해 가져올 수 있습니다.