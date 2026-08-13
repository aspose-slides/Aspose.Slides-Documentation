---
title: 使用 Java 将演示文稿保存为只读模式
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
description: "使用 Aspose.Slides for Java 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览而不更改您的演示文稿。"
---
## **介绍**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户用来保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。 
- 您想提醒他人您提供的演示文稿是最终版本。

在为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时，会看到 **只读** 推荐，并可能看到如下信息：*为了防止意外更改，作者已将此文件设置为以只读方式打开。*

只读推荐是一种简单而有效的威慑手段，因为用户必须先执行任务才能删除该推荐，才能对演示文稿进行编辑。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式提示他们，只读推荐可能是一个不错的选择。

> 如果在不支持此新功能的旧版 Microsoft PowerPoint 应用程序中打开带有 **只读** 保护的演示文稿，**只读** 推荐将被忽略（演示文稿将正常打开）。

## **应用只读模式**

Aspose.Slides for Java 允许您将演示文稿设置为 **只读**，这意味着用户（打开演示文稿后）会看到 **只读** 推荐。以下示例代码演示了如何使用 Aspose.Slides 在 Java 中将演示文稿设置为 **只读**：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**注意**：**只读** 推荐仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示稿，他们可以轻松移除只读设置。如果您真的需要防止未授权的编辑，最好使用[更严格的加密和密码保护](https://docs.aspose.com/slides/zh/java/password-protected-presentation/)。

{{% /alert %}} 

## **常见问题**

### “只读推荐”与完整密码保护有什么区别？

“只读推荐”仅显示在只读模式下打开文件的建议，且容易绕过。[密码保护](/slides/zh/java/password-protected-presentation/) 实际限制打开或编辑，适用于需要真正安全控制的场景。

### “只读推荐”可以与水印结合使用以进一步劝阻编辑吗？

可以。推荐可以与[水印](/slides/zh/java/watermark/) 结合使用，作为视觉威慑；它们是独立机制，能够很好地协同工作。

### 启用推荐后，宏或外部工具仍能修改文件吗？

可以。推荐不会阻止程序化更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/java/password-protected-presentation/)。

### “只读推荐”与 `isEncrypted` 和 `isWriteProtected` 方法有什么关系？

它们是不同的信号。“只读推荐”是软性、可选的提示；[isWriteProtected](https://reference.aspose.com/slides/zh/java/com.aspose.slides/protectionmanager/#isWriteProtected--) 和 [isEncrypted](https://reference.aspose.com/slides/zh/java/com.aspose.slides/protectionmanager/#isEncrypted--) 则表示实际的写入或读取限制，取决于密码或加密。