---
title: 将PowerPoint演示文稿转换为HTML（Python）
linktitle: PowerPoint转HTML
type: docs
weight: 30
url: /zh/python-net/convert-powerpoint-to-html/
keywords:
- 转换PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换PPT
- 转换PPTX
- PowerPoint转HTML
- 演示文稿转HTML
- 幻灯片转HTML
- PPT转HTML
- PPTX转HTML
- 将PowerPoint保存为HTML
- 将演示文稿保存为HTML
- 将幻灯片保存为HTML
- 将PPT保存为HTML
- 将PPTX保存为HTML
- Python
- Aspose.Slides
description: "使用Python将PowerPoint演示文稿转换为响应式HTML。通过Aspose.Slides转换指南，保留布局、链接和图像，实现快速、完美的结果。"
---

## **概述**

本文介绍如何使用Python将PowerPoint演示文稿转换为HTML格式。涵盖以下主题。

- 在Python中将PowerPoint转换为HTML
- 在Python中将PPT转换为HTML
- 在Python中将PPTX转换为HTML
- 在Python中将ODP转换为HTML
- 在Python中将PowerPoint幻灯片转换为HTML

## **Python PowerPoint转HTML**

有关将PowerPoint转换为HTML的Python示例代码，请参阅下面的章节，即[Convert PowerPoint to HTML](#convert-powerpoint-to-html)。代码可以在Presentation对象中加载PPT、PPTX和ODP等多种格式，并将其保存为HTML格式。

## **关于PowerPoint转HTML转换**

使用[**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发者可以将PowerPoint演示文稿转换为HTML：**PPTX转HTML**或**PPT转HTML**。

**Aspose.Slides** 提供许多选项（主要来自[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类），定义PowerPoint转HTML的转换过程：

* 将整个PowerPoint演示文稿转换为HTML。
* 将PowerPoint演示文稿中的特定幻灯片转换为HTML。
* 将演示文稿媒体（图像、视频等）转换为HTML。
* 将PowerPoint演示文稿转换为响应式HTML。 
* 将PowerPoint演示文稿转换为包含或不包含演讲者备注的HTML。 
* 将PowerPoint演示文稿转换为包含或不包含批注的HTML。 
* 将PowerPoint演示文稿转换为使用原始或嵌入字体的HTML。 
* 在使用新CSS样式的情况下将PowerPoint演示文稿转换为HTML。 

{{% alert color="primary" %}} 

Aspose 使用其自有 API 开发了免费[演示文稿转HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html)转换器： [PPT转HTML](https://products.aspose.app/slides/conversion/ppt-to-html)，[PPTX转HTML](https://products.aspose.app/slides/conversion/pptx-to-html)，[ODP转HTML](https://products.aspose.app/slides/conversion/odp-to-html)，等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想了解 Aspose 的其他[免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除本文描述的转换过程外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作： 

* [HTML转图片](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML转JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML转XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML转TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **将PowerPoint转换为HTML**
使用 Aspose.Slides，您可以按以下方式将整个PowerPoint演示文稿转换为HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 使用 [Save ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将对象保存为HTML文件。

以下代码演示如何在 python 中将 PowerPoint 转换为 HTML：

```python
import aspose.slides as slides

# Instantiate a Presentation object that represents a presentation file
pres = slides.Presentation("Convert_HTML.pptx")

options = slides.export.HtmlOptions()

options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL
options.html_formatter = slides.export.HtmlFormatter.create_document_formatter("", False)

# Saving the presentation to HTML
pres.save("ConvertWholePresentationToHTML_out.html", slides.export.SaveFormat.HTML, options)
```

## **将PowerPoint转换为响应式HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) 类，可生成响应式 HTML 文件。以下代码演示如何在 python 中将 PowerPoint 演示文稿转换为响应式 HTML：

```py
# Instantiate a Presentation object that represents a presentation file
import aspose.slides as slides

pres = slides.Presentation("Convert_HTML.pptx")

controller = slides.export.ResponsiveHtmlController()
htmlOptions = slides.export.HtmlOptions()
htmlOptions.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

# Saving the presentation to HTML
pres.save("ConvertPresentationToResponsiveHTML_out.html", slides.export.SaveFormat.HTML, htmlOptions)
```

## **将PowerPoint转换为带备注的HTML**
以下代码演示如何在 Python 中将 PowerPoint 转换为带备注的 HTML：

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **将PowerPoint转换为带原始字体的HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类，可在将演示文稿转换为 HTML 时嵌入所有字体。

若要防止嵌入特定字体，可向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 的带参数构造函数传递字体名称数组。常用字体（如 Calibri 或 Arial）在演示文稿中使用时无需嵌入，因为大多数系统已包含这些字体。若嵌入这些字体，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法，可在子类中覆盖实现。 

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# exclude default presentation fonts
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **将幻灯片转换为HTML**
将单独的演示文稿幻灯片转换为 HTML。为此使用与将整个 PPT(X) 演示文稿转换为 HTML 文档相同的[**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法。也可以使用[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类设置额外的转换选项：

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```


## **导出为HTML时保存CSS和图像**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程生成的 HTML 文件的样式。

本示例中的 python 代码演示如何使用可覆盖的方法创建带有 CSS 文件链接的自定义 HTML 文档：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **转换演示文稿为HTML时链接所有字体**
如果您不想嵌入字体（以避免增大生成的 HTML 大小），可以通过实现自定义 `LinkAllFontsHtmlController` 来链接所有字体。

以下 python 代码演示如何在链接所有字体并排除 “Calibri” 和 “Arial”（因为系统已存在）时，将 PowerPoint 转换为 HTML：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **支持SVG响应式属性**
下面的代码示例展示如何使用响应式布局将 PPT(X) 演示文稿导出为 HTML：

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **将媒体文件导出为HTML文件**
使用 Aspose.Slides for python，您可以按以下方式导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 获取幻灯片的引用。
1. 向幻灯片添加视频。
1. 将演示文稿写入为 HTML 文件。

以下 python 代码演示如何向演示文稿添加视频并将其保存为 HTML：

```py
import aspose.slides as slides

# Loading a presentation
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

## 常见问题

### **如何使用 Python 将 PowerPoint 演示文稿转换为 HTML？**

您可以使用 Aspose.Slides for Python via .NET 库加载 PPT、PPTX 或 ODP 文件，并使用 `save()` 方法并指定 `SaveFormat.HTML` 将其转换为 HTML。

### **Aspose.Slides 是否支持将单个 PowerPoint 幻灯片转换为 HTML？**

是的，Aspose.Slides 允许通过相应配置 `HtmlOptions`，将整个演示文稿或特定幻灯片转换为 HTML。

### **我可以从 PowerPoint 演示文稿生成响应式 HTML 吗？**

可以，使用 `ResponsiveHtmlController` 类，您可以将演示文稿导出为能够自适应不同屏幕尺寸的响应式 HTML 布局。

### **可以在导出的 HTML 中包含演讲者备注或批注吗？**

可以，您可以在导出 PowerPoint 演示文稿为 HTML 时，通过配置 `HtmlOptions` 来包含或排除演讲者备注和批注。

### **在将演示文稿转换为 HTML 时可以嵌入字体吗？**

可以，Aspose.Slides 提供 `EmbedAllFontsHtmlController` 类，允许您嵌入字体或排除特定字体以减小输出文件大小。

### **PowerPoint 转 HTML 的转换是否支持视频和音频等媒体文件？**

可以，Aspose.Slides 通过 `VideoPlayerHtmlController` 等相关类，支持将幻灯片中嵌入的媒体内容导出为 HTML。

### **支持哪些文件格式转换为 HTML？**

Aspose.Slides 支持将 PPT、PPTX 和 ODP 演示文稿格式转换为 HTML。还可以将幻灯片内容保存为 SVG 并导出媒体资源。

### **我可以避免嵌入字体以减小 HTML 输出大小吗？**

可以，您可以通过实现自定义的 `HtmlController`，链接常见的系统字体（如 Arial、Calibri），而不是嵌入它们。

### **有在线工具可以将 PowerPoint 转换为 HTML 吗？**

有，您可以尝试 Aspose 的免费在线工具，如 [PPT转HTML](https://products.aspose.app/slides/conversion/ppt-to-html) 或 [PPTX转HTML](https://products.aspose.app/slides/conversion/pptx-to-html)，直接在浏览器中转换演示文稿，无需编写代码。

### **我可以在导出的 HTML 文件中使用自定义 CSS 样式吗？**

可以，Aspose.Slides 允许在转换过程中链接外部 CSS 文件，使您能够全面自定义生成的 HTML 内容的外观。