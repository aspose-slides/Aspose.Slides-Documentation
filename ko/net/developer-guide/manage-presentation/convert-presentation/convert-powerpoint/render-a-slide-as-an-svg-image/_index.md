---
title: ".NET에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링"
linktitle: "슬라이드를 SVG로"
type: docs
weight: 50
url: /ko/net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint를 SVG로"
- "프레젠테이션을 SVG로"
- "슬라이드를 SVG로"
- "PPT를 SVG로"
- "PPTX를 SVG로"
- "SVG 내보내기 옵션"
- "인터랙티브 SVG"
- "PowerPoint"
- "프레젠테이션"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides로 글꼴, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 글꼴, 그림 및 SVG 요소가 어떻게 기록되는지를 제어할 수 있습니다.

내보낸 SVG가 압축되어야 하거나 브라우저 간에 일관되게 동작하거나 인터랙티브 사용을 위해 준비되어야 할 경우 [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)를 사용하십시오.

## **슬라이드를 SVG로 내보내기**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)을 만들고, 슬라이드를 선택한 다음 스트림에 기록합니다. 다음 예제는 프레젠테이션의 모든 슬라이드를 별개의 SVG 파일로 내보냅니다.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

파일 이름은 반복 인덱스 대신 [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/)를 사용합니다. 슬라이드 뷰어 또는 웹 페이지에서 특정 도형만 필요할 경우 [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/)를 사용하여 개별 도형을 내보낼 수도 있습니다.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)은 SVG 렌더링을 제어합니다. 텍스트 프레임의 경우 [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/)가 텍스트 프레임을 렌더링 영역에 포함하고, [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/)이 프레임 회전을 적용할지 여부를 결정합니다. 텍스트를 리가처 없이 렌더링해야 할 경우 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/)를 `true`로 설정하십시오.

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

## **텍스트 및 글꼴 제어**

슬라이드를 SVG로 내보낼 때 텍스트를 텍스트 그대로 유지할지 벡터 그래픽으로 변환할지, 외부 글꼴을 포함하거나 참조할지를 제어할 수 있습니다. 다음 옵션을 사용하면 내보낸 SVG에서 시각적 일관성, 텍스트 선택 가능성 및 글꼴 의존성 사이의 균형을 맞출 수 있습니다.

### **모든 텍스트 벡터화**

[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)를 `true`로 설정하면 모든 슬라이드 텍스트를 벡터 그래픽으로 기록합니다. 이는 글꼴 의존성을 없애고 브라우저 간 시각적 결과를 더 일관되게 만들지만 텍스트는 SVG 텍스트로서 선택하거나 검색할 수 없게 됩니다.

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

### **외부 글꼴 처리 방법 선택**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/)은 외부에서 로드된 글꼴에 대해 [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) 값을 사용합니다. `AddLinksToFontFiles`를 선택하면 별도의 글꼴 파일을 참조하고, `Embed`를 선택하면 SVG에 글꼴 데이터를 포함하며, `Vectorize`를 선택하면 외부 글꼴을 사용하는 텍스트만 그래픽으로 렌더링합니다. 글꼴을 포함하기 전에 라이선스를 확인하십시오.

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

## **삽입된 이미지 크기 축소**

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/)을 사용하여 삽입된 그림의 해상도를 낮추고, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/)를 사용하여 잘린 원본 영역을 생략하며, [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/)을 사용하여 JPEG 인코딩 품질을 조절합니다. 이러한 설정은 이미지 품질이나 보존된 이미지 데이터와 교환하여 파일 크기를 줄입니다.

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

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/)은 SVG 내보내기 중 메타파일을 래스터화할 때의 최소 해상도 제한을 설정합니다. EMF 또는 WMF 이미지가 래스터화될 때 상세도와 파일 크기 사이의 균형을 맞추는 데 사용합니다. 이는 SVG 전체에 대한 전역 DPI를 정의하거나 슬라이드의 모든 객체가 래스터 이미지가 되도록 강제하지는 않습니다.

[metafile-rasterization.pptx](metafile-rasterization.pptx)를 다운로드하십시오. 이 파일에는 대각선 선이 촘촘히 배치된 EMF 이미지가 포함되어 있습니다. 다음 예제는 [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/)를 통해 첫 번째 슬라이드를 세 가지 래스터화 해상도로 내보냅니다. 다른 모든 내보내기 설정은 동일하게 유지되어 결과를 비교할 수 있습니다.

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

출력에서는 EMF가 각 SVG에 삽입된 PNG 하나로 변환됩니다. 아래 측정값은 제공된 프레젠테이션에 대한 것이며 DPI를 픽셀 크기로 변환하는 일반적인 공식은 아닙니다.

| 메타파일 래스터화 DPI | 삽입된 PNG 크기 | SVG 파일 크기 (바이트) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

아래 비교는 동일한 영역의 삽입된 래스터를 같은 확대 표시 크기로 보여줍니다. 대각선 선은 72 DPI에서 픽셀화가 보이며, 높은 해상도에서는 더 부드러운 가장자리를 나타내지만 SVG 파일 크기가 증가합니다. 값을 높인다고 해서 모든 디테일이 향상되거나 모든 내보낸 이미지가 변경되는 것은 아닙니다.

![72, 150 및 300 DPI에서 확대된 대각선 선 디테일](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/)은 이미지 해상도 감소를 제어하며 메타파일 래스터화 해상도 변경 효과를 가릴 수 있습니다. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/)는 JPEG 인코딩 품질을 제어하며 메타파일 래스터화 해상도와는 무관합니다.

## **도형 및 텍스트에 안정적인 ID 할당**

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)를 사용하여 각 SVG 도형에 대해 [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/)을 설정합니다. 텍스트 `tspan` 요소에도 [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) 값을 설정하려면 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)를 구현하십시오. 두 컨트롤러 중 하나를 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)에 할당합니다.

다음 컨트롤러는 도형의 수명 동안 안정적인 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)와 텍스트 스팬을 위한 반복 가능한 카운터를 사용합니다. 이렇게 생성된 ID는 변경되지 않은 프레젠테이션의 후처리에 적합합니다.

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

[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/)에서 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/)를 [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) 값과 함께 호출하면 내보낸 도형에 JavaScript 이벤트 핸들러를 추가할 수 있습니다. 컨트롤러를 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)에 할당하고 결과를 포함하는 페이지 또는 SVG 문서에 JavaScript 함수를 정의하십시오.

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

호스트 페이지는 핸들러가 참조하는 JavaScript 함수를 정의할 수 있습니다. ID와 이벤트 핸들러를 할당하면 슬라이드 뷰어, 접근성 향상 및 기타 인터랙티브 SVG 워크플로에 도움이 됩니다.

## **FAQ**

**언제 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 대신 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)를 사용해야 합니까?**

모든 텍스트가 글꼴과 무관해야 할 때는 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)를 사용하십시오. 외부 글꼴을 사용하는 텍스트만 그래픽으로 변환하려면 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)를 사용합니다.

**SVG를 더 작게 만들기 위한 최적의 방법은 무엇입니까?**

먼저 삽입된 그림을 압축하고, 잘린 이미지 영역을 삭제하며, 대상 환경에서 제공할 수 있는 경우 연결된 글꼴 파일을 선택하십시오. 이미지 해상도 감소, JPEG 품질 저하, 텍스트 벡터화 각각이 품질과 크기에 다른 영향을 미치므로 결과를 테스트하십시오.

**내보낸 SVG 요소를 내보낸 후에 수정할 수 있습니까?**

예. 포맷팅 컨트롤러를 통해 ID를 할당한 후 후처리 도구나 브라우저 스크립트에서 해당 SVG 요소를 선택하여 수정할 수 있습니다.