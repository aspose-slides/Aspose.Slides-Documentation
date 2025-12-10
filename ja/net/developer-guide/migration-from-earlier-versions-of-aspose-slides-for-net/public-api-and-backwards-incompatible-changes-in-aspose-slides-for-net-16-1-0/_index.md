---
title: Aspose.Slides for .NET 16.1.0 の公開 API と後方互換性のない変更
linktitle: Aspose.Slides for .NET 16.1.0
type: docs
weight: 220
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "Aspose.Slides for .NET の公開 API 更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できるようにします。"
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 16.1.0 API に導入された、追加された[added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)または削除された[removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/)クラス、メソッド、プロパティ等と、その他の変更を一覧します。

{{% /alert %}} 
## **パブリック API の変更**

#### **IChartTextBlockFormat と ITextFrameFormat インターフェイスに Property RotationAngle が追加されました**
Property RotationAngle が Aspose.Slides.Charts.IChartTextBlockFormat と Aspose.Slides.ITextFrameFormat インターフェイスに追加されました。  
このプロパティは、バウンディング ボックス内のテキストに適用されるカスタム回転角度を指定します。

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
#### **OdpException が Aspose.Slides.Odp から Aspose.Slides 名前空間へ移動しました**