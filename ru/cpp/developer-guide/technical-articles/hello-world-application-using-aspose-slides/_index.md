---
title: Приложение Hello World с использованием Aspose.Slides для C++
type: docs
weight: 80
url: /ru/cpp/hello-world-application-using-aspose-slides/
keywords:
- привет мир
- приложение
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Создайте первое C++ приложение с Aspose.Slides, простой пример Hello World, который подготовит вас к автоматизации презентаций PPT, PPTX и ODP."
---

## **Шаги по созданию приложения Hello World**
В этом простом приложении мы создадим презентацию PowerPoint, содержащую текст **Hello World** в указанной позиции слайда. Пожалуйста, выполните приведённые ниже шаги, чтобы создать приложение **Hello World**, используя Aspose.Slides for C++ API:

- Создать экземпляр класса Presentation
- Получить ссылку на первый слайд в презентации, который создаётся при инициализации Presentation
- Добавить AutoShape с ShapeType = Rectangle в указанную позицию слайда
- Добавить TextFrame к AutoShape, содержащий Hello World в качестве текста по умолчанию
- Изменить цвет текста на чёрный, так как по умолчанию он белый и не виден на слайде с белым фоном
- Изменить цвет линии формы на белый, чтобы скрыть границу формы
- Удалить формат заливки формы по умолчанию
- Наконец, записать презентацию в требуемый формат файла, используя объект Presentation

Реализация описанных выше шагов продемонстрирована ниже в примере.
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

    // добавить TextFrame к Rectangle
    shape->AddTextFrame(u"Hello World");

    // изменить цвет текста на черный (по умолчанию он белый)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // изменить цвет линии прямоугольника на белый
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // удалить любое форматирование заливки у формы
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // сохранить презентацию на диск
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
