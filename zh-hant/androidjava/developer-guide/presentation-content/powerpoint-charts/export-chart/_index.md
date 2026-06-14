---
title: 在 Android 上匯出簡報圖表
linktitle: 匯出圖表
type: docs
weight: 90
url: /zh-hant/androidjava/export-chart/
keywords:
- 圖表
- 圖表轉影像
- 圖表作為影像
- 擷取圖表影像
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 匯出簡報圖表，支援 PPT 與 PPTX 格式，並將報告流程化整合至任何工作流程。"
---
## **概觀**

Aspose.Slides 允許您將簡報中的圖表匯出為影像。本文說明如何從圖表取得影像並儲存，這在您需要在 PowerPoint 簡報之外重複使用圖表視覺時非常有用。

除了基本的影像匯出工作流程外，本文還針對常見的匯出相關問題提供說明，包括將圖表內容儲存為 SVG、透過渲染選項控制輸出大小、載入字型以保留標籤與圖例的外觀，以及在渲染過程中保持原始簡報的格式，例如佈景主題、樣式、填色和效果。

## **取得圖表影像**
Aspose.Slides for Android via Java 提供了擷取特定圖表影像的支援。以下提供範例程式。

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

**我可以將圖表匯出為向量（SVG）而非點陣圖嗎？**  
是的。圖表是一個形狀，其內容可以使用 [shape-to-SVG saving method](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 儲存為 SVG。

**我該如何以像素為單位設定匯出圖表的精確大小？**  
使用可指定大小或比例的影像渲染覆載方法——此函式庫支援以給定的尺寸/比例來渲染物件。

**如果匯出後標籤與圖例的字型顯示不正確，我該怎麼辦？**  
[載入所需字型](/slides/zh-hant/androidjava/custom-font/) 透過 [FontsLoader](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/)，以確保圖表渲染保留度量與文字外觀。

**匯出是否會遵守 PowerPoint 的佈景主題、樣式與效果？**  
是的。Aspose.Slides 的渲染器會遵循簡報的格式（佈景主題、樣式、填色、效果），因此圖表的外觀會被保留。

**我可以在哪裡找到圖表影像以外的可用渲染/匯出功能？**  
請參閱 [API](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/)/[文件](/slides/zh-hant/androidjava/convert-powerpoint/) 以了解輸出目標（[PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)、[SVG](/slides/zh-hant/androidjava/render-a-slide-as-an-svg-image/)、[XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)、[HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)、等）以及相關的渲染選項。