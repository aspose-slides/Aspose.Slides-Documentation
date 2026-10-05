---
title: 将演示文稿转换为 .NET 中的 HTML5
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

本文介绍如何使用 Aspose.Slides for .NET 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了基本导出、形状动画和幻灯片切换的控制以及注释布局。它还比较了 HTML5 输出与标准 HTML 导出的基于 SVG 的输出。

## **将 PowerPoint 导出为 HTML5**

以下示例从工作目录加载演示文稿并以 HTML5 格式保存。它使用默认的导出设置；下一个示例演示如何显式控制动画播放。将输入路径替换为您的演示文稿路径。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html5);
```

{{% alert color="info" title="注意" %}}
除了 HTML 文档外，导出还会生成用于幻灯片样式、动画、效果和导航的 CSS 和 JavaScript 支持文件。将这些文件与 HTML 文档一起移动或发布。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；若缺少它们，幻灯片导航和动画将无法运行。
{{% /alert %}}

要在导出时不播放形状动画或幻灯片切换，请在 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 中将 [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 和 [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/) 设置为 `false`。这些设置相互独立，可在禁用一个的同时启用另一个。示例在生成的页面中禁用了两种动画后导出演示文稿。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = false,
    AnimateTransitions = false
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres5.html", SaveFormat.Html5, html5Options);
```

## **将 PowerPoint 导出为 HTML**

标准 HTML 导出使用不同的渲染方式：幻灯片内容以 SVG 形式嵌入 HTML 页面。以下示例使用这种渲染方式将演示文稿转换为 HTML 文档。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
presentation.Save("pres.html", SaveFormat.Html);
```

下面的简化标记展示了生成页面的结构。SVG 元素包含渲染后的幻灯片内容；占位文本仅代表该内容，并非实际导出输出。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="警告" color="warning" %}}
基于 SVG 的导出不会将 PowerPoint 形状公开为单独的 HTML 元素。当需要本文中演示的形状动画和幻灯片切换选项时，请使用 HTML5 导出。
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

HTML5 导出生成一个用于在浏览器中查看和导航演示幻灯片的页面。此示例同时启用 [AnimateShapes](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 和 [AnimateTransitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)，以便导出的幻灯片视图能够播放源演示中的效果。

使用已包含形状动画和幻灯片切换的演示文稿以查看这些设置的效果。启用它们不会为没有动画的幻灯片添加新效果。导出后，使用支持文件可用的浏览器打开生成的 HTML5 文档。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    AnimateShapes = true,
    AnimateTransitions = true
};

using var presentation = new Presentation("pres.pptx");
presentation.Save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
```

## **将演示文稿转换为带注释的 HTML5 文档**

您可以在 HTML5 输出中包含现有幻灯片注释，使读者能够在幻灯片内容旁看到反馈。本节示例假设源演示文稿中已包含注释（如图所示），它会导出这些注释；不会创建新注释。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) 对象分配给 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 的 [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) 属性。将 [CommentsPosition](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/commentsposition/) 设置为 `Right`（来自 [CommentsPositions](https://reference.aspose.com/slides/net/aspose.slides.export/commentspositions/) 枚举），即可将注释放置在每个幻灯片的右侧。

下面的示例使用此注释布局将演示文稿导出为 HTML5。没有注释的演示文稿将不显示任何注释文本。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    CommentsPosition = CommentsPositions.Right
};

var html5Options = new Html5Options
{
    SlidesLayoutOptions = layoutOptions
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

下面的图像显示了带有注释显示在幻灯片旁边的导出 HTML5 文档。

![输出的 HTML5 文档中的注释](two_comments_html5.png)

## **导出时排除 JavaScript 超链接**

假设 `hyperlinks.pptx` 包含目标为 `javascript:alert('Hello')` 的链接文本以及普通的 `https://example.com/` 链接。要在导出时排除 JavaScript 超链接，请将 [SaveOptions.SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 设置为 `true`。默认值为 `false`，因此除非启用此选项，否则这些链接不会被过滤。

以下示例从工作目录加载演示文稿并使用 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 导出：

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options { SkipJavaScriptLinks = true };

using var presentation = new Presentation("hyperlinks.pptx");
presentation.Save("filtered-html5.html", SaveFormat.Html5, html5Options);
```

导出的文件会省略 JavaScript 超链接，但保留其文本以及普通的 HTTPS 链接。源演示文稿保持不变。

此选项仅过滤 JavaScript 超链接；它不会删除所有脚本或其他主动内容，也不保证 CSP 合规。例如，HTML5 输出仍会包含用于幻灯片导航和动画的脚本。

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

是的，HTML5 导出提供独立的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)。

**是否支持注释，且它们可以相对于幻灯片放置在哪里？**

是的，可以在 HTML5 输出中包含现有注释，并通过 [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/slideslayoutoptions/) 将其定位（例如放在幻灯片右侧）。

**我可以出于安全或 CSP 原因跳过调用 JavaScript 的链接吗？**

是的，`[SkipJavaScriptLinks](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/)` 设置允许在保存时跳过包含 JavaScript 调用的超链接。默认值为 `false`。请参阅 `[导出时排除 JavaScript 超链接](/slides/zh/net/export-to-html5/#exclude-javascript-hyperlinks-during-export)`，了解简易的 HTML、HTML5 和 PDF 导出示例以及过滤范围。此设置不会删除 HTML5 查看器用于导航和动画的 JavaScript。