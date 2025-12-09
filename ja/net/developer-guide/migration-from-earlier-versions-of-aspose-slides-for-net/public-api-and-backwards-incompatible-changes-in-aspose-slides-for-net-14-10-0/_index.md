---
title: .NET 用 Aspose.Slides 14.10.0 のパブリック API と後方互換性がない変更
linktitle: Aspose.Slides for .NET 14.10.0
type: docs
weight: 120
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- マイグレーション
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP のプレゼンテーション ソリューションを円滑に移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.10.0 APIで導入された、追加または削除されたクラス、メソッド、プロパティ等、およびその他の変更を一覧表示します。

{{% /alert %}} 
## **Public API の変更**
#### **Aspose.Slides.FieldType.Footer フィールドタイプが追加されました**
このフィールドタイプは、この種のフィールドを作成できるようにし、プレゼンテーションの有効なシリアライズを行うために追加されました。
#### **Enum 要素 ShapeElementFillSource.Own が削除されました**
重複していたため、Enum 要素 ShapeElementFillSource.Own が削除されました。ShapeElementFillSource.Own の代わりに ShapeElementFillSource.Shape を使用してください。
#### **チャート データ ポイントおよびカテゴリの削除用メソッドが追加されました**
次のメソッドが追加され、チャート データ ポイント コレクションからデータ ポイントを削除できるようになりました:

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

次のメソッドが追加され、チャート カテゴリをそのコレクションから削除できるようになりました:

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
#### **廃止予定だった Aspose.Slides.ParagraphFormat のプロパティが削除されました**
BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle の各プロパティは削除されました。これらは以前から廃止予定としてマークされていました。
#### **不要かつ廃止予定だったコンストラクタが削除されました**
以下のコンストラクタが削除されました:

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