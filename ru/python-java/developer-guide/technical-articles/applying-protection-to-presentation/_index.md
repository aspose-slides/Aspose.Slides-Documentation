---
title: Ограни��ить редактирование презентации с помощью блокировок фигур в Python
linktitle: Ограничить редактирование презентации
type: docs
weight: 60
url: /ru/python-java/applying-protection-to-presentation/
keywords:
- запретить редактирование
- защитить от редактирования
- заблокировать фигуру
- заблокировать положение
- заблокировать выбор
- заблокировать изменение размера
- заблокировать группировку
- PowerPoint
- PPTX
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX презентациях с помощью Aspose.Slides for Python via Java, чтобы ограничить выбор, перемещение, изменение размеров и группировку."
---
## **Фон**

Обычное применение Aspose.Slides for Python via Java — создавать, обновлять и сохранять презентации PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманный макет и содержимое.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить конкретные операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоматические формы, таблицы, объекты OLE, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Python via Java каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Разные типы фигур предоставляют разные варианты блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Python via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) блокирует группы фигур.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), пройдитесь по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [настройками защиты презентации](/slides/ru/python-java/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Python via Java предоставляет класс [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `True` для автоконтуров, а также эквивалентные блокировки для групп фигур, соединителей и рамок изображений. Для соединителей используется [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; для групп — также [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не входящие в четыре обрабатываемых типа, остаются без изменений. Цикл не обходит дочерние фигуры внутри группы.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Удаление защиты**

Чтобы удалить блокировку фигуры, установите её значение в `False`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размеров через [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Кроме того, ограничение группировки удаляется передачей `False` в [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), после чего сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Сохранить обрезку изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. Пример обрезает 12 % слева и 8 % справа, затем вызывает [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) со значением `True`, чтобы сохранить обрезку.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

В файле `PictureLocked.pptx` PowerPoint отключает команду **Crop**, когда вы выбираете изображение.

### **Сохранить группировку диаграммы**

Пример группирует прямоугольник и стрелку, затем вызывает [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) со значением `True`, чтобы удержать две фигуры вместе. По‑прежнему можно перемещать группу или менять заливку компонента.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

В файле `DiagramLocked.pptx` PowerPoint отключает команду **Ungroup**, когда вы выбираете всю диаграмму.

### **Заключение**

Aspose.Slides for Python via Java позволяет ограничивать конкретные операции редактирования отдельных фигур или применять одинаковые ограничения к нескольким слайдам. Выбирайте блокировки, поддерживаемые каждым типом фигур, и устанавливайте их значения в `False`, когда необходимо снять ограничения.

## **Вопросы и ответы**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, тогда как [защита паролем](/slides/ru/python-java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба механизма в одном файле.

**Могу ли я ограничить редактирование только на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет параметры блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом группы [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes), и примените соответствующие блокировки к каждой дочерней фигуре. Повторите эту процедуру для всех вложенных групп. В приведённых выше примерах обрабатывается только коллекция фигур слайда, поэтому блокировки на отдельные элементы группы не устанавливаются.