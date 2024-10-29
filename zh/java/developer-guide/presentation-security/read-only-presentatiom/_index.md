---
title: 只读演示文稿
type: docs
weight: 30
url: /zh/java/read-only-presentation/

---

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户用于保护其演示文稿的选项之一。您可能希望使用此只读设置来保护演示文稿，当

- 您希望防止意外编辑并保持演示文稿内容安全。
- 您希望提醒人们您提供的演示文稿是最终版本。

在您为演示文稿选择 **始终以只读方式打开** 选项后，当用户打开演示文稿时，他们会看到 **只读** 推荐，并可能看到如下形式的消息：*为防止意外更改，作者已将此文件设置为以只读方式打开。*

只读推荐是一种简单但有效的威慑，阻止编辑，因为用户必须执行某个操作才能在被允许编辑演示文稿之前将其移除。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告诉他们这一点，那么只读推荐可能是一个不错的选择。

> 如果使用 **只读** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该应用程序不支持最近引入的功能——**只读** 推荐将被忽略（演示文稿正常打开）。

Aspose.Slides for Java 允许您将演示文稿设置为 **只读**，这意味着用户（在他们打开演示文稿后）会看到 **只读** 推荐。以下示例代码展示了如何使用 Aspose.Slides 在 Java 中将演示文稿设置为 **只读**：

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

**注意**：**只读** 推荐仅旨在阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果一个有动力的人——知道自己在做什么——决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未经授权的编辑，最好使用 [涉及加密和密码的更严格保护措施](https://docs.aspose.com/slides/java/password-protected-presentation/)。 

{{% /alert %}}