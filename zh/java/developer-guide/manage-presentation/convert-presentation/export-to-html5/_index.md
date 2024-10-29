---
title: 导出为 HTML5
type: docs
weight: 40
url: /zh/java/export-to-html5/
keywords:
- PowerPoint 到 HTML
- 幻灯片到 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- Java
- Aspose.Slides for Java
description: "在 Java 中将 PowerPoint 导出为 HTML5"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/java/aspose-slides-for-java-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

这里的 HTML5 导出过程允许您将 PowerPoint 转换为 HTML，而无需 web 扩展或依赖项。这样，您可以使用自己的模板，应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 Java 代码演示了如何在没有 web 扩展和依赖项的情况下将演示文稿导出为 HTML5：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html5);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

在这种情况下，您得到的是干净的 HTML。 

{{% /alert %}}

您可能希望以这种方式指定形状动画和幻灯片转换的设置：

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

以下 Java 演示了标准的 PowerPoint 到 HTML 过程：

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
         <g> 幻灯片内容在此 </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

当您使用此方法将 PowerPoint 导出为 HTML 时，因 SVG 渲染，您将无法应用样式或对特定元素进行动画处理。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您将看到网页上的演示文稿以幻灯片视图模式显示。

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

## 将演示文稿转换为带注释的 HTML5 文档

PowerPoint 中的注释是一种工具，允许用户在演示幻灯片上留下笔记或反馈。它们在协作项目中特别有用，多个用户可以向特定幻灯片元素添加建议或评论，而不会更改主要内容。每个注释显示作者的姓名，使得跟踪谁留下了备注变得简单。

假设我们有以下保存在 "sample.pptx" 文件中的 PowerPoint 演示文稿。

![幻灯片上的两个注释](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿中的注释。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/java/com.aspose.slides/html5options/) 类的 `getNotesCommentsLayouting` 方法中指定注释的显示参数。

以下代码示例将演示文稿转换为带有右侧注释的 HTML5 文档。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" 文档在下面的图像中显示。

![输出 HTML5 文档中的注释](two_comments_html5.png)