---
title: 在 C++ 中将 PPTX 转换为 PPT
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

## **概览**

本文说明如何使用 C++ 将 PowerPoint 演示文稿的 PPTX 格式转换为 PPT 格式。涵盖以下主题。

- 使用 C++ 将 PPTX 转换为 PPT

## **使用 C++ 将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 C++ 示例代码，请参阅下文章节，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。它仅加载 PPTX 文件并以 PPT 格式保存。通过指定不同的保存格式，还可以将 PPTX 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，详见这些文章。

- [C++ Convert PPTX to PDF](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++ Convert PPTX to XPS](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++ Convert PPTX to HTML](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++ Convert PPTX to ODP](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++ Convert PPTX to Image](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**
要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) 类的 **Save** 方法。以下 C++ 代码示例使用默认选项将 Presentation 从 PPTX 转换为 PPT。
```cpp
// 加载 PPTX。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// 保存为 PPT 格式。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```


## **常见问题**

**所有 PPTX 的效果和功能在保存为旧版 PPT（97–2003）格式时都会保留下来吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如某些效果、对象和行为），因此在转换过程中可能会被简化或光栅化。

**我可以只将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。若要转换特定幻灯片，需要先创建仅包含这些幻灯片的新演示文稿并保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**是否支持受密码保护的演示文稿？**

支持。您可以检测文件是否受保护，使用密码打开它，并且还可以[configure protection/encryption settings](/slides/zh/cpp/password-protected-presentation/) 为保存的 PPT 配置保护/加密设置.