---
title: 只读演示文稿
type: docs
weight: 30
url: /zh/net/read-only-presentation/
keywords: "只读设置, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "C# 或 .NET 中的只读 PowerPoint 演示文稿"
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 设置，作为用户用来保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并确保演示文稿内容的安全。 
- 您想提醒他人您提供的演示文稿是最终版本。 

在为演示文稿选择 **Always Open Read-Only** 选项后，用户打开演示文稿时，会看到 **Read-Only** 建议，并可能看到如下信息：*为了防止意外更改，作者已将此文件设置为只读打开。*

只读建议是一种简单而有效的阻止编辑的手段，因为用户必须执行操作才能去除该建议后才能编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，那么只读建议可能是一个不错的选择。 

> 如果使用 **Read-Only** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该版本不支持最近引入的功能——则 **Read-Only** 建议会被忽略（演示文稿将正常打开）。 

Aspose.Slides for .NET 允许您将演示文稿设置为 **Read-Only**，这意味着用户（打开演示文稿后）会看到 **Read-Only** 建议。以下示例代码展示了如何使用 Aspose.Slides 在 C# 中将演示文稿设置为 **Read-Only**：
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 

**注意**：**Read-Only** 建议仅用于阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未授权的编辑，最好使用[涉及加密和密码的更严格保护](https://docs.aspose.com/slides/net/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

**“Read-Only recommended” 与完整密码保护有何区别？**

“Read-Only recommended” 仅显示在只读模式下打开文件的建议，且很容易绕过。[密码保护](/slides/zh/net/password-protected-presentation/) 实际限制打开或编辑，适用于需要真实安全控制的情况。

**可以将 ‘Read-Only recommended’ 与水印结合使用以进一步阻止编辑吗？**

可以。该建议可以与[水印](/slides/zh/net/watermark/) 结合使用，作为视觉阻止手段；它们是独立的机制，能够很好地协同工作。

**在启用该建议时，宏或外部工具仍能修改文件吗？**

可以。该建议并不阻止程序化的更改。若需防止自动化编辑，请使用[密码和加密](/slides/zh/net/password-protected-presentation/)。

**“Read-Only recommended” 与标志 ‘IsEncrypted’ 和 ‘IsWriteProtected’ 有何关联？**

它们是不同的信号。‘Read-Only recommended’ 是一种软性、可选的提示；[IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) 和 [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) 则表示实际的写入或读取限制，取决于密码或加密。