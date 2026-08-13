---
title: 在 Android 上将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
type: docs
weight: 40
url: /zh/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 通过 Java 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了不使用 Web 扩展或其他依赖的基本 HTML5 导出，以及用于控制形状动画和幻灯片切换的选项。本文还展示了标准的 PowerPoint 到 HTML 导出过程，解释了如何在幻灯片视图模式下生成 HTML5 输出，并演示了通过配置布局将评论包含在导出文档中的方法。

## **将 PowerPoint 导出为 HTML5**

下面的 Java 代码演示了如何在不使用 Web 扩展和依赖的情况下将演示文稿导出为 HTML5：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 
在这种情况下，你会得到干净的 HTML。 
{{% /alert %}}

你可以这样指定形状动画和幻灯片切换的设置：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    
    pres.save("pres5.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将 PowerPoint 导出为 HTML**

下面的 Java 示例演示了标准的 PowerPoint 到 HTML 的导出过程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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
使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，无法为特定元素应用样式或进行动画。 
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许你将 PowerPoint 演示文稿转换为 HTML5 文档，并以幻灯片视图模式呈现幻灯片。这样，当在浏览器中打开生成的 HTML5 文件时，演示文稿会以网页上的幻灯片视图方式展示。 

下面的 Java 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    Html5Options html5Options = new Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);

    pres.save("HTML5-slide-view.html", SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **将演示文稿转换为带评论的 HTML5 文档**

PowerPoint 中的评论是一种工具，允许用户在演示幻灯片上留下备注或反馈。它在协作项目中尤为有用，多个成员可以对特定幻灯片元素添加建议或意见，而不会改变主要内容。每条评论都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，可以轻松指定是否在输出文档中包含演示文稿的评论。为此，需要将评论的显示参数传递给 [Html5Options](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/) 类的 `setSlidesLayoutOptions` 方法。

下面的代码示例将演示文稿转换为在幻灯片右侧显示评论的 HTML5 文档。

```java
import com.aspose.slides.*;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);

Html5Options html5Options = new Html5Options();
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下面的图片展示了生成的 “output.html” 文档。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **常见问题**

### 是否可以控制对象动画和幻灯片切换在 HTML5 中的播放？

是的，HTML5 提供了独立的选项，可启用或禁用 [shape animations](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [slide transitions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

### 是否支持输出评论，且它们可以相对于幻灯片放置在哪里？

是的，可以在 HTML5 中添加评论，并通过用于备注和评论的 [layout settings](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 将其定位（例如放在幻灯片右侧）。

### 是否可以跳过因安全或 CSP 原因而调用 JavaScript 的链接？

可以，有一个 [setting](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 允许在保存时跳过包含 JavaScript 调用的超链接，这有助于遵守严格的安全策略。