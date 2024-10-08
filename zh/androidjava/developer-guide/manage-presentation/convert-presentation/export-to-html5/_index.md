---
title: 导出到 HTML5
type: docs
weight: 40
url: /androidjava/export-to-html5/
keywords:
- PowerPoint 到 HTML
- 幻灯片到 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- Java
- Aspose.Slides for Android via Java
description: "在 Java 中将 PowerPoint 导出到 HTML5"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/androidjava/aspose-slides-for-java-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的导出到 HTML5 过程允许您在没有网页扩展或依赖的情况下将 PowerPoint 转换为 HTML。这样，使用您自己的模板，您可以应用非常灵活的选项，以定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **导出 PowerPoint 到 HTML5**

下面的 Java 代码展示了如何在没有网页扩展和依赖的情况下将演示文稿导出为 HTML5：

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

您可能想以这种方式指定形状动画和幻灯片过渡的设置：

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

## **导出 PowerPoint 到 HTML**

下面的 Java 代码展示了标准的 PowerPoint 到 HTML 过程：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    pres.save("pres.html", SaveFormat.Html);
} finally {
    if (pres != null) pres.dispose();
}
```

在这种情况下，演示文稿内容通过 SVG 渲染，形成如下形式：

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> 幻灯片内容在这里 </g>
     </svg>
</div>
</body>
```

{{% alert title="注意" color="warning" %}} 

当您使用此方法将 PowerPoint 导出到 HTML 时，由于 SVG 渲染，您将无法应用样式或动画特定元素。

{{% /alert %}}

## **导出 PowerPoint 到 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您会在网页上看到以幻灯片视图模式呈现的演示文稿。

下面的 Java 代码演示了 PowerPoint 到 HTML5 幻灯片视图导出过程：

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

PowerPoint 中的注释是允许用户在演示文稿幻灯片上留下备注或反馈的工具。它们在协作项目中尤其有用，多个人员可以在不改变主要内容的情况下向特定幻灯片元素添加建议或备注。每条评论显示作者的名称，使得追踪是谁留下的备注变得容易。

假设我们有以下保存在 "sample.pptx" 文件中的 PowerPoint 演示文稿。

![幻灯片上有两个注释](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否将演示文稿中的注释包含到输出文档中。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/androidjava/com.aspose.slides/html5options/) 类的 `getNotesCommentsLayouting` 方法中指定注释的显示参数。

以下代码示例将演示文稿转换为带有注释的 HTML5 文档，注释显示在幻灯片的右侧。
```java
Html5Options html5Options = new Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(CommentsPositions.Right);

Presentation presentation = new Presentation("sample.pptx");
presentation.save("output.html", SaveFormat.Html5, html5Options);
presentation.dispose();
```

"output.html" 文档在下面的图像中显示。

![输出的 HTML5 文档中的注释](two_comments_html5.png)