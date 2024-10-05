---
title: Aspose.Slides for .NET 16.1.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 220
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 16.1.0 APIで追加されたすべての[class](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)または[removed](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)クラス、メソッド、プロパティなど、およびその他の変更を示します。

{{% /alert %}} 
## **パブリックAPIの変更**


#### **IChartTextBlockFormatおよびITextFrameFormatインターフェイスにRotationAngleプロパティが追加されました**
RotationAngleプロパティがAspose.Slides.Charts.IChartTextBlockFormatおよびAspose.Slides.ITextFrameFormatインターフェイスに追加されました。
これは、バウンディングボックス内のテキストに適用されるカスタム回転を指定します。

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("カスタムタイトル").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpExceptionがAspose.Slides.OdpからAspose.Slides名前空間に移動されました**