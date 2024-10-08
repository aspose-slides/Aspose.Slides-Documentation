---
title: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /zh/net/convert-powerpoint-to-word/
keywords:
- 转换 PowerPoint
- PPT
- PPTX
- 演示文稿
- Word
- DOCX
- DOC
- PPTX 转 DOCX
- PPT 转 DOC
- PPTX 转 DOC
- PPT 转 DOCX
- C#
- Csharp
- .NET
- Aspose.Slides
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 Word "
---

如果您计划以新的方式使用演示文稿 (PPT 或 PPTX) 的文本内容或信息，您可能会受益于将演示文稿转换为 Word (DOC 或 DOCX)。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用程序在内容方面更具工具或功能。
* 除了 Word 中的编辑功能，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}} 

您可能想尝试我们的 [**在线演示文稿转 Word 转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，以查看从幻灯片中使用文本内容能获得哪些好处。

{{% /alert %}} 

### **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件 (PPTX 或 PPT) 转换为 Word (DOCX 或 DOCX)，您需要 [Aspose.Slides for .NET](https://products.aspose.com/slides/net/) 和 [Aspose.Words for .NET](https://products.aspose.com/words/net/) 两者。

作为一个独立的 API，[Aspose.Slides](https://products.aspose.app/slides) for .NET 提供了允许您从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/net/) 是一个高级文档处理 API，允许应用程序生成、修改、转换、渲染、打印文件，并在无需使用 Microsoft Word 的情况下执行其他文档任务。

## **将 PowerPoint 转换为 Word**

1. 将这些命名空间添加到您的 program.cs 文件中：

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. 使用此代码片段将 PowerPoint 转换为 Word：

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // 生成幻灯片图像并将其保存到内存流中
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // 插入幻灯片的文本
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```