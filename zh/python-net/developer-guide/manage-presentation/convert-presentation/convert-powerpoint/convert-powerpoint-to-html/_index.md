---
title: 使用 Python 将 PowerPoint 转换为 HTML
linktitle: 将 PowerPoint 转换为 HTML
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-html/
keywords: "Python PowerPoint 转换为 HTML, 转换 PowerPoint 演示文稿, PPTX, PPT, PPT 转换为 HTML, PPTX 转换为 HTML, PowerPoint 转换为 HTML, 将 PowerPoint 保存为 HTML, 将 PPT 保存为 HTML, 将 PPTX 保存为 HTML, Python, Aspose.Slides, HTML 导出"
description: "将 PowerPoint 转换为 HTML: 将 PPTX 或 PPT 保存为 HTML. 将幻灯片保存为 HTML"
---

## **概述**

本文解释了如何使用 Python 将 PowerPoint 演示文稿转换为 HTML 格式。涵盖以下主题。

- 使用 Python 将 PowerPoint 转换为 HTML
- 使用 Python 将 PPT 转换为 HTML
- 使用 Python 将 PPTX 转换为 HTML
- 使用 Python 将 ODP 转换为 HTML
- 使用 Python 将 PowerPoint 幻灯片转换为 HTML

## **Python PowerPoint 转换为 HTML**

要获取将 PowerPoint 转换为 HTML 的 Python 示例代码，请参见下面的部分，即 [将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载多种格式，如 PPT、PPTX 和 ODP，并将其保存为 HTML 格式。

## **关于 PowerPoint 到 HTML 转换**
使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发人员可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转换为 HTML** 或 **PPT 转换为 HTML**。

**Aspose.Slides** 提供许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类），这些选项定义了 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。
* 将 PowerPoint 演示文稿转换为带有或不带有发言者备注的 HTML。
* 将 PowerPoint 演示文稿转换为带有或不带有评论的 HTML。
* 将 PowerPoint 演示文稿转换为带有原始或嵌入字体的 HTML。
* 使用新 CSS 样式将 PowerPoint 演示文稿转换为 HTML。

{{% alert color="primary" %}} 

使用其自己的 API，Aspose 开发了免费的 [演示文稿到 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能还想查看其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除了这里描述的转换过程外，Aspose.Slides 还支持这些涉及 HTML 格式的转换操作：

* [HTML 转图片](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 使用 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将对象保存为 HTML 文件。

以下代码演示了如何在 Python 中将 PowerPoint 转换为 HTML：

```python
import aspose.slides as slides

# 实例化表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# 将演示文稿保存为 HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **将 PowerPoint 转换为响应式 HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) 类，允许您生成响应式 HTML 文件。以下代码演示了如何在 Python 中将 PowerPoint 演示文稿转换为响应式 HTML：

```py
# 实例化表示演示文稿文件的 Presentation 对象
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# 将演示文稿保存为 HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **将 PowerPoint 转换为带备注的 HTML**
以下代码演示了如何在 Python 中将 PowerPoint 转换为带备注的 HTML：

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **将 PowerPoint 转换为带原始字体的 HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类，允许您在将演示文稿转换为 HTML 时嵌入所有字体。

为了防止某些字体被嵌入，您可以将字体名称的数组传递给 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类的参数化构造函数。常用字体，如 Calibri 或 Arial，在演示文稿中使用时，无需嵌入，因为大多数系统已经包含这些字体。当这些字体被嵌入时，生成的 HTML 文档会变得不必要的大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法，旨在被重写。

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
将单独的演示文稿幻灯片转换为 HTML。为此，使用 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，该方法由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类提供，用于将整个 PPT(X) 演示文稿转换为 HTML 文档。 [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类也可用于设置额外的转换选项：

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改由于 PowerPoint 转换为 HTML 过程而生成的 HTML 文件的样式。

以下 Python 代码示例演示了如何使用可重写的方法创建一个链接到 CSS 文件的自定义 HTML 文档：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **在将演示文稿转换为 HTML 时链接所有字体**
如果您不想嵌入字体（以避免增加生成的 HTML 的大小），可以通过实现您自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

以下 Python 代码演示了如何在链接所有字体并排除 "Calibri" 和 "Arial" 的情况下将 PowerPoint 转换为 HTML（因为它们在系统中已经存在）：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **支持 SVG 响应属性**
以下代码示例演示了如何将 PPT(X) 演示文稿导出为具有响应布局的 HTML：

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **导出媒体文件到 HTML 文件**
使用 Aspose.Slides for python，您可以通过以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片的引用。
1. 向幻灯片添加视频。
1. 将演示文稿写入 HTML 文件。

以下 Python 代码演示了如何向演示文稿添加视频并将其保存为 HTML：

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