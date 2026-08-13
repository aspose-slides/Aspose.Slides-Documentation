---
title: 使用 VSTO 和 Aspose.Slides for Java 将 Excel 图表创建并嵌入为 OLE 对象
linktitle: 创建并嵌入 Excel 图表为 OLE 对象
type: docs
weight: 60
url: /zh/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 创建图表
- 嵌入 Excel 图表
- OLE 对象
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: 将 Microsoft Office 自动化迁移到 Aspose.Slides for Java，并在 Java 中将 Excel 图表嵌入为 OLE 对象到 PowerPoint (PPT, PPTX) 幻灯片。
---
{{% alert color="info" %}} 
图表是数据的可视化表示，广泛用于演示幻灯片。本文将展示如何使用[VSTO](/slides/zh/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)和[Aspose.Slides for Java](/slides/zh/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)通过编程方式在 PowerPoint 幻灯片中创建并嵌入 Excel 图表作为 OLE 对象的代码。
{{% /alert %}} 
## **创建并嵌入 Excel 图表**
下面的两个代码示例篇幅较长且详尽，因为它们描述的任务较为复杂。您需要创建一个 Microsoft Excel 工作簿，创建图表，然后创建要嵌入图表的 Microsoft PowerPoint 演示文稿。OLE 对象包含指向原始文档的链接，用户双击嵌入的文件时会启动该文件及其应用程序。
### **VSTO 示例**
使用 VSTO，执行以下步骤：

1. 创建 Microsoft Excel ApplicationClass 对象的实例。
1. 创建一个包含一个工作表的新工作簿。
1. 向工作表添加图表。
1. 保存工作簿。
1. 打开包含图表数据工作表的 Excel 工作簿。
1. 获取工作表的 ChartObjects 集合。
1. 获取要复制的图表。
1. 创建 Microsoft PowerPoint 演示文稿。
1. 向演示文稿添加空白幻灯片。
1. 将 Excel 工作表中的图表复制到剪贴板。
1. 将图表粘贴到 PowerPoint 演示文稿中。
1. 在幻灯片上定位图表。
1. 保存演示文稿。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java 示例**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 使用 Aspose.Cells for Java 创建工作簿。
1. 创建 Microsoft Excel 图表。
1. 设置 Excel 图表的 OLE 大小。
1. 获取图表的图像。
1. 使用 Aspose.Slides for Java 将 Excel 图表作为 OLE 对象嵌入 PPTX 演示文稿。
1. 用第 3 步获取的图像替换对象更改后产生的图像，以解决对象更改问题。
1. 将输出的演示文稿以 PPTX 格式写入磁盘。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}