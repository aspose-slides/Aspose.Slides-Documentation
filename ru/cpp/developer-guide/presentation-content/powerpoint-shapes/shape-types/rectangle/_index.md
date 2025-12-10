---
title: Добавление прямоугольников в презентации на C++
linktitle: Прямоугольник
type: docs
weight: 80
url: /ru/cpp/rectangle/
keywords:
- добавить прямоугольник
- создать прямоугольник
- форма прямоугольника
- простой прямоугольник
- форматированный прямоугольник
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Улучшите свои презентации PowerPoint, добавляя прямоугольники с помощью Aspose.Slides для C++ — легко проектировать и модифицировать фигуры программно."
---

## **Создать простой прямоугольник**
Как и в предыдущих темах, эта также посвящена добавлению формы, и на этот раз мы будем обсуждать прямоугольник. В этой теме мы описали, как разработчики могут добавлять простые или форматированные прямоугольники в свои слайды с помощью Aspose.Slides for C++. Чтобы добавить простой прямоугольник на выбранный слайд презентации, выполните следующие шаги:

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
1. Запишите изменённую презентацию в виде файла PPTX.

В приведённом ниже примере мы добавили простой прямоугольник на первый слайд презентации.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Создать форматированный прямоугольник**
Чтобы добавить форматированный прямоугольник на слайд, выполните следующие шаги:

1. Создайте экземпляр [Presentation class](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его Index.
1. Добавьте IAutoShape типа Rectangle, используя метод AddAutoShape, предоставляемый объектом IShapes.
1. Установите Fill Type прямоугольника в Solid.
1. Установите цвет прямоугольника, используя свойство SolidFillColor.Color, предоставляемое объектом FillFormat, связанным с объектом IShape.
1. Установите цвет линий прямоугольника.
1. Установите ширину линий прямоугольника.
1. Запишите изменённую презентацию в виде файла PPTX.
   Вышеуказанные шаги реализованы в примере, приведённом ниже.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Как добавить прямоугольник со скруглёнными углами?**

Используйте тип формы с закруглёнными углами [shape type](https://reference.aspose.com/slides/cpp/aspose.slides/shapetype/) и настройте радиус скругления в свойствах формы; скругление также можно применить к отдельным углам с помощью геометрических корректировок.

**Как заполнить прямоугольник изображением (текстурой)?**

Выберите тип заливки [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/), укажите источник изображения и настройте режимы [stretching/tiling modes](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/).

**Можно ли добавить к прямоугольнику тень и свечение?**

Да. Доступны [Outer/inner shadow, glow, and soft edges](/slides/ru/cpp/shape-effect/) с настраиваемыми параметрами.

**Можно ли превратить прямоугольник в кнопку с гиперссылкой?**

Да. [Assign a hyperlink](/slides/ru/cpp/manage-hyperlinks/) к событию щелчка по форме (переход к слайду, файлу, веб‑адресу или e‑mail).

**Как защитить прямоугольник от перемещения и изменений?**

[Use shape locks](/slides/ru/cpp/applying-protection-to-presentation/): вы можете запретить перемещение, изменение размера, выделение или редактирование текста, чтобы сохранить расположение.

**Можно ли преобразовать прямоугольник в растровое изображение или SVG?**

Да. Вы можете [render the shape](http://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) в изображение с указанным размером/масштабом или [export it as SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) для использования векторного формата.

**Как быстро получить фактические (effective) свойства прямоугольника с учётом темы и наследования?**

[Use the shape’s effective properties](/slides/ru/cpp/shape-effective-properties/): API возвращает вычисленные значения, учитывающие стили темы, макет и локальные настройки, упрощая анализ форматирования.