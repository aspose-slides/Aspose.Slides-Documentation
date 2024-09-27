---
title: Манипуляции с формами
type: docs
weight: 40
url: /ru/python-net/shape-manipulations/
keywords: "Форма PowerPoint, форма на слайде, найти форму, клонировать форму, удалить форму, скрыть форму, изменить порядок формы, получить ID встроенной формы, альтернативный текст формы, форматы макета формы, форма как SVG, выравнять форму, презентация PowerPoint, Python, Aspose.Slides для Python через .NET"
description: "Манипулируйте формами PowerPoint в Python"
---

## **Найти форму на слайде**
Эта тема описывает простую технику, позволяющую разработчикам легче находить конкретную форму на слайде без использования ее внутреннего ID. Важно знать, что файлы презентаций PowerPoint не имеют способа идентификации форм на слайде, кроме как внутренним уникальным ID. Похоже, что для разработчиков сложно найти форму, используя ее внутренний уникальный ID. Все формы, добавленные на слайды, имеют некоторый альтернативный текст. Мы рекомендуем разработчикам использовать альтернативный текст для поиска конкретной формы. Вы можете использовать MS PowerPoint для определения альтернативного текста для объектов, которые вы планируете изменить в будущем.

После установки альтернативного текста для любой желаемой формы вы можете открыть эту презентацию, используя Aspose.Slides для Python через .NET, и пройтись по всем формам, добавленным на слайд. Во время каждой итерации вы можете проверить альтернативный текст формы, и форма с совпадающим альтернативным текстом будет той формой, которая вам нужна. Чтобы продемонстрировать эту технику более наглядно, мы создали метод, [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), который выполняет поиск конкретной формы на слайде и затем просто возвращает эту форму.

```py
import aspose.slides as slides

# Реализация метода для поиска формы на слайде с использованием ее альтернативного текста
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# Создание класса Presentation, представляющего файл презентации
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # Альтернативный текст формы, которую нужно найти
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("Имя формы: " + shape.name)
```



## **Клонировать форму**
Чтобы клонировать форму на слайд с использованием Aspose.Slides для Python через .NET:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Получите ссылку на слайд, используя его индекс.
1. Получите коллекцию форм с исходного слайда.
1. Добавьте новый слайд в презентацию.
1. Клонируйте формы из коллекции форм исходного слайда на новый слайд.
1. Сохраните измененную презентацию в виде файла PPTX.

Пример ниже добавляет группу форм на слайд.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# Запись файла PPTX на диск
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Удалить форму**
Aspose.Slides для Python через .NET позволяет разработчикам удалять любые формы. Для удаления формы из любого слайда, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Найдите форму с конкретным альтернативным текстом.
1. Удалите форму.
1. Сохраните файл на диск.

```py
import aspose.slides as slides

# Создание объекта Presentation
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру прямоугольной формы
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Пользовательский"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # Сохранение презентации на диск
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Скрыть форму**
Aspose.Slides для Python через .NET позволяет разработчикам скрывать любые формы. Чтобы скрыть форму из любого слайда, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Найдите форму с конкретным альтернативным текстом.
1. Скрыть форму.
1. Сохраните файл на диск.

```py
import aspose.slides as slides

# Создание экземпляра класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру прямоугольной формы
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Пользовательский"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # Сохранение презентации на диск
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Изменить порядок форм**
Aspose.Slides для Python через .NET позволяет разработчикам изменять порядок форм. Изменение порядка форм определяет, какая форма находится спереди, а какая - сзади. Чтобы изменить порядок формы на любом слайде, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Добавьте форму.
1. Добавьте некоторый текст в текстовое поле формы.
1. Добавьте еще одну форму с теми же координатами.
1. Измените порядок форм.
1. Сохраните файл на диск.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="Текст водяного знака Текст водяного знака Текст водяного знака"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Получить ID встроенной формы**
Aspose.Slides для Python через .NET позволяет разработчикам получить уникальный идентификатор формы в области слайда в отличие от свойства UniqueId, которое позволяет получить уникальный идентификатор в области презентации. Свойство OfficeInteropShapeId было добавлено к интерфейсам IShape и классу Shape соответственно. Значение, возвращаемое свойством OfficeInteropShapeId, соответствует значению ID объекта Microsoft.Office.Interop.PowerPoint.Shape. Ниже приведен пример кода.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # Получение уникального идентификатора формы в области слайда
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **Установить альтернативный текст для формы**
Aspose.Slides для Python через .NET позволяет разработчикам устанавливать альтернативный текст для любой формы.
Формы в презентации могут быть различены по свойству AlternativeText или Shape Name.
Свойство AlternativeText может быть прочитано или установлено как с использованием Aspose.Slides, так и Microsoft PowerPoint.
Используя это свойство, вы можете пометить форму и выполнять различные операции, такие как удаление формы,
скрытие формы или изменение порядка форм на слайде.
Чтобы установить альтернативный текст для формы, выполните следующие шаги:

1. Создайте экземпляр класса `Presentation`.
1. Получите первый слайд.
1. Добавьте любую форму на слайд.
1. Выполните некоторые действия с новодобавленной формой.
1. Переберите формы, чтобы найти нужную форму.
1. Установите альтернативный текст.
1. Сохраните файл на диск.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Создание экземпляра класса Presentation, который представляет PPTX
with slides.Presentation() as pres:
    # Получить первый слайд
    sld = pres.slides[0]

    # Добавить автофигуру прямоугольной формы
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "Пользовательский"

    # Сохранение презентации на диск
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Доступ к форматам макета для формы**
Aspose.Slides для Python через .NET предоставляет простой API для доступа к форматам макета для формы. Эта статья демонстрирует, как вы можете получить доступ к форматам макета.

Ниже приведен пример кода.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **Отрисовать форму как SVG**
Теперь Aspose.Slides для Python через .NET поддерживает отрисовку формы как SVG. Метод WriteAsSvg (и его перегрузки) были добавлены в класс Shape и интерфейс IShape. Этот метод позволяет сохранять содержимое формы в виде SVG-файла. Ниже представлен фрагмент кода, который показывает, как экспортировать форму слайда в SVG-файл.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## Выравнить форму

С помощью перегруженного метода [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) вы можете

* выровнять формы относительно границ слайда. См. пример 1.
* выровнять формы относительно друг друга. См. пример 2.

Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) определяет доступные варианты выравнивания.

### Пример 1

Этот код на Python показывает, как выровнять формы с индексами 1, 2 и 4 вдоль границы вверху слайда:
Исходный код ниже выравнивает формы с индексами 1, 2 и 4 вдоль верхней границы слайда.

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### Пример 2

Этот код на Python показывает, как выровнять всю коллекцию форм относительно нижней формы в коллекции:

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```