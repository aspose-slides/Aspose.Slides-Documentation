---
title: 管理 C++ 中的演示文稿占位符
linktitle: 管理占位符
type: docs
weight: 10
url: /zh/cpp/manage-placeholder/
keywords:
- 占位符
- 文本占位符
- 图片占位符
- 图表占位符
- 内容占位符
- 提示文本
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 检查和编辑文本、图片、图表和内容占位符，并理解占位符继承。"
---
## **概述**

占位符是一种形状，用于在演示文稿模板中预留特定类型内容的位置。常见示例包括标题、正文、图片、图表以及通用内容占位符。与普通形状不同，占位符可以从布局幻灯片或母版幻灯片继承其位置、大小、格式以及其他设置。

Aspose.Slides 通过 [IShape::get_Placeholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_placeholder/) 方法公开占位符信息。该方法返回一个 [IPlaceholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iplaceholder/) 对象，普通形状则返回 `nullptr`。使用 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iplaceholder/get_type/) 可确定占位符的预期内容类型。

在了解占位符类型后，形状接口仍然重要：

- 空的文本、图片、图表或内容占位符通常由 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 表示。
- 已填充的图片占位符可以由 [IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/) 表示。
- 已填充的图表占位符可以由 [IChart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/) 表示。
- 内容占位符可以包含多种类型的内容。请同时检查 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iplaceholder/get_type/) 和运行时形状接口，而不要假设每个占位符都是 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iplaceholder/get_type/) 描述了占位符的角色；它并不保证形状的运行时类型。在访问文本、图片、图表、表格或媒体特定成员之前，务必进行类型检查。
{{% /alert %}}

## **了解占位符继承**

占位符形成层次结构：

1. 母版幻灯片定义可重用的样式，在某些情况下还定义母版级别的占位符。
2. 布局幻灯片定义供一个或多个普通幻灯片使用的布局，并可以继承自母版。
3. 普通幻灯片包含该幻灯片的占位符，并可以继承自其布局。

调用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getbaseplaceholder/) 可在此层次结构中向上移动一级。幻灯片占位符通常返回其布局占位符；布局占位符可以返回其母版占位符。若形状没有基础占位符，方法返回 `nullptr`。

以下示例列出第一张幻灯片上的占位符并报告其基础占位符：

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

在普通幻灯片上编辑占位符会为该幻灯片创建或更改本地覆盖。编辑相关的布局或母版可能影响仍然继承该设置的所有幻灯片。本地普通形状没有基础占位符，仅因为占据相同坐标并不会开始继承。

## **在占位符中更改文本**

标题、居中标题、字幕、正文和文本占位符通常支持文本。在使用其 [get_TextFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/get_textframe/) 方法之前，请先检查是否为 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。

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

此模式避免将图片、图表、表格或媒体占位符强制转换为 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/)。它还通过占位符的用途来识别，而不是依赖脆弱的形状索引。

## **在布局上设置提示文本**

提示文本是设计时显示在空占位符中的指示，例如 *单击以添加标题*。应在布局占位符上设置自定义提示文本，而不是尝试通过普通幻灯片的形状集合获取它。通过 [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islide/get_layoutslide/) 访问布局，并遍历 [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ibaseslide/get_shapes/)。

以下示例修改第一张幻灯片所使用布局上的标题和字幕提示：

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

提示文本并非普通幻灯片内容。它仅用于 PowerPoint 等编辑应用中的空占位符。用户或程序提供真实内容后，提示将不再显示。更改提示文本也不会替换使用该布局的幻灯片上已有的文本。

## **更新图片占位符**

需要处理两种情况：

- 如果图片占位符已经填充并由 [IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/) 表示，则通过 [IPictureFillFormat::get_Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipicturefillformat/get_picture/) 和 [ISlidesPicture::set_Image](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidespicture/set_image/) 替换图像。
- 如果仍是空占位符，则使用 [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishapecollection/addpictureframe/) 在占位符坐标处添加图片框，并删除空占位符。

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

针对空占位符创建的替换是本地图片框，而不是新占位符，因为 [IShape::get_Placeholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/get_placeholder/) 为只读。它保留了预留位置，但不再继承占位符特有的行为。如果必须保留占位符关系，请先在 PowerPoint 中准备并填充占位符，然后使用 Aspose.Slides 更新得到的 [IPictureFrame](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipictureframe/)。

有关图像透明度、裁剪以及其他图片特效，请参阅 [管理图片框](/slides/zh/cpp/picture-frame/)。这些操作属于图片框或图片填充，而非占位符元数据。

## **使用图表和内容占位符**

已填充的图表占位符可以由 [IChart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/) 表示。下面的示例通过占位符类型和运行时接口同时定位此类图表，修改其标题并保存文件：

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

通用内容占位符通常具有 [PlaceholderType::Object](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/)。在 PowerPoint 中，它充当多个内容类型的启动器，包括图表、表格、图示、图片和媒体。填充后，请检查实际形状接口以了解其包含的内容。专用布局还可以公开 [PlaceholderType::Chart](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Table](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Picture](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/)、[PlaceholderType::Media](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/) 或 [PlaceholderType::Diagram](https://reference.aspose.com/slides/zh/cpp/aspose.slides/placeholdertype/)。

Aspose.Slides 不会仅通过更改 [IPlaceholder::get_Type](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iplaceholder/get_type/)（该属性为只读）就将空的 [IAutoShape](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iautoshape/) 占位符转换为 [IChart](https://reference.aspose.com/slides/zh/cpp/aspose.slides.charts/ichart/)。若要以编程方式填充空的图表或内容区域，请在占位符坐标处添加所需对象，然后删除空占位符。下面的示例演示了对图表的操作：

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

新增的图表是普通的本地图表。它占据占位符的区域，但不继承布局占位符的属性。当需要替换其类别、系列或工作簿数据时，请使用专门的 [图表管理文章](/slides/zh/cpp/powerpoint-charts/)。

## **完整示例：更新文本或图片内容**

以下端到端示例打开一个模板，搜索第一张幻灯片上的标题或图片占位符，检查占位符和形状类型，更新相应内容并保存输出。示例刻意避免假设形状索引或将每个占位符强制转换为相同接口。

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

**什么是基础占位符？**

基础占位符是布局或母版上对应的形状，其他占位符会从其继承。使用 [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ishape/getbaseplaceholder/) 可获取它。普通本地形状返回 `nullptr`，因为它不属于占位符层次结构。

**我可以通过编辑布局占位符来更改所有幻灯片标题吗？**

可以通过布局更改继承的格式或提示文本，但已有的标题内容存储在普通幻灯片上。若要在整个演示文稿中替换实际的标题文本，需要遍历幻灯片并更新每个标题占位符。

**如何管理日期、幻灯片编号、页眉和页脚占位符？**

请在相应的幻灯片、布局、母版、备注页或讲义范围使用页眉页脚管理器。参阅 [管理演示文稿页眉和页脚](/slides/zh/cpp/presentation-header-and-footer/) 获取完整示例。