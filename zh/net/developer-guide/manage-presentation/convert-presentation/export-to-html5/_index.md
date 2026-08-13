---
title: 在 .NET 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
type: docs
weight: 40
url: /zh/net/export-to-html5/
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
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文介绍如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了基本的 HTML5 导出以及控制形状动画和幻灯片切换的选项。文章还展示了标准的 PowerPoint 到 HTML 导出流程，说明如何在幻灯片视图模式下生成 HTML5 输出，并演示通过配置布局将评论包含在导出文档中。

## **导出 PowerPoint 为 HTML5**

此 C# 代码展示了如何将演示文稿导出为 HTML5：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
除了 HTML 文档外，导出还会写入它引用的支持文件：`pres.css`、`master.css`、`animation.js`、`effects.js` 和 `navigation.js`。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；如果没有它们，幻灯片导航和动画将无法运行。 
{{% /alert %}}

您可能想以这种方式指定形状动画和幻灯片切换的设置：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **导出 PowerPoint 为 HTML**

此 C# 示例演示了标准的 PowerPoint 到 HTML 过程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

在这种情况下，演示文稿内容通过 SVG 渲染，形式如下：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 
使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或进行动画。 
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，在该文档中幻灯片以幻灯片视图模式呈现。此时，当在浏览器中打开生成的 HTML5 文件时，您将在网页上看到幻灯片视图模式的演示文稿。 

此 C# 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **将演示文稿转换为带评论的 HTML5 文档**

PowerPoint 中的评论是一种工具，允许用户在幻灯片上留下备注或反馈。它们在协作项目中尤其有用，多个人员可以对特定幻灯片元素添加建议或备注，而不更改主体内容。每条评论都会显示作者姓名，便于追踪谁留下了该备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，需要在 [Html5Options](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/) 类的 `NotesCommentsLayouting` 属性中指定评论的显示参数。

以下代码示例将演示文稿转换为 HTML5 文档，并将评论显示在幻灯片右侧。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下面的图片展示了 “output.html” 文档的效果。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **常见问题**

### 我可以控制对象动画和幻灯片切换在 HTML5 中是否播放吗？

是的，HTML5 提供了单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animateshapes/) 和 [幻灯片切换](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/animatetransitions/)。

### 评论的输出是否受支持？它们可以相对于幻灯片放置在哪里？

是的，HTML5 中可以添加评论，并通过 [布局设置](https://reference.aspose.com/slides/zh/net/aspose.slides.export/html5options/notescommentslayouting/) 将其定位（例如放在幻灯片右侧）。

### 我能因安全或 CSP 而跳过调用 JavaScript 的链接吗？

是的，存在一个 [设置](https://reference.aspose.com/slides/zh/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 可以在保存时跳过包含 JavaScript 调用的超链接，从而帮助遵守严格的安全策略。