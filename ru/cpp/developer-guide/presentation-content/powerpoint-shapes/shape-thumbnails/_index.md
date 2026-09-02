---
title: Создание миниатюр фигур презентации на C++
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/cpp/shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отрисовка фигуры
- рендеринг фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides для C++ – легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides используется для создания файлов презентаций, где каждая страница — это слайд. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам требуется просмотреть изображения фигур отдельно во внешнем просмотрщике изображений. В подобных случаях Aspose.Slides помогает генерировать миниатюрные изображения фигур слайдов. Как использовать эту функцию, описано в данной статье.

Эта статья объясняет, как генерировать миниатюры слайдов различными способами:

- Создание миниатюры фигуры внутри слайда.
- Создание миниатюры фигуры для фигуры слайда с пользовательскими размерами.
- Создание миниатюры фигуры в границах внешнего вида фигуры.

## **Создание миниатюры фигуры из слайда**

Чтобы создать миниатюру фигуры из любого слайда с помощью Aspose.Slides for C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры фигуры указанного слайда в масштабе по умолчанию.
1. Сохраните изображение миниатюры в любом требуемом формате изображения.

Ниже приведён пример, генерирующий миниатюру фигуры.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Создание миниатюры с пользовательским коэффициентом масштабирования**

Чтобы создать миниатюру фигуры любого слайда с помощью Aspose.Slides for C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры указанного слайда с границами фигуры.
1. Сохраните изображение миниатюры в любом требуемом формате изображения.

Ниже приведён пример, создающий миниатюру с пользовательским коэффициентом масштабирования.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Масштабирование по осям X и Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Создание миниатюры внешнего вида фигуры на основе границ**

Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничивается границами слайда. Чтобы создать миниатюру любой фигуры слайда в границах её внешнего вида, используйте следующий пример кода:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/cpp/aspose.slides/presentation/) .
1. Получите ссылку на любой слайд, используя его ID или индекс.
1. Получите изображение миниатюры указанного слайда с границами фигуры как внешним видом.
1. Сохраните изображение миниатюры в любом требуемом формате изображения.

Ниже приведён пример, создающий миниатюру на основе границ внешнего вида фигуры.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Масштабирование по осям X и Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Получение фактических визуальных границ фигуры**

Свойства рамки [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/) — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()` и `IShape::get_Height()` — описывают прямоугольник, хранящийся в модели презентации. Содержимое, фактически отрисованное, может выходить за пределы этой рамки или занимать иной прямоугольник, выровненный по осям. Повороты, контуры, наконечники стрел, разметка и переполнение текста, генерируемая геометрия SmartArt и другие эффекты отрисовки могут изменять занимаемую область.

Используйте [Shape::GetVisualBounds](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/getvisualbounds/) для вычисления этой занимаемой области без создания изображения. Метод возвращает объект [RectangleF](https://reference.aspose.com/slides/ru/cpp/system.drawing/rectanglef/) в координатах слайда. Возвращаемый прямоугольник не ограничен границами слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

[Shape::GetVisualBounds](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/getvisualbounds/) в настоящее время не объявлен в интерфейсе [IShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/). Поэтому сохраняйте фигуру, полученную из коллекции фигур слайда, как значение интерфейса и приводите тип только при вызове метода.

В следующем примере получаются и сравниваются рамка и визуальные границы:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Тот же объект [RectangleF](https://reference.aspose.com/slides/ru/cpp/system.drawing/rectanglef/) можно использовать для выравнивания соседних фигур по его границе `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` или `RectangleF::get_Bottom()`; зарезервировать достаточно места в сгенерированном макете; либо обнаружить содержимое за пределами разрешённого региона. Визуальные границы особенно полезны для SmartArt, текстовых полей, стрелок, изображений, повернутых фигур и групповых фигур, где сохранённая рамка может не представлять полного отрисованного результата.

Используйте [Shape::GetVisualBounds](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/getvisualbounds/), когда нужны координаты для макета или проверки и не требуется bitmap. Используйте [IShape::GetImage](https://reference.aspose.com/slides/ru/cpp/aspose.slides/ishape/getimage/), когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shapethumbnailbounds/) параметр `ShapeThumbnailBounds::Shape` задаёт размер изображения на основе границ фигуры, включая настройки контура, тогда как `ShapeThumbnailBounds::Appearance` задаёт размер из внешнего вида фигуры и ограничивает результат границами слайда. В отличие от этого, [Shape::GetVisualBounds](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/getvisualbounds/) возвращает только вычисленный прямоугольник и не обрезает его по границам слайда.

## **Часто задаваемые вопросы**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/cpp/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/writeassvg/), сохраняя содержимое фигуры в формате SVG.

**В чем разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/cpp/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отрисована как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет на отображение в слайд‑шоу, но не препятствует генерированию изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/cpp/aspose.slides.charts/chart/) и [SmartArt](https://reference.aspose.com/slides/ru/cpp/aspose.slides.smartart/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты, установленные в системе, на качество миниатюр текстовых фигур?**

Да. Вам следует [предоставить требуемые шрифты](/slides/ru/cpp/custom-font/) (или [настроить замену шрифтов](/slides/ru/cpp/font-substitution/)), чтобы избежать нежелательных подстановок и переплавки текста.