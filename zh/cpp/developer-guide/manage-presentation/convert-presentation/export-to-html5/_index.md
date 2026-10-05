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
## **概览**

本文说明如何使用 Aspose.Slides for C++ 将 PowerPoint 演示文稿转换为 HTML5。它涵盖了基本导出、形状动画和幻灯片切换的控制以及注释布局。它还比较了 HTML5 输出与标准 HTML 导出采用的基于 SVG 的输出。

## **将 PowerPoint 导出为 HTML5**

以下示例从工作目录加载演示文稿并将其保存为 HTML5 格式。它使用默认的导出设置；下一个示例展示了如何显式控制动画播放。请将输入路径替换为您的演示文稿路径。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
除了 HTML 文档外，导出还会生成用于幻灯片样式、动画、效果和导航的支持 CSS 和 JavaScript 文件。将这些文件与 HTML 文档一起保留，以便在移动或发布输出时使用。生成的页面还会从公共 CDN 加载 jQuery 和 Anime.js；如果没有这些文件，幻灯片导航和动画将无法运行。
{{% /alert %}}

若要在导出时不播放形状动画或幻灯片切换，可在 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 中将 `false` 传递给 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。这些设置相互独立，您可以仅启用其中一个而禁用另一个。示例在生成的页面中将两种动画均禁用后导出演示文稿。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **将 PowerPoint 导出为 HTML**

标准的 HTML 导出使用不同的渲染方式：幻灯片内容以 SVG 形式嵌入 HTML 页面中。以下示例使用此渲染方式将演示文稿转换为 HTML 文档。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

下面的简化标记展示了生成页面的结构。SVG 元素包含渲染后的幻灯片内容；占位符文本表示该内容，并非实际的导出输出。

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
基于 SVG 的导出不会将 PowerPoint 形状暴露为单独的 HTML 元素。若需要本文演示的形状动画和幻灯片切换选项，请使用 HTML5 导出。
{{% /alert %}}

## **将 PowerPoint 导出为 HTML5 幻灯片视图**

HTML5 导出生成可在浏览器中查看和导航演示文稿幻灯片的页面。此示例将 `true` 传递给 [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)，使导出的幻灯片视图能够播放源演示文稿中的效果。

请使用已经包含形状动画和幻灯片切换的演示文稿，以查看这些设置的效果。启用它们不会为没有任何效果的幻灯片添加新效果。导出后，在浏览器中打开生成的 HTML5 文档，并确保其支持文件可用。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **将演示文稿转换为带注释的 HTML5 文档**

您可以在 HTML5 输出中包含现有的幻灯片注释，以便读者在幻灯片内容旁看到反馈。本节的示例假设源演示文稿中包含注释，如下所示。它会导出这些注释，而不会创建新的注释。

![演示文稿幻灯片上的两个注释](two_comments_pptx.png)

将一个 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 对象传递给 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 的 [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) 方法。调用 [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) 并使用来自 [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) 枚举的 `CommentsPositions::Right`，将注释放置在每张幻灯片的右侧。

下面的示例使用此注释布局将演示文稿导出为 HTML5。没有注释的演示文稿将没有可显示的注释文本。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

下图显示了导出的 HTML5 文档，注释显示在幻灯片旁边。

![输出 HTML5 文档中的注释](two_comments_html5.png)

## **导出时排除 JavaScript 超链接**

假设 `hyperlinks.pptx` 包含指向 `javascript:alert('Hello')` 的链接文本以及普通的 `https://example.com/` 链接。若要在导出时排除 JavaScript 超链接，请使用 `true` 调用 [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/)。默认值为 `false`，因此除非启用此选项，否则这些链接不会被过滤。

以下示例从工作目录加载演示文稿并使用 [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) 导出它：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

导出的文件省略了 JavaScript 超链接，但保留了其文本以及普通的 HTTPS 链接。源演示文稿保持不变。

此选项仅过滤 JavaScript 超链接；它并不会移除所有脚本或其他活动内容，也不保证 CSP 合规。例如，HTML5 输出仍然包含用于幻灯片导航和动画的脚本。

## **FAQ**

**我可以控制对象动画和幻灯片切换是否在 HTML5 中播放吗？**

是的，HTML5 导出提供了单独的选项来启用或禁用 [形状动画](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) 和 [幻灯片切换](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/)。

**是否支持注释，且它们可以相对于幻灯片放置在哪里？**

是的，现有的注释可以包含在 HTML5 输出中，并可通过备注和注释的 [布局设置](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) 将其定位（例如放在幻灯片右侧）。

**我可以跳过调用 JavaScript 的链接以满足安全或 CSP 要求吗？**

是的，[set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) 方法允许在保存时跳过包含 JavaScript 调用的超链接。默认值为 `false`。请参阅 [导出时排除 JavaScript 超链接](/slides/zh/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) 获取 HTML5 导出示例及过滤范围。此设置并不会移除 HTML5 查看器用于导航和动画的 JavaScript。