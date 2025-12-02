---
title: API 限制
type: docs
weight: 320
url: /zh/net/api-limitations/
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
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的限制：导出时在 PPT、PPTX、ODP 和 PDF 中设置固定的 Application/Producer 元数据——帮助您在集成时做好规划，避免意外。"
---

## **应用程序和生成器**

当您使用 Aspose.Slides for .NET 创建或导出演示文稿时，文件中会写入一些技术元数据。有两个字段经常会引起疑问：

**Application** 标识创建或最后保存 **PPTX** 演示文稿的程序。在 Aspose.Slides for .NET 中，此值是固定的，显示库供应商而不是您的应用程序名称，即使您设置了 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/)。

**Producer** 标识在导出期间生成最终文件的渲染引擎。在 **PDF** 导出时，元数据使用 **Creator** 和 **Producer** 字段。使用 Aspose.Slides for .NET 时，这两个字段都是固定的，并反映库及其版本。

**受限内容**

您无法通过 API 覆盖上述格式的这些字段。对于 **PPTX**，Application 属性写入为 “Aspose.Slides for .NET”。对于 **PDF**，Creator 和 Producer 属性写入为 “Aspose.Slides for .NET x.x.x”。这种行为是设计如此，无论您如何加载或保存文件，也无论在 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/nameofapplication/) 中分配了何种值，均会如此。