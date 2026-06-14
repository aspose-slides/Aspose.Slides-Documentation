---
title: 在 .NET 中將簡報投影片渲染為 SVG 圖片
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/net/render-a-slide-as-an-svg-image/
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
- 渲染投影片
- 轉換投影片
- 匯出投影片
- 向量圖像
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 將 PowerPoint 投影片渲染為 SVG 圖片。提供簡潔的 C# 程式碼範例，實現高品質的視覺效果。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將簡報投影片匯出為 SVG 圖片。內容介紹 SVG 格式及其優點，包括可伸縮性、可存取性以及在 Web 開發中的適用性。

您將學會如何載入簡報檔案、逐一遍歷投影片，並將每張投影片儲存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 以及 PPS，並示範如何使用 `Presentation` 類別和 `WriteAsSvg` 方法以程式方式執行轉換。

## **SVG 格式**
SVG（Scalable Vector Graphics 可伸縮向量圖形）是一種用於呈現二維影像的標準圖形類型或格式。SVG 以 XML 儲存圖像向量，並包含定義其行為或外觀的細節。

SVG 是少數在以下方面符合極高標準的圖像格式：可伸縮性、互動性、效能、可存取性、可程式化等。因此它在 Web 開發中被廣泛使用。

您可能會在以下情境中使用 SVG 檔案：

- **將簡報列印成*非常大的尺寸***。SVG 圖片可以無限制放大至任意解析度或尺寸，您可以多次調整大小而不會影響品質。
- **在*不同媒介或平台*中使用投影片中的圖表與圖形**。大多數瀏覽器皆能正確呈現 SVG 檔案。
- **取得*最小的圖像檔案大小***。SVG 檔案通常比其他高解析度格式（尤其是基於點陣圖的 JPEG 或 PNG）更小。

## **將投影片渲染為 SVG 圖片**

Aspose.Slides for .NET 允許您將簡報中的投影片匯出為 SVG 圖片。請依照以下步驟產生 SVG 圖片：

_步驟：PowerPoint 轉 SVG 的 C# 程式碼_

以下範例說明如何在 .NET 中執行這些轉換。
- <a name="csharp-powerpoint-to-svg" id="csharp-powerpoint-to-svg"><strong>步驟：在 C# 中將 PowerPoint 轉為 SVG</strong></a>
- <a name="csharp-ppt-to-svg" id="csharp-ppt-to-svg"><strong>步驟：在 C# 中將 PPT 轉為 SVG</strong></a>
- <a name="csharp-pptx-to-svg" id="csharp-pptx-to-svg"><strong>步驟：在 C# 中將 PPTX 轉為 SVG</strong></a>
- <a name="csharp-odp-to-svg" id="csharp-odp-to-svg"><strong>步驟：在 C# 中將 ODP 轉為 SVG</strong></a>

_程式碼步驟：_

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例。
   * _.ppt_ 副檔名用於於 _Presentation_ 類別中載入 **PPT** 檔案。
   * _.pptx_ 副檔名用於於 _Presentation_ 類別中載入 **PPTX** 檔案。
   * _.odp_ 副檔名用於於 _Presentation_ 類別中載入 **ODP** 檔案。
   * _.pps_ 副檔名用於於 _Presentation_ 類別中載入 **PPS** 檔案。
2. 逐一遍歷簡報中的所有投影片。
3. 透過 FileStream 將每張投影片寫入其對應的 SVG 檔案。

{{% alert color="primary" %}} 
您可以試試我們的[免費 Web 應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，其中已實作 Aspose.Slides for .NET 的 PPT 轉 SVG 功能。
{{% /alert %}} 

以下 C# 範例程式碼示範如何使用 Aspose.Slides 將 PowerPoint 轉換為 SVG：

``` csharp
// Presentation 物件可以載入 PPT、PPTX、ODP 等 PowerPoint 格式。
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

## **常見問題**

**為何在不同瀏覽器中顯示的 SVG 可能有所差異？**

各瀏覽器引擎對特定 SVG 功能的支援實作方式不同。使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/svgoptions/) 參數可協助平滑處理相容性問題。

**是否能將不只投影片而是單獨的圖形也匯出為 SVG？**

可以。任何[圖形皆可另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/)，這對圖示、圖解以及重複使用圖形非常方便。

**是否能將多張投影片合併為單一 SVG（條狀圖/文件）？**

標準作法是一張投影片對應一個 SVG。若需將多張投影片合併為同一個 SVG 畫布，必須在應用層面進行後處理。

## **相關內容** 

本文亦涵蓋以下主題，程式碼與上述相同。

_Format_: **PowerPoint**
- [C# PowerPoint to SVG Code](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG API](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Programmatically](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Library](#csharp-powerpoint-to-svg)
- [C# Save PowerPoint as SVG](#csharp-powerpoint-to-svg)
- [C# Generate SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# Create SVG from PowerPoint](#csharp-powerpoint-to-svg)
- [C# PowerPoint to SVG Converter](#csharp-powerpoint-to-svg)

_Format_: **PPT**
- [C# PPT to SVG Code](#csharp-ppt-to-svg)
- [C# PPT to SVG API](#csharp-ppt-to-svg)
- [C# PPT to SVG Programmatically](#csharp-ppt-to-svg)
- [C# PPT to SVG Library](#csharp-ppt-to-svg)
- [C# Save PPT as SVG](#csharp-ppt-to-svg)
- [C# Generate SVG from PPT](#csharp-ppt-to-svg)
- [C# Create SVG from PPT](#csharp-ppt-to-svg)
- [C# PPT to SVG Converter](#csharp-ppt-to-svg)

_Format_: **PPTX**
- [C# PPTX to SVG Code](#csharp-pptx-to-svg)
- [C# PPTX to SVG API](#csharp-pptx-to-svg)
- [C# PPTX to SVG Programmatically](#csharp-pptx-to-svg)
- [C# PPTX to SVG Library](#csharp-pptx-to-svg)
- [C# Save PPTX as SVG](#csharp-pptx-to-svg)
- [C# Generate SVG from PPTX](#csharp-pptx-to-svg)
- [C# Create SVG from PPTX](#csharp-pptx-to-svg)
- [C# PPTX to SVG Converter](#csharp-pptx-to-svg)

_Format_: **ODP**
- [C# ODP to SVG Code](#csharp-odp-to-svg)
- [C# ODP to SVG API](#csharp-odp-to-svg)
- [C# ODP to SVG Programmatically](#csharp-odp-to-svg)
- [C# ODP to SVG Library](#csharp-odp-to-svg)
- [C# Save ODP as SVG](#csharp-odp-to-svg)
- [C# Generate SVG from ODP](#csharp-odp-to-svg)
- [C# Create SVG from ODP](#csharp-odp-to-svg)
- [C# ODP to SVG Converter](#csharp-odp-to-svg)