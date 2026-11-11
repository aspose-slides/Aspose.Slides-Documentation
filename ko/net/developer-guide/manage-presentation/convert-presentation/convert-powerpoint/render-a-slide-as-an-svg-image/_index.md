---
title: .NET에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/net/render-a-slide-as-an-svg-image/
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
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고, Aspose.Slides를 사용해 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리 등에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 개별 SVG 파일로 내보내며 텍스트, 글꼴, 이미지 및 SVG 요소가 작성되는 방식을 제어할 수 있습니다.

내보낸 SVG가 작고, 브라우저마다 예측 가능하거나 인터랙티브 사용을 위해 준비되어야 할 때 [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)를 사용합니다.

## **슬라이드를 SVG로 내보내기**

다음과 같이 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 생성하고 슬라이드를 선택한 뒤 스트림에 기록합니다. 아래 예제는 프레젠테이션의 모든 슬라이드를 개별 SVG 파일로 내보냅니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

파일 이름은 루프 인덱스 대신 [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/)를 사용합니다. 슬라이드 뷰어 또는 웹 페이지에서 특정 도형만 필요할 경우 [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/)를 사용하여 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)는 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/)이 렌더링 영역에 텍스트 프레임을 포함하고, [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/)은 프레임 회전 적용 여부를 결정합니다. 텍스트를 합자 없이 렌더링해야 할 때는 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/)를 `true`로 설정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **화살표 머리에서 선 끝 자르기 제어**

SVG 1.1에는 화살표 머리 아래에서 선이 멈추는 위치를 지정하는 마커 삽입 설정이 없습니다. 기본적으로 Aspose.Slides는 내보낸 선의 스트로크가 마커를 뚫지 않도록 선을 단축합니다. [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/)을 `true`로 설정하면 스트로크가 선의 원래 끝점까지 그려집니다. 이 설정은 SVG 출력에만 영향을 미칩니다. 슬라이드에서는 선의 위치와 길이가 유지됩니다.

예제는 2포인트와 10포인트 두께의 선에 삼각형 및 다이아몬드 화살표 머리를 그립니다. 동일한 슬라이드를 두 번 내보내며 자르기 옵션만 변경합니다.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

비교 결과 10포인트 선의 삼각형 화살표 머리가 표시됩니다. 자르기가 활성화되면 끝이 뾰족합니다. 자르기가 비활성화되면 스트로크가 마커의 경사진 면을 통해 튀어나와 평평한 끝이 됩니다.

![자르기가 활성화된 경우 뾰족한 끝을 가진 확대된 10포인트 삼각형, 자르기가 비활성화된 경우 평평한 끝](line-end-cropping.png)

예제의 다른 선에서는 2포인트 삼각형에서 돌출된 스트로크가 덜 눈에 띕니다. 채워진 다이아몬드는 두 두께 모두에서 스트로크 끝을 덮습니다.

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 포함하거나 참조하는 방식을 제어할 수 있습니다. 다음 옵션은 내보낸 SVG에서 시각적 일관성, 텍스트 선택 가능성 및 글꼴 종속성을 균형 있게 유지하는 데 도움이 됩니다.

### **모든 텍스트 벡터화**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이로써 글꼴 종속성이 사라지고 브라우저 간 시각적 결과가 더 일관되지만, 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **외부 글꼴 처리 방식 선택**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/)은 외부에서 로드되는 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) 값을 사용합니다. 별도의 글꼴 파일을 참조하려면 `AddLinksToFontFiles`를, SVG에 글꼴 데이터를 포함하려면 `Embed`를, 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링하려면 `Vectorize`를 선택합니다. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **내장 이미지 크기 감소**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/)을 사용하여 내장 이미지 해상도를 낮추고, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/)로 잘린 원본 영역을 제외하며, [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/)로 JPEG 인코딩 품질을 제어합니다. 이러한 설정은 이미지 충실도 또는 유지된 이미지 데이터를 희생하면서 파일 크기를 줄입니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **메타파일 래스터화 해상도 제어**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/)는 SVG 내보내기 중 메타파일을 래스터화할 때 하한 해상도를 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 세부 정보와 파일 크기를 균형 있게 조정하는 데 사용합니다. 이는 SVG 전체에 대한 DPI를 정의하거나 슬라이드의 모든 객체를 래스터 이미지로 강제 변환하지는 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하세요. 이 파일에는 빽빽한 대각선 라인이 있는 EMF 이미지가 포함되어 있습니다. 아래 예제는 [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/)를 사용해 첫 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

출력에서는 EMF가 각 SVG에 하나의 내장 PNG로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며, DPI를 픽셀 치수로 변환하는 일반적인 공식은 아닙니다.

| 메타파일 래스터화 DPI | 내장 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 확대된 동일한 표시 크기에서 내장 래스터의 동일 영역을 보여줍니다. 대각선 라인은 72 DPI에서는 눈에 보이는 픽셀화가 나타나고, 높은 해상도에서는 더 부드러운 가장자리를 제공합니다. 동시에 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 세부 사항이 개선되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150, 300 DPI에서 확대된 대각선 라인 디테일](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/)은 이미지 해상도 감소를 제어하고 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/)는 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **도형 및 텍스트에 안정적인 ID 할당**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)를 사용하여 각 SVG 도형에 대한 [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/)를 설정합니다. 텍스트 `tspan` 요소에 대한 [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) 값을 설정하려면 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)를 구현합니다. 두 컨트롤러 중 하나를 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)에 할당합니다.

다음 컨트롤러는 도형의 수명 동안 안정적인 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)와 텍스트 스팬에 대한 반복 가능한 카운터를 사용합니다. 이를 통해 생성된 ID는 변경되지 않은 프레젠테이션의 후처리에 적합합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **SVG 이벤트 핸들러 추가**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)에서 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/)를 [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) 값과 함께 호출하여 내보낸 도형에 JavaScript 이벤트 핸들러를 추가합니다. 컨트롤러는 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)에 할당하고, 결과를 호스팅하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

호스트 페이지에서 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로를 사용할 수 있습니다.

## **FAQ**

**언제 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 대신 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)를 사용해야 합니까?**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)는 모든 텍스트가 글꼴에 독립적이어야 할 때 사용합니다. [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)는 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환해야 할 때 사용합니다.

**SVG를 더 작게 만드는 가장 좋은 방법은 무엇입니까?**

먼저 내장된 이미지를 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 링크된 글꼴 파일을 선택하십시오. 낮은 이미지 해상도, 낮은 JPEG 품질 및 벡터화된 텍스트는 각각 품질과 크기 사이에 다른 트레이드오프가 있으므로 결과를 테스트해야 합니다.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 다음, 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하면 됩니다.