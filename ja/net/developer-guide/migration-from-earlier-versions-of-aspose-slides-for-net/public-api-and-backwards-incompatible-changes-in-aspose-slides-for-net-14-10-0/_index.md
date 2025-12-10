---
title: Aspose.Slides for .NET 14.10.0 のパブリック API と後方互換性のない変更
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
description: "Aspose.Slides for .NET のパブリック API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.10.0 APIで導入された、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)されたクラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **Public API 変更**
#### **Aspose.Slides.FieldType.Footer フィールド型が追加されました**
このフィールド型は、このタイプのフィールドを作成できるようにする実装と、正しいプレゼンテーションのシリアライズのために追加されました。
#### **Enum 要素 ShapeElementFillSource.Own が削除されました**
重複しているため、Enum 要素 ShapeElementFillSource.Own は削除されました。ShapeElementFillSource.Own の代わりに ShapeElementFillSource.Shape を使用してください。
#### **チャート データポイントおよびカテゴリの削除に関するメソッドが追加されました**
チャート データポイント コレクションからデータポイントを削除できる次のメソッドが追加されました:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

含むコレクションからチャート カテゴリを削除できる次のメソッドが追加されました:

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
#### **非推奨の Aspose.Slides.ParagraphFormat プロパティが削除されました**
プロパティ BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle が削除されました。これらは以前から非推奨とされていました。
#### **不要かつ非推奨のコンストラクタが削除されました**
次のコンストラクタが削除されました:

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