---
title: 在 .NET 中以只读模式保存演示文稿
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/net/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览而不更改演示文稿。"
---
## **介绍**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。 
- 您想提醒他人您提供的演示文稿是最终版本。 

当您为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时会看到 **只读** 推荐，可能会看到如下提示：*为防止意外更改，作者已将此文件设置为只读打开。*

只读推荐是一种简单而有效的阻止编辑的手段，因为用户必须执行操作才能移除它，才被允许编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，只读推荐可能是一个不错的选择。 

> 如果在不支持此新功能的旧版 Microsoft PowerPoint 应用程序中打开带有 **只读** 保护的演示文稿，**只读** 推荐将被忽略（演示文稿将正常打开）。

## **应用只读模式**

Aspose.Slides for .NET 允许您将演示文稿设置为 **只读**，这意味着用户（打开演示文稿后）会看到 **只读** 推荐。以下示例代码展示了如何使用 Aspose.Slides 在 C# 中将演示文稿设置为 **只读**：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**注意**：**只读** 推荐仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未授权的编辑，最好使用[更严格的加密和密码保护](https://docs.aspose.com/slides/zh/net/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

### “只读推荐” 与完整密码保护有什么区别？

“只读推荐” 只显示在只读模式下打开文件的建议，且易于绕过。[密码保护](/slides/zh/net/password-protected-presentation/) 实际限制打开或编辑，适用于需要真实安全控制的场景。

### “只读推荐” 能否与水印结合使用以进一步劝阻编辑？

可以。该推荐可以与[水印](/slides/zh/net/watermark/) 结合使用作为视觉阻止手段；它们是独立的机制，协同效果良好。

### 当启用推荐时，宏或外部工具仍能修改文件吗？

可以。该推荐并不阻止程序化修改。要防止自动化编辑，请使用[密码和加密](/slides/zh/net/password-protected-presentation/)。

### “只读推荐” 与标志 “IsEncrypted” 和 “IsWriteProtected” 有何关联？

它们是不同的信号。“只读推荐” 是一种软性的可选提示；[IsWriteProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/iswriteprotected/) 和 [IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/isencrypted/) 则表示实际的写入或读取限制，这取决于密码或加密。