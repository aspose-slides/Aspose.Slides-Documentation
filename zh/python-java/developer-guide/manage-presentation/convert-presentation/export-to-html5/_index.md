---
title: 使用 Python via Java 将演示文稿转换为 HTML5
linktitle: 演示文稿转换为 HTML5
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

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了不带额外 Web 扩展的基本 HTML5 导出，以及控制形状动画和幻灯片切换的选项。文章还展示了标准的 PowerPoint 转 HTML 导出过程，解释了如何在幻灯片视图模式下生成 HTML5 输出，并演示了通过配置布局将批注包含在导出文档中的方法。

示例需要 Aspose.Slides for Python via Java 和兼容的 Java 运行时。将 `pres.pptx`（或批注示例使用的 `sample.pptx`）放在当前工作目录中。每个示例仅在 JVM 未运行时启动它。

## **将 PowerPoint 导出为 HTML5**

使用 [Presentation.save](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#save) 与 [SaveFormat.Html5](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Html5) 将演示文稿导出为不带额外 Web 扩展的 HTML5：

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

HTML5 导出器会创建可在浏览器中查看的 HTML 内容。 

{{% /alert %}}

使用 [Html5Options](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/) 配置导出。调用 [setAnimateShapes](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateTransitions) 并传入 `False` 可禁用形状动画和幻灯片切换：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(False)
    html5_options.setAnimateTransitions(False)

    presentation.save("pres5.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **将 PowerPoint 导出为 HTML**

使用 [SaveFormat.Html](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveformat/#Html) 进行标准 HTML 导出。更多选项请参见 [Convert PowerPoint to HTML](/slides/zh/python-java/convert-powerpoint-to-html/)：

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

在此情况下，演示文稿内容通过 SVG 以如下形式呈现：

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

标准 HTML 导出通过 SVG 渲染幻灯片内容，并不提供 HTML5 形状动画和幻灯片切换选项。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许你将 PowerPoint 演示文稿转换为 HTML5 文档，在该文档中幻灯片以幻灯片视图模式呈现。这样，在浏览器中打开生成的 HTML5 文件时，网页上会以幻灯片视图模式显示演示文稿。

以下 Python 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Html5Options, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    html5_options = Html5Options()
    html5_options.setAnimateShapes(True)
    html5_options.setAnimateTransitions(True)

    presentation.save("HTML5-slide-view.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

## **将演示文稿转换为带批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在幻灯片上留下备注或反馈。它在协作项目中尤为有用，多个成员可以对特定幻灯片元素添加建议或评论，而不会更改主体内容。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，可以轻松指定是否在输出文档中包含演示文稿的批注。为此，将批注的显示参数传递给 [Html5Options](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/) 类的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 方法。

使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/) 并通过 [setCommentsPosition](https://reference.aspose.com/slides/zh/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) 将位置设置为 [CommentsPositions.Right](https://reference.aspose.com/slides/zh/python-java/aspose.slides/commentspositions/#Right)。下面的代码示例将演示文稿转换为在幻灯片右侧显示批注的 HTML5 文档。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, NotesCommentsLayoutingOptions, Html5Options, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setCommentsPosition(CommentsPositions.Right)

    html5_options = Html5Options()
    html5_options.setSlidesLayoutOptions(layout_options)

    presentation.save("output.html", SaveFormat.Html5, html5_options)
finally:
    presentation.dispose()
```

下面的图像展示了生成的 “output.html” 文档。

![The comments in the output HTML5 document](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

可以，HTML5 提供了独立的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateShapes) 和 [slide transitions](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setAnimateTransitions)。

**批注可以导出吗，能够相对于幻灯片放置在哪里？**

可以，批注可以在 HTML5 中添加，并通过 [layout settings](https://reference.aspose.com/slides/zh/python-java/aspose.slides/html5options/#setSlidesLayoutOptions) 将其定位（例如放在幻灯片右侧）。

**我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？**

可以，有一个 [setting](https://reference.aspose.com/slides/zh/python-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 允许在保存时跳过带有 JavaScript 调用的超链接。这会移除这些超链接，但并不能单独保证所有生成的 HTML5 脚本符合站点的内容安全策略。