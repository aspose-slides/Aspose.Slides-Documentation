---
title: 在 .NET 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報轉 SVG
- 投影片轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- SVG 匯出選項
- 互動式 SVG
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖像、ID 與事件。"
---
## **概觀**

SVG 是一種可伸縮的基於 XML 的圖像格式，適用於 Web 發佈、投影片檢視器、無障礙工作流程和自動後處理。Aspose.Slides 將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片和 SVG 元素的寫入方式。

在匯出的 SVG 必須緊湊、在各瀏覽器上可預測或適合互動使用時，使用 [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)。

## **匯出投影片為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，選取投影片，並寫入至串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

檔名使用 [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) 而非迴圈索引。當投影片檢視器或網頁僅需特定圖形時，也可以使用 [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/) 匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) 控制 SVG 的呈現。對於文字框，[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) 會將文字框納入渲染區域，而 [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) 則決定是否套用框架旋轉。當文字必須在不使用連字的情況下呈現時，將 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) 設為 `true`。

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

## **控制文字與字型**

在將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參照方式。以下選項可協助您在匯出的 SVG 中平衡視覺一致性、文字選取與字型相依性。

### **向量化所有文字**

將 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 設為 `true`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，使視覺結果在各瀏覽器上更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

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

### **選擇外部字型的處理方式**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) 的值來處理外部載入的字型。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案、`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 只將使用外部字型的文字以圖形方式呈現。在嵌入字型前請確認字型授權。

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

## **降低嵌入圖像大小**

使用 [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 以降低嵌入圖片的解析度，使用 [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) 省略被裁切的來源區域，並使用 [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 來控制 JPEG 編碼品質。這些設定會在犧牲圖像忠實度或保留圖像資料的情況下降低檔案大小。

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

## **控制中繼檔點陣化解析度**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) 設定在 SVG 匯出期間對中繼檔點陣化的最低解析度限制。當 EMF 或 WMF 圖像被點陣化時，可使用它在細節與檔案大小之間取得平衡。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件都變成點陣圖像。

下載 [metafile-rasterization.pptx](metafile-rasterization.pptx)，其中包含具有緊密對角線的 EMF 圖像。以下範例透過 [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) 將其第一張投影片以三種點陣化解析度匯出。其他匯出設定保持相同，以便比較結果。

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

在輸出中，EMF 會在每個 SVG 中變成一個嵌入的 PNG。以下測量值僅針對提供的簡報；它們並非將 DPI 轉換為像素尺寸的一般公式。

| 中繼檔點陣化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小 (位元組) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下面的比較顯示在相同放大顯示大小下，嵌入點陣圖的相同區域。對角線在 72 DPI 時可見像素化，在較高解析度時邊緣較平滑，同時 SVG 檔案大小會增加。提升該數值不一定會改善所有細節或改變每張匯出的圖像。

![放大 72、150 與 300 DPI 的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 控制圖像解析度的縮減，並可能掩蓋變更中繼檔點陣化解析度的效果。[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 控制 JPEG 編碼品質，而非中繼檔點陣化解析度。

## **為圖形與文字指派穩定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 為每個 SVG 圖形設定 [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/)。若也要在文字 `tspan` 元素上設定 [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) 值，請實作 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)。使用 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 指派任一控制器。

以下控制器使用 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)，此 ID 在圖形的生命週期內保持穩定，並為其文字 span 使用可重複的計數器。這使得產生的 ID 適用於對未變更的簡報進行後處理。

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

## **新增 SVG 事件處理常式**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 中，呼叫 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) 並傳入 [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) 值，即可為匯出的圖形加入 JavaScript 事件處理常式。使用 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 指派控制器，並在承載結果的頁面或 SVG 文件中定義 JavaScript 函式。

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

承載頁面可以定義事件處理常式所參考的 JavaScript 函式。指派 ID 與事件處理常式可支援投影片檢視器、無障礙增強功能以及其他互動 SVG 工作流程。

## **常見問題**

**何時應使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 而非 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字必須獨立於字型時，使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)。當僅需將使用外部字型的文字轉換為圖形時，使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)。

**如何將 SVG 檔案尺寸縮小？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔案時選擇連結字型檔。測試結果，因為較低的圖像解析度、較低的 JPEG 品質以及向量化文字各有不同的品質與大小取捨。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取相符的 SVG 元素。