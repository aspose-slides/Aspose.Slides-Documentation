---
title: 使用 C++ 将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/cpp/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPTX
- PPTX 转 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松将 PPTX 转换为 PPT——确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

本文说明如何使用 C++ 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。以下主题进行了解释。

- 在 C++ 中将 PPTX 转换为 PPT

## **在 C++ 中将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C++ 示例代码，请参阅下面的章节，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为 PDF、XPS、ODP、HTML 等多种格式，详见这些文章。

- [在 C++ 中将 PPTX 转换为 PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/)
- [在 C++ 中将 PPTX 转换为 XPS](/slides/zh/cpp/convert-powerpoint-to-xps/)
- [在 C++ 中将 PPTX 转换为 HTML](/slides/zh/cpp/convert-powerpoint-to-html/)
- [在 C++ 中将 PPTX 转换为 ODP](/slides/zh/cpp/save-presentation/)
- [在 C++ 中将 PPTX 转换为 PNG](/slides/zh/cpp/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**

要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的 **Save** 方法。下面的 C++ 代码示例使用默认选项将 Presentation 从 PPTX 转换为 PPT。

```cpp
// 加载 PPTX。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// 以 PPT 格式保存。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **常见问题**

**将 PPTX 保存为传统 PPT（97–2003）格式时，所有效果和功能都会保留吗？**

并非总是如此。PPT 格式缺少某些新功能（例如特定的效果、对象和行为），因此在转换过程中可能会对功能进行简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，需要创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

是的。您可以检测文件是否受保护，使用密码打开它，并且还可以为保存的 PPT [配置保护/加密设置](/slides/zh/cpp/password-protected-presentation/)。