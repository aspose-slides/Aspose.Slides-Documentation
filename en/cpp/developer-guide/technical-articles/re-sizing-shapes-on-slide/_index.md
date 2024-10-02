---
title: Re-sizing Shapes on Slide
type: docs
weight: 100
url: /cpp/re-sizing-shapes-on-slide/
---

#### **Resizing Shapes on Slide**
One of the most frequent questions asked by the Aspose.Slides for C++ customers is how to resize shapes so that when Slide size is changed the data does not cut off. This short technical tip shows how to achieve that. 

To avoid shapes disorientation, each shape on the slide needs to be updated according to the new slide size.

``` cpp
// Load a presentation
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// Old slide size
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Changing slide size
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// New slide size
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Resize position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Resize shape size if required 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

If there is any table in the slide then above code would not work perfect. In that case, every cell of the table needs to be resized.

{{% /alert %}} 

You need to use following code on your end if you need to re-size the slides with tables. Setting table width or height is a special case in shapes where you need to alter the individual row height and column width to alter the table height and width.

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// Old slide size
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Changing slide size
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// New slide size
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // Resize position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Resize shape size if required 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            //Resize position
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            //Resize shape size if required 
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Resize position
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Resize shape size if required 
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
