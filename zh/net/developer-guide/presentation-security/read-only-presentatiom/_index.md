---
title: 只读演示文稿
type: docs
weight: 30
url: /net/read-only-presentation/
keywords: "只读设置, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "C#或者.NET中的只读PowerPoint演示文稿"
---

在PowerPoint 2019中，微软引入了**始终以只读方式打开**设置，作为用户用来保护他们演示文稿的选项之一。您可能希望使用此只读设置来保护演示文稿，当

- 您希望防止意外编辑并确保演示文稿的内容安全。
- 您希望提醒人们您提供的演示文稿是最终版本。

选择演示文稿的**始终以只读方式打开**选项后，当用户打开演示文稿时，他们会看到**只读**建议，并可能会看到以下形式的消息：*为了防止意外更改，作者已将此文件设置为以只读方式打开。*

只读建议是一种简单而有效的威慑，阻止编辑，因为用户必须执行某个操作才能在被允许编辑演示文稿之前将其移除。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，那么只读建议可能是一个不错的选择。

> 如果带有**只读**保护的演示文稿在较旧的Microsoft PowerPoint应用程序中打开——该应用程序不支持最近引入的功能——则会忽略**只读**建议（演示文稿通常打开）。

Aspose.Slides for .NET允许您将演示文稿设置为**只读**，这意味着用户（在打开演示文稿后）将看到**只读**建议。以下示例代码演示了如何使用Aspose.Slides在C#中将演示文稿设置为**只读**：

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**注意**：**只读**建议仅用于阻止编辑或防止用户对PowerPoint演示文稿进行意外更改。如果一个有动机的人——知道自己在做什么——决定编辑您的演示文稿，他们可以轻松地移除只读设置。如果您确实需要防止未经授权的编辑，您最好使用[涉及加密和密码的更严格保护措施](https://docs.aspose.com/slides/net/password-protected-presentation/)。

{{% /alert %}} 