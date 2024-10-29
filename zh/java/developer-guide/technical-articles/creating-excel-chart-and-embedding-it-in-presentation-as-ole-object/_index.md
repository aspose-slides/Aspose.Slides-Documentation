---
title: 创建 Excel 图表并将其嵌入为 OLE 对象
type: docs
weight: 30
url: /zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

在 PowerPoint 幻灯片中，使用可编辑的图表来图形化显示数据是一项常见活动。Aspose 提供了使用 Aspose.Cells for Java 创建 Excel 图表的支持，并且这些图表可以通过 Aspose.Slides for Java 嵌入为 PowerPoint 幻灯片中的 OLE 对象。本文涵盖了所需的步骤，以及在 Java 中的实现，以使用 Aspose.Cells for Java 和 Aspose.Slides for Java 创建并嵌入 MS Excel 图表作为 PowerPoint 演示文稿中的 OLE 对象。

{{% /alert %}} 
## **所需步骤**
以下步骤的顺序是将 Excel 图表作为 OLE 对象创建并嵌入到 PowerPoint 幻灯片中的必要步骤：# 使用 Aspose.Cells for Java 创建 Excel 图表。# 使用 Aspose.Cells for Java 设置 Excel 图表的 OLE 大小。# 使用 Aspose.Cells for Java 获取 Excel 图表的图像。# 使用 Aspose.Slides for Java 将 Excel 图表嵌入 PPTX 演示文稿中作为 OLE 对象。# 替换步骤 3 中获得的图像以解决对象更改问题# 将输出演示文稿保存到磁盘，格式为 PPTX
## **所需步骤的实现**
上述步骤在 Java 中的实现如下：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

通过上述方法创建的演示文稿将包含 Excel 图表作为 OLE 对象，可以通过双击 OLE 对象框进行激活。

{{% /alert %}} 
## **结论**
{{% alert color="primary" %}} 

通过使用 Aspose.Cells for Java 和 Aspose.Slides for Java，我们可以创建由 Aspose.Cells for Java 支持的任何 Excel 图表，并将创建的图表作为 OLE 对象嵌入到 PowerPoint 幻灯片中。Excel 图表的 OLE 大小也可以定义。最终用户可以像编辑其他任何 OLE 对象一样进一步编辑 Excel 图表。

{{% /alert %}} 
## **相关部分**
[图表调整大小的工作解决方案](/slides/zh/java/working-solution-for-chart-resizing-in-pptx/)

[对象更改问题](/slides/zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)