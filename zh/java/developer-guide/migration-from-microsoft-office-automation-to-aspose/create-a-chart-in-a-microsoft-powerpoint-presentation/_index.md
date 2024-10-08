---
title: 在 Microsoft PowerPoint 演示文稿中创建图表
type: docs
weight: 70
url: /java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 图表是数据的视觉表示，广泛用于演示文稿。本文展示了如何通过使用 [VSTO](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 和 [Aspose.Slides for Java](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 来以编程方式在 Microsoft PowerPoint 中创建图表的代码。

{{% /alert %}} 
## **创建图表**
下面的代码示例描述了使用 VSTO 添加简单的 3D 集群柱状图的过程。您创建一个演示实例，向其添加一个默认图表。然后使用 Microsoft Excel 工作簿访问和修改图表数据，并设置图表属性。最后，保存演示文稿。
### **VSTO 示例**
使用 VSTO 时，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿的实例。
1. 向演示文稿添加一张空白幻灯片。
1. 添加一个 **3D 集群柱状** 图表并访问它。
1. 创建一个新的 Microsoft Excel 工作簿实例并加载图表数据。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 在工作表中设置图表范围，并从图表中移除系列 2 和 3。
1. 修改图表数据工作表中的图表类别数据。
1. 修改图表数据工作表中的系列 1 数据。
1. 现在，访问图表标题并设置字体相关属性。
1. 访问图表数值轴并设置主要单位、次要单位、最大值和最小值。
1. 访问图表深度或系列轴并将其移除，因为在该示例中仅使用了一个系列。
1. 现在，设置图表在 X 和 Y 方向上的旋转角度。
1. 保存演示文稿。
1. 关闭 Microsoft Excel 和 PowerPoint 的实例。

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java 示例**
使用 Aspose.Slides for Java 时，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿的实例。
1. 向演示文稿添加一张空白幻灯片。
1. 添加一个 **3D 集群柱状** 图表并访问它。
1. 使用 Microsoft Excel 工作簿实例访问图表数据工作表。
1. 移除未使用的系列 2 和 3。
1. 访问图表类别并修改标签。
1. 访问系列 1 并修改系列值。
1. 现在，访问图表标题并设置字体属性。
1. 访问图表数值轴并设置主要单位、次要单位、最大值和最小值。
1. 现在，设置图表在 X 和 Y 方向上的旋转角度。
1. 将演示文稿保存为 PPTX 格式。

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}