---
title: Aspose.Slides for .NET 15.2.0の公開APIと後方非互換性のある変更
type: docs
weight: 140
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.2.0 APIで追加または削除されたすべての[class](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)や[method](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)やプロパティなど、その他の変更がリストされています。

{{% /alert %}} 
## **公開APIの変更**
#### **AddDataPointForDoughnutSeriesメソッドが追加されました**
Doughnutチャートタイプの系列にデータポイントを追加するためのIChartDataPointCollection.AddDataPointForDoughnutSeries()メソッドの2つのオーバーロードが追加されました。
#### **Aspose.Slides.SmartArt.SmartArtShapeクラスはAspose.Slides.GeometryShapeクラスから継承されました**
Aspose.Slides.SmartArt.SmartArtShapeクラスはAspose.Slides.GeometryShapeクラスから継承されました。この変更により、Aspose.Slidesのオブジェクトモデルが改善され、SmartArtShapeクラスに新機能が追加されます。
#### **インデックスによるチャートデータポイントとチャートカテゴリの削除メソッドが追加されました**
IChartDataPointCollection.RemoveAt(int index)メソッドが、インデックスによるチャートデータポイントを削除するために追加されました。
IChartCategoryCollection.RemoveAt(int index)メソッドが、インデックスによるチャートカテゴリを削除するために追加されました。
#### **PptXPptY値がAspose.Slides.Animation.PropertyType列挙型に追加されました**
PptXPptY値が、シリアライゼーションの問題修正の範囲内でAspose.Slides.Animation.PropertyType列挙型に追加されました。
#### **System.Drawing.Color GetAutomaticSeriesColor()メソッドがAspose.Slides.Charts.IChartSeriesに追加されました**
GetAutomaticSeriesColorメソッドは、系列インデックスとチャートスタイルに基づいて系列の自動色を返します。この色は、FillTypeがNotDefinedの場合にデフォルトで使用されます。

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