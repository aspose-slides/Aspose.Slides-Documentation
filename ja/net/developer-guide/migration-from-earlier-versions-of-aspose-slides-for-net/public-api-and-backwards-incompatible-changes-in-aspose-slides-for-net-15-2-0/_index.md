---
title: Aspose.Slides for .NET 15.2.0 のパブリック API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 15.2.0
type: docs
weight: 140
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーションソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページは Aspose.Slides for .NET 15.2.0 API で導入された、[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) または [削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) クラス、メソッド、プロパティ等、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **AddDataPointForDoughnutSeries メソッドが追加されました**
IChartDataPointCollection.AddDataPointForDoughnutSeries() メソッドの 2 つのオーバーロードが追加され、ドーナツ チャート タイプのシリーズにデータ ポイントを追加できるようになりました。
#### **Aspose.Slides.SmartArt.SmartArtShape クラスが Aspose.Slides.GeometryShape クラスから継承されました**
Aspose.Slides.SmartArt.SmartArtShape クラスが Aspose.Slides.GeometryShape クラスから継承されました。この変更により Aspose.Slides のオブジェクト モデルが向上し、SmartArtShape クラスに新機能が追加されます。
#### **インデックスでチャート データ ポイントとチャート カテゴリを削除するメソッドが追加されました**
IChartDataPointCollection.RemoveAt(int index) メソッドが追加され、インデックスでチャート データ ポイントを削除できます。
IChartCategoryCollection.RemoveAt(int index) メソッドが追加され、インデックスでチャート カテゴリを削除できます。
#### **PptXPptY 値が Aspose.Slides.Animation.PropertyType 列挙体に追加されました**
シリアライズの問題修正の範囲で、Aspose.Slides.Animation.PropertyType 列挙体に PptXPptY 値が追加されました。
#### **System.Drawing.Color GetAutomaticSeriesColor() メソッドが Aspose.Slides.Charts.IChartSeries に追加されました**
GetAutomaticSeriesColor メソッドは、シリーズ インデックスとチャート スタイルに基づいてシリーズの自動カラーを返します。このカラーは FillType が NotDefined の場合にデフォルトで使用されます。

``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}

```