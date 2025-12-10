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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行しましょう。"
---

{{% alert color="primary" %}} 
このページでは、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) クラス、メソッド、プロパティなど、すべての変更と、Aspose.Slides for .NET 15.2.0 API によって導入されたその他の変更を一覧表示します。
{{% /alert %}} 
## **パブリック API の変更**
#### **AddDataPointForDoughnutSeries メソッドが追加されました**
IChartDataPointCollection.AddDataPointForDoughnutSeries() メソッドの 2 つのオーバーロードが、ドーナツ チャート タイプのシリーズにデータ ポイントを追加するために追加されました。
#### **Aspose.Slides.SmartArt.SmartArtShape クラスが Aspose.Slides.GeometryShape クラスから継承されました**
Aspose.Slides.SmartArt.SmartArtShape クラスは Aspose.Slides.GeometryShape クラスから継承されました。この変更により Aspose.Slides のオブジェクト モデルが改善され、SmartArtShape クラスに新機能が追加されます。
#### **インデックスでチャート データ ポイントとチャート カテゴリを削除するメソッドが追加されました**
IChartDataPointCollection.RemoveAt(int index) メソッドが、インデックスでチャート データ ポイントを削除するために追加されました。  
IChartCategoryCollection.RemoveAt(int index) メソッドが、インデックスでチャート カテゴリを削除するために追加されました。
#### **Aspose.Slides.Animation.PropertyType 列挙体に PptXPptY 値が追加されました**
シリアライズの問題修正の対象として、Aspose.Slides.Animation.PropertyType 列挙体に PptXPptY 値が追加されました。
#### **Aspose.Slides.Charts.IChartSeries に System.Drawing.Color GetAutomaticSeriesColor() メソッドが追加されました**
GetAutomaticSeriesColor メソッドは、シリーズのインデックスとチャート スタイルに基づいてシリーズの自動カラーを返します。FillType が NotDefined の場合、このカラーがデフォルトで使用されます。

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