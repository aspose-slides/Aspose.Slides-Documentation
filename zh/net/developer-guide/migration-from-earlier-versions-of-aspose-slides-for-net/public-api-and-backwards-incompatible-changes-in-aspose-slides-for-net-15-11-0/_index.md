---
title: Aspose.Slides for .NET 15.11.0 的公共API和向后不兼容的更改
type: docs
weight: 210
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
---

{{% alert color="primary" %}} 

本页面列出了所有在 Aspose.Slides for .NET 15.11.0 API 中[添加](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)或[删除](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/)的类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共API更改**

#### **DataLabelCollection 类中的过时属性已被删除**
DataLabelCollection 类中的过时属性已被删除：
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

#### **Presentation 类中添加了新属性 FirstSlideNumber**
新增属性 FirstSlideNumber 允许获取或设置演示文稿中的第一页幻灯片的编号。

当指定新的 FirstSlideNumber 值时，所有幻灯片编号将被重新计算。

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```