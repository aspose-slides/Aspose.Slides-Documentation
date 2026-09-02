---
title: 在 .NET 中將 PowerPoint 簡報轉換為 XML
linktitle: PowerPoint 轉 XML
type: docs
weight: 145
url: /zh-hant/net/convert-powerpoint-to-xml/
keywords:
- 將 PowerPoint 轉換為 XML
- 將簡報轉換為 XML
- PPT 轉 XML
- PPTX 轉 XML
- ODP 轉 XML
- PowerPoint XML 簡報
- SaveFormat.Xml
- 將簡報儲存為 XML
- 將簡報匯出為 XML
- XML 串流
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides for .NET，將 PowerPoint 和 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **概述**

Aspose.Slides for .NET 可以將 PowerPoint 簡報轉換為 PowerPoint XML Presentation 格式。當您需要以文字為基礎的表示方式來檢查簡報結構、排除產生文件的問題、在自動化測試中比較輸出，或是與消耗 XML 而非簡報封裝的工作流程整合時，XML 輸出非常實用。

使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，並搭配 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 列舉中的 `Xml` 值。您可以直接將結果寫入檔案或寫入串流。

{{% alert color="info" title="注意" %}}

`SaveFormat.Xml` 會產生 PowerPoint XML Presentation。它不會擷取儲存在 PPTX 封裝內的各個 Office Open XML 部分。如果您需要完整的 PPTX 封裝部件，例如 `ppt/presentation.xml` 或單獨的投影片 XML 檔案，請直接檢查 PPTX 封裝本身。

{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑與 `SaveFormat.Xml` 傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管道）時，請使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 的串流版本。以下範例將結果寫入 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) 並將指標重新定位以便後續讀取：

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
using var xmlStream = new MemoryStream();

presentation.Save(xmlStream, SaveFormat.Xml);
xmlStream.Position = 0;

// 將 xmlStream 傳遞給工作流程中的下一個元件。
```

## **比較 XML 與簡報及匯出格式**

依據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 典型用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML Presentation | 檢查結構、排除問題、比較產生的輸出、以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 與較舊的 PowerPoint 工作流程相容 |
| PPTX (`.pptx`) | 包含多個部件的 Office Open XML 封裝 | 一般 PowerPoint 編輯與簡報交換 |
| PDF 或 TIFF | 固定版面頁面或多頁影像 | 檢視、列印與保存 |
| PNG、JPEG 或 SVG | 單一投影片的渲染圖像 | 縮圖、預覽與影像資產 |
| HTML 或 HTML5 | 網頁導向的簡報輸出 | 瀏覽器檢視與網路發佈 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢查與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染成頁面或視覺資產。[支援的檔案格式](/slides/zh-hant/net/supported-file-formats/) 表格將 PowerPoint XML Presentation 列為僅能儲存的格式，因此在工作流程必須將匯出檔案重新載入 Aspose.Slides 進行後續編輯時，請勿使用此格式。

## **常見問題**

**`SaveFormat.Xml` 與儲存 PPTX 檔案相同嗎？**

不是。PPTX 是包含多個 Office Open XML 部分的封裝，而 `SaveFormat.Xml` 只會產生 PowerPoint XML Presentation 檔案。

**我可以在不建立磁碟檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)。例如，可使用 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

不能。PowerPoint XML Presentation 目前僅支援儲存，不支援載入。若需要回圈編輯，請使用 PPTX 或其他受支援的簡報格式。

**XML 轉換會將每張投影片渲染成頁面或影像嗎？**

不會。XML 轉換只會寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF；若需要單張投影片的圖像，請使用 PNG、JPEG 或 SVG。