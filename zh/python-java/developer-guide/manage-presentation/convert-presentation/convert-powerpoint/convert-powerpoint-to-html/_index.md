---
title: 在 Python via Java 中将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/python-java/convert-powerpoint-to-html/
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
- 将 PPT 导出为 HTML
- 将 PPTX 导出为 HTML
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for Python via Java 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需加载一个 [Presentation] 并使用 [save] 调用配合 [SaveFormat]。当您需要控制导出的布局、字体、图像、备注、评论、SVG 输出或链接资源时，请使用 [HtmlOptions]。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和评论。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入和引用方式。

默认情况下，HTML 导出生成一个自包含的 HTML 文档，绝大多数资源都已嵌入。这便利于共享单个文件，但会增大输出体积。针对网站发布，请考虑使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠可用的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用 [Presentation] 加载它，并使用 [SaveFormat.Html] 保存。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

每个示例都从当前工作目录加载 `presentation.pptx`。在运行之前请先安装 Aspose.Slides for Python via Java 和兼容的 Java 运行时。JVM 在每个 Python 进程启动时只启动一次。

此示例写入一个 HTML 文件。演示文稿对象在 `finally` 块中被释放，从而在导出后释放文件句柄和渲染资源。

## **配置 HTML 导出**

[HtmlOptions] 是 HTML 导出的主要配置类。常用设置包括：

- [setSlidesLayoutOptions]：添加备注、评论、讲义或其他布局信息。
- [setHtmlFormatter]：更改 HTML 文档结构或将格式化委托给控制器。
- [setSlideImageFormat]：更改幻灯片的表示方式，例如作为 SVG。
- [setPicturesCompression]：控制图像 DPI 和输出大小。
- [setDeletePicturesCroppedAreas]：保持或删除裁剪的图像数据。
- [setSvgResponsiveLayout]：使导出的 SVG 内容适应其容器。
- [setShowHiddenSlides]：在需要时包含隐藏幻灯片。

以下章节分别演示最常用的选项，您可以仅组合工作流所需的部分。

## **将选定的幻灯片转换为 HTML**

接受幻灯片编号的 [Presentation.save] 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

当网站或应用需要每张幻灯片对应一个 HTML 页面时，请使用此模式。如果每张幻灯片应使用相同的布局，创建一个 [HtmlOptions] 实例并将其传递给每个 [Presentation.save] 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController] 通过 [HtmlFormatter] 提供响应式 HTML 输出。当导出的页面需要更好地适应浏览器宽度时使用它。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

对于基于 SVG 的响应式布局，调用 [HtmlOptions.setSvgResponsiveLayout] 并传入 `True`。当幻灯片内容以可伸缩的 SVG 标记导出时，这非常有用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **包含演讲者备注和评论**

通过 [HtmlOptions.setSlidesLayoutOptions] 使用 [NotesCommentsLayoutingOptions] 可包含演讲者备注或评论。默认情况下，备注和评论是隐藏的，除非您指定它们的位置。

假设源演示文稿包含演讲者备注：

![PowerPoint 中带有演讲者备注的幻灯片](slide_with_notes.png)

以下代码将幻灯片内容与其下方的演讲者备注一起导出。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

导出的 HTML 包含备注区域：

![带有幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

要导出评论，请调用 [NotesCommentsLayoutingOptions.setCommentsPosition]，例如使用 [CommentsPositions.Right] 或 [CommentsPositions.Bottom]。如果只需要评论，省略 [NotesCommentsLayoutingOptions.setNotesPosition]。如果需要同时保留备注和评论，则两个方法都要调用。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以降低输出体积。需要更高图像质量时，请向 [HtmlOptions.setPicturesCompression] 传入来自 [PicturesCompression] 的值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

默认情况下，导出可能会移除图像的裁剪区域。仅在用户必须能够恢复或检查这些隐藏图像部分时才保留裁剪数据。保留它会增加 HTML 大小。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **添加 CSS**

对于简单的样式，可将 CSS 字符串传递给 [HtmlFormatter.createDocumentFormatter]。这会更改外围 HTML 文档，而 Aspose.Slides 仍然负责渲染幻灯片内容。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

如需自定义文档头、链接的 CSS 文件或在幻灯片和形状周围加入自定义标记，请通过 JPype 接口代理实现自定义格式化控制器，并通过 [HtmlFormatter.createCustomFormatter] 将其传递给 [HtmlFormatter]。

## **嵌入字体**

如果目标环境可能没有安装演示文稿使用的字体，请使用 [EmbedAllFontsHtmlController] 将字体嵌入 HTML。嵌入可提升视觉保真度，但会增大输出体积。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

仅在确信目标浏览器或系统已提供相应字体时才排除嵌入。对于品牌字体或不常见字体，嵌入通常更安全。

## **外部保存资源**

自包含的 HTML 易于搬移，但嵌入的 Base64 资源会使文件变大。如果您的应用需要外部图像文件，请通过 JPype 接口代理实现资源链接控制器，并将其传递给 [HtmlOptions] 构造函数。

外部化资源时，需要有意识地选择两条路径：

- 文件系统输出路径，即应用程序写入生成的图像、字体、音频或视频的目录。
- URL 路径，即浏览器从 HTML 文档加载这些文件时使用的路径。

## **导出媒体文件**

[VideoPlayerHtmlController] 导出视频和音频文件，并生成可在浏览器中播放的 HTML。其构造函数接受：

- `path`：生成的媒体文件将写入的目录。
- `fileName`：正在生成的 HTML 文件名。
- `baseUri`：HTML 链接到媒体文件时使用的绝对 URI 前缀。

以下示例导出已嵌入在 `presentation.pptx` 中的媒体。生成的 HTML 仅通过文件名引用媒体文件，路径相对于 HTML 文档所在位置，因此 `path` 必须是同时接收 HTML 文件的目录。`baseUri` 必须是绝对 URI：本地预览时可从输出目录构建 `file:///` URI；部署时使用已发布目录的绝对 URL。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

在服务器应用中，请为每次导出作业使用唯一的输出目录。共享输出路径可能导致不同转换产生的文件相互覆盖。

## **性能和资源管理**

HTML 转换是一次渲染操作，处理时间和内存使用取决于幻灯片数量、图像分辨率、字体、效果、图表以及嵌入的媒体。向 [HtmlOptions.setPicturesCompression] 传入更高的 DPI、嵌入字体、SVG 输出以及保留裁剪图像区域可以提升保真度，但通常会增大输出体积。

批量转换时：

- 及时释放每个 [Presentation] 实例。
- 为不同的作业使用独立的输出目录。
- 除非保真度要求，否则避免嵌入常用字体。
- 当 HTML 用于预览或缩略图时降低图像 DPI。
- 在部署路径确定之前，保持源演示文稿、生成的 HTML 和外部资源一起存放。

## **常见问题**

**HTML 输出中会保留超链接吗？**

会。演示文稿中的超链接会导出到 HTML 中，并在目标 URL 有效时保持可点击。

**我可以并行将演示文稿转换为 HTML 吗？**

可以，但不要在多个线程间共享同一个 [Presentation] 实例。对不同文件使用独立的演示实例、独立的流和独立的输出目录。详见 [multithreading guidance](/slides/zh/python-java/multithreading/)。

**演示文稿对象是线程安全的吗？**

不是。单个 [Presentation] 实例应在同一线程中完成加载、修改、保存和释放。并行工作时，请为每个线程或进程创建独立的实例。

**为什么生成的 HTML 文件很大？**

默认导出会直接在 HTML 中嵌入资源。嵌入的字体、高 DPI 图像、媒体、SVG 内容以及保留的裁剪图像区域都会增大体积。使用外部资源、排除常用字体并向 [HtmlOptions.setPicturesCompression] 传入较低的 DPI，可在对最大保真度要求不高时减小输出。

**为什么 HTML 中的 font-size 值可能与 PowerPoint 中的值不同？**

导出的页面可能使用 SVG 坐标系和缩放变换。单独的 CSS 或 SVG font-size 值并不能完整描述最终显示大小。请在预期的缩放级别下比较渲染后的幻灯片，并检查字体是否可用。

**我应该如何为媒体导出选择 baseUri？**

从浏览器的视角选择 `baseUri` 并以绝对 URI 形式传入。本地预览时可以使用 `output_directory.as_uri() + "/"` 构建；部署时使用已发布目录的绝对 URL。文件系统的 `path` 与浏览器的 `baseUri` 不必是相同的字符串，但必须指向同一位置，并且该位置必须是生成的 HTML 文件所在的目录，因为媒体链接是相对于它写入的。

**我可以包含隐藏的幻灯片吗？**

可以。在需要导出隐藏幻灯片时，调用 [HtmlOptions.setShowHiddenSlides] 并传入 `True`。