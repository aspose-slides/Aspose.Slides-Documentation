---
title: 将 PowerPoint 演示文稿转换为 .NET 中的 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/net/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 MD
- 演示文稿 转 MD
- 幻灯片 转 MD
- PPT 转 MD
- PPTX 转 MD
- 将 PowerPoint 保存为 Markdown
- 将演示文稿保存为 Markdown
- 将幻灯片保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 将 PPT 导出为 MD
- 将 PPTX 导出为 MD
- PowerPoint
- 演示文稿
- Markdown
- .NET
- C#
- Aspose.Slides
description: 使用 Aspose.Slides for .NET 将 PowerPoint 幻灯片（PPT、PPTX）转换为干净的 Markdown，自动生成文档并保持格式。
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 的转换支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 的导出默认 **不包含图像**。如果要导出包含图像的 PowerPoint 文档，需要将 `ExportType = MarkdownExportType.Visual` 并设置 BasePath，以确定 markdown 文档中引用的图像保存位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，以表示演示文稿对象。  
2. 使用 [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method 将对象保存为 markdown 文件。

以下 C# 代码演示了如何将 PowerPoint 转换为 markdown：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab 等 17 种其他 markdown 变体。

以下 C# 代码演示了如何将 PowerPoint 转换为 CommonMark：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 种受支持的 markdown 变体请参见 [Flavor 枚举](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中的列出内容，位于 [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为以下值，以决定图像的渲染或处理方式：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个依次出现，需要选择顺序选项。以下 C# 代码演示了如何将包含图像的演示文稿转换为 markdown：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    MarkdownSaveOptions markdownSaveOptions = new MarkdownSaveOptions
    {
        ShowHiddenSlides = true,
        ShowSlideNumber = true,
        Flavor = Flavor.Github,
        ExportType = MarkdownExportType.Sequential,
        NewLineType = NewLineType.Windows
    };
    
    pres.Save("doc.md", new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, SaveFormat.Md, markdownSaveOptions);
}
```


### **可视化转换图像**

如果希望图像在生成的 markdown 中一起出现，需要选择可视化选项。此情况下，图像将保存到应用程序的当前目录（在 markdown 文档中会为其生成相对路径），也可以指定您偏好的路径和文件夹名称。

以下 C# 代码演示了该操作：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    const string outPath = "c:\\documents";
    pres.Save(Path.Combine(outPath, "pres.md"), SaveFormat.Md, new MarkdownSaveOptions
    { 
        ExportType = MarkdownExportType.Visual,
        ImagesSaveFolderName = "md-images",
        BasePath = outPath
    });
}
```


## **FAQ**

**超链接在导出为 Markdown 后是否仍然有效？**

是的。文本 [hyperlinks](/slides/zh/net/manage-hyperlinks/) 会被保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/net/slide-transition/) 和 [animations](/slides/zh/net/powerpoint-animation/) 不会被转换。

**可以通过多线程来加速转换吗？**

可以在文件层面并行处理，但请 **不要在多个线程之间共享** 同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例。针对每个文件使用单独的实例或进程以避免竞争。

**图像会怎样处理——保存在哪里，路径是否为相对路径？**

[Images](/slides/zh/net/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。