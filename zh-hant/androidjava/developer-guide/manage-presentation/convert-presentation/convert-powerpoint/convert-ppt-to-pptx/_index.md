---
title: 在 Android 上將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰教學、免費程式碼範例，且不需要 Microsoft Office 相依性。"
---
## **概述**

本文說明如何使用 Java 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。以下主題將會說明。

- 使用 Java 轉換 PPT 為 PPTX

## **在 Android 上將 PPT 轉換為 PPTX**

有關使用 Java 轉換 PPT 為 PPTX 的範例程式碼，請參閱以下章節，即[Convert PPT to PPTX](#convert-ppt-to-pptx)。它僅載入 PPT 檔案並以 PPTX 格式儲存。透過指定不同的儲存格式，亦可將 PPT 檔案另存為 PDF、XPS、ODP、HTML 等多種格式，詳見以下文章。

- [在 Android 上將 PPT 轉換為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)
- [在 Android 上將 PPT 轉換為 XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)
- [在 Android 上將 PPT 轉換為 HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)
- [在 Android 上將 PPT 轉換為 ODP](/slides/zh-hant/androidjava/save-presentation/)
- [在 Android 上將 PPT 轉換為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)

## **關於 PPT 轉換為 PPTX**

使用 Aspose.Slides API 轉換舊版 PPT 格式為 PPTX。如果您需要將成千上萬的 PPT 簡報轉換為 PPTX 格式，最好的解決方案是以程式方式執行。使用 Aspose.Slides API 只需幾行程式碼即可完成。該 API 完全相容於 PPT 轉換為 PPTX，且可以：

- 轉換包含母片、版面配置與投影片的複雜結構。
- 轉換含有圖表的簡報。
- 轉換含有群組圖形、自動圖形（如矩形與橢圓）以及自訂幾何形狀的簡報。
- 轉換自動圖形使用紋理與圖片填充樣式的簡報。
- 轉換包含佔位符、文字框與文字持有者的簡報。

{{% alert color="info" %}} 

請參閱 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式是基於 [**Aspose.Slides API**](https://products.aspose.com/slides/zh-hant/androidjava/) 建置的，您可看到基本 PPT 轉 PPTX 轉換功能的即時範例。Aspose.Slides Conversion 為 Web 應用程式，允許您拖放 PPT 格式的簡報檔案，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}} 

## **轉換 PPT 為 PPTX**

Aspose.Slides for Android via Java 現在讓開發人員能夠使用[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)類別實例存取 PPT，並將其轉換為相應的[PPTX](https://docs.fileformat.com/presentation/pptx/)格式。目前，它支援將[PPT ](https://docs.fileformat.com/presentation/ppt/)轉換為 PPTX 的部分功能。

Aspose.Slides for Android via Java 提供的[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation)類別代表一個 **PPTX** 簡報檔案。當建立物件時，Presentation 類別現在也可以存取 **PPT**。以下範例說明如何將 PPT 簡報轉換為 PPTX 簡報。

```java
import com.aspose.slides.*;

// 建立代表 PPT 檔案的 Presentation 物件
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
|**Figure : 原始 PPT 簡報**|

上述程式碼片段在轉換後產生以下 PPTX 簡報

|![todo:image_alt_text](http://i.imgur.com/tBXF3nA.png)|
| :- |
|**Figure: 轉換後產生的 PPTX 簡報**|

## **常見問題**

### PPT 與 PPTX 格式有何不同？

PPT 是 Microsoft PowerPoint 使用的舊二進位檔案格式，而 PPTX 是自 Microsoft Office 2007 起推出的基於 XML 的新格式。PPTX 檔案提供更佳的效能、較小的檔案大小以及更完善的資料復原能力。

### Aspose.Slides 是否支援批次將多個 PPT 檔案轉換為 PPTX？

是的，您可以在迴圈中使用 Aspose.Slides 程式化地批次轉換多個 PPT 檔案為 PPTX，適用於批次轉換情境。

### 轉換後內容與格式會被保留嗎？

Aspose.Slides 在轉換簡報時保持高度保真度。投影片版面配置、動畫、圖形、圖表及其他設計元素在 PPT 轉換為 PPTX 時都會被完整保留。

### 我可以將 PPT 檔案轉換為其他格式如 PDF 或 HTML 嗎？

是的，Aspose.Slides 支援將 PPT 檔案轉換為[多種格式](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveformat/)，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等影像格式。

### 在未安裝 Microsoft PowerPoint 的情況下，是否能將 PPT 轉換為 PPTX？

可以，Aspose.Slides 為獨立的 API，無需 Microsoft PowerPoint 或任何第三方軟體即可執行轉換。

### 是否有線上工具可用於 PPT 轉換為 PPTX？

是的，您可以使用免費的[Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)網路應用程式，直接在瀏覽器中完成轉換，無需撰寫任何程式碼。