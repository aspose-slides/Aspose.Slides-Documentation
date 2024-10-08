---
title: 在 Microsoft PowerPoint 演示文稿中创建图表
type: docs
weight: 70
url: /androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 图表是数据的可视化表示，广泛用于演示文稿。本文展示了如何通过使用 [VSTO](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) 和 [Aspose.Slides for Android via Java](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) 编程方式在 Microsoft PowerPoint 中创建图表的代码。

{{% /alert %}} 
## **创建图表**
以下代码示例描述了使用 VSTO 添加简单 3D 柱状图的过程。您需要创建一个演示文稿实例，向其中添加默认图表。然后使用 Microsoft Excel 工作簿访问并修改图表数据，并设置图表属性。最后，保存演示文稿。
### **VSTO 示例**
使用 VSTO 执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿中添加一张空白幻灯片。
1. 添加一个 **3D 柱状图** 并访问它。
1. 创建一个新的 Microsoft Excel 工作簿实例并加载图表数据。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 在工作表中设置图表范围，并从图表中删除系列 2 和 3。
1. 修改图表数据工作表中的图表类别数据。
1. 修改图表数据工作表中的图表系列 1 数据。
1. 现在，访问图表标题并设置字体相关属性。
1. 访问图表值轴并设置主要单位、次单位、最大值和最小值。
1. 访问图表深度轴或系列轴，并将其删除，因为在本示例中，仅使用一个系列。
1. 现在，在 X 和 Y 方向设置图表旋转角度。
1. 保存演示文稿。
1. 关闭 Microsoft Excel 和 PowerPoint 的实例。

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Android via Java 示例**
使用 Aspose.Slides for Android via Java 执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿实例。
1. 向演示文稿中添加一张空白幻灯片。
1. 添加一个 **3D 柱状图** 并访问它。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 删除未使用的系列 2 和 3。
1. 访问图表类别并修改标签。
1. 访问系列 1 并修改系列值。
1. 现在，访问图表标题并设置字体属性。
1. 访问图表值轴并设置主要单位、次单位、最大值和最小值。
1. 现在，在 X 和 Y 方向设置图表旋转角度。
1. 将演示文稿保存为 PPTX 格式。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}