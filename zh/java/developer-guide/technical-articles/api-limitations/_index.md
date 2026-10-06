---
title: 输出元数据限制
type: docs
weight: 320
url: /zh/java/api-limitations/
keywords:
- API 限制
- 导出格式
- 应用程序
- 生成器
- 文档属性
- 元数据
- 生成器
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 会将固定的 application、creator 和 producer 元数据写入保存的 PPTX、PDF 和 ODP 文件，无论您设置的应用程序名称是什么。"
---
## **概述**

当使用 Aspose.Slides 创建或导出演示文稿时，某些技术元数据会写入输出文件。本文说明了 PPTX、PDF 和 ODP 文件中与 `Application`、`Creator`、`Producer` 和 generator 元数据字段相关的限制。

## **Application 和 Producer**

当您使用 Aspose.Slides for Java 创建或导出演示文稿时，文件中会写入一些技术元数据。两个字段经常引发疑问：

**Application** 标识创建或最后保存 **PPTX** 演示文稿的程序。在 Aspose.Slides for Java 中，此值是固定的，显示库名称而不是您应用程序的名称，即使您使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)。

**Producer** 标识在导出期间生成最终文件的渲染引擎。在 **PDF** 导出中，元数据使用 **Creator** 和 **Producer** 字段。使用 Aspose.Slides for Java 时，这两个字段都是固定的，反映库及其版本。

**受限内容**

您无法通过 API 覆盖上述格式的这些字段。对于 **PPTX**，Application 属性写入为 “Aspose.Slides for Java”。对于 **PDF**，Creator 和 Producer 属性写入为 “Aspose.Slides for Java”，后跟库版本。对于 **ODP**，generator 字段写入为 “Aspose.Slides for Java”，后跟库版本。此行为是设计如此，无论您如何加载或保存文件，也无论使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 分配的值如何，均会如此。

此限制不适用于 **PPT** 文件：在 PPT 文件中，使用[DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/zh/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-) 设置的应用程序名称会被保存。