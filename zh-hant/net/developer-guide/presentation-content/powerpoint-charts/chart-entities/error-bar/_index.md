---
title: 在 .NET 中自訂簡報圖表的誤差條
linktitle: 誤差條
type: docs
url: /zh-hant/net/error-bar/
keywords:
- 誤差條
- 自訂值
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在圖表中新增與自訂誤差條——在 PowerPoint 簡報中優化資料視覺效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報圖表中處理誤差條。它示範了如何將誤差條新增至圖表系列、設定 X 與 Y 誤差條的屬性，並套用固定值、百分比與自訂值等不同類型。

此外，本文亦示範如何透過相應的資料點集合，為系列中的個別資料點指派自訂誤差條值。文章還簡要說明了誤差條在匯出時的行為、與標記與資料標籤的相容性，以及相關 API 參考類別與列舉的所在位置。

## **新增誤差條**
Aspose.Slides for .NET 提供簡易的 API 以管理誤差條值。以下範例適用於使用自訂值類型的情況。若要指定值，請使用系列 **DataPoints** 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立一個 [簡報](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 在目標投影片上新增氣泡圖表。
3. 取得第一個圖表系列並設定誤差條 X 格式。
4. 取得第一個圖表系列並設定誤差條 Y 格式。
5. 設定條件值與格式。
6. 將修改後的簡報寫入 PPTX 檔案。

```c#
// 建立空的簡報
using (Presentation presentation = new Presentation())
{
    // 建立氣泡圖表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 加入誤差條並設定其格式
    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Fixed;
    errBarX.Value = 0.1f;
    errBarY.ValueType = ErrorBarValueType.Percentage;
    errBarY.Value = 5;
    errBarX.Type = ErrorBarType.Plus;
    errBarY.Format.Line.Width = 2;
    errBarX.HasEndCap = true;

    // 儲存簡報
    presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **新增自訂誤差條值**
Aspose.Slides for .NET 提供簡易的 API 以管理自訂誤差條值。以下範例適用於 **IErrorBarsFormat.ValueType** 屬性等於 **Custom** 的情況。若要指定值，請使用系列 **DataPoints** 集合中特定資料點的 **ErrorBarCustomValues** 屬性：

1. 建立一個 [簡報](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
2. 在目標投影片上新增氣泡圖表。
3. 取得第一個圖表系列並設定誤差條 X 格式。
4. 取得第一個圖表系列並設定誤差條 Y 格式。
5. 取得圖表系列的個別資料點，為個別資料點設定誤差條值。
6. 設定條件值與格式。
7. 將修改後的簡報寫入 PPTX 檔案。

```c#
// 建立空的簡報
using (Presentation presentation = new Presentation())
{
    // 建立氣泡圖表
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 加入自訂誤差條並設定其格式
    IChartSeries series = chart.ChartData.Series[0];
    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
    errBarX.IsVisible = true;
    errBarY.IsVisible = true;
    errBarX.ValueType = ErrorBarValueType.Custom;
    errBarY.ValueType = ErrorBarValueType.Custom;

    // 存取圖表系列資料點並為個別點設定誤差條值
    IChartDataPointCollection points = series.DataPoints;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    // 為圖表系列點設定誤差條
    for (int i = 0; i < points.Count; i++)
    {
        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
    }

    // 儲存簡報
    presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**將簡報匯出為 PDF 或圖像時，誤差條會發生什麼情況？**

誤差條會作為圖表的一部分被渲染，且在轉換過程中會與其他圖表格式一起保留，前提是使用相容的版本或渲染器。

**誤差條可以與標記和資料標籤同時使用嗎？**

可以。誤差條是獨立的元素，與標記和資料標籤相容；若元素重疊，可能需要調整格式。

**在哪裡可以找到用於操作誤差條的屬性與列舉清單？**

請參考 API 文件：[ErrorBarsFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/errorbarsformat/) 類別，以及相關列舉 [ErrorBarType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/errorbartype/) 和 [ErrorBarValueType](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/errorbarvaluetype/)。