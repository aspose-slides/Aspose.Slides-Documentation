---
title: 创建并将 Excel 图表作为 OLE 对象嵌入到 Microsoft PowerPoint 幻灯片中
type: docs
weight: 60
url: /zh/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 图表是您数据的可视化表示，广泛用于演示文稿幻灯片。本文将向您展示如何通过使用 [VSTO](/slides/zh/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 和 [Aspose.Slides for Android via Java](/slides/zh/androidjava/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) 以编程方式创建并将 Excel 图表作为 OLE 对象嵌入到 PowerPoint 幻灯片中的代码。

{{% /alert %}} 
## **创建并嵌入 Excel 图表**
下面的两个代码示例比较长且详细，因为它们描述的任务相对复杂。您将创建一个 Microsoft Excel 工作簿，创建一个图表，然后创建您将图表嵌入其中的 Microsoft PowerPoint 演示文稿。OLE 对象包含指向原始文档的链接，因此双击嵌入文件的用户会打开该文件及其应用程序。
### **VSTO 示例**
使用 VSTO，执行以下步骤：

1. 创建 Microsoft Excel ApplicationClass 对象的实例。
1. 创建一个包含一个工作表的新工作簿。
1. 向工作表添加图表。
1. 保存工作簿。
1. 打开包含图表数据的工作表的 Excel 工作簿。
1. 获取工作表的 ChartObjects 集合。
1. 获取要复制的图表。
1. 创建一个 Microsoft PowerPoint 演示文稿。
1. 向演示文稿添加一个空白幻灯片。
1. 将 Excel 工作表中的图表复制到剪贴板。
1. 将图表粘贴到 PowerPoint 演示文稿中。
1. 将图表放置在幻灯片上。
1. 保存演示文稿。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Android via Java 示例**
使用 Aspose.Slides for .NET，执行以下步骤：

1. 使用 Aspose.Cells for Java 创建一个工作簿。
1. 创建一个 Microsoft Excel 图表。
1. 设置 Excel 图表的 OLE 大小。
1. 获取图表的图像。
1. 使用 Aspose.Slides for Android via Java 将 Excel 图表作为 OLE 对象嵌入到 PPTX 演示文稿中。
1. 将步骤 3 中获取的图像替换更改对象的图像，以解决对象更改问题。
1. 将输出演示文稿以 PPTX 格式写入磁盘。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}