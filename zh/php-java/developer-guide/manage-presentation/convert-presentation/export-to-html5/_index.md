---
title: 在 PHP 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
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
- 导出 PPT 为 HTML5
- 导出 PPTX 为 HTML5
- 导出 ODP 为 HTML5
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP（通过 Java）将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/php-java/aspose-slides-for-java-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在无需 Web 扩展或依赖的情况下将 PowerPoint 转换为 HTML。通过这种方式，使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **导出 PowerPoint 为 HTML5**

以下 PHP 代码演示如何在没有 Web 扩展和依赖的情况下将演示文稿导出为 HTML5：
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

在这种情况下，您将得到干净的 HTML。 

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


## **导出 PowerPoint 为 HTML**

以下 Java 示例演示了标准的 PowerPoint 到 HTML 的转换过程：
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

当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或对特定元素进行动画。 

{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。这样，当您在浏览器中打开生成的 HTML5 文件时，便会在网页上以幻灯片视图模式查看演示文稿。 

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


## **将演示文稿转换为带有评论的 HTML5 文档**

PowerPoint 中的评论是让用户在演示文稿幻灯片上留下备注或反馈的工具。它们在协作项目中尤为有用，多个成员可以在不修改主体内容的情况下，对特定幻灯片元素添加建议或意见。每条评论都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个保存在 `sample.pptx` 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，需要在 `Html5Options` 类的 `getNotesCommentsLayouting` 方法中指定评论的显示参数。

以下代码示例将演示文稿转换为 HTML5 文档，并将评论显示在幻灯片的右侧。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```


`output.html` 文档如下图所示。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **常见问题**

**我能控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

是的，HTML5 提供了独立的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimateshapes/) 和 [幻灯片切换](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/setanimatetransitions/)。

**是否支持输出评论？它们可以相对于幻灯片放置在哪里？**

是的，HTML5 中可以添加评论，并可通过用于备注和评论的 [布局设置](https://reference.aspose.com/slides/php-java/aspose.slides/html5options/#setSlidesLayoutOptions) 将其定位（例如放在幻灯片右侧）。

**我能为了安全或 CSP 而跳过调用 JavaScript 的链接吗？**

是的，有一个 [设置](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 允许您在保存时跳过带有 JavaScript 调用的超链接。这有助于遵守严格的安全策略。