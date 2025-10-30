---
title: Создание миниатюр фигур презентации в Python
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- рендеринг фигуры
- отображение фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте высококачественные миниатюры фигур из слайдов PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET – легко создавайте и экспортируйте миниатюры презентаций."
---

## **Введение**

Aspose.Slides for Python via .NET используется для создания файлов презентаций, где каждая страница представляет собой слайд. Вы можете просматривать эти слайды в Microsoft PowerPoint, открывая файл презентации. Однако разработчикам иногда необходимо просматривать изображения фигур отдельно в просмотрщике изображений. В таких случаях Aspose.Slides может генерировать миниатюрные изображения фигур слайдов. В этой статье объясняется, как использовать эту функцию.

## **Создание миниатюр фигур со слайдов**

Когда вам нужен предварительный просмотр конкретного объекта, а не всего слайда, можно отобразить миниатюру отдельной фигуры. Aspose.Slides позволяет экспортировать любую фигуру в изображение, что упрощает создание легковесных превью, иконок или ресурсов для дальнейшей обработки.

Чтобы создать миниатюру из любой фигуры:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его ID или индексу.
1. Получите ссылку на фигуру на этом слайде.
1. Отобразите миниатюру изображения фигуры.
1. Сохраните изображение миниатюры в нужном формате.

Ниже приведён пример, генерирующий миниатюру фигуры.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с масштабом по умолчанию.
    with shape.get_image() as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр с пользовательским коэффициентом масштабирования**

В этом разделе показано, как генерировать миниатюры фигур с пользовательским коэффициентом масштабирования в Aspose.Slides. Управляя масштабом, вы можете точно настроить размер миниатюры для превью, экспорта или дисплеев с высоким DPI.

Чтобы создать миниатюру любой фигуры на слайде:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его ID или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отобразите изображение миниатюры фигуры с указанным масштабом.
1. Сохраните изображение миниатюры в нужном формате.

Ниже пример, создающий миниатюру с пользовательским коэффициентом масштабирования.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Создайте экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с указанным масштабом.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр с использованием границ отображения фигуры**

В этом разделе показано, как создать миниатюру внутри границ отображения фигуры. При этом учитываются все эффекты фигуры. Сгенерированная миниатюра ограничивается границами слайда.

Чтобы создать миниатюру любой фигуры слайда в границах её отображения:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите слайд по его ID или индексу.
1. Получите целевую фигуру на этом слайде.
1. Отобразите изображение миниатюры фигуры с указанными границами.
1. Сохраните изображение миниатюры в нужном формате изображения.

Ниже пример, создающий миниатюру с пользовательскими границами.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Создайте экземпляр класса Presentation для открытия файла презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Создайте изображение фигуры с границами отображения.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) путем сохранения содержимого фигуры в формате SVG.

**В чём разница между границами SHAPE и APPEARANCE при рендеринге миниатюры?**

`SHAPE` использует геометрию фигуры; `APPEARANCE` учитывает [визуальные эффекты](/slides/ru/python-net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно отображена как миниатюра?**

Скрытая фигура остаётся частью модели и может быть отрендерена; флаг скрытия влияет только на отображение в слайд-шоу, но не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**

Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты на качество миниатюр текстовых фигур?**

Да. Вам следует [предоставить необходимые шрифты](/slides/ru/python-net/custom-font/) (или [настроить подстановку шрифтов](/slides/ru/python-net/font-substitution/)), чтобы избежать нежелательных замен и переполнения текста.