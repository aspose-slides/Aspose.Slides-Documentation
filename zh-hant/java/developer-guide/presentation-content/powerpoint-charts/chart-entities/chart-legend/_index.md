---
title: 使用 Java 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/java/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字體大小
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 自訂圖表圖例，以符合需求的圖例格式優化 PowerPoint 簡報。"
---
## **概覽**

Aspose.Slides 提供了在 PowerPoint 簡報中自訂圖表圖例的選項。本文說明如何設定圖例的位置與大小、為整個圖例設定字體大小，以及對單一圖例項目套用格式。

同時在 FAQ 中也討論了相關行為，包括使用非覆蓋模式以讓繪圖區為圖例留出空間、允許長圖例標籤自動換行或使用換行符號，以及在未設定明確文字與填充時讓圖例格式從簡報主題繼承。

## **圖例定位**
若要設定圖例屬性，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 在投影片上新增圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

以下範例示範了如何為圖表圖例設定位置與大小。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在投影片上新增群集柱狀圖
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // 設定圖例屬性
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // 將簡報寫入磁碟
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定圖例的字體大小**
Aspose.Slides for Java 讓開發人員能設定圖例的字體大小。請依照以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 設定字體大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **設定單一圖例項目的字體大小**
Aspose.Slides for Java 讓開發人員能設定單一圖例項目的字體大小。請依照以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 取得圖例項目。
- 設定字體大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以啟用圖例，使圖表自動為圖例分配空間而不是覆蓋它嗎？**

可以。使用非覆蓋模式（[setOverlay(false)](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/legend/#setOverlay-boolean-)）；此時繪圖區會縮小以容納圖例。

**我可以製作多行圖例標籤嗎？**

可以。當空間不足時，長標籤會自動換行；亦支援在系列名稱中加入換行字元以強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

不要為圖例或其文字設定明確的顏色、填充或字體。如此一來，它們會從主題繼承，且在設計變更時會正確更新。