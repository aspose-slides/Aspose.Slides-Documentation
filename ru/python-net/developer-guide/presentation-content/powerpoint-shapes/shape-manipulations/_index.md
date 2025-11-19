---
title: Управление формами в презентациях с использованием Python
linktitle: Манипулирование формами
type: docs
weight: 40
url: /ru/python-net/shape-manipulations/
keywords:
- Форма PowerPoint
- Форма презентации
- Форма на слайде
- поиск формы
- клонирование формы
- удаление формы
- скрытие формы
- изменение порядка формы
- получение Interop ID формы
- альтернативный текст формы
- форматы макета формы
- форма как SVG
- форма в SVG
- выравнивание формы
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как создавать, редактировать и оптимизировать формы в Aspose.Slides for Python via .NET и создавать высокопроизводительные презентации PowerPoint и OpenDocument."
---

## **Обзор**

Это руководство знакомит с манипуляцией формами в Aspose.Slides for Python via .NET. Узнайте практические шаблоны поиска форм (в том числе по альтернативному тексту), дублирования, удаления или скрытия, переупорядочивания, выравнивания и отражения, чтения идентификаторов и форматирования по макету, а также экспорта отдельных форм в SVG с использованием API [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

## **Поиск форм на слайдах**

PowerPoint идентифицирует формы только по внутренним идентификаторам. Присвойте целевой форме уникальный Alt Text в PowerPoint, затем откройте презентацию с помощью Aspose.Slides for Python, пройдитесь по формам слайда и выберите ту, у которой Alt Text совпадает. Метод `find_shape` реализует этот подход и возвращает найденную форму.
```py
import aspose.slides as slides

# Находит форму на слайде по её альтернативному тексту.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Создаёт экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Находит форму с альтернативным текстом "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **Клонирование форм**

Чтобы клонировать формы из исходного слайда на новый слайд в Aspose.Slides, выполните следующие действия:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) из исходного файла.  
1. Получите исходный слайд по индексу и его коллекцию форм.  
1. Получите пустой макет из главного слайда.  
1. Добавьте пустой слайд, используя этот макет, и получите его формы.  
1. Клонируйте формы в целевой слайд.  
1. Сохраните презентацию в формате PPTX.  

Ниже приведён пример кода, клонирующего формы с одного слайда на другой.
```py
import aspose.slides as slides

# Создаёт экземпляр класса Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes
	
    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Сохранить презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Удаление форм**

Aspose.Slides позволяет удалить любую форму со слайда. Например, чтобы удалить форму с первого слайда по её альтернативному тексту, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите файл.  
1. Получите первый слайд из коллекции слайдов.  
1. Найдите форму по значению альтернативного текста.  
1. Удалите форму из коллекции форм слайда.  
1. Сохраните презентацию на диск в формате PPTX.  
```py
import aspose.slides as slides

# Находит форму на слайде по её альтернативному тексту.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Создаёт экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Находит форму с альтернативным текстом "User Defined".
    shape = find_shape(slide, "User Defined")
    # Удаляет форму.
    slide.shapes.remove(shape)
    # Сохраняет презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Скрытие форм**

Aspose.Slides позволяет скрыть любую форму на слайде. Например, чтобы скрыть форму на первом слайде по её альтернативному тексту, выполните следующие шаги:

1. Создайте объект [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) и загрузите файл.  
1. Получите первый слайд из коллекции слайдов.  
1. Найдите форму по значению альтернативного текста.  
1. Скрыть форму.  
1. Сохраните презентацию на диск в формате PPTX.  
```py
# Находит форму на слайде по её альтернативному тексту.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Создаёт экземпляр класса Presentation, представляющего файл презентации.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Находит форму с альтернативным текстом "User Defined".
    shape = find_shape(slide, "User Defined")
    # Скрывает форму.
    shape.hidden = True
    # Сохраняет презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Изменение порядка форм**

Aspose.Slides позволяет переупорядочивать формы (изменять их Z‑order). Переупорядочивание определяет, какая форма будет отображаться спереди, а какая позади. Например, чтобы изменить порядок двух форм на первом слайде, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Получите первый слайд.  
1. Добавьте первую форму (например, прямоугольник).  
1. Добавьте вторую форму (например, треугольник).  
1. Переупорядочьте формы, переместив вторую форму в первую позицию в коллекции.  
1. Сохраните презентацию на диск.  
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Добавьте две формы на слайд.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Переместите вторую форму в первую позицию.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Получение Interop ID формы**

Aspose.Slides позволяет получить уникальный идентификатор формы в пределах слайда, в отличие от свойства `unique_id`, которое уникально для всей презентации. Свойство `office_interop_shape_id` доступно в классе [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Его значение соответствует `Id` объекта `Microsoft.Office.Interop.PowerPoint.Shape`. Ниже показан пример кода.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Получить уникальный идентификатор формы внутри слайда.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **Установка альтернативного текста для форм**

Aspose.Slides позволяет задавать альтернативный текст для любой формы. Вы можете использовать альтернативный текст для идентификации и поиска форм в презентации. Это свойство можно читать и записывать как через Aspose.Slides, так и через Microsoft PowerPoint. Помечая формы этим свойством, вы позже сможете удалять, скрывать или переупорядочивать их на слайде.

Чтобы установить альтернативный текст формы, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Получите первый слайд.  
1. Добавьте форму на слайд.  
1. Установите альтернативный текст.  
1. Сохраните презентацию на диск.  
```py
import aspose.slides as slides

# Создаёт экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Добавьте форму.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Установите альтернативный текст для формы.
    shape.alternative_text = "User Defined"
    # Сохраните презентацию на диск.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Доступ к форматам макета для форм**

Aspose.Slides предоставляет простой API для доступа к форматам макета форм. В этом разделе показано, как получить доступ к форматам макета.
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **Рендеринг форм в SVG**

Aspose.Slides поддерживает рендеринг форм в SVG. Метод `write_as_svg` (и его перегрузки) в классе [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) позволяет сохранить содержимое формы как SVG‑изображение. Ниже показан фрагмент кода, экспортирующего форму в файл SVG.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Получить первую форму на первом слайде.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **Выравнивание формы**

Используя метод `align_shape` в классе [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), вы можете:

* Выравнивать формы относительно полей слайда (см. пример 1).  
* Выравнивать формы относительно друг друга (см. пример 2).  

Перечисление [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) определяет доступные варианты выравнивания.

**Пример 1**

Этот код Python показывает, как выровнять формы с индексами 1, 2 и 4 по верхнему краю слайда:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**Пример 2**

Этот пример Python показывает, как выровнять все формы в коллекции относительно самой нижней формы в этой коллекции:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **Свойства отражения**

В Aspose.Slides класс [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) обеспечивает управление горизонтальным и вертикальным отражением форм через свойства `flip_h` и `flip_v`. Оба свойства имеют тип [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), позволяющий задавать значение `TRUE` для включения отражения, `FALSE` — без отражения, или `NOT_DEFINED` для использования поведения по умолчанию. Эти значения доступны через [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) формы.

Чтобы изменить настройки отражения, создаётся новый экземпляр [ShapeFrame] с текущими позициями и размерами формы, желаемыми значениями `flip_h` и `flip_v` и углом вращения. Присвоение этого экземпляра свойству [Frame] формы и сохранение презентации применяют трансформации отражения и фиксируют их в выходном файле.

Предположим, у нас есть файл sample.pptx, в котором первый слайд содержит единственную форму с настройками отражения по умолчанию, как показано ниже.

![Форма, которую нужно отразить](shape_to_be_flipped.png)

Следующий пример кода получает текущие свойства отражения формы и отражает её горизонтально и вертикально.
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Получить свойство горизонтального отражения формы.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Получить свойство вертикального отражения формы.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Отразить по горизонтали и вертикали.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


Результат:

![Отражённая форма](flipped_shape.png)

## **FAQ**

**Могу ли я объединять формы (union/intersect/subtract) на слайде, как в настольном редакторе?**

Встроенного API для булевых операций нет. Можно приблизительно реализовать это, построив требуемый контур вручную — например, вычислив итоговую геометрию (через [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)) и создав новую форму с этим контуру, при необходимости удалив исходные.

**Как контролировать порядок наложения (z‑order), чтобы форма всегда оставалась «на переднем плане»?**

Изменяйте порядок вставки/перемещения внутри коллекции [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) слайда. Для предсказуемых результатов рекомендуется фиксировать z‑order после всех остальных изменений слайда.

**Могу ли я «заблокировать» форму, чтобы пользователи не могли её редактировать в PowerPoint?**

Да. Установите [флаги защиты на уровне формы](/slides/ru/python-net/applying-protection-to-presentation/) (например, блокировать выбор, перемещение, изменение размеров, редактирование текста). При необходимости наложите ограничения на мастер‑слайд или макет. Учтите, что это защита только на уровне UI, а не полноценная безопасность; для более надёжной защиты комбинируйте её с ограничениями уровня файла, такими как [рекомендации только для чтения или пароли](/slides/ru/python-net/password-protected-presentation/).