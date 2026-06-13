---
title: 오디오
type: docs
weight: 70
url: /ko/php-java/examples/elements/audio/
keywords:
- 오디오
- 오디오 프레임
- 오디오 추가
- 오디오 접근
- 오디오 제거
- 오디오 재생
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 오디오 작업: 사운드를 추가, 교체, 추출 및 트림하고, PowerPoint와 OpenDocument의 슬라이드 및 도형에 대한 볼륨과 재생을 설정합니다."
---
오디오 프레임을 삽입하고 재생을 제어하는 방법을 **Aspose.Slides for PHP via Java**를 사용하여 보여줍니다. 다음 예제에서는 기본 오디오 작업을 설명합니다.

## **오디오 프레임 추가**

오디오 프레임을 삽입합니다.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 오디오 프레임을 생성합니다.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **오디오 프레임 액세스**

이 코드는 슬라이드의 첫 번째 오디오 프레임을 가져옵니다.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드에서 첫 번째 오디오 프레임에 접근합니다.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **오디오 프레임 제거**

이전에 추가된 오디오 프레임을 삭제합니다.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 오디오 프레임이라고 가정합니다.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 오디오 프레임을 제거합니다.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **오디오 재생 설정**

슬라이드가 표시될 때 오디오 프레임이 자동으로 재생되도록 구성합니다.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 슬라이드의 첫 번째 도형이 오디오 프레임이라고 가정합니다.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // 슬라이드가 나타날 때 자동으로 재생합니다.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```