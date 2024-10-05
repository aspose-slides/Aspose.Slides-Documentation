---
title: .NET向けAspose.SlidesのパブリックAPIと後方互換性のない変更点 14.10.0
type: docs
weight: 120
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 14.10.0 APIに導入されたすべての[class added](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)または[class removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)のクラス、メソッド、プロパティなど、及びその他の変更を一覧表示しています。

{{% /alert %}} 
## **パブリックAPIの変更点**
#### **Aspose.Slides.FieldType.Footerフィールドタイプが追加されました**
Footerフィールドタイプが追加され、このタイプのフィールドを作成する可能性を実装し、有効なプレゼンテーションのシリアル化を行うことができます。
#### **Enum要素ShapeElementFillSource.Ownが削除されました**
Enum要素ShapeElementFillSource.Ownが重複しているため削除されました。ShapeElementFillSource.Ownの代わりにShapeElementFillSource.Shapeを使用してください。
#### **チャートデータポイントおよびカテゴリ削除のためのメソッドが追加されました**
チャートデータポイントコレクションからチャートデータポイントを削除するための以下のメソッドが追加されました：

IChartDataPointCollection.Remove(IChartDataPoint)  
IChartDataPoint.Report()

以下のメソッドは、含まれるコレクションからチャートカテゴリを削除することができます：

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //ChartCategory.Remove()で削除

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //ChartCategoryCollection.Remove()で削除

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove(); //ChartDataPoint.Remove()で削除

        ser.DataPoints.Remove(ser.DataPoints[0]); //ChartDataPointCollection.Remove()で削除

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **非推奨のAspose.Slides.ParagraphFormatプロパティが削除されました**
プロパティBulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyleが削除されました。これらは長い間非推奨としてマークされていました。
#### **不要で非推奨のコンストラクタが削除されました**
以下のコンストラクタが削除されました：

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