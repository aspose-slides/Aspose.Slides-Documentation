---
title: 在 JavaScript 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/nodejs-java/convert-openoffice-odp/
keywords:
- 轉換 ODP
- ODP 轉換為圖像
- ODP 轉換為 GIF
- ODP 轉換為 HTML
- ODP 轉換為 JPG
- ODP 轉換為 MD
- ODP 轉換為 PDF
- ODP 轉換為 PNG
- ODP 轉換為 PPT
- ODP 轉換為 PPTX
- ODP 轉換為 TIFF
- ODP 轉換為影片
- ODP 轉換為 Word
- ODP 轉換為 XPS
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js 讓您輕鬆將 ODP 轉換為 PDF、HTML 和圖像格式。透過快速且精確的簡報轉換提升應用程式效能。"
---
[**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/nodejs-java/) 允許您將 OpenDocument (ODP) 簡報轉換為多種格式 (HTML、PDF、TIFF、SWF、XPS 等)。用於將 ODP 檔案轉換為其他文件格式的 API 與用於 PowerPoint (PPT 和 PPTX) 轉換作業的 API 相同。

例如，如果您需要將 ODP 簡報轉換為 PDF，您可以按以下方式操作：

```js
let presentation = null;
try {
  presentation = new aspose.slides.Presentation("presentation.odp");
  presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **常見問題**

**如果 ODP 檔案在轉換後的格式發生變化怎麼辦？**

ODP 與 PowerPoint 使用不同的簡報模型，某些元素——如表格、自訂字型或填充樣式——可能無法完全相同地呈現。建議您檢查輸出結果，必要時在程式碼中調整版面配置或格式。

**我需要安裝 OpenOffice 或 LibreOffice 才能使用 ODP 轉換嗎？**

不需要，Aspose.Slides 是獨立的函式庫，並不需要在系統上安裝 OpenOffice 或 LibreOffice。

**我可以在 ODP 轉換過程中自訂輸出格式（例如設定 PDF 選項）嗎？**

是的，Aspose.Slides 提供豐富的選項來自訂輸出。例如，將檔案儲存為 PDF 時，您可以透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pdfoptions/) 類別來控制壓縮、影像品質、文字呈現等設定。

**Aspose.Slides 適合用於伺服器端或雲端的 ODP 處理嗎？**

絕對可以。Aspose.Slides 專為桌面與伺服器環境設計，包括 Azure、AWS 以及 Docker 容器等雲端平台，且不依賴任何 UI。