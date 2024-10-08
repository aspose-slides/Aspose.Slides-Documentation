---
title: PPTX中图表自适应大小的有效解决方案
type: docs
weight: 40
url: /php-java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

我们观察到，通过Aspose组件在PowerPoint演示文稿中嵌入的Excel图表在第一次激活后被调整为未知的比例。这一行为在图表激活前后造成了演示文稿的显著视觉差异。Aspose团队在微软团队的帮助下详细调查了此问题，并找到了其解决方案。本文将涵盖导致此问题的原因及其解决方案。

{{% /alert %}} 
## **背景**
在[上一篇文章](/slides/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)中，我们解释了如何使用Aspose.Cells for Java创建Excel图表，并通过Java使用Aspose.Slides for PHP将该图表嵌入PowerPoint演示文稿。为了兼容[对象更改问题](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)，我们将图表图像分配给图表OLE对象框。在输出的演示文稿中，当我们双击显示图表图像的OLE对象框时，Excel图表被激活。最终用户可以在实际的Excel工作簿中进行任何所需的更改，然后通过单击激活的Excel工作簿外部返回到相关幻灯片。当用户返回到幻灯片时，OLE对象框的大小将发生变化。不同大小的OLE对象框和嵌入的Excel工作簿的缩放因子将是不同的。
## **调整大小的原因**
由于Excel工作簿具有自己的窗口大小，它试图在第一次激活时保持原始大小。另一方面，OLE对象框将具有其自己的大小。根据微软的说法，在激活Excel工作簿时，Excel和PowerPoint会协商大小，并确保其在嵌入操作中保持正确的比例。根据Excel窗口大小与OLE对象框大小/位置之间的差异，调整大小就会发生。
## **有效解决方案**
使用Aspose.Slides for PHP通过Java创建PowerPoint演示文稿有两种可能的场景。**场景1：** 基于现有模板创建演示文稿**场景2：** 从头开始创建演示文稿。我们在这里提供的解决方案对这两种场景都是有效的。所有解决方案方法的基础将是相同的。也就是说：**嵌入的OLE对象窗口大小应与PowerPoint幻灯片中的OLE对象框大小相同**。现在，我们将讨论解决方案的两种方法。
## **第一种方法**
在此方法中，我们将学习如何将嵌入的Excel工作簿的窗口大小设置为与PowerPoint幻灯片中的OLE对象框大小相等。**场景1**假设我们定义了一个模板，并希望基于该模板创建演示文稿。假设在模板的索引2处有一个形状，我们希望放置一个承载嵌入Excel工作簿的OLE框。在这种情况下，OLE对象框的大小将被视为预定义（即模板中索引2处形状的大小）。我们需要做的就是将工作簿的窗口大小设置为与形状的大小相等。以下代码片段将服务于此目的：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**场景2**假设我们希望从头开始创建演示文稿，并希望具有任意大小的OLE对象框和嵌入的Excel工作簿。在以下代码片段中，我们在x轴=0.5英寸和y轴=1英寸的幻灯片中创建了一个高4英寸、宽9.5英寸的OLE对象框。此外，我们还设置了相应的Excel工作簿窗口大小，即：高度4英寸，宽度9.5英寸。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}

## **第二种方法**
在此方法中，我们将学习如何将嵌入Excel工作簿中图表的大小设置为与PowerPoint幻灯片中的OLE对象框相等的大小。当图表的大小事先已知且永远不会改变时，这种方法非常有用。**场景1**假设我们定义了一个模板，并希望基于该模板创建演示文稿。假设在模板的索引2处有一个形状，我们希望放置一个承载嵌入Excel工作簿的OLE框。在这种情况下，OLE框的大小将被视为预定义（即模板中索引2处形状的大小）。我们需要做的就是将工作簿中的图表大小设置为与形状的大小相等。以下代码片段将服务于此目的：

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**场景2**假设我们希望从头开始创建演示文稿，并希望具有任意大小的OLE对象框和嵌入的Excel工作簿。在以下代码片段中，我们在x轴=0.5英寸和y轴=1英寸的幻灯片中创建了一个高4英寸、宽9.5英寸的OLE对象框。此外，我们还设置了相应的图表大小，即：高度4英寸，宽度9.5英寸。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **结论**
{{% alert color="primary" %}} 

有两种方法可以解决图表调整大小的问题。选择适当方法的依据取决于需求和使用案例。无论演示文稿是从模板创建还是从头开始创建，这两种方法都以相同方式工作。此外，解决方案中没有OLE对象框大小的限制。

{{% /alert %}}