---
title: 在 Android 上的簡報圖表中自訂誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/androidjava/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在圖表中新增與自訂誤差棒，優化 PowerPoint 簡報中的資料視覺效果。"
---
## **概觀**

本文說明如何在簡報圖表中使用 Aspose.Slides 來處理誤差棒。它展示了如何將誤差棒加入圖表系列、設定 X 與 Y 誤差棒的屬性，並套用不同的值類型，如固定值、百分比和自訂值。

此外，還示範了如何透過相應的資料點集合，為系列中的單一資料點指定自訂誤差棒值。文章亦簡要說明了誤差棒在匯出時的行為、它與標記和資料標籤的相容性，以及在何處可以找到相關的 API 參考類別與列舉。

## **新增誤差棒**
Aspose.Slides for Android via Java 提供了簡單的 API 來管理誤差棒值。樣本程式碼適用於使用自訂值類型的情況。若要指定值，請使用系列中 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesCollection) 集合內特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 在指定的投影片上新增氣泡圖。
3. 取得第一個圖表系列，並設定誤差棒 X 格式。
4. 取得第一個圖表系列，並設定誤差棒 Y 格式。
5. 設定棒的值與格式。
6. 將修改後的簡報寫入 PPTX 檔案。

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

## **新增自訂誤差棒值**
Aspose.Slides for Android via Java 提供了簡單的 API 來管理自訂誤差棒值。樣本程式碼適用於當 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) 屬性等於 **Custom** 時。若要指定值，請使用系列中 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IChartSeriesCollection) 集合內特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
2. 在指定的投影片上新增氣泡圖。
3. 取得第一個圖表系列，並設定誤差棒 X 格式。
4. 取得第一個圖表系列，並設定誤差棒 Y 格式。
5. 存取圖表系列的個別資料點，並為每個資料點設定誤差棒值。
6. 設定棒的值與格式。
7. 將修改後的簡報寫入 PPTX 檔案。

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

    // 取得圖表系列資料點並設定誤差棒值給
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

**將簡報匯出為 PDF 或圖片時，誤差棒會發生什麼情況？**

它們會作為圖表的一部分被渲染，並在轉換過程中與其他圖表格式一起保留，前提是使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，且與標記和資料標籤相容；若元素重疊，可能需要調整格式。

**在哪裡可以找到 API 中用於處理誤差棒的屬性與類別清單？**

請參考 API 參考文件：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/errorbarsformat/) 類別，以及相關的 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/errorbarvaluetype/) 類別。