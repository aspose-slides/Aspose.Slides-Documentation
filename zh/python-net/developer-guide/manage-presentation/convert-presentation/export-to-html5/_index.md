---
title: 在 Python 中将演示文稿转换为 HTML5
linktitle: 导出到 HTML5
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
- 转换演示文稿
- 转换幻灯片
- HTML5 导出
- 导出演示文稿
- 导出幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python，将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5，保留格式、动画和交互性。"
---

{{% alert title="信息" color="info" %}}

在 **Aspose.Slides 21.9** 中，我们实现了对 HTML5 导出的支持。但是，如果您更喜欢使用 Web 扩展将 PowerPoint 导出为 HTML，请参阅 [这篇文章](/slides/zh/net/web-extensions/)。

{{% /alert %}} 

此导出为 HTML5 的过程允许您在没有 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。这样，使用您自己的模板，您可以应用非常灵活的选项，定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 Python 代码展示了如何在没有 Web 扩展和依赖项的情况下导出演示文稿为 HTML5：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML5)
```

{{% alert color="primary" %}} 

在这种情况下，您获得的是干净的 HTML。

{{% /alert %}}

您可能希望以这种方式指定形状动画和幻灯片过渡的设置：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    options = slides.export.Html5Options()
    options.animate_shapes = False
    options.animate_transitions = False

    presentation.save("index.html", slides.export.SaveFormat.HTML5, options)
```

#### **将 PowerPoint 导出为 HTML**

以下 Python 代码演示了标准的 PowerPoint 到 HTML 的过程：

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.save("index.html", slides.export.SaveFormat.HTML)
```

在这种情况下，演示文稿内容以如下形式通过 SVG 渲染：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> 幻灯片内容在这里 </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或为特定元素动画。

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您会在网页上看到幻灯片视图模式下的演示文稿。

以下 Python 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    # 导出包含幻灯片过渡、动画和形状动画的演示文稿为 HTML5
    options = slides.export.Html5Options()
    options.animate_shapes = True
    options.animate_transitions = True

    # 保存演示文稿
    pres.save("HTML5-slide-view.html", slides.export.SaveFormat.HTML5, options)
```

## 将演示文稿转换为带注释的 HTML5 文档

PowerPoint 中的注释是一个工具，允许用户在演示幻灯片上留下笔记或反馈。它们在协作项目中尤其有用，其中多个可以在不改变主要内容的情况下，为特定幻灯片元素添加建议或备注。每条评论显示作者的姓名，便于跟踪谁留下了备注。

假设我们有以下 PowerPoint 演示文稿保存在 "sample.pptx" 文件中。

![幻灯片上的两个评论](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，可以轻松指定是否在输出文档中包括演示文稿中的注释。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/python-net/aspose.slides.export/html5options/) 类的 `notes_comments_layouting` 属性中指定注释的显示参数。

以下代码示例将演示文稿转换为显示在幻灯片右侧的注释的 HTML5 文档。
```py
html5_options = Html5Options()
html5_options.notes_comments_layouting.comments_position = CommentsPositions.RIGHT

with Presentation("sample.pptx") as presentation:
    presentation.save("output.html", SaveFormat.HTML5, html5_options)
```

下图显示了 "output.html" 文档。

![输出 HTML5 文档中的注释](two_comments_html5.png)