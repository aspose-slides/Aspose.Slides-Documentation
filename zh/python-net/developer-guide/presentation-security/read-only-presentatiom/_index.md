---
title: 使用 Python 将演示文稿以只读模式保存
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
description: 使用 Aspose.Slides for Python via .NET 加载并以只读模式保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览而不更改您的演示文稿。
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 设置，作为用户保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。  
- 您想告知他人您提供的演示文稿是最终版本。

当您为演示文稿选择 **Always Open Read-Only** 选项后，用户打开演示文稿时会看到 **Read-Only** 建议，可能会出现如下信息：*为防止意外更改，作者已将此文件设置为以只读方式打开。*

**Read-Only** 建议是一种简单而有效的阻吓手段，它通过让用户在编辑前必须执行移除操作来防止编辑。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，那么 **Read-Only** 建议可能是一个不错的选择。

> 如果带有 **Read-Only** 保护的演示文稿在不支持此功能的旧版 Microsoft PowerPoint 应用中打开——该功能在旧版中不存在——则 **Read-Only** 建议会被忽略（演示文稿会正常打开）。

Aspose.Slides for Python via .NET 允许您将演示文稿设置为 **Read-Only**，这意味着用户（在打开演示文稿后）会看到 **Read-Only** 建议。以下示例代码展示了如何使用 Aspose.Slides 在 Python 中将演示文稿设置为 **Read-Only**：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**注意**：**Read-Only** 建议仅用于阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且具备相应技术的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未授权的编辑，建议使用[更严格的加密和密码保护](https://docs.aspose.com/slides/python-net/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

**“只读推荐”与完整的密码保护有何不同？**

“只读推荐”仅显示一个以只读模式打开文件的建议，且易于绕过。[密码保护](/slides/zh/python-net/password-protected-presentation/) 实际限制打开或编辑，并在需要真正的安全控制时使用。

**可以将“只读推荐”与水印结合使用以进一步阻止编辑吗？**

可以。该建议可以与[水印](/slides/zh/python-net/watermark/) 组合使用，作为视觉阻吓；两者是独立机制，配合良好。

**启用该建议后，宏或外部工具仍能修改文件吗？**

可以。该建议并不会阻止程序化更改。若需防止自动化编辑，请使用[密码和加密](/slides/zh/python-net/password-protected-presentation/)。

**“只读推荐”与标志 `is_encrypted` 和 `is_write_protected` 有何关联？**

它们是不同的信号。**只读推荐** 是一种软性的、可选提示；[`is_write_protected`](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) 和 [`is_encrypted`](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) 表示实际的写入或读取限制，这些限制取决于密码或加密。