---
title: 在 PHP 中将演示文稿转换为 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/php-java/export-to-html5/
keywords:
- PowerPoint 转 HTML5
- OpenDocument 转 HTML5
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
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

Aspose.Slides 支持 HTML5 导出。此处的导出到 HTML5 过程允许您在不使用 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 PHP 代码演示如何在不使用 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html5);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
在这种情况下，您将获得干净的 HTML。 
{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片切换的设置：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(false);
    $html5Options->setAnimateTransitions(false);
    $pres->save("pres5.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将 PowerPoint 导出为 HTML**

下面的 Java 示例演示了标准的 PowerPoint 到 HTML 过程：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.html", SaveFormat::Html);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


在此情况下，演示文稿内容通过 SVG 渲染，形式如下：
```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```php


{{% alert title="Note" color="warning" %}} 
当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法对特定元素应用样式或动画。 
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，在该文档中幻灯片以幻灯片视图模式呈现。此时，当您在浏览器中打开生成的 HTML5 文件时，您将在网页上看到以幻灯片视图模式显示的演示文稿。

以下 PHP 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $html5Options = new Html5Options();
    $html5Options->setAnimateShapes(true);
    $html5Options->setAnimateTransitions(true);
    $pres->save("HTML5-slide-view.html", SaveFormat::Html5, $html5Options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **将演示文稿转换为带注释的 HTML5 文档**

PowerPoint 中的注释是一种工具，允许用户在演示文稿幻灯片上留下备注或反馈。它们在协作项目中特别有用，多个用户可以向特定幻灯片元素添加建议或意见，而不更改主体内容。每条注释都会显示作者名称，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![演示文稿幻灯片上的两个注释](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，可以轻松指定是否在输出文档中包含演示文稿的注释。为此，需要在 `Html5Options` 类的 `getNotesCommentsLayouting` 方法中指定注释的显示参数。

下面的代码示例将演示文稿转换为带有注释（显示在幻灯片右侧）的 HTML5 文档。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


下图显示了 “output.html” 文档的效果。

![输出 HTML5 文档中的注释](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) 和 [幻灯片切换](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/)。

**是否支持注释的输出，且它们可以相对于幻灯片放置在哪里？**

是的，注释可以在 HTML5 中添加，并通过针对笔记和注释的 [布局设置](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions)（例如放置在幻灯片右侧）进行定位。

**我可以跳过调用 JavaScript 的链接，以满足安全或 CSP 要求吗？**

可以，存在一个 [设置](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 允许您在保存时跳过带有 JavaScript 调用的超链接。这有助于符合严格的安全策略。