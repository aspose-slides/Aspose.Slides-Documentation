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
description: "在 .NET 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、圖片、ID 與事件。"
---
## **概覽**

SVG 是一種可縮放的 XML 為基礎的圖像格式，適用於網站發佈、投影片檢視器、無障礙工作流程以及自動後處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔，並讓您控制文字、字型、圖片與 SVG 元素的寫入方式。

在匯出的 SVG 必須緊湊、在各瀏覽器間具可預測性，或需要即時互動時，請使用[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)，選取投影片，並將其寫入串流。下列範例會將簡報中的每張投影片匯出為單獨的 SVG 檔。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

檔名使用[ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/)而非迴圈索引。若投影片檢視器或網頁只需要特定圖形，也可以使用[IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/)匯出單一圖形。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) 控制 SVG 的呈現方式。對於文字框，[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) 會將文字框納入繪製區域，而[SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) 決定是否套用框的旋轉。若文字必須在不使用連字的情況下呈現，請將[SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) 設為 `true`。

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

## **控制箭頭端點的線尾裁切**

SVG 1.1 沒有標記內縮設定可指定線條在箭頭底下的停止位置。預設情況下，Aspose.Slides 會縮短匯出的線條，使其筆劃不會穿透標記。將[SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) 設為 `true`，即可將筆劃畫到線條的原始端點。此設定僅影響 SVG 輸出，線條在投影片上的位置與長度保持不變。

範例在第 2 點與第 10 點寬的線條上繪製三角形與菱形箭頭，並兩次匯出同一投影片，只變更裁切選項。

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

比較圖顯示 10 點寬線條的三角形箭頭。啟用裁切時，尖端尖銳；停用裁切時，筆劃會穿透標記的斜邊而呈現平坦的端點。

![在啟用裁切時呈現尖銳尖端、在停用裁切時呈現平坦端的放大 10 點三角形](line-end-cropping.png)

在範例的其他線條中，2 點寬的三角形的突出筆劃較不明顯。填滿的菱形在兩種寬度下皆會遮蓋筆劃的末端。

## **控制文字與字型**

將投影片匯出為 SVG 時，您可以控制文字是保留為文字還是轉換為向量圖形，以及外部字型的包含或參考方式。以下選項可協助您在視覺一致性、文字可選取性與字型相依性之間取得平衡。

### **將所有文字向量化**

將[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) 設為 `true`，即可將所有投影片文字寫入為向量圖形。這會消除字型相依性，使視覺結果在各瀏覽器間更一致，但文字將不再可在 SVG 中選取或搜尋。

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

### **選擇如何處理外部字型**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) 會使用[SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) 的值來決定外部載入的字型處理方式。選擇 `AddLinksToFontFiles` 以參照獨立的字型檔，`Embed` 以在 SVG 中嵌入字型資料，或 `Vectorize` 只將使用外部字型的文字轉為圖形。嵌入字型前請確認授權情況。

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

## **減少嵌入圖像大小**

使用[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 以降低嵌入圖片的解析度，使用[SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) 以省略被裁切的來源區域，並使用[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 來控制 JPEG 編碼品質。這些設定會在降低檔案大小的同時，以不同程度犧牲圖像真實度或保留的圖像資料。

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

## **控制圖形檔光柵化解析度**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) 設定在 SVG 匯出過程中對圖形檔進行光柵化時的下限解析度。使用此設定可在 EMF 或 WMF 圖像光柵化時在細節與檔案大小之間取得平衡。它不會為 SVG 定義全域 DPI，也不會強制投影片上的每個物件都轉為光柵圖像。

下載[metafile-rasterization.pptx](metafile-rasterization.pptx)（內含緊密排列的對角線 EMF 圖像）。下列範例透過[ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/) 將其第一張投影片以三種光柵化解析度匯出。其他匯出設定保持相同，以便比較結果。

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

輸出中，EMF 會在每個 SVG 中轉為一個嵌入的 PNG。以下測量僅針對提供的簡報；並非將 DPI 轉換為像素尺寸的通用公式。

| 圖形檔光柵化 DPI | 嵌入 PNG 尺寸 | SVG 檔案大小 (位元組) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

下方比較顯示相同區域的光柵圖在相同放大顯示尺寸下的差異。72 DPI 時對角線可見像素化，較高解析度則邊緣更平滑，且 SVG 檔案大小會增加。提升此數值未必能改善每個細節或改變每個匯出圖像。

![在 72、150、300 DPI 下放大的對角線細節](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) 控制圖像解析度降低，可能會掩蓋改變圖形檔光柵化解析度的效果。[SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) 控制 JPEG 編碼品質，而非圖形檔光柵化解析度。

## **為形狀與文字指派穩定的 ID**

使用[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 來為每個 SVG 形狀設定[ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/)。若要同時為文字 `tspan` 元素設定[ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) 值，請實作[ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)。將任一控制器指派給[SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)。

以下控制器使用[IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/)，其在形狀生命週期內保持穩定，並使用可重複的計數器產生文字跨度的 ID。這使得產生的 ID 適合於對未變更的簡報進行後處理。

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

## **新增 SVG 事件處理程式**

在[ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) 中，呼叫[ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) 並傳入[SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/) 值，即可為匯出的形狀新增 JavaScript 事件處理程式。將控制器指派給[SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

主頁面可以定義被處理程式參照的 JavaScript 函式。指派 ID 及事件處理程式可支援投影片檢視器、無障礙增強與其他互動式 SVG 工作流程。

## **FAQ**

**什麼時候應該使用[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)而不是[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

當所有文字都必須與字型無關時，請使用[SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/)。若僅需要將使用外部字型的文字轉為圖形，則使用[SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)。

**如何才能讓 SVG 檔案變小？**

首先壓縮嵌入的圖片、刪除被裁切的圖像區域，並在目標環境能提供字型檔時選擇使用連結字型檔。請測試結果，因為降低圖像解析度、降低 JPEG 品質與向量化文字各自都有不同的品質與大小取捨。

**匯出後我可以修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，之後即可在後處理工具或瀏覽器腳本中選取相應的 SVG 元素進行修改。