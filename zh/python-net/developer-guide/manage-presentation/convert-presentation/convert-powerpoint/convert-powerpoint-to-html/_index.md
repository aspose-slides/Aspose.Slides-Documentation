---
title: Convert PowerPoint Presentations to HTML in Python
linktitle: PowerPoint to HTML
type: docs
weight: 30
url: /zh/python-net/developer-guide/manage-presentation/convert-presentation/convert-powerpoint/convert-powerpoint-to-html/
keywords:
- convert PowerPoint
- convert presentation
- convert slide
- convert PPT
- convert PPTX
- PowerPoint to HTML
- presentation to HTML
- slide to HTML
- PPT to HTML
- PPTX to HTML
- save PowerPoint as HTML
- save presentation as HTML
- save slide as HTML
- save PPT as HTML
- save PPTX as HTML
- Python
- Aspose.Slides
description: "Convert PowerPoint presentations to responsive HTML in Python. Preserve layout, links, and images with Aspose.Slides conversion guide for fast, flawless results."
---

## **概述**

本文档说明了如何使用 Python 将 PowerPoint 演示文稿转换为 HTML 格式，涉及以下主题。

- 在 Python 中将 PowerPoint 转换为 HTML
- 在 Python 中将 PPT 转换为 HTML
- 在 Python 中将 PPTX 转换为 HTML
- 在 Python 中将 ODP 转换为 HTML
- 在 Python 中将 PowerPoint 幻灯片转换为 HTML

## **Python PowerPoint 转 HTML**

有关在 Python 中将 PowerPoint 转换为 HTML 的示例代码，请参见下文的章节 **[转换 PowerPoint 为 HTML](#convert-powerpoint-to-html)**。该代码可以将 PPT、PPTX 和 ODP 等多种格式加载到 Presentation 对象中，并保存为 HTML 格式。

## **关于 PowerPoint 转 HTML 转换**
使用 [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/)，应用程序和开发者可以将 PowerPoint 演示文稿转换为 HTML：**PPTX 转 HTML** 或 **PPT 转 HTML**。  

**Aspose.Slides** 提供了众多选项（主要来自 [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export.htmloptions/) 类），用于定义 PowerPoint 到 HTML 的转换过程：

* 将整个 PowerPoint 演示文稿转换为 HTML。
* 将 PowerPoint 演示文稿中的特定幻灯片转换为 HTML。
* 将演示文稿媒体（图像、视频等）转换为 HTML。
* 将 PowerPoint 演示文稿转换为响应式 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含演讲者备注的 HTML。 
* 将 PowerPoint 演示文稿转换为包含或不包含批注的 HTML。 
* 将 PowerPoint 演示文稿转换为使用原始或嵌入式字体的 HTML。 
* 将 PowerPoint 演示文稿转换为使用新 CSS 样式的 HTML。 

{{% alert color="primary" %}} 

Aspose 通过自有 API 开发了免费 [演示文稿转 HTML](https://products.aspose.app/slides/conversion/powerpoint-to-html) 转换器：  
[PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html)、  
[PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)、  
[ODP 转 HTML](https://products.aspose.app/slides/conversion/odp-to-html) 等。  

[![todo:image_alt_text](ppt-to-html.png)](https://products.aspose.app/slides/conversion/ppt-to-html)

您还可以查看其他 [Aspose 免费转换器](https://products.aspose.app/slides/conversion)。

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

除本文所述的转换流程外，Aspose.Slides 还支持以下与 HTML 格式相关的转换操作：

* [HTML 转图像](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML 转 JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML 转 XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML 转 TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}

## **转换 PowerPoint 为 HTML**
使用 Aspose.Slides，您可以按以下方式将整个 PowerPoint 演示文稿转换为 HTML：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例  
2. 使用 [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法将对象保存为 HTML 文件  

下面的代码演示了如何在 Python 中将 PowerPoint 转换为 HTML：

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

## **转换 PowerPoint 为响应式 HTML**

Aspose.Slides 提供了 [ResponsiveHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.responsivehtmlcontroller/) 类，可生成响应式 HTML 文件。以下代码演示了如何在 Python 中将 PowerPoint 演示文稿转换为响应式 HTML：

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

## **转换 PowerPoint 为带备注的 HTML**
以下代码演示了如何在 Python 中将 PowerPoint 转换为带备注的 HTML：

```py
import aspose.slides as slides

pres = slides.Presentation("Presentation.pptx")

opt = slides.export.HtmlOptions()
opt.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

pres.save("Output.html", slides.export.SaveFormat.HTML, opt)
```

## **转换 PowerPoint 为带原始字体的 HTML**
Aspose.Slides 提供了 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) 类，可在将演示文稿转换为 HTML 时嵌入所有字体。

如果想排除某些字体不被嵌入，可以向 [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) 的带参数构造函数传入字体名称数组。像 Calibri 或 Arial 这样的常用字体在多数系统中已预装，无需嵌入；若嵌入这些字体会导致生成的 HTML 文档体积不必要地增大。

[EmbedAllFontsHtmlController](https://reference.aspose.com/slides/python-net/aspose.slides.export.embedallfontshtmlcontroller/) 类支持继承，并提供 `WriteFont` 方法供重写。

```py
import aspose.slides as slides

pres = slides.Presentation("input.pptx")

# 排除默认演示文稿字体
fontNameExcludeList = ["Calibri", "Arial"]

htmlOptionsEmbed = slides.export.HtmlOptions()
htmlOptionsEmbed.html_formatter = slides.export.HtmlFormatter.create_custom_formatter(slides.export.EmbedAllFontsHtmlController(fontNameExcludeList))

pres.save("input-PFDinDisplayPro-Regular-installed.html", slides.export.SaveFormat.HTML, htmlOptionsEmbed)
```

## **转换幻灯片为 HTML**
将单独的演示文稿幻灯片转换为 HTML。使用与将整个 PPT(X) 演示文稿转换为 HTML 文档相同的 [**Save**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 方法。还可以使用 [**HtmlOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export.htmloptions/) 类设置额外的转换选项：

```py
# [TODO[not_supported_yet]: python implementation of .net interface]
```

## **导出为 HTML 时保存 CSS 和图像**
使用新的 CSS 样式文件，您可以轻松更改 PowerPoint 转 HTML 过程中生成的 HTML 文件的样式。

下面的 Python 代码演示了如何使用可重写的方法创建带有 CSS 链接的自定义 HTML 文档：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **转换演示文稿为 HTML 时链接所有字体**
如果不想嵌入字体（以避免增加生成的 HTML 大小），可以通过实现自定义的 `LinkAllFontsHtmlController` 来链接所有字体。

下面的 Python 代码演示了在链接所有字体并排除 “Calibri” 与 “Arial”（因为系统已自带）时，将 PowerPoint 转换为 HTML 的方法：

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

## **支持 SVG 响应式属性**
下面的代码示例展示了如何使用响应式布局将 PPT(X) 演示文稿导出为 HTML：

```py
presentation = slides.Presentation("SomePresentation.pptx")

saveOptions = slides.export.HtmlOptions()
saveOptions.svg_responsive_layout = True

presentation.save("SomePresentation-out.html", slides.export.SaveFormat.HTML, saveOptions)
```

## **将媒体文件导出为 HTML**
使用 Aspose.Slides for Python，您可以按以下步骤导出媒体文件：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 获取幻灯片的引用。  
3. 向幻灯片添加视频。  
4. 将演示文稿写入为 HTML 文件。  

下面的 Python 代码演示了如何向演示文稿添加视频并保存为 HTML：

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

## 常见问题

### **如何使用 Python 将 PowerPoint 演示文稿转换为 HTML？**

您可以使用 Aspose.Slides for Python via .NET 库加载 PPT、PPTX 或 ODP 文件，并通过 `save()` 方法配合 `SaveFormat.HTML` 将其转换为 HTML。

### **Aspose.Slides 是否支持将单个 PowerPoint 幻灯片转换为 HTML？**

是的，Aspose.Slides 允许通过相应的 `HtmlOptions` 配置，将整个演示文稿或指定的幻灯片转换为 HTML。

### **我可以生成响应式 HTML 吗？**

可以，使用 `ResponsiveHtmlController` 类，您可以将演示文稿导出为能够在不同屏幕尺寸下自适应的 HTML 布局。

### **是否可以在导出的 HTML 中包含演讲者备注或批注？**

可以，您可以在 `HtmlOptions` 中配置是否包含演讲者备注和批注。

### **转换为 HTML 时可以嵌入字体吗？**

可以，Aspose.Slides 提供 `EmbedAllFontsHtmlController` 类，允许嵌入字体或排除特定字体以减小输出文件体积。

### **PowerPoint 转 HTML 是否支持媒体文件（如视频、音频）？**

支持，Aspose.Slides 可通过 `VideoPlayerHtmlController` 等相关类将幻灯片中嵌入的媒体内容导出为 HTML。

### **支持哪些文件格式转换为 HTML？**

Aspose.Slides 支持将 PPT、PPTX 和 ODP 演示文稿格式转换为 HTML，还可以将幻灯片内容保存为 SVG 并导出媒体资源。

### **我能否通过链接系统已有字体来避免嵌入字体，从而减小 HTML 输出大小？**

可以，您可以实现自定义的 `HtmlController`，将常见系统字体（如 Arial、Calibri）以链接方式引用，而不是嵌入。

### **是否有在线工具可以将 PowerPoint 转换为 HTML？**

有，您可以使用 Aspose 免费的在线工具，例如 [PPT 转 HTML](https://products.aspose.app/slides/conversion/ppt-to-html) 或 [PPTX 转 HTML](https://products.aspose.app/slides/conversion/pptx-to-html)，无需编写代码即可在浏览器中直接转换演示文稿。

### **我可以在导出的 HTML 文件中使用自定义 CSS 样式吗？**

可以，Aspose.Slides 允许在转换过程中链接外部 CSS 文件，从而完全自定义生成的 HTML 内容的外观。