---
title: 公共 API 和向后不兼容的更改（Aspose.Slides for .NET 16.2.0）
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 迁移
- 老代码
- 现代代码
- 老式方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 
此页面列出所有 [已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) 或 [已删除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) 的类、方法、属性等，以及 Aspose.Slides for .NET 16.2.0 API 引入的其他更改。
{{% /alert %}} 
## **Public API Changes**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields have been removed**
已从 Aspose.Slides.Presentation 类和 Aspose.Slides.IPresentation 接口中移除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields。  
Aspose.Slides.TextFrame、Paragraph、Portion 类以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 接口的 Text 属性现在返回已更新“datetime”字段的文本。  
此外，Presentation.DocumentProperties.CreatedTime、LastSavedTime 和 LastPrinted 属性已变为只读。

#### **Enum Slides.Charts.CategoryAxisType has been switched to public**
在 IAxis.CategoryAxisType 和 Axis.CategoryAxisType 属性中使用，以确定类目轴类型。  
- CategoryAxisType.Auto – 在序列化期间自动确定类目轴类型（此行为目前未实现）  
- CategoryAxisType.Text – 类目轴类型为 Text  
- CategoryAxisType.Date – 类目轴类型为 DateTime  

#### **Fast text extraction**
已在 Presentation 类中添加静态方法 GetPresentationText。此方法有两个重载：

```csharp
PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)
```

ExtractionMode 枚举参数指示文本结果的组织方式，可设为以下值：  
- Unarranged – 原始文本，不考虑幻灯片上的位置  
- Arranged – 文本按幻灯片上的顺序排列  

当速度至关重要时，可使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，返回 ISlideText 对象数组。每个对象表示对应幻灯片上的文本。ISlideText 对象具有以下属性：

- ISlideText.Text – 幻灯片形状上的文本  
- ISlideText.MasterText – 该幻灯片所在母版页形状上的文本  
- ISlideText.LayoutText – 该幻灯片所在版式页形状上的文本  
- ISlideText.NotesText – 该幻灯片笔记页形状上的文本  

另外还有实现 ISlideText 接口的 SlideText 类。

新的 API 使用示例：

```csharp
PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");
Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged);
```

#### **ILegacyDiagram interface and LegacyDiagram class have been added**
已添加接口 Aspose.Slides.ILegacyDiagram 和类 Aspose.Slides.LegacyDiagram，用于表示旧版图表对象。Legacy diagram 对象是 PowerPoint 97‑2003 中的旧格式图表。新类提供将旧版图表转换为可编辑的 SmartArt 对象或可编辑的 GroupShape 的方法。

#### **New Aspose.Slides.TextAlignment enum membed added (JustifyLow)**
TextAlignment 枚举新增成员：  
- JustifyLow – Kashida 低对齐。

#### **New properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
在 IOleObjectFrame 接口及其实现类 OleObjectFrame 中新增以下属性，用于提供嵌入对象的信息：  
- EmbeddedFileExtension – 返回当前嵌入对象的文件扩展名；若对象不是链接则返回空字符串  
- EmbeddedFileLabel – 返回嵌入 OLE 对象的文件名  
- EmbeddedFileName – 返回嵌入 OLE 对象的路径  

#### **New property CategoryAxisType has been added to IAxis and Axis classes**
在 IAxis 和 Axis 类中添加了 CategoryAxisType 属性，用于指定类目轴类型。

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

#### **New property ShowLabelAsDataCallout has been added to DataLabelFormat class and IDataLabelFormat interface**
ShowLabelAsDataCallout 属性决定指定图表的数据标签是显示为数据标注还是数据标签。

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

#### **Property DrawSlidesFrame has been added to PdfOptions and XpsOptions**
在 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 接口以及对应的 PdfOptions、XpsOptions 类中新增布尔属性 DrawSlidesFrame。若将该属性设为 true，则将在每张幻灯片周围绘制黑色框。

```csharp
using (Presentation pres = new Presentation("input.pptx"))
{
    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });
}
```