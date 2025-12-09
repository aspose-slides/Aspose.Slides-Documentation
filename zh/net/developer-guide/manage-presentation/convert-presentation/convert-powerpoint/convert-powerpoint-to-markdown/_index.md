---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/net/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
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
- 导出 PPT 为 MD
- 导出 PPTX 为 MD
- PowerPoint
- 演示文稿
- Markdown
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 幻灯片—PPT、PPTX—转换为简洁的 Markdown，实现文档自动化并保持格式。"
---

{{% alert color="info" %}} 

PowerPoint 到 markdown 转换的支持已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) 中实现。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 markdown 的导出默认 **不含图像**。如果要导出包含图像的 PowerPoint 文档，需要将 `ExportType = MarkdownExportType.Visual` 并设置 BasePath，以便将 markdown 文档中引用的图像保存到该路径。

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

Aspose.Slides 允许您将 PowerPoint 转换为 markdown（包含基本语法）、CommonMark、GitHub 风格 markdown、Trelo、XWiki、GitLab 以及其他 17 种 markdown 变体。

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


支持的 23 种 markdown 变体列在 [Flavor 枚举](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 中，来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，可让您为生成的 markdown 文件使用特定选项或设置。例如，可将 [MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举设置为决定图像渲染或处理方式的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果希望图像在生成的 markdown 中一个接一个地单独出现，需要选择 sequential 选项。下面的 C# 代码演示如何将包含图像的演示文稿转换为 markdown：
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

如果希望图像在生成的 markdown 中一起出现，需要选择 visual 选项。在这种情况下，图像将保存到应用程序的当前目录（并在 markdown 文档中为其构建相对路径），也可以指定您偏好的路径和文件夹名称。

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

是的。文本 [hyperlinks](/slides/zh/net/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片的 [transitions](/slides/zh/net/slide-transition/) 和 [animations](/slides/zh/net/powerpoint-animation/) 不会被转换。

**我可以通过多线程运行来加速转换吗？**

可以对文件进行并行处理，但请 [不要共享](/slides/zh/net/multithreading/) 同一个 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 实例跨线程使用。每个文件使用单独的实例/进程以避免竞争。

**图像会怎样处理——保存在哪里，路径是否为相对路径？**

[Images](/slides/zh/net/image/) 会导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资源文件夹名称，以保持可预测的仓库结构。