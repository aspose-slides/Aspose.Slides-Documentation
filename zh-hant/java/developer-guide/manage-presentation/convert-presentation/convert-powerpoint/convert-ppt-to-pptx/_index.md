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
- 將 PPT 匯出為 PPTX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰教學、免費程式碼範例，無需 Microsoft Office 相依性。"
---
## **概述**

本文說明如何使用 Java 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。以下主題將被討論。

- 使用 Java 轉換 PPT 為 PPTX

## **使用 Java 轉換 PPT 為 PPTX**

欲取得 Java 範例程式碼以將 PPT 轉換為 PPTX，請參考下方的 [Convert PPT to PPTX](#convert-ppt-to-pptx) 章節。它僅會載入 PPT 檔案並儲存為 PPTX 格式。透過指定不同的儲存格式，您亦可將 PPT 檔案另存為 PDF、XPS、ODP、HTML 等多種格式，相關說明請參閱以下文章。

- [將 PPT 轉換為 PDF (Java)](/slides/zh-hant/java/convert-powerpoint-to-pdf/)
- [將 PPT 轉換為 XPS (Java)](/slides/zh-hant/java/convert-powerpoint-to-xps/)
- [將 PPT 轉換為 HTML (Java)](/slides/zh-hant/java/convert-powerpoint-to-html/)
- [將 PPT 轉換為 ODP (Java)](/slides/zh-hant/java/save-presentation/)
- [將 PPT 轉換為 PNG (Java)](/slides/zh-hant/java/convert-powerpoint-to-png/)

## **關於 PPT 轉換為 PPTX**

使用 Aspose.Slides API 將舊版 PPT 格式轉換為 PPTX。如果您需要將數千個 PPT 簡報批次轉換為 PPTX 格式，最佳解決方案是以程式方式執行。透過 Aspose.Slides API 只需幾行程式碼即可完成。此 API 完全相容於將 PPT 簡報轉換為 PPTX，且可執行以下操作：

- 轉換包含母片、版面配置與投影片的複雜結構。
- 轉換含圖表的簡報。
- 轉換含群組圖形、自動圖形（如矩形與橢圓）以及自訂幾何形狀的簡報。
- 轉換具有紋理與圖片填充樣式的自動圖形簡報。
- 轉換包含佔位符、文字框與文字持有者的簡報。

{{% alert color="primary" %}} 

請查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式是基於 [**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/java/) 建置，因此您可以看到基本 PPT 轉 PPTX 轉換功能的即時範例。Aspose.Slides Conversion 是一個網路應用程式，允許將 PPT 格式的簡報檔案拖放上傳，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}} 

## **轉換 PPT 為 PPTX**

Aspose.Slides for Java 現在讓開發人員能透過 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別實例存取 PPT，並將其轉換為相對應的 [PPTX](https://docs.fileformat.com/presentation/pptx/) 格式。目前支援將 [PPT](https://docs.fileformat.com/presentation/ppt/) 部分轉換為 PPTX。欲了解 PPT 轉 PPTX 轉換中支援與不支援的功能，請參閱此文件 [link](/slides/zh-hant/java/ppt-to-pptx-conversion/)。

Aspose.Slides for Java 提供的 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別代表一個 **PPTX** 簡報檔案。當物件被實例化時，Presentation 類別現在也能存取 **PPT**。以下範例說明如何將 PPT 簡報轉換為 PPTX 簡報。

```java
// 實例化一個代表 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("Aspose.ppt");
try {
// 將 PPTX 簡報儲存為 PPTX 格式
    pres.save("ConvertedAspose.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](http://i.imgur.com/Y9jaUtI.png)|
| :- |
|**圖：來源 PPT 簡報**|

上述程式碼片段在轉換後產生以下 PPTX 簡報：

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**圖：轉換後產生的 PPTX 簡報**|

## **常見問題**

**PPT 與 PPTX 格式有何不同？**

PPT 是 Microsoft PowerPoint 早期使用的二進位檔案格式，而 PPTX 是自 Microsoft Office 2007 起採用的基於 XML 的新格式。PPTX 檔案提供更佳的效能、較小的檔案大小以及更好的資料復原能力。

**Aspose.Slides 是否支援批次將多個 PPT 檔案轉換為 PPTX？**

是的，您可以在迴圈中使用 Aspose.Slides 以程式方式批次將多個 PPT 檔案轉換為 PPTX，適用於大量轉換的情境。

**轉換後內容與格式會被保留嗎？**

Aspose.Slides 在轉換簡報時保持高度相似度。投影片版面、動畫、圖形、圖表及其他設計元素在 PPT 轉 PPTX 的過程中皆會被完整保留。

**我可以將 PPT 檔案轉換成其他格式，例如 PDF 或 HTML 嗎？**

可以，Aspose.Slides 支援將 PPT 檔案轉換為[多種格式](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等影像格式。

**在未安裝 Microsoft PowerPoint 的情況下能否轉換 PPT 為 PPTX？**

可以，Aspose.Slides 為獨立的 API，無需安裝 Microsoft PowerPoint 或任何第三方軟體即可執行轉換。

**是否有線上工具可用於 PPT 轉 PPTX 轉換？**

可以，您可使用免費的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網頁應用程式，在瀏覽器中直接完成轉換，且不需要撰寫程式碼。