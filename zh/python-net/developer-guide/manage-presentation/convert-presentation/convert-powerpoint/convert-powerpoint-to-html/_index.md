---
title: 在 Python 中将 PowerPoint 演示文稿转换为 HTML
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
description: "在 Python 中将 PowerPoint 演示文稿转换为响应式 HTML。使用 Aspose.Slides 转换指南，保留布局、链接和图像，实现快速且完美的结果。"
---

## **概述**

本文介绍如何使用 Python 将 PowerPoint 演示文稿转换为 HTML 格式。它涵盖以下主题。

- 在 Python 中将 PowerPoint 转换为 HTML
- 在 Python 中将 PPT 转换为 HTML
- 在 Python 中将 PPTX 转换为 HTML
- 在 Python 中将 ODP 转换为 HTML
- 在 Python 中将 PowerPoint 幻灯片转换为 HTML

## **Python PowerPoint 转 HTML**

有关将 PowerPoint 转换为 HTML 的 Python 示例代码，请参见下面的章节，即[将 PowerPoint 转换为 HTML](#convert-powerpoint-to-html)。该代码可以在 Presentation 对象中加载 PPT、PPTX 和 ODP 等多种格式，并将其保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**
使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。 

**Aspose.Slides** 提供许多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类），用于定义 PowerPoint 转 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。 
* 将 PowerPoint 演示文稿转换为使用原始或嵌入字体的 HTML。 
* 在使用新 CSS 样式的情况下将 PowerPoint 演示文稿转换为 HTML。 

{{% alert color="primary" %}} 

使用其自身的 API，Aspose 开发了免费的 [presentation to HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器： [PPT to HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、[PPTX to HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、[ODP to HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。 

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您可能想查看 Aspose 的其他 [Aspose 的免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="Note" color="warning" %}} 

除了本文中描述的转换过程之外，Aspose.Slides 还支持以下涉及 HTML 格式的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}


## **将 PowerPoint 转换为 HTML**
使用 Aspose.Slides，您可以通过以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例
1. 使用 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将对象保存为 HTML 文件。

这段代码演示了如何在 python 中将 PowerPoint 转换为 HTML：
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
Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/responsivehtmlcontroller/) 类，允许您生成响应式 HTML 文件。下面的代码演示了如何在 python 中将 PowerPoint 演示文稿转换为响应式 HTML：
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
下面的代码演示了如何在 python 中将 PowerPoint 转换为带备注的 HTML：
```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```


## **将 PowerPoint 转换为带原始字体的 HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类，允许在将演示文稿转换为 HTML 时嵌入所有字体。

为了防止嵌入某些字体，您可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类的带参数构造函数传递字体名称数组。常用字体，如 Calibri 或 Arial，在演示文稿中使用时无需嵌入，因为大多数系统已包含这些字体。如果嵌入这些字体，生成的 HTML 文档会不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法，供重写使用。 
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
将单独的演示文稿幻灯片转换为 HTML。为此，请使用由 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类公开的相同 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法，该方法用于将整个 PPT(X) 演示文稿转换为 HTML 文档。[**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) 类亦可用于设置额外的转换选项：
```py
# [TODO[not_supported_yet]: python 实现 .net 接口]
```



## **导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 转换过程生成的 HTML 文件的样式。 

本示例中的 python 代码展示了如何使用可重写的方法创建带有 CSS 文件链接的自定义 HTML 文档：
```py
# [TODO[not_supported_yet]: python 实现 .net 接口]
```


## **转换演示文稿为 HTML 时链接所有字体**
如果您不想嵌入字体（以避免增加生成的 HTML 大小），可以通过实现自己的 `LinkAllFontsHtmlController` 版本来链接所有字体。

下面的 python 代码演示了如何在链接所有字体且排除 "Calibri" 和 "Arial"（因为系统已存在这些字体）的情况下将 PowerPoint 转换为 HTML： 
```py
# [TODO[not_supported_yet]: python 实现 .net 接口]
```


## **支持 SVG 响应式属性**
以下代码示例展示了如何将 PPT(X) 演示文稿导出为带有响应式布局的 HTML：
```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```


## **将媒体文件导出为 HTML 文件**
使用 Aspose.Slides for python，您可以按以下方式导出媒体文件：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 获取该幻灯片的引用。
3. 向幻灯片添加视频。
4. 将演示文稿写入为 HTML 文件。

下面的 python 代码演示了如何向演示文稿添加视频，然后将其保存为 HTML：
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


## **常见问题解答**

### **如何使用 Python 将 PowerPoint 演示文稿转换为 HTML？**

您可以使用 Aspose.Slides for Python via .NET 库加载 PPT、PPTX 或 ODP 文件，并使用带有 `SaveFormat.HTML` 的 `save()` 方法将其转换为 HTML。

### **Aspose.Slides 是否支持将单个 PowerPoint 幻灯片转换为 HTML？**

是的，Aspose.Slides 允许您通过相应配置 `HtmlOptions` 将整个演示文稿或特定幻灯片转换为 HTML。

### **我可以从 PowerPoint 演示文稿生成响应式 HTML 吗？**

是的，使用 `ResponsiveHtmlController` 类，您可以将演示文稿导出为可适配不同屏幕尺寸的响应式 HTML 布局。

### **是否可以在导出的 HTML 中包含演讲者备注或批注？**

是的，您可以通过配置 `HtmlOptions` 在将 PowerPoint 演示文稿导出为 HTML 时包含或排除演讲者备注和批注。

### **在将演示文稿转换为 HTML 时，我可以嵌入字体吗？**

是的，Aspose.Slides 提供 `EmbedAllFontsHtmlController` 类，您可以嵌入字体或排除特定字体以减小输出文件大小。

### **PowerPoint 转 HTML 的转换是否支持视频和音频等媒体文件？**

是的，Aspose.Slides 可使用 `VideoPlayerHtmlController` 及相关配置类将幻灯片中嵌入的媒体内容导出为 HTML。

### **支持哪些文件格式转换为 HTML？**

Aspose.Slides 支持将 PPT、PPTX 和 ODP 演示文稿格式转换为 HTML。它还允许将幻灯片内容保存为 SVG 并导出媒体资产。

### **我可以避免嵌入字体以减小 HTML 输出大小吗？**

是的，您可以通过自定义 `HtmlController` 的实现，将常见系统字体（如 Arial 或 Calibri）链接而非嵌入，以减小 HTML 输出大小。

### **是否有在线工具可以将 PowerPoint 转换为 HTML？**

是的，您可以尝试 Aspose 免费的网页工具，例如 [PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html) 或 [PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)，在浏览器中直接转换演示文稿，无需编写代码。

### **我可以在导出的 HTML 文件中使用自定义 CSS 样式吗？**

是的，Aspose.Slides 允许在转换过程中链接外部 CSS 文件，使您能够完全自定义生成的 HTML 内容的外观。