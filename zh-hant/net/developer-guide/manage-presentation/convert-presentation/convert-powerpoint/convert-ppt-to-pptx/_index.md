---
title: 在 .NET 中將 PPT 轉換為 PPTX
linktitle: PPT 轉 PPTX
type: docs
weight: 20
url: /zh-hant/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰教學、免費 C# 程式碼範例，無需 Microsoft Office 相依性。"
---
## **概觀**

本文說明如何使用 C# 以及線上 PPT 轉 PPTX 轉換應用程式，將 PowerPoint 簡報的 PPT 格式轉換為 PPTX 格式。以下主題將會討論。

- [在 C# 中將 PPT 轉換為 PPTX](#convert-ppt-to-pptx)

## **在 .NET 中將 PPT 轉換為 PPTX**

如需 C# 範例程式碼將 PPT 轉換為 PPTX，請參閱下方章節 [在 C# 中將 PPT 轉換為 PPTX](#convert-ppt-to-pptx)。它僅會載入 PPT 檔案並以 PPTX 格式儲存。透過指定不同的儲存格式，您也可以將 PPT 檔案儲存為 PDF、XPS、ODP、HTML 等多種格式，詳情請參考以下文章。

- [在 .NET 中將 PPT 轉換為 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)
- [在 .NET 中將 PPT 轉換為 XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)
- [在 .NET 中將 PPT 轉換為 HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)
- [在 .NET 中將 PPT 轉換為 ODP](/slides/zh-hant/net/save-presentation/)
- [在 .NET 中將 PPT 轉換為 PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)

## **關於 PPT 轉換為 PPTX**

使用 Aspose.Slides API 可將舊的 PPT 格式轉換為 PPTX。如果需要將數千個 PPT 簡報批次轉換為 PPTX 格式，最合適的解決方案是程式化執行。透過 Aspose.Slides API，只需幾行程式碼即可完成。此 API 完全相容於 PPT 轉換為 PPTX，且能夠：

- 轉換包含母片、版面配置與投影片的複雜結構。
- 轉換含有圖表的簡報。
- 轉換包含群組圖形、自動圖形（如矩形與橢圓）以及自訂幾何圖形的簡報。
- 轉換具有紋理與圖片填充樣式的自動圖形簡報。
- 轉換包含佔位符、文字框與文字持有者的簡報。

{{% alert color="info" %}} 

查看 [**Aspose.Slides PPT to PPTX Conversion**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式是基於 **Aspose.Slides API** 建置，您可以看到 PPT 轉換為 PPTX 基本功能的即時示範。Aspose.Slides Conversion 為網路應用程式，允許拖放 PPT 格式的簡報檔，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。

{{% /alert %}} 

## **將 PPT 轉換為 PPTX**

要將 PPT 轉換為 PPTX，只需將檔案名稱與儲存格式傳遞給 [**Save**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save/index) 方法，並使用 [**Presentation**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別。以下 C# 程式碼範例使用預設選項將簡報從 PPT 轉換為 PPTX。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 實例化一個表示 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("PPTtoPPTX.ppt");

// 將 PPTX 簡報儲存為 PPTX 格式
pres.Save("PPTtoPPTX_out.pptx", SaveFormat.Pptx);
```

閱讀更多關於 [**PPT 與 PPTX**](/slides/zh-hant/net/ppt-vs-pptx/) 簡報格式的資訊，以及 [**Aspose.Slides 支援 PPT 轉換為 PPTX**](/slides/zh-hant/net/convert-ppt-to-pptx/) 的說明。

## **常見問題**

### PPT 與 PPTX 格式的差異是什麼？

PPT 是 Microsoft PowerPoint 使用的舊版二進位檔案格式，而 PPTX 是自 Microsoft Office 2007 起推出的基於 XML 的新格式。PPTX 檔案提供更佳的效能、更小的檔案大小以及改進的資料復原能力。

### 能否在 .NET 中將 PPT 轉換為 PPTX？

可以，使用 Aspose.Slides for .NET 函式庫，只需幾行程式碼即可輕鬆載入 PPT 檔案並以 PPTX 格式儲存。

### Aspose.Slides 是否支援批次將多個 PPT 檔案轉換為 PPTX？

可以，您可以在迴圈中使用 Aspose.Slides 逐一將多個 PPT 檔案程式化轉換為 PPTX，適用於批次轉換情境。

### 轉換後內容與格式會被保留嗎？

Aspose.Slides 在轉換簡報時保持高度逼真。投影片版面配置、動畫、圖形、圖表以及其他設計元素皆會在 PPT 轉換為 PPTX 的過程中保留下來。

### 能否將 PPT 檔案轉換為其他格式如 PDF 或 HTML？

可以，Aspose.Slides 支援將 PPT 檔案轉換為多種格式，包括 PDF、XPS、HTML、ODP 以及 PNG、JPEG 等影像格式。

### 在未安裝 Microsoft PowerPoint 的情況下可以轉換 PPT 為 PPTX 嗎？

可以，Aspose.Slides for .NET 為獨立的 API，無需安裝 Microsoft PowerPoint 或任何第三方軟體即可執行轉換。

### 有線上工具可以進行 PPT 轉換為 PPTX 嗎？

可以，您可使用免費的 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網頁應用程式，直接在瀏覽器中完成轉換，無需撰寫任何程式碼。