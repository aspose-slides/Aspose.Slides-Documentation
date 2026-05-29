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

Aspose.Slides for Python via .NET 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需加载一个[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)并使用[SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)进行`save`调用。需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选择的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入和引用方式。

默认情况下，HTML 导出会生成一个自包含的 HTML 文档，其中大多数资源都已嵌入。这对于共享单个文件很方便，但会增加输出大小。进行网页发布时，请考虑使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/)加载并使用[SaveFormat](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/saveformat/)保存。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

此示例写入一个 HTML 文件。`with`语句在导出后会释放演示文稿对象、文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `slides_layout_options`：添加备注、批注、讲义或其他布局信息。
- `html_formatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `slide_image_format`：更改幻灯片的表现形式，例如使用 SVG。
- `pictures_compression`：控制图像 DPI 和输出大小。
- `delete_pictures_cropped_areas`：保留或删除裁剪图像数据。
- `svg_responsive_layout`：使导出的 SVG 内容适应其容器。
- `show_hidden_slides`：在需要时包含隐藏的幻灯片。

以下章节分别展示最常用的选项，您可以仅组合工作流中需要的部分。

## **将选定的幻灯片转换为 HTML**

接受幻灯片编号的`save`重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

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

当网站或应用需要每张幻灯片对应一个 HTML 页面时使用此模式。如果每张幻灯片应使用相同的布局，请创建一个[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/)实例并将其传递给每个`save`调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/responsivehtmlcontroller/) 通过[HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/) 提供响应式 HTML 输出。当导出页面需要更好地适应浏览器宽度时使用它。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

对于基于 SVG 的响应式布局，在[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 上设置`svg_responsive_layout`。当幻灯片内容以可缩放的 SVG 标记导出时，这非常有用。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **包含演讲者备注和批注**

通过`html_options.slides_layout_options`使用[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/notescommentslayoutingoptions/) 可以包含演讲者备注或批注。默认情况下备注和批注是隐藏的，除非您指定它们的位置。

假设源演示文稿包含演讲者备注：

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

下面的代码将在幻灯片下方导出演讲者备注。

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

![HTML output with the slide and speaker notes](HTML_with_notes.png)

要导出批注，设置`comments_position`，例如 `CommentsPositions.RIGHT` 或 `CommentsPositions.BOTTOM`。如果只需要批注，省略`notes_position`。如果需要同时包含备注和批注，则同时设置这两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以减少输出大小。当需要更高图像质量时，将`pictures_compression`设置为[PicturesCompression](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/picturescompression/) 中的相应值。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

默认情况下，图像的裁剪区域可能会从导出输出中移除。只有在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留裁剪数据会增加 HTML 大小。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **添加 CSS**

对于简单的样式，向[HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/) 传递 CSS 字符串。这会改变外围的 HTML 文档，而 Aspose.Slides 仍然负责渲染幻灯片内容。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

如需自定义文档头、链接的 CSS 文件或围绕幻灯片和形状的自定义标记，请使用自定义格式化控制器，并通过`create_custom_formatter` 将其传递给[HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/)。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，可使用[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 将字体嵌入 HTML。嵌入可提升视觉保真度，但会增加输出大小。

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

## **链接字体文件而非嵌入**

为了减小 HTML 文件大小，可以将字体数据写入单独的 WOFF 文件，并在 HTML 中添加`@font-face`规则。这需要一个在导出期间自定义字体写入方式的控制器。在 Python via .NET 中，实现该控制器的 .NET 辅助程序集，加载到 Python 并通过`create_custom_formatter` 将帮助对象传递给[HtmlFormatter](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmlformatter/)。

外部化字体时，需要明确两条路径：

- 用于写入生成的 WOFF 文件的文件系统输出目录。
- 将出现在 HTML 文档中的 URL 路径，浏览器将使用该路径加载字体文件。

在部署路径最终确定之前，请保持 HTML 文件与生成的字体文件在同一目录下。如果文件部署到其他位置，请使 URL 前缀与部署后的 URL 路径匹配。

## **外部保存资源**

自包含的 HTML 易于移动，但嵌入的 Base64 资源会使文件变大。如果您的应用需要外部图像、字体、音频或视频文件，请使用自定义链接/嵌入控制器，并将其传递给[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 构造函数。

外部化资源时，需要明确两条路径：

- 文件系统输出路径，您的应用在此写入生成的图像、字体、音频或视频。
- URL 路径，即浏览器从 HTML 文档加载这些文件时使用的路径。

有关完整的图像链接讨论，请参阅[将演示文稿导出为带外部链接图像的 HTML](/slides/zh/python-net/exporting-presentations-to-html-with-externally-linked-images/)。

## **导出媒体文件**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/videoplayerhtmlcontroller/) 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的媒体文件写入的目录。
- `file_name`：正在生成的 HTML 文件名。
- `base_uri`：HTML 中指向媒体文件的绝对 URI 前缀。

如果 HTML 文件位于`html-output/presentation.html`，媒体文件保存于`html-output/media`，则`path`应指向磁盘上的 media 目录，而`base_uri`应指向浏览器视角下的同一目录。用于本地预览时，可从 media 目录构建`file:///` URI；部署时使用已发布媒体目录的绝对 URL。

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

在服务器应用中，建议为每次导出使用唯一的输出目录。共享输出路径可能导致不同转换的文件相互覆盖。

## **性能与资源管理**

HTML 转换是一次渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、特效、图表和嵌入的媒体。较高的`pictures_compression` DPI、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增大输出大小。

批量转换时：

- 及时释放每个[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例。
- 为不同作业使用独立的输出目录。
- 除非保真度要求，否则避免嵌入常用字体。
- 当 HTML 用于预览或缩略图时降低图像 DPI。
- 在部署路径最终确定前，保持源演示文稿、生成的 HTML 和外部资源在同一位置。

## **常见问题**

**HTML 输出会保留超链接吗？**

会。演示文稿中的超链接会导出为 HTML，并在目标 URL 有效时保持可点击。

**可以并行转换演示文稿为 HTML 吗？**

可以，但不要在多个线程之间共享同一个[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例。对不同文件使用独立的演示实例、独立的流和独立的输出目录。参阅[多线程指南](/slides/zh/python-net/multithreading/)获取详细信息。

**Presentation 对象是线程安全的吗？**

不是。单个[Presentation](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/) 实例应在同一线程上完成加载、修改、保存和释放。并行工作时，为每个线程或进程创建独立的实例。

**生成的 HTML 文件为什么很大？**

默认导出会将资源直接嵌入 HTML。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增大文件大小。使用外部资源、排除常用字体并在对保真度要求不高时降低`pictures_compression` 可以减小输出。

**媒体导出时如何选择 base_uri？**

请选择浏览器视角下的`base_uri`并以绝对 URI 形式传入。本地预览时，可使用`Path(media_directory).as_uri() + "/"` 生成；部署时使用已发布媒体目录的绝对 URL。文件系统 `path` 与浏览器 `base_uri` 不必是相同的字符串，但必须指向同一资源位置。

**可以包含隐藏的幻灯片吗？**

可以。对[HtmlOptions](https://reference.aspose.com/slides/zh/python-net/aspose.slides.export/htmloptions/) 设置`show_hidden_slides = True` 即可在需要时导出隐藏幻灯片。