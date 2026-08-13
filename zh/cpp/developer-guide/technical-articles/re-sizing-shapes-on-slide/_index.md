---
title: 幻灯片上调整形状大小
type: docs
weight: 100
url: /zh/cpp/re-sizing-shapes-on-slide/
keywords:
- 调整形状大小
- 更改形状尺寸
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 轻松调整 PowerPoint 和 OpenDocument 幻灯片上的形状大小——自动化幻灯片布局调整，提高工作效率。"
---
## **概述**

Aspose.Slides for C++ 客户最常问的问题之一是如何在幻灯片尺寸变化时调整形状大小，以免数据被截断。本文简要技术说明了如何实现。

## **调整形状大小**

为防止幻灯片尺寸变化时形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。

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

// 加载演示文稿文件。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 获取原始幻灯片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 更改幻灯片尺寸且不缩放现有形状。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 获取新的幻灯片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// 在每张幻灯片上调整大小并重新定位形状。
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 缩放形状大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 缩放形状位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
如果幻灯片中包含表格，上面的代码将无法正常工作。在这种情况下，需要对表格中的每个单元格进行大小调整。
{{% /alert %}} 

在包含表格的幻灯片上使用以下代码进行调整。对于表格，设置宽度或高度是特殊情况：必须分别调整行高和列宽，以改变表格的整体尺寸。

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
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 获取原始幻灯片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 更改幻灯片尺寸且不缩放现有形状。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// 获取新的幻灯片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // 缩放形状大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 缩放形状位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // 缩放形状大小。
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // 缩放形状位置。
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // 缩放形状大小。
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // 缩放形状位置。
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常见问题**

### 为什么在调整幻灯片大小后形状会变形或被截断？

在调整幻灯片大小时，形状会保留原始位置和尺寸，除非显式更改比例。这可能导致内容被裁剪或形状错位。

### 提供的代码适用于所有形状类型吗？

基本示例适用于大多数形状类型（文本框、图像、图表等）。但对于表格，需要单独处理行和列，因为表格的宽高由各单元格的尺寸决定。

### 调整幻灯片大小时怎样调整表格？

需要遍历表格的所有行和列，并按比例调整它们的高度和宽度，如第二段代码示例所示。

### 此调整方法适用于母版幻灯片和布局幻灯片吗？

是的，但还应遍历[Masters](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_masters/)和[Layout slides](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/get_layoutslides/)并对其形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

### 我可以在调整大小的同时更改幻灯片方向（纵向/横向）吗？

可以。可以使用[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/islidesize/set_orientation/)更改方向。请相应地设置缩放逻辑，以保持布局。

### 幻灯片尺寸设置是否有上限？

Aspose.Slides 支持自定义尺寸，但过大的尺寸可能会影响性能或与某些 PowerPoint 版本的兼容性。

### 如何防止锁定宽高比的形状被拉伸变形？

在缩放之前可以检查形状的`get_AspectRatioLocked`方法。如果已锁定，应按比例调整宽度或高度，而不是单独缩放。