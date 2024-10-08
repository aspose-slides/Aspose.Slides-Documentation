---
title: 工作表调整大小的有效解决方案
type: docs
weight: 20
url: /php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

已观察到，通过 Aspose 组件在 PowerPoint 演示文稿中嵌入为 OLE 的 Excel 工作表在第一次激活后被调整为未知比例。此行为导致演示文稿在图表激活前后的视觉差异显著。我们对这个问题进行了详细调查，并找到了本文所涵盖的解决方案。

{{% /alert %}} 
## **背景**
在 [添加 Ole 框架文章]() 中，我们解释了如何使用 Aspose.Slides for PHP via Java 在 PowerPoint 演示文稿中添加 Ole 框架。为了适应 [对象改变问题](/slides/php-java/object-changed-issue-when-adding-oleobjectframe/)，我们将选定区域的工作表图像分配给图表 OLE 对象框。在输出演示文稿中，当我们双击显示工作表图像的 OLE 对象框时，Excel 图表被激活。最终用户可以在实际的 Excel 工作簿中进行任何所需的更改，然后通过点击激活的 Excel 工作簿外部返回到相关幻灯片。当用户返回幻灯片时，OLE 对象框的大小会发生变化。对于不同大小的 OLE 对象框和嵌入的 Excel 工作簿，调整大小的因子将会不同。
## **调整大小的原因**
由于 Excel 工作簿具有其自己的窗口大小，它在第一次激活时会尝试保持原始大小。另一方面，OLE 对象框会有其自己的大小。根据微软的说法，在激活 Excel 工作簿时，Excel 和 PowerPoint 会协商大小，并确保它在嵌入操作中处于正确的比例。根据 Excel 窗口大小与 OLE 对象框大小/位置的差异，会发生调整大小。
## **有效解决方案**
避免重新调整大小效果有两种可能的解决方案。* 将 PPT 中的 Ole 框架大小调整为与 Ole 框架中所需行/列的高度/宽度相匹配* 保持 Ole 框架大小不变，调整参与的行/列的大小以适应所选的 Ole 框架大小
## **将 Ole 框架大小调整为工作表选定行/列的大小**
在此方法中，我们将学习如何将嵌入的 Excel 工作簿的 Ole 框架大小设置为参与的行和列在 Excel 工作表中累积的大小。
## **示例**
假设，我们定义了一个模板 Excel 工作表，并希望将其作为 Ole 框架添加到演示文稿中。在这种情况下，OLE 对象框的大小将首先根据参与工作簿的行和列的累计高度和宽度进行计算。然后我们将 Ole 框架的大小设置为该计算值。为了避免 PowerPoint 中 Ole 框架出现红色 **嵌入对象** 消息，我们还将获取工作簿中所需行和列的图像，并将其设置为 Ole 框架图像。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **根据 Ole 框架大小调整工作表的行高和列宽**
在此方法中，我们将学习如何根据自定义设置的 Ole 框架大小调整参与行的高度和参与列的宽度
## **示例**
假设，我们定义了一个模板 Excel 工作表，并希望将其作为 Ole 框架添加到演示文稿中。在这种情况下，我们将设置 Ole 框架的大小并调整参与 Ole 框架区域的行和列的大小。然后我们将工作簿保存到流中以保存更改，并将其转换为字节数组以添加到 Ole 框架中。为了避免 PowerPoint 中 Ole 框架出现红色 **嵌入对象** 消息，我们还将获取工作簿中所需行和列的图像，并将其设置为 Ole 框架图像。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **结论**
{{% alert color="primary" %}} 

有两种方法可以解决工作表调整大小的问题。选择适当的方法取决于需求和用例。这两种方法在使用模板创建演示文稿或从头开始创建时都能正常工作。此外，在解决方案中没有 OLE 对象框大小的限制。

{{% /alert %}}