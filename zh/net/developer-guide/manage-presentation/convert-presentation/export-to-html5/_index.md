---
title: 在 .NET 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
type: docs
weight: 40
url: /zh/net/export-to-html5/
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
- 导出 PPT 到 HTML5
- 导出 PPTX 到 HTML5
- 导出 ODP 到 HTML5
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="Info" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/net/aspose-slides-for-net-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。不过，如果您更倾向于使用 WebExtensions 将 PowerPoint 导出为 HTML，请改为参阅[本文](/slides/zh/net/web-extensions/)。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在无需 WebExtensions 或任何依赖的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **导出 PowerPoint 为 HTML5**

此 C# 代码展示了如何在没有 WebExtensions 和任何依赖的情况下将演示文稿导出为 HTML5：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

在这种情况下，您将获得干净的 HTML。 

{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片过渡的设置：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```


## **导出 PowerPoint 为 HTML**

此 C# 示例演示了标准的 PowerPoint 到 HTML 的转换过程：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
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

使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或进行动画。 

{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。这样，当您在浏览器中打开生成的 HTML5 文件时，便会在网页上以幻灯片视图模式查看演示文稿。 

此 C# 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```


## **将演示文稿转换为带有批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在演示文稿幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个用户可以对特定幻灯片元素添加建议或意见，而不会更改主要内容。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个保存为 "sample.pptx" 的 PowerPoint 演示文稿。

![演示幻灯片上的两个批注](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 类的 `NotesCommentsLayouting` 属性中指定批注的显示参数。

下面的代码示例将演示文稿转换为 HTML5 文档，并将批注显示在幻灯片的右侧。
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```


输出的 "output.html" 文档在下图中展示。

![输出 HTML5 文档中的批注](two_comments_html5.png)

## **常见问题**

**我能控制对象动画和幻灯片过渡是否在 HTML5 中播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用[形状动画](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/)和[幻灯片过渡](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)。

**是否支持批注的输出，它们可以相对于幻灯片放置在何处？**

是的，HTML5 中可以添加批注，并通过[布局设置](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/)（例如，将其放置在幻灯片的右侧）进行定位。

**我能因安全或 CSP 的原因跳过调用 JavaScript 的链接吗？**

是的，有一个[设置](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/)，可以在保存时跳过包含 JavaScript 调用的超链接。这有助于符合严格的安全策略。