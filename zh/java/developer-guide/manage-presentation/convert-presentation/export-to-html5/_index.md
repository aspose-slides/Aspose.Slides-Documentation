---
title: 在 Java 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
type: docs
weight: 40
url: /zh/java/export-to-html5/
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
- Java
- Aspose.Slides
description: "使用适用于 Java 的 Aspose.Slides 将 PowerPoint 与 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概览**

本文说明如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了不使用 Web 扩展或其他依赖项的基本 HTML5 导出，以及控制形状动画和幻灯片切换的选项。文章还展示了标准的 PowerPoint 到 HTML 导出过程，解释了如何在幻灯片视图模式下生成 HTML5 输出，并演示了通过配置布局在导出文档中包含评论的方法。

## **导出 PowerPoint 为 HTML5**

此 Java 代码展示了如何在不使用 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：

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
在这种情况下，您将获得干净的 HTML。 
{{% /alert %}}

您可能想以这种方式指定形状动画和幻灯片切换的设置：

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

## **导出 PowerPoint 为 HTML**

此 Java 示例演示了标准的 PowerPoint 到 HTML 过程：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

在这种情况下，演示文稿内容通过 SVG 渲染为如下形式：

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
使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或为特定元素添加动画。 
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，并以幻灯片视图模式呈现幻灯片。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，会在网页上以幻灯片视图模式查看演示文稿。

此 Java 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

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

PowerPoint 中的评论是一种工具，允许用户在演示文稿幻灯片上留下笔记或反馈。它们在协作项目中特别有用，多个成员可以对特定幻灯片元素添加建议或备注，而不会更改主体内容。每条评论都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有下面保存为 “sample.pptx” 的 PowerPoint 演示文稿。

![演示文稿幻灯片上的两个评论](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，请将评论的显示参数传递给 [Html5Options](https://reference.aspose.com/slides/zh/java/com.aspose.slides/html5options/) 类的 `setSlidesLayoutOptions` 方法。

以下代码示例将演示文稿转换为在幻灯片右侧显示评论的 HTML5 文档。
```java
import com.aspose.slides.*;

Html5Options html5Options = new Html5Options();

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setCommentsPosition(CommentsPositions.Right);
html5Options.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

下面的图片展示了 “output.html” 文档的效果。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **常见问题**

### 我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？

是的，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/zh/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [slide transitions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

### 是否支持评论的输出，以及它们可以相对于幻灯片放置在哪里？

是的，HTML5 中可以添加评论，并通过 [layout settings](https://reference.aspose.com/slides/zh/java/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 为备注和评论指定位置（例如，将其放置在幻灯片的右侧）。

### 我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？

是的，有一个 [setting](https://reference.aspose.com/slides/zh/java/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)，可在保存期间跳过包含 JavaScript 调用的超链接。这有助于遵守严格的安全策略。