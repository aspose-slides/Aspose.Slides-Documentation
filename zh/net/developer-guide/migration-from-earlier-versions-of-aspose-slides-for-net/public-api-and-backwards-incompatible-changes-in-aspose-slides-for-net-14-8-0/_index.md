---
title: Aspose.Slides for .NET 14.8.0 的公共 API 和向后不兼容的更改
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
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
description: "回顾 Aspose.Slides for .NET 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 
此页面列出了所有[已添加](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)或[已移除](/slides/zh/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)的类、方法、属性等，以及在 Aspose.Slides for .NET 14.8.0 API 中引入的其他更改。
{{% /alert %}} 
## **公共 API 更改**
### **已更改的属性**
#### **添加了 IVbaProject 接口， 更改了 Presentation.VbaProject 属性**
Presentation 类的 VbaProject 属性已被替换。原先的 VbaProject 属性的原始字节表示已被新的 IVbaProject 接口实现所取代。

使用 IVbaProject 属性来管理嵌入演示文稿中的 VBA 项目。您可以添加新的项目引用，编辑现有模块并创建新模块。

此外，您可以使用实现 IVbaProject 接口的 VbaProject 类来创建新的 VBA 项目。

下面的示例展示了创建一个包含一个模块并向库添加两个必需引用的简单 VBA 项目。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // 创建新的 VBA 项目
    pres.VbaProject = new VbaProject();

    // 向 VBA 项目添加空模块
    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // 设置模块源代码
    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // 创建对 <stdole> 的引用
    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // 创建对 Office 的引用
    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // 向 VBA 项目添加引用
    pres.VbaProject.References.Add(stdoleReference);
    pres.VbaProject.References.Add(officeReference);
    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

此示例展示了如何将 VBA 项目从现有演示文稿复制到新演示文稿。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **已添加接口、属性和枚举选项**
#### **添加了 Aspose.Slides.Charts.IChartSeries.Overlap 属性**
Aspose.Slides.Charts.IChartSeries.Overlap 属性指定在二维图表中柱形和条形的重叠程度（范围为 -100 到 100）。

该属性不仅适用于此系列，还适用于父系列组中的所有系列——它是相应组属性的投影。因此该属性为只读。

- 使用 ParentSeriesGroup 属性访问父系列组。
- 使用 ParentSeriesGroup.Overlap 可读写属性更改值。

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


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
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **添加了 ShapeThumbnailBounds.Appearance 枚举值**
此形状缩略图创建方法允许在其外观范围内生成形状缩略图。它会考虑所有形状效果。生成的形状缩略图受幻灯片边界的限制。

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```