---
title: Ограничение редактирования презентации с помощью блокировок фигур в Python
linktitle: Ограничить редактирование презентации
type: docs
weight: 70
url: /ru/python-net/applying-protection-to-presentation/
keywords:
- запретить правки
- защитить от редактирования
- заблокировать фигуру
- заблокировать позицию
- заблокировать выбор
- заблокировать изменение размера
- заблокировать группировку
- PowerPoint
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в PPTX‑презентациях с помощью Aspose.Slides for Python via .NET, чтобы ограничить выбор, перемещение, изменение размера и групировку."
---
## **Общее**

Распространённое применение Aspose.Slides for Python via .NET — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур может помочь сохранить задуманный макет и содержание.

В этой статье объясняется, как фигуры организованы на слайдах и как применять и удалять блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автофигуры, таблицы, OLE‑объекты, группированные фигуры, рамки изображений, видеокадры, соединители и другие элементы, используемые для создания презентации. В Aspose.Slides for Python via .NET каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Разные типы фигур предоставляют различные варианты блокировки. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Python via .NET предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) блокирует автофигуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) блокирует фигуры‑соединители.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) блокирует групповые фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Совместимые редакторы презентаций используют блокировки фигур для ограничения отдельных операций редактирования. Шифрование файлов и защита записи на уровне документа являются отдельными [настройки защиты презентации](/slides/ru/python-net/password-protected-presentation/).

### **Применение защиты к фигурам PPTX**

Aspose.Slides for Python via .NET предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) для работы с фигурами на слайде.

В примере для автофигур устанавливается [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) и [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) в `True`, аналогичные блокировки для групповых фигур, соединителей и рамок изображений. Соединители используют [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) для перемещения; группы также используют [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) для ограничения объединения.

В примере загружается существующая PPTX‑презентация, проверяются фигуры в коллекции фигур каждого слайда и сохраняется копия с применёнными ограничениями. Фигуры, не относящиеся к четырём рассматриваемым типам, остаются без изменений. Цикл не проходит по дочерним фигурам внутри группы.

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

Чтобы удалить блокировку фигуры, установите её значение в `False`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размера через [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Также очищается [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) и сохраняется копия презентации. Другие настройки блокировок остаются без изменений.

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

### **Сохранение обрезки изображения**

Поместите фото с именем `photo.jpg` в рабочий каталог. В примере обрезается 12 % слева и 8 % справа, после чего для рамки изображения устанавливается [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) для сохранения обрезки.

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

`PictureLocked.pptx` сохраняет блокировку обрезки как `True`. В PowerPoint команда **Crop** отключена, когда выбран фото.

### **Сохранение диаграммы в группе**

В примере прямоугольник и стрелка объединяются в группу, после чего для самой группы устанавливается [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) , чтобы компоненты диаграммы оставались вместе. Другие правки, такие как перемещение группы или изменение заливки компонента, остаются доступными.

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

`DiagramLocked.pptx` сохраняет блокировку разгруппировки как `True`. В PowerPoint команда **Ungroup** отключена, когда выбрана вся диаграмма.

### **Заключение**

Aspose.Slides for Python via .NET позволяет ограничивать определённые операции редактирования отдельных фигур или применять одинаковые ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые типом каждой фигуры, и устанавливайте их значения в `False`, когда необходимо снять эти ограничения.

## **Часто задаваемые вопросы**

**Можно ли сочетать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают определённые операции редактирования, в то время как [защита паролем](/slides/ru/python-net/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба средства в одном файле.

**Можно ли ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдитесь по коллекции [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) группы и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для всех вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки отдельным членам группы.