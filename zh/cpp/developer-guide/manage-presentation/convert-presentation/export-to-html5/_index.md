---
title: 导出到 HTML5
type: docs
weight: 40
url: /zh/cpp/export-to-html5/
keywords:
- PowerPoint 到 HTML
- 幻灯片到 HTML
- HTML5
- HTML 导出
- 导出演示文稿
- 转换演示文稿
- 转换幻灯片
- C++
- Aspose.Slides for C++
description: "在 C++ 中将 PowerPoint 导出为 HTML5" 
---

{{% alert title="信息" color="info" %}}

在 [Aspose.Slides 21.9](/slides/zh/cpp/aspose-slides-for-cpp-21-9-release-notes/) 中，我们实现了对 HTML5 导出的支持。

{{% /alert %}} 

这里的导出到 HTML5 过程允许您将 PowerPoint 转换为 HTML。借助您自己的模板，您可以应用非常灵活的选项来定义导出过程以及生成的 HTML、CSS、JavaScript 和动画属性。

## **将 PowerPoint 导出为 HTML5**

以下 C++ 代码演示了如何将演示文稿导出为 HTML5。

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 

在这种情况下，您将获得干净的 HTML。 

{{% /alert %}}

您可能想要以这种方式指定形状动画和幻灯片过渡的设置：

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

以下 C++ 演示了标准的 PowerPoint 到 HTML 的过程：

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

在这种情况下，演示文稿内容通过 SVG 渲染，呈现如下形式：

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

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为一个 HTML5 文档，在该文档中幻灯片呈现在幻灯片视图模式下。在这种情况下，当您在浏览器中打开生成的 HTML5 文件时，您将在网页上看到幻灯片视图模式下的演示文稿。

以下 C++ 代码演示了 PowerPoint 到 HTML5 幻灯片视图的导出过程：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## 将演示文稿转换为带注释的 HTML5 文档

PowerPoint 中的注释是允许用户在演示文稿幻灯片上留下笔记或反馈的工具。它们在协作项目中尤为有用，多个可以在不改变主要内容的情况下向特定幻灯片元素添加建议或备注。每个评论显示作者的姓名，方便追踪是谁留下的评论。

假设我们有以下保存为 "sample.pptx" 文件的 PowerPoint 演示文稿。

![演示文稿幻灯片上的两个注释](two_comments_pptx.png)

当您将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿中的注释。为此，您需要在 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 类的 `get_NotesCommentsLayouting` 方法中指定注释的显示参数。

以下代码示例将演示文稿转换为带注释显示在幻灯片右侧的 HTML5 文档。
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下面的图像显示了 "output.html" 文档。

![输出 HTML5 文档中的注释](two_comments_html5.png)