---
title: 在 Android 上将演示文稿转换为 HTML5
linktitle: 演示文稿至 HTML5
type: docs
weight: 40
url: /zh/androidjava/export-to-html5/
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
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 将 PowerPoint 与 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="Info" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/androidjava/aspose-slides-for-java-21-9-release-notes/)，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在不使用 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

以下 Java 代码演示了如何在不使用 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

在这种情况下，您会得到干净的 HTML。 

{{% /alert %}}

您也可以以这种方式指定形状动画和幻灯片切换的设置：
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


## **将 PowerPoint 导出为 HTML**

以下 Java 示例展示了标准的 PowerPoint 到 HTML 的导出过程：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
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
```


{{% alert title="Note" color="warning" %}} 

使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法对特定元素应用样式或进行动画。

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，并以幻灯片视图模式呈现幻灯片。此时，当您在浏览器中打开生成的 HTML5 文件时，演示文稿将在网页上以幻灯片视图模式显示。

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

PowerPoint 中的评论是让用户在幻灯片上留下备注或反馈的工具。它们在协作项目中尤为有用，多个人员可以对特定幻灯片元素添加建议或备注，而不会改变主体内容。每条评论都会显示作者名称，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，需要在 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 类的 `getNotesCommentsLayouting` 方法中设定评论的显示参数。

下面的代码示例演示了将演示文稿转换为在幻灯片右侧显示评论的 HTML5 文档：
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


下面的图片展示了生成的 “output.html” 文档。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**是否可以控制对象动画和幻灯片切换在 HTML5 中的播放？**

是的，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [slide transitions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支持输出评论，且它们可以相对于幻灯片放置在哪里？**

是的，HTML5 中可以添加评论，并通过针对备注和评论的 [layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 将其定位（例如放在幻灯片右侧）。

**是否可以跳过调用 JavaScript 的链接，以满足安全或 CSP 要求？**

可以，存在一个 [setting](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 允许在保存时跳过带有 JavaScript 调用的超链接，从而帮助符合严格的安全策略。