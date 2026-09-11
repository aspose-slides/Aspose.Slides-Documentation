---
title: Управление фигурами презентации в Python через Java
linktitle: Манипуляция фигурами
type: docs
weight: 40
url: /ru/python-java/shape-manipulations/
keywords:
- Фигура PowerPoint
- Фигура презентации
- Фигура на слайде
- Найти фигуру
- Клонировать фигуру
- Удалить фигуру
- Скрыть фигуру
- Изменить порядок фигур
- Получить interop ID фигуры
- Альтернативный текст фигуры
- Точка регулировки фигуры
- Регулировка предустановленной фигуры
- Геометрия фигуры
- Форматы макета фигуры
- Фигура в формате SVG
- Экспорт фигуры в SVG
- Выровнять фигуру
- Отразить фигуру
- PowerPoint
- Презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как идентифицировать, регулировать, клонировать, удалять, скрывать, переупорядочивать, экспортировать, выравнивать и отражать фигуры презентации с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Aspose.Slides for Python via Java представляет фигуры на слайде в виде упорядоченного [ShapeCollection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/). Эта коллекция одновременно служит местом, где можно находить и изменять фигуры, и источником их порядка наложения: индекс `0` — самая задняя фигура, а последний индекс — самая передняя.

В этой статье описывается именно такая модель. Сначала объясняется, как надёжно идентифицировать фигуру и изменять предустановленные точки регулировки, затем показывается, как клонировать, удалять, скрывать и переупорядочивать фигуры. В заключительных разделах рассматриваются форматирование на уровне макета, экспорт в SVG, выравнивание и параметры отражения. Каждый пример независим, поэтому можно использовать только те операции, которые нужны вашему рабочему процессу.

## **Определение и поиск фигур**

Индексы коллекции удобны при обработке известного файла, но они не являются стабильными идентификаторами. Добавление, удаление или переупорядочивание фигуры могут изменить её индекс. Выберите идентификатор в зависимости от того, как презентация создаётся и поддерживается:

- [Name](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getName) полезно для шаблонов, управляемых разработчиком, и легко просматривается в панеле выбора PowerPoint. Имена могут редактироваться и не гарантируют уникальность, поэтому при зависимости кода от них следует установить конвенцию именования.
- [AlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText) удобно, когда описание доступности или тег, заданный автором, уже идентифицирует фигуру. Оно видно пользователям, может быть локализовано или переписано для доступности и не гарантирует уникальность. Не используйте осмысленный текст доступности в качестве ключа базы данных без явного согласования.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getOfficeInteropShapeId) — идентификатор только для чтения, уникальный в пределах слайда и соответствующий ID фигуры, используемому в PowerPoint interop. Применяйте его при интеграции с PowerPoint или когда нужен однозначный ссылочный объект в течение жизни фигуры. Клонированная или воссозданная фигура — другая фигура и получает собственный ID.

Связанный метод [getUniqueId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getUniqueId) возвращает идентификатор в области презентации, но он предназначен для надстроек и может быть переименован. Не следует рассматривать его как постоянный внешний ключ. Если нужна долговременная идентичность, храните сопоставление в данных приложения и проверяйте, существует ли ожидаемая фигура.

Следующий пример ищет по имени с точным сравнением и выводит межслайдовый interop‑ID. Когда шаблон не содержит ожидаемой фигуры, код сообщает об этом вместо продолжения работы с неверным объектом.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

Когда операция специфична для типа фигуры, проверьте тип перед использованием членов, характерных для этого типа. В этом примере обновляются текст и альтернативный текст только если именованный объект является [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **Определение и изменение предустановленных регулировок фигур**

Фигуры с предустановленной геометрией могут иметь точки регулировки, управляющие, например, размером углов, пропорциями стрелок или углами дуг. Доступ к ним осуществляется через только‑для‑чтения коллекцию [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/geometryshape/#getAdjustments). Коллекция поставляется фигурой, но каждый [AdjustValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/) содержит значение, которое можно изменить.

Не полагайтесь только на фиксированный индекс коллекции. Итерируйте регулировки и проверяйте метод только‑для‑чтения [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType), чей тип [ShapeAdjustmentType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/) описывает, что регулирует данная настройка. Метод только‑для‑чтения [getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) предоставляет дополнительную идентификационную информацию и особенно полезен, когда предустановка содержит более одной регулировки с одинаковым семантическим типом.

Используйте метод значения, соответствующий смыслу регулировки:

| Тип регулировки | Назначение | Значение для изменения |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | Размер скруглённых углов | [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | Толщина хвоста стрелки | [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | Длина наконечника стрелки | [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | Ширина наконечника стрелки | [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | Начальный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | Конечный угол сектора или дуги | [setAngleValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType) и [getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) возвращают только‑для‑чтения информацию. [getRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getRawValue) и [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue) работают с целым числом в родных единицах геометрии предустановки, а [getAngleValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getAngleValue) и [setAngleValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setAngleValue) — с углом в градусах. Количество, порядок, смысл и допустимый диапазон регулировок зависят от предустановленного [ShapeType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/geometryshape/#getShapeType). Значение, допустимое для одной предустановки, может быть недопустимым или иметь иной эффект для другой.

Когда [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType) возвращает [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#Custom), API не распознаёт стандартный семантический смысл. Исследуйте [getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName), тип предустановки и текущее значение и оставляйте регулировку без изменений, если смысл и диапазон неизвестны. Даже для распознанных типов проверяйте, не встречается ли тот же тип более одного раза, прежде чем выбирать значение. Статья [Connector](/slides/ru/python-java/connector/) демонстрирует эту ситуацию с регулировками изгибов соединителя.

Следующий полнофункциональный пример создаёт стандартные и изменённые варианты трёх предустановленных фигур. Он проходит по каждой регулировке, выводит её имя и тип, изменяет значения, связанные с размером, через [setRawValue], меняет углы через [setAngleValue] и сохраняет результат. Левая колонка сохраняет исходную геометрию; правая показывает скорректированный скруглённый прямоугольник, четырёхстороннюю стрелку и сектор.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Добавляет заголовки для столбцов с фигурами по умолчанию и изменёнными параметрами.
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Проверка семантического типа перед изменением значения делает код явным в своих намерениях и избавляет от предположения, что определённый индекс коллекции имеет одинаковый смысл в разных предустановках фигур.

## **Изменение коллекции фигур**

Методы добавления, клонирования, удаления и переупорядочивания воздействуют на коллекцию немедленно. Если операция меняет количество или порядок фигур, не продолжайте использовать индексы, захваченные до этой операции.

### **Клонирование фигуры**

[addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addClone) создаёт независимую копию и добавляет её в конец целевой коллекции. [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#insertClone) тоже создаёт копию, но помещает её по указанному индексу z‑порядка. Перегрузки, принимающие координаты, перемещают клон без изменения его размера; перегрузки с шириной и высотой могут изменить размер.

Пример создаёт целевой слайд, клонирует помеченный прямоугольник на передний план и вставляет второй клон в заднюю часть. Изменения любого из клонов не влияют на исходную фигуру.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Клонирование копирует содержимое и форматирование фигуры, включая её имя и альтернативный текст. Присвойте клону новые логические идентификаторы, если эти значения должны быть уникальными. Ресурсы, используемые сложными фигурами, обрабатываются презентацией, но клон остаётся новым элементом коллекции с новой идентичностью фигуры.

### **Удаление фигур**

[remove](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#remove) удаляет конкретный объект фигуры из его коллекции. При удалении нескольких совпадений во время итерации по индексам проходите с конца, чтобы каждый оставшийся индекс оставался валидным.

В этом примере удаляются все фигуры с заданным именем. Он читает фигуру по текущему индексу, а не фиксированный элемент коллекции, и не приводит тип фигуры без необходимости.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

После удаления меняются количество фигур и индексы последующих. Ссылки на не затронутые фигуры остаются более надёжными, чем сохранённые индексы. Также учитывайте соединители, анимацию и другие функции презентации, которые могут ссылаться на удалённый объект; удаление видимой фигуры может изменить не только внешний вид слайда.

### **Скрытие фигуры**

Установка [Hidden](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setHidden) в `True` оставляет фигуру в коллекции, но не позволяет ей отображаться в обычном режиме показа слайдов. Её индекс, форматирование и содержимое остаются доступными коду, поэтому скрытие подходит для необязательных элементов, которые могут быть восстановлены позже.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Скрытие — не удаление и не защита. Объект всё ещё может быть найден и раскрыт пользователем или кодом, и остаётся частью файла презентации.

### **Изменение порядка наложения (Z-Order)**

Перекрывающиеся фигуры рисуются в порядке коллекции. [reorder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#reorder) перемещает существующую фигуру к целевому индексу без её клонирования. Индекс `0` — задний; [size](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#size) минус один — передний.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Прямоугольник создаётся первым и изначально находится позади эллипса. Перемещение его к конечному индексу помещает его спереди. Завершайте настройку z‑order после добавления или клонирования всех связанных фигур, поскольку эти операции добавляют новые элементы коллекции и могут изменить желаемый стек.

## **Проверка фигур на макетных слайдах**

Обычные слайды, макетные слайды и слайды‑шаблоны имеют отдельные коллекции фигур. Фигура в коллекции макета — не тот же объект, что аналогично расположенная фигура на обычном слайде. Проверяйте фигуры макета, когда нужно понять или изменить форматирование, предоставляемое макетом.

Следующий пример читает у каждой фигуры макета [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getFillFormat) и [LineFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getLineFormat), не предполагая, что каждая фигура является [AutoShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

Редактирование макета может затронуть несколько слайдов, использующих его. Прежде чем изменить фигуру макета, определите, наследует ли её обычный слайд или содержит локальное переопределение, и проверьте каждый слайд, использующий этот макет.

## **Экспорт фигуры в SVG**

Метод `writeAsSvg` класса [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) записывает отрендеренное содержимое одной фигуры в поток. Результат содержит только эту фигуру, а не фон всего слайда или соседние фигуры.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Держите презентацию открытой во время рендеринга. Вывод зависит от форматирования фигуры и от ресурсов, таких как шрифты и изображения. Если нужен весь комплект, экспортируйте слайд, а не отдельную фигуру. Вызывающая сторона владеет потоком и обязана его закрыть.

## **Выровнять фигуры**

Перегрузки [SlideUtil.alignShapes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/slideutil/#alignShapes) выравнивают либо все фигуры, либо выбранные индексы коллекции. [ShapesAlignmentType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapesalignmenttype/) определяет ребро, центральную линию или режим распределения. Установите `align_to_slide` в `True`, чтобы использовать границы слайда; установите в `False`, чтобы выравнивать выбранные фигуры относительно друг друга.

В этом примере три фигуры выравниваются по верхнему краю слайда. Ссылки на фигуры преобразуются в их текущие индексы непосредственно перед выравниванием.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Выровнять меняет позиции, а не порядок наложения. Относительное выравнивание обычно требует минимум две фигуры, а распределение по горизонтали или вертикали требует достаточного количества фигур для определения интервала. Пересчитайте индексы, если вы изменяете коллекцию перед вызовом метода.

## **Отразить фигуру**

Класс [ShapeFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeframe/) хранит позицию, размер, параметры горизонтального и вертикального отражения и вращение. Его значения [getFlipH](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeframe/#getFlipH) и [getFlipV](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeframe/#getFlipV) используют [NullableBool](https://reference.aspose.com/slides/ru/python-java/aspose.slides/nullablebool/): `True` — включить отражение, `False` — отключить, `NotDefined` — сохранить неуказанное/значение по умолчанию.

Входная презентация ниже содержит одну неотражённую фигуру.

![Фигура до отражения](shape_to_be_flipped.png)

Пример сохраняет все остальные значения кадра и заменяет только два параметра отражения. Это важно, потому что присвоение нового [Frame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setFrame) заменяет весь кадр.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Сохранённая фигура зеркально отражена по горизонтали и вертикали, при этом сохраняются её позиция, размер и вращение.

![Фигура после отражения](flipped_shape.png)

## **FAQ**

**Стоит ли использовать индекс коллекции в качестве идентификатора фигуры?**

Только для короткоживущей обработки, когда коллекция не будет изменена до использования индекса. Предпочтительно использовать проверенный [Name](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getName) или [AlternativeText](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText) согласно конвенции именования для шаблонов, либо [OfficeInteropShapeId](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getOfficeInteropShapeId) для межслайдовой работы через interop.

**Удаляет ли скрытие фигуру из порядка наложения?**

Нет. Скрытая фигура остаётся в коллекции на том же индексе. Её можно находить, переупорядочивать, редактировать или снова сделать видимой.

**Почему клон фигуры появился перед другой фигурой?**

[addClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addClone) добавляет клон в конец коллекции, а конец — передняя часть z‑order. Используйте [insertClone](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#insertClone), чтобы задать начальный индекс, либо [reorder](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#reorder) после добавления всех фигур.

**Можно ли использовать фиксированный индекс для идентификации регулировки предустановленной фигуры?**

Только после полной проверки конкретной предустановки и расположения коллекции. Предпочтительно итерировать [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/geometryshape/#getAdjustments) и проверять [AdjustValue.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType); используйте [AdjustValue.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.