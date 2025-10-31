---
title: 用 Python 将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 HTML
- 演示文稿 转 HTML
- 幻灯片 转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- 将 PowerPoint 保存为 HTML
- 将 演示文稿 保存为 HTML
- 将 幻灯片 保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- Python
- Aspose.Slides
description: "在 Python 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，保留布局、链接和图像，实现快速、完美的结果。"
---

## **概述**

本文档说明如何使用 Python 将 PowerPoint 演示文稿转换为 HTML 格式。涵盖以下主题。

- 在 Python 中将 PowerPoint 转换为 HTML
- 在 Python 中将 PPT 转换为 HTML
- 在 Python 中将 PPTX 转换为 HTML
- 在 Python 中将 ODP 转换为 HTML
- 在 Python 中将 PowerPoint 幻灯片转换为 HTML

## **Python PowerPoint 转 HTML**

有关在 Python 中将 PowerPoint 转换为 HTML 的示例代码，请参见下面的章节，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。该代码可以加载 PPT、PPTX 和 ODP 等多种格式到 Presentation 对象，并保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**
使用[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。

**Aspose.Slides** 提供许多选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类）来定义 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为 HTML 时，可包含或排除讲演者备注。 
* 将 PowerPoint 演示文稿转换为 HTML 时，可包含或排除批注。 
* 将 PowerPoint 演示文稿转换为 HTML 时，可使用原始字体或嵌入字体。 
* 将 PowerPoint 演示文稿转换为 HTML 时，使用全新的 CSS 样式。

{{% alert color="primary" %}} 

使用 Aspose 自己的 API，Aspose 开发了免费的[演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器：[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html)等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想了解其他[Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除本文档中描述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **Convert PowerPoint to HTML**
使用 Aspose.Slides，您可以按以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
2. 使用 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将对象保存为 HTML 文件。

下面的代码展示了如何在 python 中将 PowerPoint 转换为 HTML：

```python
import aspose.slides as slides

# 实例化一个表示演示文稿文件的 Presentation 对象
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# 保存演示文稿为 HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **Convert PowerPoint to Responsive HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) 类，可生成响应式 HTML 文件。下面的代码展示了如何在 python 中将 PowerPoint 演示文稿转换为响应式 HTML：

```py
# 实例化一个表示演示文稿文件的 Presentation 对象
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# 保存演示文稿为 HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **Convert PowerPoint to HTML with Notes**
下面的代码展示了如何在 python 中将 PowerPoint 转换为包含备注的 HTML：

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **Convert PowerPoint to HTML with Original Fonts**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类，可在将演示文稿转换为 HTML 时嵌入所有字体。

若要防止某些字体被嵌入，您可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 的参数化构造函数传递字体名称数组。诸如 Calibri 或 Arial 等常用字体在演示文稿中使用时无需嵌入，因为大多数系统已自带这些字体。当这些字体被嵌入时，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法，可供覆盖。 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# 排除默认演示文稿字体
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **Convert Slide to HTML**
将单独的幻灯片转换为 HTML。为此使用与将整个 PPT(X) 演示文稿转换为 HTML 文档相同的[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法。也可以使用[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类设置其他转换选项：

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **Save CSS and Images When Exporting To HTML**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

下面的 python 代码展示了如何使用可覆盖的方法创建带有 CSS 链接的自定义 HTML 文档：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Link All Fonts When Converting Presentation to HTML**
如果您不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自定义的 `LinkAllFontsHtmlController` 来链接所有字体。

下面的 python 代码展示了如何在链接所有字体并排除 “Calibri” 与 “Arial”（因为系统已存在）时，将 PowerPoint 转换为 HTML：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **Support of SVG Responsive Property**
下面的代码示例展示了如何使用响应式布局将 PPT(X) 演示文稿导出为 HTML：

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **Export Media Files to HTML file**
使用 Aspose.Slides for python，您可以按以下方式导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 获取对幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入为 HTML 文件。

下面的 python 代码展示了如何向演示文稿添加视频并保存为 HTML：

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

## Frequently Asked Questions

### **How can I convert a PowerPoint presentation to HTML using Python?**

You can use the Aspose.Slides for Python via .NET library to load PPT, PPTX, or ODP files and convert them to HTML using the `save()` method with `SaveFormat.HTML`.

### **Does Aspose.Slides support converting individual PowerPoint slides to HTML?**

Yes, Aspose.Slides allows you to convert either the entire presentation or specific slides to HTML by configuring `HtmlOptions` accordingly.

### **Can I generate responsive HTML from PowerPoint presentations?**

Yes, with the `ResponsiveHtmlController` class, you can export your presentation to a responsive HTML layout that adapts to different screen sizes.

### **Is it possible to include speaker notes or comments in the exported HTML?**

Yes, you can configure the `HtmlOptions` to include or exclude speaker notes and comments when exporting PowerPoint presentations to HTML.

### **Can I embed fonts when converting a presentation to HTML?**

Yes, Aspose.Slides provides the `EmbedAllFontsHtmlController` class, which allows you to embed fonts or exclude certain fonts to reduce the output file size.

### **Does the PowerPoint to HTML conversion support media files like videos and audio?**

Yes, Aspose.Slides allows exporting media content embedded in slides to HTML using `VideoPlayerHtmlController` and related configuration classes.

### **What file formats are supported for conversion to HTML?**

Aspose.Slides supports converting PPT, PPTX, and ODP presentation formats to HTML. It also allows saving slide content as SVG and exporting media assets.

### **Can I avoid embedding fonts to reduce HTML output size?**

Yes, you can link commonly available system fonts like Arial or Calibri instead of embedding them, using a custom implementation of the `HtmlController`.

### **Is there an online tool to convert PowerPoint to HTML?**

Yes, you can try Aspose’s free web tools such as [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html) or [PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html) to convert presentations directly in your browser without writing any code.

### **Can I use custom CSS styles in the exported HTML file?**

Yes, Aspose.Slides allows linking to external CSS files during conversion, enabling you to fully customize the appearance of the resulting HTML content.