---
title: PHP에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/php-java/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 뒤 개별 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 배율로 렌더링하고, 배율을 증가시키며, 출력 크기를 픽셀 단위로 지정하고, 그라디언트 렌더링 스타일을 선택하는 방법을 보여줍니다.

## **PowerPoint를 PNG로 변환**

프레젠테이션을 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 클래스로 로드하고, [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) 컬렉션을 통해 슬라이드에 접근합니다. 예제에서는 매 슬라이드를 매개변수 없이 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)으로 렌더링하여 썸네일을 만든 뒤, [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png)와 함께 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)를 호출해 렌더링된 각 슬라이드를 PNG 이미지로 저장합니다.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) 오버로드는 배율 0.2로 렌더링합니다. 예를 들어, 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래와 같이 배율 인자나 명시적인 이미지 크기를 사용하는 오버로드를 사용하십시오.
{{% /alert %}}

## **사용자 지정 배율로 PowerPoint를 PNG로 변환**

[Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)에 가로 및 세로 배율 인자를 전달하여 렌더링 크기를 제어합니다. 이 예제에서는 두 배율이 모두 2이므로, 720 × 540 포인트 슬라이드는 1440 × 1080 픽셀 이미지가 됩니다. 동일한 배율을 사용하면 슬라이드의 가로세로 비율이 유지됩니다. 각 이미지는 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)를 사용하여 PNG 형식으로 저장됩니다.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **사용자 지정 크기로 PowerPoint를 PNG로 변환**

픽셀 단위의 출력 크기를 지정하려면 배율 대신 크기를 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)에 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save)로 결과를 저장합니다. 이미지가 늘어나지 않도록 슬라이드의 가로세로 비율에 맞는 크기를 선택하십시오.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만, 내보낸 PNG에서의 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 표시된다고 가정해 보겠습니다. [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/)에서 상속받은 [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) 메서드를 사용하여 그라디언트가 렌더링되는 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx)를 다운로드하여 애플리케이션 작업 디렉터리에 넣습니다. 첫 번째 슬라이드에는 상단에 청록색에서 주황색으로, 하단에 파랑에서 노랑으로 변하는 두 개의 선형 그라디언트가 있습니다. 각 그라디언트는 0%와 100%에 두 개의 스톱을 가지고 있습니다.

다음 예제는 이 프레젠테이션을 로드하고 [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage)으로 두 모드 모두에서 동일한 첫 번째 슬라이드를 렌더링합니다.

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

아래 이미지들은 동일한 슬라이드의 출력 결과이며, 각 이미지에 두 개의 그라디언트가 모두 포함되어 있습니다:

| Default | PowerPointUI |
| --- | --- |
| ![Default 로 렌더링된 청록색‑주황색 및 파랑‑노랑 그라디언트](gradient-Default.png) | ![PowerPointUI 로 렌더링된 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 표시되고, `PowerPointUI`는 중간 색상이 더 어둡게 표시됩니다. 차이는 그라디언트의 색상 및 스톱에 따라 달라집니다.

표준 Aspose.Slides 출력이 요구 사항에 맞으면 `Default`를 선택하십시오. PowerPoint와 외관을 일치시키는 것이 우선인 경우 `PowerPointUI`를 사용해 보세요. 두 출력 결과를 원하는 결과와 비교해 보시기 바랍니다; 어느 모드도 절대적으로 우수한 것은 아닙니다.

## **FAQ**

**전체 슬라이드가 아니라 차트나 그림 등 특정 도형만 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/php-java/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환을 지원하나요?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오; [스레드 간 단일 인스턴스 공유 금지](/slides/ko/php-java/multithreading/)입니다.

**PNG로 내보낼 때 평가판 제한은 무엇인가요?**

평가판 모드에서는 출력 이미지에 워터마크가 추가되고, [기타 제한 사항](/slides/ko/php-java/licensing/)이 적용됩니다.