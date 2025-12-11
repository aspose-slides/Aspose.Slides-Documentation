---
title: Изменение размеров фигур на слайдах презентации
type: docs
weight: 100
url: /ru/cpp/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко изменяйте размеры фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides for C++ — автоматизируйте настройки макета слайдов и повышайте продуктивность."
---

## **Обзор**

Один из самых частых вопросов клиентов Aspose.Slides for C++ — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья показывает, как это сделать.

## **Изменить размер фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры, чтобы они соответствовали новому макету слайда.
```cpp
// Загрузить файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Get the original slide size.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Изменить размер слайда без масштабирования существующих фигур.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Get the new slide size.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Масштабировать размер фигуры.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Масштабировать позицию фигуры.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}} 
Если слайд содержит таблицу, приведённый выше код работать не будет. В этом случае каждую ячейку таблицы необходимо изменить в размере.
{{% /alert %}} 

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц установка ширины или высоты является особым случаем: необходимо изменить высоту отдельных строк и ширину отдельных столбцов, чтобы изменить общий размер таблицы.
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Получить исходный размер слайда.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Изменить размер слайда без масштабирования существующих фигур.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Получить новый размер слайда.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Масштабировать размер фигуры.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Масштабировать позицию фигуры.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Масштабировать размер фигуры.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Масштабировать позицию фигуры.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Масштабировать размер фигуры.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Масштабировать позицию фигуры.
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


## **Вопросы и ответы**

**Почему фигуры искажаются или обрезаются после изменения размера слайда?**  
При изменении размера слайда фигуры сохраняют исходную позицию и размер, если масштаб явно не изменить. Это может привести к обрезке содержимого или смещению фигур.

**Работает ли предоставленный код для всех типов фигур?**  
Базовый пример работает для большинства типов фигур (текстовые поля, изображения, диаграммы и т.д.). Однако для таблиц необходимо обрабатывать строки и столбцы отдельно, так как высота и ширина таблицы определяются размерами отдельных ячеек.

**Как изменить размер таблиц при изменении размера слайда?**  
Необходимо пройтись по всем строкам и столбцам таблицы и изменить их высоту и ширину пропорционально, как показано во втором примере кода.

**Будет ли такое изменение размера работать для мастер‑слайдов и слайдов макета?**  
Да, но также следует пройтись по [Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) и [Layout slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность по всей презентации.

**Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?**  
Да. Можно использовать [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/islidesize/set_orientation/) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответствующим образом, чтобы сохранить макет.

**Есть ли ограничение на размер слайда, который я могу задать?**  
Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**  
Можно проверить метод `get_AspectRatioLocked` у фигуры перед масштабированием. Если он заблокирован, изменяйте ширину или высоту пропорционально, а не масштабируйте их отдельно.