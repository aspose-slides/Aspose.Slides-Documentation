---
title: Ограничить редактирование презентаций с помощью блокировок форм в Python
linktitle: Ограничить редактирование презентаций
type: docs
weight: 60
url: /ru/python-java/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- блокировать форму
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
description: "Узнайте, как блокировать и разблокировать формы в PPTX‑презентациях с помощью Aspose.Slides for Python via Java, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Предыстория**

Распространённое применение Aspose.Slides for Python via Java — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают эти презентации, ограничение изменений форм позволяет сохранить задуманную макет и содержимое.

В этой статье объясняется, как формы организованы на слайдах и как применять и удалять блокировки форм в презентации PPTX. Эти блокировки позволяют ограничить конкретные операции редактирования отдельных форм.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, OLE‑объекты, сгруппированные формы, рамки изображений, видеокадры, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Python via Java каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Разные типы форм предоставляют различные варианты блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) является базовым классом для блокировок форм. Aspose.Slides for Python via Java предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) блокирует автофигуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) блокирует формы‑соединители.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) блокирует сгруппированные формы.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки к всей [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), пройдитесь по её слайдам и установите соответствующие блокировки для каждой поддерживаемой формы.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки форм для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [настройками защиты презентации](/slides/ru/python-java/password-protected-presentation/).

### **Применение защиты к формам PPTX**

Aspose.Slides for Python via Java предоставляет класс [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) для работы с формами на слайде.

В примере вызываются [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) и [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) с `True` для автоформ, с эквивалентными блокировками для сгруппированных форм, соединителей и рамок изображений. Соединители используют [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) для перемещения; группы также используют [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет формы в коллекции форм каждого слайда и сохраняет копию с применёнными ограничениями. Формы, не относящиеся к четырём рассматриваемым типам, остаются без изменений. Цикл не проходит по дочерним формам внутри группы.

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

Чтобы удалить блокировку формы, установите её значение в `False`. В следующем примере загружается презентация с блокировками форм и очищаются ограничения выбора, перемещения и изменения размера через [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Также удаляется ограничение группировки, передавая `False` в [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked), и сохраняется копия презентации. Другие настройки блокировок остаются без изменений.

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

### **Сохранение обрезки изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. В примере выполняется обрезка 12 % слева и 8 % справа, затем вызывается [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) с `True` для сохранения обрезки.

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

В файле `PictureLocked.pptx` PowerPoint отключает команду **Crop**, когда вы выбираете фотографию.

### **Сохранять диаграмму сгруппированной**

В примере прямоугольник и стрелка объединяются в группу, затем вызывается [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) с `True`, чтобы сохранить две формы вместе. Вы всё ещё можете перемещать группу или менять заливку компонента.

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

### **Отчёт о существующих блокировках форм**

Чтобы просмотреть шаблон, откройте его и прочитайте объект блокировки для каждой формы. Метод [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) возвращает `True`, когда все флаги в этом объекте отключены, и `False`, когда включён хотя бы один. У группы и её дочерних элементов отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение автоформ, рамок изображений и групп. Также проверяется обрезка изображений и разгруппировка для групп. Отчёт перечисляет включённые флаги, которые он распознаёт, и отмечает типы форм, которые он не проверяет.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Предположим, что слайд 1 файла `Sample.pptx` содержит группу с именем `Layout`, у которой заблокирована разгруппировка, изображение с именем `Photo` внутри неё с заблокированной обрезкой и разблокированный прямоугольник с именем `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Отчёт читает сохранённые флаги редактирования на уровне формы без их изменения или сохранения презентации. Защита записи на уровне документа — отдельная настройка, а применение каждого флага зависит от редактора.

### **Заключение**

Aspose.Slides for Python via Java позволяет ограничивать конкретные операции редактирования отдельных форм или применять те же ограничения к нескольким слайдам. Выбирайте блокировки, поддерживаемые каждым типом формы, и устанавливайте их значения в `False`, когда необходимо снять ограничения.

## **FAQ**

**Можно ли комбинировать блокировки форм и защиту паролем в одной презентации?**

Да. Блокировки форм ограничивают конкретные операции редактирования, в то время как [защита паролем](/slides/ru/python-java/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба метода в одном файле.

**Можно ли ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к формам на выбранных слайдах. Это не изменит настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным формам внутри группы?**

Пройдитесь по коллекции, возвращаемой методом [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) группы, и примените соответствующие блокировки к каждой дочерней форме. Повторите это для всех вложенных групп, следуя обходу, показанному в примере отчёта.