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
description: "在 .NET 中將 PowerPoint 投影片匯出為 SVG 圖像，並使用 Aspose.Slides 控制字型、文字、影像、ID 以及事件。"
---
## **概覽**

SVG 是一種可縮放的基於 XML 的影像格式，適用於網路發佈、投影片檢視器、可及性工作流程以及自動化後製處理。Aspose.Slides 會將每張投影片匯出為單獨的 SVG 檔案，並讓您控制文字、字型、圖片與 SVG 元素的寫入方式。

當匯出的 SVG 必須保持緊湊、在瀏覽器間具備可預測性，或需要支援互動時，請使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/)。

## **將投影片匯出為 SVG**

建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/)，選取投影片，並將其寫入串流。以下範例會將簡報中的每張投影片匯出為單獨的 SVG 檔案。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

檔名使用 [ISlide.SlideNumber](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/slidenumber/) 而不是迴圈索引。當投影片檢視器或網頁只需要特定形狀時，亦可使用 [IShape.WriteAsSvg](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/writeassvg/) 匯出單一形狀。

## **設定 SVG 輸出**

[SVGOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/) 控制 SVG 的渲染方式。對於文字框，[SVGOptions.UseFrameSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/useframesize/) 會將文字框納入渲染區域，而 [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/useframerotation/) 則決定是否套用框的旋轉。將 [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/disablefontligatures/) 設為 `true`，即可在渲染文字時不使用連字。

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

### **向量化全部文字**

將 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/vectorizetext/) 設為 `true`，即可將投影片中的所有文字寫入為向量圖形。這樣可以消除字型相依性，讓視覺結果在不同瀏覽器間更一致，但文字將不再可作為 SVG 文字被選取或搜尋。

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/externalfontshandling/) 會使用 [SvgExternalFontsHandling](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgexternalfontshandling/) 之值來處理外部載入的字型。可選擇 `AddLinksToFontFiles` 以參照獨立的字型檔案、`Embed` 以將字型資料嵌入 SVG，或 `Vectorize` 只將使用外部字型的文字渲染為圖形。嵌入字型前請先確認授權情形。

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

## **減少嵌入圖片的大小**

使用 [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/picturescompression/) 以降低嵌入圖片的解析度，使用 [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) 以省略被裁切的來源區域，並利用 [SVGOptions.JpegQuality](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/jpegquality/) 來控制 JPEG 編碼品質。這些設定會以犧牲影像細節或保留的圖像資料為代價，減少檔案大小。

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

## **為形狀與文字指派穩定的 ID**

使用 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshapeformattingcontroller/) 為每個 SVG 形狀設定 [ISvgShape.Id](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshape/id/)。若也要在文字 `tspan` 元素上設定 [ISvgTSpan.Id](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgtspan/id/) 值，請實作 [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshapeandtextformattingcontroller/)。將任一控制器指派給 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/shapeformattingcontroller/)。

以下控制器使用 [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishape/officeinteropshapeid/)，此 ID 在形狀生命週期內保持穩定，並使用可重複的計數器為其文字跨度產生 ID。這使得產生的 ID 適合於對未變更的簡報進行後續處理。

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

## **新增 SVG 事件處理程序**

在 [ISvgShapeFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshapeformattingcontroller/) 中，呼叫 [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/isvgshape/seteventhandler/) 並傳入 [SvgEvent](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgevent/) 值，即可為匯出的形狀加入 JavaScript 事件處理程序。透過 [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) 指派此控制器，並在承載結果的頁面或 SVG 文件中定義相應的 JavaScript 函式。

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

主頁面可以定義被處理程序引用的 JavaScript 函式。指派 ID 與事件處理程序後，可支援投影片檢視器、可及性增強以及其他互動式 SVG 工作流程。

## **常見問題**

**什麼時候應該使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/vectorizetext/) 而不是 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgexternalfontshandling/)？**

當所有文字必須獨立於字型時，請使用 [SVGOptions.VectorizeText](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/vectorizetext/)。當只有使用外部字型的文字需要轉換為圖形時，請使用 [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgexternalfontshandling/)。

**如何讓 SVG 檔案變得更小？**

首先壓縮嵌入的圖片、刪除裁切的圖像區域，並在目標環境能提供字型檔案時選擇使用連結字型檔。請測試結果，因為降低圖片解析度、降低 JPEG 品質以及向量化文字各自會在品質與檔案大小之間產生不同的取捨。

**我可以在匯出後修改 SVG 元素嗎？**

可以。透過格式化控制器指派 ID，然後在後處理工具或瀏覽器腳本中選取相對應的 SVG 元素進行修改。