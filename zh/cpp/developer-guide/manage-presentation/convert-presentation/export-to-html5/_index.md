---
title: 在 C++ 中将演示文稿转换为 HTML5
linktitle: 演示文稿转 HTML5
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
description: "使用适用于 C++ 的 Aspose.Slides 将 PowerPoint 和 OpenDocument 演示文稿导出为响应式 HTML5。保留格式、动画和交互性。"
---
## **概述**

本文介绍了如何使用 Aspose.Slides 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了不带 Web 扩展或额外依赖的基本 HTML5 导出，以及用于控制形状动画和幻灯片转场的选项。文章还展示了标准的 PowerPoint 到 HTML 导出流程，解释了如何在幻灯片视图模式下生成 HTML5 输出，并演示了通过配置布局将批注包含在导出文档中的方法。

## **将 PowerPoint 导出为 HTML5**

此 C++ 代码演示了如何将演示文稿导出为 HTML5。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}} 
在这种情况下，您将获得干净的 HTML。 
{{% /alert %}}

您可以通过以下方式指定形状动画和幻灯片转场的设置：

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **将 PowerPoint 导出为 HTML**

此 C++ 示例演示了标准的 PowerPoint 到 HTML 过程：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

在此情况下，演示文稿内容通过 SVG 渲染为如下形式：

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

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

**Aspose.Slides** 允许您将 PowerPoint 演示文稿转换为 HTML5 文档，并在其中以幻灯片视图模式呈现幻灯片。这样，当在浏览器中打开生成的 HTML5 文件时，您将在网页上以幻灯片视图模式查看演示文稿。

此 C++ 代码演示了 PowerPoint 到 HTML5 幻灯片视图导出的过程：

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **将演示文稿转换为带批注的 HTML5 文档**

PowerPoint 中的批注是一种工具，允许用户在演示幻灯片上留下备注或反馈。它们在协作项目中尤为有用，多个人员可以在不更改主体内容的情况下，对特定幻灯片元素添加建议或评论。每条批注都会显示作者姓名，便于追踪评论来源。

假设我们有以下保存在 “sample.pptx” 文件中的 PowerPoint 演示文稿。

![演示幻灯片上的两个批注](two_comments_pptx.png)

将 PowerPoint 演示文稿转换为 HTML5 文档时，您可以轻松指定是否在输出文档中包含演示文稿的批注。为此，需要在 [Html5Options](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/) 类的 `get_NotesCommentsLayouting` 方法中设定批注的显示参数。

下面的代码示例将演示文稿转换为带有批注（显示在幻灯片右侧）的 HTML5 文档。
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下图显示了生成的 “output.html” 文档。

![输出 HTML5 文档中的批注](two_comments_html5.png)

## **常见问题**

### 我可以控制对象动画和幻灯片转场在 HTML5 中是否播放吗？

可以，HTML5 提供了独立的选项来启用或禁用 [shape animations](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [slide transitions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

### 是否支持批注的输出？批注可以相对于幻灯片放置在哪里？

支持，批注可以在 HTML5 中添加，并通过备注和批注的布局设置（例如放在幻灯片右侧）进行定位。

### 我可以为安全或 CSP 考虑而跳过调用 JavaScript 的链接吗？

可以，存在一个 [setting](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 可在保存时跳过包含 JavaScript 调用的超链接，从而帮助遵守严格的安全策略。