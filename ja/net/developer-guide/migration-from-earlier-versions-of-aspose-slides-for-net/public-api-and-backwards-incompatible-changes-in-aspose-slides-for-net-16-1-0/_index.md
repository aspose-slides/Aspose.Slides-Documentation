---
title: Aspose.Slides for .NET 16.1.0 のパブリック API と後方互換性がない変更
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- 従来のアプローチ
- 現代的アプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーションソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) クラス、メソッド、プロパティなど、その他の変更を一覧表示し、Aspose.Slides for .NET 16.1.0 APIで導入された内容を示します。

{{% /alert %}} 
## **パブリック API の変更**


#### **Property RotationAngle が IChartTextBlockFormat と ITextFrameFormat インターフェイスに追加されました**
Property RotationAngle はインターフェイス Aspose.Slides.Charts.IChartTextBlockFormat と Aspose.Slides.ITextFrameFormat に追加されました。これは、バウンディング ボックス内のテキストに適用されるカスタム回転を指定します。

``` csharp

 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **OdpException が Aspose.Slides.Odp から Aspose.Slides 名前空間に移動しました**