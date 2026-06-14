---
title: 使用 Java 在簡報圖表中自訂誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/java/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在圖表中新增與自訂誤差棒—優化 PowerPoint 簡報中的資料視覺效果。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 在簡報圖表中處理誤差棒。它展示了如何將誤差棒加入圖表系列、設定 X 與 Y 誤差棒的屬性，以及使用固定值、百分比和自訂值等不同的值類型。

它還示範了如何透過對應的資料點集合，為系列中的個別資料點指派自訂誤差棒值。此外，本文還簡要說明了誤差棒在匯出時的行為、它與資料標記和資料標籤的相容性，以及相關 API 參考類別與列舉的所在位置。

## **添加誤差棒**
Aspose.Slides for Java 提供簡易的 API 以管理誤差棒值。此範例程式碼適用於使用自訂值類型的情況。若要指定值，請在系列的 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesCollection) 集合中，使用特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
1. 在指定的投影片上加入氣泡圖表。
1. 存取第一個圖表系列，且設定誤差棒 X 格式。
1. 存取第一個圖表系列，且設定誤差棒 Y 格式。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 建立氣泡圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 新增誤差棒並設定其格式
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // 儲存簡報
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **添加自訂誤差棒值**
Aspose.Slides for Java 提供簡易的 API 以管理自訂誤差棒值。此範例程式碼適用於當 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IErrorBarsFormat#getValue--) 屬性等於 **Custom** 時。若要指定值，請在系列的 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IChartSeriesCollection) 集合中，使用特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
1. 在指定的投影片上加入氣泡圖表。
1. 存取第一個圖表系列，且設定誤差棒 X 格式。
1. 存取第一個圖表系列，且設定誤差棒 Y 格式。
1. 存取圖表系列的個別資料點，並為每個資料點設定誤差棒值。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```java
// 建立 Presentation 類別的實例
Presentation pres = new Presentation();
try {
    // 建立氣泡圖表
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 新增自訂誤差棒並設定其格式
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // 存取圖表系列資料點並設定誤差棒值給
    // 個別資料點
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // 為圖表系列資料點設定誤差棒
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // 儲存簡報
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**將簡報匯出為 PDF 或影像時，誤差棒會發生什麼情況？**

它們會作為圖表的一部分被呈現，並在轉換過程中與其他圖表格式一起保留，前提是使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，且與標記及資料標籤相容；若元素重疊，可能需要調整格式。

**在哪裡可以找到用於操作誤差棒的屬性與類別清單？**

於 API 參考文件中：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/errorbarsformat/) 類別，以及相關的 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/errorbartype/) 與 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/errorbarvaluetype/) 類別。