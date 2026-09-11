---
title: Получить эффективные свойства фигур из презентаций в Python через Java
linktitle: Эффективные свойства
type: docs
weight: 50
url: /ru/python-java/shape-effective-properties/
keywords:
- свойства фигур
- свойства камеры
- освещение
- фаска фигуры
- текстовый кадр
- стиль текста
- высота шрифта
- формат заливки
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как использовать Aspose.Slides для Python через Java, чтобы различать локальное, унаследованное и эффективное форматирование фигур в презентациях PowerPoint."
---
## **Понимание локальных, унаследованных и эффективных свойств**

Форматирование PowerPoint может поступать из нескольких источников. Значение, хранящееся непосредственно в объекте, является его **локальным значением**. Если это значение не задано, PowerPoint ищет источники форматирования у родителя, такие как формат по умолчанию для абзаца, текстовый стиль, макет или главный слайд, тема или значения по умолчанию уровня презентации. Эти значения являются **унаследованными значениями**. Значение, оставшееся после разрешения всей иерархии, — это **эффективное значение** — значение, используемое для отрисовки объекта.

Например, часть текста может не определять собственный размер шрифта. Ее локальное значение [getFontHeight](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseportionformat/#getFontHeight) тогда равно `float("nan")`, что означает «не задано здесь». Часть может унаследовать высоту от абзаца, стиля текста по умолчанию презентации или другого применимого источника. Вызов [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) у формата части возвращает окончательную разрешённую высоту.

Используйте два типа данных форматирования для разных целей:

- Читайте или изменяйте локальный объект формата, например [PortionFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/), когда необходимо контролировать, где задано значение.
- Читайте объект эффективных данных, например `PortionFormatEffectiveData`, когда нужен окончательный отрисованный результат. Эффективные данные доступны только для чтения.

## **Сравнение локальных, унаследованных и эффективных значений**

Следующий полный пример создаёт фигуру и применяет высоту шрифта на уровнях презентации, абзаца и части. На каждом шаге выводятся значения, определённые на этих уровнях, и получаемое эффективное значение для той же части текста. Пример также демонстрирует, почему эффективные данные нужно считывать повторно после изменения форматирования.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from math import isnan
from asposeslides.api import Presentation, SaveFormat, ShapeType


def format_local_value(value):
    return "<not set>" if isnan(value) else str(value)


def print_font_heights(caption, presentation, paragraph, portion):
    presentation_value = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight()
    paragraph_value = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight()
    local_value = portion.getPortionFormat().getFontHeight()

    # Прочитать эффективные данные после предыдущих изменений.
    effective_value = portion.getPortionFormat().getEffective().getFontHeight()

    print(caption)
    print(f"  Presentation default: {format_local_value(presentation_value)}")
    print(f"  Paragraph default:    {format_local_value(paragraph_value)}")
    print(f"  Portion local:        {format_local_value(local_value)}")
    print(f"  Portion effective:    {effective_value}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, False)
    text_frame = shape.addTextFrame("Effective formatting")
    paragraph = text_frame.getParagraphs().get_Item(0)
    portion = paragraph.getPortions().get_Item(0)

    # Определить унаследованные значения на двух разных уровнях.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28)
    print_font_heights("The portion inherits from the paragraph", presentation, paragraph, portion)

    # Локальное значение в части переопределяет оба унаследованных значения.
    portion.getPortionFormat().setFontHeight(36)
    print_font_heights("A local value overrides inherited values", presentation, paragraph, portion)

    # Изменение унаследованного значения не переопределяет существующее локальное значение.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30)
    print_font_heights("The local value still has priority", presentation, paragraph, portion)

    # Очистить локальное значение. Теперь часть снова наследует значение от абзаца.
    portion.getPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The local value is cleared", presentation, paragraph, portion)

    # Очистить значение абзаца. Теперь значение берётся из настроек по умолчанию презентации.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(float("nan"))
    print_font_heights("The paragraph value is cleared", presentation, paragraph, portion)

    presentation.save("effective-properties.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Приоритет в этом примере: локальное форматирование части, затем форматирование абзаца, затем значение по умолчанию презентации. У других объектов могут быть разные цепочки наследования, но принцип тот же: более специфичное явно заданное значение выигрывает, а [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) возвращает окончательный результат.

## **Получение эффективных свойств текста**

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframeformat/#getEffective) разрешает свойства текстового кадра, такие как поля, привязка, автоподгонка и вертикальное направление текста.
- [TextStyle.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textstyle/#getEffective) разрешает форматирование абзаца для каждого уровня текстового стиля.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/paragraphformat/#getEffective) разрешает свойства абзаца, такие как выравнивание, отступы и маркеры.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) разрешает свойства символов, такие как высота шрифта, гарнитура, цвет, полужирный и курсив.

Для следующего примера в файле `text-formatting.pptx` должен присутствовать хотя бы один слайд и одна [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/) с непустым текстовым кадром. AutoShape может находиться в любой позиции коллекции фигур; код ищет подходящий объект и проверяет его перед использованием.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation


def has_non_empty_text(shape):
    text_frame = shape.getTextFrame()
    if text_frame is None or text_frame.getParagraphs().getCount() == 0:
        return False
    return text_frame.getParagraphs().get_Item(0).getPortions().getCount() > 0


def find_auto_shape_with_text(slide):
    for candidate in slide.getShapes():
        if isinstance(candidate, AutoShape) and has_non_empty_text(candidate):
            return candidate
    return None


presentation = Presentation("text-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        shape = find_auto_shape_with_text(presentation.getSlides().get_Item(0))
        if shape is None:
            print("The first slide must contain an AutoShape with non-empty text.")
        else:
            text_frame = shape.getTextFrame()
            paragraph = text_frame.getParagraphs().get_Item(0)
            portion = paragraph.getPortions().get_Item(0)

            text_frame_effective = text_frame.getTextFrameFormat().getEffective()
            paragraph_effective = paragraph.getParagraphFormat().getEffective()
            portion_effective = portion.getPortionFormat().getEffective()

            print("Text frame margins:")
            print(f"  Left: {text_frame_effective.getMarginLeft()}")
            print(f"  Top: {text_frame_effective.getMarginTop()}")
            print(f"  Right: {text_frame_effective.getMarginRight()}")
            print(f"  Bottom: {text_frame_effective.getMarginBottom()}")
            print(f"Paragraph alignment: {paragraph_effective.getAlignment()}")
            print(f"Font height: {portion_effective.getFontHeight()}")
            print(f"Bold: {portion_effective.getFontBold()}")

            effective_text_style = text_frame.getTextFrameFormat().getTextStyle().getEffective()
            for level in range(9):
                level_effective = effective_text_style.getLevel(level)
                print(f"Level {level} indent: {level_effective.getIndent()}")
finally:
    presentation.dispose()
```

## **Получение эффективных 3D‑свойств**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/threedformat/#getEffective) возвращает один объект `ThreeDFormatEffectiveData`, который группирует все разрешённые 3D‑настройки. Его методы `getCamera`, `getLightRig`, `getBevelTop` и `getBevelBottom` предоставляют соответствующие эффективные данные. Совместное чтение этих связанных настроек упрощает понимание окончательного 3D‑вида фигуры.

Для этого примера в файле `shape-3d.pptx` должна быть хотя бы одна фигура на первом слайде. Примените к этой фигуре 3D‑камеру, освещение или параметры фаски, если хотите, чтобы вывод содержал значения, отличные от значений по умолчанию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("shape-3d.pptx")
try:
    if presentation.getSlides().size() == 0 or presentation.getSlides().get_Item(0).getShapes().size() == 0:
        print("The first slide must contain a shape.")
    else:
        shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        three_d_effective = shape.getThreeDFormat().getEffective()

        print("Camera:")
        print(f"  Type: {three_d_effective.getCamera().getCameraType()}")
        print(f"  Field of view: {three_d_effective.getCamera().getFieldOfViewAngle()}")
        print(f"  Zoom: {three_d_effective.getCamera().getZoom()}")

        print("Light rig:")
        print(f"  Type: {three_d_effective.getLightRig().getLightType()}")
        print(f"  Direction: {three_d_effective.getLightRig().getDirection()}")

        print("Top bevel:")
        print(f"  Type: {three_d_effective.getBevelTop().getBevelType()}")
        print(f"  Width: {three_d_effective.getBevelTop().getWidth()}")
        print(f"  Height: {three_d_effective.getBevelTop().getHeight()}")
finally:
    presentation.dispose()
```

## **Получение эффективного форматирования таблицы**

Форматирование таблицы может исходить из стиля таблицы и из форматов, применённых ко всей таблице, столбцу, строке или отдельной ячейке. При конфликте явно заданных заливок приоритет имеет ячейка, затем строка, столбец и, наконец, вся таблица. Эффективный формат ячейки — это окончательный формат, используемый для её отрисовки.

Для этого примера в файле `table-formatting.pptx` должна быть хотя бы одна таблица на первом слайде. Таблица должна содержать хотя бы одну строку и один столбец. Код ищет объект [Table](https://reference.aspose.com/slides/ru/python-java/aspose.slides/table/), а не предполагает, что `getShapes().get_Item(0)` является таблицей.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table


def find_table(slide):
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            return shape
    return None


presentation = Presentation("table-formatting.pptx")
try:
    if presentation.getSlides().size() == 0:
        print("The presentation contains no slides.")
    else:
        table = find_table(presentation.getSlides().get_Item(0))
        if table is None:
            print("The first slide must contain a table.")
        elif table.getRows().size() == 0 or table.getColumns().size() == 0:
            print("The table must contain at least one cell.")
        else:
            table_effective = table.getTableFormat().getEffective()
            row_effective = table.getRows().get_Item(0).getRowFormat().getEffective()
            column_effective = table.getColumns().get_Item(0).getColumnFormat().getEffective()
            cell_effective = table.get_Item(0, 0).getCellFormat().getEffective()

            print(f"Table fill: {table_effective.getFillFormat().getFillType()}")
            print(f"Row fill: {row_effective.getFillFormat().getFillType()}")
            print(f"Column fill: {column_effective.getFillFormat().getFillType()}")
            print(f"Final cell fill: {cell_effective.getFillFormat().getFillType()}")
finally:
    presentation.dispose()
```

Если нужен цвет, а не только тип заливки, сначала проверьте эффективный `getFillType`, а затем читайте метод, соответствующий этому типу — например, `getSolidFillColor` для сплошной заливки.

## **Повторное чтение эффективных данных после изменений**

Эффективные данные описывают иерархию форматирования в момент её разрешения. Вызовите [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) ещё раз после изменения любого элемента, который может участвовать в этой иерархии, включая:

- локальное форматирование объекта;
- значения по умолчанию для абзаца или текстового кадра;
- стиль таблицы, таблицу, столбец, строку или формат ячейки;
- форматирование макета или главного слайда;
- данные темы или значения по умолчанию уровня презентации;
- макет или главный слайд, назначенный данному слайду.

Не храните объект эффективных данных как постоянный снимок. Aspose.Slides может кэшировать некоторые эффективные данные внутри, и последующий вызов [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) может обновить эти данные. Если необходимо сравнить значения до и после изменения, скопируйте скалярные значения, которые вам нужны — например, высоту шрифта, цвет, выравнивание или ширину фаски — в собственные переменные перед внесением изменения.

Чтобы изменить значение, обновите соответствующий локальный объект формата, а затем вызовите [getEffective](https://reference.aspose.com/slides/ru/python-java/aspose.slides/portionformat/#getEffective) для проверки результата. Объекты эффективных данных сами по себе только для чтения.

## **FAQ**

**Как определить, какой уровень предоставил эффективное значение?**  
Эффективные данные содержат только окончательное значение, а не его источник. Проверяйте применимые локальные объекты, начиная с самого специфичного уровня и двигаясь наружу. Для текста это могут быть часть, абзац, текстовый кадр, макет, главный слайд, тема и значения по умолчанию презентации. Неопределённые значения, такие как `float("nan")` или `None`, указывают, что поиск продолжается на более высоком уровне.

**Что происходит, когда ни один уровень не задаёт свойство?**  
Aspose.Slides разрешает соответствующее значение по умолчанию PowerPoint или библиотеки. Это разрешённое значение появляется в эффективных данных, хотя ни один локальный объект явно его не задаёт.

**Почему иногда эффективное значение равно локальному?**  
Локальное значение выиграло в расчёте наследования. Это ожидаемо, когда свойство явно установлено в объекте и ни правило более специфичное его не переопределяет.

**Когда следует использовать локальные данные вместо эффективных?**  
Используйте локальные данные для просмотра или редактирования конкретного уровня форматирования. Используйте эффективные данные, когда нужен окончательный вид после применения наследования, правил темы и применимых стилей. Полный пример сравнения (см. выше) демонстрирует оба подхода в одном рабочем процессе.