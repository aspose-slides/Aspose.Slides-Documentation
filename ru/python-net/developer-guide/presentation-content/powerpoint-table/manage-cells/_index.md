---
title: Управление ячейками таблиц в презентациях с Python
linktitle: Управление ячейками
type: docs
weight: 30
url: /ru/python-net/manage-cells/
keywords:
- ячейка таблицы
- объединение ячеек
- удалить границу
- разделить ячейку
- изображение в ячейке
- цвет фона
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Легко управлять ячейками таблиц в PowerPoint и OpenDocument с помощью Aspose.Slides для Python через .NET. Овладейте быстрым доступом, изменением и стилизацией ячеек для бесшовной автоматизации слайдов."
---

## **Обзор**

В этой статье показано, как работать с ячейками таблиц в презентациях с помощью Aspose.Slides. Вы узнаете, как определять объединённые ячейки, очищать или настраивать границы ячеек, а также как PowerPoint перенумеровывает ячейки после операций объединения и разделения, чтобы вы могли предсказывать индексы в сложных макетах. Статья также демонстрирует типичные задачи форматирования — например, изменение фоновой заливки ячейки — и показывает, как разместить изображение непосредственно внутри ячейки таблицы с помощью параметров заливки картинкой. Каждый сценарий сопровождается лаконичными примерами на Python, которые создают или изменяют таблицы и затем сохраняют обновлённую презентацию, чтобы вы могли быстро адаптировать фрагменты к своим слайдам.

## **Определение объединённых ячеек таблицы**

В таблицах часто используются объединённые ячейки для заголовков или группировки связанных данных. В этом разделе вы увидите, как определить, принадлежит ли конкретная ячейка объединённому региону, и как сослаться на главную (верхне‑левую) ячейку, чтобы читать или форматировать весь блок последовательно.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите таблицу с первого слайда.
1. Пройдитесь по строкам и столбцам таблицы, чтобы найти объединённые ячейки.
1. Выведите сообщение, когда найдены объединённые ячейки.

Следующий код на Python определяет объединённые ячейки таблицы в презентации:
```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Предполагается, что первая фигура на первом слайде — таблица.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```


## **Удаление границ ячеек таблицы**

Иногда границы таблицы отвлекают от содержания или создают визуальный шум. В этом разделе показано, как удалить границы у выбранных ячеек — либо у всей ячейки, либо у отдельных её сторон — чтобы получить более чистый макет и лучше соответствовать дизайну слайда.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите слайд по его индексу.
1. Определите массив ширин столбцов.
1. Определите массив высот строк.
1. Добавьте таблицу на слайд с помощью метода [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. Пройдитесь по каждой ячейке, чтобы очистить верхнюю, нижнюю, левую и правую границы.
1. Сохраните изменённую презентацию как файл PPTX.

Следующий код на Python показывает, как удалить границы у ячеек таблицы:
```python
import aspose.slides as slides

# Создайте объект класса Presentation, представляющий файл PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Определите столбцы с ширинами и строки с высотами.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Добавьте форму таблицы на слайд.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Очистите заливку границ для каждой ячейки.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Сохраните файл PPTX на диск.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Нумерация в объединённых ячейках**

Если объединить две пары ячеек — например, (1, 1) × (2, 1) и (1, 2) × (2, 2) — получившаяся таблица будет сохранять ту же нумерацию ячеек, что и таблица без объединения. Следующий код на Python демонстрирует это поведение:
```python
import aspose.slides as slides

    # Создайте экземпляр класса Presentation, представляющего файл PPTX.
    with slides.Presentation() as presentation:
        # Получите первый слайд.
        slide = presentation.slides[0]

        # Определите столбцы с ширинами и строки с высотами.
        column_widths = [70, 70, 70, 70]
        row_heights = [70, 70, 70, 70]

        # Добавьте форму таблицы на слайд.
        table = slide.shapes.add_table(50, 50, column_widths, row_heights)

        # Объедините ячейки (1,1) и (2,1).
        table.merge_cells(table.rows[1][1], table.rows[2][1], False)

        # Объедините ячейки (1, 2) и (2, 2).
        table.merge_cells(table.rows[1][2], table.rows[2][2], False)

        # Выведите индексы ячеек.
        for row_index in range(len(table.rows)):
            for column_index in range(len(table.rows[row_index])):
                cell = table.rows[row_index][column_index]
                print(f"{cell.first_row_index, cell.first_column_index} ", end="")
            print()

        # Сохраните файл PPTX на диск.
        presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```


Вывод:
```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```


## **Нумерация в разрезанных ячейках**

В предыдущем примере при объединении ячеек нумерация остальных ячеек не менялась. На этот раз мы создаём обычную таблицу (без объединённых ячеек), а затем разрезаем ячейку (1, 1), получая особую таблицу. Обратите внимание на нумерацию этой таблицы — она может выглядеть необычно. Однако именно так Microsoft PowerPoint нумерует ячейки таблицы, и Aspose.Slides следует этому поведению.

Следующий код на Python демонстрирует это поведение:
```python
import aspose.slides as slides

# Создайте экземпляр класса Presentation, представляющий файл PPTX.
with slides.Presentation() as presentation:
    # Получите первый слайд.
    slide = presentation.slides[0]

    # Определите ширины столбцов и высоты строк.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Добавьте форму таблицы на слайд.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Разделите ячейку (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Выведите индексы ячеек.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Сохраните файл PPTX на диск.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```


Вывод:
```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```


## **Изменение фонового цвета ячейки таблицы**

Следующий пример на Python демонстрирует, как изменить фон ячейки таблицы:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Создайте новую таблицу.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Установите цвет фона для ячейки.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```


## **Вставка изображений в ячейки таблицы**

В этом разделе показано, как вставить изображение в ячейку таблицы в Aspose.Slides. Описывается применение заливки картинкой к целевой ячейке и настройка параметров отображения, таких как растягивание или мозаика.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Получите ссылку на слайд по его индексу.
1. Определите массив ширин столбцов.
1. Определите массив высот строк.
1. Добавьте таблицу на слайд с помощью метода [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) .
1. Загрузите изображение из файла.
1. Добавьте изображение в коллекцию изображений презентации, чтобы получить объект [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) .
1. Установите для ячейки таблицы свойство [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) в значение `PICTURE` .
1. Примените изображение к ячейке таблицы и выберите режим заливки (например, `STRETCH`) .
1. Сохраните презентацию как файл PPTX.

Следующий код на Python показывает, как разместить изображение внутри ячейки таблицы при её создании:
```python
import aspose.slides as slides

# Создать объект Presentation.
with slides.Presentation() as presentation:
    # Получить первый слайд.
    slide = presentation.slides[0]

    # Определить ширины столбцов и высоты строк.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Добавить форму таблицы на слайд.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Загрузить изображение и добавить его в презентацию для получения PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Применить изображение к первой ячейке таблицы.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Сохранить презентацию на диск.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Можно ли задать разную толщину и стиль линий для разных сторон одной ячейки?**

Да. Границы [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) имеют отдельные свойства, поэтому толщина и стиль каждой стороны могут различаться. Это логически вытекает из управления границами по сторонам, продемонстрированного в статье.

**Что происходит с изображением, если изменить размер столбца/строки после установки картинки как фона ячейки?**

Поведение зависит от [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile). При растягивании изображение подстраивается под новую ячейку; при мозаике плитки пересчитываются. В статье упоминаются режимы отображения изображения в ячейке.

**Можно ли назначить гиперссылку всему содержимому ячейки?**

[Hyperlinks](/slides/ru/python-net/manage-hyperlinks/) устанавливаются на уровне текста (portion) внутри текстового кадра ячейки или на уровне всей таблицы/фигуры. На практике вы назначаете ссылку отдельному участку или всему тексту в ячейке.

**Можно ли задать разные шрифты внутри одной ячейки?**

Да. Текстовый кадр ячейки поддерживает [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (фрагменты) с независимым форматированием — семейство шрифта, стиль, размер и цвет.