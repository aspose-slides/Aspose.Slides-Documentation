---
title: 导出到 HTML5
type: docs
weight: 40
url: /net/export-to-html5/
keywords:
- PowerPoint 到 HTML
- 幻灯片到 HTML
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

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/net/aspose-slides-for-net-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。然而，如果您更喜欢使用 Web 扩展将 PowerPoint 导出为 HTML，请参阅 [这篇文章](/slides/net/web-extensions/)。

{{% /alert %}}

导出到 HTML5 的过程允许您在不使用 Web 扩展或依赖项的情况下将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用定义导出过程及生成的 HTML、CSS、JavaScript 和动画属性的灵活选项。

## **将 PowerPoint 导出为 HTML5**

以下 C# 代码演示了如何在没有 Web 扩展和依赖项的情况下将演示文稿导出为 HTML5：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}}

在这种情况下，您将获得干净的 HTML。

{{% /alert %}}

您可能希望以这种方式指定形状动画和幻灯片过渡的设置：

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

#### **将 PowerPoint 导出为 HTML**

以下 C# 代码演示了标准的 PowerPoint 到 HTML 过程：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

在这种情况下，演示文稿的内容通过 SVG 以以下形式呈现：

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

当您使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法应用样式或动画特定元素。

{{% /alert %}}

## **导出 PowerPoint 至 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您将在网页上看到演示文稿的幻灯片视图模式。

以下 C# 代码演示了 PowerPoint 到 HTML5 幻灯片视图导出过程：

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

## 将演示文稿转换为带注释的 HTML5 文档

PowerPoint 中的注释是允许用户在演示文稿幻灯片上留下笔记或反馈的工具。它们在协作项目中尤其有用，在这种情况下，多个人可以向特定幻灯片元素添加建议或备注，而不改变主要内容。每个注释会显示作者的姓名，便于跟踪是谁留下的评论。

假设我们有以下保存为 "sample.pptx" 文件的 PowerPoint 演示文稿。

![幻灯片上有两个注释](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否将演示文稿中的注释包含在输出文档中。要做到这一点，您需要在 [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/) 类的 `NotesCommentsLayouting` 属性中指定注释的展示参数。

以下代码示例将演示文稿转换为带有注释显示在幻灯片右侧的 HTML5 文档。
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

"output.html" 文档在下面的图像中显示。

![输出 HTML5 文档中的注释](two_comments_html5.png)