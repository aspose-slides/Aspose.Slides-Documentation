---
title: .NET에서 프레젠테이션 잉크 개체 관리
linktitle: 잉크 관리
type: docs
weight: 95
url: /ko/net/manage-ink/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint 잉크 개체를 관리하고, 트레이스와 브러시 속성을 편집하며, PDF, HTML, SVG, TIFF 및 이미지 내보내기 시 잉크 모양을 제어합니다."
---
## **소개**

PowerPoint는 자유형 스트로크를 그릴 수 있는 잉크 기능을 제공합니다. 잉크는 다른 개체를 강조하고, 연결 및 프로세스를 표시하며, 슬라이드의 특정 항목에 주목하도록 하는 데 사용할 수 있습니다.

[Aspose.Slides.Ink](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/) 네임스페이스는 잉크 개체 작업에 필요한 클래스와 인터페이스를 포함합니다. 예를 들어, [IInk](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iink/) 인터페이스는 슬라이드의 잉크 개체를 나타냅니다.

## **일반 개체와 잉크 개체의 차이점**

PowerPoint 슬라이드의 개체는 일반적으로 도형 개체로 표시됩니다. 가장 단순한 형태에서 도형은 개체 자체(프레임)의 영역을 정의하는 컨테이너이며, 컨테이너 크기, 모양 및 배경과 같은 속성을 포함합니다. 자세한 내용은 [Shape Layout Format](https://docs.aspose.com/slides/ko/net/shape-manipulations/#access-layout-formats-for-shape)을 참조하십시오.

그러나 PowerPoint가 잉크 개체를 처리할 때는 컨테이너(프레임)의 모든 속성을 무시하고 크기만 사용합니다. 컨테이너 영역의 크기는 표준 [IShape.Width](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/width/) 및 [IShape.Height](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/height/) 속성으로 결정됩니다:

![ink_powerpoint1](ink_powerpoint1.png)

## **잉크 트레이스**

잉크 트레이스는 사용자가 디지털 잉크를 쓸 때 펜의 궤적을 기록하는 기본 요소입니다. 트레이스는 연결된 점들의 순서를 저장합니다.

가장 단순한 인코딩 방식은 각 샘플 점의 X 및 Y 좌표를 지정합니다. 모든 연결된 점이 렌더링될 때 다음과 같은 이미지가 생성됩니다:

![ink_powerpoint2](ink_powerpoint2.png)

## **그리기용 브러시 속성**

브러시는 잉크 트레이스의 점들을 연결하는 선을 그리는 데 사용됩니다. 브러시에는 자체 색상과 크기가 있으며, 이는 [IInkBrush.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iinkbrush/color/) 및 [IInkBrush.Size](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iinkbrush/size/) 속성으로 표현됩니다.

### **잉크 브러시 색상 설정**

다음 C# 코드는 잉크 브러시의 색상을 설정하는 방법을 보여줍니다:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **잉크 브러시 크기 설정**

다음 C# 코드는 잉크 브러시의 크기를 설정하는 방법을 보여줍니다:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

일반적으로 브러시의 너비와 높이는 일치하지 않으므로 PowerPoint는 브러시 크기를 표시하지 않습니다(해당 데이터 섹션이 회색 처리됨). 브러시의 너비와 높이가 일치하면 PowerPoint는 다음과 같이 크기를 표시합니다:

![ink_powerpoint3](ink_powerpoint3.png)

명확히 보기 위해 잉크 개체의 높이를 늘리고 중요한 차원을 검토해 보겠습니다:

![ink_powerpoint4](ink_powerpoint4.png)

컨테이너(프레임)는 브러시 크기를 고려하지 않으며, 선 두께가 0이라고 가정합니다(앞 이미지 참조).

따라서 전체 잉크 개체의 표시 영역을 판단하려면 트레이스의 브러시 크기를 고려해야 합니다. 여기서는 대상 개체(손글씨 텍스트 트레이스)를 컨테이너(프레임) 크기에 맞게 스케일링했습니다. 컨테이너 크기가 변하면 브러시 크기는 일정하게 유지되고 그 반대도 마찬가지입니다.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint는 텍스트 개체에서도 유사한 동작을 사용합니다:

![ink_powerpoint6](ink_powerpoint6.png)

## **내보내기 및 렌더링 시 잉크 모양 제어**

Aspose.Slides는 [IInkOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/) 인터페이스를 제공하여 내보내기 또는 렌더링된 출력에서 잉크 개체가 어떻게 표시되는지를 제어할 수 있습니다. 이 인터페이스의 속성을 사용해 잉크를 완전히 숨기거나 잉크 브러시 마스크 연산의 해석 방식을 변경할 수 있습니다.

잉크 옵션은 여러 출력 형식에 대한 내보내기 또는 렌더링 옵션을 통해 사용할 수 있습니다:

| 출력 | 잉크 옵션 속성 |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/inkoptions/) |
| 슬라이드 이미지 | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/inkoptions/) |

다음 두 설정이 이러한 속성을 통해 제공됩니다:

- [`HideInk`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/hideink/)은 잉크 개체를 출력에 포함시킬지 여부를 결정합니다. 기본값은 `false`입니다.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/)은 잉크 브러시를 렌더링할 때 마스크 연산을 불투명도로 해석할지 여부를 결정합니다. 기본값은 `true`이며, `false`로 설정하면 ROP 연산을 사용합니다.

### **PDF 출력에서 잉크 개체 숨기기**

기본적으로 잉크 개체는 내보내기 시 표시됩니다. 손글씨 주석이나 기타 잉크 내용 없이 깔끔한 출력을 원한다면 [IInkOptions.HideInk](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/hideink/)을 `true`로 설정하십시오.

다음 C# 예제는 모든 잉크 개체를 숨긴 상태로 프레젠테이션을 PDF로 내보냅니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **슬라이드를 이미지로 렌더링할 때 잉크 개체 숨기기**

슬라이드를 비트맵 이미지로 렌더링할 때 잉크 개체를 숨기려면 [RenderingOptions.InkOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/renderingoptions/inkoptions/)을 구성하고 해당 렌더링 옵션을 [ISlide.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/getimage/) 메서드에 전달하십시오.

다음 C# 예제는 첫 번째 슬라이드를 PNG 이미지로 렌더링하면서 잉크 개체를 제외합니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **잉크 마스크 렌더링 제어**

[IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) 속성은 잉크 브러시를 렌더링할 때 마스크 연산을 어떻게 해석할지를 제어합니다. 기본값은 `true`이며 불투명도를 사용합니다. `false`로 설정하면 ROP 연산을 사용합니다.

다음 C# 예제는 슬라이드를 SVG로 내보내면서 ROP 기반 렌더링을 사용합니다:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

동일한 설정은 프레젠테이션을 TIFF로 내보내거나 슬라이드를 TIFF로 렌더링할 때 [TiffOptions.InkOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/inkoptions/)를 통해 적용할 수 있습니다.

### **잉크를 숨길지 보존할지 선택하기**

주석이 포함된 프레젠테이션의 깔끔한 버전을 내보내야 할 경우, 예를 들어 검토 마크 없이 배포용 최종 사본이 필요할 때는 [IInkOptions.HideInk](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/hideink/)을 `true`로 설정하십시오.

잉크 주석이 의도된 콘텐츠의 일부인 경우(검토 의견, 손글씨 메모, 하이라이트, 도형 등)에는 [IInkOptions.HideInk](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/hideink/)을 기본값인 `false`로 두십시오. 이렇게 하면 동일한 프레젠테이션에서 소스 잉크 개체를 수정하지 않고도 검토용과 최종용 출력을 별도로 생성할 수 있습니다.

## **FAQ**

**기존 잉크 스트로크의 색상이나 크기를 변경할 수 있나요?**

예. [IInk.Traces](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iink/traces/)에서 트레이스를 가져온 다음 해당 트레이스의 [IInkTrace.Brush](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iinktrace/brush/)를 변경하십시오. 브러시의 [IInkBrush.Color](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iinkbrush/color/) 및 [IInkBrush.Size](https://reference.aspose.com/slides/ko/net/aspose.slides.ink/iinkbrush/size/) 속성을 설정할 수 있습니다.

**잉크를 숨기면 원본 프레젠테이션이 변경되나요?**

아니요. [IInkOptions.HideInk](https://reference.aspose.com/slides/ko/net/aspose.slides.export/iinkoptions/hideink/)은 렌더링 또는 내보내기 결과에만 영향을 미치며, 원본 프레젠테이션의 잉크 개체를 제거하거나 수정하지 않습니다.

**어떤 내보내기 형식이 잉크 옵션을 지원하나요?**

위에 표시된 해당 내보내기 또는 렌더링 옵션을 통해 PDF, HTML, SVG, TIFF 및 비트맵 슬라이드 이미지에 대한 잉크 옵션을 구성할 수 있습니다.

**추가 읽을거리**

* 일반적인 도형에 대해 알아보려면 [PowerPoint Shapes](https://docs.aspose.com/slides/ko/net/powerpoint-shapes/) 섹션을 참조하십시오.
* 유효값에 대한 자세한 내용은 [Shape Effective Properties](https://docs.aspose.com/slides/ko/net/shape-effective-properties/#get-effective-font-height-value)를 확인하십시오.
* PDF 내보내기에 대한 자세한 내용은 [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ko/net/convert-powerpoint-to-pdf/)를 보십시오.
* HTML 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ko/net/convert-powerpoint-to-html/)를 확인하십시오.
* SVG 내보내기에 대한 자세한 내용은 [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ko/net/render-a-slide-as-an-svg-image/)를 보십시오.
* TIFF 내보내기에 대한 자세한 내용은 [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ko/net/convert-powerpoint-to-tiff/)를 참고하십시오.
* 슬라이드 이미지 렌더링에 대한 자세한 내용은 [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ko/net/convert-slide/)를 확인하십시오.