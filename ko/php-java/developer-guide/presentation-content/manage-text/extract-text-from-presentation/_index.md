---
title: PHP에서 프레젠테이션의 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/php-java/extract-text-from-presentation/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 가져오기
- 슬라이드에서 텍스트 가져오기
- 프레젠테이션에서 텍스트 가져오기
- PowerPoint에서 텍스트 가져오기
- OpenDocument에서 텍스트 가져오기
- PPT에서 텍스트 가져오기
- PPTX에서 텍스트 가져오기
- ODP에서 텍스트 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java를 사용하여 PowerPoint와 OpenDocument 프레젠테이션에서 텍스트를 빠르게 추출하세요. 간단하고 단계별 가이드를 따라 시간을 절약하십시오."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 흔하면서도 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 접근하고 가져오는 것은 분석, 자동화, 색인 작성 또는 콘텐츠 마이그레이션 등에서 핵심이 될 수 있습니다.

이 문서에서는 Aspose.Slides for PHP via Java를 사용하여 PPT, PPTX 및 ODP와 같은 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 반복하면서 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for PHP via Java는 [SlideUtil](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/) 클래스를 제공합니다. 이 클래스는 프레젠테이션이나 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 노출합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [getAllTextBoxes](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/#getAllTextBoxes) 메서드를 사용합니다. 이 메서드는 [BaseSlide](https://reference.aspose.com/slides/ko/php-java/aspose.slides/baseslide/) 유형의 객체를 매개변수로 받습니다. 실행 시 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾아 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 유형의 객체 배열을 반환하며, 텍스트 서식도 그대로 유지됩니다.

다음 코드 스니펫은 프레젠테이션의 첫 번째 슬라이드에서 모든 텍스트를 추출합니다:

```php
$slideIndex = 0;

$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $slide = $presentation->getSlides()->get_Item($slideIndex);

    $textFrames = SlideUtil::getAllTextBoxes($slide);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션에서 텍스트를 스캔하려면 [SlideUtil](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/) 클래스가 노출하는 [getAllTextFrames](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slideutil/#getAllTextFrames) 정적 메서드를 사용합니다. 이 메서드는 두 개의 매개변수를 받습니다:

1. 첫 번째, PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 객체.
1. 두 번째, 마스터 슬라이드를 포함하여 텍스트를 스캔할지 여부를 나타내는 `boolean` 값.

이 메서드는 [TextFrame](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textframe/) 유형의 객체 배열을 반환하며, 텍스트 서식 정보를 포함합니다. 아래 코드는 프레젠테이션과 마스터 슬라이드를 포함한 텍스트와 서식 세부 정보를 스캔합니다.

```php
$presentation = new Presentation("demo.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $includeMasterSlides = true;
    $textFrames = SlideUtil::getAllTextFrames($presentation, $includeMasterSlides);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        foreach ($textFrames[$textFrameIndex]->getParagraphs() as $paragraph) {
            foreach ($paragraph->getPortions() as $portion) {
                $portionText = $portion->getText();
                echo($portionText);

                $portionFormat = $portion->getPortionFormat();
                $fontHeight = $portionFormat->getFontHeight();
                echo($fontHeight);

                $latinFont = $portionFormat->getLatinFont();
                if (!java_is_null($latinFont)) {
                    $fontName = $latinFont->getFontName();
                    echo($fontName);
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **분류 및 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationfactory/) 클래스는 또한 프레젠테이션에서 모든 텍스트를 추출하는 메서드를 제공합니다:

```php
PresentationText getPresentationText(String, int);
PresentationText getPresentationText(InputStream, int);
PresentationText getPresentationText(InputStream, int, LoadOptions);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/textextractionarrangingmode/) 열거형 인자는 텍스트 추출 결과를 조직하는 방식을 나타내며 다음 값으로 설정할 수 있습니다:
- `Unarranged` - 슬라이드상의 위치와 무관한 원시 텍스트.
- `Arranged` - 텍스트가 슬라이드와 동일한 순서대로 정렬됩니다.

속도가 중요한 경우 정렬되지 않은 모드를 사용할 수 있으며, 정렬된 모드보다 빠릅니다.

[PresentationText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationtext/)는 프레젠테이션에서 추출한 원시 텍스트를 나타냅니다. 그 `getSlidesText` 메서드는 각 객체가 해당 슬라이드의 텍스트를 나타내는 객체 배열을 반환합니다. 각 반환된 객체는 다음 메서드를 포함합니다:

- `getText` - 슬라이드의 도형에 포함된 텍스트.
- `getMasterText` - 이 슬라이드와 연결된 마스터 슬라이드 도형에 포함된 텍스트.
- `getLayoutText` - 이 슬라이드와 연결된 레이아웃 슬라이드 도형에 포함된 텍스트.
- `getNotesText` - 이 슬라이드와 연결된 노트 슬라이드 도형에 포함된 텍스트.
- `getCommentsText` - 이 슬라이드와 연결된 주석에 포함된 텍스트.

```php
$presentationPath = "presentation.ppt";
$arrangingMode = TextExtractionArrangingMode::Unarranged;
$presentationText = PresentationFactory::getInstance()->getPresentationText($presentationPath, $arrangingMode);
$slidesText = $presentationText->getSlidesText();
$firstSlideText = $slidesText[0];

echo($firstSlideText->getText());
echo($firstSlideText->getLayoutText());
echo($firstSlideText->getMasterText());
echo($firstSlideText->getNotesText());
echo($firstSlideText->getCommentsText());
```

## **FAQ**

**Aspose.Slides는 대형 프레젠테이션을 텍스트 추출할 때 얼마나 빠른가요?**

Aspose.Slides는 고성능을 위해 최적화되어 있으며, [large presentations](/slides/ko/php-java/open-presentation/)도 처리할 수 있어 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides는 프레젠테이션 내 테이블 및 차트에서 텍스트를 추출할 수 있나요?**

예. Aspose.Slides는 테이블 및 차트 관련 객체를 포함한 많은 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 체험 버전의 Aspose.Slides를 사용해 텍스트를 추출할 수 있지만, [certain limitations](/slides/ko/php-java/licensing/)처럼 제한된 슬라이드 수만 처리할 수 있습니다. 제한 없이 사용하고 대형 프레젠테이션을 다루려면 전체 라이선스를 구매하는 것이 권장됩니다.