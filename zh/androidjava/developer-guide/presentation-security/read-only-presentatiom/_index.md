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
## **介绍**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。  
- 您想向他人提示您提供的演示文稿是最终版本。  

当您为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时会看到 **只读** 推荐，并可能看到类似以下形式的消息：*为防止意外更改，作者已将此文件设为只读打开。*

只读推荐是一种简单而有效的阻止编辑的手段，因为用户必须执行一定操作才能删除它，才被允许编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，只读推荐可能是一个不错的选择。

> 如果带有 **只读** 保护的演示文稿在不支持此功能的旧版 Microsoft PowerPoint 应用程序中打开，**只读** 推荐将被忽略（演示文稿会正常打开）。

## **应用只读模式**

Aspose.Slides for Android via Java 允许您将演示文稿设置为 **只读**，这意味着用户（在打开演示文稿后）会看到 **只读** 推荐。以下示例代码展示了如何在 Java 中使用 Aspose.Slides 将演示文稿设置为 **只读**：

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

**注意**：**只读** 推荐仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且了解操作方法的人想要编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未授权编辑，建议使用[更严格的加密和密码保护](https://docs.aspose.com/slides/zh/androidjava/password-protected-presentation/)。

{{% /alert %}} 

## **常见问题**

### “只读推荐” 与完整密码保护有何不同？

“只读推荐” 只会显示以只读模式打开文件的建议，且很容易绕过。[密码保护](/slides/zh/androidjava/password-protected-presentation/) 实际限制打开或编辑，适用于需要真正安全控制的情况。

### “只读推荐” 可以与水印结合使用以进一步阻止编辑吗？

可以。该推荐可以与[水印](/slides/zh/androidjava/watermark/) 配合使用，作为视觉阻吓；两者是独立机制，配合使用效果更佳。

### 启用推荐后，宏或外部工具仍能修改文件吗？

可以。该推荐并不会阻止程序化更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/androidjava/password-protected-presentation/)。

### “只读推荐” 与 `isEncrypted` 和 `isWriteProtected` 方法有什么关系？

它们是不同的信号。“只读推荐” 是一种软性的、可选的提示；[isWriteProtected](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) 和 [isEncrypted](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) 则表明实际的写入或读取限制，这取决于密码或加密。