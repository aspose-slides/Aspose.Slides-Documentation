---
title: Aspose.Slides for .NET 16.2.0 中的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 迁移
- 旧版代码
- 现代代码
- 旧版方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审阅 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出了所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)或[已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 16.2.0 API 引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**
#### **已删除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields**
已删除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields，这两个属性分别位于 Aspose.Slides.Presentation 类和 Aspose.Slides.IPresentation 接口中。  
Aspose.Slides.TextFrame、Paragraph、Portion 类以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 接口的 Text 属性现在返回已更新 “datetime” 字段的文本。  
此外，属性 Presentation.DocumentProperties.CreatedTime、LastSavedTime 和 LastPrinted 已变为只读。

#### **枚举 Slides.Charts.CategoryAxisType 已设为 public**
在 IAxis.CategoryAxisType 和 Axis.CategoryAxisType 属性中使用，用于确定类目轴类型。  
- CategoryAxisType.Auto - 在序列化期间自动确定类目轴类型（此行为目前未实现）  
- CategoryAxisType.Text - 类目轴类型为 Text  
- CategoryAxisType.Date - 类目轴类型为 DateTime  

#### **快速文本提取**
在 Presentation 类中新增静态方法 GetPresentationText，提供两个重载：

```csharp
PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

ExtractionMode 枚举参数指示组织文本结果的方式，可设为以下值：  
- Unarranged - 原始文本，不考虑在幻灯片上的位置  
- Arranged - 文本按照在幻灯片上的顺序排列  

当速度至关重要时，可使用 Unarranged 模式，其比 Arranged 模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，返回 ISlideText 对象数组。每个对象表示相应幻灯片上的文本。ISlideText 对象具有以下属性：

- ISlideText.Text - 幻灯片形状上的文本  
- ISlideText.MasterText - 该幻灯片对应母版页面形状上的文本  
- ISlideText.LayoutText - 该幻灯片对应布局页面形状上的文本  
- ISlideText.NotesText - 该幻灯片备注页形状上的文本  

另外还有实现了 ISlideText 接口的 SlideText 类。

新 API 的使用示例：

```csharp
PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);
```

#### **已添加 ILegacyDiagram 接口和 LegacyDiagram 类**
新增接口 Aspose.Slides.ILegacyDiagram 与类 Aspose.Slides.LegacyDiagram，用于表示传统图表对象。传统图表对象是 PowerPoint 97-2003 时代的旧格式图表。新类提供将传统图表转换为现代可编辑 SmartArt 对象或可编辑 GroupShape 的方法。

#### **Aspose.Slides.TextAlignment 枚举新增成员 (JustifyLow)**
为 TextAlignment 枚举新增成员：  
- JustifyLow - Kashida 低对齐。

#### **为 Aspose.Slides.IOleObjectFrame 和 OleObjectFrame 添加新属性**
在 IOleObjectFrame 接口及其实现类 OleObjectFrame 中新增以下属性，用于提供嵌入对象的信息：  
- EmbeddedFileExtension - 返回当前嵌入对象的文件扩展名，如果对象不是链接则返回空字符串  
- EmbeddedFileLabel - 返回嵌入 OLE 对象的文件名  
- EmbeddedFileName - 返回嵌入 OLE 对象的路径  

#### **在 IAxis 和 Axis 类中新增属性 CategoryAxisType**
属性 CategoryAxisType 指定类目轴的类型。

```csharp
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

#### **在 DataLabelFormat 类和 IDataLabelFormat 接口中新增属性 ShowLabelAsDataCallout**
属性 ShowLabelAsDataCallout 决定指定图表的数据标签是以数据标注形式显示还是以数据标签形式显示。

```csharp
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    pres.Save(pptxFileName, SaveFormat.Pptx);
}
```

#### **在 PdfOptions 和 XpsOptions 中新增属性 DrawSlidesFrame**
在接口 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 以及相应类 Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions 中新增布尔属性 DrawSlidesFrame。若将该属性设为 true，则每个幻灯片周围的黑色边框将被绘制。

```csharp
using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```
