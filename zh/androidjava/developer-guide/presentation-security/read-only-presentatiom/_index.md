---
title: 只读演示文稿
type: docs
weight: 30
url: /androidjava/read-only-presentation/

---

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护其演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您希望防止意外编辑并保持演示文稿内容的安全。
- 您希望提醒人们您提供的演示文稿是最终版本。

在您为演示文稿选择 **始终以只读方式打开** 选项后，当用户打开演示文稿时，他们会看到 **只读** 建议，并可能看到以下形式的消息：*为了防止意外更改，作者已将此文件设置为只读。*

只读建议是一种简单而有效的威慑措施，可以防止编辑，因为用户在被允许编辑演示文稿之前必须执行某项操作以将其移除。如果您不希望用户对演示文稿进行更改并希望以礼貌的方式告诉他们，那么只读建议可能是一个不错的选择。

> 如果带有 **只读** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该应用程序不支持最近引入的功能——则 **只读** 建议将被忽略（演示文稿将正常打开）。

Aspose.Slides for Android via Java 允许您将演示文稿设置为 **只读**，这意味着用户（在打开演示文稿后）会看到 **只读** 建议。以下示例代码演示了如何使用 Aspose.Slides 在 Java 中将演示文稿设置为 **只读**：

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

**注意**：**只读** 建议的目的仅仅是为了劝阻编辑或阻止用户对 PowerPoint 演示文稿进行意外更改。如果一个动机明确的人——知道他们在做什么——决定编辑您的演示文稿，他们可以轻松删除只读设置。如果您确实需要防止未经授权的编辑，您最好使用 [涉及加密和密码的更严格保护措施](https://docs.aspose.com/slides/androidjava/password-protected-presentation/)。

{{% /alert %}} 