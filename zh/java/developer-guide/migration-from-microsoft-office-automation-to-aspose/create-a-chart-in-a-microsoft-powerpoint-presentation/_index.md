---
title: 使用 VSTO 和 Aspose.Slides for Java 创建图表
linktitle: 创建图表
type: docs
weight: 70
url: /zh/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 创建图表
- 迁移
- VSTO
- Office 自动化
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Java 中自动化 PowerPoint 图表创建。此分步指南展示了 Aspose.Slides for Java 相较于 Microsoft.Office.Interop 更快、更强大的优势。"
---
{{% alert color="info" %}} 

 图表是对数据的可视化呈现，广泛用于演示文稿。本文展示了使用 [VSTO](/slides/zh/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 和 [Aspose.Slides for Java](/slides/zh/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 以编程方式在 Microsoft PowerPoint 中创建图表的代码。

{{% /alert %}} 
## **创建图表**
下面的代码示例描述了使用 VSTO 添加简单 3D 组合柱形图的过程。您会创建一个演示文稿实例，向其中添加默认图表。然后使用 Microsoft Excel 工作簿访问并修改图表数据以及设置图表属性。最后，保存演示文稿。
### **VSTO 示例**
使用 VSTO，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿的实例。  
2. 向演示文稿中添加一个空白幻灯片。  
3. 添加一个 **3D 组合柱形** 图表并访问它。  
4. 创建一个新的 Microsoft Excel Workbook 实例并加载图表数据。  
5. 使用 Microsoft Excel Workbook 实例 `fromworkbook` 访问图表数据工作表。  
6. 在工作表中设置图表范围并从图表中删除第 2 和第 3 系列。  
7. 在图表数据工作表中修改图表分类数据。  
8. 在图表数据工作表中修改图表系列 1 的数据。  
9. 现在，访问图表标题并设置字体相关属性。  
10. 访问图表值轴并设置主单位、次单位、最大值和最小值。  
11. 访问图表深度或系列轴并将其删除，因为本示例仅使用一个系列。  
12. 现在，设置图表在 X 方向和 Y 方向的旋转角度。  
13. 保存演示文稿。  
14. 关闭 Microsoft Excel 和 PowerPoint 的实例。  

**使用 VSTO 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java 示例**
使用 Aspose.Slides for Java，执行以下步骤：

1. 创建一个 Microsoft PowerPoint 演示文稿的实例。  
2. 向演示文稿中添加一个空白幻灯片。  
3. 添加一个 **3D 组合柱形** 图表并访问它。  
4. 使用 Microsoft Excel Workbook 实例 `fromworkbook` 访问图表数据工作表。  
5. 删除未使用的第 2 和第 3 系列。  
6. 访问图表分类并修改标签。  
7. 访问系列 1 并修改系列值。  
8. 现在，访问图表标题并设置字体属性。  
9. 访问图表值轴并设置主单位、次单位、最大值和最小值。  
10. 现在，设置图表在 X 方向和 Y 方向的旋转角度。  
11. 将演示文稿保存为 PPTX 格式。  

**使用 Aspose.Slides 创建的输出演示文稿** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **常见问题**

### 我可以使用 Aspose.Slides 创建其他类型的图表，如饼图、折线图或条形图吗？

可以。Aspose.Slides 支持广泛的[图表类型](/slides/zh/java/create-chart/)，包括饼图、折线图、条形图、散点图、气泡图等。添加图表时可以使用 [ChartType](https://reference.aspose.com/slides/zh/java/com.aspose.slides/charttype/) 类指定所需的图表类型。

### 我可以为图表应用自定义样式或主题吗？

可以。您可以完全自定义图表的外观，包括颜色、字体、填充、轮廓、网格线和布局。不过，要完全复现 PowerPoint 中的 Office 主题，需要手动设置各项样式。

### 我能将图表单独导出为图像吗？

可以，Aspose.Slides 允许您使用图表[shape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/shape/)上的 `getImage` 方法，将任何形状（包括图表）导出为单独的图像（例如 PNG、JPEG）。