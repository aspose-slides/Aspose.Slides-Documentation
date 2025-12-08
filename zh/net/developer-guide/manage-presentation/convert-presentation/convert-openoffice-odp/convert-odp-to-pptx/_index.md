---
title: 在 C# 中将 ODP 转换为 PPTX
linktitle: 将 ODP 转换为 PPTX
type: docs
weight: 10
url: /zh/net/convert-odp-to-pptx/
keywords: "转换 OpenOffice 演示文稿, ODP, ODP 转 PPTX, C#, Csharp, .NET"
description: "在 C# 或 .NET 中将 OpenOffice ODP 转换为 PowerPoint 演示文稿 PPTX"
---

## **概述**

本文解释以下主题。

- [C# 将 ODP 转换为 PPTX](#csharp-odp-to-pptx)
- [C# 将 ODP 转换为 PowerPoint](#csharp-odp-to-powerpoint)

## **ODP 转 PPTX 转换**

Aspose.Slides for .NET 提供表示演示文稿文件的 Presentation 类。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类现在还可以通过实例化对象时的 Presentation 构造函数访问 ODP。下面的示例演示如何将 ODP 演示文稿转换为 PPTX 演示文稿。

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

**是否需要安装 Microsoft PowerPoint 或 LibreOffice 来将 ODP 转换为 PPTX？**

不需要。Aspose.Slides 可独立工作，无需第三方应用程序即可读取或写入 ODP/PPTX。

**转换期间是否会保留母版幻灯片、版式和主题？**

会。该库使用完整的演示对象模型并保留结构，包括母版幻灯片和版式，从而在转换后保持设计的正确性。

**我可以转换受密码保护的 ODP 文件吗？**

可以。Aspose.Slides 支持检测保护状态，在提供密码后能够打开和处理 [protected presentations](/slides/zh/net/password-protected-presentation/)（包括 ODP），并且可以配置加密和访问文档属性。

**Aspose.Slides 适用于云或基于 REST 的转换服务吗？**

可以。您可以在自己的后端使用本地库，或使用 [Aspose.Slides Cloud](https://products.aspose.cloud/slides/family/)（REST API）；这两种方式均支持 ODP → PPTX 转换。