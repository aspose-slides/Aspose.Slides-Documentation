---
title: .NET のプレゼンテーションでチャート データ マーカーを管理する
linktitle: データ マーカー
type: docs
url: /ja/net/chart-data-marker/
keywords:
- チャート
- データ ポイント
- マーカー
- マーカー オプション
- マーカー サイズ
- 塗りつぶし タイプ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でチャート データ マーカーをカスタマイズする方法を学び、PPT および PPTX 形式のプレゼンテーション効果を高める、わかりやすい C# コード例をご紹介します。"
---

## **チャート マーカー オプションの設定**
マーカーは特定の系列内のチャート データ ポイントに設定できます。チャート マーカー オプションを設定するには、以下の手順に従ってください。

- Instantiate [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
- デフォルトのチャートを作成します。
- 画像を設定します。
- 最初のチャート系列を取得します。
- 新しいデータ ポイントを追加します。
- プレゼンテーションをディスクに書き込みます。

以下の例では、データ ポイント レベルでチャート マーカー オプションを設定しています。
```c#
// Presentationクラスのインスタンスを作成
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// デフォルトのチャート データ ワークシート インデックスを取得
int defaultWorksheetIndex = 0;

// チャート データ ワークシートを取得
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// デモ系列を削除
chart.ChartData.Series.Clear();

// 新しい系列を追加
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// 画像を設定
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// 画像を設定
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// 最初のチャート系列を取得
IChartSeries series = chart.ChartData.Series[0];

// そこに新しいポイント (1:3) を追加.
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

// チャート系列のマーカーを変更
series.Marker.Size = 15;

// プレゼンテーションをディスクに保存
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Which marker shapes are available out of the box?**

標準の形状が利用できます（円、四角、ダイヤモンド、三角形など）；一覧は[MarkerStyleType](https://reference.aspose.com/slides/net/aspose.slides.charts/markerstyletype/)列挙体で定義されています。非標準の形状が必要な場合は、画像塗りつぶしのマーカーを使用してカスタム ビジュアルをエミュレートしてください。

**Are markers preserved when exporting a chart to an image or SVG?**

はい。チャートを[raster formats](/slides/ja/net/convert-powerpoint-to-png/)にレンダリングする場合や、[shapes as SVG](/slides/ja/net/render-a-slide-as-an-svg-image/)として保存する場合、マーカーは外観と設定（サイズ、塗りつぶし、アウトライン）を保持します。