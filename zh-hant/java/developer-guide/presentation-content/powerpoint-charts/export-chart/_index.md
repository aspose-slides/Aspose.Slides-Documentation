---
title: 在 Java 中匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/java/export-chart/
keywords:
- 圖表
- 圖表轉圖片
- 圖表作為圖片
- 擷取圖表圖片
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程簡化至任何工作流程。"
---
## **概觀**

Aspose.Slides 允許您將簡報中的圖表匯出為圖片。本文說明如何從圖表取得圖片並儲存，當您需要在 PowerPoint 簡報之外重複使用圖表視覺時，此功能相當有用。

除了基本的圖片匯出工作流程外，本文亦說明常見的匯出相關問題，包括將圖表內容儲存為 SVG、透過渲染選項控制輸出大小、載入字型以保留標籤與圖例外觀，以及在渲染過程中保留原始簡報的格式（例如佈景主題、樣式、填色與效果）。

## **取得圖表圖片**
Aspose.Slides for Java 提供擷取特定圖表圖片的支援。以下提供範例程式碼。

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以將圖表匯出為向量 (SVG) 而非點陣圖嗎？**

是的。圖表是一個圖形，其內容可以使用[shape-to-SVG 保存方法](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)匯出為 SVG。

**如何以像素設定匯出圖表的精確大小？**

使用可指定大小或比例的影像渲染覆寫方法——函式庫支援以給定的尺寸/比例渲染物件。

**匯出後標籤與圖例的字型顯示不正確，我該怎麼辦？**

請透過[載入所需字型](/slides/zh-hant/java/custom-font/)，並使用[FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/)來確保圖表渲染保留字型度量與文字外觀。

**匯出是否會遵守 PowerPoint 的佈景主題、樣式與效果？**

會。Aspose.Slides 的渲染器會遵循簡報的格式（佈景主題、樣式、填色、效果），因此圖表的外觀會被保留。

**我可以在哪裡找到圖表圖片之外的渲染/匯出功能？**

請參考[API](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/)/[文件](/slides/zh-hant/java/convert-powerpoint/)以了解輸出目標（[PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/java/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/java/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/java/convert-powerpoint-to-html/)，等等）以及相關的渲染選項。