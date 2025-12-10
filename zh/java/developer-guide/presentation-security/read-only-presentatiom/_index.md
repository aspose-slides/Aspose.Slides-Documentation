---
title: 使用 Java 将演示文稿以只读模式保存
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/java/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览而不更改演示文稿。"
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 设置，作为用户用于保护演示文稿的选项之一。当以下情况时，您可能想使用此只读设置来保护演示文稿：

- 您希望防止意外编辑并保持演示文稿内容安全。 
- 您希望提醒他人您提供的演示文稿是最终版本。 

为演示文稿选择 **Always Open Read-Only** 选项后，用户打开演示文稿时，会看到 **Read-Only** 建议，并可能看到如下信息：*为了防止意外更改，作者已将此文件设置为只读模式打开。*

只读建议是一种简单而有效的威慑手段，它通过要求用户在编辑演示文稿前先执行移除该建议的操作来阻止编辑。如果您不希望用户更改演示文稿并且想以礼貌的方式告知他们，那么只读建议可能是一个不错的选择。 

> 如果带有 **Read-Only** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该程序不支持最近引入的功能——则 **Read-Only** 建议会被忽略（演示文稿会正常打开）。

Aspose.Slides for Java 允许您将演示文稿设置为 **Read-Only**，这意味着用户（打开演示文稿后）会看到 **Read-Only** 建议。以下示例代码展示了如何使用 Aspose.Slides 在 Java 中将演示文稿设置为 **Read-Only**：
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 
**Note**: **Read-Only** 建议仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未授权的编辑，最好使用[更严格的涉及加密和密码的保护](https://docs.aspose.com/slides/java/password-protected-presentation/)。 
{{% /alert %}} 

## **FAQ**

**只读建议 与 完整密码保护 有何不同？**

**只读建议** 只会显示一个打开文件的只读模式提示，容易绕过。[密码保护](/slides/zh/java/password-protected-presentation/) 实际限制打开或编辑，在需要真正安全控制时更合适。

**只读建议 能否 与 水印 结合以进一步劝阻编辑？**

可以。该建议可以与[水印](/slides/zh/java/watermark/) 结合使用，作为视觉威慑；二者是独立机制，配合良好。

**启用建议后，宏或外部工具仍能修改文件吗？**

可以。该建议不会阻止程序化更改。若需防止自动化编辑，请使用[密码和加密](/slides/zh/java/password-protected-presentation/)。 

**“只读建议” 与 方法 `isEncrypted` 和 `isWriteProtected` 有何关联？**

它们是不同的信号。**只读建议** 是一种软性、可选的提示；[isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isWriteProtected--) 和 [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isEncrypted--) 表示实际的写入或读取限制，取决于密码或加密。