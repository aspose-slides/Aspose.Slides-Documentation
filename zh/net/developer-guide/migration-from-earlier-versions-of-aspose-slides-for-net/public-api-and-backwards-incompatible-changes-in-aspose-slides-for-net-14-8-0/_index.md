---
title: Aspose.Slides for .NET 14.8.0 中的公共 API 与向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- 迁移
- 传统代码
- 现代代码
- 传统方法
- 现代方法
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "审查 Aspose.Slides for .NET 中的公共 API 更新和破坏性更改，以平稳迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---

{{% alert color="primary" %}} 

此页面列出了所有[added](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)或[removed](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)的类、方法、属性等，以及 Aspose.Slides for .NET 14.8.0 API 引入的其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **已更改的属性**
#### **添加了 IVbaProject 接口，修改了 Presentation.VbaProject 属性**
Presentation 类的 VbaProject 属性已被替换。原先 VbaProject 属性返回 VBA 项目的原始字节表示，现在已添加新的 IVbaProject 接口实现。

使用 IVbaProject 属性来管理嵌入在演示文稿中的 VBA 项目。您可以添加新的项目引用，编辑现有模块并创建新模块。

此外，您也可以使用实现了 IVbaProject 接口的 VbaProject 类创建新的 VBA 项目。

以下示例展示了创建一个包含一个模块的简单 VBA 项目，并向库添加两个必需的引用。

``` csharp

 using (Presentation pres = new Presentation())

{

    // Create new VBA Project

    pres.VbaProject = new VbaProject();

    // Add empty module to the VBA project

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // Set module source code

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // Create reference to <stdole>

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Create reference to Office

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Add references to the VBA project

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}

``` 

此示例展示了如何将已有演示文稿中的 VBA 项目复制到新演示文稿中。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **添加的接口、属性和枚举选项**
#### **添加了 Aspose.Slides.Charts.IChartSeries.Overlap 属性**
Aspose.Slides.Charts.IChartSeries.Overlap 属性指定在二维图表中柱形和条形的重叠程度（范围为 -100 到 100）。

该属性不仅适用于当前系列，还适用于父系列组中的所有系列——它是相应组属性的投影。因此此属性为只读。

- 使用 ParentSeriesGroup 属性访问父系列组。
- 使用 ParentSeriesGroup.Overlap 可读写属性来更改值。

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}

``` 
#### **添加了 Aspose.Slides.Charts.IChartSeriesGroup.Overlap 属性**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap 属性指定在二维图表中柱形和条形的重叠程度（范围为 -100 到 100）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **添加了 ShapeThumbnailBounds.Appearance 枚举值**
此形状缩略图创建方法允许在形状外观的边界内生成缩略图。它会考虑所有形状效果，生成的缩略图受幻灯片边界限制。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

```