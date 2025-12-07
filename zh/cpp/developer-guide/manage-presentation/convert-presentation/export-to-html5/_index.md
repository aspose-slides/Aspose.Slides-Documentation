---
title: 在 C++ 中将演示文稿转换为 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/cpp/aspose-slides-for-cpp-21-9-release-notes/)，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的 HTML5 导出过程可将 PowerPoint 转换为 HTML。使用您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

下面的 C++ 代码演示如何将演示文稿导出为 HTML5。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

在此情况下，您将获得干净的 HTML。 

{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片切换的设置：
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```


## **将 PowerPoint 导出为 HTML**

下面的 C++ 示例展示了标准的 PowerPoint 到 HTML 的导出过程：
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


在此情况下，演示文稿内容通过 SVG 渲染，呈现形式如下：
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

使用此方法将 PowerPoint 导出为 HTML 时，由于 SVG 渲染，您将无法为特定元素应用样式或动画。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。此时，当您在浏览器中打开生成的 HTML5 文件时，演示文稿将在网页上以幻灯片视图模式显示。 

下面的 C++ 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **将演示文稿转换为带评论的 HTML5 文档**

PowerPoint 中的评论是允许用户在演示文稿幻灯片上留下备注或反馈的工具。它们在协作项目中尤为有用，多个用户可以向特定幻灯片元素添加建议或意见，而不会更改主要内容。每条评论都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![Two comments on the presentation slide](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，需要在 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 类的 `get_NotesCommentsLayouting` 方法中设置评论的显示参数。

下面的代码示例将演示文稿转换为带有评论且显示在幻灯片右侧的 HTML5 文档。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


下图显示了生成的 “output.html” 文档。

![The comments in the output HTML5 document](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

可以，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

**是否支持输出评论，且它们可以相对于幻灯片放置在哪里？**

可以，评论可在 HTML5 中添加，并通过备注和评论的布局设置（例如放在幻灯片右侧）进行定位。

**我能否出于安全或 CSP 考虑跳过调用 JavaScript 的链接？**

可以，有一个 [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 允许您在保存时跳过包含 JavaScript 调用的超链接。这有助于遵守严格的安全策略。