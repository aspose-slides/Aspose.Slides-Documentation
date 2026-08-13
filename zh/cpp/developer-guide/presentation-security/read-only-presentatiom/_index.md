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
description: "使用 Aspose.Slides for C++ 以只读模式加载和保存 PowerPoint 文件（PPT、PPTX），在不更改演示文稿的情况下提供精确的幻灯片预览。"
---
## **简介**

在 PowerPoint 2019 中，Microsoft 引入了 **始终以只读方式打开** 设置，作为用户保护演示文稿的一种选项。您可能希望在以下情况下使用此只读设置来保护演示文稿：

- 防止意外编辑，确保演示文稿内容安全。
- 提醒他人您提供的演示文稿是最终版本。

当您为演示文稿选择 **始终以只读方式打开** 选项后，用户打开演示文稿时，会看到 **只读** 建议，可能会看到如下信息：*为防止意外更改，作者已将此文件设置为只读打开。*

只读建议是一种简单而有效的阻慑手段，因为用户必须执行操作才能取消它，才能编辑演示文稿。如果您不希望用户对演示文稿进行更改，并希望以礼貌的方式告知他们，只读建议可能是一个不错的选择。

> 如果带有 **只读** 保护的演示文稿在较旧的 Microsoft PowerPoint 应用程序中打开——该应用程序不支持最近引入的功能——则 **只读** 建议会被忽略（演示文稿将正常打开）。

## **应用只读模式**

Aspose.Slides for C++ 允许您将演示文稿设置为 **只读**，这意味着用户（在打开演示文稿后）会看到 **只读** 建议。以下示例代码展示了如何在 C++ 中使用 Aspose.Slides 将演示文稿设置为 **只读**：

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**注意**：**只读** 建议仅用于阻止编辑或防止用户对 PowerPoint 演示文稿进行意外更改。如果有动机且懂行的人决定编辑您的演示文稿，他们可以轻松移除只读设置。如果您真的需要防止未经授权的编辑，最好使用[更严格的加密和密码保护](https://docs.aspose.com/slides/zh/cpp/password-protected-presentation/)。

{{% /alert %}} 

## **常见问题**

### “只读推荐” 与完整密码保护有什么区别？

“只读推荐”仅显示在只读模式下打开文件的建议，且容易绕过。[密码保护](/slides/zh/cpp/password-protected-presentation/) 实际限制打开或编辑，适用于需要真正安全控制的场景。

### 可以将“只读推荐”与水印结合使用以进一步阻止编辑吗？

可以。该建议可以与[水印](/slides/zh/cpp/watermark/) 组合，作为视觉阻慑；它们是独立机制，能够很好地协同工作。

### 启用该建议后，宏或外部工具仍能修改文件吗？

可以。该建议不会阻止程序化更改。要防止自动化编辑，请使用[密码和加密](/slides/zh/cpp/password-protected-presentation/)。

### “只读推荐” 与 “is encrypted” 和 “is write protected” 标志有什么关联？

它们是不同的信号。“只读推荐”是软性、可选提示；[get_IsWriteProtected](https://reference.aspose.com/slides/zh/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) 和 [get_IsEncrypted](https://reference.aspose.com/slides/zh/cpp/aspose.slides/protectionmanager/get_isencrypted/) 表示实际的写入或读取限制，这取决于密码或加密。