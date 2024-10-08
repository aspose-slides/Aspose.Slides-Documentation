---
title: 只读演示
type: docs
weight: 30
url: /zh/php-java/read-only-presentation/

---

在 PowerPoint 2019 中，微软引入了 **始终以只读方式打开** 设置，作为用户保护其演示文稿的选项之一。当您希望保护演示文稿时，可以使用此只读设置，例如：

- 您希望防止意外编辑，确保演示文稿内容的安全。
- 您希望提醒他人您提供的演示文稿是最终版本。

当您为演示文稿选择 **始终以只读方式打开** 选项后，当用户打开该演示文稿时，他们会看到 **只读** 推荐，并可能会看到如下消息：*为了防止意外更改，作者已将此文件设置为只读。*

只读推荐是一种简单但有效的威慑措施，可以使用户在被允许编辑演示文稿之前，必须先执行一个任务来移除此设置。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告诉他们这一点，那么只读推荐可能是一个不错的选择。

> 如果带有 **只读** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该应用程序不支持最近引入的功能——那么 **只读** 推荐将被忽略（演示文稿将正常打开）。

Aspose.Slides for PHP via Java 允许您将演示文稿设置为 **只读**，这意味着用户（在打开演示文稿后）将看到 **只读** 推荐。以下示例代码展示了如何使用 Aspose.Slides 将演示文稿设置为 **只读**：

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

**注意**：**只读** 推荐仅旨在劝阻编辑或阻止用户对 PowerPoint 演示文稿进行意外更改。如果一个有动机的人——他们知道自己在做什么——决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未经授权的编辑，您最好使用 [更严格的保护措施，如加密和密码](https://docs.aspose.com/slides/php-java/password-protected-presentation/)。

{{% /alert %}} 