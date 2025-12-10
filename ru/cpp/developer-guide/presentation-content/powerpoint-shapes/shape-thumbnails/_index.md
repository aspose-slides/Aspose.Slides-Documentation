---
title: Создание миниатюр фигур презентации в C++
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/cpp/shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендеринг фигуры
- визуализация фигуры
- PowerPoint
- презентация
- C++
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint с помощью Aspose.Slides для C++ – легко создавайте и экспортируйте миниатюры презентаций."
---

## **Создание миниатюры фигуры**
Aspose.Slides for C++ используется для создания файлов презентаций, где каждая страница представляет собой слайд. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам требуется просмотреть изображения фигур отдельно в просмотрщике изображений. В таком случае Aspose.Slides for C++ помогает создать миниатюры фигур слайдов. Как использовать эту функцию, описано в этой статье.
В статье объясняется, как генерировать миниатюры слайдов различными способами:

- Генерация миниатюры фигуры внутри слайда.
- Генерация миниатюры фигуры с пользовательскими размерами.
- Генерация миниатюры в границах внешнего вида фигуры.
- Генерация миниатюры дочернего узла SmartArt.

## **Генерация миниатюры фигуры со слайда**
Чтобы сгенерировать миниатюру фигуры с любого слайда с помощью Aspose.Slides for C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на любой слайд по его идентификатору или индексу.
3. Получите изображение миниатюры фигуры указанного слайда в масштабе по умолчанию.
4. Сохраните изображение миниатюры в нужном формате.

Пример ниже генерирует миниатюру фигуры.
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Генерация миниатюры с пользовательским коэффициентом масштабирования**
Чтобы сгенерировать миниатюру фигуры любого слайда с помощью Aspose.Slides for C++:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на любой слайд по его идентификатору или индексу.
3. Получите изображение миниатюры указанного слайда с границами фигуры.
4. Сохраните изображение миниатюры в нужном формате.

Пример ниже генерирует миниатюру с пользовательским коэффициентом масштабирования.
```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // Масштабирование вдоль осей X и Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **Создание миниатюры фигуры на основе границ внешнего вида**
Этот метод создания миниатюр фигур позволяет разработчикам генерировать миниатюру в границах внешнего вида фигуры. Он учитывает все эффекты фигуры. Сгенерированная миниатюра фигуры ограничена границами слайда. Чтобы сгенерировать миниатюру любой фигуры слайда в границах её внешнего вида, используйте следующий пример кода:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
2. Получите ссылку на любой слайд по его идентификатору или индексу.
3. Получите изображение миниатюры указанного слайда с границами фигуры как внешнего вида.
4. Сохраните изображение миниатюры в нужном формате.

Пример ниже создаёт миниатюру с пользовательским коэффициентом масштабирования.
```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // Масштабирование вдоль осей X и Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/), и другие. Фигуры также можно [экспортировать как векторный SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) сохраняя содержание фигуры в SVG.

**В чём разница между границами Shape и Appearance при рендеринге миниатюры?**

`Shape` использует геометрию фигуры; `Appearance` учитывает [визуальные эффекты](/slides/ru/cpp/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отображена в виде миниатюры?**

Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в показе, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)), можно сохранить как миниатюру или как SVG.

**Влияют ли системно установленные шрифты на качество миниатюр текстовых фигур?**

Да. Необходимо [предоставить требуемые шрифты](/slides/ru/cpp/custom-font/) (или [настроить подстановку шрифтов](/slides/ru/cpp/font-substitution/)), чтобы избежать нежелательных замен и переподгонки текста.