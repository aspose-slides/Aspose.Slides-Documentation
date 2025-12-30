---
title: 使用 PHP 将演示文稿保存为只读模式
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/php-java/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），提供精确的幻灯片预览且不会更改您的演示文稿。"
---

## **Apply Read-Only Mode**

在 PowerPoint 2019 中，Microsoft 引入了 **Always Open Read-Only** 设置，作为用户保护演示文稿的选项之一。当您希望通过只读设置来保护演示文稿时：

- 防止意外编辑，保持演示文稿内容安全。  
- 向他人提示您提供的演示文稿是最终版本。  

为演示文稿选择 **Always Open Read-Only** 选项后，用户打开演示文稿时会看到 **Read-Only** 提示，可能会出现如下信息：*为防止意外更改，作者已将此文件设置为只读打开。*

**Read-Only** 提示是一种简单而有效的阻吓手段，用户必须执行操作才能去除该提示并进行编辑。如果您不希望用户对演示文稿进行更改，并且想以礼貌的方式告知他们，那么 **Read-Only** 提示可能是一个不错的选择。

> 如果带有 **Read-Only** 保护的演示文稿在旧版 Microsoft PowerPoint（不支持此功能）中打开，**Read-Only** 提示将被忽略（演示文稿正常打开）。

Aspose.Slides for PHP via Java 允许您将演示文稿设置为 **Read-Only**，这意味着用户（打开演示文稿后）会看到 **Read-Only** 提示。以下示例代码演示了如何使用 Aspose.Slides 将演示文稿设置为 **Read-Only**：
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**Note**: **Read-Only** 提示仅用于阻止编辑或避免用户对 PowerPoint 演示文稿进行意外更改。如果有动机且具备相应技术的人想编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未授权编辑，建议使用[更严格的加密和密码保护](https://docs.aspose.com/slides/php-java/password-protected-presentation/)。

{{% /alert %}} 

## **FAQ**

**“Read-Only recommended” 与完整的密码保护有什么区别？**

“Read-Only recommended” 只会显示一个建议，以只读模式打开文件，且易于绕过。[密码保护](/slides/zh/php-java/password-protected-presentation/) 则真正限制打开或编辑，适用于需要真正安全控制的场景。

**“Read-Only recommended” 能否与水印结合使用以进一步阻止编辑？**

可以。该建议可以与[水印](/slides/zh/php-java/watermark/) 结合使用，作为视觉阻吓；它们是独立机制，配合使用效果良好。

**启用该建议后，宏或外部工具仍能修改文件吗？**

可以。该建议并不阻止程序化的更改。若要防止自动化编辑，请使用[密码和加密](/slides/zh/php-java/password-protected-presentation/)。

**“Read-Only recommended” 与 `isEncrypted` 和 `isWriteProtected` 方法有什么关联？**

它们是不同的信号。“Read-Only recommended” 是一种软性的、可选的提示；[`isWriteProtected`](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) 和 [`isEncrypted`](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) 表示实际的写入或读取限制，取决于密码或加密。