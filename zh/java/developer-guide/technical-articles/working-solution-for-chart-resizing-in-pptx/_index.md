---
title: PPTX 中图表缩放的有效解决方案
type: docs
weight: 40
url: /zh/java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

经过观察，发现通过 Aspose 组件在 PowerPoint 演示文稿中嵌入的 Excel 图表在第一次激活后会缩放到未识别的比例。这种行为导致演示文稿在图表激活前后的视觉差异显著。Aspose 团队在 Microsoft 团队的帮助下对此问题进行了详细调查，并找到了该问题的解决方案。本文将介绍该问题的原因及解决方案。

{{% /alert %}} 
## **背景**
在 [上一篇文章](/slides/zh/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) 中，我们解释了如何使用 Aspose.Cells for Java 创建 Excel 图表，并进一步使用 Aspose.Slides for Java 将该图表嵌入到 PowerPoint 演示文稿中。为了解决 [对象变化问题](/slides/zh/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)，我们将图表图像分配给图表 OLE 对象框。在输出的演示文稿中，当我们双击显示图表图像的 OLE 对象框时，Excel 图表被激活。最终用户可以在实际的 Excel 工作簿中进行任何所需的更改，然后通过点击激活的 Excel 工作簿外的区域返回到相关幻灯片。用户返回幻灯片时，OLE 对象框的大小会发生变化。对于不同大小的 OLE 对象框和嵌入的 Excel 工作簿，缩放因子会有所不同。
## **缩放原因**
由于 Excel 工作簿具有自己的窗口大小，它在第一次激活时会尝试保留其原始大小。另一方面，OLE 对象框将具有自己的大小。根据微软的说法，在激活 Excel 工作簿时，Excel 和 PowerPoint 会协商大小，并确保它处于正确的比例，作为嵌入操作的一部分。由于 Excel 窗口大小和 OLE 对象框的大小/位置之间的差异，会发生缩放。
## **有效解决方案**
使用 Aspose.Slides for Java 创建 PowerPoint 演示文稿有两种可能的场景。**场景 1：**基于现有模板创建演示文稿**场景 2：**从头开始创建演示文稿。我们在这里提供的解决方案适用于这两种场景。所有解决方案方法的基础相同。即：**嵌入的 OLE 对象窗口大小应与 PowerPoint 幻灯片中的 OLE 对象框大小相同**。现在，我们将讨论该解决方案的两种方法。
## **第一种方法**
在此方法中，我们将学习如何将嵌入的 Excel 工作簿窗口大小设置为与 PowerPoint 幻灯片中 OLE 对象框的大小相等。**场景 1**假设我们定义了一个模板，并希望基于该模板创建演示文稿。假设模板中的索引 2 处有一个形状，我们希望在其中放置一个承载嵌入的 Excel 工作簿的 OLE 框。在此场景中，OLE 对象框的大小将被视为预定义的（即模板中索引 2 处形状的大小）。我们所要做的就是：将工作簿的窗口大小设置为与形状大小相等。以下代码片段将实现此目的：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}


**场景 2**
假设我们希望从头开始创建演示文稿，并希望拥有任何大小的 OLE 对象框和一个嵌入的 Excel 工作簿。在以下代码片段中，我们在幻灯片中创建了一个高度为 4 英寸、宽度为 9.5 英寸的 OLE 对象框，位置在 x 轴=0.5 英寸和 y 轴=1 英寸。此外，我们将等效的 Excel 工作簿窗口大小设置为：高度 4 英寸，宽度 9.5 英寸。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **第二种方法**
在此方法中，我们将学习如何将嵌入的 Excel 工作簿中存在的图表大小设置为与 PowerPoint 幻灯片中 OLE 对象框的大小相等。当图表的大小在前期已知并且将不会改变时，此方法非常有用。**场景 1**假设我们定义了一个模板，并希望基于该模板创建演示文稿。假设模板中的索引 2 处有一个形状，我们希望在其中放置一个承载嵌入的 Excel 工作簿的 OLE 框。在此场景中，OLE 框的大小将被视为预定义的（即模板中索引 2 处形状的大小）。我们所要做的就是：将工作簿中图表的大小设置为与形状的大小相等。以下代码片段将实现此目的：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**场景 2**：假设我们希望从头开始创建演示文稿，并希望拥有任何大小的 OLE 对象框和一个嵌入的 Excel 工作簿。在以下代码片段中，我们在幻灯片中创建了一个高度为 4 英寸、宽度为 9.5 英寸的 OLE 对象框，位置在 x 轴=0.5 英寸和 y 轴=1 英寸。此外，我们设置了等效的图表大小，即：高度 4 英寸，宽度 9.5 英寸。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **结论**
{{% alert color="primary" %}} 

修复图表缩放问题有两种方法。选择适当的方法取决于需求和用例。无论是从模板创建演示文稿还是从头创建，两个方法的工作方式相同。此外，解决方案中对 OLE 对象框的大小没有限制。

{{% /alert %}}