---
title: Aspose.Slides for .NET 15.11.0におけるパブリックAPIと後方互換性のない変更
type: docs
weight: 210
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.11.0 APIに導入されたすべての[class](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)を[List](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)または[削除された](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)クラス、メソッド、プロパティなど、その他の変更が一覧表示されています。

{{% /alert %}} 
## **パブリックAPIの変更**

#### **DataLabelCollectionクラスの非推奨プロパティが削除されました**
DataLabelCollectionクラスの非推奨プロパティが削除されました：
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

#### **新しいプロパティFirstSlideNumberがPresentationクラスに追加されました**
Presentationに追加された新しいプロパティFirstSlideNumberを使用すると、プレゼンテーションの最初のスライド番号を取得または設定できます。

新しいFirstSlideNumberの値が指定されると、すべてのスライド番号が再計算されます。

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```