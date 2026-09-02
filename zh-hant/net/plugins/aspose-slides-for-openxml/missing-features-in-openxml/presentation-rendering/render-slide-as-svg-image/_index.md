---
title: 将投影片渲染为 SVG 图像
type: docs
weight: 50
url: /zh-hant/net/render-slide-as-svg-image/
---
SVG — Scalable Vector Graphics（可擴展向量圖形）的縮寫，是用於呈現二維圖像的標準圖形類型或格式。SVG 以 XML 中的向量方式儲存圖像，並包含定義其行為或外觀的細節。

SVG 是少數在以下方面符合極高標準的圖像格式：可伸縮性、互動性、效能、可及性、可程式化等。因此，它常被用於網路開發。

您可能會在以下情境下使用 SVG 檔案：

- 當您計畫將簡報以非常大的尺寸列印。SVG 圖像可無限制放大至任意解析度或等級，您可以多次調整 SVG 圖像大小而不會損失品質。
- 當您想將投影片中的圖表與圖形於不同媒介或平台使用。大多數閱讀器皆能解讀 SVG 檔案。
- 當您需要使用盡可能最小的圖像檔案大小。與其他格式的高解析度等效檔案相比，SVG 檔案通常較小，特別是相較於基於點陣圖的格式（JPEG 或 PNG）。

Aspose.Slides for .NET 允許您將簡報中的投影片匯出為 **SVG** 圖像。若要從任意投影片產生 SVG 圖像，請執行以下步驟：

- 建立 Presentation 類別的實例。
- 逐一遍歷簡報中的所有投影片。
- 透過 FileStream 將每張投影片寫入其各自的 SVG 檔案。

{{% alert color="info" %}} 

您可以試用我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，其中實作了 Aspose.Slides for .NET 的 PPT 轉 SVG 功能。

{{% /alert %}} 

以下 C# 範例程式碼示範如何使用 Aspose.Slides 將 PPT 轉換為 SVG：

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```