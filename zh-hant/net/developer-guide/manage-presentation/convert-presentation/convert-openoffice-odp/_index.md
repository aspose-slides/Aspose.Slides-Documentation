---
title: 在 .NET 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/net/convert-openoffice-odp/
keywords:
- 轉換 ODP
- ODP 轉圖片
- ODP 轉 GIF
- ODP 轉 HTML
- ODP 轉 JPG
- ODP 轉 MD
- ODP 轉 PDF
- ODP 轉 PNG
- ODP 轉 PPT
- ODP 轉 PPTX
- ODP 轉 TIFF
- ODP 轉影片
- ODP 轉 Word
- ODP 轉 XPS
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 讓您輕鬆將 ODP 轉換為 PDF、HTML 與影像格式。透過快速且精確的簡報轉換，提升您的 .NET 應用程式效能。"
---
## **簡介**

[**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/net/) 允許您將 OpenDocument (ODP) 簡報轉換為多種格式 (HTML、PDF、TIFF、SWF、XPS 等)。用於將 ODP 檔案轉換為其他文件格式的 API 與用於 PowerPoint (PPT 和 PPTX) 轉換操作的 API 相同。

例如，如果您需要將 ODP 簡報轉換為 PDF，您可以按下列方式執行：

```cs
using (Presentation presentation = new Presentation("presentation.odp"))
{
    presentation.Save("presentation.pdf", SaveFormat.Pdf);
}
```

## **在不同應用程式中的 OpenDocument 簡報**

當在 PowerPoint 中開啟 OpenDocument 簡報 (ODP) 檔案時，可能無法保留原先建立該檔案之應用程式的格式。這是因為 OpenDocument 簡報應用程式與 PowerPoint 應用程式提供的功能與呈現行為不同。

以下是一些差異：

- 在 PowerPoint 中，表格通常最後渲染，可能覆蓋其他形狀，無論它們在 ODP 投影片上的順序如何。  
- PowerPoint 不支援 ODP 表格的圖片填充。  
- LibreOffice/OpenOffice Impress 不支援文字垂直旋轉 (270°、堆疊) 與分散對齊。  
- LibreOffice/OpenOffice Impress 不支援文字的圖片填充、漸層填充與圖案填充。

MS PowerPoint 與 LibreOffice/OpenOffice Impress 也以不同方式處理清單。使用 PowerPoint 建立的 ODP 檔案在 LibreOffice/OpenOffice Impress 中可能無法正確顯示，反之亦然。

下圖顯示在 LibreOffice Impress 中建立的清單樣式：

![ODP list example](odp-list-example.png)

Aspose.Slides 以確保 ODP 清單在 LibreOffice/OpenOffice Impress 中正確顯示的方式儲存它們。

[了解有關 OpenDocument 格式與 PowerPoint 的更多資訊](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)。

## **常見問題**

**如果 ODP 檔案的格式在轉換後發生變化該怎麼辦？**

ODP 與 PowerPoint 使用不同的簡報模型，某些元素——例如表格、自訂字型或填充樣式——可能無法完全相同地呈現。建議檢視輸出結果，並在需要時於程式碼中調整版面配置或格式。

**我需要安裝 OpenOffice 或 LibreOffice 才能使用 ODP 轉換嗎？**

不需要，Aspose.Slides for .NET 是獨立的函式庫，無需在系統上安裝 OpenOffice 或 LibreOffice。

**在 ODP 轉換過程中，我可以自訂輸出格式嗎（例如設定 PDF 選項）？**

是的，Aspose.Slides 提供了豐富的選項以自訂輸出。例如，匯出為 PDF 時，您可以透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/pdfoptions/) 類別控制壓縮、影像品質、文字呈現等設定。

**Aspose.Slides 適合用於伺服器端或雲端的 ODP 處理嗎？**

絕對可以。Aspose.Slides for .NET 專為桌面與伺服器環境設計，亦支援 Azure、AWS、Docker 容器等雲端平台，且不依賴任何 UI 元件。