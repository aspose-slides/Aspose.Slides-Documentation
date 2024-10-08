---
title: 在 C# 中将 ODP 转换为 PPTX
linktitle: 将 ODP 转换为 PPTX
type: docs
weight: 10
url: /net/convert-odp-to-pptx/
keywords: "转换 OpenOffice 演示文稿，ODP，ODP 到 PPTX，C#，Csharp，.NET"
description: "在 C# 或 .NET 中将 OpenOffice ODP 转换为 PowerPoint 演示文稿 PPTX"
---

## 概览

本文解释了以下主题。

- [C# 将 ODP 转换为 PPTX](#csharp-odp-to-pptx)
- [C# 将 ODP 转换为 PowerPoint](#csharp-odp-to-powerpoint)

## C# ODP 到 PPTX 转换

Aspose.Slides for .NET 提供了表示演示文稿文件的 Presentation 类。[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类现在还可以通过 Presentation 构造函数访问 ODP，当对象被实例化时。以下示例展示了如何将 ODP 演示文稿转换为 PPTX 演示文稿。

<a name="csharp-odp-to-pptx" id="csharp-odp-to-pptx"><strong>步骤：在 C# 中将 ODP 转换为 PPTX</strong></a> |
<a name="csharp-odp-to-powerpoint" id="csharp-odp-to-powerpoint"><strong>步骤：在 C# 中将 ODP 转换为 PowerPoint</strong></a>

```c#
// 打开 ODP 文件
Presentation pres = new Presentation("AccessOpenDoc.odp");

// 将 ODP 演示文稿保存为 PPTX 格式
pres.Save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
```

## **实时示例**
您可以访问 [**Aspose.Slides 转换**](https://products.aspose.app/slides/conversion/) 网页应用程序，该应用程序是使用 **Aspose.Slides API** 构建的。该应用演示了如何使用 Aspose.Slides API 实现 ODP 到 PPTX 的转换。