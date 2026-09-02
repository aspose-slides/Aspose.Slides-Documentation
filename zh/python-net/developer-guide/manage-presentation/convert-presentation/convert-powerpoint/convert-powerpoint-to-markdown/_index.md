---
title: 将 PowerPoint 演示文稿转换为 Python 中的 Markdown
linktitle: PowerPoint 转 Markdown
type: docs
weight: 140
url: /zh/python-net/convert-powerpoint-to-markdown/
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
- Markdown 图像导出
- CDN 图像链接
- PowerPoint
- 演示文稿
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "在 Python 中将 PPT 和 PPTX 演示文稿转换为 Markdown，并控制导出图像的保存位置以及生成的 Markdown 如何引用这些图像。"
---
## **概述**

Aspose.Slides for Python via .NET 可以将 PPT 和 PPTX 演示文稿转换为 Markdown，以用于文档、静态站点、内容迁移和版本控制工作流。您可以选择 Markdown 的变体，控制幻灯片内容的渲染方式，并决定导出图像的存储位置以及生成的 Markdown 如何引用它们。

默认情况下，Markdown 导出使用仅文本输出。若要导出可视内容，请将 [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/export_type/) 属性设置为 [MarkdownExportType](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownexporttype/) 枚举中的 `SEQUENTIAL` 或 `VISUAL` 值。`SEQUENTIAL` 将幻灯片项分别且按顺序渲染，而 `VISUAL` 将分组的项保持在一起，以保留它们的视觉关系。`TEXT_ONLY` 值不会生成图像资源。

## **将演示文稿转换为 Markdown**

使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 类加载源文件，然后调用 [Presentation.save](https://reference.aspose.com/slides/zh/python-net/aspose.slides/ipresentation/save/) 方法，并使用来自 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 枚举的 `MD` 值。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **选择 Markdown 变体**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/flavor/) 属性控制输出所使用的 Markdown 规范。[Flavor](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/flavor/) 枚举包括 CommonMark、GitHub Flavored Markdown 以及其他受支持的变体。

以下示例将演示文稿导出为 CommonMark：

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **使用默认本地保存行为导出图像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/) 类提供两个用于本地保存图像的属性：

- [base_path](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 指定 Markdown 文档及其资源的基础目录。
- [images_save_folder_name](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) 指定图像子目录。其默认值为 `Images`。

以下示例渲染可视内容，将图像写入 `output/assets`，并在 Markdown 文档中创建相对图像引用：

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

当导出生成图像资源时，Aspose.Slides 会创建图像子目录，但应用程序必须在保存 Markdown 文件之前创建 `base_path`。

## **准备 Markdown 和图像以供发布**

Aspose.Slides for Python via .NET 不公开 .NET 的图像保存回调，以在导出期间替换每个生成的图像链接。相反，应将 Markdown 文档及其图像文件夹导出到发布目录，然后在不更改相对结构的情况下发布该目录。

以下示例将 `cdn-origin/presentations/quarterly-report` 准备为挂载或同步的发布目录。示例本身不执行网络上传：目录在目标站点或 CDN 位置发布后，生成的链接即可生效。

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

将 `presentation.md` 与 `assets` 目录一起发布。Markdown 文档使用相对图像引用，因此两者在目标位置必须保持相同的关系。如果发布系统需要绝对的外部 URL，请在所有图像文件发布后，将生成的链接作为单独的后处理步骤进行重写。

## **常见问题**

**Python 回调能在 Markdown 导出期间自定义单个图像文件和链接吗？**

不。Aspose.Slides for Python via .NET 不公开 .NET 的 `ImageSaving` 和 `SvgImageSaving` 回调。请使用 [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 和 [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) 配置本地输出，然后发布或对生成的资源进行后处理。

**导出的图像保存在哪里？**

图像位置由 [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/base_path/) 和 [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) 控制。Markdown 文档使用相对路径引用这些图像。

**图像链接应使用哪种路径分隔符？**

在 Markdown 链接和 URL 中使用正斜杠。`os.path.join` 仅用于文件系统路径，并在后处理时单独对任何生成的链接进行规范化。

**在 Markdown 导出期间超链接会被保留吗？**

是的。文本 [hyperlinks](/slides/zh/python-net/manage-hyperlinks/) 会保留为标准的 Markdown 链接。幻灯片的 [transitions](/slides/zh/python-net/slide-transition/) 和 [animations](/slides/zh/python-net/powerpoint-animation/) 不会被转换。

**可以并行将演示文稿转换为 Markdown 吗？**

可以并行处理不同的演示文稿文件，但不要在多个线程之间共享同一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例。请遵循 [multithreading guidelines](/slides/zh/python-net/multithreading/) 并为每个文件使用单独的实例。