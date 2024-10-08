---
title: Aspose.Slides for .NET 15.2.0中的公共API和不兼容的变更
type: docs
weight: 140
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
---

{{% alert color="primary" %}} 

此页面列出了所有[添加的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)或[移除的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/)类、方法、属性等，以及Aspose.Slides for .NET 15.2.0 API引入的其他变更。

{{% /alert %}} 
## **公共API变更**
#### **添加了AddDataPointForDoughnutSeries方法**
为将数据点添加到甜甜圈图类型系列中，添加了IChartDataPointCollection.AddDataPointForDoughnutSeries()方法的两个重载。
#### **Aspose.Slides.SmartArt.SmartArtShape类继承自Aspose.Slides.GeometryShape类**
Aspose.Slides.SmartArt.SmartArtShape类已从Aspose.Slides.GeometryShape类继承。此更改改善了Aspose.Slides对象模型，并为SmartArtShape类添加了新功能。
#### **添加了通过索引移除图表数据点和图表类别的方法**
添加了IChartDataPointCollection.RemoveAt(int index)方法，用于通过索引移除图表数据点。
添加了IChartCategoryCollection.RemoveAt(int index)方法，用于通过索引移除图表类别。
#### **PptXPptY值已添加到Aspose.Slides.Animation.PropertyType枚举**
在序列化问题修复的范围内，PptXPptY值已添加到Aspose.Slides.Animation.PropertyType枚举。
#### **System.Drawing.Color GetAutomaticSeriesColor()方法已添加到Aspose.Slides.Charts.IChartSeries**
GetAutomaticSeriesColor方法根据系列索引和图表样式返回系列的自动颜色。如果FillType等于NotDefined，则默认使用此颜色。

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