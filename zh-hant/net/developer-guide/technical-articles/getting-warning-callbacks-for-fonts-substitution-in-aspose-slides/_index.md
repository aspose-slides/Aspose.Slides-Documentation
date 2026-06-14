---
title: 在 .NET 中取得字型替代的警告回呼
type: docs
weight: 120
url: /zh-hant/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告回呼
- 字型替代
- 渲染過程
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何在 Aspose.Slides for .NET 中取得字型替代的警告回呼，並準確顯示 PowerPoint 與 OpenDocument 簡報。"
---
## **簡介**

Aspose.Slides for .NET 允許您在渲染期間當所需字型在機器上不存在時接收字型替代的警告回呼。這些回呼有助於診斷缺少或無法存取的字型問題。

## **啟用警告回呼**

Aspose.Slides for .NET 提供簡單的 API 以在渲染簡報投影片時接收警告回呼。請依照以下步驟設定警告回呼：

1. 建立自訂回呼類別，實作 [IWarningCallback](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.warnings/iwarningcallback/) 介面以處理警告。
1. 使用如 [RenderingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/renderingoptions/)、[PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/htmloptions/) 等選項類別設定警告回呼。
1. 載入使用目標機器上不存在的字型的簡報。
1. 產生投影片縮圖或匯出簡報以觀察效果。

**自訂警告回呼類別：**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// 範例輸出:
//
// 字型將由 XYZ 替代為 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**產生投影片縮圖：**

```c#
// 設置警告回呼以在投影片渲染期間處理與字型相關的警告。
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// 從指定的檔案路徑載入簡報。
using var presentation = new Presentation("sample.pptx");

// 為簡報中的每張投影片產生縮圖影像。
foreach (var slide in presentation.Slides)
{
    // 使用指定的渲染選項取得投影片縮圖影像。
    using var image = slide.GetImage(options);
    // ...
}
```

**匯出為 PDF 格式：**

```c#
 // 設置警告回呼以在 PDF 匯出期間處理與字型相關的警告。
 var options = new PdfOptions();
 options.WarningCallback = new FontWarningHandler();

 // 從指定的檔案路徑載入簡報。
 using var presentation = new Presentation("sample.pptx");

 // 將簡報匯出為 PDF。
 using var stream = new MemoryStream();
 presentation.Save(stream, SaveFormat.Pdf, options);
 // ...
```

**匯出為 HTML 格式：**

```c#
 // 設置警告回呼以在 HTML 匯出期間處理與字型相關的警告。
 var options = new HtmlOptions();
 options.WarningCallback = new FontWarningHandler();

 // 從指定的檔案路徑載入簡報。
 using var presentation = new Presentation("sample.pptx");

 // 將簡報匯出為 HTML 格式。
 using var stream = new MemoryStream();
 presentation.Save(stream, SaveFormat.Html, options);
 // ...
```