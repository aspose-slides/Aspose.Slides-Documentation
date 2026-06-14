---
title: 在 Java 中將簡報投影片渲染為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/java/render-a-slide-as-an-svg-image/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 將 PowerPoint 投影片渲染為 SVG 圖像。提供簡單程式碼範例的高品質視覺效果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將簡報投影片渲染為 SVG 圖像。它描述了 SVG 格式及其優點，包括可擴展性、可存取性以及對 Web 開發的適用性。

您將學習如何載入簡報檔案、遍歷其投影片，並將每張投影片另存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 和 PPS，並說明如何使用 `Presentation` 類別和 `writeAsSvg` 方法以程式方式執行轉換。

## **SVG 格式**

SVG（Scalable Vector Graphics 的縮寫）是一種用於呈現二維圖像的標準圖形類型或格式。SVG 以 XML 中的向量方式儲存圖像，並包含定義其行為或外觀的細節。

SVG 是少數能在以下方面達到極高標準的圖像格式：可擴展性、互動性、效能、可存取性、可程式化等。因此，它在 Web 開發中被廣泛使用。

當您需要以下情況時，可能會想使用 SVG 檔案：

- **以*非常大的規格*列印簡報。** SVG 圖像可以擴展至任意解析度或尺寸。您可以多次調整 SVG 圖像的大小而不會犧牲品質。
- **在*不同媒介或平台*上使用投影片中的圖表與圖形**。大多數閱讀器都能解析 SVG 檔案。
- **使用*盡可能最小的圖像尺寸***。SVG 檔案通常比其他格式的高解析度等效檔案更小，特別是基於點陣圖的格式（如 JPEG 或 PNG）。

## **將投影片渲染為 SVG 圖像**

Aspose.Slides for Java 允許您將簡報中的投影片匯出為 SVG 圖像。請依照以下步驟產生 SVG 圖像：

1. 建立 `Presentation` 類別的實例。
2. 遍歷簡報中的所有投影片。
3. 透過 `FileOutputStream` 將每張投影片寫入其自己的 SVG 檔案。

{{% alert color="primary" %}} 

您可能想試用我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，我們在其中實作了 Aspose.Slides for Java 的 PPT 轉 SVG 功能。

{{% /alert %}} 

以下 Java 範例程式碼示範了如何使用 Aspose.Slides 將 PPT 轉換為 SVG：

``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**為什麼產生的 SVG 在不同瀏覽器上可能會呈現不同？**

各瀏覽器引擎對特定 SVG 功能的支援實作方式不同。使用 [SVGOptions](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/svgoptions/) 參數可以緩解相容性問題。

**是否可以將不僅是投影片，還有單獨的形狀匯出為 SVG？**

可以。任何[形狀皆可另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，這對於圖示、圖解以及重複使用圖形非常方便。

**是否可以將多張投影片合併為單一 SVG（條帶/文件）？**

標準情況是一張投影片 → 一個 SVG。將多張投影片合併為單一 SVG 畫布屬於應用層級的後處理步驟。