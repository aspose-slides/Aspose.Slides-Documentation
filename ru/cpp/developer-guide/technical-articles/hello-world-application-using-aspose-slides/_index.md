---
title: Приложение Hello World с использованием Aspose.Slides
type: docs
weight: 80
url: /ru/cpp/hello-world-application-using-aspose-slides/
---

## **Шаги для создания приложения Hello World**
В этом простом приложении мы создадим презентацию PowerPoint с текстом **Hello World** в указанной позиции слайда. Пожалуйста, следуйте приведенным ниже шагам, чтобы создать приложение **Hello World** с использованием API Aspose.Slides для C++:

- Создайте экземпляр класса Presentation
- Получите ссылку на первый слайд в презентации, который создается при инициализации Presentation.
- Добавьте AutoShape с типом ShapeType в форме прямоугольника в указанной позиции слайда.
- Добавьте TextFrame к AutoShape, содержащий текст Hello World по умолчанию.
- Измените цвет текста на черный, так как по умолчанию он белый и не виден на слайде с белым фоном.
- Измените цвет линии фигуры на белый, чтобы скрыть границу фигуры.
- Удалите формат заливки по умолчанию у фигуры.
- Наконец, запишите презентацию в желаемый формат файла, используя объект Presentation.

Реализация вышеуказанных шагов показана ниже в примере.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // получить первый слайд
    auto slide = pres->get_Slides()->idx_get(0);

    // добавить AutoShape типа Rectangle
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // добавить TextFrame к прямоугольнику
    shape->AddTextFrame(u"Hello World");

    // изменить цвет текста на черный (который по умолчанию белый)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // изменить цвет линии прямоугольника на белый
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // удалить любое форматирование заливки в фигуре
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // сохранить презентацию на диск
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```