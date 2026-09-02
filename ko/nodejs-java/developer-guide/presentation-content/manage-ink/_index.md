---
title: JavaScript에서 프레젠테이션 잉크 객체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/nodejs-java/manage-ink/
keywords:
- 잉크
- 잉크 객체
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java로 PDF, HTML, SVG, TIFF 및 이미지 내보내기 시 PowerPoint 잉크 객체를 관리하고, 트레이스와 브러시 속성을 편집하며, 잉크 모양을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 객체를 강조하거나, 연결 및 프로세스를 표시하고, 슬라이드의 특정 항목에 주의를 끌 때 사용할 수 있습니다.

Aspose.Slides는 잉크 객체를 다루는 데 필요한 유형을 제공합니다. 예를 들어, [Ink](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ink/) 클래스는 슬라이드에 있는 잉크 객체를 나타냅니다.

## **정규 객체와 잉크 객체 사이의 차이점**

PowerPoint 슬라이드의 객체는 일반적으로 도형(shape) 객체로 표현됩니다. 가장 단순하게는 도형이 객체 자체의 영역(프레임)과 컨테이너 크기, 모양, 배경과 같은 속성을 정의하는 컨테이너입니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/nodejs-java/shape-manipulations/#access-layout-formats-for-shape) 를 참고하십시오.

하지만 PowerPoint가 잉크 객체를 처리할 때는 크기를 제외한 객체 프레임(컨테이너)의 모든 속성을 무시합니다. 컨테이너 영역의 크기는 표준 [Shape.getWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getWidth--) 및 [Shape.getHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getHeight--) 메서드에 의해 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 시퀀스를 저장합니다.

가장 단순한 인코딩 형태는 각 샘플 점의 X와 Y 좌표를 지정합니다. 모든 연결된 점을 렌더링하면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시에는 자체 색상과 크기가 있으며, 이는 [InkBrush.getColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/inkbrush/#getColor--) 및 [InkBrush.getSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/inkbrush/#getSize--) 메서드로 나타냅니다.

### **잉크 브러시 색상 설정**

다음 JavaScript 코드는 잉크 브러시의 색상을 설정하는 방법을 보여줍니다:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **잉크 브러시 크기 설정**

다음 JavaScript 코드는 잉크 브러시의 크기를 설정하는 방법을 보여줍니다:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됩니다). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 객체의 높이를 늘리고 중요한 치수를 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며 항상 선 두께가 0이라고 가정합니다(앞 이미지 참조).

따라서 전체 잉크 객체의 보이는 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서 대상 객체(손글씨 텍스트 트레이스)는 컨테이너(프레임)의 크기에 맞게 스케일되었습니다. 컨테이너 크기가 변하면 브러시 크기는 일정하게 유지되고, 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 객체에도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 모양 제어**

Aspose.Slides는 내보내기 또는 렌더링된 출력에서 잉크 객체가 어떻게 표시되는지를 제어하는 [InkOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/inkoptions/) 클래스를 제공합니다. 해당 속성을 사용해 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산의 해석 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 형식에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 속성 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

다음 [InkOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/inkoptions/) 메서드는 동일한 두 설정을 노출합니다:

- [InkOptions.getHideInk] 은(는) 잉크 객체가 출력에 포함되는지를 결정합니다. 기본값은 `false` 입니다.
- [InkOptions.getInterpretMaskOpAsOpacity] 은(는) 잉크 브러시를 렌더링할 때 마스크 연산을 불투명도로 해석할지를 결정합니다. 기본값은 `true`이며, `false` 로 호출하면 대신 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 객체 숨기기**

기본적으로, 내보내기 시 잉크 객체는 보이게 유지됩니다. 손글씨 주석이나 기타 잉크 콘텐츠가 없는 깔끔한 출력을 만들려면 [InkOptions.setHideInk] 를 `true` 로 호출하십시오.

다음 JavaScript 예제는 모든 잉크 객체를 숨긴 상태로 프레젠테이션을 PDF로 내보냅니다:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **슬라이드를 이미지로 렌더링할 때 잉크 객체 숨기기**

슬라이드를 비트맵 이미지로 렌더링할 때 잉크 객체를 숨기려면 [RenderingOptions.getInkOptions] 를 구성하고 해당 렌더링 옵션을 [Slide.getImage] 에 전달하십시오.

다음 JavaScript 예제는 첫 번째 슬라이드를 잉크 객체 없이 PNG 이미지로 렌더링합니다:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **잉크 마스크 렌더링 제어**

[InkOptions.getInterpretMaskOpAsOpacity] 설정은 잉크 브러시를 렌더링할 때 마스크 연산이 어떻게 해석되는지를 제어합니다. 기본값은 `true`이며 불투명도를 사용합니다. 대신 ROP 연산을 사용하려면 [InkOptions.setInterpretMaskOpAsOpacity] 를 `false` 로 호출하십시오.

다음 JavaScript 예제는 슬라이드를 SVG로 내보내고 잉크 마스크 연산에 ROP 기반 렌더링을 사용합니다:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

같은 설정을 프레젠테이션을 내보내거나 슬라이드를 TIFF로 렌더링할 때 [TiffOptions.getInkOptions] 를 통해 적용할 수 있습니다.

### **잉크를 숨길지 유지할지 선택**

주석이 포함된 프레젠테이션을 배포용으로 검토 표시 없이 깔끔하게 만들 필요가 있을 때는 내보내기 중에 [InkOptions.setHideInk] 를 `true` 로 호출하십시오.

[InkOptions.getHideInk] 를 `false` 기본값으로 유지하면 잉크 주석이 의도된 콘텐츠의 일부인 경우(예: 검토 의견, 손글씨 메모, 강조 표시, 또는 렌더링 결과에 표시되어야 하는 그림) 그대로 유지됩니다. 이를 통해 애플리케이션은 동일한 프레젠테이션에서 소스 잉크 객체를 수정하지 않고도 검토용과 최종용 출력을 별도로 생성할 수 있습니다.

## **자주 묻는 질문**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [Ink.getTraces] 로 트레이스를 얻은 다음 [InkTrace.getBrush] 를 변경합니다. 브러시를 변경하려면 [InkBrush.setColor] 또는 [InkBrush.setSize] 를 호출하십시오.

**잉크를 숨겨도 원본 프레젠테이션이 변경되나요?**

아니요. [InkOptions.setHideInk] 를 호출해도 렌더링 또는 내보낸 결과에만 영향을 미치며, 원본 프레젠테이션의 잉크 객체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

위에 표시된 해당 내보내기 또는 렌더링 옵션을 통해 PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지에 대한 잉크 옵션을 구성할 수 있습니다.

**추가 자료**

* 일반적인 도형에 대해 읽으려면 [PowerPoint Shapes] 섹션을 참조하십시오.
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/nodejs-java/shape-effective-properties/#get-effective-font-height-value) 를 보십시오.
* PDF 내보내기 자세히 보기: [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) .
* HTML 내보내기 자세히 보기: [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/nodejs-java/convert-powerpoint-to-html/) .
* SVG 내보내기 자세히 보기: [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/) .
* TIFF 내보내기 자세히 보기: [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/nodejs-java/convert-powerpoint-to-tiff/) .
* 슬라이드 이미지 렌더링 자세히 보기: [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/nodejs-java/convert-slide/) .