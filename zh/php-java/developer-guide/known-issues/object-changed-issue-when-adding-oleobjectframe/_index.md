---
title: 添加 OleObjectFrame 时出现对象已更改问题
type: docs
weight: 10
url: /zh/php-java/object-changed-issue-when-adding-oleobjectframe/
---

## **问题陈述**
当开发人员通过 Java 的 Aspose.Slides for PHP 向他们的幻灯片添加 **OleObjectFrame** 时，输出幻灯片上显示的是 **对象已更改** 消息，而不是 **OLE 对象**。大多数 Aspose.Slides for PHP 的 Java 客户认为这是 Aspose.Slides for PHP 的 Java 中的一个错误或缺陷。
## **批判分析和解释**
首先，重要的是要知道，在幻灯片中添加 **OleObjectFrame** 后，由 Aspose.Slides for PHP 通过 Java 显示的 **对象已更改** 消息，**不是** Aspose.Slides for PHP 通过 Java 中的错误或缺陷。它只是一个信息或消息，通知用户对象已更改，图像应该更新。

例如，如果您将 **Microsoft Excel 图表** 作为 **OleObjectFrame** 添加到您的幻灯片中（有关将 **OleObjectFrame** 添加到幻灯片的更多详细信息和代码片段，请 [点击这里](/slides/zh/php-java/adding-frame-to-the-slide/)），然后使用 MS PowerPoint 打开演示文稿文件，则 (添加 **OLE 对象** 的) 幻灯片将如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**图**：在 **OLE 对象** 添加后显示 **对象已更改** 消息的幻灯片

这不是错误，您的 OLE 对象仍然添加到幻灯片中。如果您想测试一下，请 **双击** **对象已更改** 消息，或 **右键单击** 它并选择 **工作表对象 -> 编辑** 选项，如下图所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**图**：选择 **编辑** 选项以编辑 **OLE 对象**

选择弹出菜单的 **编辑** 选项后，您将看到 **嵌入的 OLE 对象** 以可编辑的形式呈现，如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**图**：可编辑形式的 **OLE 对象**

您仍然可以在 MS PowerPoint 的左侧窗格中看到 **对象已更改** 消息，该窗格显示幻灯片预览。一旦您单击 **OLE 对象**，您将看到幻灯片预览也会发生变化，**已更改对象** 消息将被 **OLE 对象** 的图像替代，如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**图**：**OLE 对象** 图像的更新

现在，您应该使用 MS PowerPoint **保存** 您的演示文稿文件，以便 **OLE 对象** 的图像更新。保存演示文稿后再次使用 MS PowerPoint 打开，您将看到不会再有 **对象已更改** 消息。
## **更多解决方案**
在上述批判分析中，我们演示了通过在 MS PowerPoint 中打开演示文稿文件并保存它，可以更新 **OLE 对象** 的图像。但还有两种解决方案可以处理 **对象已更改** 消息。
## **第一个解决方案：用图像替换对象已更改消息**
如果您不喜欢 **对象已更改** 消息，则可以用您自己的图像替换该消息。您可以将任何所需的图片添加到演示文稿中，然后使用该添加图片的 Id 来替换 **对象已更改** 消息。

为了实现这一点，您可以在向幻灯片添加 **OleObjectFrame** 后，在您的应用程序中添加以下几行代码。
## **示例**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

在您的应用程序中添加上述行后，包含 **OleObjectFrame** 的幻灯片将如下所示：

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**图**：用图像替换的 **对象已更改** 消息
## **第二个解决方案：为 MS PowerPoint 创建一个附加组件**
您还可以尝试为 MS PowerPoint 创建一个附加组件，当您在 MS PowerPoint 中打开演示文稿时，更新所有 **OLE 对象**。