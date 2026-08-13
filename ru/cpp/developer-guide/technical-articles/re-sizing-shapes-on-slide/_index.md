---
title: Изменение размеров фигур на слайдах презентации
type: docs
weight: 100
url: /ru/cpp/re-sizing-shapes-on-slide/
keywords:
- изменить размер фигуры
- изменить размер формы
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — автоматизируйте настройку макетов слайдов и повышайте продуктивность."
---
## **Обзор**

Один из наиболее часто задаваемых вопросов клиентам Aspose.Slides for C++ — как изменить размер фигур так, чтобы при изменении размера слайда данные не обрезались. Эта короткая техническая статья показывает, как это сделать.

## **Изменение размера фигур**

Чтобы фигуры не смещались при изменении размера слайда, обновите позицию и размеры каждой фигуры в соответствии с новым макетом слайда.

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

// Загрузите файл презентации.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Получите исходный размер слайда.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Измените размер слайда без масштабирования существующих фигур.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Получите новый размер слайда.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Измените размер и переместите фигуры на каждом слайде.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Масштабируйте размер фигуры.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Масштабируйте позицию фигуры.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="info" %}} 
Если на слайде есть таблица, приведённый выше код работать не будет. В этом случае каждую ячейку таблицы необходимо менять размер.
{{% /alert %}} 

Используйте следующий код, чтобы изменить размер слайдов, содержащих таблицы. Для таблиц установка ширины или высоты является особым случаем: необходимо корректировать высоты отдельных строк и ширины столбцов, чтобы изменить общий размер таблицы.

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

        // Масштабировать положение фигуры.
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

            // Масштабировать положение фигуры.
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

        // Масштабировать положение фигуры.
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

## **FAQ**

### Почему фигуры искажаются или обрезаются после изменения размера слайда?

При изменении размера слайда фигуры сохраняют своё исходное положение и размер, если масштаб явно не изменён. Это может привести к обрезке содержимого или смещению фигур.

### Работает ли предоставленный код для всех типов фигур?

Базовый пример работает для большинства типов фигур (текстовые поля, изображения, диаграммы и т.д.). Однако для таблиц необходимо обрабатывать строки и столбцы отдельно, поскольку высота и ширина таблицы определяются размерами отдельных ячеек.

### Как изменить размер таблиц при изменении размера слайда?

Необходимо пройтись по всем строкам и столбцам таблицы и изменить их высоту и ширину пропорционально, как показано во втором примере кода.

### Будет ли это изменение размера работать для шаблонов слайдов и макетных слайдов?

Да, но также следует пройтись по [Мастерам](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_masters/) и [Слайдам макета](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/get_layoutslides/) и применить ту же логику масштабирования к их фигурам, чтобы обеспечить согласованность всей презентации.

### Можно ли изменить ориентацию слайда (портрет/ландшафт) вместе с изменением размера?

Да. Вы можете использовать [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/islidesize/set_orientation/) для изменения ориентации. Убедитесь, что логика масштабирования настроена соответственно, чтобы сохранить макет.

### Есть ли ограничение на размер слайда, который я могу установить?

Aspose.Slides поддерживает пользовательские размеры, но очень большие размеры могут влиять на производительность или совместимость с некоторыми версиями PowerPoint.

### Как предотвратить искажение фигур с фиксированным соотношением сторон?

Перед масштабированием можно проверить метод `get_AspectRatioLocked` у фигуры. Если он заблокирован, изменяйте ширину или высоту пропорционально, а не масштабируйте их по отдельности.