---
title: 안드로이드에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Android에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 잘 맞는 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides for Android via Java는 각 슬라이드를 별도의 SVG 파일로 내보내고 텍스트, 글꼴, 사진 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 컴팩트하고 브라우저 간에 예측 가능하거나 인터랙티브하게 사용될 준비가 된 경우에는 [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/)를 사용합니다.

## **슬라이드를 SVG로 내보내기**

[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)을 생성하고 슬라이드를 선택한 다음, [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-)를 사용해 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

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

파일 이름은 루프 인덱스가 아니라 [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--)을 사용합니다. 슬라이드 뷰어나 웹 페이지에서 특정 도형만 필요할 때는 [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)를 사용해 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/)은 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-)는 텍스트 프레임을 렌더링 영역에 포함하고, [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-)은 프레임 회전 적용 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 때는 [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-)를 `true`로 설정합니다.

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

## **화살촉에서 선 끝 자르기 제어**

SVG 1.1에는 선이 화살촉 아래에서 멈추는 위치를 지정하는 마커 인셋 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선을 단축하여 스트로크가 마커를 뚫지 않도록 합니다. `[SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-)`을 `true`로 호출하면 스트로크가 원래 끝점까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미치며, 슬라이드 상에서 선의 위치와 길이는 유지됩니다.

예제는 2 pt와 10 pt 너비 선에 삼각형 및 다이아몬드 화살촉을 그립니다. 동일한 슬라이드를 두 번 내보내며 자르기 옵션만 변경합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;

    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

비교는 10 pt 선에 대한 삼각형 화살촉을 보여줍니다. 자르기가 활성화된 경우 팁이 날카롭고, 비활성화된 경우 스트로크가 마커의 경사면을 뚫고 평평한 끝을 남깁니다.

![자르기가 활성화될 때 날카로운 팁을 가진 확대된 10 pt 삼각형과 자르기가 비활성화될 때 평평한 끝을 가진 이미지](line-end-cropping.png)

예제의 다른 선에서는 2 pt 삼각형에서 돌출된 스트로크가 덜 눈에 띕니다. 채워진 다이아몬드는 두 너비 모두에서 스트로크 끝을 가립니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 어떻게 포함하거나 참조할지를 제어할 수 있습니다. 다음 옵션은 내보낸 SVG의 시각적 일관성, 텍스트 선택 및 글꼴 의존성을 균형 있게 맞추는 데 도움을 줍니다.

### **모든 텍스트 벡터화**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)을 `true`로 설정하면 모든 슬라이드 텍스트가 벡터 그래픽으로 기록됩니다. 이는 글꼴 의존성을 없애고 브라우저 간 시각적 일관성을 높이지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

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

### **외부 글꼴 처리 방식 선택**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)를 선택하고, SVG에 글꼴 데이터를 포함하려면 [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환하려면 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)를 선택합니다. 글꼴을 임베드하기 전에 라이선스를 확인하세요.

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

## **삽입된 이미지 크기 줄이기**

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-)을 사용해 삽입된 사진의 해상도를 낮추고, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-)으로 잘라낸 원본 영역을 생략하며, [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-)으로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 충실도 또는 보존된 이미지 데이터를 희생하면서 파일 크기를 감소시킵니다.

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

## **메타파일 래스터화 해상도 제어**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-)은 SVG 내보내기 중 메타파일을 래스터화할 때 최소 해상도 제한을 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 세부 사항과 파일 크기 사이의 균형을 맞추는 데 사용합니다. 이는 SVG 전체에 대한 전역 DPI를 정의하거나 슬라이드의 모든 객체를 래스터 이미지로 강제 변환하지는 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하면 근접한 대각선 라인이 포함된 EMF 이미지를 확인할 수 있습니다. 다음 예제는 [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)을 통해 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

출력에서 EMF는 각 SVG에 삽입된 PNG 하나로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며 DPI를 픽셀 치수로 변환하는 일반 공식은 아닙니다.

| 메타파일 래스터화 DPI | 삽입된 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 확대된 표시 크기에서 동일 영역의 삽입된 래스터를 보여줍니다. 대각선 라인은 72 DPI에서 눈에 보이는 픽셀화가 나타나고, 높은 해상도에서는 가장자리가 매끄러워지며 SVG 파일 크기가 증가합니다. 값이 증가한다고 해서 모든 세부 사항이 개선되거나 모든 내보낸 이미지가 바뀌는 것은 아닙니다.

![72, 150 및 300 DPI에서 확대된 대각선선 디테일](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-)은 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **도형 및 텍스트에 안정적인 ID 할당**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)를 사용해 각 SVG 도형에 대해 [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-)를 설정합니다. 텍스트 `tspan` 요소에도 [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) 값을 지정하려면 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/)를 구현합니다. 두 컨트롤러 중 하나를 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)로 할당합니다.

다음 컨트롤러는 도형의 수명 동안 안정적인 [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--)와 텍스트 스팬에 대한 반복 가능한 카운터를 사용합니다. 이는 변경되지 않은 프레젠테이션을 후처리할 때 생성된 ID가 적합하도록 합니다.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/)에서 [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-)을 [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) 값과 함께 호출하면 내보낸 도형에 JavaScript 이벤트 핸들러를 추가할 수 있습니다. 컨트롤러는 [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-)로 할당하고, 결과를 호스팅하는 페이지或SVG 문서에 JavaScript 함수를 정의합니다.

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

**언제 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)을 사용하고 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)를 대신 사용해야 합니까?**

모든 텍스트가 글꼴과 독립적이어야 할 때는 [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-)를 사용합니다. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 경우에는 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)를 사용합니다.

**SVG 파일을 더 작게 만들려면 가장 좋은 방법은 무엇입니까?**

먼저 삽입된 사진을 압축하고, 잘라낸 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 링크된 글꼴 파일을 선택합니다. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기에 다른 영향을 미치므로 결과를 테스트하세요.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있습니까?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 일치하는 SVG 요소를 선택하여 수정할 수 있습니다.