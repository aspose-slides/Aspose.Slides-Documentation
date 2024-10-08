---
title: 在 Python 中将 PowerPoint 转换为 Markdown
type: docs
weight: 140
url: /python-net/convert-powerpoint-to-markdown/
keywords: "将 PowerPoint 转换为 Markdown, 将 ppt 转换为 md, PowerPoint, PPT, PPTX, 演示文稿, Markdown, Python, Aspose.Slides for Python via .NET"
description: "在 Python 中将 PowerPoint 转换为 Markdown"
---

{{% alert color="info" %}} 

在 [Aspose.Slides 23.7](https://docs.aspose.com/slides/python-net/aspose-slides-for-python-net-23-7-release-notes/) 中实现了 PowerPoint 到 Markdown 的转换支持。

{{% /alert %}} 

{{% alert color="warning" %}} 

PowerPoint 到 Markdown 导出默认是 **不包含图片** 的。如果您想导出包含图片的 PowerPoint 文档，您需要设置 `saveOptions.export_type = MarkdownExportType.VISUAL`，还要设置 `base_path`，以便在 Markdown 文档中引用的图片将被保存。

{{% /alert %}} 

## **将 PowerPoint 转换为 Markdown**

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例以表示演示文稿对象。
2. 使用 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#methods) 方法将对象保存为 Markdown 文件。

以下 Python 代码展示了如何将 PowerPoint 转换为 Markdown： 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:  
    pres.save("pres.md", slides.export.SaveFormat.MD)
```

## 将 PowerPoint 转换为 Markdown 风格

Aspose.Slides 允许您将 PowerPoint 转换为 Markdown（包含基本语法）、CommonMark、GitHub 风格的 Markdown、Trello、XWiki、GitLab 以及其他 17 种 Markdown 风格。

以下 Python 代码展示了如何将 PowerPoint 转换为 CommonMark： 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, Flavor
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    saveOptions = MarkdownSaveOptions()
    saveOptions.flavor = Flavor.COMMONMARK

    pres.save("pres.md", SaveFormat.MD, saveOptions)
```

支持的 23 种 Markdown 风格在 [Flavor 枚举下列出](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 来自 [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类。

## **将包含图片的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供了属性和枚举，允许您为生成的 Markdown 文件使用某些选项或设置。例如，[MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举可以设置为各种值，以决定图片的渲染或处理方式：`Sequential`、`TextOnly`、`Visual`。

### **顺序转换图片**

如果您希望图片在生成的 Markdown 中一个接一个地单独出现，则必须选择顺序选项。以下 Python 代码展示了如何将包含图片的演示文稿转换为 Markdown： 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    markdownSaveOptions = slides.export.MarkdownSaveOptions()
    markdownSaveOptions.show_hidden_slides = True
    markdownSaveOptions.show_slide_number = True
    markdownSaveOptions.flavor = slides.export.Flavor.GITHUB
    markdownSaveOptions.export_type = slides.export.MarkdownExportType.SEQUENTIAL
    markdownSaveOptions.new_line_type = slides.export.NewLineType.WINDOWS
    
    pres.save("doc.md", [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ], slides.export.SaveFormat.MD, markdownSaveOptions)
```

### **视觉转换图片**

如果您希望图片在生成的 Markdown 中一起出现，则必须选择视觉选项。在这种情况下，图片将被保存到应用程序的当前目录（并且将为它们在 Markdown 文档中构建相对路径），或者您可以指定您选择的路径和文件夹名称。

以下 Python 代码演示了这个操作： 

```python
from aspose.slides import Presentation
from aspose.slides.dom.export.markdown.saveoptions import MarkdownSaveOptions, MarkdownExportType
from aspose.slides.export import SaveFormat

with Presentation("pres.pptx") as pres:  
    outPath = "c:\\documents"

    saveOptions = MarkdownSaveOptions()
    saveOptions.export_type = MarkdownExportType.VISUAL
    saveOptions.images_save_folder_name = "md-images"
    saveOptions.base_path = outPath

    pres.save(outPath + "\\pres.md", SaveFormat.MD, saveOptions)
```