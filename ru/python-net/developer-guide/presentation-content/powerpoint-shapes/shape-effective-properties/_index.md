---
title: Получить эффективные свойства фигур из презентаций на Python
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/python-net/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- система освещения
- фаска формы
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Python через .NET, чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Понимание локальных, унаследованных и эффективных свойств**

Форматирование PowerPoint может поступать из нескольких источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint ищет источники форматирования родителя, такие как значение по умолчанию абзаца, стиль текста, макет или шаблонный слайд, тема или параметры по умолчанию презентации. Эти значения являются **унаследованными значениями**. Значение, оставшееся после разрешения всей иерархии, — **эффективное значение**, которое используется для отрисовки объекта.

Например, часть текста может не определять собственный размер шрифта. Ее локальный [font_height](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ibaseportionformat/font_height/) тогда `float("nan")`, что означает "не задано здесь". Часть может унаследовать высоту от абзаца, стиля текста по умолчанию презентации или другого применимого источника. Вызов [get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformat/get_effective/) для формата части возвращает окончательно разрешенную высоту.

Используйте два типа данных форматирования для разных целей:

- Читайте или изменяйте локальный объект формата, такой как [IPortionFormat](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformat/), когда нужно контролировать, где определено значение.
- Читайте эффективный объект данных, такой как [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformateffectivedata/), когда нужен окончательный, отрисованный результат. Эффективные данные только для чтения.

## **Сравнение локальных, унаследованных и эффективных значений**

Следующий полный пример создает форму и применяет высоты шрифта на уровнях презентации, абзаца и части. Каждый шаг выводит значения, определенные на этих уровнях, и получаемое эффективное значение для той же части текста. Он также демонстрирует, почему эффективные данные необходимо считывать заново после изменения форматирования.

```python
import math

import aspose.slides as slides


def format_local_value(value):
    return "<not set>" if math.isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.default_text_style.get_level(0).default_portion_format.font_height
    paragraph_value = paragraph.paragraph_format.default_portion_format.font_height
    local_value = portion.portion_format.font_height

    # Прочитать эффективные данные после предыдущих изменений.
    effective_value = portion.portion_format.get_effective().font_height

    print(caption)
    print("  Presentation default: " + format_local_value(presentation_value))
    print("  Paragraph default:    " + format_local_value(paragraph_value))
    print("  Portion local:        " + format_local_value(local_value))
    print("  Portion effective:    " + str(effective_value))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 500, 80, False)
    text_frame = shape.add_text_frame("Effective formatting")
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    # Определить унаследованные значения на двух разных уровнях.
    presentation.default_text_style.get_level(0).default_portion_format.font_height = 20
    paragraph.paragraph_format.default_portion_format.font_height = 28

    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Локальное значение в части переопределяет оба унаследованных значения.
    portion.portion_format.font_height = 36
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Изменение унаследованного значения не переопределяет существующее локальное значение.
    paragraph.paragraph_format.default_portion_format.font_height = 30
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Очистить локальное значение. Часть теперь снова наследует значение из абзаца.
    portion.portion_format.font_height = float("nan")
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Очистить значение абзаца. Значение по умолчанию презентации теперь предоставляет результат.
    paragraph.paragraph_format.default_portion_format.font_height = float("nan")
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", slides.export.SaveFormat.PPTX)
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. У других объектов могут быть разные цепочки наследования, но принцип тот же: более специфичное явное значение выигрывает, и [get_effective](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformat/get_effective/) возвращает окончательный результат.

## **Получение эффективных свойств текста**

Форматирование текста разделено между несколькими объектами:

- [ITextFrameFormat.get_effective()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/itextframeformat/get_effective/) разрешает свойства текстового кадра, такие как поля, привязка, автоподгонка и вертикальное направление текста.
- [ITextStyle.get_effective()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/itextstyle/get_effective/) разрешает форматирование абзаца для каждого уровня текстового стиля.
- [IParagraphFormat.get_effective()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iparagraphformat/get_effective/) разрешает свойства абзаца, такие как выравнивание, отступы и маркеры.
- [IPortionFormat.get_effective()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/iportionformat/get_effective/) разрешает свойства символов, такие как высота шрифта, гарнитура, цвет, полужирный и курсив.

Для следующего примера `text-formatting.pptx` должен содержать как минимум один слайд и одну [AutoShape](https://reference.aspose.com/slides/ru/python-net/aspose.slides/autoshape/) с непустым текстовым кадром. AutoShape может находиться в любой позиции в коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```python
import aspose.slides as slides


def has_non_empty_text(shape):
    if not isinstance(shape, slides.AutoShape):
        return False
    if shape.text_frame is None:
        return False
    if shape.text_frame.paragraphs.count == 0:
        return False
    return shape.text_frame.paragraphs[0].portions.count > 0


with slides.Presentation("text-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    shape = None
    for candidate in presentation.slides[0].shapes:
        if has_non_empty_text(candidate):
            shape = candidate
            break

    if shape is None:
        raise RuntimeError("The first slide must contain an AutoShape with non-empty text.")

    text_frame = shape.text_frame
    paragraph = text_frame.paragraphs[0]
    portion = paragraph.portions[0]

    text_frame_effective = text_frame.text_frame_format.get_effective()
    paragraph_effective = paragraph.paragraph_format.get_effective()
    portion_effective = portion.portion_format.get_effective()

    print("Text frame margins:")
    print("  Left: " + str(text_frame_effective.margin_left))
    print("  Top: " + str(text_frame_effective.margin_top))
    print("  Right: " + str(text_frame_effective.margin_right))
    print("  Bottom: " + str(text_frame_effective.margin_bottom))
    print("Paragraph alignment: " + str(paragraph_effective.alignment))
    print("Font height: " + str(portion_effective.font_height))
    print("Bold: " + str(portion_effective.font_bold))

    effective_text_style = text_frame.text_frame_format.text_style.get_effective()
    for level in range(9):
        level_effective = effective_text_style.get_level(level)
        print("Level " + str(level) + " indent: " + str(level_effective.indent))
```

## **Получение эффективных 3D‑свойств**

[IThreeDFormat.get_effective()](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformat/get_effective/) возвращает один объект [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/), который группирует все разрешённые 3D‑настройки. Его свойства [camera](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/camera/), [light_rig](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/light_rig/), [bevel_top](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/bevel_top/), и [bevel_bottom](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ithreedformateffectivedata/bevel_bottom/) предоставляют соответствующие эффективные данные. Чтение этих связанных настроек вместе облегчает понимание окончательного 3D‑вида формы.

Для этого примера `shape-3d.pptx` должен содержать как минимум одну форму на первом слайде. Примените к этой форме 3D‑камеру, освещение или настройки фаски, если хотите, чтобы вывод содержал значения, отличные от значений по умолчанию.

```python
import aspose.slides as slides


with slides.Presentation("shape-3d.pptx") as presentation:
    if presentation.slides.count == 0 or presentation.slides[0].shapes.count == 0:
        raise RuntimeError("The first slide must contain a shape.")

    shape = presentation.slides[0].shapes[0]
    three_d_effective = shape.three_d_format.get_effective()

    print("Camera:")
    print("  Type: " + str(three_d_effective.camera.camera_type))
    print("  Field of view: " + str(three_d_effective.camera.field_of_view_angle))
    print("  Zoom: " + str(three_d_effective.camera.zoom))

    print("Light rig:")
    print("  Type: " + str(three_d_effective.light_rig.light_type))
    print("  Direction: " + str(three_d_effective.light_rig.direction))

    print("Top bevel:")
    print("  Type: " + str(three_d_effective.bevel_top.bevel_type))
    print("  Width: " + str(three_d_effective.bevel_top.width))
    print("  Height: " + str(three_d_effective.bevel_top.height))
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может поступать из стиля таблицы и из форматов, применённых ко всей таблице, колонке, строке или отдельной ячейке. При конфликте явно заданных заливок приоритетом является ячейка, строка, колонка и затем вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для её отрисовки.

Для этого примера `table-formatting.pptx` должен содержать как минимум одну таблицу на первом слайде. Таблица должна иметь как минимум одну строку и одну колонку. Код ищет [Table](https://reference.aspose.com/slides/ru/python-net/aspose.slides/table/) вместо предположения, что `shapes[0]` — это таблица.

```python
import aspose.slides as slides


with slides.Presentation("table-formatting.pptx") as presentation:
    if presentation.slides.count == 0:
        raise RuntimeError("The presentation contains no slides.")

    table = None
    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is None:
        raise RuntimeError("The first slide must contain a table.")

    if table.rows.count == 0 or table.columns.count == 0:
        raise RuntimeError("The table must contain at least one cell.")

    table_effective = table.table_format.get_effective()
    row_effective = table.rows[0].row_format.get_effective()
    column_effective = table.columns[0].column_format.get_effective()
    cell_effective = table.rows[0][0].cell_format.get_effective()

    print("Table fill: " + str(table_effective.fill_format.fill_type))
    print("Row fill: " + str(row_effective.fill_format.fill_type))
    print("Column fill: " + str(column_effective.fill_format.fill_type))
    print("Final cell fill: " + str(cell_effective.fill_format.fill_type))
```

Если вам нужен цвет, а не только тип заливки, сначала проверьте эффективный [fill_type](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/fill_type/), а затем прочитайте свойство, соответствующее этому типу, например, [solid_fill_color](https://reference.aspose.com/slides/ru/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент их разрешения. Вызовите `get_effective` снова после изменения любого элемента, участвующего в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию абзаца или текстового кадра;
- стиль таблицы, формат таблицы, колонки, строки или ячейки;
- форматирование макета или шаблонного слайда;
- данные темы или значения по умолчанию презентации;
- макет или шаблон, назначенный слайду.

Не сохраняйте объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутренне, и последующий вызов `get_effective` может обновить эти данные. Если нужно сравнить значения до и после изменения, скопируйте скалярные значения, которые вам нужны, такие как высота шрифта, цвет, выравнивание или ширина фаски, в свои переменные перед изменением.

Чтобы изменить значение, обновите соответствующий локальный объект формата и затем вызовите `get_effective` для проверки результата. Объекты эффективных данных только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**

Эффективные данные содержат окончательное значение, а не его источник. Проверьте применимые локальные объекты, начиная с самого специфичного уровня и движитесь наружу. Для текста это могут быть часть, абзац, текстовый кадр, макет, шаблон, тема и значения по умолчанию презентации. Неопределённые значения, такие как `float("nan")` или `None`, указывают, что поиск продолжается на следующем уровне.

**Что происходит, если ни один уровень не определяет свойство?**

Aspose.Slides определяет соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, даже если ни один локальный объект явно его не задаёт.

**Почему эффективное значение иногда совпадает с локальным?**

Локальное значение победило в расчёте наследования. Это ожидаемо, когда свойство явно установлено в объекте и более специфичное правило его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**

Используйте локальные данные для просмотра или редактирования конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный внешний вид после применения наследования, правил темы и соответствующих стилей. Полный пример сравнения ([compare-local-inherited-and-effective-values](#compare-local-inherited-and-effective-values)) демонстрирует оба подхода в одном рабочем процессе.