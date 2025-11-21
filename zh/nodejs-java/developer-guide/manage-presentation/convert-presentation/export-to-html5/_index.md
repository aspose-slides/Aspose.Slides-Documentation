---
title: 导出为 HTML5
type: docs
weight: 40
url: /zh/nodejs-java/export-to-html5/
keywords:
- PowerPoint 转 HTML
- 幻灯片转 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- Java
- 适用于 Node.js via Java 的 Aspose.Slides
description: 在 JavaScript 中将 PowerPoint 导出为 HTML5
---

{{% alert title="Info" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/nodejs-java/aspose-slides-for-java-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在不使用 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。这样，使用您自己的模板，您可以应用非常灵活的选项来定义导出过程及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

以下 JavaScript 代码演示如何在没有 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html5);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

在这种情况下，您会得到干净的 HTML。 

{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片切换的设置：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(false);
    html5Options.setAnimateTransitions(false);
    pres.save("pres5.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将 PowerPoint 导出为 HTML**

以下 JavaScript 演示标准的 PowerPoint 到 HTML 的导出过程：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.html", aspose.slides.SaveFormat.Html);
} finally {
    if (pres != null) {
        pres.dispose();
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
```


{{% alert title="Note" color="warning" %}} 

使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法对特定元素应用样式或进行动画。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，幻灯片以幻灯片视图模式呈现。此时，在浏览器中打开生成的 HTML5 文件，您将在网页上看到幻灯片视图模式的演示文稿。 

以下 JavaScript 代码演示 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var html5Options = new aspose.slides.Html5Options();
    html5Options.setAnimateShapes(true);
    html5Options.setAnimateTransitions(true);
    pres.save("HTML5-slide-view.html", aspose.slides.SaveFormat.Html5, html5Options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **将演示文稿转换为包含批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在演示幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个人员可以对特定幻灯片元素添加建议或备注，而不会更改主体内容。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) 类的 `notes_comments_layouting` 属性中指定批注的显示参数。

以下代码示例将演示文稿转换为在幻灯片右侧显示批注的 HTML5 文档。
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


下面的图片展示了 “output.html” 文档的效果。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**我能控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

可以，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/)。

**批注的输出是否受支持？它们可以相对于幻灯片放置在哪里？**

支持批注的输出，且可以通过 [layout settings](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting) 将其定位（例如放在幻灯片右侧）。

**我能出于安全或 CSP 考虑跳过调用 JavaScript 的链接吗？**

可以，有一个 [setting](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks) 允许在保存时跳过包含 JavaScript 调用的超链接。这有助于遵守严格的安全策略。