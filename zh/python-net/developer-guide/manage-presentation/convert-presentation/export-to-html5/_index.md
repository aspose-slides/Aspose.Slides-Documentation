---
title: 在 Python 中将演示文稿转换为 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/python-net/export-to-html5/
keywords:
- PowerPoint 转换为 HTML5
- OpenDocument 转换为 HTML5
- 演示文稿转 HTML5
- 幻灯片转 HTML5
- PPT 转 HTML5
- PPTX 转 HTML5
- ODP 转 HTML5
- 将 PPT 保存为 HTML5
- 将 PPTX 保存为 HTML5
- 将 ODP 保存为 HTML5
- 导出 PPT 为 HTML5
- 导出 PPTX 为 HTML5
- 导出 ODP 为 HTML5
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via .NET 将 PowerPoint 演示文稿转换为 HTML5。它涵盖基础导出、形状动画和幻灯片切换的控制以及评论布局。它还比较了 HTML5 输出与标准 HTML 导出的基于 SVG 的输出。

## **导出 PowerPoint 为 HTML5**

以下示例从工作目录加载演示文稿并将其保存为 HTML5 格式。它使用默认导出设置；下一个示例演示如何显式控制动画播放。请将输入路径替换为您的演示文稿路径。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="info" title="Note" %}}
除了 HTML 文档之外，导出还会写入用于幻灯片样式、动画、效果和导航的支持性 CSS 和 JavaScript 文件。移动或发布输出时请将这些文件与 HTML 文档一起保留。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；如果没有这些文件，幻灯片导航和动画将无法运行。
{{% /alert %}}

若要在导出时不播放形状动画或幻灯片切换，请在 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 中将 [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 和 [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/) 设置为 `False`。这些设置相互独立，可在禁用一个的同时启用另一个。示例在生成的页面中导出时禁用了两种动画。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = False
html5_options.animate_transitions = False

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres5.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **导出 PowerPoint 为 HTML**

标准的 HTML 导出使用不同的渲染方式：幻灯片内容以 SVG 形式嵌入 HTML 页面。以下示例使用此渲染方式将演示文稿转换为 HTML 文档。

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("pres.html", slides.export.SaveFormat.HTML)
```

下面的简化标记展示了生成页面的结构。SVG 元素包含渲染后的幻灯片内容；占位文本代表该内容，并非实际导出输出。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
基于 SVG 的导出不会将 PowerPoint 形状公开为单独的 HTML 元素。如果需要本文演示的形状动画和幻灯片切换选项，请使用 HTML5 导出。
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

HTML5 导出生成一个用于在浏览器中查看和导航演示文稿幻灯片的页面。此示例同时启用 [animate_shapes](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 和 [animate_transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)，使导出的幻灯片视图能够播放源演示文稿中的效果。

使用已包含形状动画和幻灯片切换的演示文稿来查看这些设置的效果。启用它们不会为没有效果的幻灯片添加新效果。导出后，在浏览器中打开生成的 HTML5 文档并确保其支持文件可用。

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.animate_shapes = True
html5_options.animate_transitions = True

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, html5_options)
```

## **将演示文稿转换为带评论的 HTML5 文档**

您可以在 HTML5 输出中包含现有的幻灯片评论，以便读者在幻灯片内容旁看到反馈。本节示例要求源演示文稿包含评论，如下所示。它会导出这些评论；不会创建新的评论。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/) 对象分配给 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 的 [slides_layout_options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/) 属性。将 [comments_position](https://reference.aspose.com/slides/python-net/aspose.slides.export/notescommentslayoutingoptions/comments_position/) 设置为 `RIGHT`（来自 [CommentsPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/commentspositions/) 枚举），以将评论放置在每张幻灯片的右侧。

以下示例使用此评论布局将演示文稿导出为 HTML5。没有评论的演示文稿将没有可显示的评论文本。

```python
import aspose.slides as slides

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.comments_position = slides.export.CommentsPositions.RIGHT

html5_options = slides.export.Html5Options()
html5_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.html", slides.export.SaveFormat.HTML5, html5_options)
```

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **导出时排除 JavaScript 超链接**

假设 `hyperlinks.pptx` 包含目标为 `javascript:alert('Hello')` 的链接文本以及普通的 `https://example.com/` 链接。要在导出时排除 JavaScript 超链接，请将 [Html5Options.skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) 设置为 `True`。默认值为 `False`，因此除非启用此选项，否则这些链接不会被过滤。

以下示例从工作目录加载演示文稿并使用 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 导出：

```python
import aspose.slides as slides

html5_options = slides.export.Html5Options()
html5_options.skip_java_script_links = True

with slides.Presentation("hyperlinks.pptx") as presentation:
    presentation.save("filtered-html5.html", slides.export.SaveFormat.HTML5, html5_options)
```

导出的文件省略了 JavaScript 超链接，但保留了其文本和普通的 HTTPS 链接。源演示文稿保持不变。

此选项过滤 JavaScript 超链接；它不会删除所有脚本或其他活动内容，也不能保证 CSP 合规。例如，HTML5 输出仍包含用于幻灯片导航和动画的脚本。

## **常见问题**

**我可以控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

是的，HTML5 导出提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/) 和 [slide transitions](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)。

**是否支持评论，且可以相对于幻灯片放置在哪里？**

是的，现有的评论可以包含在 HTML5 输出中，并可通过笔记和评论的 [layout settings](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/slides_layout_options/)（例如放置在幻灯片右侧）进行定位。

**我能出于安全或 CSP 考虑跳过调用 JavaScript 的链接吗？**

是的，[skip_java_script_links](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/) 设置允许您在保存时跳过包含 JavaScript 调用的超链接。默认值为 `False`。请参阅 [导出时排除 JavaScript 超链接](/slides/zh/python-net/export-to-html5/#exclude-javascript-hyperlinks-during-export) 获取 HTML5 导出示例以及过滤范围。此设置不会删除 HTML5 查看器用于导航和动画的 JavaScript。