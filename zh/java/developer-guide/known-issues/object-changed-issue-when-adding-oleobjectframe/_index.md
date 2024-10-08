---
title: 添加 OleObjectFrame 时的对象更改问题
type: docs
weight: 10
url: /zh/java/object-changed-issue-when-adding-oleobjectframe/
---

## **问题陈述**
当开发者使用 Aspose.Slides for Java 向他们的幻灯片添加 **OleObjectFrame** 时，输出幻灯片上会显示 **对象更改** 消息，而不是 **OLE 对象**。大多数 Aspose.Slides for Java 客户认为这是 Aspose.Slides for Java 中的错误或缺陷。
## **批判分析与解释**
首先，重要的是知道，在幻灯片中添加 **OleObjectFrame** 后，Aspose.Slides for Java 显示的 **对象更改** 消息 **并不是** Aspose.Slides for Java 中的错误或缺陷。这只是一个信息或消息，用于通知用户对象已更改，并且图像应被更新。

例如，如果您将 **Microsoft Excel 图表** 作为 **OleObjectFrame** 添加到幻灯片中（有关将 **OleObjectFrame** 添加到幻灯片的更多详细信息和代码片段， [点击这里](/slides/zh/java/adding-frame-to-the-slide/)），然后使用 MS PowerPoint 打开演示文稿文件，那么幻灯片（添加 **OLE 对象** 的地方）将如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**图**：添加 **OLE 对象** 后显示 **对象更改** 消息的幻灯片

这并不是错误，并且您的 OLE 对象仍然已添加到幻灯片中。如果您想测试它，可以 **双击** **对象更改** 消息或 **右键单击** 它，并选择 **工作表对象 -> 编辑** 选项，如下图所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**图**：选择 **编辑** 选项以编辑 **OLE 对象**

在您选择弹出菜单的 **编辑** 选项后，您将看到 **嵌入的 OLE 对象** 将以可编辑形式显示，如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**图**：可编辑形式的 **OLE 对象**

您仍然可以在 MS PowerPoint 的幻灯片预览左侧面板中看到 **对象更改** 消息。一旦您单击 **OLE 对象**，您将看到幻灯片预览也会发生变化，**更改的对象** 消息将被 **OLE 对象** 的图像所替换，如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**图**：**OLE 对象** 图像的更新

现在，您应使用 MS PowerPoint **保存** 您的演示文稿文件，以便更新 **OLE 对象** 的图像。一旦您保存演示文稿并再次使用 MS PowerPoint 打开，您将看到没有 **对象更改** 消息。
## **更多解决方案**
在上述批判分析中，我们演示了通过在 MS PowerPoint 中打开演示文稿文件并保存，从而可以更新 **OLE 对象** 的图像。但还有两种其他解决方案可以处理 **对象更改** 消息。
## **第一种解决方案：用图像替换对象更改消息**
如果您不喜欢 **对象更改** 消息，您也可以用您自己的图像替换该消息。您可以向演示文稿添加任何想要的图片，然后使用该添加图片的 Id 来替换 **对象更改** 消息。

要实现此目标，您可以在将 **OleObjectFrame** 添加到幻灯片后在应用程序中添加以下几行代码。
## **示例**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

在您的应用程序中添加以上代码行后，包含 **OleObjectFrame** 的结果幻灯片将如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**图**：用图像替换的 **对象更改** 消息
## **第二种解决方案：为 MS PowerPoint 创建附加组件**
您还可以尝试为 MS PowerPoint 创建一个附加组件，当您在 MS PowerPoint 中打开演示文稿时更新所有 **OLE 对象**。