---
title: PHP에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint를 SVG로
- 프레젠테이션을 SVG로
- 슬라이드를 SVG로
- PPT를 SVG로
- PPTX를 SVG로
- SVG 내보내기 옵션
- 인터랙티브 SVG
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로, 자동 후처리 등에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 파일 크기가 작고 브라우저 간에 일관되며 인터랙티브하게 사용될 준비가 되어 있어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/)을 만들고 슬라이드를 선택한 후 [Slide.writeAsSvg](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#writeAsSvg)으로 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 개별 SVG 파일로 내보냅니다.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/#getSlideNumber)을 사용합니다. 슬라이드 뷰어 또는 웹 페이지에서 특정 도형만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#writeAsSvg)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setUseFrameSize)를 사용하면 텍스트 프레임이 렌더링 영역에 포함되고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setUseFrameRotation)는 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `true`로 설정하십시오.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **텍스트 및 글꼴 제어**

### **전체 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setVectorizeText)를 `true`로 설정하면 모든 슬라이드 텍스트가 벡터 그래픽으로 기록됩니다. 이렇게 하면 글꼴 의존성이 사라지고 브라우저 간 시각적 결과가 보다 일관되지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **외부 글꼴 처리 방식 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setExternalFontsHandling)는 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. `AddLinksToFontFiles`를 선택하면 별도 글꼴 파일을 참조하고, `Embed`를 선택하면 글꼴 데이터를 SVG에 포함하며, `Vectorize`를 선택하면 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링합니다. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **내장 이미지 크기 축소**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setPicturesCompression)를 사용해 내장 그림의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)를 사용해 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setJpegQuality)를 사용해 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 파일 크기를 줄이지만 이미지 충실도 또는 보존되는 이미지 데이터가 감소할 수 있습니다.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **도형 및 텍스트에 안정적인 ID 할당**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setShapeFormattingController)에 포맷팅 콜백을 제공하여 각 SVG 도형에 대해 [SvgShape.setId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgshape/#setId)를 설정합니다. 콜백은 텍스트 `tspan` 요소에 대해 [SvgTSpan.setId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgtspan/#setId) 값을 설정할 수도 있습니다.

PhpJavaBridge는 스트림 모드에서 `writeAsSvg`가 실행될 때 PHP 콜백을 호출할 수 없습니다. 포맷팅 로직을 작은 Java 헬퍼 클래스로 구현하고 컴파일한 뒤, 결과 JAR 파일을 브리지 클래스패스에 추가하십시오. 헬퍼는 도형 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/php-java/aspose.slides/shape/#getOfficeInteropShapeId)를 사용하고, 텍스트 스팬에 대해 반복 가능한 카운터를 사용합니다. 헬퍼 코드는 [Java implementation of `StableSvgIdController`](/slides/ko/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)를 참조하십시오.

컴파일된 `com.example.slides.StableSvgIdController` 클래스를 브리지 클래스패스에 추가한 뒤, PHP에서 인스턴스화하고 `SVGOptions`에 할당하십시오.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **SVG 이벤트 핸들러 추가**

포맷팅 콜백에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgshape/#setEventHandler)에 [SvgEvent](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgevent/) 값을 지정하면 내보낸 도형에 JavaScript 이벤트 핸들러를 추가할 수 있습니다. 콜백은 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setShapeFormattingController)로 할당하고, 결과를 호스팅하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

안정적인 ID와 마찬가지로, PhpJavaBridge가 스트림 모드를 사용할 때는 Java 헬퍼에서 콜백을 구현해야 합니다. [Java implementation of `SvgEventController`](/slides/ko/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers)는 `ActionButton`이라는 도형에 ID와 `OnClick` 핸들러를 할당합니다. 해당 헬퍼를 컴파일하고 `com.example.slides.SvgEventController`로 브리지 클래스패스에 추가한 뒤, PHP에서 다음과 같이 사용하십시오:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 지원할 수 있습니다.

## **FAQ**

**[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setVectorizeText)를 언제 사용하고, [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgexternalfontshandling/) 대신 사용해야 합니까?**

모든 텍스트가 글꼴에 독립적이어야 할 경우 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgoptions/#setVectorizeText)를 사용하십시오. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/php-java/aspose.slides/svgexternalfontshandling/)를 사용하십시오.

**SVG 파일을 더 작게 만들기 위한 가장 좋은 방법은 무엇입니까?**

먼저 내장 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기 사이의 트레이드오프가 다르므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 콜백을 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하여 수정할 수 있습니다.