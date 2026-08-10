---
title: JavaScript에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드를 SVG로
type: docs
weight: 50
url: /ko/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides for Node.js via Java은 각 슬라이드를 별도의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 컴팩트하고 브라우저 간에 일관되며 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

소스코드에서 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)을 생성하고 슬라이드를 선택한 후 [Slide.writeAsSvg](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/writeassvg/)를 사용하여 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별도의 SVG 파일로 내보냅니다.

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

파일 이름은 루프 인덱스 대신 [Slide.getSlideNumber](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/getslidenumber/)를 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 도형만 필요할 경우 [Shape.writeAsSvg](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/writeassvg/)를 사용하여 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setuseframesize/)는 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setuseframerotation/)은 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures)를 `true`로 설정하십시오.

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

## **텍스트 및 글꼴 제어**

### **전체 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 의존성이 사라지고 시각적 결과가 브라우저 간에 더 일관되게 되지만, 텍스트는 더 이상 SVG 텍스트로 선택하거나 검색할 수 없습니다.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/)은 외부에서 로드되는 글꼴에 대한 [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택하십시오. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

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

## **삽입된 이미지 크기 줄이기**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setpicturescompression/)을 사용하여 삽입된 이미지의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/)을 사용하여 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setjpegquality/)을 사용하여 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 품질이나 보존된 이미지 데이터의 대가로 파일 크기를 줄입니다.

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

## **도형 및 텍스트에 안정적인 ID 할당**

[SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)에 포맷팅 컨트롤러를 전달하여 각 SVG 도형에 대해 [SvgShape.setId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgshape/setid/)를 설정합니다. 텍스트 스팬을 처리하는 컨트롤러는 텍스트 `tspan` 요소에 대한 [SvgTSpan.setId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgtspan/setid/) 값을 지정할 수 있습니다.

다음 컨트롤러는 도형의 수명 동안 안정적인 [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)를 사용하고, 텍스트 스팬에 대해 반복 가능한 카운터를 사용합니다. 이렇게 생성된 ID는 변경되지 않은 프레젠테이션을 후처리하는 데 적합합니다.

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

포맷팅 컨트롤러에서 [SvgShape.setEventHandler](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgshape/seteventhandler/)에 [SvgEvent](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgevent/) 값을 전달하여 내보낸 도형에 JavaScript 이벤트 핸들러를 추가합니다. 컨트롤러를 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/)에 할당하고 결과를 호스팅하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

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

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 활성화할 수 있습니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)를 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgexternalfontshandling/) 대신 사용해야 하나요?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgoptions/setvectorizetext/)는 모든 텍스트가 글꼴에 의존하지 않아야 할 때 사용합니다. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgexternalfontshandling/)는 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 때 사용합니다.

**SVG를 더 작게 만들기 위한 가장 좋은 방법은 무엇인가요?**

먼저 삽입된 이미지를 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경이 제공할 수 있는 경우 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질 및 크기 측면에서 다른 트레이드오프를 가지므로 결과를 테스트해야 합니다.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.