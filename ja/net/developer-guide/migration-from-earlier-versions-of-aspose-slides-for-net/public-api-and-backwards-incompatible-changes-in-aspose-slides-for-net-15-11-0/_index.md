---
title: Aspose.Slides for .NET 15.11.0 のパブリック API と後方互換性がない変更
linktitle: Aspose.Slides for .NET 15.11.0
type: docs
weight: 210
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
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
description: "Aspose.Slides for .NET のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションをスムーズに移行できます。"
---

{{% alert color="primary" %}} 

このページでは、[追加された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)または[削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)クラス、メソッド、プロパティなど、その他の変更を一覧表示します。

{{% /alert %}} 
## **パブリック API の変更**

#### **DataLabelCollection クラスの旧式プロパティが削除されました**
旧式プロパティは以下のとおり削除されました:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **Presentation クラスに新しいプロパティ FirstSlideNumber が追加されました**
Presentation に追加された新しいプロパティ FirstSlideNumber は、プレゼンテーションの最初のスライド番号を取得または設定できるようにします。

新しい FirstSlideNumber の値が指定されると、すべてのスライド番号が再計算されます。

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```