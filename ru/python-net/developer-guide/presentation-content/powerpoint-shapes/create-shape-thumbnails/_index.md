---
title: Создание миниатюр фигур презентации в Python
linktitle: Миниатюры фигур
type: docs
weight: 70
url: /ru/python-net/create-shape-thumbnails/
keywords:
- миниатюра фигуры
- изображение фигуры
- отображение фигуры
- отрисовка фигуры
- визуальные границы
- границы фигуры
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Создавайте миниатюры фигур высокого качества из слайдов PowerPoint и OpenDocument с помощью Aspose.Slides for Python via .NET – легко создавайте и экспортируйте миниатюры презентаций."
---
## **Введение**

Aspose.Slides for Python via .NET используется для создания файлов презентаций, где каждая страница представляет собой слайд. Вы можете просматривать эти слайды в Microsoft PowerPoint, открыв файл презентации. Однако разработчикам иногда требуется просматривать изображения фигур отдельно в просмоторщике изображений. В таких случаях Aspose.Slides может генерировать миниатюрные изображения фигур слайдов. В этой статье объясняется, как использовать эту функцию.

## **Создание миниатюр фигур из слайдов**

Когда вам нужен предварительный просмотр конкретного объекта, а не всего слайда, вы можете отобразить миниатюру отдельной фигуры. Aspose.Slides позволяет экспортировать любую фигуру в изображение, что упрощает создание лёгких превью, иконок или ресурсов для дальнейшей обработки.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд по его идентификатору (ID) или индексу.
1. Получите ссылку на фигурку на этом слайде.
1. Отрендерите миниатюру изображения фигурки.
1. Сохраните изображение миниатюры в нужном формате.

Ниже приведён пример, генерирующий миниатюру фигурки.

```py
import aspose.slides as slides

# Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с масштабом по умолчанию.
    with shape.get_image() as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр с пользовательским коэффициентом масштабирования**

В этом разделе показано, как генерировать миниатюры фигур с задаваемым пользователем коэффициентом масштабирования в Aspose.Slides. Управляя масштабом, вы можете точно настроить размер миниатюры для превью, экспорта или дисплеев с высоким DPI.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите слайд по его идентификатору (ID) или индексу.
1. Получите целевую фигурку на этом слайде.
1. Отрендерите изображение миниатюры фигурки с указанным масштабом.
1. Сохраните изображение миниатюры в нужном формате.

Ниже приведён пример, генерирующий миниатюру с пользовательским коэффициентом масштабирования.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Создайте изображение с указанным масштабом.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Создание миниатюр, используя границы отображения фигуры**

В этом разделе показано, как генерировать миниатюру внутри границ отображения фигуры. При учёте принимаются все эффекты фигуры. Сгенерированная миниатюра ограничивается границами слайда.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-net/aspose.slides/presentation/).
1. Получите слайд по его идентификатору (ID) или индексу.
1. Получите целевую фигурку на этом слайде.
1. Отрендерите изображение миниатюры фигурки с указанными границами.
1. Сохраните изображение миниатюры в нужном формате изображения.

Ниже приведён пример, создающий миниатюру с пользовательскими границами.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Создайте экземпляр класса Presentation, чтобы открыть файл презентации.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Создайте изображение фигуры с границами отображения.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Сохраните изображение на диск в формате PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Получение фактических визуальных границ фигуры**

Свойства рамки [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) — `Shape.x`, `Shape.y`, `Shape.width` и `Shape.height` — описывают прямоугольник, хранящийся в модели презентации. Содержимое, которое действительно отрисовывается, может выходить за пределы этой рамки или занимать другой прямоугольник, выровненный по осям. Повороты, контуры, концы стрел, размещение и переполнение текста, генерируемая геометрия SmartArt и другие эффекты рендеринга могут изменять занимаемую область.

Используйте [Shape.get_visual_bounds](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_visual_bounds/) для расчёта этой области без создания изображения. Метод возвращает прямоугольник с плавающей точкой в координатах слайда. Возвращённый прямоугольник не обрезается по границе слайда, поэтому его координаты могут быть отрицательными, если содержимое выходит за начало слайда.

В следующем примере получаются и сравниваются границы рамки и визуальные границы:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Тот же прямоугольник можно использовать для выравнивания соседних фигур по его левому, правому, верхнему или нижнему краю; для резервирования достаточного места в генерируемом макете; или для обнаружения содержимого за пределами разрешенной области. Визуальные границы особенно полезны для SmartArt, текстовых блоков, стрелок, изображений, повернутых фигур и групповых фигур, где сохранённая рамка может не отражать полностью отрисованный результат.

Используйте [Shape.get_visual_bounds](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_visual_bounds/), когда нужны координаты для макетирования или валидации и не требуется bitmap. Используйте [Shape.get_image](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/get_image/), когда необходимо отрисовать фигуру. С помощью [ShapeThumbnailBounds](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.SHAPE` задаёт размер изображения по границам фигуры, включая настройки контура, тогда как `ShapeThumbnailBounds.APPEARANCE` задаёт размер по отображению фигуры и ограничивает результат границами слайда. В отличие от этого, `Shape.get_visual_bounds` возвращает только рассчитанный прямоугольник и не обрезает его по границе слайда.

## **FAQ**

**Какие форматы изображений можно использовать при сохранении миниатюр фигур?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ru/python-net/aspose.slides/imageformat/), и другие. Фигуры также могут быть [экспортированы как векторный SVG](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/write_as_svg/) путём сохранения содержимого фигуры в формате SVG.

**В чём разница между границами SHAPE и APPEARANCE при рендеринге миниатюры?**  
`SHAPE` использует геометрию фигуры; `APPEARANCE` учитывает [визуальные эффекты](/slides/ru/python-net/shape-effect/) (тени, свечения и т.д.).

**Что происходит, если фигура помечена как скрытая? Будет ли она всё равно рендериться как миниатюра?**  
Скрытая фигура остаётся частью модели и может быть отрисована; флаг скрытия влияет только на отображение в слайд-шоу и не препятствует генерации изображения фигуры.

**Поддерживаются ли групповые фигуры, диаграммы, SmartArt и другие сложные объекты?**  
Да. Любой объект, представленный как [Shape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/shape/) (включая [GroupShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/ru/python-net/aspose.slides.charts/chart/), и [SmartArt](https://reference.aspose.com/slides/ru/python-net/aspose.slides.smartart/smartart/)), может быть сохранён как миниатюра или как SVG.

**Влияют ли системные шрифты, установленные на компьютере, на качество миниатюр текстовых фигур?**  
Да. Необходимо [предоставить требуемые шрифты](/slides/ru/python-net/custom-font/) (или [настроить замену шрифтов](/slides/ru/python-net/font-substitution/)), чтобы избежать нежелательных замен и перераспределения текста.