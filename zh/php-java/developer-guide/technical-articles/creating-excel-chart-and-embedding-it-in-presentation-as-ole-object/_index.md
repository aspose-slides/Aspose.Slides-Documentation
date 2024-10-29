---
title: 创建 Excel 图表并将其嵌入演示文稿作为 OLE 对象
type: docs
weight: 30
url: /zh/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

在 PowerPoint 幻灯片中，使用可编辑图表图形化展示数据是一项常见活动。Aspose 提供了使用 Aspose.Cells for Java 创建 Excel 图表的支持，并且可以通过 Java 的 Aspose.Slides for PHP 将这些图表嵌入为 PowerPoint 幻灯片中的 OLE 对象。本文涵盖了使用 Aspose.Cells for Java 和通过 Java 的 Aspose.Slides for PHP 将 MS Excel 图表作为 OLE 对象创建和嵌入到 PowerPoint 演示文稿中的必要步骤和实现。

{{% /alert %}} 
## **必要步骤**
以下步骤顺序是将 Excel 图表创建并嵌入为 PowerPoint 幻灯片中的 OLE 对象所需的：# 使用 Aspose.Cells for Java 创建 Excel 图表。# 使用 Aspose.Cells for Java 设置 Excel 图表的 OLE 大小。# 使用 Aspose.Cells for Java 获取 Excel 图表的图像。# 使用通过 Java 的 Aspose.Slides for PHP 将 Excel 图表嵌入为 PPTX 演示文稿中的 OLE 对象。# 用步骤 3 获取的图像替换对象更改的图像以解决对象更改问题。# 将输出演示文稿以 PPTX 格式保存到磁盘。
## **必要步骤的实现**
上述步骤的实现如下：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

通过上述方法创建的演示文稿将携带 Excel 图表作为 OLE 对象，可以通过双击 OLE 对象框来激活。

{{% /alert %}} 
## **结论**
{{% alert color="primary" %}} 

通过使用 Aspose.Cells for Java 以及通过 Java 的 Aspose.Slides for PHP，我们可以创建任何由 Aspose.Cells for Java 支持的 Excel 图表，并将创建的图表嵌入到 PowerPoint 幻灯片中作为 OLE 对象。Excel 图表的 OLE 大小也可以定义。最终用户可以像编辑其他 OLE 对象一样进一步编辑 Excel 图表。

{{% /alert %}} 
## **相关部分**
[图表调整大小的工作解决方案](/slides/zh/php-java/working-solution-for-chart-resizing-in-pptx/)

[对象更改问题](/slides/zh/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)