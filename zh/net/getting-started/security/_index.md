---
title: 安全
type: docs
weight: 160
url: /zh/net/security/
keywords:
- 安全
- 依赖项
- 第三方组件
- NuGet
- 漏洞扫描
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 如何处理演示文稿、它在每个目标框架下依赖的 NuGet 包以及包含的第三方组件。"
---
## **Aspose.Slides 中的安全性**

Aspose 在开发产品时遵循最佳实践。

* Aspose.Slides for .NET 用于操作演示文稿并将其转换为其他格式。它不会在演示文稿中运行脚本。Aspose.Slides 解析演示文稿的结构，并让最终用户的代码以便捷的方式操作对象模型。
* Aspose.Slides 作为库解析并解释文档，而不执行远程代码。所有 Aspose 产品都在您的机器上运行。它们不会将任何数据传输给 Aspose。唯一的例外是[计量许可证](https://purchase.aspose.com/faqs/licensing/metered)：如果使用该许可证，只会处理您的 API 使用信息。
* Aspose 组件在与普通应用程序相同的用户上下文中运行。因此，Aspose 组件不会对关键系统资源构成风险。此外，当 Aspose 组件打开文档时，宏不会自动运行。
* 与 Microsoft Office 套件相关的内在风险不适用于 Aspose 组件，因此 Aspose 产品非常安全。

## **NuGet 依赖项**

Aspose.Slides for .NET 依赖于 Microsoft 在 NuGet 上发布的程序包。依赖项随程序包和目标框架而异：

| 程序包 | 目标框架 | 依赖项 |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) 和 [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) 在 NuGet 上的页面的 **Dependencies** 部分列出了每次发布的每个依赖项的最低版本。

将 Aspose.Slides 添加到项目时，NuGet 还会恢复这些程序包的依赖项。要列出项目恢复的每个程序包（包括这些传递依赖项），请在项目文件夹中运行以下命令：

```bash
dotnet list package --include-transitive
```

要将同一套程序包与已知漏洞进行检查，请运行：

```bash
dotnet list package --vulnerable --include-transitive
```

有关审计 NuGet 程序包的其他方法，请参阅[审计软件包依赖项的安全漏洞](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages)。

## **第三方组件**

Aspose.Slides 包含来自第三方开源组件的代码。它们是产品的一部分，而不是单独的 NuGet 程序包，因此仅读取 NuGet 依赖项的工具不会列出它们。两个程序包都包含文件 *thirdpartylicenses.Aspose.Slides.for.NET.pdf*，其中列出了组件及其许可证：

| 组件 | 通知中声明的许可证 |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **常见问题**

**用于监控 Aspose 代码漏洞的系统是什么？**

我们对每个 Aspose.Slides 版本进行静态代码分析。我们可以提供安全报告，证明 Aspose.Slides 代码通过了 OWASP Top 10。

**Aspose.Slides 使用外部程序包吗？**

是的。它依赖于[NuGet 依赖项](#nuget-依赖项)中列出的 Microsoft NuGet 程序包，并包含[第三方组件](#第三方组件)中列出的第三方组件。在进行安全审查时请同时考虑两者，并使用 `dotnet list package --vulnerable --include-transitive` 检查项目恢复的 NuGet 程序包。