---
title: Aspose.Slides for Java 14.8.0 中的公共 API 及向后不兼容的更改
linktitle: Aspose.Slides for Java 14.8.0
type: docs
weight: 70
url: /zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- 迁移
- "旧版代码"
- "现代代码"
- "旧版方法"
- "现代方法"
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "审阅 Aspose.Slides for Java 的公共 API 更新和破坏性更改，以顺利迁移您的 PowerPoint PPT、PPTX 和 ODP 演示文稿解决方案。"
---
{{% alert color="info" %}} 
此页面列出所有[已添加](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)类、方法、属性等，以及随 Aspose.Slides for Java 14.8.0 API 引入的任何新限制和其他[更改](/slides/zh/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)。
{{% /alert %}} 
## **公共 API 更改**
### **添加了 Aspose.Slides.Charts.IChartSeries.getOverlap()、IChartSeriesGroup.getOverlap() 和 setOverlap(byte) 方法**
Aspose.Slides.Charts.IChartSeries.getOverlap() 获取柱形和条形在二维图表上的重叠程度（范围为 -100 到 100）。
此方法不仅适用于特定系列，而是适用于父系列组的所有系列——它是相应组属性的投影。

- 使用 IChartSeries.getParentSeriesGroup() 方法访问父系列组。
- 使用 IChartSeriesGroup.getOverlap() 和 setOverlap(byte) 方法来管理该值。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);

}

```
### **添加了 ShapeThumbnailBounds.Appearance 枚举值**
此创建形状缩略图的方法允许开发人员在其外观的边界内生成形状缩略图。它考虑了所有形状效果。生成的形状缩略图受幻灯片边界限制。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("Presentation.pptx");

IImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **添加了 VbaProject 类和 IVbaProject 接口，修改了 Presentation.getVbaProject() 和 setVbaProject(VbaProject) 方法**
此新功能允许开发人员在演示文稿中创建和编辑 VBA 项目。

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

// 创建新的 VBA 项目

pres.setVbaProject(new VbaProject());

// 向 VBA 项目添加空模块

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// 设置模块源代码

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// 创建对 <stdole> 的引用

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// 创建对 Office 的引用

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// 向 VBA 项目添加引用

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("test.pptm", SaveFormat.Pptm);
```