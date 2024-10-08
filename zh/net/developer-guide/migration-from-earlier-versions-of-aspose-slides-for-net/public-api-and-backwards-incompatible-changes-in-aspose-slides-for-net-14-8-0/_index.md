---
title: Aspose.Slides for .NET 14.8.0 的公共 API 和向后不兼容的更改
type: docs
weight: 100
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
---

{{% alert color="primary" %}} 

此页面列出了所有在 Aspose.Slides for .NET 14.8.0 API 中[添加的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)或[移除的](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/)类、方法、属性等，以及其他更改。

{{% /alert %}} 
## **公共 API 更改**
### **更改的属性**
#### **添加了 IVbaProject 接口，更改了 Presentation.VbaProject 属性**
Presentation 类的 VbaProject 属性已被替换。原本的 VbaProject 属性的 VBA 项目的原始字节表示，现已添加新的 IVbaProject 接口实现。

使用 IVbaProject 属性来管理嵌入演示文稿中的 VBA 项目。您可以添加新的项目引用，编辑现有模块并创建新模块。

此外，您可以使用实现 IVbaProject 接口的 VbaProject 类创建新的 VBA 项目。

以下示例显示了创建一个包含一个模块的简单 VBA 项目并向库中添加两个所需引用的过程。

``` csharp

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

此示例显示了如何将现有演示文稿中的 VBA 项目复制到新的演示文稿中。

``` csharp

 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}

``` 
### **添加的接口、属性和枚举选项**
#### **添加了 Aspose.Slides.Charts.IChartSeries.Overlap 属性**
Aspose.Slides.Charts.IChartSeries.Overlap 属性指定了在 2D 图表上条形图和柱形图的重叠程度（范围从 -100 到 100）。

该属性不仅是此系列的属性，还是父系列组中所有系列的属性 - 这是相关组属性的投影。因此，此属性为只读。

- 使用 ParentSeriesGroup 属性访问父系列组。
- 使用 ParentSeriesGroup.Overlap 读/写属性更改值。

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
Aspose.Slides.Charts.IChartSeriesGroup.Overlap 属性指定了在 2D 图表上条形图和柱形图应重叠的程度（范围从 -100 到 100）。

``` csharp



using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}

``` 
#### **添加了 ShapeThumbnailBounds.Appearance 枚举值**
这种形状缩略图创建方法允许您生成形状外观范围内的缩略图。它考虑了所有形状效果。生成的形状缩略图受到幻灯片边界的限制。

``` csharp



using (Presentation p = new Presentation("Presentation.pptx"))

{

    Bitmap st = p.Slides[0].Shapes[0].GetThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

    st.Save("ShapeThumbnail.png", ImageFormat.Png);

}

``` 