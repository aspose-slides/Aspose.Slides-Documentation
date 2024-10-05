---
title: チャートデータマーカー
type: docs
url: /net/chart-data-marker/
keywords:
- チャートマーカーオプション
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションのチャートマーカーオプションを設定します"
---

## **チャートマーカーオプションの設定**
マーカーは特定のシリーズ内のチャートデータポイントに設定できます。チャートマーカーオプションを設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャートシリーズを取得します。
- 新しいデータポイントを追加します。
- プレゼンテーションをディスクに保存します。

以下の例では、データポイントレベルでチャートマーカーオプションを設定しています。

```c#
// Create an instance of Presentation class
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Creating the default chart
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Getting the default chart data worksheet index
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Delete demo series
chart.ChartData.Series.Clear();

// Add new series
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "シリーズ 1"), chart.Type);

// Set the picture
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Set the picture
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Take first chart series
IChartSeries series = chart.ChartData.Series[0];

// Add new point (1:3) there.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// Changing the chart series marker
series.Marker.Size = 15;

// Write presentation to disk
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```