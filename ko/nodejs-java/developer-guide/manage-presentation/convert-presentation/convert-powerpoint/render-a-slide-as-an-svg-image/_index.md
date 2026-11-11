---
title: JavaScript에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint에서 SVG로
- 프레젠테이션에서 SVG로
- 슬라이드에서 SVG로
- PPT에서 SVG로
- PPTX에서 SVG로
- SVG 내보내기 옵션
- 인터랙티브 SVG
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용하여 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로, 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides for Node.js via Java는 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 작성되는지를 제어할 수 있게 합니다.

내보낸 SVG가 작고, 브라우저 간 예측 가능하며, 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

프레젠테이션([Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/))을 만들고, 슬라이드를 선택한 다음, [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/)를 사용하여 스트림에 씁니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/)를 사용합니다. 슬라이드 뷰어나 웹 페이지에서 해당 도형만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/)가 텍스트 프레임을 렌더링 영역에 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/)이 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `true`로 설정하십시오.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **화살촉에서 선 끝 자르기 제어**

SVG 1.1에는 선이 화살촉 아래에서 멈추는 위치를 지정하는 마커 inset 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선이 마커를 통과하지 않도록 선을 짧게 만듭니다. `true`와 함께 [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping)를 호출하면 스트로크가 원래 라인 끝까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미칩니다. 슬라이드상의 선 위치와 길이는 유지됩니다.

예제는 2포인트와 10포인트 너비의 선에 삼각형 및 다이아몬드 화살촉을 그립니다. 동일한 슬라이드를 두 번 내보내며 자르기 옵션만 변경합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

비교에서는 10포인트 선에 삼각형 화살촉이 표시됩니다. 자르기가 활성화된 경우 팁이 날카롭고, 비활성화된 경우 스트로크가 마커의 경사면을 통해 돌출되어 평평한 끝이 됩니다.

![자르기가 활성화된 경우 날카로운 끝이 있는 10포인트 삼각형 확대 이미지와 자르기가 비활성화된 경우 평평한 끝](line-end-cropping.png)

다른 예제 선에서는 돌출된 스트로크가 2포인트 삼각형에서 덜 눈에 띕니다. 채워진 다이아몬드는 두 너비 모두에서 스트로크 끝을 가립니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 어떻게 포함하거나 참조할지를 제어할 수 있습니다. 다음 옵션은 내보낸 SVG에서 시각적 일관성, 텍스트 선택 가능성 및 글꼴 의존성을 균형 있게 맞추는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 의존성이 사라지고 브라우저 간 시각적 결과가 더 일관되지만 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **외부 글꼴 처리 방식 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. `AddLinksToFontFiles`를 선택하면 개별 글꼴 파일에 대한 링크를 참조하고, `Embed`를 선택하면 SVG에 글꼴 데이터를 포함하며, `Vectorize`를 선택하면 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링합니다. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **삽입된 이미지 크기 축소**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/)을 사용하여 삽입된 그림의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/)로 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/)으로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질 또는 보존된 이미지 데이터를 희생하면서 파일 크기를 줄입니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **메타파일 래스터화 해상도 제어**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/)은 SVG 내보내기 중 메타파일을 래스터화할 때 최소 해상도 한도를 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 디테일과 파일 크기의 균형을 맞추는 데 사용합니다. 이는 SVG 전체에 대한 전역 DPI를 정의하거나 슬라이드의 모든 개체가 래스터 이미지가 되도록 강제하지 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하세요. 이 파일에는 대각선이 촘촘히 배치된 EMF 이미지가 포함되어 있습니다. 다음 예제는 [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/)를 사용해 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

출력에서는 EMF가 각 SVG에 삽입된 PNG 하나로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며 DPI를 픽셀 차원으로 변환하는 일반 공식은 아닙니다.

| 메타파일 래스터화 DPI | 삽입된 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 동일한 영역의 삽입된 래스터를 동일한 확대 표시 크기로 보여줍니다. 대각선은 72 DPI에서 눈에 띄는 픽셀화가 보이며, 해상도가 높을수록 가장자리가 부드러워지고 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 디테일이 개선되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150 및 300 DPI에서 확대된 대각선 라인 디테일](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/)는 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **도형 및 텍스트에 안정적인 ID 할당**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)에 포맷팅 컨트롤러를 전달하여 각 SVG 도형에 대해 [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/)를 설정합니다. 텍스트 스팬을 처리하는 컨트롤러는 텍스트 `tspan` 요소에 [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) 값을 설정할 수 있습니다.

다음 컨트롤러는 도형의 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)를 사용하고, 텍스트 스팬에 대해 재현 가능한 카운터를 사용합니다. 이렇게 하면 변경되지 않은 프레젠테이션에 대한 후처리 작업에 적합한 ID가 생성됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **SVG 이벤트 핸들러 추가**

포맷팅 컨트롤러에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/)에 [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) 값을 전달하면 내보낸 도형에 JavaScript 이벤트 핸들러를 추가할 수 있습니다. 컨트롤러는 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)에 할당하고, 결과를 호스팅하는 페이지나 SVG 문서에 JavaScript 함수를 정의합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로에 활용할 수 있습니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)를 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) 대신 사용해야 합니까?**

모든 텍스트가 글꼴과 독립적이어야 할 때는 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)를 사용하십시오. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환하려면 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)를 사용하십시오.

**SVG 파일을 작게 만드는 가장 좋은 방법은 무엇입니까?**

먼저 삽입된 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우에는 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기 사이에 다른 트레이드오프를 가지므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있습니까?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하여 수정할 수 있습니다.