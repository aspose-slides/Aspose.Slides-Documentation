---
title: 使用 C++ 将 PowerPoint 演示文稿转换为 HTML
linktitle: PowerPoint 转 HTML
type: docs
weight: 30
url: /zh/cpp/convert-powerpoint-to-html/
keywords:
- 转换 PowerPoint
- 转换演示文稿
- 转换幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 HTML
- 演示文稿转 HTML
- 幻灯片转 HTML
- PPT 转 HTML
- PPTX 转 HTML
- 将 PowerPoint 保存为 HTML
- 将演示文稿保存为 HTML
- 将幻灯片保存为 HTML
- 将 PPT 保存为 HTML
- 将 PPTX 保存为 HTML
- 导出 PPT 为 HTML
- 导出 PPTX 为 HTML
- C++
- Aspose.Slides
description: "使用 C++ 将 PowerPoint 演示文稿转换为 HTML。使用 Aspose.Slides 导出 PPT 和 PPTX 文件、选定的幻灯片、备注、字体、图像、SVG 和媒体。"
---
## **概述**

Aspose.Slides for C++ 可以在没有 Microsoft PowerPoint 的情况下将 PowerPoint 演示文稿保存为 HTML。基本的转换只需一次 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 加载，再调用带有 [SaveFormat](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/saveformat/) 的 `Save`。当需要控制导出布局、字体、图像、备注、批注、SVG 输出或链接资源时，请使用 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/)。

本指南侧重于实用的 HTML 导出场景：

- 导出整个演示文稿或选定的幻灯片。
- 生成固定布局、响应式或基于 SVG 的 HTML。
- 包含演讲者备注和批注。
- 控制图像质量和裁剪图像数据。
- 嵌入字体或单独保存字体文件。
- 选择外部资源和媒体文件的写入方式及引用方式。

默认情况下，HTML 导出生成一个自包含的 HTML 文档，其中大多数资源都已内嵌。这对于共享单个文件很方便，但会增加输出大小。对网页发布而言，可考虑使用外部资源、降低图像 DPI，并仅嵌入目标环境中不可靠的字体。

## **将演示文稿转换为 HTML**

要将演示文稿导出为 HTML，使用 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 加载它，并使用 `SaveFormat::Html` 保存。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

此示例写入一个 HTML 文件。调用 `Dispose` 可在导出后释放文件句柄和渲染资源。

## **使用 HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 是 HTML 导出的主要配置类。常用设置包括：

- `SlidesLayoutOptions`：添加备注、批注、讲义或其他布局信息。
- `HtmlFormatter`：更改 HTML 文档结构或将格式化委托给控制器。
- `SlideImageFormat`：更改幻灯片的表示方式，例如作为 SVG。
- `PicturesCompression`：控制图像 DPI 和输出大小。
- `DeletePicturesCroppedAreas`：保留或删除裁剪的图像数据。
- `SvgResponsiveLayout`：使导出的 SVG 内容适应其容器。
- `ShowHiddenSlides`：在需要时包含隐藏幻灯片。

以下章节分别展示最常用的选项，以便仅组合工作流所需的部分。

## **将选定幻灯片转换为 HTML**

接受幻灯片编号的 `Presentation::Save` 重载使用基于 1 的幻灯片位置。下面的循环将每张幻灯片保存为单独的 HTML 文件。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

当网站或应用需要每张幻灯片对应一个 HTML 页面时请使用此模式。如果每张幻灯片应使用相同的布局，请创建一个 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 实例并将其传递给每个 `Save` 调用。

## **创建响应式 HTML**

[ResponsiveHtmlController](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/responsivehtmlcontroller/) 通过 [HtmlFormatter](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmlformatter/) 提供响应式 HTML 输出。当导出页面需更好地适应浏览器宽度时使用它。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

对于基于 SVG 的响应式布局，请在 [HtmlOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/htmloptions/) 上设置 `SvgResponsiveLayout`。当幻灯片内容以可伸缩的 SVG 标记导出时，这非常有用。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **包含演讲者备注和批注**

通过 `HtmlOptions.SlidesLayoutOptions` 使用 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/notescommentslayoutingoptions/) 来包含演讲者备注或批注。除非显式指定位置，否则备注和批注默认隐藏。

假设源演示文稿包含演讲者备注：

![PowerPoint 中带有演讲者备注的幻灯片](slide_with_notes.png)

下面的代码将幻灯片内容连同幻灯片下方的演讲者备注一起导出。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

导出的 HTML 包含备注区域：

![包含幻灯片和演讲者备注的 HTML 输出](HTML_with_notes.png)

要导出批注，请设置 `CommentsPosition`，例如 `CommentsPositions::Right` 或 `CommentsPositions::Bottom`。仅需要批注时可省略 `NotesPosition`。若需同时显示备注和批注，则同时设置两个属性。

## **控制图像质量和裁剪区域**

HTML 导出可以压缩幻灯片图像以降低输出大小。当需要更高图像质量时，将 `PicturesCompression` 设置为 [PicturesCompression](https://reference.aspose.com/slides/zh/cpp/aspose.slides.export/picturescompression/) 中的相应值。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

默认情况下，图像的裁剪区域可能会从导出结果中移除。仅当用户必须能够恢复或检查这些隐藏的图像部分时才保留裁剪数据。保留裁剪数据会增加 HTML 大小。

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **添加 CSS**

对于简单的样式，可将 CSS 字符串传递给 `HtmlFormatter::CreateDocumentFormatter`。这会更改外围 HTML 文档，而 Aspose.Slides 仍负责渲染幻灯片内容。

{{23b4b506-21c1-4753-a