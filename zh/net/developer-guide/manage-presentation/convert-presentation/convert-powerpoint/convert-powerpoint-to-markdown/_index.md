---
title: 在 C# 中将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /zh/net/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 中将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) 中实现对 PowerPoint 到 markdown 转换的支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 markdown 的导出 **不包含图像**。如果您想导出包含图像的 PowerPoint 文档，需要将 `ExportType = MarkdownExportType.Visual` 设置为相应值，并设置 BasePath，以便将 markdown 文档中引用的图像保存到该路径。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例以表示演示文稿对象。  
2. 使用 [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save)method 将对象保存为 markdown 文件。

以下 C# 代码演示如何将 PowerPoint 转换为 markdown：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```


## **将 PowerPoint 转换为 Markdown 变体**

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格 markdown、Trello、XWiki、GitLab 以及另外 17 种 markdown 变体。

以下 C# 代码演示如何将 PowerPoint 转换为 CommonMark：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md, new MarkdownSaveOptions
    {
        Flavor = Flavor.CommonMark
    });
}
```


23 种受支持的 markdown 变体已在 [Flavor 枚举](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中列出，属于 [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，允许您为生成的 markdown 文件使用特定选项或设置。例如，可将 [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举设置为 `Sequential`、`TextOnly`、`Visual`，以决定图像的呈现或处理方式。

### **顺序转换图像**

如果希望图像在生成的 markdown 中依次单独出现，请选择 **Sequential** 选项。以下 C# 代码演示如何将包含图像的演示文稿转换为 markdown：
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

如果希望图像在生成的 markdown 中一起出现，请选择 **Visual** 选项。此时，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定您偏好的路径和文件夹名称。

以下 C# 代码演示该操作：
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

**超链接在导出为 Markdown 时会被保留吗？**

是的。文本 [hyperlinks](/slides/zh/net/manage-hyperlinks/) 会被保留为标准的 Markdown 链接。幻灯片 [transitions](/slides/zh/net/slide-transition/) 和 [animations](/slides/zh/net/powerpoint-animation/) 则不被转换。

**我可以通过多线程运行来加快转换速度吗？**

可以对文件进行并行处理，但请勿在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例。每个文件使用独立的实例或进程，以避免竞争。

**图像会怎样处理——它们保存在哪里，路径是否相对？**

[Images](/slides/zh/net/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资产文件夹名称，以保持仓库结构的可预测性。