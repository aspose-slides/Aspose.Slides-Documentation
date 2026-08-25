---
title: C++ 中的低代码演示文稿操作
linktitle: 低代码 API
type: docs
weight: 50
url: /zh/cpp/low-code-presentation-operations/
keywords:
- 低代码演示文稿 API
- 转换演示文稿
- 合并演示文稿
- 遍历幻灯片
- 遍历形状
- 遍历文本
- 收集形状
- 压缩演示文稿
- 删除未使用的母版幻灯片
- 删除未使用的布局幻灯片
- 压缩嵌入式字体
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 低代码 API 来转换和合并演示文稿，遍历内容，收集形状，并减小演示文稿大小。"
---
## **概述**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/) 命名空间为常见的演示文稿操作提供静态帮助类。这些帮助类将常用的对象模型工作流封装在专注的方法中，因而您可以使用更少的代码实现文件的转换或合并、处理演示文稿元素、收集形状以及删除未使用的内容。

当操作适用于整个文件或演示文稿且默认工作流符合您的需求时，低代码帮助程序最有用。当您需要对单个幻灯片、母版、布局、形状、导出设置或演示文稿元素之间的关系进行细粒度控制时，请使用完整的 [Aspose.Slides object model](https://reference.aspose.com/slides/zh/cpp/aspose.slides/)。

下表概述了可用的帮助程序：

| 帮助程序 | 适用场景 |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/convert/) | 将演示文稿转换为另一种格式，直接进行文件到文件的调用。 |
| [Merger](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/merger/) | 合并同一格式的完整演示文稿文件。 |
| [ForEach](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/) | 对每个幻灯片、形状、段落或文本片段执行操作。 |
| [Collect](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/collect/) | 从整个演示文稿中检索形状，以便重复处理或分析。 |
| [Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) | 删除未使用的母版和布局并压缩嵌入式字体数据。 |

## **转换演示文稿**

当输出文件扩展名足以确定导出格式时，请使用 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/convert/autobyextension/)。该方法打开源演示文稿，根据输出路径确定所需格式并写入结果。

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

[Convert](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/convert/) 类还提供针对 PDF、SVG、JPEG、PNG 和 TIFF 输出的专用方法。当您需要在导出前检查或修改演示文稿，或配置选定帮助程序未公开的导出选项时，请使用完整的对象模型。有关特定格式的工作流和选项，请参见 [Convert Presentation](/slides/zh/cpp/convert-presentation/)。

## **合并演示文稿**

使用 [Merger::Process](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/merger/process/) 可以一次调用合并完整的演示文稿文件。输入的演示文稿必须具有相同的文件格式。

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

当所有幻灯片应直接追加到一个结果中且无需单独选择或重新映射时，该帮助程序适用。当您需要合并特定幻灯片、应用目标母版或布局、显式保留章节，或统一不同的幻灯片尺寸时，请使用完整的对象模型。有关这些场景，请参见 [Merge Presentations](/slides/zh/cpp/merge-presentation/)。

## **遍历演示文稿元素**

[ForEach](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/) 类为每种请求的演示文稿元素类型调用回调函数。它避免了嵌套的集合循环，便于对整个演示文稿进行检查或格式更改。

以下示例使用 [ForEach::Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/slide/)、[ForEach::Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/paragraph/)、和 [ForEach::Portion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/portion/) 来检查相应的元素：

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

默认情况下，遍历整个演示文稿的形状和文本会包括普通、母版和布局幻灯片。带有 `includeNotes` 参数的重载还可以处理备注幻灯片。当遍历顺序、提前退出、在回调调用前进行过滤，或需要细粒度的父子关系控制时，请使用直接的集合循环。

## **收集形状**

当您需要获取演示文稿中所有形状的集合，而不是对每个形状进行回调时，请使用 [Collect::Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/collect/shapes/)。当同一集合需要多次过滤、计数或处理时，这非常有用。

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

如果每个形状可以立即处理且不需要保留收集结果，请改用 [ForEach::Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/shape/)。

## **压缩演示文稿内容**

[Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) 类可以删除未使用的结构元素并压缩嵌入式字体数据：

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) 删除没有普通幻灯片引用的布局幻灯片。
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) 删除不再使用的母版幻灯片。
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) 从嵌入式字体中移除未使用的字符。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

先删除未使用的布局，再删除未使用的母版，这样在布局清理后变为未引用的母版也可以被移除。如果以后可能需要原始的母版、布局或完整的嵌入式字体数据，请将优化后的演示文稿保存为新文件。有关详细信息，请参见 [Slide Master](/slides/zh/cpp/slide-master/) 和 [Embedded Font](/slides/zh/cpp/embedded-font/)。

## **常见问题**

**何时应该使用低代码 API 而不是完整的对象模型？**

当标准操作适用于整个文件或演示文稿且不需要对单个元素进行细粒度控制时，可以使用低代码帮助程序。需要选择特定幻灯片、控制母版和布局关系、检查中间状态或配置帮助程序未公开的行为时，请使用完整的对象模型。

**Merger 能够合并不同文件格式的演示文稿吗？**

不能。[Merger::Process](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/merger/process/) 要求输入的演示文稿具有相同的格式。请先将输入文件转换为统一格式，例如使用 [Convert::AutoByExtension](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/convert/autobyextension/)，然后再合并转换后的文件。

**ForEach 会处理母版、布局和备注幻灯片吗？**

[ForEach::Slide](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/slide/) 仅遍历普通演示幻灯片。面向整个演示文稿的 [ForEach::Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/shape/)、[ForEach::Paragraph](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/paragraph/) 和 [ForEach::Portion](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/portion/) 默认包括普通、母版和布局幻灯片。使用带有 `includeNotes` 参数并设置为 `true` 的重载可包含备注幻灯片。

**ForEach::Shape 与 Collect::Shapes 有何区别？**

如需通过回调立即处理每个形状，请使用 [ForEach::Shape](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/shape/)。当需要一个可保留、过滤、计数或多次遍历的可枚举结果时，请使用 [Collect::Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/collect/shapes/)。

**Compress 总是会使演示文稿文件变小吗？**

不一定。结果取决于演示文稿是否包含未使用的布局、未使用的母版或包含未使用字符的嵌入式字体。如果这些都不存在，相应的 [Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) 操作可能不会减小文件大小。

**ForEach 或 Compress 所做的更改会自动保存吗？**

不会。这些帮助程序在内存中对已加载的 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 对象进行操作。 在 [ForEach](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/foreach/) 回调中更改元素或运行 [Compress](https://reference.aspose.com/slides/zh/cpp/aspose.slides.lowcode/compress/) 后，需调用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 将结果写入文件。

## **相关文章**

- [转换演示文稿](/slides/zh/cpp/convert-presentation/)
- [合并演示文稿](/slides/zh/cpp/merge-presentation/)
- [幻灯片母版](/slides/zh/cpp/slide-master/)
- [管理文本框](/slides/zh/cpp/manage-textbox/)
- [嵌入式字体](/slides/zh/cpp/embedded-font/)