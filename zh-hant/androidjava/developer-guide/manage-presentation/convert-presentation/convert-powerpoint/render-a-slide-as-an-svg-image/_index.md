---
title: 以 Android 渲染簡報投影片為 SVG 圖像
linktitle: 投影片轉 SVG
type: docs
weight: 50
url: /zh-hant/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 將 PowerPoint 投影片渲染為 SVG 圖像。使用簡單的 Java 程式碼示例即可獲得高品質視覺效果。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 將簡報投影片渲染為 SVG 圖像。它描述了 SVG 格式及其優點，包括可伸縮性、可存取性以及對 Web 開發的適用性。

您將學習如何載入簡報檔案、遍歷其投影片，並將每張投影片另存為單獨的 SVG 檔案。本文涵蓋 PowerPoint 與 OpenDocument 簡報格式，包括 PPT、PPTX、ODP 與 PPS，並示範如何使用 `Presentation` 類別與 `writeAsSvg` 方法以程式方式執行轉換。

## **SVG 格式**

SVG（Scalable Vector Graphics 的縮寫）是一種用於渲染二維圖像的標準圖形類型或格式。  
SVG 將圖像以向量形式儲存在 XML 中，並包含定義其行為或外觀的細節。

SVG 是少數在以下方面符合極高標準的圖像格式：可伸縮性、互動性、效能、可存取性、可程式化等。因此，它在 Web 開發中被廣泛使用。

您可能會在需要以下情況時使用 SVG 檔案：

- **以 *非常大型* 的格式列印簡報。** SVG 圖像可伸縮至任意解析度或尺寸。您可以多次調整 SVG 圖像大小而不會影響品質。
- **在 *不同媒介或平台* 中使用投影片中的圖表與圖形**。大多數閱讀器都能解析 SVG 檔案。
- **使用 *最小尺寸* 的圖像**。SVG 檔案通常比其他格式的高解析度等效檔案更小，尤其是基於點陣圖的格式（JPEG 或 PNG）。

## **將投影片渲染為 SVG 圖像**

Aspose.Slides for Android via Java 允許您將簡報中的投影片匯出為 SVG 圖像。請依照以下步驟產生 SVG 圖像：

1. 建立 `Presentation` 類別的實例。  
2. 遍歷簡報中的所有投影片。  
3. 透過 `FileOutputStream` 將每張投影片寫入其各自的 SVG 檔案。

{{% alert color="primary" %}} 
您可以嘗試我們的[免費網路應用程式](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-svg)，我們在其中實作了來自 Aspose.Slides for Android via Java 的 PPT 轉 SVG 功能。
{{% /alert %}} 

以下為 Java 範例程式碼，說明如何使用 Aspose.Slides 將 PPT 轉換為 SVG：

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

**為什麼產生的 SVG 在不同瀏覽器上可能會顯示不同？**

不同瀏覽器引擎對特定 SVG 功能的支援實作方式不同。[SVGOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/svgoptions/) 參數可協助平衡相容性問題。

**是否能夠將不僅是投影片，也包括單一圖形匯出為 SVG？**

是的。任何[圖形都可以另存為單獨的 SVG](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)，這對圖示、圖解以及重複使用圖形非常方便。

**能否將多張投影片合併為單一 SVG（條狀圖/文件）？**

標準情況是一張投影片對應一個 SVG。將多張投影片合併為單一 SVG 畫布是於應用層面執行的後處理步驟。