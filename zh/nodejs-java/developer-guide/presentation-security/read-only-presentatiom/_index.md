---
title: 只读演示文稿
type: docs
weight: 30
url: /zh/nodejs-java/read-only-presentation/
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的选项之一。当出现以下情况时，您可能想使用此只读设置来保护演示文稿：

- 您希望防止意外编辑并保持演示文稿内容安全。 
- 您希望提醒他人您提供的演示文稿是最终版本。 

在为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时，会看到 **只读** 推荐，并可能看到如下信息：*为防止意外更改，作者已将此文件设置为只读打开。*

只读推荐是一种简单而有效的阻止编辑的方式，因为用户必须先执行操作才能移除它，才能编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，则只读推荐可能是一个不错的选择。 

> 如果带有 **只读** 保护的演示文稿在不支持此新功能的旧版 Microsoft PowerPoint 中打开，则 **只读** 推荐将被忽略（演示文稿会正常打开）。

Aspose.Slides for Node.js via Java 允许您将演示文稿设置为 **只读**，这意味着用户（打开演示文稿后）会看到 **只读** 推荐。以下示例代码演示了如何使用 Aspose.Slides 在 JavaScript 中将演示文稿设置为 **只读**：
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**注意**：**只读** 推荐仅用于劝阻编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有经验的用户决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未授权的编辑，最好使用[更严格的加密和密码保护](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

**“只读推荐”与完整密码保护有何不同？**

“只读推荐”仅显示在只读模式下打开文件的建议，且容易绕过。[密码保护](/slides/zh/nodejs-java/password-protected-presentation/) 实际限制打开或编辑，当您需要真实的安全控制时适用。 

**“只读推荐”可以与水印结合使用以进一步劝阻编辑吗？**

可以。该推荐可以与[水印](/slides/zh/nodejs-java/watermark/) 结合使用，作为视觉阻止手段；它们是独立的机制，能够良好配合。 

**启用该推荐后，宏或外部工具仍能修改文件吗？**

可以。该推荐并不会阻止程序化的更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/nodejs-java/password-protected-presentation/)。 

**“只读推荐”与标志 'IsEncrypted' 和 'IsWriteProtected' 有何关联？**

它们是不同的信号。“只读推荐”是一种软性的可选提示；[isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) 和 [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) 表示实际的写入或读取限制，这取决于密码或加密。