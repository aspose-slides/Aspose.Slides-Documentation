---
title: 在 Android 上的簡報中自訂圖表圖例
linktitle: 圖例
type: docs
url: /zh-hant/androidjava/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 針對 PowerPoint 簡報自訂圖表圖例，以最佳化並套用客製化的圖例格式。"
---
## **概觀**

Aspose.Slides 提供了在 PowerPoint 簡報中自訂圖表圖例的選項。本文章說明如何設定圖例的位置與大小、為整個圖例設定字型大小，以及對單一圖例項目套用格式。

此外，還在 FAQ 中涵蓋了多項相關行為，包括使用非覆寫模式讓繪圖區域為圖例騰出空間、允許長圖例標籤自動換行或使用換行符號，以及在未設定明確文字與填色時，讓圖例格式從簡報主題繼承。

## **圖例位置設定**
若要設定圖例屬性，請遵循以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 取得投影片的參考。
- 在投影片上新增圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

以下範例示範了如何設定圖表圖例的位置與大小。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 取得投影片的參考
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 在投影片上新增叢集柱狀圖
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

## **設定圖例的字型大小**
Aspose.Slides for Android via Java 允許開發人員設定圖例的字型大小。請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 設定字型大小。
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

## **設定單一圖例項目的字型大小**
Aspose.Slides for Android via Java 允許開發人員設定單一圖例項目的字型大小。請遵循以下步驟：

- 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別。
- 建立預設圖表。
- 存取圖例項目。
- 設定字型大小。
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

**我可以啟用圖例，使圖表自動為其分配空間而非覆寫嗎？**

是。使用非覆寫模式（[setOverlay(false)](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)）；此時，繪圖區域會縮小以容納圖例。

**我可以讓圖例標籤換行嗎？**

是。當空間不足時，長標籤會自動換行；亦支援在系列名稱中使用換行字元來強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

不要為圖例或其文字設定明確的顏色、填色或字型。如此一來，它們會從主題繼承，且在設計變更時會正確更新。