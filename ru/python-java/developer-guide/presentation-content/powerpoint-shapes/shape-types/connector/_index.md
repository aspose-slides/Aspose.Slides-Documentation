---
title: Управление коннекторами в презентациях на Python через Java
linktitle: Коннектор
type: docs
weight: 10
url: /ru/python-java/connector/
keywords:
- коннектор
- тип коннектора
- точка коннектора
- линия коннектора
- угол коннектора
- точка соединения
- точка регулировки
- соединение фигур
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как добавлять, прикреплять, перенаправлять, регулировать и исследовать прямые, согнутые и изогнутые коннекторы PowerPoint с помощью Aspose.Slides для Python через Java."
---
## **Обзор**

Коннектор — это линия, которая может оставаться присоединённой к двум фигурам, когда одна из фигур перемещается. Его концы присоединяются к точкам соединения, представленным зелёными точками в PowerPoint. Некоторые согнутые и изогнутые коннекторы также имеют точки регулировки, представленные оранжевыми точками, которые управляют положением отдельных сегментов коннектора.

Aspose.Slides представляет коннекторы через класс [Connector](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/). Вы можете создавать их, присоединять их концы к фигурам, выбирать точки соединения, перенаправлять их и изменять геометрию коннекторов, которые имеют точки регулировки.

## **Типы коннекторов**

Класс [ShapeType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/) включает предустановки прямых, согнутых и изогнутых коннекторов. В таблице ниже показаны доступные геометрии коннекторов и количество точек регулировки, определённых для каждой предустановки.

| Коннектор | Изображение | Количество точек регулировки |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

Количество и значение точек регулировки являются частью выбранной предустановки коннектора. Не следует полагать, что два разных типа коннекторов раскрывают одинаковый порядок коллекции.

## **Соединить две фигуры**

Используйте [ShapeCollection.addConnector](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addConnector) для добавления коннектора, а также [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#setStartShapeConnectedTo) и [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#setEndShapeConnectedTo) для присоединения его концов. После присоединения обоих концов [Connector.reroute](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#reroute) выбирает короткий путь между фигурами.

В следующем примере эллипс соединяется с прямоугольником с помощью согнутого коннектора:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Внимание" %}}
Вызов [reroute](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#reroute) может изменить значения [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#setStartShapeConnectionSiteIndex) и [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connector/#setEndShapeConnectionSiteIndex). Присвойте конкретные точки соединения после перенаправления, если эти точки должны оставаться фиксированными.
{{% /alert %}}

## **Выбрать точку соединения**

Каждая фигурка, к которой можно подключаться, сообщает количество точек через [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getConnectionSiteCount). Проверьте предпочтительный нулевой индекс точки перед тем, как присвоить его концу коннектора; количество точек варьируется в зависимости от геометрии фигуры.

В этом примере коннектор присоединяется к определённой точке на эллипсе, если такая точка существует:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Регулировать точку коннектора**

Коннекторы с точками регулировки предоставляют их через [GeometryShape.getAdjustments](https://reference.aspose.com/slides/ru/python-java/aspose.slides/geometryshape/#getAdjustments). Проверьте каждое значение [AdjustValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/) и его [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType) перед изменением с помощью [setRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#setRawValue). Общие правила идентификации предустановленных регулировок фигур описаны в разделе [Shape Manipulation](/slides/ru/python-java/shape-manipulations/).

Количество, порядок, значение и допустимый диапазон значений регулировок коннектора зависят от предустановки коннектора. Тип регулировки только для чтения, тогда как значение регулировки можно изменять. Метод только для чтения [getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) предоставляет дополнительную идентификацию, когда коннектор содержит более одной регулировки одного и того же семантического типа.

### **Обойти препятствие**

На следующей схеме коннектор [BentConnector5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector5), соединяющий две фигуры, проходит через третью фигуру:

![connector-obstruction](connector-obstruction.png)

Этот код создаёт препятствующий коннектор:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Перемещение вертикального изгиба изменяет маршрут, так что коннектор обходил препятствие:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

Вместо того чтобы предполагать, что индекс коллекции `1` всегда представляет вертикальный изгиб, этот пример ищет [ConnectorBendPositionY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY) и изменяет его только когда ожидаемый семантический тип присутствует:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

У [BentConnector5](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector5) два регулировочных параметра [ConnectorBendPositionX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionX) и один параметр [ConnectorBendPositionY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#ConnectorBendPositionY). Если требуемый тип встречается более одного раза, проверьте [getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) и известную геометрию этой предустановки перед выбором. Если регулировка возвращает [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapeadjustmenttype/#Custom), рассматривайте её значение и диапазон как специфичные для предустановки и не меняйте её, пока не станет известен соответствующий контракт.

## **Связать значения регулировок с геометрией коннектора**

Для согнутых коннекторов значения регулировок могут использоваться для оценки позиций отдельных сегментов. Эти расчёты специфичны для предустановки коннектора:

- [BentConnector4](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector4) обычно предоставляет одну регулировку [ConnectorBendPositionX] и одну [ConnectorBendPositionY].
- Для этих позиций изгиба деление значения, возвращаемого [getRawValue](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getRawValue) на `100000.0` дает долю ширины или высоты кадра коннектора, как используется в примерах ниже.
- Кадр коннектора может быть повернут или отражён, поэтому координаты кадра необходимо преобразовать перед сравнением с координатами слайда.

В следующих примерах сначала используется [getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType) для определения регулировок. Они не рассматривают индексы коллекции как переносимые идентификаторы.

### **Не повернутый коннектор**

Исходная схема содержит две текстовые фигуры, соединённые [BentConnector4](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapetype/#BentConnector4):

![connector-shape-complex](connector-shape-complex.png)

Этот пример проверяет коннектор и получает его горизонтальные и вертикальные регулировки изгиба:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

Чтобы изменить оба изгиба, найдите каждый ожидаемый тип и измените значения только после того, как оба будут найдены:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Результат — коннектор, у которого горизонтальные и вертикальные сегменты сместились:

![connector-adjusted-1](connector-adjusted-1.png)

После определения семантических типов их значения можно преобразовать в координаты кадра коннектора. Этот пример рисует тонкий прямоугольник над вертикальным сегментом, контролируемым двумя регулировками изгиба:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Контурная фигура отмечает рассчитанный сегмент:

![connector-adjusted-2](connector-adjusted-2.png)

### **Повернутый или отражённый коннектор**

Когда та же геометрия коннектора ориентирована вертикально, её значения [Shape.getFrame], [ShapeFrame.getFlipH] и [ShapeFrame.getFlipV] влияют на преобразование координат кадра коннектора в координаты слайда.

В этом примере создаётся и регулируется вертикально ориентированный коннектор:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Отрегулированный коннектор появляется вертикально между фигурами:

![connector-adjusted-3](connector-adjusted-3.png)

Для произвольного угла поворота `alpha` вращайте точку кадра коннектора `(x, y)` вокруг центра кадра `(x0, y0)`:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

Следующий код обрабатывает 90‑градусную ориентацию, использованную в этом примере, и рисует красную направляющую над соответствующим сегментом коннектора:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Красная направляющая отмечает рассчитанный сегмент после преобразования координат:

![connector-adjusted-4](connector-adjusted-4.png)

Эти формулы описывают предустановки, использованные в примерах, а не универсальную модель коннектора. Проверьте типы регулировок, ориентацию кадра и диапазоны значений перед применением того же расчёта к другой предустановке.

## **Find a Connector Direction Angle**

Направление прямого коннектора можно вычислить по его ширине и высоте, учитывая горизонтальные и вертикальные отражения. В следующем примере выводится угол по часовой стрелке от положительной горизонтальной оси в координатах слайда:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**Как узнать, может ли коннектор присоединяться к фигуре?**

Проверьте значение [getConnectionSiteCount](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getConnectionSiteCount) у фигуры. Положительное количество означает, что у фигуры есть точки соединения. Проверьте выбранный индекс точки перед тем, как присвоить его концу коннектора.

**Могу ли я идентифицировать регулировку коннектора по её индексу в коллекции?**

Индекс имеет смысл только для известной предустановки коннектора и структуры коллекции. Перед изменением значения проверьте [AdjustValue.getType](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getType) и используйте [AdjustValue.getName](https://reference.aspose.com/slides/ru/python-java/aspose.slides/adjustvalue/#getName) как дополнительную информацию, когда один и тот же семантический тип встречается более одного раза.

**Что происходит, когда подключённая фигура удаляется?**

Соответствующий конец коннектора открепляется. Коннектор остаётся на слайде и может быть удалён, превратиться в свободную линию или присоединён к другой фигуре.

**Сохраняются ли привязки коннектора при копировании слайда?**

Привязки обычно сохраняются при копировании фигур вместе со слайдом. Если коннектор копируется без одной из целевых фигур, соответствующий конец необходимо снова присоединить.