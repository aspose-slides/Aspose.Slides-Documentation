---
title: Ограничить редактирование презентаций с помощью блокировок фигур в Python
linktitle: Ограничить редактирование презентаций
type: docs
weight: 70
url: /ru/python-net/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защита от редактирования
- заблокировать форму
- заблокировать позицию
- заблокировать выбор
- заблокировать изменение размера
- заблокировать группировку
- PowerPoint
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for Python via .NET, чтобы ограничить выбор, перемещение, изменение размера и группировку."
---
## **Предыстория**

Обычное применение Aspose.Slides for Python via .NET — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают эти презентации, ограничение изменений фигур помогает сохранить задуманную компоновку и содержание.

Эта статья объясняет, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить конкретные операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, группированные фигуры, рамки изображений, видеокадры, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Python via .NET каждый элемент на слайде представлен объектом, наследующимся от класса [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Разные типы фигур предоставляют разные варианты блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Python via .NET предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) блокирует группы фигур.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [presentation protection settings](/slides/ru/python-net/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Python via .NET предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) для работы с фигурами на слайде.

В примере свойства [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) и [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) устанавливаются в `True` для автоконтуров, аналогичные блокировки применяются к группам фигур, соединителям и рамкам изображений. Для соединителей используется [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) для перемещения; для групп также применяется [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) для ограничения группировки.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём обрабатываемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Удаление защиты**

Чтобы удалить блокировку фигуры, установите её значение в `False`. Ниже приводится пример, который загружает презентацию с блокировками фигур и снимает ограничения на выбор, перемещение и изменение размера через [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Он также очищает [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) и сохраняет копию презентации. Другие параметры блокировок остаются без изменения.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Сохранить обрезку изображения**

Поместите фотографию с именем `photo.jpg` в рабочий каталог. В примере обрезается 12 % слева и 8 % справа, затем для рамки изображения устанавливается [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/). Этот флаг ограничивает дальнейшую обрезку и сохраняет существующую обрезку.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` хранит блокировку обрезки как `True`. В PowerPoint команда **Crop** отключена, когда выбран фото.

### **Сохранить диаграмму сгруппированной**

Пример группирует прямоугольник и стрелку, затем для самой группы устанавливает [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/), чтобы компоненты диаграммы оставались вместе. Другие правки, такие как перемещение группы или изменение заливки компонента, остаются доступными.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` хранит блокировку разгруппировки как `True`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Отчет о существующих блокировках фигур**

Чтобы просмотреть шаблон, откройте его и прочитайте объект блокировки для каждой фигуры. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) имеет значение `True`, когда все флаги в этом объекте отключены, и `False`, когда включён хотя бы один. У группы и её дочерних элементов есть отдельные объекты блокировок, поэтому проверяйте дочерние элементы, даже если у группы нет блокировок.

В этом примере проверяется перемещение автоконтуров, рамок изображений и групп, обрезка изображений и разгруппировка групп. Пример выводит обнаруженные флаги и отмечает типы фигур, которые он не проверяет.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Предположим, что слайд 1 файла `Sample.pptx` содержит группу с именем `Layout`, у которой включена блокировка разгруппировки, изображение `Photo` внутри группы с блокировкой обрезки и разблокированный прямоугольник `Free`. Отчёт пропускает `Free` и выводит две строки:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Отчёт считывает сохранённые флаги редактирования на уровне фигур без их изменения или сохранения презентации. Защита записи на уровне документа — отдельная настройка, а применение каждого флага зависит от редактора.

### **Заключение**

Aspose.Slides for Python via .NET позволяет ограничить конкретные операции редактирования отдельных фигур или применить одинаковые ограничения ко всем слайдам. Выбирайте поддерживаемые каждой фигурой блокировки и устанавливайте их значения в `False`, когда необходимо снять ограничения.

## **Вопросы и ответы**

**Могу ли я комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, в то время как [password protection](/slides/ru/python-net/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать обе возможности в одном файле.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на других слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Итерируйте коллекцию [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) группы и применяйте соответствующие блокировки к каждой дочерней фигуре. Повторяйте процесс для любых вложенных групп, следуя обходу, показанному в примере отчёта.