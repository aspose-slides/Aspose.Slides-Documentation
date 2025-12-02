---
title: API 限制
type: docs
weight: 320
url: /zh/cpp/api-limitations/
keywords:
- API 限制
- 导出格式
- 应用程序
- 生成器
- 文档属性
- 元数据
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解 Aspose.Slides for C++ 的限制：导出在 PPT、PPTX、ODP 和 PDF 中设置固定的 Application/Producer 元数据——帮助您规划集成，避免意外。"
---

## **应用程序和生成器**

当您使用 Aspose.Slides for C++ 创建或导出演示文稿时，某些技术元数据会写入文件。两个字段经常引发疑问：

**Application** 标识创建或最近保存 **PPTX** 演示文稿的程序。在 Aspose.Slides for C++ 中，此值是固定的，显示库供应商而不是您的应用程序名称，即使您使用[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/)。

**Producer** 标识在导出期间生成最终文件的渲染引擎。在 **PDF** 导出中，元数据使用 **Creator** 和 **Producer** 字段。使用 Aspose.Slides for C++ 时，这两个字段都是固定的，反映库及其版本。

**受限**

不能通过 API 覆盖上述格式的这些字段。对于 **PPTX**，Application 属性写入为 “Aspose.Slides for C++”。对于 **PDF**，Creator 和 Producer 属性写入为 “Aspose.Slides for C++ x.x.x”。此行为是设计如此，无论您如何加载或保存文件，也无论使用[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/cpp/aspose.slides/documentproperties/set_nameofapplication/) 分配的值如何，都适用。