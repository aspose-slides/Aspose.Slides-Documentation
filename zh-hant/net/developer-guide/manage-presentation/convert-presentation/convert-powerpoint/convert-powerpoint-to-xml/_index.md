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
description: "在 C# 中使用 Aspose.Slides for .NET，將 PowerPoint 與 OpenDocument 簡報轉換為 PowerPoint XML 檔案或串流。"
---
## **總覽**

Aspose.Slides for .NET 可以將 PowerPoint 簡報轉換為 PowerPoint XML 簡報格式。當您需要以文字為基礎的表示來檢查簡報結構、排除產生的文件問題、在自動化測試中比較輸出，或整合需要 XML 而非簡報封裝的工作流程時，XML 輸出非常有用。

使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，搭配來自 [SaveFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveformat/) 列舉的 `Xml` 值。您可以將結果直接寫入檔案或寫入串流。

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` 會建立 PowerPoint XML 簡報。它不會提取 PPTX 封裝內部儲存的各個 Office Open XML 部分。若您需要完整的 PPTX 封裝部件，例如 `ppt/presentation.xml` 或單一投影片的 XML 檔案，請檢查 PPTX 封裝本身。
{{% /alert %}}

## **將簡報轉換為 XML 檔案**

使用 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別載入來源簡報，然後將輸出路徑和 `SaveFormat.Xml` 傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)。來源可以是任何支援載入的簡報格式，例如 PPT、PPTX 或 ODP。

以下範例將 PPTX 簡報轉換為 XML 檔案：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.xml", SaveFormat.Xml);
```

## **將 XML 輸出寫入串流**

當 XML 必須保留在記憶體中或傳遞給其他元件（例如 Web 服務、儲存提供者或 XML 處理管線）時，請使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 的串流重載。以下範例將結果寫入 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) 並將其倒回以便後續讀取：

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

根據結果的使用方式選擇輸出格式：

| 格式 | 輸出 | 常見用途 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 簡報 | 檢查結構、排除問題、比較產生的輸出，以及基於 XML 的整合 |
| PPT (`.ppt`) | 舊版二進位簡報檔案 | 與舊版 PowerPoint 工作流程的相容性 |
| PPTX (`.pptx`) | 包含多個部分的 Office Open XML 套件 | 一般的 PowerPoint 編輯與簡報交換 |
| PDF or TIFF | 固定版面的頁面或 TIFF 圖像 | 檢視、列印與存檔 |
| PNG, JPEG, or SVG | 單一投影片的渲染表示 | 縮圖、預覽與圖像資產 |
| HTML or HTML5 | 面向 Web 的簡報輸出 | 在瀏覽器檢視與 Web 發布 |

與 PPT 與 PPTX 不同，XML 輸出主要用於檢查與資料導向的工作流程。與 PDF、TIFF、HTML 以及投影片影像格式不同，XML 代表的是簡報資料，而非將投影片渲染為頁面或視覺資產。[支援的檔案格式](/slides/zh-hant/net/supported-file-formats/) 表格列出了 Aspose.Slides 可以載入、匯入、儲存或呈現的所有格式。

## **常見問題**

**`SaveFormat.Xml` 是否等同於儲存為 PPTX 檔案？**

否。PPTX 是一個包含多個 Office Open XML 部分的封裝，而 `SaveFormat.Xml` 會建立 PowerPoint XML 簡報檔案。

**我可以在不在磁碟上建立檔案的情況下儲存 XML 輸出嗎？**

可以。將可寫入的串流傳遞給 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/)。例如，使用 [MemoryStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=net-10.0) 進行記憶體內處理。

**Aspose.Slides 能再次載入匯出的 XML 檔案嗎？**

可以。將 XML 檔案或串流傳遞給 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/presentation/) 建構子。然後 [Presentation.SourceFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/sourceformat/) 會回傳 `SourceFormat.Xml`。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentationfactory/getpresentationinfo/) 會為此格式回報 `LoadFormat.Unknown`，因此請勿以此判斷是否能開啟 XML 檔案。

**XML 轉換會將每張投影片渲染為頁面或影像嗎？**

否。XML 轉換只寫入結構化的簡報資料。若需要頁面導向的輸出，請使用 PDF 或 TIFF；若需要單一投影片的影像，請使用 PNG、JPEG 或 SVG。