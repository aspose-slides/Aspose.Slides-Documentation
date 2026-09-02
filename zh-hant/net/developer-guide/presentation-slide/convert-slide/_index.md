---
title: 在 .NET 中將簡報投影片轉換為影像
linktitle: 投影片轉影像
type: docs
weight: 41
url: /zh-hant/net/convert-slide/
keywords:
- 轉換投影片
- 匯出投影片
- 投影片轉影像
- 將投影片儲存為影像
- 投影片轉 EMF
- 投影片轉 PNG
- 投影片轉 JPEG
- 投影片轉點陣圖
- 投影片轉 TIFF
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 於 C# 中，將 PPT、PPTX 與 ODP 簡報的投影片轉換為 PNG、JPEG、GIF、TIFF、EMF 以及其他影像格式。"
---
## **簡介**

Aspose.Slides for .NET 能夠將 PowerPoint 與 OpenDocument 簡報中的單一投影片渲染為 PNG、JPEG、GIF、TIFF 以及其他影像格式。

若要將投影片轉換為影像，請遵循以下步驟：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入簡報。
2. 選取要渲染的投影片。
3. 如有需要，使用 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/) 或 [TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 類別設定渲染參數。
4. 呼叫 [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 方法。它會傳回一個 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件。
5. 呼叫 [IImage.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/save/) 方法，並使用 [ImageFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imageformat/) 值指定輸出格式。

## **將投影片轉換為 PNG 影像**

最簡單的轉換使用預設渲染設定。產生的 [IImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimage/) 物件可在記憶體中處理或儲存為檔案。

下列 C# 範例會渲染第一張投影片並將其儲存為 PNG 影像：

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **將投影片轉換為自訂尺寸的影像**

使用接受 [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) 參數的 [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 多載，以精確的像素尺寸渲染投影片。

以下範例會建立 1820 × 1040 的 JPEG 影像：

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **將含註解與備註的投影片轉換為影像**

預設情況下，投影片影像不會包含備註或評論。將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 物件指派給 [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) 屬性，以控制備註與評論的顯示位置。

以下範例會將截斷的備註置於投影片下方，並將評論置於右側：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
在投影片轉影像的過程中，請勿將 [NotesPosition](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) 屬性設定為 [BottomFull](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notespositions/)。備註的文字可能超過固定影像大小的容納範圍。請改用 [BottomTruncated](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notespositions/)。 
{{% /alert %}}

## **使用 TIFF 選項將投影片轉換為影像**

[TiffOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/tiffoptions/) 類別讓您可以控制渲染出的 TIFF 影像的尺寸、解析度與其他屬性。

以下範例會將第一張投影片以 300 DPI 渲染為 2160 × 2880 的 TIFF 影像：

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **將所有投影片轉換為影像**

遍歷投影片集合，以將整個簡報轉換為一系列影像。除非明確跳過，否則隱藏的投影片也會被包含。

以下範例會以水平與垂直比例為 2 的方式，將每張投影片渲染為 JPEG 影像：

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **產生增強型圖形檔 (EMF) 輸出**

增強型圖形檔 (EMF) 在需要將向量圖形與 Microsoft Office 或其他支援 Windows 視訊檔的 Windows 應用程式交換時相當有用。與像素圖像不同，EMF 能保留向量繪圖操作，且在放大時不會同樣失去清晰度。然而，EMF 主要是針對支援 Windows 視訊檔的應用程式的相容格式，並非通用的交換格式。此外，複雜的投影片內容，如點陣圖與某些效果，可能會以光柵化元素儲存在向量視訊檔容器中。

### **將投影片匯出為 EMF**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/writeasemf/) 方法會將 [ISlide](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/) 以 EMF 格式寫入目標串流。以下範例載入簡報、選取第一張投影片，並將其寫入 EMF 檔案串流：

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

呼叫端擁有傳遞給 [ISlide.WriteAsEmf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/writeasemf/) 的串流，必須負責關閉或釋放它。Aspose.Slides 會在串流的當前位置寫入，並保持串流開啟。

### **將 SVG 圖像轉換為 EMF 並加入簡報**

使用 [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/writeasemf/) 可將 SVG 內容轉換為 EMF。產生的位元組可透過 [IImageCollection.AddImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection/addimage/) 加入簡報，並使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 放置於投影片上。

以下範例從 SVG 標記建立 [SvgImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/svgimage/)，將其轉換為記憶體中的 EMF，插入第一張投影片，並儲存簡報：

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/isvgimage/writeasemf/) 不會取得目標串流的所有權。寫入完成後，串流位置會位於產生資料的末端。請如上例所示，將 `Position` 重設為起始位置，然後再將同一個可搜尋的串流傳遞給讀取器。保持串流開啟，直至使用者完成讀取，之後再釋放。或者，呼叫 `ToArray` 並將返回的位元組陣列傳遞給 [IImageCollection.AddImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection/addimage/); `ToArray` 會返回完整緩衝區，與目前的串流位置無關。

EMF 產生功能在所選 Aspose.Slides for .NET 版本支援的作業系統上皆可使用，但若缺少字型或本機圖形相依性，跨平台的渲染結果可能會不同。請安裝來源內容使用的字型或設定適當的替代方案，遵循您的 Aspose.Slides 套件的 [platform requirements](/slides/zh-hant/net/system-requirements/)，並在目標 EMF 消費應用程式中驗證結果。Linux 與 macOS 應用程式通常對顯示與編輯 Windows 視訊檔的支援有限或不一致。

## **彩色表情符號渲染**

{{% alert title="Note" color="info" %}}
在將簡報投影片轉換為影像時，若要正確呈現彩色表情符號，必須在執行轉換的系統上安裝簡報中使用的表情符號字型。例如，若簡報使用 **Segoe UI Emoji** 且此字型缺失，輸出影像中的表情符號可能會以單色顯示。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援渲染帶有動畫的投影片？**

不支援。 [GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islide/getimage/) 方法只會渲染投影片的靜態影像，不會匯出動畫。

**隱藏的投影片能匯出為影像嗎？**

可以。隱藏的投影片可像普通投影片一樣渲染。請將其納入處理迴圈，如上例所示。

**投影片影像會保留陰影與其他效果嗎？**

會。Aspose.Slides 會在投影片影像中渲染陰影、透明度及其他支援的圖形效果。