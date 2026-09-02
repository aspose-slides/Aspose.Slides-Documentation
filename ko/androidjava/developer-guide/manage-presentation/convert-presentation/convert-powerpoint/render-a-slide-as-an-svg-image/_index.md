---
title: Android에서 SVG 이미지로 프레젠테이션 슬라이드 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 포맷입니다. Aspose.Slides for Android via Java는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지 제어할 수 있습니다.

내보낸 SVG가 작고, 브라우저 간에 예측 가능하며, 인터랙티브 사용을 위해 준비되어야 할 때는 [SVGOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/)를 사용하십시오.

## **슬라이드 SVG로 내보내기**

다음 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)을 만들고 슬라이드를 선택한 뒤 [ISlide.writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-)를 사용해 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

파일 이름은 루프 인덱스 대신 [ISlide.getSlideNumber](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getSlideNumber--)을 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 도형만 필요할 경우 [IShape.writeAsSvg](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-)은 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-)은 프레임 회전 적용 여부를 결정합니다. 텍스트를 결합 글자 없이 렌더링해야 할 경우 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-)를 `true`로 설정하십시오.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **텍스트 및 글꼴 제어**

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이렇게 하면 글꼴 의존성이 사라지고 시각적 결과가 브라우저 간에 더 일관되게 되지만, 텍스트는 더 이상 SVG 텍스트로 선택하거나 검색할 수 없습니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **외부 글꼴 처리 방법 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/)을 선택하고, SVG에 글꼴 데이터를 포함하려면 [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/)을, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/)를 선택합니다. 글꼴을 포함하기 전에 글꼴 라이선스를 확인하십시오.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **내장 이미지 크기 줄이기**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-)을 사용해 내장 그림의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-)으로 잘린 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-)으로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 충실도 또는 보존된 이미지 데이터를 희생하면서 파일 크기를 줄입니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **도형 및 텍스트에 안정적인 ID 할당**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)를 사용해 각 SVG 도형에 대해 [ISvgShape.setId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-)를 설정합니다. 텍스트 `tspan` 요소에도 [ISvgTSpan.setId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) 값을 설정하려면 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/)를 구현하십시오. 두 컨트롤러 중 하나를 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)로 할당합니다.

다음 컨트롤러는 도형 수명 동안 안정적인 [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)와 텍스트 스팬에 대한 반복 가능한 카운터를 사용합니다. 이렇게 생성된 ID는 변경되지 않은 프레젠테이션을 후처리하는 데 적합합니다.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **SVG 이벤트 핸들러 추가**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)에서 [ISvgShape.setEventHandler](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-)에 [SvgEvent](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgevent/) 값을 전달해 내보낸 도형에 JavaScript 이벤트 핸들러를 추가합니다. 컨트롤러를 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)로 할당하고, 결과를 호스팅하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 지원합니다.

## **FAQ**

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)을 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/) 대신 사용해야 합니까?**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)는 모든 텍스트가 글꼴에 독립적이어야 할 때 사용합니다. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우에는 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/svgexternalfontshandling/)를 사용하십시오.

**SVG를 더 작게 만들기 위한 최선의 방법은 무엇입니까?**

먼저 내장 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경이 제공할 수 있다면 링크된 글꼴 파일을 선택하세요. 이미지 해상도 저하, JPEG 품질 감소, 텍스트 벡터화는 각각 품질과 크기 사이에 다른 트레이드오프가 있으므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 후, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.