---
title: 在 C# 中将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /zh/net/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, C#, Csharp, .NET, Aspose.Slides"
description: "在 C# 中将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

对 PowerPoint 转换为 Markdown 的支持已在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/net/aspose-slides-for-net-23-7-release-notes/) 中实现。

{{% /alert %}} 

{{% alert color="warning" %}} 

默认情况下，PowerPoint 到 Markdown 的导出**不包括图像**。如果您希望导出包含图像的 PowerPoint 文档，您需要设置 `ExportType = MarkdownExportType.Visual` 并设置 BasePath，以便在 Markdown 文档中引用的图像将被保存的位置。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类的实例以表示演示文稿对象。
2. 使用 [Save ](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) 方法将对象保存为 Markdown 文件。

以下 C# 代码演示了如何将 PowerPoint 转换为 Markdown：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.md", SaveFormat.Md);
}
```

## 将 PowerPoint 转换为 Markdown 风格

Aspose.Slides 允许您将 PowerPoint 转换为 Markdown（包含基本语法）、CommonMark、GitHub 风格 Markdown、Trello、XWiki、GitLab 以及其他 17 种 Markdown 风格。

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

23 种支持的 Markdown 风格在 [MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类的 [`Flavor` 枚举中列出](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/flavor/)。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供的属性和枚举允许您对结果 Markdown 文件使用某些选项或设置。 例如，[MarkdownExportType](https://reference.aspose.com/slides/net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为决定图像如何呈现或处理的值：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图像**

如果您希望图像在结果 Markdown 中一个接一个地单独出现，则必须选择顺序选项。以下 C# 代码演示了如何将包含图像的演示文稿转换为 Markdown：

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

如果您希望在结果 Markdown 中一起显示图像，则必须选择视觉选项。在这种情况下，图像将保存到应用程序的当前目录（并将在 Markdown 文档中为它们构建相对路径），或者您可以指定所需的路径和文件夹名称。

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