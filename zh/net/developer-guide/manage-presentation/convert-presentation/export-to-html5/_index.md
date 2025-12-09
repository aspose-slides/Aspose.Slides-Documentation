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
- 将 PPT 导出为 HTML5
- 将 PPTX 导出为 HTML5
- 将 ODP 导出为 HTML5
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="信息" color="info" %}}
在 [Aspose.Slides 21.9](/slides/zh/net/aspose-slides-for-net-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。不过，如果您更喜欢使用 WebExtensions 将 PowerPoint 导出为 HTML，请改为查看 [本文](/slides/zh/net/web-extensions/)。
{{% /alert %}}

此处的 HTML5 导出过程允许您在不使用 WebExtensions 或任何依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **导出 PowerPoint 为 HTML5**
这段 C# 代码展示了如何在不使用 WebExtensions 和依赖项的情况下将演示文稿导出为 HTML5：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```


{{% alert color="primary" %}}
在这种情况下，您将获得干净的 HTML。
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


## **导出 PowerPoint 为 HTML**
这段 C# 代码演示了标准的 PowerPoint 到 HTML 的转换过程：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```


在这种情况下，演示文稿的内容会通过 SVG 渲染，如下所示：
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
当您使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或动画。
{{% /alert %}}

## **导出 PowerPoint 为 HTML5 幻灯片视图**
**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，并以幻灯片视图模式呈现幻灯片。在这种情况下，您在浏览器中打开生成的 HTML5 文件时，会在网页上以幻灯片视图模式查看演示文稿。
这段 C# 代码展示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
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


## **将演示文稿转换为包含批注的 HTML5 文档**
PowerPoint 中的批注是一种工具，允许用户在幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个成员可以对特定幻灯片元素添加建议或评论，而不会更改主体内容。每条批注都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有一个保存为 “sample.pptx” 的 PowerPoint 演示文稿。

![幻灯片上的两个批注](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 类的 `NotesCommentsLayouting` 属性中设置批注的显示参数。

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


下图展示了 “output.html” 文档的效果。

![输出 HTML5 文档中的批注](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**  
是的，HTML5 提供单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animateshapes/) 和 [幻灯片切换](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/animatetransitions/)。

**HTML5 是否支持批注输出，且可以相对于幻灯片放置在哪里？**  
是的，批注可以在 HTML5 中添加，并可通过 [布局设置](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/notescommentslayouting/) 将其定位（例如放在幻灯片右侧）。

**我可以为了安全或 CSP 原因跳过调用 JavaScript 的链接吗？**  
可以，有一个 [设置](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) 允许在保存时跳过带有 JavaScript 调用的超链接，这有助于遵守严格的安全策略。