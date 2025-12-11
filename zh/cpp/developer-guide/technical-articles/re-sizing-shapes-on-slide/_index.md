---
title: 在演示文稿幻灯片上调整形状大小
type: docs
weight: 100
url: /zh/cpp/re-sizing-shapes-on-slide/
keywords:
- 调整形状
- 更改形状大小
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++，轻松在 PowerPoint 和 OpenDocument 幻灯片上调整形状大小——自动化幻灯片布局调整，提高工作效率。"
---

## **概述**

Aspose.Slides for C++ 客户最常见的问题之一是如何在幻灯片尺寸变化时调整形状大小，以免数据被截断。本文简要技术文章演示了实现方法。

## **调整形状大小**

为防止幻灯片尺寸变化时形状错位，需要更新每个形状的位置和尺寸，使其符合新的幻灯片布局。
```cpp
// 加载演示文稿文件。
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// 获取原始幻灯片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不缩放现有形状的情况下更改幻灯片尺寸。
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 获取新的幻灯片尺寸。
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
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


{{% alert color="primary" %}} 

如果幻灯片中包含表格，上述代码将无法正常工作。此时必须调整表格中每个单元格的大小。

{{% /alert %}} 

在包含表格的幻灯片上使用以下代码进行尺寸调整。对于表格，设置宽度或高度是特殊情况：必须分别调整行高和列宽，以改变表格的整体大小。
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 获取原始幻灯片尺寸。
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 在不缩放现有形状的情况下更改幻灯片尺寸。
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


## **常见问题解答**

**调整幻灯片大小后，为什么形状会变形或被截断？**

在调整幻灯片大小时，除非显式更改比例，否则形状会保持原始位置和尺寸。这可能导致内容被裁剪或形状错位。

**提供的代码适用于所有形状类型吗？**

基本示例适用于大多数形状类型（文本框、图像、图表等）。但对于表格，需要单独处理行和列，因为表格的高度和宽度由各单元格尺寸决定。

**调整幻灯片时如何调整表格大小？**

需要遍历表格的所有行和列，按比例调整它们的高度和宽度，如第二个代码示例所示。

**此调整方法适用于母版幻灯片和布局幻灯片吗？**

是的，但也应遍历[Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)和[Layout slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/)，对其形状应用相同的缩放逻辑，以确保整个演示文稿的一致性。

**我可以在调整大小的同时更改幻灯片方向（纵向/横向）吗？**

可以。可使用[presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/)更改方向。请相应设置缩放逻辑，以保持布局不变。

**幻灯片尺寸有最大限制吗？**

Aspose.Slides 支持自定义尺寸，但非常大的尺寸可能会影响性能或与某些 PowerPoint 版本的兼容性。

**如何防止固定宽高比的形状被拉伸变形？**

在缩放前检查形状的`get_AspectRatioLocked`方法。如果锁定，则按比例调整宽度或高度，而不是单独缩放两者。