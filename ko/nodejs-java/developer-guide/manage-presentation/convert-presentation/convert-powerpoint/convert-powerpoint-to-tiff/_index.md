---
title: JavaScript에서 PowerPoint 프레젠테이션을 TIFF로 변환하기
titlelink: PowerPoint를 TIFF로 변환
type: docs
weight: 90
url: /ko/nodejs-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로 변환
- 프레젠테이션을 TIFF로 변환
- 슬라이드를 TIFF로 변환
- PPT를 TIFF로 변환
- PPTX를 TIFF로 변환
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint(PPT, PPTX) 프레젠테이션을 고품질 TIFF 이미지로 손쉽게 변환하는 방법을 JavaScript 코드 예제와 함께 배웁니다."
---
## **소개**

TIFF (**태그 이미지 파일 포맷**)은 광범위하게 사용되는 무손실 래스터 이미지 포맷으로, 뛰어난 품질과 그래픽의 정밀한 보존으로 알려져 있습니다. 디자이너, 사진작가 및 데스크톱 퍼블리셔는 종종 이미지의 레이어, 색 정확도 및 원래 설정을 유지하기 위해 TIFF를 선택합니다.

Aspose.Slides를 사용하면 PowerPoint 슬라이드(PPT, PPTX)와 OpenDocument 슬라이드(ODP)를 손쉽게 고품질 TIFF 이미지로 직접 변환하여 프레젠테이션이 최대한의 시각적 충실도를 유지하도록 할 수 있습니다.

## **프레젠테이션을 TIFF로 변환**

Presentation 클래스에서 제공하는 [save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하면 전체 PowerPoint 프레젠테이션을 빠르게 TIFF로 변환할 수 있습니다. 결과 TIFF 이미지는 기본 슬라이드 크기에 해당합니다.

다음 JavaScript 코드는 PowerPoint 프레젠테이션을 TIFF로 변환하는 방법을 보여줍니다:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    // 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션을 흑백 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스의 [setBwConversionMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 메서드를 사용하면 컬러 슬라이드나 이미지를 흑백 TIFF로 변환할 때 사용되는 알고리즘을 지정할 수 있습니다. 이 설정은 [setCompressionType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#setCompressionType-int-) 메서드가 `CCITT4` 또는 `CCITT3`으로 설정된 경우에만 적용됩니다.

{{% alert color="info" title="Note" %}}
[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#setBwConversionMode-int-) 은 전체 TIFF 이미지에 대한 픽셀 변환 알고리즘을 선택하는 내보내기 수준 설정입니다. 흑백 디스플레이 모드가 활성화된 경우 개별 도형이 어떻게 표시될지 정의하려면 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) 을 사용하십시오. 예제는 [Control Black-and-White Rendering for Shapes](/nodejs-java/shape-formatting/#control-black-and-white-rendering-for-shapes) 를 참조하십시오.
{{% /alert %}}

예를 들어, 다음 슬라이드가 포함된 "sample.pptx" 파일이 있다고 가정해 보겠습니다:
![프레젠테이션 슬라이드](slide_black_and_white.png)

다음 JavaScript 코드는 컬러 슬라이드를 흑백 TIFF로 변환하는 방법을 보여줍니다:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(aspose.slides.BlackWhiteConversionMode.Dithering);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

결과:
![흑백 TIFF](TIFF_black_and_white.png)

## **맞춤 크기로 프레젠테이션을 TIFF로 변환**

특정 치수의 TIFF 이미지가 필요한 경우 [TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 에 있는 메서드를 사용하여 원하는 값을 설정할 수 있습니다. 예를 들어, [setImageSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#setImageSize) 메서드를 사용하면 결과 이미지의 크기를 정의할 수 있습니다.

다음 JavaScript 코드는 맞춤 크기로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    // 압축 유형을 설정합니다.
    tiffOptions.setCompressionType(aspose.slides.TiffCompressionTypes.Default);
    /*
    압축 유형:
        Default - 기본 압축 방식(LZW)을 지정합니다.
        None - 압축을 사용하지 않음을 지정합니다.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 색 깊이는 픽셀 형식에 의해 제어됩니다(아래 예시 참조); CCITT3와 CCITT4는 항상 픽셀당 1비트를 생성합니다.

    // 이미지 DPI를 설정합니다.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 이미지 크기를 설정합니다.
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 1728, 1078));

    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 지정된 크기로 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("tiff-ImageSize.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

## **맞춤 이미지 픽셀 형식으로 프레젠테이션을 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/) 클래스의 [setPixelFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#setPixelFormat) 메서드를 사용하면 결과 TIFF 이미지에 원하는 픽셀 형식을 지정할 수 있습니다.

다음 JavaScript 코드는 맞춤 픽셀 형식으로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:
```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let tiffOptions = new aspose.slides.TiffOptions();

    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat에는 다음 값들이 포함되어 있습니다(문서에 명시된 대로):
        Format1bppIndexed - 픽셀당 1비트, 인덱스 형식.
        Format4bppIndexed - 픽셀당 4비트, 인덱스 형식.
        Format8bppIndexed - 픽셀당 8비트, 인덱스 형식.
        Format24bppRgb    - 픽셀당 24비트, RGB.
        Format32bppArgb   - 픽셀당 32비트, ARGB.
    */

    /// 지정된 이미지 크기로 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("Tiff-PixelFormat.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose의 [무료 PowerPoint 포스터 변환기](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **자주 묻는 질문**

**전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드를 TIFF로 변환할 수 있나요?**

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

**프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?**

아니요, Aspose.Slides는 슬라이드 수에 제한을 두지 않습니다. 어느 크기의 프레젠테이션이든 TIFF 형식으로 변환할 수 있습니다.

**PowerPoint 애니메이션 및 전환 효과가 슬라이드를 TIFF로 변환할 때 보존되나요?**

아니요, TIFF는 정적인 이미지 형식입니다. 따라서 애니메이션 및 전환 효과는 보존되지 않으며, 슬라이드의 정적 스냅샷만 내보내집니다.