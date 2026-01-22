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
description: "通过 Java 使用适用于 Android 的 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

Aspose.Slides 支持 HTML5 导出。此处的 HTML5 导出过程允许您在无需 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。这样，使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

下面的 Java 代码展示了如何在没有 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
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

您可以通过以下方式指定形状动画和幻灯片切换的设置：
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

下面的 Java 演示了标准的 PowerPoint 到 HTML 的过程：
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

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，使用浏览器打开生成的 HTML5 文件时，您将在网页上以幻灯片视图模式观看演示文稿。 

下面的 Java 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
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


## **将演示文稿转换为带有批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在演示幻灯片上留下备注或反馈。它们在协作项目中尤其有用，多个人员可以在不更改主要内容的前提下，对特定幻灯片元素添加建议或备注。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个保存在 "sample.pptx" 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个批注](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 类的 `getNotesCommentsLayouting` 方法中指定批注的显示参数。

下面的代码示例将演示文稿转换为 HTML5 文档，并将批注显示在幻灯片的右侧。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```


"output.html" 文档如下面的图片所示。

![输出 HTML5 文档中的批注](two_comments_html5.png)

## **常见问题**

**我能控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 和 [幻灯片切换](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-)。

**是否支持输出批注，以及可以相对于幻灯片放置在哪里？**

是的，批注可以在 HTML5 中添加，并通过用于备注和批注的 [布局设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) 将其定位（例如放在幻灯片的右侧）。

**我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？**

是的，有一个 [设置](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setSkipJavaScriptLinks-boolean-) 可以在保存时跳过带有 JavaScript 调用的超链接。这有助于遵守严格的安全策略。