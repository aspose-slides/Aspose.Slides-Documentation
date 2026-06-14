---
title: 在 .NET 中於簡報管理圖表資料系列
linktitle: 資料系列
type: docs
url: /zh-hant/net/chart-series/
keywords:
- 圖表系列
- 系列重疊
- 系列顏色
- 類別顏色
- 系列名稱
- 資料點
- 系列間隙
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習如何在 C# 中為 PowerPoint (PPT/PPTX) 管理圖表系列，透過實用的程式碼範例與最佳實踐，提升您的資料簡報效果。"
---
## **概述**

本文說明了 [ChartSeries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartseries/) 在 Aspose.Slides for .NET 中的角色，重點在於資料在簡報中的結構與視覺化方式。這些物件提供了定義圖表中單一資料點集合、類別和外觀參數的基礎元素。透過使用 [ChartSeries](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/chartseries/)，開發人員可以無縫整合底層資料來源，並完全掌控資訊的顯示方式，從而產生動態、資料驅動的簡報，清晰傳達洞見與分析。

系列是一列或一欄在圖表中繪製的數字。

![chart-series-powerpoint](chart-series-powerpoint.png)

## **設定圖表系列重疊**

[IChartSeriesOverlap](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/ichartseries/properties/overlap) 屬性透過指定 -100 到 100 的範圍，控制 2D 圖表中棒狀圖和柱狀圖的重疊方式。由於此屬性與系列群組相關，而非單一圖表系列，因此在系列層級上為唯讀。若要設定重疊值，請使用 `ParentSeriesGroup.Overlap` 可讀寫屬性，該屬性會將指定的重疊套用至該群組中的所有系列。

以下是一個 C# 範例，示範如何建立簡報、加入叢集柱狀圖、存取第一個圖表系列、設定重疊屬性，然後將結果儲存為 PPTX 檔案：

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的叢集柱狀圖。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // 設定系列重疊。
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // 將簡報檔案儲存至磁碟。
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

結果：

![系列重疊](series_overlap.png)

## **變更系列填滿顏色**

Aspose.Slides 讓自訂圖表系列的填滿顏色變得簡單，您可以突出特定資料點，並建立視覺上吸引人的圖表。這透過 [IFormat](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.charts/iformat/) 物件實現，該物件支援各種填充類型、顏色設定以及其他進階樣式選項。將圖表加入投影片並存取目標系列後，只需取得該系列並套用適當的填滿顏色。除了純色填滿，您還可以使用漸層或圖案填滿以提升設計彈性。設定完所需的顏色後，將簡報儲存即可完成更新的外觀。

以下 C# 程式碼範例示範如何變更第一個系列的顏色：

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的叢集柱狀圖。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 設定第一個系列的顏色。
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // 將簡報檔案儲存至磁碟。
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

結果：

![系列的顏色](series_color.png)

## **變更系列名稱**

Aspose.Slides 提供簡易的方式來修改圖表系列的名稱，使資料標籤更清晰且具意義。透過存取圖表資料中的相關工作表儲存格，開發人員可以自訂資料的呈現方式。當系列名稱需要根據資料情境進行更新或說明時，此修改特別有用。重新命名系列後，可儲存簡報以保留變更。

以下是展示此過程的 C# 程式碼片段。

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的叢集柱狀圖。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 設定第一個系列的名稱。
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // 將簡報檔案儲存至磁碟。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

以下 C# 程式碼示範另一種變更系列名稱的方法：

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的叢集柱狀圖。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // 設定第一個系列的名稱。
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // 將簡報檔案儲存至磁碟。
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

結果：

![系列名稱](series_name.png)

## **取得自動系列填滿顏色**

Aspose.Slides for .NET 允許您取得圖表區域內系列的自動填滿顏色。建立 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別的實例後，您可以透過索引取得目標投影片的參考，然後使用您偏好的類型（例如 `ChartType.ClusteredColumn`）新增圖表。存取圖表中的系列後，即可取得自動填滿顏色。

以下 C# 程式碼詳細示範此流程。

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的叢集柱狀圖。
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // 取得系列的填滿顏色。
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

輸出：

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **設定圖表系列的反轉填滿顏色**

當資料系列同時包含正值與負值時，若所有柱形或棒狀圖使用相同顏色，圖表將難以閱讀。Aspose.Slides for .NET 允許您指定反轉填滿顏色——這是一種會自動套用於低於零的資料點的獨立填充，使負值一目了然。在本節中，您將學習如何啟用此選項、選擇合適的顏色，並儲存更新後的簡報。

以下程式碼範例示範此操作：

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // 新增類別。
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // 新增系列。
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // 填入系列資料。
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // 設定系列的顏色設定。
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

結果：

![反轉的實心填充顏色](inverted_solid_fill_color.png)

您可以對單一資料點而非整個系列套用反轉填充顏色。只需存取目標 `IChartDataPoint`，並將其 `InvertIfNegative` 屬性設為 true。

以下程式碼範例示範如何執行此操作：

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // 若索引 2 的資料點為負值，則反轉顏色。
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **清除特定資料點值**

有時圖表中會包含測試值、異常值或過時的條目，您需要在不重建整個系列的情況下將其移除。Aspose.Slides for .NET 允許您透過索引定位任意資料點，清除其內容，並即時重新整理圖表，使剩餘的資料點移位，座標軸自動重新調整比例。

以下程式碼範例示範此操作：

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **設定系列間隙寬度**

間隙寬度控制相鄰柱形或棒狀圖之間的空白量——較寬的間隙凸顯個別類別，而較窄的間隙則產生更緊密、緊湊的外觀。透過 Aspose.Slides for .NET，您可以對整個系列微調此參數，以達到簡報所需的視覺平衡，而無需更改底層資料。

以下程式碼範例示範如何為系列設定間隙寬度：

```cs
ushort gapWidth = 30;

// 建立空白簡報。
using (Presentation presentation = new Presentation())
{
    // 存取第一張投影片。
    ISlide slide = presentation.Slides[0];

    // 新增預設資料的圖表。
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // 將簡報儲存至磁碟。
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // 設定 GapWidth 值。
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // 將簡報儲存至磁碟。
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

結果：

![間隙寬度](gap_width.png)

## **常見問題**

**單一圖表能包含的系列數量是否有限制？**

Aspose.Slides 並未對您可加入的系列數量設定固定上限。實際限制取決於圖表的可讀性以及您的應用程式可用的記憶體。

**如果叢集內的柱形過於接近或相隔過遠，該怎麼辦？**

調整該系列（或其父系列群組）的 `GapWidth` 設定。增大數值會擴大柱形之間的間距，減小數值則會使它們更靠近。