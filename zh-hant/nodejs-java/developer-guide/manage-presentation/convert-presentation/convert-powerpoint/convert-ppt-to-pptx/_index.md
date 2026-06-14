---
title: 在 JavaScript 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/nodejs-java/convert-ppt-to-pptx/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- PPT 轉 PPTX
- 將 PPT 儲存為 PPTX
- 匯出 PPT 為 PPTX
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰教學、免費程式碼範例，且不依賴 Microsoft Office。"
---
## **概述**

本文說明如何使用 JavaScript 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。以下主題將會涵蓋。

- 使用 JavaScript 將 PPT 轉換為 PPTX

## **Java 轉換 PPT 為 PPTX**

如需 JavaScript 範例程式碼將 PPT 轉換為 PPTX，請參考下方章節[Convert PPT to PPTX](#convert-ppt-to-pptx)。此示例僅載入 PPT 檔案並儲存為 PPTX 格式。透過指定不同的儲存格式，您還可以將 PPT 檔案儲存為 PDF、XPS、ODP、HTML 等其他格式，相關說明請參考下列文章。

- [使用 JavaScript 將 PPT 轉換為 PDF](/slides/zh-hant/nodejs-java/convert-powerpoint-to-pdf/)
- [使用 JavaScript 將 PPT 轉換為 XPS](/slides/zh-hant/nodejs-java/convert-powerpoint-to-xps/)
- [使用 JavaScript 將 PPT 轉換為 HTML](/slides/zh-hant/nodejs-java/convert-powerpoint-to-html/)
- [使用 JavaScript 將 PPT 轉換為 ODP](/slides/zh-hant/nodejs-java/save-presentation/)
- [使用 JavaScript 將 PPT 轉換為 PNG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)

## **關於 PPT 轉 PPTX 轉換**
使用 Aspose.Slides API 將舊版 PPT 格式轉換為 PPTX。如果您需要將數千個 PPT 簡報批次轉換為 PPTX 格式，最佳解決方案是以程式方式執行。透過 Aspose.Slides API 只要幾行程式碼即可完成。此 API 完全相容，能將 PPT 簡報轉換為 PPTX，且可執行以下操作：

- 轉換包含母片、版面配置與投影片的複雜結構。
- 轉換包含圖表的簡報。
- 轉換包含群組圖形、自動圖形（如矩形與橢圓）、自訂幾何圖形的簡報。
- 轉換具有紋理與圖片填充樣式的自動圖形的簡報。
- 轉換包含佔位符、文字框與文字持有者的簡報。

{{% alert color="primary" %}} 

請參考 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式是基於 [**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/nodejs-java/) 建置，您可即時看到基本 PPT 轉 PPTX 轉換功能的範例。Aspose.Slides Conversion 為一 Web 應用程式，允許您拖放 PPT 格式的簡報檔案，並下載已轉換為 PPTX 的檔案。

尋找其他即時的[**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}} 

## **將 PPT 轉換為 PPTX**
Aspose.Slides for Node.js via Java 目前提供開發人員透過 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別實例存取 PPT，並將其轉換為相應的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。現在已支援將 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分轉換為 PPTX。

Aspose.Slides for Node.js via Java 提供的 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別代表 **PPTX** 簡報檔案。透過在建立物件時即存取 **PPT**，Presentation 類別現在也能處理 PPT。以下範例示範如何將 PPT 簡報轉換為 PPTX 簡報。

```javascript
// 建立代表 PPTX 檔案的 Presentation 物件
var pres = new aspose.slides.Presentation("Aspose.ppt");
try {
    // 將 PPTX 簡報儲存為 PPTX 格式
    pres.save("ConvertedAspose.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**圖示：來源 PPT 簡報**|

上述程式碼片段在轉換後產生以下 PPTX 簡報

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**圖示：轉換後產生的 PPTX 簡報**|

## **常見問題**

**PPT 與 PPTX 格式有何差異？**

PPT 為 Microsoft PowerPoint 早期使用的二進位檔案格式，而 PPTX 為隨 Microsoft Office 2007 推出的基於 XML 的新格式。PPTX 檔案具備更佳的效能、較小的檔案大小，以及更好的資料復原能力。

**Aspose.Slides 是否支援批次將多個 PPT 檔案轉換為 PPTX？**

是的，您可以在迴圈中使用 Aspose.Slides 以程式方式批次轉換多個 PPT 檔案為 PPTX，適用於大量轉換的情境。

**轉換後內容與格式會被保留嗎？**

Aspose.Slides 在轉換簡報時保持高度相似度。投影片版面、動畫、圖形、圖表以及其他設計元素在 PPT 轉換為 PPTX 的過程中都會被完整保留。

**我能將 PPT 檔案轉換成其他格式，例如 PDF 或 HTML 嗎？**

可以，Aspose.Slides 支援將 PPT 檔案轉換為多種格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等影像格式。

**在未安裝 Microsoft PowerPoint 的情況下，是否可以將 PPT 轉換為 PPTX？**

可以，Aspose.Slides 為獨立的 API，無需安裝 Microsoft PowerPoint 或任何第三方軟體即可執行轉換。

**是否有線上工具可用於 PPT 轉換為 PPTX？**

可以，您可以使用免費的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網路應用程式，直接在瀏覽器中完成轉換，無需撰寫程式碼。