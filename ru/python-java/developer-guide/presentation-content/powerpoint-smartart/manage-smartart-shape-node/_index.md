---
title: Управление узлами фигур SmartArt в презентациях с помощью Python
linktitle: Узел фигуры SmartArt
type: docs
weight: 30
url: /ru/python-java/manage-smartart-shape-node/
keywords:
- Узел SmartArt
- Дочерний узел
- Добавить узел
- Позиция узла
- Доступ к узлу
- Удалить узел
- Пользовательская позиция
- Вспомогательный узел
- Формат заливки
- Отрисовка узла
- PowerPoint
- презентация
- Python
- Aspose.Slides
description: "Управляйте узлами фигур SmartArt в PPT и PPTX с помощью Aspose.Slides for Python via Java. Получите понятные примеры кода и советы по оптимизации ваших презентаций."
---
## **Обзор**

Графика SmartArt в презентациях PowerPoint организована с помощью узлов, содержащих текст и определяющих структуру диаграммы. Aspose.Slides позволяет программно работать с этими узлами SmartArt: добавлять новые узлы и дочерние узлы, вставлять дочерние узлы в определённую позицию, получать доступ к существующим узлам и считывать их текст, уровень и позицию.

В этой статье описывается, как управлять узлами фигур SmartArt. Показано, как удалять узлы, работать с дочерними узлами по индексу или позиции, преобразовывать вспомогательный узел в обычный, менять позицию, размер и вращение фигур узлов SmartArt, задавать форматы заливки узлов и генерировать изображение‑миниатюру для дочернего узла SmartArt.

## **Добавление узла SmartArt**
Aspose.Slides for Python via Java предоставляет API для управления фигурами SmartArt. В следующем примере добавляется узел и дочерний узел к фигуре SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. [Add a new node](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#addNode) к [node collection](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getAllNodes) фигуры SmartArt и задайте её текст через [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).  
1. [Add](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#addNode) [child node](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#getChildNodes) к новому узлу и задайте его текст через [TextFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/textframe/).  
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Добавление узла SmartArt в определённой позиции**
В следующем примере добавляется дочерний узел в определённую позицию узла SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).  
1. Получите первый слайд по его индексу.  
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/) с макетом [StackedList](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/#StackedList) на слайд.  
1. Получите первый узел добавленной фигуры SmartArt.  
1. Добавьте дочерний узел к выбранному узлу на позицию 2 с помощью [addNodeByPosition](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) и задайте его текст.  
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Доступ к узлу SmartArt**
В следующем примере осуществляется доступ к узлам фигуры SmartArt. Макет, возвращаемый [getLayout](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getLayout), только для чтения и задаётся при добавлении фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. Пройдите по всем [nodes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getAllNodes) в фигуре SmartArt.  
1. Считайте и отобразите позицию, уровень и текст каждого узла SmartArt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **Доступ к дочернему узлу SmartArt**
В следующем примере осуществляется доступ к дочерним узлам каждого узла в фигуре SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. Пройдите по всем [nodes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/#getAllNodes) в фигуре SmartArt.  
1. Для каждого узла пройдите по его [child nodes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#getChildNodes).  
1. Считайте и отобразите позицию, уровень и текст [child node](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **Доступ к дочернему узлу SmartArt в определённой позиции**
В следующем примере осуществляется доступ к дочернему узлу по определённому индексу в коллекции узлов его родителя.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).  
1. Получите первый слайд по его индексу.  
1. Добавьте фигуру SmartArt с макетом [StackedList](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/#StackedList).  
1. Получите добавленную фигуру SmartArt.  
1. Получите узел с индексом 0 в фигуре SmartArt.  
1. Получите дочерний узел с индексом 1 с помощью [get_Item](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#get_Item).  
1. Считайте и отобразите позицию, уровень и текст [child node](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#getChildNodes).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **Удаление узла SmartArt**
В следующем примере удаляется узел из фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. Убедитесь, что фигура [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/) содержит хотя бы один узел.  
1. Выберите узел SmartArt, подлежащий удалению.  
1. Удалите выбранный узел с помощью [removeNode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Удаление узла SmartArt из определённой позиции**
В следующем примере удаляется дочерний узел по определённому индексу в коллекции узлов фигуры SmartArt.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. При наличии доступа получите узел SmartArt с индексом 0.  
1. Убедитесь, что выбранный узел SmartArt имеет как минимум два дочерних узла.  
1. Удалите дочерний узел с индексом 1 с помощью [removeNode](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnodecollection/#removeNode).  
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Установка пользовательской позиции для дочернего узла в объекте SmartArt**
Aspose.Slides for Python via Java поддерживает задание позиции [SmartArtShape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartshape/) с помощью [setX](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setX) и [setY](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#setY). В следующем примере задаются пользовательская позиция, размер и вращение фигур узлов SmartArt. Добавление новых узлов пересчитывает позиции и размеры всех узлов. Пользовательское позиционирование позволяет размещать узлы согласно требованиям.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Проверка вспомогательного узла**
{{% alert color="info" title="Note" %}} 

В этом разделе рассматриваются фигуры SmartArt, добавляемые в слайды презентации программно с помощью Aspose.Slides for Python via Java.

{{% /alert %}} 

В примере используется следующая исходная фигура SmartArt.

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**Рисунок: Исходная фигура SmartArt на слайде**|

В следующем примере идентифицируются вспомогательные узлы в коллекции узлов SmartArt и преобразуются в обычные узлы.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/) и загрузите презентацию, содержащую фигуру SmartArt.  
1. Получите первый слайд по его индексу.  
1. Пройдите по всем фигурам на первом слайде.  
1. Проверьте, является ли фигура экземпляром [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/).  
1. Пройдите по всем узлам в фигуре SmartArt и проверьте, являются ли они [Assistant Nodes](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartnode/#isAssistant).  
1. Преобразуйте каждый вспомогательный узел в обычный.  
1. Сохраните презентацию.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Рисунок: Вспомогательные узлы, преобразованные в обычные, в фигуре SmartArt на слайде**|

## **Задание формата заливки узла**
Aspose.Slides for Python via Java позволяет добавлять пользовательские фигуры SmartArt и задавать их формат заливки. В этой статье объясняется, как создавать и получать доступ к фигурам SmartArt и задавать их формат заливки с помощью Aspose.Slides for Python via Java.

Выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).  
1. Получите слайд по его индексу.  
1. Добавьте фигуру [SmartArt](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartart/) с макетом [ClosedChevronProcess](https://reference.aspose.com/slides/ru/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess).  
1. Задайте [FillFormat](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getFillFormat) для узлов фигуры SmartArt.  
1. Запишите изменённую презентацию в файл PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Создание миниатюры дочернего узла SmartArt**
Чтобы создать миниатюру дочернего узла SmartArt, выполните следующие действия:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/).  
1. [Add a SmartArt shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shapecollection/#addSmartArt).  
1. Получите узел по его индексу.  
1. Получите изображение‑миниатюру.  
1. Сохраните изображение‑миниатюру в любом требуемом формате изображения.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Поддерживается ли анимация SmartArt?**

Да. SmartArt рассматривается как обычная фигура, поэтому вы можете [применять стандартные анимации](/slides/ru/python-java/shape-animation/) (вход, выход, акцент, траектории движения) и настраивать время. При необходимости можно анимировать фигуры внутри узлов SmartArt.

**Как надёжно найти конкретный SmartArt на слайде, если его внутренний идентификатор неизвестен?**

Назначьте и ищите по [alternative text](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getAlternativeText). Установка отличающегося альтернативного текста для SmartArt позволяет находить её программно без использования внутренних идентификаторов.

**Сохранится ли внешний вид SmartArt при конвертации презентации в PDF?**

Да. Aspose.Slides рендерит SmartArt с высокой визуальной точностью во время [PDF export](/slides/ru/python-java/convert-powerpoint-to-pdf/), сохраняя макет, цвета и эффекты.

**Можно ли извлечь изображение всего SmartArt (для превью или отчётов)?**

Да. Вы можете экспортировать фигуру SmartArt в [растровые форматы](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#getImage) или в [SVG](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/#writeAsSvgToBytes) для масштабируемого векторного вывода, что подходит для миниатюр, отчетов или веб‑использования.