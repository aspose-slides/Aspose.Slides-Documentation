---
title: Aspose.Slides for .NET 16.2.0 的公共 API 与向后不兼容更改
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- 迁移
- 遗留代码
- 现代代码
- 遗留方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "查看 Aspose.Slides for .NET 中的公共 API 更新和突破性更改，帮助您顺利迁移 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 

此页面列出所有已[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 16.2.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **已删除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields**
已从 Aspose.Slides.Presentation 类和 Aspose.Slides.IPresentation 接口中删除属性 UpdateDateTimeFields 和 UpdateSlideNumberFields。
Aspose.Slides.TextFrame、Paragraph、Portion 类以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 接口的 Text 属性返回已更新 “datetime” 字段的文本。
此外，Presentation.DocumentProperties.CreatedTime、LastSavedTime 和 LastPrinted 属性已变为只读。
#### **枚举 Slides.Charts.CategoryAxisType 已设为 public**
用于 IAxis.CategoryAxisType 和 Axis.CategoryAxisType 属性，以确定类别轴类型。
CategoryAxisType.Auto - 在序列化期间自动确定类别轴类型（此行为目前未实现）
CategoryAxisType.Text - 类别轴类型为 Text
CategoryAxisType.Date - 类别轴类型为 DateTime
#### **快速文本提取**
在 Presentation 类中新增了静态方法 GetPresentationText。该方法有两个重载：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 枚举参数指示组织文本结果输出的模式，可设置为以下值：
Unarranged - 原始文本，不考虑幻灯片上的位置
Arranged - 文本按照幻灯片上的顺序排列

当速度至关重要时，可使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，返回 ISlideText 对象数组。每个对象表示相应幻灯片上的文本。ISlideText 对象具有以下属性：

ISlideText.Text - 幻灯片形状上的文本
ISlideText.MasterText - 此幻灯片所在母版页面形状上的文本
ISlideText.LayoutText - 此幻灯片所在布局页面形状上的文本
ISlideText.NotesText - 此幻灯片备注页面形状上的文本

还有实现 ISlideText 接口的 SlideText 类。

新 API 可按如下方式使用：

``` csharp
using System;
using Aspose.Slides;

// 提取文本时不考虑其在幻灯片上的位置（最快模式）。
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// 按幻灯片上的相同顺序提取文本。
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **已添加 ILegacyDiagram 接口和 LegacyDiagram 类**
已添加接口 Aspose.Slides.ILegacyDiagram 和类 Aspose.Slides.LegacyDiagram，用于表示传统图表对象。传统图表对象是 PowerPoint 97-2003 的旧格式图表。
新类提供将传统图表转换为现代可编辑 SmartArt 对象或可编辑 GroupShape 的方法。
#### **新增 Aspose.Slides.TextAlignment 枚举成员 (JustifyLow)**
向 TextAlignment 枚举添加了新成员：
JustifyLow - Kashida 低水平两端对齐。
#### **为 Aspose.Slides.IOleObjectFrame 和 OleObjectFrame 添加新属性**
向 IOleObjectFrame 接口和实现该接口的 OleObjectFrame 类添加了新属性。这些属性用于提供嵌入到演示文稿中的对象信息：
EmbeddedFileExtension - 返回当前嵌入对象的文件扩展名，如果对象不是链接则返回空字符串
EmbeddedFileLabel - 返回嵌入 OLE 对象的文件名
EmbeddedFileName - 返回嵌入 OLE 对象的路径
#### **在 IAxis 和 Axis 类中添加了新属性 CategoryAxisType**
属性 CategoryAxisType 指定类别轴的类型。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

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
#### **在 DataLabelFormat 类和 IDataLabelFormat 接口中添加了新属性 ShowLabelAsDataCallout**
属性 ShowLabelAsDataCallout 决定指定图表的数据标签是显示为数据标注还是显示为数据标签。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **在 PdfOptions 和 XpsOptions 中添加了属性 DrawSlidesFrame**
在 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 接口以及相关类 Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions 中添加了布尔属性 DrawSlidesFrame。
如果将此属性设为 true，将在每个幻灯片周围绘制黑色框架。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```