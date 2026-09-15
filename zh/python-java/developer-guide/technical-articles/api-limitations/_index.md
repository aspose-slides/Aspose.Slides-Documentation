---
title: API 限制
type: docs
weight: 320
url: /zh/python-java/api-limitations/
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
- Python
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 的限制：PPTX 和 PDF 文件中固定的 Application、Creator 和 Producer 元数据。"
---
## **概述**

使用 Aspose.Slides 创建或导出演示文稿时，某些技术元数据会写入输出文件。本文说明了 PPTX 和 PDF 文件中与 `Application`、`Creator` 和 `Producer` 元数据字段相关的限制。

## **Application 和 Producer**

使用 Aspose.Slides for Python via Java 创建或导出演示文稿时，某些技术元数据会写入文件。两个字段经常引起疑问：

**Application** 标识创建或最后保存 **PPTX** 演示文稿的程序。在 Aspose.Slides for Python via Java 中，此值是固定的，显示库供应商而不是您的应用程序名称，即使您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#setnameofapplication) 也是如此。

**Producer** 标识在导出期间生成最终文件的渲染引擎。在 **PDF** 导出中，元数据使用 **Creator** 和 **Producer** 字段。使用 Aspose.Slides for Python via Java 时，这两个字段都是固定的，反映库及其版本。

**受限内容**

无法通过 API 覆盖上述格式的这些字段。对于 **PPTX**，Application 属性写入为 “Aspose.Slides for Java”。对于 **PDF**，Creator 和 Producer 属性写入为 “Aspose.Slides for Java x.x.x”。此行为是设计如此，且不受您如何加载或保存文件以及使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#setnameofapplication) 所分配的值的影响。

## **FAQ**

**我可以在 PPTX 文件中将 Application 值替换为我的应用程序名称吗？**

不能。该值是固定的，即使您使用 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/python-java/aspose.slides/documentproperties/#setnameofapplication) 也是如此。

**我可以在 PDF 导出中覆盖 Creator 和 Producer 字段吗？**

不能。这两个字段都是固定的，反映库及其版本，无论您如何加载或保存演示文稿。