---
title: PHP에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드 SVG 변환
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

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리 등에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 작성되는 방식을 제어할 수 있게 합니다.

내보낸 SVG가 작고, 브라우저 간에 예측 가능하며, 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)을 사용하십시오.

## **슬라이드를 SVG로 내보내기**

새 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)을 만들고 슬라이드를 선택한 다음 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg)을 사용해 스트림에 씁니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 개별 SVG 파일로 내보냅니다.

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

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber)을(를) 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 형태만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg)을 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)은 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize)은 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation)은 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures)을 `true`로 설정하십시오.

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

슬라이드를 SVG로 내보낼 때 텍스트가 텍스트 형태로 유지될지 벡터 그래픽으로 변환될지, 외부 글꼴이 포함되거나 참조되는 방식을 제어할 수 있습니다. 다음 옵션은 내보낸 SVG에서 시각적 일관성, 텍스트 선택 및 글꼴 종속성을 균형 있게 맞추는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)을 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 씁니다. 이렇게 하면 글꼴 종속성이 없어지고 브라우저 간에 시각적 결과가 보다 일관되지만, 텍스트는 더 이상 SVG 텍스트로 선택하거나 검색할 수 없습니다.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) 은 외부에서 로드된 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택하십시오. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

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

## **내장 이미지 크기 감소**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression)을 사용하여 내장 그림의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)으로 자른 원본 영역을 제외하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality)으로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질 또는 보존된 이미지 데이터를 희생하면서 파일 크기를 줄입니다.

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

## **메타파일 래스터화 해상도 제어**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/)은 SVG 내보내기 중 메타파일을 래스터화할 때 하한 해상도를 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 상세도와 파일 크기를 균형 있게 맞추기 위해 사용합니다. 이는 SVG에 대한 전역 DPI를 정의하거나 슬라이드의 모든 객체가 래스터 이미지가 되도록 강제하지 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx) 파일을 다운로드하십시오. 이 파일에는 대각선 선이 촘촘히 배치된 EMF 이미지가 포함되어 있습니다. 다음 예제는 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/)를 통해 첫 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

출력에서 EMF는 각 SVG에 하나의 내장 PNG로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며, DPI를 픽셀 크기로 변환하는 일반적인 공식은 아닙니다.

| 메타파일 래스터화 DPI | 내장 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 확대된 동일한 표시 크기에서 내장 래스터의 동일 영역을 보여줍니다. 대각선 선은 72 DPI에서 눈에 띄는 픽셀화가 나타나고, 높은 해상도에서는 가장자리가 더 부드러워지며 SVG 파일 크기도 증가합니다. 값을 높인다고 해서 모든 세부 사항이 개선되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150 및 300 DPI에서 확대된 대각선 선 상세](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/)은 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **도형 및 텍스트에 안정적인 ID 할당**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)에 포맷팅 콜백을 제공하여 각 SVG 도형에 대해 [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId)를 설정합니다. 콜백은 텍스트 `tspan` 요소에 대해 [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) 값을 설정할 수도 있습니다.

PhpJavaBridge가 스트림 모드에서 실행될 때 `writeAsSvg`에서 PHP 콜백을 호출할 수 없습니다. 포맷팅 로직을 작은 Java 헬퍼 클래스에 넣고 컴파일한 뒤 해당 JAR 파일을 브리지 클래스 경로에 추가하십시오. 헬퍼는 도형 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)을 사용할 수 있으며, 텍스트 스팬에 대한 반복 가능한 카운터를 사용할 수 있습니다. 헬퍼 코드는 [Java implementation of `StableSvgIdController`](/slides/ko/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)에서 확인하십시오.

컴파일된 `com.example.slides.StableSvgIdController` 클래스를 브리지 클래스 경로에 추가한 후, PHP에서 인스턴스화하고 `SVGOptions`에 할당하십시오:

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

포맷팅 콜백에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler)에 [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) 값을 전달하여 내보낸 도형에 JavaScript 이벤트 핸들러를 추가합니다. 콜백은 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)에 할당하고, 결과를 포함하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

안정적인 ID와 마찬가지로, PhpJavaBridge가 스트림 모드를 사용할 때 콜백을 Java 헬퍼에서 구현하십시오. [Java implementation of `SvgEventController`](/slides/ko/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers)는 `ActionButton`이라는 도형에 ID와 `OnClick` 핸들러를 할당합니다. 해당 헬퍼를 컴파일하고 `com.example.slides.SvgEventController`로 브리지 클래스 경로에 추가한 뒤, PHP에서 다음과 같이 사용하십시오:

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

호스트 페이지에서 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 지원합니다.

## **자주 묻는 질문**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) 대신 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)를 사용해야 합니까?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)는 모든 텍스트가 글꼴과 무관해야 할 때 사용하십시오. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)는 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 때 사용하십시오.

**SVG 파일을 작게 만드는 가장 좋은 방법은 무엇입니까?**

먼저 내장 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기 사이에 다른 트레이드오프가 있으므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 콜백을 통해 ID를 할당한 후, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.