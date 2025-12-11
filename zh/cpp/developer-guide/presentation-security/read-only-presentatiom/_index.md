---
title: 使用 C++ 将演示文稿保存为只读模式
linktitle: 只读演示文稿
type: docs
weight: 30
url: /zh/cpp/read-only-presentation/
keywords:
- 只读
- 保护演示文稿
- 防止编辑
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 加载和保存 PowerPoint 文件 (PPT, PPTX) 为只读模式，可精确预览幻灯片而不更改演示文稿。"
---

## **应用只读模式**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户用来保护演示文稿的选项之一。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 您想防止意外编辑并保持演示文稿内容的安全。  
- 您想提醒他人您提供的演示文稿是最终版本。  

当您为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时，会看到 **只读** 建议，并可能看到如下信息：*为防止意外更改，作者已将此文件设置为以只读方式打开。*

只读建议是一种简单但有效的威慑手段，能够阻止编辑，因为用户必须执行移除该建议的操作后才被允许运行编辑。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，只读建议可能是一个不错的选项。

> 如果带有 **只读** 保护的演示文稿在不支持此新功能的旧版 Microsoft PowerPoint 应用中打开——该应用不支持最近引入的功能——则 **只读** 建议会被忽略（演示文稿会正常打开）。

Aspose.Slides for C++ 允许您将演示文稿设置为 **只读**，这意味着用户（在打开演示文稿后）会看到 **只读** 建议。以下示例代码演示了如何在 C++ 中使用 Aspose.Slides 将演示文稿设置为 **只读**：
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**注意**：**只读** 建议仅用于劝阻编辑或阻止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人员决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未授权的编辑，建议使用[更严格的加密和密码保护](https://docs.aspose.com/slides/cpp/password-protected-presentation/)。 

{{% /alert %}} 

## **常见问题**

**“只读建议”与完整的密码保护有什么区别？**

“只读建议”仅显示在只读模式下打开文件的提示，且很容易绕过。[Password protection](/slides/zh/cpp/password-protected-presentation/) 实际限制打开或编辑，适用于需要真实安全控制的场景。

**“只读建议”可以与水印结合使用以进一步劝阻编辑吗？**

可以。建议可以与[watermarks](/slides/zh/cpp/watermark/) 组合使用作为视觉威慑；它们是独立的机制，配合使用效果更佳。

**启用建议后，宏或外部工具仍能修改文件吗？**

可以。该建议不会阻止程序化的更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/cpp/password-protected-presentation/)。 

**“只读建议”与 “is encrypted” 与 “is write protected” 标志有什么关系？**

它们是不同的信号。“只读建议”是软性、可选的提示；[get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) 和 [get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/) 表示实际的写入或读取限制，这些限制取决于密码或加密。