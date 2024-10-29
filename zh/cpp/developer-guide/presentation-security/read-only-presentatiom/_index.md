---
title: 只读演示文稿
type: docs
weight: 30
url: /zh/cpp/read-only-presentation/

---

在 PowerPoint 2019 中，微软引入了 **始终以只读方式打开** 设置，作为用户可以用来保护其演示文稿的选项之一。您可能希望使用这个只读设置来保护演示文稿，当：

- 您想防止意外编辑，并保持演示文稿的内容安全。
- 您想提醒人们您提供的演示文稿是最终版本。

在您选择演示文稿的 **始终以只读方式打开** 选项后，当用户打开该演示文稿时，他们会看到 **只读** 建议，并可能会看到这样的信息：*为了防止意外更改，作者已将此文件设置为以只读方式打开。*

只读建议是一个简单而有效的阻止措施，可以阻止编辑，因为用户必须执行某个操作以消除它，然后才能编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，那么只读建议可能是一个不错的选择。

> 如果在较旧的 Microsoft PowerPoint 应用程序中打开具有 **只读** 保护的演示文稿（该应用程序不支持最近引入的功能），则 **只读** 建议将被忽略（演示文稿正常打开）。

Aspose.Slides for C++ 允许您将演示文稿设置为 **只读**，这意味着用户（在他们打开该演示文稿后）会看到 **只读** 建议。以下示例代码展示了如何在 C++ 中使用 Aspose.Slides 将演示文稿设置为 **只读**：

```cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**注意**：**只读** 建议仅旨在阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果一个目标明确的人——知道自己在做什么——决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未经授权的编辑，最好使用 [更严格的保护措施，包括加密和密码](https://docs.aspose.com/slides/cpp/password-protected-presentation/)。 

{{% /alert %}}