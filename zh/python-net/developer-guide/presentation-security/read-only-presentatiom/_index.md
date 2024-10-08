---
title: 只读演示文稿
type: docs
weight: 30
url: /zh/python-net/read-only-presentation/
keywords: "只读设置，PowerPoint演示文稿，Python，Aspose.Slides for Python via .NET"
description: "Python中的只读PowerPoint演示文稿"
---

在PowerPoint 2019中，Microsoft引入了**永远以只读方式打开**设置，作为用户用于保护其演示文稿的选项之一。您可能想使用此只读设置来保护演示文稿，当

- 您想防止意外编辑并保持演示文稿的内容安全。
- 您想告知他人您提供的演示文稿是最终版本。

在您为演示文稿选择**永远以只读方式打开**选项后，当用户打开演示文稿时，他们会看到**只读**建议，并可能看到如下形式的消息：*为了防止意外更改，作者已将此文件设置为只读打开。*

只读建议是一个简单但有效的威慑措施，阻止编辑，因为用户必须执行某项操作以在被允许编辑演示文稿之前移除它。如果您不希望用户对演示文稿进行更改，并且希望以礼貌的方式告知他们，那么只读建议可能是一个不错的选择。

> 如果带有**只读**保护的演示文稿在较旧的Microsoft PowerPoint应用程序中打开——该应用程序不支持最近引入的功能——则**只读**建议将被忽略（演示文稿将正常打开）。

Aspose.Slides for Python via .NET允许您将演示文稿设置为**只读**，这意味着用户（在他们打开演示文稿后）会看到**只读**建议。以下示例代码演示了如何使用Aspose.Slides在Python中将演示文稿设置为**只读**：

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**注意**：**只读**建议仅旨在阻止编辑或防止用户意外更改PowerPoint演示文稿。如果一个有动机的人——知道他们在做什么——决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您确实需要防止未经授权的编辑，您最好使用[涉及加密和密码的更严格保护措施](https://docs.aspose.com/slides/python-net/password-protected-presentation/)。  

{{% /alert %}} 