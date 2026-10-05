---
title: 将演示文稿转换为 Python via Java 的 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/python-java/export-to-html5/
keywords:
- PowerPoint 转 HTML5
- OpenDocument 转 HTML5
- 演示文稿 转 HTML5
- 幻灯片 转 HTML5
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 将 PowerPoint 与 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文说明如何使用 Aspose.Slides for Python via Java 将 PowerPoint 演示文稿转换为 HTML5。内容包括基本导出、形状动画和幻灯片切换的控制以及注释布局，同时比较 HTML5 输出与标准 HTML 导出的基于 SVG 的输出。

示例需要 Aspose.Slides for Python via Java 和兼容的 Java 运行时。请将输入演示文稿放在当前工作目录中。每个示例仅在 JVM 尚未运行时启动 JVM。

## **导出 PowerPoint 为 HTML5**

以下示例从工作目录加载演示文稿并保存为 HTML5 格式。它使用默认导出设置；下一个示例展示如何显式控制动画播放。请将输入路径替换为您的演示文稿路径。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html5)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
除了 HTML 文档，导出还会写入用于幻灯片样式、动画、效果和导航的支持 CSS 和 JavaScript 文件。将这些文件与 HTML 文档一起移动或发布。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；如果没有这些文件，幻灯片导航和动画将无法运行。
{{% /alert %}}

要在导出时不播放形状动画或幻灯片切换，请在 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 中将 `False` 传递给 [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)。这些设置相互独立，您可以启用其中一个而禁用另一个。示例在生成的页面中同时禁用了两种动画。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(False)
html5_options.setAnimateTransitions(False)

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **导出 PowerPoint 为 HTML**

标准 HTML 导出使用不同的渲染方式：幻灯片内容以 SVG 形式嵌入 HTML 页面。以下示例使用此渲染方式将演示文稿转换为 HTML 文档。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

下面的简化标记展示了生成页面的结构。SVG 元素包含渲染后的幻灯片内容；占位符文本表示该内容，并非实际导出输出。

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
基于 SVG 的导出不会将 PowerPoint 形状暴露为单独的 HTML 元素。需要形状动画和幻灯片切换选项时，请使用 HTML5 导出。
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

HTML5 导出生成用于在浏览器中查看和导航演示文稿幻灯片的页面。此示例同时启用 [setAnimateShapes](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)，使导出的幻灯片视图能够播放来源演示文稿中的效果。

使用已经包含形状动画和幻灯片切换的演示文稿以查看这些设置的效果。启用它们不会为没有任何效果的幻灯片添加新效果。导出后，在浏览器中打开生成的 HTML5 文档，并确保其支持文件可用。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setAnimateShapes(True)
html5_options.setAnimateTransitions(True)

presentation = Presentation("pres.pptx")
try:
    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **将演示文稿转换为带注释的 HTML5 文档**

您可以在 HTML5 输出中包含现有的幻灯片注释，以便读者在幻灯片内容旁看到反馈。本节示例要求源演示文稿包含注释，如下所示。它仅导出这些注释，不会创建新注释。

![演示文稿幻灯片上的两个评论](two_comments_pptx.png)

将一个 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/) 对象传递给 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) 将 [CommentsPositions](https://reference.aspose.com/slides/python-java/aspose.slides/commentspositions/) 枚举的 `Right` 选中，以将注释放置在每张幻灯片的右侧。

下面的示例将演示文稿导出为带此注释布局的 HTML5。没有注释的演示文稿将没有可显示的注释文本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, Html5Options, NotesCommentsLayoutingOptions, Presentation, SaveFormat

layout_options = NotesCommentsLayoutingOptions()
layout_options.setCommentsPosition(CommentsPositions.Right)

html5_options = Html5Options()
html5_options.setSlidesLayoutOptions(layout_options)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

![输出 HTML5 文档中的注释](two_comments_html5.png)

## **导出期间排除 JavaScript 超链接**

假设 `hyperlinks.pptx` 包含目标为 `javascript:alert('Hello')` 的链接文本以及普通的 `https://example.com/` 链接。要在导出期间排除 JavaScript 超链接，请将 `True` 传递给 [SaveOptions.setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)。默认值为 `False`，因此除非启用此选项，否则这些链接不会被过滤。

下面的示例从工作目录加载演示文稿并使用 [Html5Options](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/) 导出：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

html5_options = Html5Options()
html5_options.setSkipJavaScriptLinks(True)

presentation = Presentation("hyperlinks.pptx")
try:
    presentation.save("filtered-html5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

导出的文件会省略 JavaScript 超链接，但保留其文本和普通的 HTTPS 链接。源演示文稿保持不变。

此选项仅过滤 JavaScript 超链接；它不会删除所有脚本或其他活动内容，也不能保证 CSP 合规。例如，HTML5 输出仍会包含用于幻灯片导航和动画的脚本。

## **常见问题**

**我可以控制 HTML5 中对象动画和幻灯片切换是否播放吗？**

是的，HTML5 导出提供独立的选项，可分别启用或禁用 [shape animations](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [slide transitions](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setAnimateTransitions)。

**是否支持注释，且可以将它们放置在幻灯片的何处？**

是的，可以在 HTML5 输出中包含现有注释，并通过 [layout settings](https://reference.aspose.com/slides/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 将它们放置（例如放在幻灯片右侧）。

**我能否为安全或 CSP 考虑而跳过调用 JavaScript 的链接？**

可以，[setSkipJavaScriptLinks](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 设置允许在保存时跳过带有 JavaScript 调用的超链接。默认值为 `False`。请参阅 [Exclude JavaScript Hyperlinks During Export](/slides/zh/python-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 获取 HTML5 导出示例及过滤范围说明。此设置不会移除 HTML5 查看器用于导航和动画的 JavaScript。