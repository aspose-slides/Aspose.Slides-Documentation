---
title: Aspose.Slides for .NET 16.2.0 的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了所有[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 16.2.0 API 引入的其他更改。

{{% /alert %}} 
## **Public API Changes**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields Have Been Removed**
已从 Aspose.Slides.Presentation 类和 Aspose.Slides.IPresentation 接口中移除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields。  
Aspose.Slides.TextFrame、Paragraph、Portion 类以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 接口的 Text 属性返回已更新 “datetime” 字段的文本。  
此外，Presentation.DocumentProperties.CreatedTime、LastSavedTime 和 LastPrinted 属性已变为只读。

#### **Enum Slides.Charts.CategoryAxisType Has Been Switched to Public**
用于 IAxis.CategoryAxisType 和 Axis.CategoryAxisType 属性，以确定类别轴类型。  
CategoryAxisType.Auto - 序列化期间将自动确定类别轴类型（此行为当前未实现）  
CategoryAxisType.Text - 类别轴类型为 Text  
CategoryAxisType.Date - 类别轴类型为 DateTime  

#### **Fast Text Extraction**
已在 Presentation 类中添加新的静态方法 GetPresentationText。该方法有两个重载：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 枚举参数指示组织文本输出的模式，可设置为以下值：  
Unarranged - 原始文本，不考虑幻灯片上的位置  
Arranged - 文本按幻灯片上的顺序排列  

当速度至关重要时，可使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，返回 ISlideText 对象数组。每个对象代表相应幻灯片上的文本。ISlideText 对象具有以下属性：

ISlideText.Text - 幻灯片形状上的文本  
ISlideText.MasterText - 该幻灯片对应的母版页形状上的文本  
ISlideText.LayoutText - 该幻灯片对应的版式页形状上的文本  
ISlideText.NotesText - 该幻灯片备注页形状上的文本  

另有实现 ISlideText 接口的 SlideText 类。

新 API 的使用示例：

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 

#### **ILegacyDiagram Interface and LegacyDiagram Class Have Been Added**
已添加接口 Aspose.Slides.ILegacyDiagram 和类 Aspose.Slides.LegacyDiagram，用于表示遗留图表对象。遗留图表对象是 PowerPoint 97-2003 的旧版图表格式。新类提供将遗留图表转换为可编辑的 SmartArt 对象或可编辑的 GroupShape 的方法。

#### **New Aspose.Slides.TextAlignment Enum Member Added (JustifyLow)**
TextAlignment 枚举新增成员：  
JustifyLow - Kashida 低位对齐。

#### **New Properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
已向 IOleObjectFrame 接口及实现该接口的 OleObjectFrame 类添加新属性，用于提供嵌入对象的信息：  
EmbeddedFileExtension - 返回当前嵌入对象的文件扩展名，如果对象不是链接则返回空字符串  
EmbeddedFileLabel - 返回嵌入 OLE 对象的文件名  
EmbeddedFileName - 返回嵌入 OLE 对象的路径  

#### **New Property CategoryAxisType Has Been Added to IAxis and Axis Classes**
属性 CategoryAxisType 指定类别轴的类型。

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 

#### **New Property ShowLabelAsDataCallout Has Been Added to DataLabelFormat Class and IDataLabelFormat Interface**
属性 ShowLabelAsDataCallout 决定指定图表的数据标签是显示为数据呼叫框还是作为普通数据标签。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 

#### **Property DrawSlidesFrame Has Been Added to PdfOptions and XpsOptions**
布尔属性 DrawSlidesFrame 已添加到接口 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 以及相应的类 Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions。  
如果将此属性设为 true，则在每张幻灯片周围绘制黑色框。

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```