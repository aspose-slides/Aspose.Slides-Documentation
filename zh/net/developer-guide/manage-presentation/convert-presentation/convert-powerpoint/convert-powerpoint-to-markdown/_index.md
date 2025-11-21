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
- 将演示文稿 保存为 Markdown
- 将幻灯片 保存为 Markdown
- 将 PPT 保存为 MD
- 将 PPTX 保存为 MD
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 幻灯片（PPT、PPTX）转换为简洁的 Markdown，自动生成文档并保持格式。"
---

{{% alert color="info" %}} 
已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) 实现对 PowerPoint 到 markdown 的转换支持。
{{% /alert %}} 

{{% alert color="warning" %}} 
PowerPoint 到 markdown 的导出默认 **不包含图像**。如果要导出包含图像的 PowerPoint 文档，需要将 `ExportType = MarkdownExportType.Visual` 并设置 BasePath，以保存 markdown 文档中引用的图像。
{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例，以表示演示文稿对象。  
2. 使用 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将对象保存为 markdown 文件。

下面的 C# 代码演示如何将 PowerPoint 转换为 markdown：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格的 markdown、Trello、XWiki、GitLab，以及另外 17 种 markdown 变体。

下面的 C# 代码演示如何将 PowerPoint 转换为 CommonMark：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


这 23 种支持的 markdown 变体列在 [Flavor 枚举](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，可用于对生成的 markdown 文件使用特定的选项或设置。例如，[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为决定图像渲染或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中逐个依次出现，则需要选择 sequential 选项。下面的 C# 代码演示如何将包含图像的演示文稿转换为 markdown：
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


### **视觉转换图像**

如果希望图像在生成的 markdown 中一起出现，则需要选择 visual 选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），或者您可以指定首选的路径和文件夹名称。

下面的 C# 代码演示此操作：
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


## **常见问题**

**超链接在导出为 Markdown 时会保留吗？**  
是的。文本 [hyperlinks](/slides/zh/net/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片的 [transitions](/slides/zh/net/slide-transition/) 和 [animations](/slides/zh/net/powerpoint-animation/) 则不会被转换。

**我可以通过多线程运行来加速转换吗？**  
您可以在文件之间并行处理，但请 [不要共享](/slides/zh/net/multithreading/) 同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例跨线程使用。每个文件使用单独的实例或进程以避免竞争。

**图像会怎样处理——保存在哪里，路径是否为相对路径？**  
[Images](/slides/zh/net/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。