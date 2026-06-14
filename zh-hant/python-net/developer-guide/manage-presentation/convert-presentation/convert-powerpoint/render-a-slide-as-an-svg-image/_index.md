---
title: 在 Python 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/python-net/render-a-slide-as-an-svg-image/
keywords:
- 投影片轉 SVG
- 簡報轉 SVG
- PowerPoint 轉 SVG
- OpenDocument 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- ODP 轉 SVG
- 渲染投影片
- 轉換投影片
- 匯出投影片
- 向量圖像
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 將 PowerPoint 與 OpenDocument 投影片渲染為 SVG 圖像。提供高品質視覺效果與簡單程式碼範例。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將簡報投影片呈現為 SVG 圖像。它描述了 SVG 格式及其優勢，包括可伸縮性、可存取性以及適合 Web 開發的特性。

您將學習如何載入簡報檔案、遍歷其投影片，並將每張投影片另存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 與 PPS，並示範如何使用 `Presentation` 類別與 `write_as_svg` 方法以程式方式執行轉換。

## **SVG 格式**

SVG（Scalable Vector Graphics 的縮寫）是一種用於渲染二維圖像的標準圖形類型或格式。SVG 以 XML 形式儲存向量圖像，並包含定義其行為或外觀的詳細資訊。

SVG 是少數在可伸縮性、互動性、效能、可存取性、可程式化等方面符合極高標準的圖像格式之一。因此，它常被用於 Web 開發。

您可能想在以下情況下使用 SVG 檔案：

- **將簡報列印成 *非常大型* 的格式。** SVG 圖像可以縮放至任意解析度或層級。您可以多次調整 SVG 圖像大小而不會降低品質。  
- **使用投影片中的圖表與圖形於 *不同的媒介或平台***。** 大多數閱讀器都能解析 SVG 檔案。  
- **使用 *最小可能的圖像尺寸***。 SVG 檔案通常比其他格式的高解析度等價檔案更小，特別是基於點陣圖的格式（JPEG 或 PNG）。

## **將投影片渲染為 SVG 圖像**

Aspose.Slides for Python via .NET 允許您將簡報中的投影片匯出為 SVG 圖像。請依照以下步驟產生 SVG 圖像：

1. 建立 Presentation 類別的實例。  
2. 遍歷簡報中的所有投影片。  
3. 透過 FileStream 將每張投影片寫入其各自的 SVG 檔案。

{{% alert color="primary" %}} 
您也許想試用我們的[免費網頁應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，我們在其中實作了 Aspose.Slides for Python via .NET 的 PPT 轉 SVG 轉換功能。
{{% /alert %}} 

```py
import aspose.slides as slides

# 建立表示簡報檔案的 Presentation 物件
pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]

    with open("slide-{index}.svg".format(index = index), "wb") as file:
        slide.write_as_svg(file)
```

## **常見問題**

**為何產生的 SVG 在不同瀏覽器上可能顯示不同？**

支援特定 SVG 功能的方式在各瀏覽器引擎中實作不同。[SVGOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/) 參數有助於平衡這些不相容性。

**是否可以將不僅是投影片，還有個別圖形匯出為 SVG？**

是的。任何[圖形皆可另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/shape/write_as_svg/)，這對於圖示、圖形符號以及重複使用圖形非常便利。

**是否可以將多張投影片合併為單一的 SVG（長條/文件）？**

標準情況是一張投影片對應一個 SVG。將多張投影片合併為單一 SVG 畫布是一個於應用層級執行的後處理步驟。