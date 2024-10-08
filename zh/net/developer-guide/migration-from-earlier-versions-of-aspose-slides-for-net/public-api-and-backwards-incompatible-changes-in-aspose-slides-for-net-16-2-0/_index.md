---
title: Aspose.Slides for .NET 16.2.0 的公共 API 和向后不兼容的更改
type: docs
weight: 230
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for .NET 16.2.0 API 中[添加](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)或[移除](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/)的类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
#### **属性 UpdateDateTimeFields 和 UpdateSlideNumberFields 已被移除**
属性 UpdateDateTimeFields 和 UpdateSlideNumberFields 已从 Aspose.Slides.Presentation 类和 Aspose.Slides.IPresentation 接口中移除。
Aspose.Slides.TextFrame、Paragraph、Portion 类以及 Aspose.Slides.ITextFrame、IParagraph、IPortion 接口的 Text 属性返回带有更新的 "datetime" 字段的文本。
此外，属性 Presentation.DocumentProperties.CreatedTime、LastSavedTime 和 LastPrinted 变为只读。
#### **枚举 Slides.Charts.CategoryAxisType 已切换为公共**
用于 IAxis.CategoryAxisType 和 Axis.CategoryAxisType 属性以确定类别轴类型。
CategoryAxisType.Auto - 类别轴类型将在序列化过程中自动确定（该行为目前尚未实现）
CategoryAxisType.Text - 类别轴类型为文本
CategoryAxisType.Date - 类别轴类型为日期时间
#### **快速文本提取**
已在 Presentation 类中添加新的静态方法 GetPresentationText。该方法有两个重载：

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode 枚举参数指示输出文本结果的组织模式，可以设置为以下值：
Unarranged - 原始文本不考虑在幻灯片上的位置
Arranged - 文本以与幻灯片相同的顺序定位

当速度至关重要时，可以使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 SlidesText 属性，返回 ISlideText 对象的数组。每个对象代表相应幻灯片上的文本。ISlideText 对象具有以下属性：

ISlideText.Text - 幻灯片形状上的文本
ISlideText.MasterText - 此幻灯片的母版页面形状上的文本
ISlideText.LayoutText - 此幻灯片的布局页面形状上的文本
ISlideText.NotesText - 此幻灯片的备注页面形状上的文本

还有一个 SlideText 类实现了 ISlideText 接口。

新的 API 可以像这样使用：

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **已添加 ILegacyDiagram 接口和 LegacyDiagram 类**
接口 Aspose.Slides.ILegacyDiagram 和类 Aspose.Slides.LegacyDiagram 已添加以表示旧版图表对象。旧版图表对象是 PowerPoint 97-2003 的旧格式图表。
新类提供了将旧版图表转换为现代可编辑 SmartArt 对象或可编辑 GroupShape 的方法。
#### **新增 Aspose.Slides.TextAlignment 枚举成员 (JustifyLow)**
添加了 TextAlignment 枚举的新成员：
JustifyLow - Kashida 低对齐。
#### **为 Aspose.Slides.IOleObjectFrame 和 OleObjectFrame 添加新属性**
为实现该接口的 IOleObjectFrame 接口和 OleObjectFrame 类添加了新属性。这些属性用于提供关于嵌入演示文稿中的对象的信息：
EmbeddedFileExtension - 返回当前嵌入对象的文件扩展名，或如果对象不是链接则返回空字符串
EmbeddedFileLabel - 返回嵌入 OLE 对象的文件名
EmbeddedFileName - 返回嵌入 OLE 对象的路径
#### **为 IAxis 和 Axis 类添加了新属性 CategoryAxisType**
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
#### **为 DataLabelFormat 类和 IDataLabelFormat 接口添加了新属性 ShowLabelAsDataCallout**
属性 ShowLabelAsDataCallout 确定指定的图表数据标签将作为数据调用显示还是作为数据标签显示。

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
#### **为 PdfOptions 和 XpsOptions 添加了 DrawSlidesFrame 属性**
布尔属性 DrawSlidesFrame 已添加到接口 Aspose.Slides.Export.IPdfOptions、Aspose.Slides.Export.IXpsOptions 以及相关类 Aspose.Slides.Export.PdfOptions、Aspose.Slides.Export.XpsOptions。
如果将此属性设置为 'true'，则会绘制每个幻灯片周围的黑色框。

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

``` 