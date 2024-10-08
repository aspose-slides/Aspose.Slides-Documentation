---
title: 创建并将Excel图表嵌入到Microsoft PowerPoint幻灯片中的OLE对象
type: docs
weight: 60
url: /php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 图表是数据的直观表示，广泛应用于演示幻灯片中。本文将向您展示如何通过使用[VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)和[Aspose.Slides for PHP via Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)以编程方式创建并将Excel图表作为OLE对象嵌入到PowerPoint幻灯片中。

{{% /alert %}} 
## **创建并嵌入Excel图表**
下面的两个代码示例较长且详细，因为它们描述的任务比较复杂。您需要创建一个Microsoft Excel工作簿，创建一个图表，然后创建一个将嵌入图表的Microsoft PowerPoint演示文稿。OLE对象包含指向原始文档的链接，因此用户双击嵌入的文件会启动该文件及其应用程序。
### **VSTO示例**
使用VSTO，执行以下步骤：

1. 创建Microsoft Excel ApplicationClass对象的实例。
1. 创建一个包含一个工作表的新工作簿。
1. 向工作表添加图表。
1. 保存工作簿。
1. 打开包含图表数据的工作表的Excel工作簿。
1. 获取工作表的ChartObjects集合。
1. 获取要复制的图表。
1. 创建Microsoft PowerPoint演示文稿。
1. 向演示文稿添加一个空白幻灯片。
1. 从Excel工作表复制图表到剪贴板。
1. 将图表粘贴到PowerPoint演示文稿中。
1. 在幻灯片上定位图表。
1. 保存演示文稿。

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **通过Java使用Aspose.Slides for PHP示例**
使用Aspose.Slides for .NET，执行以下步骤：

1. 使用Aspose.Cells for Java创建工作簿。
1. 创建Microsoft Excel图表。
1. 设置Excel图表的OLE大小。
1. 获取图表的图像。
1. 使用Aspose.Slides for PHP via Java将Excel图表作为OLE对象嵌入到PPTX演示文稿中。
1. 将对象更改后的图像替换为步骤3获得的图像，以处理对象更改问题。
1. 将输出演示文稿以PPTX格式写入磁盘。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}