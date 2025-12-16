---
title: 在 Android 上以只读模式保存演示文稿
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/androidjava/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 文件（PPT、PPTX）以只读模式保存，提供精确的幻灯片预览且不更改演示文稿。"
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。 
- 您想提示他人您提供的演示文稿是最终版本。 

为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时会看到 **只读** 建议，并可能看到如下信息：*为防止意外更改，作者已将此文件设置为只读打开。*

只读建议是一种简单而有效的阻止编辑的手段，因为用户必须执行操作才能移除该建议后才能编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，只读建议可能是一个不错的选项。 

> 如果带有 **只读** 保护的演示文稿在不支持此功能的旧版 Microsoft PowerPoint 应用中打开——该应用不支持最近引入的功能——则 **只读** 建议将被忽略（演示文稿会正常打开）。 

Aspose.Slides for Android via Java 允许您将演示文稿设置为 **只读**，即用户（打开演示文稿后）会看到 **只读** 建议。以下示例代码演示了如何在 Java 中使用 Aspose.Slides 将演示文稿设置为 **只读**：
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

**注意**：**只读** 建议仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未授权的编辑，建议使用[更严格的加密和密码保护](https://docs.aspose.com/slides/androidjava/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

**“只读建议”与完整的密码保护有什么不同？**

“只读建议”仅显示在只读模式下打开文件的提示，且容易绕过。[密码保护](/slides/zh/androidjava/password-protected-presentation/) 实际限制打开或编辑，适用于您需要真正安全控制的场景。 

**“只读建议”可以与水印结合以进一步阻止编辑吗？**

可以。该建议可与[水印](/slides/zh/androidjava/watermark/) 结合使用，作为视觉阻止手段；它们是独立机制，配合使用效果良好。 

**启用建议后，宏或外部工具仍能修改文件吗？**

可以。该建议不会阻止程序化修改。若要防止自动编辑，请使用[密码和加密](/slides/zh/androidjava/password-protected-presentation/)。 

**“只读建议”与 `isEncrypted` 和 `isWriteProtected` 方法有何关联？**

它们是不同的信号。“只读建议”是软性的可选提示；[isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) 和 [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) 表示实际的写入或读取限制，取决于密码或加密。