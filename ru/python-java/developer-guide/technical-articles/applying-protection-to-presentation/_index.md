---
title: Ограничить редактирование презентаций с помощью блокировок фигур в Python
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/python-java/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- блокировать фигуру
- блокировать позицию
- блокировать выбор
- блокировать изменение размера
- блокировать группировку
- PowerPoint
- PPTX
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for Python via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Предыстория**

Обычное применение Aspose.Slides for Python via Java — создавать, обновлять и сохранять презентации PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманное расположение и содержание.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеорамки, соединительные линии и другие элементы, используемые при построении презентации. В Aspose.Slides for Python via Java каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/).

Разные типы фигур предоставляют разные варианты блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) является базовым для блокировок фигур. Aspose.Slides for Python via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) блокирует соединительные линии.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) блокирует группы фигур.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), пройдитесь по её слайдам и задайте соответствующие блокировки каждому поддерживаемому типу фигур.

## **Применение и удаление защиты**

Блокировки фигур ограничивают операции, такие как выбор, перемещение и изменение размеров фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for Python via Java предоставляет класс [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) для работы с фигурами на слайде.

В примере вызываются методы [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) со значением `True` для автоконтуров, аналогичные блокировки используются для групп фигур, соединительных линий и рамок изображений. Для соединительных линий используется метод [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; для групп также применяется [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

### **Удалить защиту**

Чтобы снять блокировку с фигуры, установите её значение в `False`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размеров через [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Также снимается ограничение группировки, передавая `False` в [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), после чего сохраняется копия презентации. Другие параметры блокировок остаются без изменений.

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

### **Заключение**

Aspose.Slides for Python via Java позволяет ограничивать конкретные операции редактирования отдельных фигур или применять одинаковые ограничения ко всему набору слайдов. Выбирайте блокировки, поддерживаемые типом каждой фигуры, и устанавливайте их значения в `False`, когда необходимо снять эти ограничения.

## **FAQ**

**Можно ли комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают отдельные операции редактирования, тогда как [password protection](/slides/ru/python-java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Оба метода можно использовать в одном файле.

**Можно ли ограничить редактирование только на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) группы, и примените соответствующие блокировки к каждой дочерней фигуре. Повторите процесс для вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки отдельным элементам группы.