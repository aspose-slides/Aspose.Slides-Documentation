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
- Python
- Aspose.Slides
description: "在 Python 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南快速、完美地保留布局、链接和图像。"
---

## **概述**

本文解释了如何使用 Python 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖以下主题。

- 在 Python 中将 PowerPoint 转换为 HTML
- 在 Python 中将 PPT 转换为 HTML
- 在 Python 中将 PPTX 转换为 HTML
- 在 Python 中将 ODP 转换为 HTML
- 在 Python 中将 PowerPoint 幻灯片转换为 HTML

## **Python PowerPoint 转 HTML**

有关将 PowerPoint 转换为 HTML 的 Python 示例代码，请参阅下面的部分，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载 PPT、PPTX 和 ODP 等多种格式，并将其保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**

使用[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML：**PPTX to HTML** 或 **PPT to HTML**。

**Aspose.Slides** 提供了许多选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类），用于定义 PowerPoint 转 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。
* 将 PowerPoint 演示文稿转换为使用原始或嵌入字体的 HTML。
* 在使用新 CSS 样式的情况下将 PowerPoint 演示文稿转换为 HTML。

{{% alert color="primary" %}} 

使用自己的 API，Aspose 开发了免费的[演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看 Aspose 的其他[免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了本文所述的转换流程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **将 PowerPoint 转换为 HTML**

使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 使用[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)方法将对象保存为 HTML 文件。

以下代码演示了如何在 python 中将 PowerPoint 转换为 HTML：
```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# 将演示文稿保存为 HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```


## **将 PowerPoint 转换为响应式 HTML**

Aspose.Slides 提供了[ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) 类，允许您生成响应式 HTML 文件。以下代码演示了如何在 python 中将 PowerPoint 演示文稿转换为响应式 HTML：
```py
# 实例化一个表示演示文稿文件的 Presentation 对象
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# 将演示文稿保存为 HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **将 PowerPoint 转换为带备注的 HTML**

以下代码演示了如何在 python 中将 PowerPoint 转换为带备注的 HTML：
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **将 PowerPoint 转换为带原始字体的 HTML**

Aspose.Slides 提供了[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

若要防止嵌入某些字体，您可以向[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类的参数化构造函数传递字体名称数组。诸如 Calibri 或 Arial 等常用字体在演示文稿中使用时，无需嵌入，因为大多数系统已预装这些字体。嵌入这些字体会导致生成的 HTML 文档体积过大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法，可供覆写。 
```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# 排除默认演示文稿字体
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```


## **将幻灯片转换为 HTML**

将单独的演示文稿幻灯片转换为 HTML。为此使用[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开的相同[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，该方法用于将整个 PPT(X) 演示文稿转换为 HTML 文档。[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类也可以用于设置额外的转换选项：
```py
# [TODO[not_supported_yet]: python 对 .net 接口的实现]
```


## **导出为 HTML 时保存 CSS 和图像**

使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 转换过程生成的 HTML 文件的样式。

此示例中的 python 代码演示了如何使用可覆写的方法创建带有 CSS 文件链接的自定义 HTML 文档：
```py
# [TODO[not_supported_yet]: python 对 .net 接口的实现]
```


## **在将演示文稿转换为 HTML 时链接所有字体**

如果您不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自定义的 `LinkAllFontsHtmlController` 版本来链接所有字体。

以下 python 代码演示了如何在链接所有字体且排除 “Calibri” 与 “Arial”（因为系统中已存在） 的情况下，将 PowerPoint 转换为 HTML：
```py
# [TODO[not_supported_yet]: python 实现 .net 接口]
```


## **支持 SVG 响应式属性**

下面的代码示例展示了如何将 PPT(X) 演示文稿导出为具有响应式布局的 HTML：
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **导出媒体文件到 HTML 文件**

使用 Aspose.Slides for python，您可以按以下方式导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 获取该幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入为 HTML 文件。

以下 python 代码演示了如何向演示文稿添加视频，然后将其保存为 HTML：
```py
import aspose.slides as slides

# 加载演示文稿
presentation = slides.Presentation("Media File.pptx")

path = "C:\\"
fileName = "ExportMediaFiles_out.html"
baseUri = "http://www.example.com/"

controller = slides.export.VideoPlayerHtmlController(path, fileName, baseUri)

htmlOptions = slides.export.HtmlOptions(controller)
svgOptions = slides.export.SVGOptions(controller)

htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
htmlOptions.slide_image_format = slides.export.SlideImageFormat.svg(svgOptions)

presentation.save(path + "ExportMediaFiles_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```


## **FAQ**

**如何使用 Python 将 PowerPoint 演示文稿转换为 HTML？**

您可以使用 Aspose.Slides for Python via .NET 库加载 PPT、PPTX 或 ODP 文件，并使用 `save()` 方法配合 `SaveFormat.HTML` 将其转换为 HTML。

**Aspose.Slides 是否支持将单个 PowerPoint 幻灯片转换为 HTML？**

是的，Aspose.Slides 允许通过相应的 `HtmlOptions` 配置将整个演示文稿或特定幻灯片转换为 HTML。

**我可以从 PowerPoint 演示文稿生成响应式 HTML 吗？**

可以，使用 `ResponsiveHtmlController` 类即可将演示文稿导出为适配不同屏幕尺寸的响应式 HTML 布局。

**导出的 HTML 是否可以包含演讲者备注或批注？**

可以，您可以在 `HtmlOptions` 中设置以包含或排除演讲者备注和批注。

**在将演示文稿转换为 HTML 时可以嵌入字体吗？**

可以，Aspose.Slides 提供 `EmbedAllFontsHtmlController` 类，可用于嵌入字体或排除特定字体以减小输出文件大小。

**PowerPoint 转 HTML 转换是否支持视频和音频等媒体文件？**

支持，Aspose.Slides 可使用 `VideoPlayerHtmlController` 等相关类将幻灯片中嵌入的媒体内容导出为 HTML。

**支持哪些文件格式转换为 HTML？**

Aspose.Slides 支持将 PPT、PPTX 和 ODP 演示文稿格式转换为 HTML，并且可以将幻灯片内容保存为 SVG 以及导出媒体资源。

**我能通过链接常用系统字体而不是嵌入它们来减小 HTML 输出大小吗？**

可以，您可以实现自定义的 `HtmlController`，将常见的系统字体（如 Arial、Calibri）以链接方式引用，而不是嵌入。

**是否有在线工具可以将 PowerPoint 转换为 HTML？**

有，您可以使用 Aspose 的免费在线工具，例如[PowerPoint 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)或[PowerPoint 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)直接在浏览器中进行转换，无需编写代码。

**我可以在导出的 HTML 文件中使用自定义 CSS 样式吗？**

可以，Aspose.Slides 在转换时支持链接外部 CSS 文件，您可以完全自定义生成的 HTML 内容的外观。