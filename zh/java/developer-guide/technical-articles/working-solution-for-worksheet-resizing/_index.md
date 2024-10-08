---
title: 工作表调整大小的解决方案
type: docs
weight: 20
url: /zh/java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

我们观察到，通过Aspose组件嵌入到PowerPoint演示文稿中的Excel工作表在第一次激活后会缩放到未定义的比例。此行为在图表激活前后创建了一个显著的视觉差异。我们对此问题进行了详细调查，并找到了在本文中介绍的解决方案。

{{% /alert %}} 
## **背景**
在[添加OLE框架的文章]()中，我们解释了如何使用Aspose.Slides for Java在PowerPoint演示文稿中添加OLE框架。为了处理[对象更改问题](/slides/zh/java/object-changed-issue-when-adding-oleobjectframe/)，我们将所选区域的工作表图像分配给图表OLE对象框架。在输出的演示文稿中，当我们双击显示工作表图像的OLE对象框架时，Excel图表会被激活。最终用户可以对实际的Excel工作簿进行任何所需的更改，然后通过点击激活的Excel工作簿外部返回到相关幻灯片。当用户返回到幻灯片时，OLE对象框架的大小会发生变化。对于不同大小的OLE对象框架和嵌入的Excel工作簿，调整大小的因素将是不同的。
## **调整大小的原因**
由于Excel工作簿具有自己的窗口大小，它会尝试在第一次激活时保持其原始大小。另一方面，OLE对象框架将有其自己的大小。根据微软的说法，在激活Excel工作簿时，Excel和PowerPoint会协商大小，并确保它按照嵌入操作的要求保持正确比例。根据Excel窗口的大小与OLE对象框架的大小/位置之间的差异，将发生调整大小。
## **解决方案**
有两种可能的解决方案来避免重新调整大小的效果。* 缩放PPT中的OLE框架大小，以匹配OLE框架中所需行/列数量的高度/宽度大小* 保持OLE框架大小不变，并缩放参与行/列的大小，以适应所选择的OLE框架大小
## **将OLE框架大小缩放到工作表的所选行/列大小**
在这种方法中，我们将学习如何将嵌入的Excel工作簿的OLE框架大小设置为参与的行和列的累积大小。
## **示例**
假设我们定义了一个模板Excel工作表，并希望将其作为OLE框架添加到演示文稿中。在这种情况下，OLE对象框架的大小将首先基于参与工作簿的行和列的累积高度和宽度进行计算。然后，我们将OLE框架的大小设置为该计算值。为了避免PowerPoint中OLE框架的红色**嵌入对象**消息，我们还将获取工作簿中所需行和列的图像，并将其设置为OLE框架的图像。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}






## **根据OLE框架大小缩放工作表的行高和列宽**
在这种方法中，我们将学习如何根据自定义设置的OLE框架大小缩放参与行的高度和参与列的宽度。
## **示例**
假设我们定义了一个模板Excel工作表，并希望将其作为OLE框架添加到演示文稿中。在这种情况下，我们将设置OLE框架的大小，并缩放参与OLE框架区域的行和列的大小。然后，我们将在流中保存工作簿以保存更改，并将其转换为字节数组以添加到OLE框架中。为了避免在PowerPoint中OLE框架的红色**嵌入对象**消息，我们还将获取工作簿中所需行和列的图像，并将其设置为OLE框架的图像。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **结论**
{{% alert color="primary" %}} 

有两种方法可以解决工作表调整大小的问题。选择适当的方法取决于需求和用例。无论演示文稿是从模板创建还是从头开始创建，这两种方法的工作方式是相同的。此外，解决方案中对OLE对象框架的大小没有限制。

{{% /alert %}}