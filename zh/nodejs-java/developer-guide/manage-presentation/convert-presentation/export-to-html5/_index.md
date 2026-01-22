---
title: 在 JavaScript 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
type: docs
weight: 40
url: /zh/nodejs-java/export-to-html5/
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
- 将 PPT 导出为 HTML5
- 将 PPTX 导出为 HTML5
- 将 ODP 导出为 HTML5
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 将 PowerPoint 并 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

Aspose.Slides 支持 HTML5 导出。此处的 HTML5 导出过程允许您在没有 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

下面的 JavaScript 代码展示了如何在没有 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：
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
在这种情况下，您将获得干净的 HTML。 
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

下面的 JavaScript 演示了标准的 PowerPoint 到 HTML 过程：
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


在这种情况下，演示文稿内容通过 SVG 呈现，形式如下：
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
当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或对特定元素进行动画。 
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您将在网页上看到以幻灯片视图模式显示的演示文稿。 

下面的 JavaScript 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
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


## **将演示文稿转换为带有批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在演示幻灯片上留下笔记或反馈。它们在协作项目中特别有用，多个人员可以向特定幻灯片元素添加建议或备注，而不会更改主要内容。每条批注都会显示作者姓名，便于跟踪是谁留下的备注。

假设我们有以下保存在 "sample.pptx" 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个批注](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/) 类的 `notes_comments_layouting` 属性中指定批注的显示参数。

下面的代码示例将演示文稿转换为 HTML5 文档，并在幻灯片右侧显示批注。
```javascript
let html5Options = new aspose.slides.Html5Options();
html5Options.getNotesCommentsLayouting().setCommentsPosition(aspose.slides.CommentsPositions.Right);

let presentation = new aspose.slides.Presentation("sample.pptx");
presentation.save("output.html", aspose.slides.SaveFormat.Html5, html5Options);
presentation.dispose();
```


"output.html" 文档如下面的图像所示。

![输出 HTML5 文档中的批注](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用[形状动画](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimateshapes/)和[幻灯片切换](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/setanimatetransitions/)。

**是否支持批注的输出，且它们相对于幻灯片可以放置在何处？**

是的，批注可以在 HTML5 中添加，并通过注释和批注的[布局设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/html5options/#setNotesCommentsLayouting)（例如放置在幻灯片右侧）进行定位。

**我能否跳过出于安全或 CSP 考虑而调用 JavaScript 的链接？**

是的，有一个[设置](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setSkipJavaScriptLinks)可以在保存时跳过带有 JavaScript 调用的超链接。这有助于遵循严格的安全策略。