---
title: 使用 JavaScript 自訂簡報圖表中的誤差棒
linktitle: 誤差棒
type: docs
url: /zh-hant/nodejs-java/error-bar/
keywords:
- 誤差棒
- 自訂值
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 JavaScript 以及 Aspose.Slides for Node.js via Java 在圖表中加入並自訂誤差棒——優化 PowerPoint 簡報中的資料視覺效果。"
---
## **概觀**

本文章說明如何使用 Aspose.Slides 在簡報圖表中處理誤差棒。它展示了如何向圖表系列添加誤差棒、設定 X 與 Y 誤差棒的屬性，並套用不同的數值類型，例如固定值、百分比和自訂值。

它也示範如何使用相應的資料點集合，為系列中的個別資料點指派自訂誤差棒值。此外，文章還簡要說明誤差棒在匯出時的行為、與標記與資料標籤的相容性，以及在 API 參考中找尋相關類別與列舉的位置。

## **新增誤差棒**

Aspose.Slides for Node.js via Java 提供簡單的 API 來管理誤差棒數值。當使用自訂數值類型時適用此範例程式碼。若要指定數值，請使用系列之 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesCollection) 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 在所需投影片上加入氣泡圖。
1. 存取第一個圖表系列並設定誤差棒 X 格式。
1. 存取第一個圖表系列並設定誤差棒 Y 格式。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 建立氣泡圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // 加入誤差棒並設定其格式
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // 儲存簡報
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **新增自訂誤差棒值**

Aspose.Slides for Node.js via Java 提供簡單的 API 來管理自訂誤差棒數值。當 [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) 屬性等於 **Custom** 時適用此範例程式碼。若要指定數值，請使用系列之 [**DataPoints**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ChartSeriesCollection) 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 在所需投影片上加入氣泡圖。
1. 存取第一個圖表系列並設定誤差棒 X 格式。
1. 存取第一個圖表系列並設定誤差棒 Y 格式。
1. 存取圖表系列的個別資料點，為個別系列資料點設定誤差棒值。
1. 設定棒的數值與格式。
1. 將修改後的簡報寫入 PPTX 檔案。

```javascript
// 建立 Presentation 類別的實例
var pres = new aspose.slides.Presentation();
try {
    // 建立氣泡圖表
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // 加入自訂誤差棒並設定其格式
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // 存取圖表系列資料點並設定誤差棒值給
    // 個別資料點
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // 設定圖表系列資料點的誤差棒
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // 儲存簡報
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**匯出簡報為 PDF 或圖片時，誤差棒會發生什麼情況？**

它們作為圖表的一部分呈現，並在轉換過程中與其他圖表格式一起保留，只要使用相容的版本或渲染器。

**誤差棒可以與標記和資料標籤結合使用嗎？**

可以。誤差棒是獨立的元素，與標記和資料標籤相容；如果元素重疊，可能需要調整格式。

**我可以在哪裡找到用於處理誤差棒的屬性與列舉清單？**

在 API 參考中： [ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/errorbarsformat/) 類別以及相關列舉 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/errorbarvaluetype/)。