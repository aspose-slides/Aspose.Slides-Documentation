---
title: 在 .NET 中将 ODP 转换为 PPTX
linktitle: ODP 转 PPTX
type: docs
weight: 10
url: /zh/net/convert-odp-to-pptx/
keywords:
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 ODP
- OpenDocument 转 PPTX
- ODP 转 PPTX
- 将 ODP 保存为 PPTX
- 将 ODP 导出为 PPTX
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 ODP 转换为 PPTX。干净的 C# 代码示例、批处理技巧和高质量结果——无需 PowerPoint。"
---

## **概述**

本文解释以下主题。

- [C# 将 ODP 转换为 PPTX](#csharp-odp-to-pptx)
- [C# 将 ODP 转换为 PowerPoint](#csharp-odp-to-powerpoint)

## **ODP 到 PPTX 转换**

Aspose.Slides for .NET 提供了表示演示文稿文件的 Presentation 类。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类现在也可以通过实例化对象时的 Presentation 构造函数访问 ODP。以下示例展示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>步骤：在 C# 中将 ODP 转换为 PPTX</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>步骤：在 C# 中将 ODP 转换为 PowerPoint</strong></a>
```c#
 // 打开 ODP 文件
 Presentation pres = new Presentation("AccessOpenDoc.odp");
 
 // 将 ODP 演示文稿保存为 PPTX 格式
 pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```


## **实时示例**

您可以访问使用 **Aspose.Slides API** 构建的 [**Aspose.Slides Conversion**](https://products.aspose.app/slides/conversion/) Web 应用程序。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。

## **常见问题**

**我是否需要安装 Microsoft PowerPoint 或 LibreOffice 来将 ODP 转换为 PPTX？**

不需要。Aspose.Slides 可以独立工作，无需第三方应用程序即可读取或写入 ODP/PPTX。

**在转换过程中，母版幻灯片、布局和主题会被保留吗？**

会。该库使用完整的演示文稿对象模型，并保留结构，包括母版幻灯片和布局，因此在转换后设计保持正确。

**我可以转换受密码保护的 ODP 文件吗？**

可以。Aspose.Slides 支持检测保护状态，提供密码后可以打开和处理[受保护的演示文稿](/slides/zh/net/password-protected-presentation/)（包括 ODP），并支持配置加密和访问文档属性。

**Aspose.Slides 适用于云或基于 REST 的转换服务吗？**

可以。您可以在自己的后端使用本地库，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）；这两种方式都支持 ODP → PPTX 转换。