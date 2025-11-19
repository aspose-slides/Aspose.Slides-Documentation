---
title: 在 Python 中将 PowerPoint 演示文稿转换为 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/python-net/convert-powerpoint-to-markdown/
keywords:
- 转换 PowerPoint 为 Markdown
- 转换 OpenDocument 为 Markdown
- 转换演示文稿为 Markdown
- 转换幻灯片为 Markdown
- 转换 PPT 为 Markdown
- 转换 PPTX 为 Markdown
- 转换 ODP 为 Markdown
- 转换 PowerPoint 为 MD
- 转换 OpenDocument 为 MD
- 转换演示文稿为 MD
- 转换幻灯片为 MD
- 转换 PPT 为 MD
- 转换 PPTX 为 MD
- 转换 ODP 为 MD
- PowerPoint
- OpenDocument
- 演示文稿
- Markdown
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 幻灯片（PPT、PPTX、ODP）转换为干净的 Markdown，自动化文档编写并保持格式。"
---

## **将演示文稿转换为 Markdown**

下面的示例展示了使用 Aspose.Slides for Python via .NET 并使用默认设置，将 PowerPoint 演示文稿转换为 Markdown 的最简方法。

1. 实例化一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 来加载演示文稿。
2. 调用 `save` 将其导出为 Markdown 文件。

使用下面的 Python 代码片段执行转换：
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```


## **将演示文稿转换为 Markdown 变体**

Aspose.Slides 允许您将演示文稿转换为 Markdown 格式，包括基本 Markdown、CommonMark、GitHub 风格的 Markdown、Trello、XWiki、GitLab 以及其他 17 种 Markdown 变体。

下面的 Python 示例展示了如何将 PowerPoint 演示文稿转换为 CommonMark：
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```


这 23 种受支持的 Markdown 变体列在 [Flavor](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/flavor/) 枚举以及 [MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类中。

## **将包含图像的演示文稿转换为 Markdown**

[MarkdownSaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownsaveoptions/) 类提供属性和枚举，可让您配置生成的 Markdown 文件。例如，[MarkdownExportType](https://reference.aspose.com/slides/python-net/aspose.slides.dom.export.markdown.saveoptions/markdownexporttype/) 枚举控制图像的处理方式：`SEQUENTIAL`、`TEXT_ONLY` 或 `VISUAL`。

### **顺序转换图像**

如果您希望图像在生成的 Markdown 中逐个出现——一个接一个——请选择 `SEQUENTIAL` 选项。下面的 Python 示例展示了如何将包含图像的演示文稿转换为 Markdown。
```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```


### **视觉化转换图像**

如果您希望图像在生成的 Markdown 中一起出现，请选择 `VISUAL` 选项。在此模式下，图像会保存到应用程序的当前目录（Markdown 文档使用相对路径），您也可以指定自定义的输出路径和文件夹名称。

下面的 Python 示例演示了此操作：
```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```


## **FAQ**

**超链接在导出为 Markdown 时是否会保留？**

是的。文本 [hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片的 [transitions](/slides/zh/python-net/slide-transition/) 和 [animations](/slides/zh/python-net/powerpoint-animation/) 则不会被转换。

**我可以通过多线程运行来加速转换吗？**

您可以在文件之间并行处理，但请 [don’t share](/slides/zh/python-net/multithreading/) 同一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 实例跨线程使用。每个文件使用单独的实例或进程以避免争用。

**图像会怎样处理——它们保存在哪里，路径是相对的吗？**

[Images](/slides/zh/python-net/image/) 被导出到专用文件夹，Markdown 文件默认使用相对路径引用它们。您可以配置基础输出路径和资产文件夹名称，以保持可预测的仓库结构。