---
title: Изменение размера фигур на слайдах презентации в C++
type: docs
weight: 130
url: /ru/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /ru/cpp/re-sizing-shapes-on-slide/
keywords:
- изменение размера фигуры
- изменение размеров фигуры
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Легко изменяйте размер фигур на слайдах PowerPoint и OpenDocument с помощью Aspose.Slides для C++ — автоматизируйте корректировку макета слайдов и повышайте продуктивность."
---
## **Обзор**

Когда вы меняете размер слайда презентации, вам также может потребоваться изменить размер и позицию фигур, чтобы они соответствовали новым размерам. Эта статья показывает, как масштабировать фигуры вручную и как работать с таблицами на слайдах, шаблонах и макетах.

## **Изменение размера фигур**

Чтобы сохранить относительное положение и размер каждой фигуры, умножьте её горизонтальные координаты и ширину на отношение новой ширины слайда к оригинальной ширине. Примените соответствующее отношение высоты к её вертикальным координатам и высоте.

Первый пример загружает презентацию, в которой слайды не содержат таблиц, меняет размер слайда на A4 и сохраняет результат. Он использует [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) с [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) так, чтобы последующий цикл контролировал масштабирование. Коэффициенты безразмерны; позиции фигур и их размеры измеряются в пунктах. Разные коэффициенты ширины и высоты могут искажать фигуры, а изменение размеров фигуры не масштабирует её размеры шрифта.

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
Таблицы требуют отдельной обработки: масштабируйте их ширины колонок и высоты строк вместо задания общей ширины и высоты таблицы. Высота строк может оставаться больше запрошенной, если содержимое ячейки требует больше места.
{{% /alert %}}

Второй пример поддерживает таблицы и обрабатывает фигуры в шаблонах и макетах, а также отдельные слайды перед сохранением изменённой презентации. Его вспомогательный класс обрабатывает каждую [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) масштабируя [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) и [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Затем он масштабирует позицию таблицы без отдельного масштабирования её общих размеров.

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

// Вычислить независимые коэффициенты масштабирования по горизонтали и вертикали.
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
            // Размеры таблицы контролируются ширинами колонок и высотами строк.
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

// Изменить размер фигур, определённых в мастерах и макетах, а также в отдельных слайдах.
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

## **Часто задаваемые вопросы**

**Почему после изменения размера слайда фигуры искажаются или обрезаются?**

Если изменить размер слайда без масштабирования фигур, они сохраняют свои исходные позиции и размеры и могут выходить за пределы слайда. Масштабирование ширины и высоты разными коэффициентами также может искажать фигуры.

**Работает ли предоставленный код со всеми типами фигур?**

Первый пример изменяет границы фигур напрямую и предназначен для слайдов без таблиц. Второй пример обрабатывает таблицы отдельно. Проверьте полученную раскладку, особенно текст и таблицы, поскольку эти примеры не масштабируют размеры шрифтов, а содержимое таблиц может ограничивать высоту строк.

**Как изменить размер таблиц при изменении размера слайда?**

Масштабируйте ширины колонок по коэффициенту ширины и минимальные высоты строк по коэффициенту высоты, затем масштабируйте позицию таблицы, как показано во втором примере.

**Будет ли это масштабирование работать для шаблонных слайдов и макетов?**

Да. Во втором примере выполняется перебор через [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) и каждой [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) мастера, применяя ту же логику изменения размеров к их фигурам.

**Можно ли одновременно изменить ориентацию слайда (портрет/ландшафт) и его размер?**

Да. Установите [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) после изменения размера слайда и перед чтением целевых размеров, чтобы коэффициенты масштабирования учитывали окончательную ориентацию.

**Есть ли ограничение на размер слайда, который я могу задать?**

Вы можете указать пользовательские размеры слайда с помощью [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Поддерживаемые размеры также зависят от формата презентации и приложения, используемого для открытия файла.

**Как предотвратить искажение фигур с фиксированным соотношением сторон?**

Используйте один и тот же коэффициент масштабирования для ширины и высоты. Чтобы разместить оригинальную раскладку в новых размерах слайда, используйте меньший из коэффициентов ширины и высоты для обеих размеров и позиций. Это сохраняет пропорции, но может оставить свободное пространство вдоль одной из сторон.