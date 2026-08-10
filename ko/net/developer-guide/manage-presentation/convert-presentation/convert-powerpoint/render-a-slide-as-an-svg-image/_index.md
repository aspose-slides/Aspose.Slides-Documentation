---
title: .NET에서 프레젠테이션 슬라이드를 SVG 이미지로 렌더링
linktitle: 슬라이드에서 SVG로
type: docs
weight: 50
url: /ko/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint에서 SVG로
- 프레젠테이션에서 SVG로
- 슬라이드에서 SVG로
- PPT에서 SVG로
- PPTX에서 SVG로
- SVG 내보내기 옵션
- 대화형 SVG
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PowerPoint 슬라이드를 SVG 이미지로 내보내고 Aspose.Slides를 사용해 폰트, 텍스트, 이미지, ID 및 이벤트를 제어합니다."
---
## **개요**

SVG는 웹 게시, 슬라이드 뷰어, 접근성 워크플로 및 자동 후처리 등에 적합한 확장 가능한 XML 기반 이미지 형식입니다. Aspose.Slides는 각 슬라이드를 별개의 SVG 파일로 내보내며 텍스트, 폰트, 그림 및 SVG 요소가 작성되는 방식을 제어할 수 있습니다.

Use [SVGOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **슬라이드를 SVG로 내보내기**

Create a [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/), select a slide, and write it to a stream. The following example exports every slide in a presentation as a separate SVG file.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

The filename uses [ISlide.SlideNumber](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/slidenumber/) rather than the loop index. You can also export an individual shape with [IShape.WriteAsSvg](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/writeassvg/) when a slide viewer or web page needs only that shape.

## **SVG 출력 구성**

[SVGOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/useframesize/) includes the text frame in the rendering area, and [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/useframerotation/) determines whether the frame rotation is applied. Set [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/disablefontligatures/) to `true` when text must be rendered without ligatures.

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

## **텍스트 및 폰트 제어**

### **모든 텍스트 벡터화**

Set [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/vectorizetext/) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

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

### **외부 폰트 처리 방법 선택**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/externalfontshandling/) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

## **내장 이미지 크기 줄이기**

Use [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/picturescompression/) to reduce the resolution of embedded pictures, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) to omit cropped source areas, and [SVGOptions.JpegQuality](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/jpegquality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **형상 및 텍스트에 안정적인 ID 할당**

Use [ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgshapeformattingcontroller/) to set [ISvgShape.Id](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgshape/id/) for each SVG shape. To set [ISvgTSpan.Id](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgtspan/id/) values on text `tspan` elements as well, implement [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Assign either controller with [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

The following controller uses [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/officeinteropshapeid/), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

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

In an [ISvgShapeFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgshapeformattingcontroller/), call [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/ko/net/aspose.slides.export/isvgshape/seteventhandler/) with a [SvgEvent](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) and define the JavaScript function in the page or SVG document that hosts the result.

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

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **FAQ**

**언제 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/vectorizetext/)를 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgexternalfontshandling/) 대신 사용해야 합니까?**

Use [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgoptions/vectorizetext/) when all text must be independent of fonts. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ko/net/aspose.slides.export/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**SVG 파일을 더 작게 만드는 가장 좋은 방법은 무엇입니까?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**내보낸 SVG 요소를 내보낸 후 수정할 수 있나요?**

Yes. Assign IDs through a formatting controller, then select the matching SVG elements in your post-processing tool or browser script.