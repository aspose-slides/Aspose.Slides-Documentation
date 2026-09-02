---
title: PHP에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/php-java/manage-ink/
keywords:
- 잉크
- 잉크 개체
- 잉크 트레이스
- 잉크 관리
- 잉크 그리기
- 그리기
- 잉크 내보내기
- 잉크 렌더링
- 잉크 숨기기
- InkOptions
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PowerPoint 잉크 개체를 관리하고, 트레이스와 브러시 속성을 편집하며, Aspose.Slides for PHP via Java를 사용하여 PDF, HTML, SVG, TIFF 및 이미지 내보내기 시 잉크 외관을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하거나 연결 및 프로세스를 표시하고 슬라이드의 특정 항목에 주의를 끌 때 사용할 수 있습니다.

Aspose.Slides는 잉크 개체를 다루는 데 필요한 유형을 제공합니다. 예를 들어, [Ink](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ink/) 클래스는 슬라이드의 잉크 개체를 나타냅니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 [Shape](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/) 개체로 표현됩니다. 가장 단순한 형태에서 모양은 개체 자체(프레임)의 영역을 정의하는 컨테이너이며, 컨테이너 크기, 모양 및 배경과 같은 속성을 가집니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/php-java/shape-manipulations/#access-layout-formats-for-shape)을 참조하십시오.

그러나 PowerPoint가 잉크 개체를 처리할 때는 크기를 제외한 개체 프레임(컨테이너)의 모든 속성을 무시합니다. 컨테이너 영역의 크기는 표준 [Shape.getWidth](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getWidth) 및 [Shape.getHeight](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getHeight) 메서드에 의해 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 순서를 저장합니다.

가장 단순한 인코딩 형태는 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기를 위한 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시는 자체 색상과 크기를 가지며, 이는 [InkBrush.getColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkbrush/#getColor) 및 [InkBrush.getSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkbrush/#getSize) 메서드로 표현됩니다.

### **잉크 브러시 색상 설정**

다음 PHP 코드는 잉크 브러시 색상을 설정하는 방법을 보여줍니다:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **잉크 브러시 크기 설정**

다음 PHP 코드는 잉크 브러시 크기를 설정하는 방법을 보여줍니다:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

일반적으로 브러시의 너비와 높이는 일치하지 않아 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색으로 표시됨). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 개체의 높이를 늘리고 중요한 치수를 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시의 크기를 고려하지 않으며—항상 선 두께가 0이라고 가정합니다(이전 이미지를 참조).

따라서 전체 잉크 개체의 가시 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손글씨 텍스트 트레이스)는 컨테이너(프레임)의 크기로 확대되었습니다. 컨테이너 크기가 변하면 브러시 크기는 일정하게 유지되고, 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 개체에도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 중 잉크 외관 제어**

Aspose.Slides는 [InkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/) 클래스를 제공하여 잉크 개체가 내보내기 또는 렌더링 결과에 어떻게 표시되는지 제어할 수 있습니다. 해당 속성을 사용하여 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산이 해석되는 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 유형에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 속성 |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/#getInkOptions) |

다음 [InkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/) 메서드는 동일한 두 설정을 노출합니다:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#getHideInk) 은 잉크 개체가 출력에 포함되는지를 결정합니다. 기본값은 `false`입니다.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 은 잉크 브러시를 렌더링할 때 마스크 연산을 투명도로 해석할지를 결정합니다. 기본값은 `true`이며, `false` 로 호출하면 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 개체 숨기기**

기본적으로 잉크 개체는 내보내기 시 표시됩니다. 손글씨 주석이나 기타 잉크 콘텐츠 없이 깔끔한 출력을 만들려면 [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#setHideInk) 을 `true` 로 호출하십시오.

다음 PHP 예제는 모든 잉크 개체를 숨긴 상태로 프레젠테이션을 PDF로 내보냅니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **슬라이드를 이미지로 렌더링할 때 잉크 개체 숨기기**

비트맵 이미지로 슬라이드를 렌더링할 때 잉크 개체를 숨기려면 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/renderingoptions/#getInkOptions) 를 구성하고 해당 렌더링 옵션을 [Slide.getImage](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getImage) 에 전달하십시오.

다음 PHP 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 개체를 제외합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **잉크 마스크 렌더링 제어**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) 설정은 잉크 브러시를 렌더링할 때 마스크 연산이 어떻게 해석되는지를 제어합니다. 기본값은 `true`이며, 이는 투명도를 사용한다는 의미입니다. 대신 ROP 연산을 사용하려면 `false` 로 호출하십시오.

다음 PHP 예제는 슬라이드를 SVG로 내보내면서 잉크 마스크 연산에 ROP 기반 렌더링을 적용합니다:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

동일한 설정은 프레젠테이션을 내보내거나 슬라이드를 TIFF로 렌더링할 때 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/tiffoptions/#getInkOptions) 를 통해 적용할 수 있습니다.

### **잉크를 숨길지 유지할지 선택**

주석이 포함된 프레젠테이션을 검토 표시 없이 배포용으로 깔끔하게 만들고 싶다면 내보내기 시 [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#setHideInk) 을 `true` 로 호출하십시오.

잉크 주석이 의도된 콘텐츠(예: 검토 의견, 손글씨 메모, 강조 표시 또는 표시되어야 하는 그림)의 일부인 경우에는 [InkOptions.getHideInk](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#getHideInk) 을 기본값인 `false` 로 유지하십시오. 이렇게 하면 소스 잉크 개체를 수정하지 않고도 동일한 프레젠테이션에서 별도의 검토 및 최종 출력을 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [Ink.getTraces](https://reference.aspose.com/slides/ko/php-java/aspose.slides/ink/#getTraces) 로 트레이스를 가져온 후 [InkTrace.getBrush](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inktrace/#getBrush) 를 변경하십시오. [InkBrush.setColor](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkbrush/#setColor) 또는 [InkBrush.setSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkbrush/#setSize) 을 호출하면 브러시를 변경할 수 있습니다.

**잉크를 숨기면 소스 프레젠테이션이 변경되나요?**

아니요. [InkOptions.setHideInk](https://reference.aspose.com/slides/ko/php-java/aspose.slides/inkoptions/#setHideInk) 호출은 렌더링 또는 내보내기 결과에만 영향을 미치며, 소스 프레젠테이션의 잉크 개체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

위에 표시된 대로 PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지에 대해 해당 내보내기 또는 렌더링 옵션을 통해 잉크 옵션을 구성할 수 있습니다.

**추가 읽을거리**

* 일반적인 도형에 대해 알아보려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/php-java/powerpoint-shapes/) 섹션을 참조하십시오.
* 유효값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/php-java/shape-effective-properties/#get-effective-font-height-value)를 확인하십시오.
* PDF 내보내기에 대한 자세한 내용은 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/php-java/convert-powerpoint-to-pdf/)를 보십시오.
* HTML 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/php-java/convert-powerpoint-to-html/)를 보십시오.
* SVG 내보내기에 대한 자세한 내용은 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/php-java/render-a-slide-as-an-svg-image/)를 보십시오.
* TIFF 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/php-java/convert-powerpoint-to-tiff/)를 보십시오.
* 슬라이드 이미지 렌더링에 대한 자세한 내용은 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/php-java/convert-slide/)를 보십시오.