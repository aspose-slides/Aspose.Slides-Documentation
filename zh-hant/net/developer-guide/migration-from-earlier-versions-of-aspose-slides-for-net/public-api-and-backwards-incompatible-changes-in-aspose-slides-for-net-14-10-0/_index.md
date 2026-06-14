---
title: "Aspose.Slides for .NET 14.10.0 的公共 API 與向後不相容變更"
linktitle: "Aspose.Slides for .NET 14.10.0"
type: docs
weight: 120
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- 遷移
- 遺留程式碼
- 現代程式碼
- 遺留方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 
此頁面列出所有已[新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)或已[移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/)的類別、方法、屬性等，以及在 Aspose.Slides for .NET 14.10.0 API 中引入的其他變更。
{{% /alert %}} 
## **公共 API 變更**
#### **已新增 Aspose.Slides.FieldType.Footer 欄位類型**
已新增 Footer 欄位類型，以實作建立此類型欄位的可能性，並用於有效的簡報序列化。
#### **已刪除列舉成員 ShapeElementFillSource.Own**
由於重複，已刪除列舉成員 ShapeElementFillSource.Own。請改用 ShapeElementFillSource.Shape 取代 ShapeElementFillSource.Own。
#### **已新增用於移除圖表資料點、類別的方法**
已新增以下方法，允許從圖表資料點集合中移除圖表資料點：

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

已新增以下方法，允許從其所屬集合中移除圖表類別：

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

    chart.ChartData.Categories[0].Remove(); //使用 ChartCategory.Remove() 移除

    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //使用 ChartCategoryCollection.Remove() 移除

    foreach (var ser in chart.ChartData.Series)

    {

        ser.DataPoints[0].Remove();//使用 ChartDataPoint.Remove() 移除

        ser.DataPoints.Remove(ser.DataPoints[0]);//使用 ChartDataPointCollection.Remove()

    }

    pres.Save(outPath, SaveFormat.Pptx);

}

``` 
#### **已移除過時的 Aspose.Slides.ParagraphFormat 屬性**
已移除屬性 BulletChar、BulletColor、BulletColorFormat、BulletFont、BulletHeight、BulletType、IsBulletHardColor、IsBulletHardFont、NumberedBulletStartWith、NumberedBulletStyle。這些屬性早已標示為過時。
#### **已移除無用且過時的建構函式**
以下建構函式已被移除：

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