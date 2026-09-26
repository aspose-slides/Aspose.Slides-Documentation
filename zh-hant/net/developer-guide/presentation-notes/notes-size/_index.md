---
title: 在 .NET 中變更註解頁尺寸與方向
linktitle: 註解頁尺寸
type: docs
weight: 10
url: /zh-hant/net/notes-size/
keywords:
- 註解頁尺寸
- 註解方向
- 橫向註解
- 直向註解
- 講義尺寸
- PowerPoint
- 簡報
- PPT
- PPTX
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中讀取並變更註解頁尺寸，切換方向，驗證儲存的尺寸，並將註解或講義匯出為 PDF 與影像。"
---
## **概觀**

使用 [Presentation.NotesSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/notessize/) 來存取簡報的註解頁設定。它會傳回一個 [INotesSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotessize/) 物件，其 [Size](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/inotessize/size/) 屬性是可寫入的。雖然設定物件本身是唯讀的，但您可以為其尺寸屬性指派新的尺寸。

寬度與高度以**點**（points）為單位指定，每英吋 72 點。例如，900 × 600 點等於 12.5 × 8⅓ 英吋。這些設定套用於整個簡報，而非單一投影片的註解。

| 設定 | 目的 |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/notessize/) | 控制註解頁的尺寸以及用於講義匯出的頁面尺寸。 |
| [Presentation.SlideSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/slidesize/) | 透過 [ISlideSize](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/islidesize/) 控制一般簡報投影片的尺寸。 |

變更任一設定不會自動變更另一個。變更註解頁的方向也不會旋轉一般投影片。請參閱 [Slide Size](/slides/zh-hant/net/slide-size/) 以調整一般投影片的大小。

以下範例使用現有的 `sample.pptx`。對於匯出範例，請使用至少包含一張投影片且有講者註解的簡報。每個範例皆可獨立執行。

## **讀取註解頁尺寸與方向**

讀取寬度與高度並比較以判斷方向：較寬的頁面為橫向，較高的頁面為直向，若尺寸相等則為正方形頁面。此範例會以點為單位列印實際尺寸，不會假設標準紙張大小。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **切換為橫向而不變更紙張大小**

若僅想變更方向，交換現有的寬度與高度。此做法會保留兩邊的長度，包括自訂紙張大小的長度。下方的條件式可防止已為橫向的頁面被切換回直向，且不會變更正方形頁面。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

對於直向，當 `size.Width > size.Height` 時使用相同的指派。除非您也想變更紙張大小，否則請勿改用 A4 或 Letter 尺寸。

## **設定與驗證自訂註解頁尺寸**

一次指派兩個尺寸，然後使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 來寫入簡報。此範例設定 900 × 600 點的橫向頁面，將其儲存為 PPTX，並再次開啟已儲存的檔案以檢查持久化的值。比較時允許 0.01 點的浮點容差；此容差並不保證每種檔案格式的精確度。

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

預期結果為 `900 x 600 points` 與 `Size preserved: True`。檢查新開啟的簡報可驗證已儲存的檔案，而不僅是記憶體中的設定。

## **匯出註解與講義**

頁面尺寸定義了註解或講義版面可用的區域。它們本身不會啟用這些版面配置：還需要設定匯出選項。一般投影片的匯出仍會使用投影片尺寸。

### **匯出註解為 PDF 與 PNG**

將 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notescommentslayoutingoptions/) 指派給 [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) 以在 PDF 中包含註解。此範例亦使用 [Slide.GetImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/slide/getimage/) 與 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/) 將第一張含註解的投影片渲染為 PNG。

[BottomTruncated](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notespositions/) 模式將註解保留於單一頁面；若註解超出則會被截斷。PDF 使用 900 × 600 點的頁面。以下使用 1 × 1 的影像縮放時，PNG 為 900 × 600 像素。點數描述頁面幾何；像素描述光柵輸出，其尺寸亦受渲染縮放影響。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

對於包含長註解的 PDF 匯出，[BottomFull](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/notespositions/) 會在需要時新增頁面。請勿將此模式與上述單投影片影像呼叫一起使用，因為它不支援此模式。調整尺寸後，檢查輸出是否有被截斷的註解以及既有 notes-master 物件的位置；僅變更頁面尺寸不應視為所有內容皆能適配的保證。更多有關註解匯出的資訊，請參閱 [Convert PowerPoint to PDF with Notes](/slides/zh-hant/net/convert-powerpoint-to-pdf-with-notes/)。

### **匯出講義為 PDF**

使用 [HandoutLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handoutlayoutingoptions/) 於單一頁面內放置多個投影片縮圖。以下範例設定 900 × 600 點的頁面，並使用 [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/handouttype/) 以每頁排列最多四張投影片。水平預設會控制投影片的排序；頁面方向則由其寬度與高度決定。

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

變更頁面大小會調整講義格線可用的區域，但不會改變來源投影片的尺寸。對於講義影像，請使用搭配講義版面的 [Presentation.GetImages](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/getimages/) 而非單一投影片的影像方法。於 Aspose.Slides 中，簡報層級的講義渲染會使用註解頁尺寸，而個別投影片的影像呼叫不會產生講義頁面。請參閱 [Handout Mode](/slides/zh-hant/net/convert-powerpoint-in-handout-mode/) 了解版面選項。

## **檢視器、匯出與列印中的頁面尺寸**

保持儲存的簡報尺寸、匯出的頁面尺寸與列印的紙張尺寸彼此分離：

- **Presentation viewers:** 檢視器可以使用其自行的版面規則顯示或列印註解。如果其他應用程式儲存了檔案，請重新開啟並再次檢查尺寸；該應用程式的格式轉換可能會使其正規化。
- **Export formats:** 上述註解與講義 PDF 範例使用已設定的頁面尺寸。光柵影像使用整數像素尺寸與渲染比例，因此在影像輸出時可能會將小數點的點值四捨五入。匯出一般投影片不會套用註解頁尺寸。
- **Printer drivers:** 紙張選擇、自動旋轉與適合頁面設定可能會改變實際輸出，而不會更改簡報或 PDF 中儲存的尺寸。若使用特定紙張大小，請配合印表機設定並檢查列印預覽。

## **常見問題**

**Can I set the notes size for just one slide?**  
註解頁尺寸是簡報層級的設定。單一投影片可以有不同的註解內容，但此屬性不會為每張投影片提供獨立的頁面尺寸。

**Why did changing notes orientation not change my slides?**  
註解頁與一般投影片具有獨立的尺寸。若想調整投影片本身的大小，請使用一般投影片尺寸設定。

**Why does my saved or printed result have a different size?**  
首先重新開啟已儲存的簡報並比較其註解尺寸。若尺寸已變更，請檢查是否在其他應用程式中儲存或轉換檔案時更改了頁面設定。若未變更，請檢查匯出版面、影像縮放、檢視器設定與印表機紙張選擇。