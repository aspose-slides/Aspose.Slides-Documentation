---
title: 在 Java 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰教學、免費程式碼範例，無需 Microsoft Office 相依性。"
---
## **概覽**

本文說明如何使用 Java 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。涵蓋以下主題。

- 在 Java 中將 PPT 轉換為 PPTX

## **在 Java 中將 PPT 轉換為 PPTX**

欲取得 Java 範例程式碼，請參閱以下章節 [Convert PPT to PPTX](#convert-ppt-to-pptx)。程式碼僅會載入 PPT 檔案並以 PPTX 格式儲存。透過指定不同的儲存格式，亦可將 PPT 檔案另存為 PDF、XPS、ODP、HTML 等多種格式，相關說明請參閱下列文章。

- [在 Java 中將 PPT 轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)
- [在 Java 中將 PPT 轉換為 XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)
- [在 Java 中將 PPT 轉換為 HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)
- [在 Java 中將 PPT 轉換為 ODP](/slides/zh-hant/java/save-presentation/)
- [在 Java 中將 PPT 轉換為 PNG](/slides/zh-hant/java/convert-powerpoint-to-png/)

## **關於 PPT 轉 PPTX 轉換**
使用 Aspose.Slides API 可將舊版 PPT 格式轉換為 PPTX。如果需要將數千個 PPT 簡報批次轉換為 PPTX，最佳做法是以程式方式執行。透過 Aspose.Slides API，只需數行程式碼即可完成。此 API 完全相容於 PPT 轉 PPTX，且可：

- 轉換包含母片、版面配置與投影片的複雜結構。
- 轉換含圖表的簡報。
- 轉換包含群組圖形、自動圖形（如矩形與橢圓）、具自訂幾何形狀的簡報。
- 轉換具有紋理與圖片填充樣式的自動圖形簡報。
- 轉換含占位符、文字框與文字持有者的簡報。

{{% alert color="info" %}} 

請參考 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式建基於 [**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/java/)，您可以即時看到基本 PPT 轉 PPTX 功能的範例。Aspose.Slides Conversion 為 Web 應用程式，可直接拖放 PPT 格式的簡報檔，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}} 

## **將 PPT 轉換為 PPTX**
Aspose.Slides for Java 現在讓開發人員透過 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別存取 PPT，並將其轉換為相應的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前支援將 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分轉換為 PPTX。如需了解 PPT 轉 PPTX 支援與不支援的功能，請參閱此文件 [link](/slides/zh-hant/java/ppt-to-pptx-conversion/)。

Aspose.Slides for Java 提供的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別代表 **PPTX** 簡報檔案。此類別現在也可在實例化時直接存取 **PPT**。以下範例示範如何將 PPT 簡報轉換為 PPTX 簡報。

```java
import com.aspose.slides.*;

// 建立一個代表 PPT 檔案的 Presentation 物件
Presentation pres = new Presentation("Aspose.ppt");
try {
// 將 PPT 簡報儲存為 PPTX 格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**圖 1：原始 PPT 簡報**|

上述程式碼片段在轉換後產生以下 PPTX 簡報：

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**圖 2：轉換後產生的 PPTX 簡報**|

## **常見問題**

### PPT 與 PPTX 格式有何差異？

PPT 為 Microsoft PowerPoint 较早期的二進位檔案格式，而 PPTX 為隨 Microsoft Office 2007 推出的基於 XML 的新格式。PPTX 檔案具備更佳效能、較小檔案大小以及更好的資料復原能力。

### Aspose.Slides 是否支援批次將多個 PPT 檔案轉換為 PPTX？

是，您可以在迴圈中使用 Aspose.Slides 以程式方式批次轉換多個 PPT 檔案為 PPTX，適用於大量轉換情境。

### 轉換後內容與格式會被保留嗎？

Aspose.Slides 在轉換簡報時保持高相似度。投影片版面、動畫、圖形、圖表以及其他設計元素皆會在 PPT 轉 PPTX 時被完整保留。

### 我可以將 PPT 檔案轉換為其他格式，例如 PDF 或 HTML 嗎？

可以，Aspose.Slides 支援將 PPT 檔案轉換為多種格式，包括 PDF、XPS、HTML、ODP，亦支援 PNG、JPEG 等影像格式，詳情請見 [multiple formats](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/)。

### 是否能在未安裝 Microsoft PowerPoint 的環境下執行 PPT 轉 PPTX？

可以，Aspose.Slides 為獨立的 API，無需 Microsoft PowerPoint 或任何第三方軟體即可完成轉換。

### 是否有線上工具可供 PPT 轉 PPTX 使用？

有，您可以免費使用 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網頁應用程式，在瀏覽器中直接完成轉換，無需編寫程式碼。