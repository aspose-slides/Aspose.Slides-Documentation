---
title: 在 Python 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-html/
keywords:
  - 转换 PowerPoint
  - 转换演示文稿
  - 转换幻灯片
  - 转换 PPT
  - 转换 PPTX
  - PowerPoint 转 HTML
  - 演示文稿转 HTML
  - 幻灯片转 HTML
  - PPT 转 HTML
  - PPTX 转 HTML
  - 将 PowerPoint 保存为 HTML
  - 将演示文稿保存为 HTML
  - 将幻灯片保存为 HTML
  - 将 PPT 保存为 HTML
  - 将 PPTX 保存为 HTML
  - 导出 PPT 为 HTML
  - 导出 PPTX 为 HTML
  - Python
  - Aspose.Slides
description: "在 Python 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for Python via .NET 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需加载一个 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 并使用 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 调用 `save`。当需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入方式和引用方式。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，绝大多数资源都嵌入其中。这对于共享单个文件很方便，但会增加输出大小。对于 Web 发布，请考虑使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，请使用 [Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 加载，然后使用 [SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/) 保存。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

此示例会写入一个 HTML 文件。`with` 语句在导出后会释放演示文稿对象并关闭文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `slides_layout_options`：添加备注、批注、讲义或其他布局信息。
- `html_formatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `slide_image_format`：更改幻灯片的表示方式，例如作为 SVG。
- `pictures_compression`：控制图像 DPI 和输出大小。
- `delete_pictures_cropped_areas`：保留或删除裁剪的图像数据。
- `svg_responsive_layout`：使导出的 SVG 内容适应其容器。
- `show_hidden_slides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，以便您仅组合工作流所需的部分。

## **将选定幻灯片转换为 HTML**

接受幻灯片编号的 `save` 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

当网站或应用程序需要每张幻灯片对应一个 HTML 页面时，请使用此模式。如果每张幻灯片应使用相同的布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 实例并将其传递给每个 `save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/) 提供响应式 HTML 输出。当导出页面需要更好地适应浏览器宽度时，请使用它。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 上设置 `svg_responsive_layout`。当幻灯片内容以可缩放的 SVG 标记导出时，这非常有用。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **包含演讲者备注和批注**

通过 `html_options.slides_layout_options` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/) 可以包含演讲者备注或批注。默认情况下，备注和批注是隐藏的，除非您指定它们的位置。

假设源演示文稿包含演讲者备注：

![带有演讲者备注的幻灯片](slide_with_notes.png)

下面的代码将幻灯片内容导出，并在幻灯片下方显示演讲者备注。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

导出的 HTML 包含备注区域：

![包含幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

要导出批注，请设置 `comments_position`，例如 `CommentsPositions.RIGHT` 或 `CommentsPositions.BOTTOM`。如果只需要批注，请省略 `notes_position`。如果需要同时显示备注和批注，请同时设置两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减小输出大小。当需要更高图像质量时，请将 `pictures_compression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/picturescompression/) 中的某个值。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

默认情况下，图像的裁剪区域可能会从导出输出中移除。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留裁剪数据会增加 HTML 大小。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **添加 CSS**

对于简单的样式，向 [HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/) 传递 CSS 字符串。这样可以更改外围 HTML 文档，而 Aspose.Slides 仍然负责渲染幻灯片内容。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

要自定义文档头、链接的 CSS 文件或在幻灯片和形状周围添加自定义标记，请使用自定义格式化控制器，并通过 `create_custom_formatter` 将其传递给 [HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/)。

## **嵌入字体**

如果目标环境可能未安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 在 HTML 中嵌入字体。嵌入可以提升视觉保真度，但会增加输出大小。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

仅在确信目标浏览器或系统已经提供该字体时才排除它。对于品牌字体或不常见的字体，嵌入通常更安全。

## **链接字体文件而不是嵌入**

为减小 HTML 文件大小，您可以将字体数据