---
title: 在 C++ 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/cpp/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint 轉 SVG
- 簡報 轉 SVG
- 投影片 轉 SVG
- PPT 轉 SVG
- PPTX 轉 SVG
- 將 PPT 儲存為 SVG
- 將 PPTX 儲存為 SVG
- 匯出 PPT 為 SVG
- 匯出 PPTX 為 SVG
- 呈現 投影片
- 轉換 投影片
- 匯出 投影片
- 向量圖像
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for C++ 將 PowerPoint 投影片渲染為 SVG 圖像。提供簡單程式碼範例，實現高品質視覺效果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將簡報投影片渲染為 SVG 圖像。它描述了 SVG 格式及其優點，包括可伸縮性、可存取性以及適合 Web 開發的特性。

您將學習如何載入簡報檔案、遍歷其投影片，並將每張投影片另存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 與 PPS，並示範如何使用 `Presentation` 類別和 `WriteAsSvg` 方法以程式方式執行轉換。

## **SVG 格式**

SVG（Scalable Vector Graphics 可伸縮向量圖形的縮寫）是一種用於呈現二維圖像的標準圖形類型或格式。SVG 以 XML 向量形式儲存圖像，並包含定義其行為或外觀的細節。

SVG 是少數在以下方面符合極高標準的圖像格式之一：可伸縮性、互動性、效能、可存取性、可程式化等。基於這些原因，它在 Web 開發中被廣泛使用。

您可能想使用 SVG 檔案於以下情況：

- **以*非常大尺寸*列印您的簡報。** SVG 圖像可擴展至任意解析度或尺寸。您可以多次調整 SVG 圖像大小而不會降低品質。
- **使用投影片中的圖表與圖形於*不同媒介或平台*。** 大多數閱讀器都能解讀 SVG 檔案。
- **使用*盡可能最小的圖像尺寸*。** SVG 檔案通常比其他格式的高解析度等效檔案更小，尤其是基於點陣圖的格式（JPEG 或 PNG）。

## **將投影片渲染為 SVG 圖像**

Aspose.Slides for C++ 允許您將簡報中的投影片匯出為 SVG 圖像。請依照以下步驟產生 SVG 圖像：

1. 建立 Presentation 類別的實例。
2. 遍歷簡報中的所有投影片。
3. 透過 FileStream 將每張投影片寫入其各自的 SVG 檔案。

{{% alert color="primary" %}} 
您可能想試用我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，其中實作了來自 Aspose.Slides for C++ 的 PPT 轉 SVG 轉換功能。 
{{% /alert %}} 

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
        
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto fileName = String::Format(u"slide-{0}.svg", index);
    auto fileStream = System::MakeObject<FileStream>(fileName, FileMode::Create, FileAccess::Write);

    auto slide = pres->get_Slides()->idx_get(index);
    slide->WriteAsSvg(fileStream);
}
```

## **常見問題**

**為何產生的 SVG 可能在不同瀏覽器中顯示不同？**

各瀏覽器引擎對特定 SVG 功能的支援實作方式不同。[SVGOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/svgoptions/) 參數可協助平衡相容性問題。

**是否能將不僅是投影片，還有單獨的圖形匯出為 SVG？**

可以。任何[圖形都可以另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/)，這對圖示、圖示圖形以及重複使用圖形非常方便。

**是否可以將多張投影片合併成單一 SVG（條帶/文件）？**

標準做法為一張投影片對應一個 SVG。將多張投影片合併成單一 SVG 畫布是需要在應用層面進行的後處理步驟。