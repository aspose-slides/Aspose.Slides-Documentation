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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 
このページでは、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)または削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)クラス、メソッド、プロパティ等、そして Aspose.Slides for .NET 15.2.0 APIで導入されたその他の変更をすべて一覧表示します。
{{% /alert %}} 
## **パブリック API の変更**
#### **AddDataPointForDoughnutSeries メソッドが追加されました**
ドーナツチャートタイプの系列にデータポイントを追加するために、IChartDataPointCollection.AddDataPointForDoughnutSeries() メソッドの2つのオーバーロードが追加されました。
#### **Aspose.Slides.SmartArt.SmartArtShape クラスが Aspose.Slides.GeometryShape クラスから継承されました**
Aspose.Slides.SmartArt.SmartArtShape クラスは Aspose.Slides.GeometryShape クラスから継承されました。この変更により Aspose.Slides のオブジェクトモデルが改善され、SmartArtShape クラスに新機能が追加されます。
#### **インデックスでチャートのデータポイントとカテゴリを削除するメソッドが追加されました**
IChartDataPointCollection.RemoveAt(int index) メソッドはインデックスでチャートデータポイントを削除するために追加されました。  
IChartCategoryCollection.RemoveAt(int index) メソッドはインデックスでチャートカテゴリを削除するために追加されました。
#### **PptXPptY 値が Aspose.Slides.Animation.PropertyType 列挙体に追加されました**
PptXPptY 値が Aspose.Slides.Animation.PropertyType 列挙体に追加されました。これはシリアライズ問題の修正の範囲です。
#### **System.Drawing.Color GetAutomaticSeriesColor() メソッドが Aspose.Slides.Charts.IChartSeries に追加されました**
GetAutomaticSeriesColor メソッドは、シリーズインデックスとチャートスタイルに基づいてシリーズの自動カラーを返します。このカラーは FillType が NotDefined の場合にデフォルトで使用されます。

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