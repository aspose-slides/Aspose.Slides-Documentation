---
title: 将演示文稿转换为 HTML5（Python）
linktitle: 导出为 HTML5
type: docs
weight: 40
url: /zh/python-net/export-to-html5/
keywords:
- PowerPoint 转 HTML5
- OpenDocument 转 HTML5
- 演示文稿 转 HTML5
- 幻灯片 转 HTML5
- PPT 转 HTML5
- PPTX 转 HTML5
- ODP 转 HTML5
- 转换 PowerPoint
- 转换 OpenDocument
- 转换 演示文稿
- 转换 幻灯片
- HTML5 导出
- 导出 演示文稿
- 导出 幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 将 PowerPoint 与 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="Info" color="info" %}}

在 **Aspose.Slides 21.9** 中，我们实现了对 HTML5 导出的支持。不过，如果您更倾向于使用 WebExtensions 将 PowerPoint 导出为 HTML，请参阅[本文](/slides/zh/net/web-extensions/)。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在不使用 WebExtensions 或其他依赖的情况下将 PowerPoint 转换为 HTML。通过使用自定义模板，您可以灵活地设置导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 Python 代码演示了如何在没有 WebExtensions 和依赖的情况下将演示文稿导出为 HTML5：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

在这种情况下，您将得到干净的 HTML。 

{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片切换的设置：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

## **将 PowerPoint 导出为 HTML**

以下 Python 代码演示了标准的 PowerPoint 到 HTML 过程：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

此时，演示文稿内容将通过 SVG 进行渲染，形式如下：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 

使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或动画。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，在该文档中幻灯片以幻灯片视图模式呈现。此时，在浏览器中打开生成的 HTML5 文件，即可在网页上以幻灯片视图模式查看演示文稿。

以下 Python 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # 导出包含幻灯片切换、动画和形状动画的演示文稿为 HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # 保存演示文稿
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## **将演示文稿转换为带注释的 HTML5 文档**

PowerPoint 中的注释是一种工具，允许用户在演示文稿幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个成员可以在不改动主体内容的前提下，对特定幻灯片元素添加建议或说明。每条注释都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的注释。为此，需要在 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 类的 `notes_comments_layouting` 属性中设置注释的显示参数。

以下代码示例将演示文稿转换为在幻灯片右侧显示注释的 HTML5 文档。

```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

下面的图片展示了生成的 “output.html” 文档。

![The comments in the output HTML5 document](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

可以，HTML5 提供了单独的选项来启用或禁用[形状动画](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_shapes/)和[幻灯片切换](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/animate_transitions/)。

**是否支持输出注释，它们可以相对于幻灯片放置在哪里？**

支持，您可以通过[布局设置](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/notes_comments_layouting/)将注释放置在幻灯片的任意位置（例如右侧）。

**我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？**

可以，存在一个[设置](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/skip_java_script_links/)，允许在保存时跳过包含 JavaScript 调用的超链接，从而符合严格的安全策略。