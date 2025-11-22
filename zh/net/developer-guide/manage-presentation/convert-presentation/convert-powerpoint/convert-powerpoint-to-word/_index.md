---
title: 在 C# 中将 PowerPoint 演示文稿转换为 Word 文档
linktitle: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /zh/net/convert-powerpoint-to-word/
keywords:
- PowerPoint 转 DOCX
- OpenDocument 转 DOCX
- 演示文稿 转 DOCX
- 幻灯片 转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- ODP 转 DOCX
- PowerPoint 转 DOC
- OpenDocument 转 DOC
- 演示文稿 转 DOC
- 幻灯片 转 DOC
- PPT 转 DOC
- PPTX 转 DOC
- ODP 转 DOC
- PowerPoint 转 Word
- OpenDocument 转 Word
- 演示文稿 转 Word
- 幻灯片 转 Word
- PPT 转 Word
- PPTX 转 Word
- ODP 转 Word
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- 转换 ODP
- C#
- .NET
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档。我们的分步指南提供示例 C# 代码，为希望简化文档工作流的开发人员提供解决方案。"
---

## **概览**

本文为开发人员提供了使用 Aspose.Slides for .NET 和 Aspose.Words for .NET 将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档的解决方案。该分步指南将带您逐步完成转换过程的每个阶段。

## **将演示文稿转换为 Word 文档**

请按照以下说明将 PowerPoint 或 OpenDocument 演示文稿转换为 Word 文档：

1. 实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类并加载演示文稿文件。  
2. 实例化 [Document](https://reference.aspose.com/words/net/aspose.words/document/) 和 [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 类以生成 Word 文档。  
3. 使用 [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 属性将 Word 文档的页面大小设置为与演示文稿相匹配。  
4. 使用 [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 属性设置 Word 文档的页边距。  
5. 使用 [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) 属性遍历所有演示文稿幻灯片。  
    - 使用来自 [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) 接口的 `GetImage` 方法生成幻灯片图像并将其保存到内存流中。  
    - 使用 [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 类的 `InsertImage` 方法将幻灯片图像添加到 Word 文档中。  
6. 将 Word 文档保存到文件。

假设我们有一个名为 “sample.pptx” 的演示稿，其外观如下：

![PowerPoint 演示文稿](PowerPoint.png)

以下 C# 代码示例演示如何将 PowerPoint 演示文稿转换为 Word 文档：
```cs
// 加载演示文稿文件.
using var presentation = new Presentation("sample.pptx");

// 创建 Document 和 DocumentBuilder 对象.
var document = new Document();
var builder = new DocumentBuilder(document);

// 在 Word 文档中设置页面大小.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// 在 Word 文档中设置页边距.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// 遍历所有演示文稿幻灯片.
foreach (var slide in presentation.Slides)
{
    // 生成幻灯片图像并保存到内存流.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // 将幻灯片图像添加到 Word 文档.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// 将 Word 文档保存到文件.
document.Save("output.docx");
```


结果：

![Word 文档](Word.png)

{{% alert color="primary" %}} 
尝试我们的 [**在线 PPT 转 Word 转换器**](https://products.aspose.app/slides/conversion/ppt-to-word) ，了解将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档可以带来哪些收益。 
{{% /alert %}}

## **常见问题**

**转换 PowerPoint 和 OpenDocument 演示文稿为 Word 文档需要安装哪些组件？**

您只需在 C# 项目中添加对应的 NuGet 包 [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) 和 [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/)。这两个库均以独立 API 形式运行，无需安装 Microsoft Office。

**是否支持所有 PowerPoint 和 OpenDocument 演示文稿格式？**

Aspose.Slides for .NET [支持所有演示文稿格式](/slides/zh/net/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常见文件类型。这确保您能够处理由不同版本 Microsoft PowerPoint 创建的演示文稿。