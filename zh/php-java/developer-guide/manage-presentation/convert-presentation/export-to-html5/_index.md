---
title: 在 PHP 中将演示文稿转换为 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/php-java/export-to-html5/
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
- 将 PPT 导出为 HTML5
- 将 PPTX 导出为 HTML5
- 将 ODP 导出为 HTML5
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文介绍如何使用 Aspose.Slides for PHP via Java 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了基本导出、形状动画和幻灯片切换的控制以及评论布局。它还比较了 HTML5 输出与标准 HTML 导出的基于 SVG 的输出。

## **将 PowerPoint 导出为 HTML5**

下面的示例从工作目录加载演示文稿并将其保存为 HTML5 格式。它使用默认的导出设置；下一个示例展示了如何显式控制动画播放。请将输入路径替换为您的演示文稿路径。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html5);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
除了 HTML 文档外，导出还会生成用于幻灯片样式、动画、特效和导航的支持性 CSS 和 JavaScript 文件。将这些文件与 HTML 文档一起保留，以便在移动或发布输出时使用。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；如果没有这些文件，幻灯片导航和动画将无法运行。
{{% /alert %}}

要在导出时不播放形状动画或幻灯片切换，请在 [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) 中将 `false` 传递给 [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions)。这些设置是独立的，因此您可以启用其中一个而禁用另一个。示例在生成的页面中将两种动画均禁用后导出演示文稿。

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(false);
$html5Options->setAnimateTransitions(false);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **将 PowerPoint 导出为 HTML**

标准的 HTML 导出使用不同的渲染方式：幻灯片内容在 HTML 页面中以 SVG 形式呈现。下面的示例使用此渲染方式将演示文稿转换为 HTML 文档。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("pres.html", SaveFormat::Html);
} finally {
    $presentation->dispose();
}
```

下面的简化标记展示了生成页面的结构。SVG 元素包含渲染后的幻灯片内容；占位文本表示该内容，并非实际导出输出。

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
基于 SVG 的导出不会将 PowerPoint 形状公开为单独的 HTML 元素。当您需要本文演示的形状动画和幻灯片切换选项时，请使用 HTML5 导出。
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

HTML5 导出生成一个页面，可在浏览器中查看和导航演示文稿的幻灯片。此示例同时启用 [setAnimateShapes](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) 和 [setAnimateTransitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions)，以便导出的幻灯片视图能够播放来源演示文稿的效果。

请使用已经包含形状动画和幻灯片切换的演示文稿，以查看这些设置的效果。启用它们不会为没有效果的幻灯片添加新效果。导出后，在浏览器中打开生成的 HTML5 文档，并确保其支持文件可用。

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setAnimateShapes(true);
$html5Options->setAnimateTransitions(true);

$presentation = new Presentation("pres.pptx");
try {
    $presentation->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

## **将演示文稿转换为带评论的 HTML5 文档**

您可以在 HTML5 输出中包含现有的幻灯片评论，使阅读者能够在幻灯片内容旁看到反馈。本节的示例假设源演示文稿包含评论，如下所示。它会导出这些评论；不会创建新的评论。

![演示文稿幻灯片上的两个评论](two_comments_pptx.png)

将一个 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) 对象传递给 [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) 的 [setSlidesLayoutOptions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) 方法。使用 [setCommentsPosition](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) 从 [CommentsPositions](https://reference.aspose.com/slides/php-java/aspose.slides/commentspositions/) 枚举中选择 `Right`，将评论放置在每张幻灯片的右侧。

下面的示例使用此评论布局将演示文稿导出为 HTML5。没有评论的演示文稿将不会显示评论文本。

```php
use aspose\slides\CommentsPositions;
use aspose\slides\Html5Options;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setCommentsPosition(CommentsPositions::Right);

$html5Options = new Html5Options();
$html5Options->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

下图显示了导出的 HTML5 文档，其中评论显示在幻灯片旁侧。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **导出时排除 JavaScript 超链接**

假设 `hyperlinks.pptx` 包含指向 `javascript:alert('Hello')` 的链接文本以及普通的 `https://example.com/` 链接。要在导出时排除 JavaScript 超链接，请将 `true` 传递给 [SaveOptions::setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)。默认值为 `false`，因此除非启用此选项，否则这些链接不会被过滤。

下面的示例从工作目录加载演示文稿，并使用 [Html5Options](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/) 导出：

```php
use aspose\slides\Html5Options;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$html5Options = new Html5Options();
$html5Options->setSkipJavaScriptLinks(true);

$presentation = new Presentation("hyperlinks.pptx");
try {
    $presentation->save("filtered-html5.html", SaveFormat::Html5, $html5Options);
} finally {
    $presentation->dispose();
}
```

导出的文件会省略 JavaScript 超链接，同时保留其文本和普通的 HTTPS 链接。源演示文稿保持不变。

此选项仅过滤 JavaScript 超链接；它不会删除所有脚本或其他活动内容，也不能保证 CSP 合规性。例如，HTML5 输出仍然包含用于幻灯片导航和动画的脚本。

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**
是的，HTML5 导出提供了独立的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateShapes) 和 [slide transitions](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setAnimateTransitions)。

**是否支持评论？它们可以相对于幻灯片放置在哪里？**
是的，现有的评论可以包含在 HTML5 输出中，并可通过笔记和评论的 [layout settings](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) 将其定位（例如，放在幻灯片右侧）。

**我可以因为安全或 CSP 原因跳过调用 JavaScript 的链接吗？**
是的，[setSkipJavaScriptLinks](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 设置允许您在保存时跳过包含 JavaScript 调用的超链接。默认值为 `false`。请参阅 [Exclude JavaScript Hyperlinks During Export](/slides/zh/php-java/export-to-html5/#exclude-javascript-hyperlinks-during-export) 获取 HTML5 导出示例及过滤范围。此设置不会删除 HTML5 查看器用于导航和动画的 JavaScript。