---
title: PHP에서 PowerPoint 프레젠테이션을 TIFF로 변환
titlelink: PowerPoint를 TIFF로
type: docs
weight: 90
url: /ko/php-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP 를 Java를 통해 사용하여 PowerPoint(PPT, PPTX) 프레젠테이션을 고품질 TIFF 이미지로 쉽게 변환하는 방법을 코드 예제와 함께 배우세요."
---
## **소개**

TIFF (**Tagged Image File Format**)는 뛰어난 품질과 그래픽을 상세히 보존하는 것으로 알려진 널리 사용되는 무손실 래스터 이미지 형식입니다. 디자이너, 사진작가 및 데스크톱 출판자는 종종 이미지에서 레이어, 색 정확도 및 원본 설정을 유지하기 위해 TIFF를 선택합니다.

Aspose.Slides를 사용하면 PowerPoint 슬라이드(PPT, PPTX)와 OpenDocument 슬라이드(ODP)를 고품질 TIFF 이미지로 손쉽게 변환할 수 있어 프레젠테이션이 최대한의 시각적 충실도를 유지합니다. 

## **프레젠테이션을 TIFF로 변환**

제공되는 [save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 메서드와 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스를 사용하면 전체 PowerPoint 프레젠테이션을 빠르게 TIFF로 변환할 수 있습니다. 생성된 TIFF 이미지는 기본 슬라이드 크기에 해당합니다.

다음 코드는 PowerPoint 프레젠테이션을 TIFF로 변환하는 방법을 보여줍니다:

```php
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("presentation.pptx");
try {
    // 프레젠테이션을 TIFF로 저장합니다.
    $presentation->save("output.tiff", SaveFormat::Tiff);
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션을 흑백 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 클래스의 [setBwConversionMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#setBwConversionMode) 메서드는 컬러 슬라이드나 이미지를 흑백 TIFF로 변환할 때 사용할 알고리즘을 지정할 수 있습니다. 이 설정은 [setCompressionType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#getCompressionType) 메서드가 `CCITT4` 또는 `CCITT3` 로 설정된 경우에만 적용됩니다.

{{% alert color="info" title="Note" %}}
[TiffOptions::setBwConversionMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#setBwConversionMode) 은 전체 TIFF 이미지에 대한 픽셀 변환 알고리즘을 선택하는 내보내기 수준 설정입니다. 흑백 표시 모드가 활성화된 경우 개별 도형이 어떻게 표시될지 정의하려면 [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#setBlackWhiteMode)를 사용하십시오. 예제는 [Control Black-and-White Rendering for Shapes](/php-java/shape-formatting/#control-black-and-white-rendering-for-shapes) 를 참고하십시오.
{{% /alert %}}

예를 들어 다음 슬라이드가 포함된 "sample.pptx" 파일이 있다고 가정해 보겠습니다:

![프레젠테이션 슬라이드](slide_black_and_white.png)

다음 코드는 컬러 슬라이드를 흑백 TIFF로 변환하는 방법을 보여줍니다:

```php
$tiffOptions = new TiffOptions();
$tiffOptions->setCompressionType(TiffCompressionTypes::CCITT4);
$tiffOptions->setBwConversionMode(BlackWhiteConversionMode::Dithering);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

결과:

![흑백 TIFF](TIFF_black_and_white.png)

## **사용자 지정 크기로 프레젠테이션을 TIFF로 변환**

특정 크기의 TIFF 이미지가 필요하면 [TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 에서 제공되는 메서드를 사용하여 원하는 값을 설정할 수 있습니다. 예를 들어, [setImageSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#getImageSize) 메서드는 생성된 이미지의 크기를 정의할 수 있게 해줍니다.

다음 코드는 사용자 지정 크기로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:

```php
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    // 압축 유형을 설정합니다.
    $tiffOptions->setCompressionType(TiffCompressionTypes::Default);
    /*
    압축 유형:
        Default - 기본 압축 방식(LZW)을 지정합니다.
        None - 압축을 사용하지 않음을 지정합니다.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 깊이는 압축 유형에 따라 결정되며 수동으로 설정할 수 없습니다.

    // 이미지 DPI를 설정합니다.
    $tiffOptions->setDpiX(200);
    $tiffOptions->setDpiY(200);

    // 이미지 크기를 설정합니다.
    $tiffOptions->setImageSize(new Java("java.awt.Dimension", 1728, 1078));

    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // 지정된 크기로 프레젠테이션을 TIFF로 저장합니다.
    $presentation->save("tiff-ImageSize.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

## **사용자 지정 이미지 픽셀 형식으로 프레젠테이션을 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/) 클래스의 [setPixelFormat](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#getPixelFormat) 메서드를 사용하면 결과 TIFF 이미지에 원하는 픽셀 형식을 지정할 수 있습니다.

다음 코드는 사용자 지정 픽셀 형식으로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:

```php
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
$presentation = new Presentation("presentation.pptx");
try {
    $tiffOptions = new TiffOptions();

    $tiffOptions->setPixelFormat(ImagePixelFormat::Format8bppIndexed);
    /*
    ImagePixelFormat은 다음 값을 포함합니다(문서에 명시된 대로):
        Format1bppIndexed - 픽셀당 1비트, 인덱스 색상.
        Format4bppIndexed - 픽셀당 4비트, 인덱스 색상.
        Format8bppIndexed - 픽셀당 8비트, 인덱스 색상.
        Format24bppRgb    - 픽셀당 24비트, RGB.
        Format32bppArgb   - 픽셀당 32비트, ARGB.
    */

    // 지정된 이미지 크기로 프레젠테이션을 TIFF로 저장합니다.
    $presentation->save("Tiff-PixelFormat.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose의 [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **FAQ**

**전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드를 TIFF로 변환할 수 있나요?**

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

**프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?**

아니오, Aspose.Slides는 슬라이드 수에 제한을 두지 않습니다. 크기에 관계없이 모든 프레젠테이션을 TIFF 형식으로 변환할 수 있습니다.

**PowerPoint 애니메이션 및 전환 효과가 슬라이드를 TIFF로 변환할 때 보존되나요?**

아니오, TIFF는 정적 이미지 형식입니다. 따라서 애니메이션 및 전환 효과는 보존되지 않으며 슬라이드의 정적 스냅샷만 내보내집니다.