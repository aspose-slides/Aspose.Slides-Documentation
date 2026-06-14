---
title: 在 Python 中將 PPT 轉換為 PPTX
linktitle: PPT 轉換為 PPTX
type: docs
weight: 20
url: /zh-hant/python-net/convert-ppt-to-pptx/
keywords:
- 轉換 PPT
- PPT 轉換為 PPTX
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中快速將舊版 PPT 簡報轉換為現代 PPTX — 清晰的教學、免費範例程式碼，無需 Microsoft Office 相依性。"
---
## **概述**

本文說明如何使用 Python 以及線上 PPT 轉 PPTX 轉換應用程式，將 PPT 格式的 PowerPoint 簡報轉換為 PPTX 格式。涵蓋以下主題：

- 使用 Python 將 PPT 轉換為 PPTX

## **使用 Python 轉換 PPT 為 PPTX**

欲取得將 PPT 轉換為 PPTX 的 Python 範例程式碼，請參閱以下章節，即 [將 PPT 轉換為 PPTX](#convert-ppt-to-pptx)。它僅會載入 PPT 檔案並以 PPTX 格式儲存。透過指定不同的儲存格式，您亦可將 PPT 檔案儲存為 PDF、XPS、ODP、HTML 等多種格式，相關說明請參考以下文章：

- [將 PPT 轉換為 PDF（Python）](/slides/zh-hant/python-net/convert-powerpoint-to-pdf/)
- [將 PPT 轉換為 XPS（Python）](/slides/zh-hant/python-net/convert-powerpoint-to-xps/)
- [將 PPT 轉換為 HTML（Python）](/slides/zh-hant/python-net/convert-powerpoint-to-html/)
- [將 PPT 轉換為 ODP（Python）](/slides/zh-hant/python-net/save-presentation/)
- [將 PPT 轉換為 PNG（Python）](/slides/zh-hant/python-net/convert-powerpoint-to-png/)

## **關於 PPT 轉換為 PPTX**

使用 Aspose.Slides API 將舊的 PPT 格式轉換為 PPTX。若您需要將成千上萬的 PPT 簡報轉換為 PPTX 格式，最佳解決方案是以程式方式執行。藉由 Aspose.Slides API，僅需幾行程式碼即可完成。該 API 完全相容於將 PPT 簡報轉換為 PPTX，且能夠：

- 轉換複雜的母片、版面配置與投影片結構。
- 轉換含圖表的簡報。
- 轉換包含群組圖形、自動圖形（如矩形與橢圓）以及自訂幾何圖形的簡報。
- 轉換含有紋理與圖片填充樣式之自動圖形的簡報。
- 轉換包含占位符、文字框與文字持有者的簡報。

{{% alert color="primary" %}}

請查看 [**Aspose.Slides PPT 轉換為 PPTX**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 應用程式：

[](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx)

此應用程式是基於 **Aspose.Slides API** 建置，您可以看到基本 PPT 轉換為 PPTX 功能的即時範例。Aspose.Slides Conversion 為一個網路應用程式，可讓您拖放 PPT 格式的簡報檔，並下載已轉換為 PPTX 的檔案。

尋找其他即時的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/zh-hant/conversion/) 範例。
{{% /alert %}}

## **將 PPT 轉換為 PPTX**

要將 PPT 轉換為 PPTX，只需將檔案名稱與儲存格式傳遞給 [**Save**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 方法（屬於 [**Presentation**](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別）。以下 Python 程式碼範例使用預設選項將簡報從 PPT 轉換為 PPTX。

```python
import aspose.slides as slides

# 實例化一個表示 PPT 檔案的 Presentation 物件
pres = slides.Presentation("PPTtoPPTX.ppt")

# 以 PPTX 格式儲存簡報
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

了解更多有關 [**PPT vs PPTX**](/slides/zh-hant/python-net/ppt-vs-pptx/) 簡報格式，以及 [**Aspose.Slides 支援 PPT 轉換為 PPTX**](/slides/zh-hant/python-net/convert-ppt-to-pptx/) 的資訊。

## **常見問題**

**PPT 與 PPTX 格式有何差異？**

PPT 是 Microsoft PowerPoint 使用的較舊二進位檔案格式，而 PPTX 是自 Microsoft Office 2007 起推出的較新 XML 為基礎的格式。PPTX 檔案提供更佳的效能、更小的檔案大小，且具更好的資料復原能力。

**我可以使用 Python 轉換 PPT 為 PPTX 嗎？**

是的，使用 Aspose.Slides for Python via .NET 函式庫，您只需幾行程式碼即可輕鬆載入 PPT 檔案並以 PPTX 格式儲存。

**Aspose.Slides 是否支援將多個 PPT 檔案批次轉換為 PPTX？**

是的，您可以在迴圈中使用 Aspose.Slides 以程式方式將多個 PPT 檔案轉換為 PPTX，適用於批次轉換情境。

**轉換後的內容與格式會被保留嗎？**

Aspose.Slides 在簡報轉換過程中保持高度保真度。投影片版面、動畫、圖形、圖表及其他設計元素在 PPT 轉換為 PPTX 時皆會被保留。

**我可以將 PPT 檔案轉換為 PDF 或 HTML 等其他格式嗎？**

是的，Aspose.Slides 支援將 PPT 檔案轉換為多種格式，包括 PDF、XPS、HTML、ODP，以及 PNG、JPEG 等影像格式。

**是否可以在未安裝 Microsoft PowerPoint 的情況下將 PPT 轉換為 PPTX？**

是的，Aspose.Slides for Python via .NET 為獨立的 API，執行轉換時不需 Microsoft PowerPoint 或任何第三方軟體。

**是否有線上工具可用於 PPT 轉換為 PPTX？**

是的，您可以使用免費的 [Aspose.Slides PPT 轉換為 PPTX 轉換器](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-pptx) 網頁應用程式，直接在瀏覽器中執行轉換，無需撰寫任何程式碼。