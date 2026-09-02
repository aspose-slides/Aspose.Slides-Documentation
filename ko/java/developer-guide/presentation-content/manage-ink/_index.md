---
title: Java에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/java/manage-ink/
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
- IInkOptions
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 잉크 개체를 관리하고, 트레이스와 브러시 속성을 편집하며, PDF, HTML, SVG, TIFF 및 이미지 내보내기 중에 잉크 표시를 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하거나 연결 및 프로세스를 표시하고 슬라이드의 특정 항목에 주의를 끄는 데 사용할 수 있습니다.

Aspose.Slides는 잉크 개체 작업에 필요한 타입을 제공합니다. 예를 들어, [IInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iink/) 인터페이스는 슬라이드의 잉크 개체를 나타냅니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 개체로 표시됩니다. 가장 단순한 형태에서 도형은 개체 자체의 영역(프레임)을 정의하는 컨테이너이며, 컨테이너 크기, 모양 및 배경과 같은 속성을 포함합니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/java/shape-manipulations/#access-layout-formats-for-shape)을 참조하십시오.

하지만 PowerPoint가 잉크 개체를 처리할 때는 컨테이너의 크기 외에는 프레임(컨테이너)의 모든 속성을 무시합니다. 컨테이너 영역의 크기는 표준 [IShape.getWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getWidth--) 및 [IShape.getHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getHeight--) 메서드에 따라 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 순서를 저장합니다.

가장 단순한 인코딩 방식은 각 샘플 점의 X와 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링되면 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시에는 자체 색상과 크기가 있으며, 이는 [IInkBrush.getColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkbrush/#getColor--) 및 [IInkBrush.getSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkbrush/#getSize--) 메서드로 표시됩니다.

### **잉크 브러시 색상 설정**

다음 Java 코드에서는 잉크 브러시의 색상을 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **잉크 브러시 크기 설정**

다음 Java 코드에서는 잉크 브러시의 크기를 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됨). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 하기 위해 잉크 개체의 높이를 늘리고 중요한 치수를 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며—항상 선 두께가 0이라고 가정합니다(이전 이미지 참조).

따라서 전체 잉크 개체의 가시 영역을 결정하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서 대상 개체(손으로 쓴 텍스트 트레이스)는 컨테이너(프레임)의 크기에 맞게 스케일링되었습니다. 컨테이너 크기가 변경되면 브러시 크기는 일정하게 유지되고, 반대로도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 개체에도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 표시 제어**

Aspose.Slides는 [IInkOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/) 인터페이스를 제공하여 내보내기 또는 렌더링된 출력에서 잉크 개체가 어떻게 표시되는지 제어할 수 있습니다. 해당 속성을 사용하여 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산의 해석 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 형식에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 속성 |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#getInkOptions--) |
| 슬라이드 이미지 | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/#getInkOptions--) |

다음 [IInkOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/) 메서드는 동일한 두 설정을 노출합니다:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#getHideInk--) 은 잉크 개체가 출력에 포함되는지를 결정합니다. 기본값은 `false` 입니다.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 은 잉크 브러시를 렌더링할 때 마스크 연산을 불투명도로 해석할지를 결정합니다. 기본값은 `true`이며, `false` 로 설정하면 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 개체 숨기기**

기본적으로 잉크 개체는 내보내기 시 표시됩니다. 손글씨 주석이나 기타 잉크 콘텐츠 없이 깔끔한 출력을 만들려면 [IInkOptions.setHideInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 을 `true` 로 호출하십시오.

다음 Java 예제는 모든 잉크 개체를 숨기면서 프레젠테이션을 PDF로 내보냅니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **슬라이드를 이미지로 렌더링할 때 잉크 개체 숨기기**

슬라이드를 비트맵 이미지로 렌더링할 때 잉크 개체를 숨기려면 [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/#getInkOptions--) 를 구성하고 해당 렌더링 옵션을 [ISlide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-) 에 전달하십시오.

다음 Java 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 개체를 제거합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **잉크 마스크 렌더링 제어**

[IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) 설정은 잉크 브러시를 렌더링할 때 마스크 연산을 어떻게 해석할지를 제어합니다. 기본값 `true`는 불투명도를 사용합니다. ROP 연산을 사용하려면 [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) 를 `false` 로 호출하십시오.

다음 Java 예제는 슬라이드를 SVG로 내보내면서 잉크 마스크 연산에 ROP 기반 렌더링을 사용합니다:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

동일한 설정은 프레젠테이션을 TIFF로 내보내거나 슬라이드를 TIFF로 렌더링할 때도 [TiffOptions.getInkOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/#getInkOptions--) 를 통해 적용할 수 있습니다.

### **잉크를 숨길지 보존할지 선택하기**

검토 표시 없이 배포용 깔끔한 주석 프레젠테이션이 필요하면 내보내기 시 [IInkOptions.setHideInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 을 `true` 로 호출하십시오.

잉크 주석이 의도된 콘텐츠(예: 검토 의견, 손글씨 메모, 강조 표시 또는 그림)라면 [IInkOptions.getHideInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#getHideInk--) 을 기본값인 `false` 로 두어야 합니다. 이렇게 하면 동일한 프레젠테이션에서 소스 잉크 개체를 수정하지 않고도 별도의 검토용 및 최종용 출력을 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [IInk.getTraces](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iink/#getTraces--) 로 트레이스를 가져온 다음 해당 [IInkTrace.getBrush](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinktrace/#getBrush--) 를 변경하십시오. [IInkBrush.setColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkbrush/#setColor-java.awt.Color-) 또는 [IInkBrush.setSize](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkbrush/#setSize-java.awt.geom.Dimension2D-) 를 호출해 브러시를 변경할 수 있습니다.

**잉크를 숨기는 것이 원본 프레젠테이션을 변경하나요?**

아니요. [IInkOptions.setHideInk](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iinkoptions/#setHideInk-boolean-) 은 렌더링 또는 내보내기 결과에만 영향을 미치며, 원본 프레젠테이션의 잉크 개체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

위에 표시된 해당 내보내기 또는 렌더링 옵션을 사용하여 PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지에 대해 잉크 옵션을 구성할 수 있습니다.

**추가 읽기**

* 일반적인 도형에 대해 알아보려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/java/powerpoint-shapes/) 섹션을 참조하십시오.
* 효과적인 값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/java/shape-effective-properties/#get-effective-font-height-value)를 참고하십시오.
* PDF 내보내기 상세는 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/java/convert-powerpoint-to-pdf/)를 확인하십시오.
* HTML 내보내기 상세는 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/java/convert-powerpoint-to-html/)를 확인하십시오.
* SVG 내보내기 상세는 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/java/render-a-slide-as-an-svg-image/)를 확인하십시오.
* TIFF 내보내기 상세는 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/java/convert-powerpoint-to-tiff/)를 확인하십시오.
* 슬라이드 이미지 렌더링 상세는 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/java/convert-slide/)를 확인하십시오.