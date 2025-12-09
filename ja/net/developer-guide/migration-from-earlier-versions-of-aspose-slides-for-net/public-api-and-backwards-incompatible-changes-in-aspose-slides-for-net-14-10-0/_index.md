---
title: Aspose.Slides for .NET 14.10.0 のパブリック API と後方互換性がない変更
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.10.0 APIで導入された、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)されたクラス、メソッド、プロパティなど、すべての変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Aspose.Slides.FieldType.Footer フィールド タイプが追加されました**
Footer フィールド タイプは、このタイプのフィールドを作成できるように実装され、プレゼンテーションの有効なシリアライズのために追加されました。
#### **Enum 要素 ShapeElementFillSource.Own が削除されました**
重複しているため、Enum 要素 ShapeElementFillSource.Own が削除されました。ShapeElementFillSource.Own の代わりに ShapeElementFillSource.Shape を使用してください。
#### **チャート データ ポイントおよびカテゴリの削除に関するメソッドが追加されました**
チャート データ ポイント コレクションからデータポイントを削除できる以下のメソッドが追加されました：

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

含まれるコレクションからチャート カテゴリを削除できる以下のメソッドが追加されました：

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //remove with ChartCategory.Remove()

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //remove with ChartCategoryCollection.Remove()

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//remove with ChartDataPoint.Remove()

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **廃止された Aspose.Slides.ParagraphFormat プロパティが削除されました**
プロパティ BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle は削除されました。これらは以前から廃止予定としてマークされていました。
#### **不要かつ廃止されたコンストラクターが削除されました**
以下のコンストラクターが削除されました：

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)