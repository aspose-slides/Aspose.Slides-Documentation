---
title: 导出到 HTML5
type: docs
weight: 40
url: /php-java/export-to-html5/
keywords:
- PowerPoint 到 HTML
- 幻灯片到 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- PHP
- Aspose.Slides for PHP via Java
description: "在 PHP 中将 PowerPoint 导出为 HTML5"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/php-java/aspose-slides-for-java-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的导出到 HTML5 的过程允许您在没有网页扩展或依赖的情况下将 PowerPoint 转换为 HTML。这样，使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 PHP 代码显示了如何在没有网页扩展和依赖的情况下将演示文稿导出为 HTML5：

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

您可能想以这种方式指定形状动画和幻灯片过渡的设置：

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

以下 Java 演示了标准的 PowerPoint 到 HTML 的过程：

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

在这种情况下，演示文稿内容通过 SVG 被呈现，形式如下：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> 幻灯片内容在这里 </g>
     </svg>
</div>
</body>
```php

```

{{% alert title="注意" color="warning" %}} 

当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或动画特定元素。

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您会看到网页上的演示文稿以幻灯片视图模式显示。

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

## 将演示文稿转换为包含评论的 HTML5 文档

PowerPoint 中的评论是一个工具，允许用户对演示文稿幻灯片留下笔记或反馈。它们在协作项目中尤其有用，多个人可以向特定幻灯片元素添加建议或备注，而不更改主要内容。每条评论都会显示作者的姓名，这使得跟踪谁留下备注变得简单。

假设我们有以下 PowerPoint 演示文稿保存为 "sample.pptx" 文件。

![幻灯片上的两个评论](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否将演示文稿中的评论包含在输出文档中。为此，您需要在 `Html5Options` 类的 `getNotesCommentsLayouting` 方法中指定评论的显示参数。

以下代码示例将演示文稿转换为一个包含评论、评论显示在幻灯片右侧的 HTML5 文档。
```php
$html5Options = new Html5Options();
$html5Options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);

$presentation = new Presentation("sample.pptx");
$presentation->save("output.html", SaveFormat::Html5, $html5Options);
$presentation->dispose();
```

"output.html" 文档在以下图像中显示。

![输出 HTML5 文档中的评论](two_comments_html5.png)