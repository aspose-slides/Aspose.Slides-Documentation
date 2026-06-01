---
title: 在 .NET 中的演示文稿高级文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/net/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们的简明分步指南，节省时间。"
---
## **概述**

从演示文稿中提取文本是开发人员处理幻灯片内容时常见且必不可少的任务。无论是处理 Microsoft PowerPoint 的 PPT 或 PPTX 格式文件，还是 OpenDocument 演示文稿（ODP），访问和检索文本数据对于分析、自动化、索引或内容迁移等目的都至关重要。

本文提供了一份全面指南，说明如何使用 Aspose.Slides for .NET 高效地从各种演示文稿格式（包括 PPT、PPTX 和 ODP）中提取文本。您将学习如何系统地遍历演示文稿元素，以准确获取所需的文本内容。

## **从幻灯片提取文本**

Aspose.Slides for .NET 提供了 [Aspose.Slides.Util](https://reference.aspose.com/slides/zh/net/aspose.slides.util/) 命名空间，其中包括 [SlideUtil](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/) 类。该类公开了多个重载的静态方法，用于从演示文稿或幻灯片中提取所有文本。要从演示文稿中的幻灯片提取文本，请使用 [GetAllTextBoxes](https://reference.aspose.com/slides/zh/net/aspose.slides.util/slideutil/getalltextboxes/) 方法。该方法接受一个类型为 [IBaseSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/ibaseslide/) 的对象作为参数。执行时，方法会扫描整张幻灯片的文本，并返回一个类型为 [ITextFrame](https://reference.aspose.com/slides/zh/net/aspose.slides/itextframe/) 的对象数组，保留任何文本格式。

以下代码片段提取了演示文稿第一张幻灯片的所有文本：

{{a13aa1f4-03f6-47c3-af95-8e1d2b5e