---
title: 将演示文稿转换为 C++ 中的 HTML5
linktitle: 演示文稿到 HTML5
type: docs
weight: 40
url: /zh/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/cpp/aspose-slides-for-cpp-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

此处的 HTML5 导出过程允许您将 PowerPoint 转换为 HTML。通过使用您自己的模板，您可以应用非常灵活的选项，以定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。 

## **将 PowerPoint 导出为 HTML5**

下面的 C++ 代码展示了如何将演示文稿导出为 HTML5。
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```


{{% alert color="primary" %}} 

在这种情况下，您会得到干净的 HTML。 

{{% /alert %}}

您可能希望以这种方式为形状动画和幻灯片切换指定设置：
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

下面的 C++ 示例演示了标准的 PowerPoint 到 HTML 的转换过程：
```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```


在这种情况下，演示文稿的内容通过 SVG 渲染，形式如下：
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

当您使用此方法将 PowerPoint 导出为 HTML 时，由于采用 SVG 渲染，您将无法对特定元素应用样式或进行动画。 

{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，其中幻灯片以幻灯片视图模式呈现。 在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您将在网页上看到以幻灯片视图模式展示的演示文稿。 

下面的 C++ 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```


## **将演示文稿转换为带评论的 HTML5 文档**

PowerPoint 中的评论是一种工具，允许用户在演示文稿的幻灯片上留下备注或反馈。它们在协作项目中尤其有用，多个人员可以对特定幻灯片元素添加建议或备注，而不修改主要内容。每条评论都会显示作者姓名，便于追踪是谁留下的备注。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![演示文稿幻灯片上的两个评论](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的评论。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 类的 `get_NotesCommentsLayouting` 方法中指定评论的显示参数。

下面的代码示例将演示文稿转换为带有显示在幻灯片右侧的评论的 HTML5 文档。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```


下面的图片展示了 “output.html” 文档的效果。

![输出 HTML5 文档中的评论](two_comments_html5.png)

## **常见问题**

**我可以控制对象动画和幻灯片切换在 HTML5 中是否播放吗？**

是的，HTML5 提供了单独的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

**支持输出评论吗？它们可以相对于幻灯片放置在哪里？**

是的，评论可以在 HTML5 中添加，并通过备注和评论的布局设置（例如放置在幻灯片右侧）进行定位。

**我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？**

是的，有一个 [setting](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 可以在保存时跳过包含 JavaScript 调用的超链接。这有助于遵守严格的安全策略。