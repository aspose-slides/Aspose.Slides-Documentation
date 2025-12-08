---
title: チャート データ マーカー
type: docs
url: /ja/net/chart-data-marker/
keywords:
- チャート マーカー オプション
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "PowerPoint プレゼンテーションで C# または .NET を使用してチャート マーカー オプションを設定します"
---

## **チャート マーカー オプションの設定**
マーカーは特定の系列のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラス。
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータ ポイントを追加します。
- プレゼンテーションをディスクに保存します。

以下の例では、データ ポイント レベルでチャート マーカー オプションを設定しています。
```c#
// Presentation クラスのインスタンスを作成します
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// デフォルトのチャート データ ワークシート インデックスを取得しています
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得しています
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// デモ シリーズを削除します
chart.ChartData.Series.Clear();

// 新しいシリーズを追加します
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// 画像を設定します
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 画像を設定します
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 最初のチャート シリーズを取得します
IChartSeries series = chart.ChartData.Series[0];

// そこに新しいポイント (1:3) を追加します
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

// チャート シリーズのマーカーを変更しています
series.Marker.Size = 15;

// プレゼンテーションをディスクに保存します
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**標準で利用できるマーカー形状はどれですか？**

標準の形状（円、四角、ダイヤモンド、三角形など）が利用可能です。一覧は[MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/) 列挙体で定義されています。標準外の形状が必要な場合は、画像塗り付きマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**チャートを画像や SVG にエクスポートしたとき、マーカーは保持されますか？**

はい。チャートを[raster formats](/slides/ja/net/convert-powerpoint-to-png/) にレンダリングしたり、[shapes as SVG](/slides/ja/net/render-a-slide-as-an-svg-image/) として保存したりすると、マーカーは外観や設定（サイズ、塗り、輪郭など）を保持します。