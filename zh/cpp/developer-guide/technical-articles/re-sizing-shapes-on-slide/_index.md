---
title: 幻灯片上的形状调整大小
type: docs
weight: 100
url: /zh/cpp/re-sizing-shapes-on-slide/
---

#### **幻灯片上的形状调整大小**
Aspose.Slides for C++ 的客户最常问的问题之一是如何调整形状的大小，以便在更改幻灯片大小时数据不会被截断。这个简短的技术提示展示了如何实现这一点。

为了避免形状失去方向，每个幻灯片上的形状都需要根据新的幻灯片大小进行更新。

``` cpp
// 加载演示文稿
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// 旧的幻灯片大小
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 更改幻灯片大小
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// 新的幻灯片大小
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // 调整位置
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // 如有需要，调整形状大小 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

如果幻灯片中有任何表格，则上述代码将无法完美工作。在这种情况下，需要调整表格的每个单元格大小。

{{% /alert %}} 

如果您需要调整包含表格的幻灯片的大小，则需要使用以下代码。设置表格宽度或高度是形状中的一个特殊情况，您需要更改各行的高度和列的宽度以更改表格的高度和宽度。

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// 旧的幻灯片大小
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// 更改幻灯片大小
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// 新的幻灯片大小
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // 调整位置
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // 如有需要，调整形状大小 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            //调整位置
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            //调整形状大小，如有需要 
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // 调整位置
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // 如有需要，调整形状大小 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = System::ExplicitCast<ITable>(shape);
            for (auto row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * ratioHeight);
                //   row.Height = row.Height * ratioHeight;
            }
            for (auto col : table->get_Columns())
            {
                col->set_Width(col->get_Width() * ratioWidth);
            }
        }
    }
}

presentation->Save(u"D:\\Resize.pptx", Export::SaveFormat::Pptx);
```