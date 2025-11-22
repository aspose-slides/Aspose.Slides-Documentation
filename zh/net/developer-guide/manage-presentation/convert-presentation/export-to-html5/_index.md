---
title: 导出为 HTML5
type: docs
weight: 40
url: /zh/net/export-to-html5/
keywords:
- PowerPoint 转 HTML
- 幻灯片 转 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- C#
- Csharp
- Aspose.Slides for .NET
description: "在 C# 或 .NET 中将 PowerPoint 导出为 HTML5"
---

{{% alert title="Info" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/net/aspose-slides-for-net-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。但是，如果您更倾向于使用 WebExtensions 将 PowerPoint 导出为 HTML，请参阅 [this article](/slides/zh/net/web-extensions/)。

{{% /alert %}} 

此处的 HTML5 导出过程允许您在不使用 WebExtensions 或其他依赖的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用高度灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **Export PowerPoint to HTML5**

下面的 C# 代码演示了如何在没有 WebExtensions 和依赖的情况下将演示文稿导出为 HTML5：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}} 

在这种情况下，您将获得纯净的 HTML。

{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片切换的设置：
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


## **Export PowerPoint to HTML**

下面的 C# 示例演示了标准的 PowerPoint 到 HTML 的转换过程：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


在此示例中，演示文稿内容通过 SVG 渲染，呈现形式如下：
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

使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或进行动画处理。

{{% /alert %}}

## **Export PowerPoint to HTML5 Slide View**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，并以幻灯片视图模式呈现幻灯片。这样，当您在浏览器中打开生成的 HTML5 文件时，演示文稿将在网页上以幻灯片视图模式显示。

下面的 C# 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
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


## **Convert a Presentation to an HTML5 Document with Comments**

PowerPoint 中的批注是一种工具，允许用户在幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个用户可以对特定幻灯片元素添加建议或意见，而不会更改主体内容。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个名为 “sample.pptx” 的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 类的 `NotesCommentsLayouting` 属性中设置批注的显示参数。

下面的代码示例将演示文稿转换为在幻灯片右侧显示批注的 HTML5 文档。
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


下面的图片展示了 “output.html” 文档的效果。

![The comments in the output HTML5 document](two_comments_html5.png)

## **FAQ**

**Can I control whether object animations and slide transitions will play in HTML5?**

是的，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)。

**Is the output of comments supported, and where can they be placed relative to the slide?**

是的，批注可以在 HTML5 中添加，并通过 [layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) 将其定位（例如放置在幻灯片右侧）。

**Can I skip links that invoke JavaScript for security or CSP reasons?**

是的，有一个 [setting](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 可以在保存时跳过包含 JavaScript 调用的超链接，从而帮助遵守严格的安全策略。