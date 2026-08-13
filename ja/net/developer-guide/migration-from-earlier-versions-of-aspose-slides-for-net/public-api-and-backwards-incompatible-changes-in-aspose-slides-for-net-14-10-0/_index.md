---
title: Aspose.Slides for .NET 14.10.0 におけるパブリック API と後方互換性のない変更
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
{{% alert color="info" %}} 

このページでは、すべての[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)または[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)クラス、メソッド、プロパティ等、およびAspose.Slides for .NET 14.10.0 APIで導入されたその他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**
#### **Aspose.Slides.FieldType.Footer フィールドタイプが追加されました**
Footer フィールドタイプが追加され、該当タイプのフィールド作成および有効なプレゼンテーションのシリアライズが可能になりました。
#### **列挙体要素 ShapeElementFillSource.Own が削除されました**
ShapeElementFillSource.Own 列挙体要素は重複していたため削除されました。代わりに ShapeElementFillSource.Shape を使用してください。
#### **チャート データポイントおよびカテゴリの削除用メソッドが追加されました**
以下のメソッドが追加され、チャート データポイント コレクションからデータポイントを削除できるようになりました:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

以下のメソッドが追加され、含まれるコレクションからチャート カテゴリを削除できるようになりました:

IChartCategory.Remove()

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove() で削除

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove() で削除

    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//ChartDataPoint.Remove() で削除

        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }

    pres.Save("chart.pptx", SaveFormat.Pptx);
}
``` 
#### **廃止予定の Aspose.Slides.ParagraphFormat プロパティが削除されました**
BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle のプロパティが削除されました。これらのプロパティはかなり前に廃止予定とマークされていました。
#### **不要かつ廃止予定のコンストラクタが削除されました**
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