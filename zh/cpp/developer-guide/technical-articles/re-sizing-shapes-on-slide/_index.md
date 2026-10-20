---
title: 在 C++ 中调整演示文稿幻灯片上的形状大小
type: docs
weight: 130
url: /zh/cpp/resizing-shapes-on-slide/
aliases:
  - /zh/cpp/re-sizing-shapes-on-slide/
  /cpp/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "轻松在 PowerPoint 和 OpenDocument 幻灯片上使用 Aspose.Slides for C++ 调整形状大小——自动化幻灯片布局调整并提升生产力。"
---
## **概述**

当您更改演示文稿的幻灯片大小时，可能还需要调整形状的大小并重新定位，以适应新的尺寸。本文展示了如何手动缩放形状以及如何处理幻灯片、母版和布局上的表格。

## **调整形状大小**

为了保持每个形状的相对位置和大小，需将其水平坐标和宽度乘以新幻灯片宽度与原始宽度的比例。将对应的高度比例应用于其垂直坐标和高度。

第一个示例加载一个幻灯片中不包含表格的演示文稿，将幻灯片大小更改为 A4，并保存结果。它使用[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/)并搭配[SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/)以便后续循环自行控制缩放。比例是无单位的；形状位置和尺寸以点为单位。不同的宽高比例会导致形状变形，且更改形状尺寸不会缩放其字体大小。

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
表格需要单独处理：通过缩放列宽和行高，而不是直接设置表格的整体宽度和高度。如果单元格内容需要更多空间，行高可能会保持大于请求的值。
{{% /alert %}}

第二个示例支持表格，并在保存调整大小后的演示文稿之前，对母版和布局以及单个幻灯片上的形状进行处理。它的辅助方法通过缩放[IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/)和[IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/)来处理每个[ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)。随后在不单独缩放整体尺寸的情况下，缩放表格的位置。

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 计算独立的水平和垂直缩放因子。
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // 表格尺寸由列宽和行高控制。
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// 调整母版、布局以及单独幻灯片上定义的形状大小。
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题解答**

**调整幻灯片大小后形状为何会变形或被截断？**

如果在更改幻灯片尺寸时未对形状进行缩放，它们会保持原始位置和尺寸，可能会超出幻灯片范围。使用不同的宽高比例进行缩放也会导致形状变形。

**提供的代码适用于所有形状类型吗？**

第一个示例直接更改形状边界，适用于没有表格的幻灯片。第二个示例单独处理表格。请检查生成的布局，特别是文本和表格，因为这些示例不会缩放字体大小，表格内容可能限制行高。

**在调整幻灯片大小时如何调整表格？**

如第二个示例所示，按宽度比例缩放列宽，按高度比例缩放最小行高，然后缩放表格的位置。

**此调整大小方式适用于母版幻灯片和布局幻灯片吗？**

是的。第二个示例遍历[Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)以及每个母版的[IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/)，并对其形状应用相同的调整逻辑。

**我可以在调整大小的同时更改幻灯片的方向（纵向/横向）吗？**

可以。在更改幻灯片大小后、读取目标尺寸前，设置[SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/)，以便比例因子反映最终方向。

**幻灯片大小是否有上限？**

您可以使用[SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/)指定自定义幻灯片尺寸。支持的尺寸还取决于演示文稿格式以及打开文件的应用程序。

**如何防止具有固定宽高比的形状被扭曲？**

对宽度和高度使用相同的比例因子。若要在新幻灯片尺寸内保持原始布局，请使用宽高比例中较小的那个作为两个维度和位置的比例因子。这会保持比例，但可能在某一边留下未使用的空间。