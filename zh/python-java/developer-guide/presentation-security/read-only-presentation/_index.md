---
title: 使用 Python 将演示文稿以只读模式保存
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/python-java/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在只读模式下加载和保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览且不更改演示文稿。"
---
## **介绍**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 设置，作为用户可用于保护演示文稿的选项之一。您在以下情况下可能希望使用此只读设置来保护演示文稿：

- 您希望防止意外编辑并保持演示文稿内容的安全。 
- 您希望提醒他人您提供的演示文稿是最终版本。 

在为演示文稿选择 **Always Open Read-Only** 选项后，用户打开演示文稿时，会看到 **Read-Only** 的建议，并可能看到如下信息：*为了防止意外更改，作者已将此文件设置为只读打开。*

只读建议是一种简单而有效的阻止手段，它通过要求用户在编辑演示文稿前先取消该设置，从而阻止编辑。如果您不希望用户对演示文稿进行更改，并且想以礼貌的方式告知他们，那么只读建议可能是一个合适的选项。

> 如果在不支持最近引入的功能的旧版 Microsoft PowerPoint 应用程序中打开带有 **Read-Only** 保护的演示文稿，则 **Read-Only** 建议会被忽略（演示文稿会正常打开）。

## **应用只读模式**

Aspose.Slides for Python via Java 允许您将演示文稿设置为 **Read-Only**，这意味着用户（打开演示文稿后）会看到 **Read-Only** 建议。以下示例代码展示了如何使用 Aspose.Slides 在 Python 中将演示文稿设置为 **Read-Only**：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
**Read-Only** 建议仅用于阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。  
如果有动机并且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。  
如果您确实需要防止未授权编辑，最好使用[更严格的加密和密码保护](/slides/zh/python-java/password-protected-presentation/)。 
{{% /alert %}} 

## **常见问题**

**'Read-Only recommended' 与完整密码保护有何区别？**  
'Read-Only recommended' 只会显示在只读模式下打开文件的建议，且很容易绕过。[密码保护](/slides/zh/python-java/password-protected-presentation/) 实际上限制打开或编辑，当您需要真正的安全控制时适用。

**'Read-Only recommended' 可以与水印结合以进一步阻止编辑吗？**  
可以。该建议可以与[水印](/slides/zh/python-java/watermark/) 结合使用，作为视觉阻止手段；它们是独立机制，能够良好配合。

**启用该建议后，宏或外部工具仍然能够修改文件吗？**  
可以。该建议并不会阻止程序化的更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/python-java/password-protected-presentation/)。

**'Read-Only recommended' 与方法 [isEncrypted](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isEncrypted) 和 [isWriteProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isWriteProtected) 有何关联？**  
它们是不同的信号。'Read-Only recommended' 是一种软性的、可选的提示；[isWriteProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isWriteProtected) 和 [isEncrypted](https://reference.aspose.com/slides/zh/python-java/aspose.slides/protectionmanager/#isEncrypted) 则表示实际的写入或读取限制，这取决于密码或加密。