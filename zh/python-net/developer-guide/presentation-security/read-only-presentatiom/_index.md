---
title: 使用 Python 以只读模式保存演示文稿
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/python-net/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），提供准确的幻灯片预览且不更改演示文稿。"
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的选项之一。当您希望在以下情况下使用此只读设置来保护演示文稿时：

- 您想防止意外编辑并保持演示文稿内容的安全。  
- 您想提醒他人您提供的演示文稿是最终版本。

为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时会看到 **只读** 建议，可能会看到如下信息：*为了防止意外更改，作者已将此文件设置为以只读方式打开。*

只读建议是一种简单而有效的阻慑手段，因为用户必须执行步骤才能移除它，才被允许编辑演示文稿。如果您不希望用户更改演示文稿，并想以礼貌的方式告知他们，只读建议可能是一个不错的选项。

> 如果在不支持此新功能的旧版 Microsoft PowerPoint 应用程序中打开带有 **只读** 保护的演示文稿，**只读** 建议将被忽略（演示文稿将正常打开）。

Aspose.Slides for Python via .NET 允许您将演示文稿设置为 **只读**，这意味着用户（打开演示文稿后）会看到 **只读** 建议。以下示例代码演示了如何使用 Aspose.Slides 在 Python 中将演示文稿设置为 **只读**：
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**注意**：**只读** 建议仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未授权编辑，最好使用[更严格的加密和密码保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/)。

{{% /alert %}} 

## **FAQ**

**“只读建议”与完整密码保护有何区别？**

“只读建议”仅显示以只读模式打开文件的提示，易于绕过。[密码保护](/slides/zh/python-net/password-protected-presentation/) 实际限制打开或编辑，当您需要真正的安全控制时更为合适。

**“只读建议”可以与水印结合使用以进一步阻止编辑吗？**

可以。该建议可以与[水印](/slides/zh/python-net/watermark/) 配合使用，作为视觉阻慑；它们是独立机制，能够很好地协同工作。

**启用建议后，宏或外部工具仍能修改文件吗？**

可以。该建议不会阻止程序化更改。如需防止自动化编辑，请使用[密码和加密](/slides/zh/python-net/password-protected-presentation/)。

**“只读建议”与标志 `is_encrypted` 和 `is_write_protected` 有何关联？**

它们是不同的信号。“只读建议”是软性、可选的提示；[is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) 和 [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) 表示实际的写入或读取限制，取决于密码或加密。