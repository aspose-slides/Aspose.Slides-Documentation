---
title: 在 Java 中轉換 OpenDocument 簡報
linktitle: 轉換 OpenDocument
type: docs
weight: 10
url: /zh-hant/java/convert-openoffice-odp/
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
- 簡報
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 讓您輕鬆將 ODP 轉換為 PDF、HTML 和圖片格式。透過快速且精確的簡報轉換，提升您的 Java 應用程式性能。"
---
## **簡介**

[**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/java/) 允許您將 OpenDocument (ODP) 簡報轉換為多種格式（HTML、PDF、TIFF、SWF、XPS 等）。用於將 ODP 檔案轉換為其他文件格式的 API 與用於 PowerPoint（PPT 和 PPTX）轉換操作的 API 相同。

例如，如果您需要將 ODP 簡報轉換為 PDF，您可以這樣做：

```java
Presentation presentation = null;
try {
    presentation = new Presentation("pres.odp");
    presentation.save("pres.pdf", SaveFormat.Pdf);
    
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **在不同應用程式中的 OpenDocument 簡報**

當在 PowerPoint 中開啟 OpenDocument 簡報（ODP）檔案時，可能無法保留原始應用程式的格式。這是因為 OpenDocument 簡報應用程式與 PowerPoint 應用程式提供的功能和渲染行為不同。

以下是一些差異：

- 在 PowerPoint 中，表格通常最後渲染，可能會覆蓋其他圖形，無論它們在 ODP 幻燈片上的順序如何。
- PowerPoint 不支援 ODP 表格的圖片填充。
- LibreOffice/OpenOffice Impress 不支援文字的垂直旋轉（270°、堆疊）和分散對齊。
- LibreOffice/OpenOffice Impress 不支援文字的圖片填充、漸層填充和圖案填充。

MS PowerPoint 與 LibreOffice/OpenOffice Impress 也以不同方式處理清單。用 PowerPoint 建立的 ODP 檔案在 LibreOffice/OpenOffice Impress 中可能顯示不正確，反之亦然。

下圖顯示了在 LibreOffice Impress 中建立的清單外觀：

![ODP 列表範例](odp-list-example.png)

Aspose.Slides 以確保在 LibreOffice/OpenOffice Impress 中正確顯示的方式儲存 ODP 清單。

[了解更多關於 OpenDocument 格式和 PowerPoint 的資訊](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **常見問題**

**如果我的 ODP 檔案在轉換後格式發生變化，該怎麼辦？**

ODP 與 PowerPoint 使用不同的簡報模型，某些元素（如表格、自訂字型或填充樣式）可能無法完全相同地呈現。建議檢查輸出結果，必要時在程式碼中調整版面或格式。

**使用 ODP 轉換是否需要安裝 OpenOffice 或 LibreOffice？**

不需要，Aspose.Slides 是獨立的函式庫，無需在系統上安裝 OpenOffice 或 LibreOffice。

**我可以在 ODP 轉換過程中自訂輸出格式嗎（例如設定 PDF 選項）？**

可以，Aspose.Slides 提供豐富的選項來自訂輸出。例如，將檔案儲存為 PDF 時，您可以透過 [PdfOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/pdfoptions/) 類別控制壓縮、影像品質、文字渲染等。

**Aspose.Slides 是否適用於伺服器端或雲端的 ODP 處理？**

絕對適用。Aspose.Slides 設計可在桌面與伺服器環境中使用，包括 Azure、AWS 以及 Docker 容器等雲端平台，且不依賴任何 UI。