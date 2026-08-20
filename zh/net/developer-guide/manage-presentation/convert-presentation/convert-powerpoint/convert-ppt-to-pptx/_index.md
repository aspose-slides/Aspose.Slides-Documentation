---
title: 在 .NET 中将 PPT 转换为 PPTX
linktitle: PPT 转 PPTX
type: docs
weight: 20
url: /zh/net/convert-ppt-to-pptx/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- PPT 转 PPTX
- 将 PPT 保存为 PPTX
- 导出 PPT 为 PPTX
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides 在 .NET 中将传统 PPT 文件转换为 PPTX。包括单文件和批量转换的 C# 示例、错误处理以及保真度说明。"
---
## **概述**

PPT 是传统的二进制 PowerPoint 格式，而 PPTX 是更新的 Open XML 格式。Aspose.Slides for .NET 可以在没有 Microsoft PowerPoint 的情况下加载 PPT 文件并将其保存为 PPTX。本文展示了如何转换单个文件或整个目录的文件，并说明转换后需要检查哪些内容。

## **将 PPT 文件转换为 PPTX**

使用 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 类加载源文件，然后调用 [IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/) 并使用 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/)。`using` 声明在作用域结束时释放演示文稿并清理其资源。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// 加载传统的 PPT 演示文稿。
using var presentation = new Presentation("presentation.ppt");

// 以 PPTX 格式保存演示文稿。
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

文件扩展名本身不会决定输出格式；是 [SaveFormat.Pptx](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveformat/) 参数决定的。如果需要保留原始 PPT 文件，请确保输入和输出路径不同。

## **批量转换 PPT 文件**

以下示例将一个目录中的每个 `.ppt` 文件进行转换。每个文件独立处理，单个转换失败不会阻止其余批次继续。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

对于生产环境，请记录完整的异常信息，决定是否可以覆盖已有的输出文件，并将失败的文件名写入重试或审查队列。损坏的文件、未提供所需密码的受密码保护文件、不可访问的路径以及不受支持的内容都可能导致转换失败。有关加载加密文件，请参阅 [Password-Protected Presentations](/slides/zh/net/password-protected-presentation/)。

## **保真度和遗留功能**

转换通常会保留幻灯片、母版、版式、文本、形状、图像、表格和图表。然而，PPT 与 PPTX 并未以完全相同的方式表示所有特性。没有 PPTX 等价物的遗留功能，或库不支持的功能，可能会被标准化、省略或以不同方式显示。

当转换后的文件包含动画、过渡、嵌入或链接的 OLE 对象、ActiveX 控件、嵌入媒体、非主流字体或 VBA 宏时，请仔细检查。普通的 PPTX 文件不是宏启用格式，若必须保留 VBA，请使用相应的宏启用工作流。同时确认所需字体和外部资源在将要打开或渲染该演示文稿的环境中可用。

对于重要文档，建议在程序中重新打开生成的 PPTX，检查关键幻灯片数量和内容，然后在目标查看器中比较其外观和放映行为。不要把一次成功的 [IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/) 调用视为所有遗留功能在 PPTX 中都有精确对应的证明。

## **何时使用 PPTX**

当演示文稿将在当前版本的 PowerPoint 中编辑、与使用 Open XML 包的系统交换，或需要一种比传统二进制 PPT 更易检查和恢复的存储格式时，请使用 PPTX。保留原始 PPT 作为归档或回滚副本，直至转换后的演示文稿通过您的保真度检查。

如果您需要 PDF、HTML、图像、XPS 或其他输出类型，请参考 [Convert Presentations to Multiple Formats](/slides/zh/net/convert-presentation/) 中的特定格式指南，而不要假设所有目标都能保留可编辑的 PowerPoint 功能。

## **在线转换器**

对于偶尔的文件或快速比较，您可以使用 [online PPT to PPTX converter](https://products.aspose.app/slides/zh/conversion/ppt-to-pptx)。对于可重复的转换、批处理或应用级错误处理，请使用 .NET API。

## **相关文章**

- [PPT 与 PPTX](/slides/zh/net/ppt-vs-pptx/)
- [在 .NET 中保存演示文稿](/slides/zh/net/save-presentation/)
- [支持的文件格式](/slides/zh/net/supported-file-formats/)
- [在 .NET 中打开演示文稿](/slides/zh/net/open-presentation/)

## **常见问题**

**我可以在未安装 Microsoft PowerPoint 的情况下将 PPT 转换为 PPTX 吗？**

可以。Aspose.Slides for .NET 在不需要 Microsoft PowerPoint 的情况下加载和保存演示文稿文件。

**PPT 转换为 PPTX 时会完全保留所有内容吗？**

它会保留常见的演示文稿内容，但并不能保证每个遗留或不受支持的特性都能完全忠实。若文件包含宏、OLE 或 ActiveX 对象、媒体、专用动画或非主流字体，请审查生成的文件。

**我可以转换受密码保护的 PPT 文件吗？**

可以，只要在加载文件时提供正确的密码。缺少或错误的密码会导致加载操作失败。

**转换后我应该删除 PPT 文件吗？**

请保留原始文件，直至在您关心的查看器和工作流中验证 PPTX。这样可以在遗留特性转换出现差异时提供回滚副本。