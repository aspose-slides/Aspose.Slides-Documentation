---
title: PHP에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
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
- 대화형 SVG
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "PHP에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 작성되는 방식을 제어할 수 있게 합니다.

내보낸 SVG가 작고, 브라우저 간에 일관되며, 대화형 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

프레젠테이션을 만들고([Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)), 슬라이드를 선택한 다음 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg)를 사용하여 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별도의 SVG 파일로 내보냅니다.

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

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber)을 사용합니다. 슬라이드 뷰어 또는 웹 페이지에서 해당 모양만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg)를 사용하여 개별 모양을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize)는 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation)는 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 때는 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `true`로 설정하십시오.

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

## **화살표 머리의 선 끝 자르기 제어**

SVG 1.1에는 화살표 머리 아래에서 선이 멈추는 위치를 지정하는 마커 inset 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선을 단축하여 스트로크가 마커를 통과하지 않도록 합니다. [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/)에 `true`를 전달하면 스트로크가 선의 원래 끝점까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미칩니다. 슬라이드에서 선은 위치와 길이를 유지합니다.

예제는 2포인트와 10포인트 폭의 선에 삼각형 및 다이아몬드 화살표 머리를 그립니다. 크롭 옵션만을 변경하여 동일한 슬라이드를 두 번 내보냅니다.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

비교를 통해 10포인트 선의 삼각형 화살표 머리를 확인할 수 있습니다. 크롭이 활성화된 경우 팁이 날카롭고, 비활성화된 경우 스트로크가 마커의 경사면을 뚫고 평평한 끝을 남깁니다.

![크롭 활성 시 날카로운 팁을 가진 확대된 10포인트 삼각형과 크롭 비활성 시 평평한 끝](line-end-cropping.png)

예제의 다른 선에서는 2포인트 삼각형에서 돌출된 스트로크가 덜 눈에 띕니다. 채워진 다이아몬드는 두 폭 모두에서 스트로크 끝을 가립니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지하거나 벡터 그래픽으로 변환할지, 외부 글꼴을 포함하거나 참조할지를 제어할 수 있습니다. 다음 옵션은 내보낸 SVG의 시각적 일관성, 텍스트 선택 가능성 및 글꼴 종속성을 균형 있게 조정하는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 종속성이 사라지고 브라우저 전반에 걸쳐 시각적 결과가 더 일관되지만, 텍스트는 더 이상 SVG 텍스트로 선택하거나 검색할 수 없습니다.

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

### **외부 글꼴 처리 방법 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택하십시오. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

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

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression)을 사용하여 내장 사진의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas)으로 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality)으로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 보존된 이미지 데이터의 희생을 대가로 파일 크기를 줄입니다.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/)는 SVG 내보내기 중 메타파일을 래스터화할 때 하한 해상도를 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 세부 사항과 파일 크기의 균형을 맞추는 데 사용합니다. 이는 SVG 전체에 대한 DPI를 정의하거나 슬라이드의 모든 개체를 래스터 이미지로 변환하도록 강제하지 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하십시오. 이 파일에는 촘촘히 배치된 대각선 선이 있는 EMF 이미지가 들어 있습니다. 다음 예제는 [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/)를 사용하여 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

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

출력에서는 EMF가 각 SVG에 하나의 내장 PNG로 변환되었습니다. 다음 측정값은 제공된 프레젠테이션에 대한 것이며 DPI를 픽셀 차원으로 변환하는 일반적인 공식은 아닙니다.

| 메타파일 래스터화 DPI | 내장 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 같은 영역의 내장 래스터를 동일한 확대 표시 크기로 보여줍니다. 대각선 선은 72 DPI에서 눈에 띄는 픽셀화가 나타나고, 높은 해상도에서는 더 부드러운 가장자리를 보이며 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 세부 사항이 개선되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150, 300 DPI에서 확대된 대각선 선 디테일](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/)은 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **모양 및 텍스트에 안정적인 ID 할당**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)에 형식 지정 콜백을 제공하여 각 SVG 모양에 대해 [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId)를 설정합니다. 콜백은 텍스트 `tspan` 요소에 대한 [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) 값도 설정할 수 있습니다.

PhpJavaBridge는 스트림 모드에서 실행될 때 `writeAsSvg`에서 PHP 콜백을 호출할 수 없습니다. 형식 지정 로직을 작은 Java 도우미 클래스로 작성하고 컴파일한 뒤, 생성된 JAR 파일을 브리지 클래스패스에 추가하십시오. 도우미는 모양의 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId)와 텍스트 스팬에 대한 반복 가능한 카운터를 사용할 수 있습니다. 도우미 코드에 대해서는 [Java implementation of `StableSvgIdController`](/slides/ko/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text)를 참조하십시오.

컴파일된 `com.example.slides.StableSvgIdController` 클래스를 브리지 클래스패스에 추가한 후, PHP에서 인스턴스화하고 `SVGOptions`에 할당하십시오:

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

형식 지정 콜백에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler)에 [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/) 값을 전달하여 내보낸 모양에 JavaScript 이벤트 핸들러를 추가합니다. 콜백은 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController)에 할당하고, 결과를 호스팅하는 페이지 또는 SVG 문서에서 JavaScript 함수를 정의하십시오.

안정적인 ID와 마찬가지로 PhpJavaBridge가 스트림 모드를 사용할 때는 콜백을 Java 도우미에서 구현합니다. [Java implementation of `SvgEventController`](/slides/ko/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers)는 `ActionButton`이라는 모양에 ID와 `OnClick` 핸들러를 할당합니다. 해당 도우미를 컴파일하고 `com.example.slides.SvgEventController`로 브리지 클래스패스에 추가한 뒤, PHP에서 다음과 같이 사용하십시오:

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

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 대화형 SVG 워크플로를 지원합니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)를 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) 대신 사용해야 합니까?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText)를 사용해야 하는 경우는 모든 텍스트가 글꼴과 무관해야 할 때입니다. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)는 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 때 사용하십시오.

**SVG를 더 작게 만들기 위한 최선의 방법은 무엇입니까?**

먼저 내장 사진을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경이 제공할 수 있는 경우 링크된 글꼴 파일을 선택하십시오. 낮은 이미지 해상도, 낮은 JPEG 품질, 벡터화된 텍스트는 각각 품질과 크기 사이에 다른 trade‑off가 있기에 결과를 테스트해야 합니다.

**내보낸 SVG 요소를 내보낸 뒤 수정할 수 있습니까?**

예. 형식 지정 콜백을 통해 ID를 할당한 다음, 후처리 도구 또는 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.