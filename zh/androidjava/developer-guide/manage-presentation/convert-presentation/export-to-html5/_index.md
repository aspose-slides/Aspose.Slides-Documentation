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
description: "使用 Aspose.Slides for Android（通过 Java）将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="Info" color="info" %}}
在 [Aspose.Slides 21.9](/slides/zh/androidjava/aspose-slides-for-java-21-9-release-notes/)，我们实现了对 HTML5 导出的支持。
{{% /alert %}}

此处的 HTML5 导出过程允许您在不使用 web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **导出 PowerPoint 为 HTML5**

以下 Java 代码展示了如何在不使用 web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}}
在这种情况下，您将获得干净的 HTML。
{{% /alert %}}

您可能想以这种方式指定形状动画和幻灯片切换的设置：
```java
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

以下 Java 示例演示了标准的 PowerPoint 到 HTML 的过程：
```java
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


{{% alert title="Note" color="warning" %}}
当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法对特定元素应用样式或进行动画。
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。这样，当您在浏览器中打开生成的 HTML5 文件时，您会在网页上以幻灯片视图模式查看演示文稿。

以下 Java 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```java
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

PowerPoint 中的注释是一种工具，允许用户在演示幻灯片上留下笔记或反馈。在协作项目中尤其有用，多人可以对特定幻灯片元素添加建议或评论，而不会更改主要内容。每条注释都会显示作者姓名，便于跟踪是谁留下的评论。

假设我们有一个保存在 "sample.pptx" 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个评论](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的注释。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 类的 `getNotesCommentsLayouting` 方法中指定注释的显示参数。

以下代码示例将演示文稿转换为 HTML5 文档，并将注释显示在幻灯片的右侧。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


"output.html" 文档如下图所示。

![输出 HTML5 文档中的注释](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [幻灯片切换](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支持注释的输出，它们可以相对于幻灯片放置在哪里？**

是的，HTML5 中可以添加注释，并通过备注和注释的 [布局设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 将其定位（例如放在幻灯片右侧）。

**我能否跳过调用 JavaScript 的链接以满足安全或 CSP 要求？**

是的，有一个 [设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-)，可以在保存时跳过带有 JavaScript 调用的超链接。这有助于遵守严格的安全策略。