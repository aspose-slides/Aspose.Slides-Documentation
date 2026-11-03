---
title: 在 C++ 中管理演示占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/cpp/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图像占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何检查和编辑文本、图片、图表和内容占位符，并使用 Aspose.Slides for C++ 理解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示模板中为特定类型的内容保留位置。常见示例包括标题、正文、图片、图表以及通用内容占位符。与普通形状不同，占位符可以从布局幻灯片或母版幻灯片继承其位置、大小、格式以及其他设置。

Aspose.Slides 通过 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 方法公开占位符信息。该方法返回一个 [IPlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/) 对象，若为普通形状则返回 `nullptr`。使用 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 可确定占位符的预期内容类型。

在了解占位符类型后，形状接口仍然很重要：

- 空的文本、图片、图表或内容占位符通常由 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 表示。
- 已填充的图片占位符可以由 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 表示。
- 已填充的图表占位符可以由 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) 表示。
- 内容占位符可以包含多种内容。请同时检查 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 和运行时的形状接口，而不要假设每个占位符都是 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/) 描述了占位符的角色；它并不保证形状的运行时类型。访问文本、图片、图表、表格或媒体特定成员之前，请始终进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层次结构：

1. 母版幻灯片定义可重用的样式，并在某些情况下提供母版级别的占位符。
2. 布局幻灯片定义供一个或多个普通幻灯片使用的布局，并可继承自母版。
3. 普通幻灯片包含该幻灯片的占位符，并可继承自其布局。

调用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) 可在该层次结构中向上移动一级。幻灯片占位符通常返回其布局占位符；布局占位符可以返回其母版占位符。当形状没有基占位符时，该方法返回 `nullptr`。

下面的示例列出第一张幻灯片上的占位符并报告其基占位符：

```c++
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/type_info.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    auto typeName = shape->GetType().get_Name();
    Console::WriteLine(u"Slide placeholder: {0}; shape interface: {1}", placeholderType, typeName);

    auto layoutPlaceholder = shape->GetBasePlaceholder();
    if (layoutPlaceholder != nullptr)
    {
        auto layoutPlaceholderInfo = layoutPlaceholder->get_Placeholder();
        if (layoutPlaceholderInfo != nullptr)
        {
            auto layoutPlaceholderType = layoutPlaceholderInfo->get_Type();
            Console::WriteLine(u"  Layout placeholder: {0}", layoutPlaceholderType);
        }

        auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
        if (masterPlaceholder != nullptr)
        {
            auto masterPlaceholderInfo = masterPlaceholder->get_Placeholder();
            if (masterPlaceholderInfo != nullptr)
            {
                auto masterPlaceholderType = masterPlaceholderInfo->get_Type();
                Console::WriteLine(u"  Master placeholder: {0}", masterPlaceholderType);
            }
        }
    }
}
```

在普通幻灯片上编辑占位符会为该幻灯片创建或更改本地覆盖。编辑相关的布局或母版可以影响仍然继承该设置的所有幻灯片。普通的本地形状没有基占位符，且仅因为它占据相同坐标而不会开始继承。

## **移除占位符状态**

在调整模板时，使用 [IShape::RemovePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/removeplaceholder/) 可将现有对象保留为普通形状。其 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 方法返回 `nullptr`，但形状仍保留在幻灯片的集合中。相反，使用 [IShapeCollection::Remove](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/remove/) 会将形状从该集合中删除。

下面的示例需要一个至少包含一张幻灯片且第一张幻灯片上有非空文本占位符的 `template.pptx`。使用从其布局或母版继承格式的占位符，以查看移除该关系的效果。示例检查同一形状是否仍然存在，再次对现在的普通形状调用该方法，并保存结果。

{{% alert color="warning" title="Warning" %}}
移除占位符状态并不会自动保留继承的外观设置。下面的示例特意未更改这些设置，因此输出可能看起来不同。一个完全继承位置和大小的形状在调用后可能拥有零坐标和尺寸，因而即使仍在集合中也会变得不可见。
{{% /alert %}}

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto found = false;

for (auto index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto currentShape = slide->get_Shape(index);
    if (!ObjectExt::Is<IAutoShape>(currentShape))
    {
        continue;
    }

    auto shape = ExplicitCast<IAutoShape>(currentShape);
    auto textFrame = shape->get_TextFrame();
    if (shape->get_Placeholder() == nullptr || 
        textFrame == nullptr || 
        String::IsNullOrEmpty(textFrame->get_Text()))
    {
        continue;
    }

    auto shapeCount = slide->get_Shapes()->get_Count();
    shape->RemovePlaceholder();

    Console::WriteLine(u"Placeholder removed: {0}", shape->get_Placeholder() == nullptr);
    Console::WriteLine(u"Same shape retained: {0}", slide->get_Shape(index) == currentShape);
    Console::WriteLine(u"Shape count unchanged: {0}", slide->get_Shapes()->get_Count() == shapeCount);

    // 在普通形状上调用此方法不会产生任何效果。
    shape->RemovePlaceholder();
    found = true;
    break;
}

if (found)
{
    presentation->Save(u"placeholder-status-removed.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"No nonempty text placeholder was found on the first slide.");
}
```

对于匹配的占位符，所有三个检查都会打印 `True`。文本仍保留，但继承的位置、大小、旋转、字体、段落对齐、文本框边距、垂直锚点、填充和线条设置在移除占位符关系后可能会改变。例如，继承的标题格式可能会回退为普通文本格式。更多关于布局的信息请参见 [幻灯片布局](/slides/zh/cpp/slide-layout/)。

为了保留预期的外观，请在调用之前捕获解析后的位置、大小和旋转，并将所需的有效格式值复制到单独的变量中。通过 [IPortionFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iportionformat/geteffective/)、[IParagraphFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/geteffective/)、[ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/geteffective/)、[IFillFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/geteffective/)、以及 [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/) 检索这些值。不要仅依赖于有效格式对象，因为在关系被移除后，它们的文本格式值可能会改变。随后显式将捕获的值应用到普通形状，包括字体族、大小、样式、颜色、段落设置、文本框设置、填充和线条等。

继承的形状几何也可能需要通过 [IGeometryShape::set_ShapeType](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/set_shapetype/) 明确设置。对于矩形文本占位符，这意味着设置 [ShapeType::Rectangle](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/)。仅恢复填充和线条可能无法恢复可见的矩形。带有额外效果或更复杂格式的模板也需要相应处理这些设置。

## **更改占位符中的文本**

标题、居中标题、副标题、正文和文本占位符通常支持文本。使用前请先检查是否为 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)，再调用其 [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/get_textframe/) 方法。

下面的示例更新第一张幻灯片上的第一个标题占位符并保存结果：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IAutoShape> titleShape;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a title placeholder.");
}

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
presentation->Save(u"title-placeholder-updated.pptx", SaveFormat::Pptx);
```

此模式避免了将图片、图表、表格或媒体占位符强制转换为 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/)。它还通过用途而非脆弱的形状索引来识别占位符。

## **在布局上设置提示文本**

提示文本是设计时在空占位符中显示的指令，例如 *Click to add title*。请在布局占位符上设置自定义提示文本，而不是尝试通过普通幻灯片的形状集合访问它。通过 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/get_layoutslide/) 获取布局，并遍历 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_shapes/)。

下面的示例更改第一张幻灯片使用的布局上的标题和副标题提示：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto layoutSlide = presentation->get_Slide(0)->get_LayoutSlide();

for (auto&& shape : layoutSlide->get_Shapes())
{
    if (!ObjectExt::Is<IAutoShape>(shape))
    {
        continue;
    }

    auto autoShape = ExplicitCast<IAutoShape>(shape);
    auto placeholder = autoShape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    switch (placeholder->get_Type())
    {
        case PlaceholderType::Title:
        case PlaceholderType::CenteredTitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a concise slide title");
            break;
        case PlaceholderType::Subtitle:
            autoShape->get_TextFrame()->set_Text(u"Enter a subtitle or reporting period");
            break;
        default:
            break;
    }
}

presentation->Save(u"custom-placeholder-prompts.pptx", SaveFormat::Pptx);
```

提示文本不是普通幻灯片内容。它仅在 PowerPoint 等编辑应用的空占位符中显示。用户或程序提供真实内容后，提示将不再显示。更改提示也不会替换使用该布局的幻灯片上已有的文本。

## **更新图片占位符**

需要处理两种情况：

- 若图片占位符已被填充并由 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/) 表示，使用 [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/get_picture/) 和 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) 替换图片。
- 若仍是空占位符，使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addpictureframe/) 在占位符坐标处添加图片框，并删除空占位符。

下面的示例同时支持这两种情况并保存演示文稿：

```c++
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"picture-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> picturePlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a picture placeholder.");
}

auto imageBytes = File::ReadAllBytes(u"replacement.png");
auto image = presentation->get_Images()->AddImage(imageBytes);

if (ObjectExt::Is<IPictureFrame>(picturePlaceholder))
{
    auto pictureFrame = ExplicitCast<IPictureFrame>(picturePlaceholder);
    pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
}
else
{
    auto x = picturePlaceholder->get_X();
    auto y = picturePlaceholder->get_Y();
    auto width = picturePlaceholder->get_Width();
    auto height = picturePlaceholder->get_Height();
    auto shapes = slide->get_Shapes();
    shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
    shapes->Remove(picturePlaceholder);
}

presentation->Save(u"picture-placeholder-updated.pptx", SaveFormat::Pptx);
```

针对空占位符创建的替代品是本地图片框，而不是新占位符，因为 [IShape::get_Placeholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_placeholder/) 为只读。它保留了预留位置，但不再继承占位符特有的行为。如果保持占位符关系至关重要，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新生成的 [IPictureFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ipictureframe/)。

有关图像透明度、裁剪和其他图片特定效果，请参见 [管理图片框](/slides/zh/cpp/picture-frame/)。这些操作属于图片框或图片填充，而不是占位符元数据。

## **处理图表和内容占位符**

已填充的图表占位符可以由 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/) 表示。以下示例通过占位符类型和运行时接口同时查找此类图表，修改其标题并保存文件：

```c++
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IChart> placeholderChart;

for (auto&& shape : slide->get_Shapes())
{
    if (!ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = ExplicitCast<IChart>(shape);
    auto placeholder = chart->get_Placeholder();
    if (placeholder != nullptr && placeholder->get_Type() == PlaceholderType::Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a populated chart placeholder.");
}

placeholderChart->set_HasTitle(true);
placeholderChart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
presentation->Save(u"chart-placeholder-updated.pptx", SaveFormat::Pptx);
```

通用内容占位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充当多个内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际的形状接口以了解其包含的内容。特定布局也可以暴露 [PlaceholderType::Chart](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)、或 [PlaceholderType::Diagram](https://reference.aspose.com/slides/cpp/aspose.slides/placeholdertype/)。

Aspose.Slides 不会仅通过更改 [IPlaceholder::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/iplaceholder/get_type/)（该属性为只读）将空的 [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) 占位符转换为 [IChart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/)。若要以编程方式填充空的图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。下面的示例对图表执行此操作：

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"content-template.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IShape> targetPlaceholder;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();
    if (placeholderType == PlaceholderType::Chart || placeholderType == PlaceholderType::Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == nullptr)
{
    throw InvalidOperationException(u"The first slide does not contain a chart or content placeholder.");
}

auto x = targetPlaceholder->get_X();
auto y = targetPlaceholder->get_Y();
auto width = targetPlaceholder->get_Width();
auto height = targetPlaceholder->get_Height();
auto shapes = slide->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, y, width, height);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Quarterly Revenue");
shapes->Remove(targetPlaceholder);
presentation->Save(u"content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
```

添加的图表是普通本地图表。它占据占位符区域，但不继承布局占位符的属性。需要替换其类别、系列或工作簿数据时，请使用专门的 [图表管理文章](/slides/zh/cpp/powerpoint-charts/)。

## **完整示例：更新文本或图像内容**

下面的端到端示例打开一个模板，搜索第一张幻灯片上的标题或图片占位符，检查占位符和形状类型，更新相应内容并保存输出。示例特意避免假设形状索引或将每个占位符强制转换为同一接口。

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/ITextFrame.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/io/file.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"template.pptx");
auto slide = presentation->get_Slide(0);
auto updated = false;

for (auto&& shape : slide->get_Shapes())
{
    auto placeholder = shape->get_Placeholder();
    if (placeholder == nullptr)
    {
        continue;
    }

    auto placeholderType = placeholder->get_Type();

    if ((placeholderType == PlaceholderType::Title || placeholderType == PlaceholderType::CenteredTitle) && ObjectExt::Is<IAutoShape>(shape))
    {
        auto titleShape = ExplicitCast<IAutoShape>(shape);
        titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review");
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType::Picture)
    {
        auto imageBytes = File::ReadAllBytes(u"replacement.png");
        auto image = presentation->get_Images()->AddImage(imageBytes);

        if (ObjectExt::Is<IPictureFrame>(shape))
        {
            auto pictureFrame = ExplicitCast<IPictureFrame>(shape);
            pictureFrame->get_PictureFormat()->get_Picture()->set_Image(image);
        }
        else
        {
            auto x = shape->get_X();
            auto y = shape->get_Y();
            auto width = shape->get_Width();
            auto height = shape->get_Height();
            auto shapes = slide->get_Shapes();
            shapes->AddPictureFrame(ShapeType::Rectangle, x, y, width, height, image);
            shapes->Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw InvalidOperationException(u"No supported title or picture placeholder was found on the first slide.");
}

presentation->Save(u"placeholder-content-updated.pptx", SaveFormat::Pptx);
```

## **常见问题**

**什么是基占位符？**

基占位符是布局或母版上对应的形状，其他占位符由其继承。使用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getbaseplaceholder/) 可检索它。普通本地形状返回 `nullptr`，因为它不在占位符层次结构中。

**我可以通过编辑布局占位符来更改所有幻灯片的标题吗？**

可以通过布局更改继承的格式或提示文本，但现有的标题内容存储在普通幻灯片上。若要替换整个演示文稿中的实际标题文本，需要遍历幻灯片并更新每个标题占位符。

**如何管理日期、幻灯片编号、页眉和页脚占位符？**

请在相应的幻灯片、布局、母版、备注页或讲义范围使用页眉页脚管理器。完整示例请参见 [管理演示文稿页眉和页脚](/slides/zh/cpp/presentation-header-and-footer/)。