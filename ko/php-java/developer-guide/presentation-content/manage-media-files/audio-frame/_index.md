---
title: PHP를 사용한 프레젠테이션의 오디오 관리
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
description: "Aspose.Slides for PHP에서 오디오 프레임을 생성하고 제어합니다—삽입, 트리밍, 루프 및 PPT, PPTX, ODP 프레젠테이션 전반에 걸친 재생 설정을 위한 코드 예제."
---
## **개요**

이 문서에서는 Aspose.Slides에서 오디오 프레임을 사용하는 방법을 설명합니다. 슬라이드에 삽입된 오디오를 추가하고, 오디오 프레임 썸네일을 사용자 지정하며, 볼륨, 루프, 숨기기, 트리밍 및 페이드 지속 시간과 같은 재생 옵션을 구성하고, 슬라이드 쇼 전환에 사용되는 오디오를 추출하는 방법을 보여줍니다.

## **오디오 프레임 만들기**

Aspose.Slides for PHP via Java를 사용하면 오디오 파일을 슬라이드에 추가할 수 있습니다. 오디오 파일은 오디오 프레임으로 슬라이드에 삽입됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.
3. 슬라이드에 삽입하려는 오디오 파일 스트림을 로드합니다.
4. 삽입된 오디오 프레임(오디오 파일을 포함)을 슬라이드에 추가합니다.
5. AudioFrame 객체가 노출하는 [PlayMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/AudioPlayModePreset)와 `Volume`을 설정합니다.
6. 수정된 프레젠테이션을 저장합니다.

이 PHP 코드는 슬라이드에 삽입된 오디오 프레임을 추가하는 방법을 보여줍니다:
```php
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
$pres = new Presentation();
try {
    # 첫 번째 슬라이드를 가져옵니다
    $sld = $pres->getSlides()->get_Item(0);
    # wav 사운드 파일을 스트림으로 로드합니다
    $fstr = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
    # 오디오 프레임을 추가합니다
    $audioFrame = $sld->getShapes()->addAudioFrameEmbedded(50, 150, 100, 100, $fstr);
    $fstr->close();
    # 오디오의 재생 모드와 볼륨을 설정합니다
    $audioFrame->setPlayMode(AudioPlayModePreset->Auto);
    $audioFrame->setVolume(AudioVolumeMode->Loud);
    # PowerPoint 파일을 디스크에 저장합니다
    $pres->save("AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
} catch(JavaException e) {
} finally {
    if (!java_is_null($pres)) $pres.dispose();
}
```

## **오디오 프레임 썸네일 변경**

프레젠테이션에 오디오 파일을 추가하면 오디오는 표준 기본 이미지가 있는 프레임으로 표시됩니다(아래 섹션의 이미지를 참조하십시오). 오디오 프레임의 미리 보기 이미지(선호하는 이미지)를 변경할 수 있습니다.

이 PHP 코드는 오디오 프레임의 썸네일 또는 미리 보기 이미지를 변경하는 방법을 보여줍니다:
```php
$presentation = new Presentation();
try {
	$slide = $presentation->getSlides()->get_Item(0);
	# 지정된 위치와 크기로 슬라이드에 오디오 프레임을 추가합니다.
	$audioStream = new Java("java.io.FileInputStream", "sample2.mp3");
	$audioFrame = $slide->getShapes()->addAudioFrameEmbedded(150, 100, 50, 50, $audioStream);
	$audioStream->close();
	# 프레젠테이션 리소스에 이미지를 추가합니다.
	$picture;
	$image = Images->fromFile("eagle.jpeg");
	try {
		$picture = $presentation->getImages()->addImage($image);
	} finally {
		if (!java_is_null($image)) {
			$image->dispose();
		}
	}
	# 오디오 프레임에 이미지를 설정합니다.
	$audioFrame->getPictureFormat()->getPicture()->setImage($picture);// <-----

	# 수정된 프레젠테이션을 디스크에 저장합니다
	$presentation->save("example_out.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
	if (!java_is_null($presentation)) {
		$presentation->dispose();
	}
}
```

## **오디오 재생 옵션 변경**

Aspose.Slides for PHP via Java를 사용하면 오디오 재생이나 속성을 제어하는 옵션을 변경할 수 있습니다. 예를 들어 오디오의 볼륨을 조정하고, 오디오를 루프 재생하도록 설정하거나, 오디오 아이콘을 숨길 수도 있습니다.

Microsoft PowerPoint의 **Audio Options** 창:
![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**는 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/) 속성과 대응됩니다:

- **Start** 드롭다운 목록은 [AudioFrame::setPlayMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setPlayMode) 메서드와 일치합니다.
- **Volume**은 [AudioFrame::setVolume](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setVolume) 메서드와 일치합니다.
- **Play Across Slides**는 [AudioFrame::setPlayAcrossSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setPlayAcrossSlides) 메서드와 일치합니다.
- **Loop until Stopped**는 [AudioFrame::setPlayLoopMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setPlayLoopMode) 메서드와 일치합니다.
- **Hide During Show**는 [AudioFrame::setHideAtShowing](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setHideAtShowing) 메서드와 일치합니다.
- **Rewind after Playing**는 [AudioFrame::setRewindAudio](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setRewindAudio) 메서드와 일치합니다.

PowerPoint **Editing** 옵션은 Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/) 속성과 대응됩니다:

- **Fade In**은 [AudioFrame::setFadeInDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setFadeInDuration) 메서드와 일치합니다. 
- **Fade Out**은 [AudioFrame::setFadeOutDuration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setFadeOutDuration) 메서드와 일치합니다. 
- **Trim Audio Start Time**은 [AudioFrame::setTrimFromStart](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setTrimFromStart) 메서드와 일치합니다. 
- **Trim Audio End Time** 값은 오디오 길이에서 [AudioFrame::setTrimFromEnd](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setTrimFromEnd) 메서드 값만큼 차감한 것과 같습니다.

PowerPoint 오디오 제어 패널의 **Volume controll**은 [AudioFrame::setVolumeValue](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#setVolumeValue) 메서드에 해당합니다. 이 메서드를 사용하면 오디오 볼륨을 백분율로 변경할 수 있습니다.

오디오 재생 옵션을 변경하는 방법은 다음과 같습니다:

1. [오디오 프레임 만들기](#create-audio-frame) 또는 오디오 프레임을 가져옵니다.
2. 조정하려는 오디오 프레임 속성에 새 값을 설정합니다.
3. 수정된 PowerPoint 파일을 저장합니다.

이 PHP 코드는 오디오 옵션을 조정하는 작업을 보여줍니다:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    # AudioFrame 도형을 가져옵니다
    $audioFrame = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # 재생 모드를 클릭 시 재생으로 설정합니다
    $audioFrame->setPlayMode(AudioPlayModePreset->OnClick);
    # 볼륨을 낮게 설정합니다
    $audioFrame->setVolume(AudioVolumeMode->Low);
    # 오디오를 슬라이드 전체에서 재생하도록 설정합니다
    $audioFrame->setPlayAcrossSlides(true);
    # 오디오 루프를 비활성화합니다
    $audioFrame->setPlayLoopMode(false);
    # 슬라이드 쇼 중에 AudioFrame을 숨깁니다
    $audioFrame->setHideAtShowing(true);
    # 재생 후 오디오를 시작 부분으로 되감습니다
    $audioFrame->setRewindAudio(true);
    # PowerPoint 파일을 디스크에 저장합니다
    $pres->save("AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

이 PHP 예제는 삽입된 오디오가 포함된 새로운 오디오 프레임을 추가하고, 트리밍하며, 페이드 지속 시간을 설정하는 방법을 보여줍니다:
```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $audioData = file_get_contents("sampleaudio.mp3");
    $audio = $pres->getAudios()->addAudio($audioData);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audio);

    // 트리밍 시작 오프셋을 1.5초로 설정합니다
    $audioFrame->setTrimFromStart(1500);
    // 트리밍 종료 오프셋을 2초로 설정합니다
    $audioFrame->setTrimFromEnd(2000);

    // 페이드인 지속 시간을 200ms로 설정합니다
    $audioFrame->setFadeInDuration(200);
    // 페이드아웃 지속 시간을 500ms로 설정합니다
    $audioFrame->setFadeOutDuration(500);

    $pres->save("AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

다음 코드 샘플은 삽입된 오디오가 있는 오디오 프레임을 가져와 볼륨을 85%로 설정하는 방법을 보여줍니다:
```php
$pres = new Presentation("AudioFrameEmbed_out.pptx");
try {
    $slide = $pres->getSlides()->get_Item(0);

    // 오디오 프레임 도형을 가져옵니다
    $audioFrame = $slide->getShapes()->get_Item(0);

    // 오디오 볼륨을 85%로 설정합니다
    $audioFrame->setVolumeValue(85);

    $pres->save("AudioFrameValue_out.pptx", SaveFormat::Pptx);
}
finally {
    $pres->dispose();
}
```

## **오디오 캡션 관리**

Aspose.Slides를 사용하면 [getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#getCaptionTracks) 메서드를 통해 오디오 프레임에 폐쇄 캡션을 추가할 수 있습니다. 이 메서드는 [CaptionsCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/)을 반환하며, 이를 사용하여 WebVTT 캡션 트랙을 추가하고, 기존 트랙을 반복하며, 필요할 때 제거할 수 있습니다.

**Add Audio Captions**

[getCaptionTracks](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/#getCaptionTracks) 메서드를 사용하여 하나 이상의 캡션 트랙을 오디오 프레임에 연결합니다. 다음 예제에서는 오디오 파일을 슬라이드에 추가하고, 새로운 캡션 트랙을 `.vtt` 파일에서 로드합니다.
```php
$presentation = new Presentation();
try {
    $audioData = file_get_contents("audio.mp3");
    $audio = $presentation->getAudios()->addAudio($audioData);

    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(10, 10, 50, 50, $audio);

    // WebVTT 파일에서 새로운 캡션 트랙을 추가합니다.
    $audioFrame->getCaptionTracks()->add("New track", "track.vtt");

    $presentation->save("audio_with_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**Extract Audio Captions**

오디오 프레임에 연결된 캡션 트랙을 반복하면서 `.vtt` 파일로 저장할 수 있습니다. 각 캡션 트랙은 바이너리 데이터와 고유 식별자를 제공하므로 캡션을 내보낼 때 사용할 수 있습니다.
```php
$presentation = new Presentation("audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
            $audioFrame = $shape;
            $trackCount = java_values($audioFrame->getCaptionTracks()->getCount());
            for ($trackIndex = 0; $trackIndex < $trackCount; $trackIndex++) {
                $captionTrack = $audioFrame->getCaptionTracks()->get_Item($trackIndex);
                // 각 캡션 트랙을 .vtt 파일로 저장합니다.
                $filePath = $captionTrack->getCaptionId() . ".vtt";
                file_put_contents($filePath, $captionTrack->getBinaryData());
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

**Remove Audio Captions**

오디오 프레임에서 캡션을 제거하려면 [CaptionsCollection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/)에서 제공하는 메서드([clear](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#clear), [remove](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#remove), [removeAt](https://reference.aspose.com/slides/ko/php-java/aspose.slides/captionscollection/#removeAt) 등)를 사용합니다. 다음 예제는 오디오 프레임의 모든 캡션 트랙을 제거합니다.
```php
$presentation = new Presentation($folderPath . "audio_with_captions.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $audioFrame = $slide->getShapes()->get_Item(0); // 형식: AudioFrame

    // 오디오 프레임에서 모든 캡션 트랙을 제거합니다.
    $audioFrame->getCaptionTracks()->clear();

    $presentation->save($folderPath . "audio_without_captions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **오디오 추출**

Aspose.Slides for PHP via Java를 사용하면 슬라이드 쇼 전환에 사용된 사운드를 추출할 수 있습니다. 예를 들어 특정 슬라이드에 사용된 사운드를 추출할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성하고 오디오가 포함된 프레젠테이션을 로드합니다.
2. 인덱스를 통해 해당 슬라이드의 참조를 가져옵니다.
3. 슬라이드의 [slideshow transitions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/#getSlideShowTransition)에 접근합니다.
4. 바이트 데이터로 사운드를 추출합니다.

이 코드는 슬라이드에 사용된 오디오를 추출하는 방법을 보여줍니다:
```php
# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
$pres = new Presentation("AudioSlide.pptx");
$Array = new java_class("java.lang.reflect.Array");
try {
	# 원하는 슬라이드에 접근합니다
	$slide = $pres->getSlides()->get_Item(0);
	# 슬라이드의 슬라이드쇼 전환 효과를 가져옵니다
	$transition = $slide->getSlideShowTransition();
	# 사운드를 바이트 배열로 추출합니다
	$audio = $transition->getSound()->getBinaryData();
	echo("Length: " . $Array->getLength($audio));
} finally {
	if (!java_is_null($pres)) {
		$pres->dispose();
	}
}
```

## **FAQ**

**여러 슬라이드에서 동일한 오디오 자산을 재사용하면서 파일 크기가 증가하지 않나요?**

예. 오디오를 프레젠테이션의 공유 [audio collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getaudios/)에 한 번 추가하고, 해당 자산을 참조하는 추가 오디오 프레임을 만들면 됩니다. 이렇게 하면 미디어 데이터가 중복되지 않아 프레젠테이션 크기를 제어할 수 있습니다.

**기존 오디오 프레임의 사운드를 형태를 다시 만들지 않고 교체할 수 있나요?**

예. 연결된 사운드의 경우 새 파일을 가리키도록 [link path](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/setlinkpathlong/)를 업데이트합니다. 삽입된 사운드의 경우 프레젠테이션의 [audio collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getaudios/)에서 다른 [embedded audio](https://reference.aspose.com/slides/ko/php-java/aspose.slides/audioframe/setembeddedaudio/) 객체로 교체합니다. 프레임의 서식 및 대부분의 재생 설정은 그대로 유지됩니다.

**트리밍이 프레젠테이션에 저장된 기본 오디오 데이터를 변경합니까?**

아니요. 트리밍은 재생 범위만 조정하고, 원본 오디오 바이트는 그대로 유지되며 삽입된 오디오나 프레젠테이션의 오디오 컬렉션을 통해 접근할 수 있습니다.