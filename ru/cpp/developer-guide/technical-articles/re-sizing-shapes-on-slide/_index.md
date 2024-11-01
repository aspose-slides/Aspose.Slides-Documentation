---
title: Изменение размеров фигур на слайде
type: docs
weight: 100
url: /ru/cpp/re-sizing-shapes-on-slide/
---

#### **Изменение размеров фигур на слайде**
Один из самых частых вопросов, задаваемых клиентами Aspose.Slides для C++, заключается в том, как изменить размеры фигур таким образом, чтобы при изменении размера слайда данные не обрезались. Этот краткий технический совет показывает, как этого добиться.

Чтобы избежать дезориентации фигур, каждую фигуру на слайде необходимо обновить в соответствии с новым размером слайда.

``` cpp
// Загрузка презентации
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\TestResize.ppt");

// Старый размер слайда
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Изменение размера слайда
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Новый размер слайда
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Изменение размера позиции
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Изменение размера фигуры, если требуется 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }
}

presentation->Save(u"Resize.pptx", Export::SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

Если на слайде есть таблица, то приведенный выше код не будет работать идеально. В этом случае необходимо изменить размер каждой ячейки таблицы.

{{% /alert %}} 

Вам нужно использовать следующий код на вашей стороне, если вам нужно изменить размеры слайдов с таблицами. Установка ширины или высоты таблицы является специальным случаем в фигурах, когда вам необходимо изменить высоту отдельных строк и ширину столбцов, чтобы изменить высоту и ширину таблицы.

``` cpp
SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"D:\\Test.pptx");

// Старый размер слайда
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Изменение размера слайда
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Новый размер слайда
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float ratioHeight = newHeight / currentHeight;
float ratioWidth = newWidth / currentWidth;

for (auto master : presentation->get_Masters())
{
    for (auto shape : master->get_Shapes())
    {
        // Изменение размера позиции
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Изменение размера фигуры, если требуется 
        shape->set_Y(shape->get_Y() * ratioHeight);
        shape->set_X(shape->get_X() * ratioWidth);
    }

    for (auto layoutslide : master->get_LayoutSlides())
    {
        for (auto shape : layoutslide->get_Shapes())
        {
            // Изменение размера позиции
            shape->set_Height(shape->get_Height() * ratioHeight);
            shape->set_Width(shape->get_Width() * ratioWidth);

            // Изменение размера фигуры, если требуется 
            shape->set_Y(shape->get_Y() * ratioHeight);
            shape->set_X(shape->get_X() * ratioWidth);
        }
    }
}

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        // Изменение размера позиции
        shape->set_Height(shape->get_Height() * ratioHeight);
        shape->set_Width(shape->get_Width() * ratioWidth);

        // Изменение размера фигуры, если требуется 
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