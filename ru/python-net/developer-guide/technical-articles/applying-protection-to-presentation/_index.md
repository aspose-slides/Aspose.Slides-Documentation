---
title: Ограничение редактирования презентаций блокировкой фигур в Python
linktitle: Ограничить редактирование презентации
type: docs
weight: 70
url: /ru/python-net/applying-protection-to-presentation/
keywords:
- предотвратить редактирование
- защитить от редактирования
- заблокировать фигуру
- заблокировать позицию
- заблокировать выбор
- заблокировать изменение размеров
- заблокировать группировку
- PowerPoint
- PPTX
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как блокировать и разблокировать фигуры в презентациях PPTX с помощью Aspose.Slides for Python via .NET, чтобы ограничить выбор, перемещение, изменение размеров и группировку."
---
## **Предыстория**

Распространённое применение Aspose.Slides for Python via .NET — создание, обновление и сохранение презентаций PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Когда пользователи получают такие презентации, ограничение изменений фигур помогает сохранить задуманную компоновку и содержимое.

В этой статье объясняется, как фигурки организованы на слайдах и как применить и удалить блокировки фигур в презентации PPTX. Эти блокировки позволяют ограничить определённые операции редактирования отдельных фигур.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автограммы, таблицы, OLE‑объекты, группированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые при построении презентации. В Aspose.Slides for Python via .NET каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Разные типы фигур предоставляют различные варианты блокировки. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) является базовым классом для блокировок фигур. Aspose.Slides for Python via .NET предоставляет следующие классы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) блокирует автограммы.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) блокирует групповые фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Чтобы применить блокировки ко всей [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), пройдите по её слайдам и установите соответствующие блокировки для каждой поддерживаемой фигуры.

## **Применение и удаление защиты**

Блокировки фигур ограничивают такие операции, как выбор, перемещение и изменение размеров фигур. Они не делают всю презентацию недоступной для редактирования.

### **Применение защиты к объектам PPTX**

Aspose.Slides for Python via .NET предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) , позволяющий работать с фигурами на слайде.

В примере свойства [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) и [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) устанавливаются в `True` для автограмм, с аналогичными блокировками для групповых фигур, соединителей и рамок изображений. Соединители используют [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) для перемещения; группы также используют [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) , чтобы ограничить группировку.

Пример загружает существующую PPTX‑презентацию, проверяет фигуры в коллекции фигур каждого слайда и сохраняет копию с применёнными ограничениями. Фигуры, не относящиеся к четырём поддерживаемым типам, остаются без изменений. Цикл не проходит по вложенным фигурам внутри группы.

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

Чтобы снять блокировку фигуры, установите её значение в `False`. В следующем примере загружается презентация с блокировками фигур и очищаются ограничения выбора, перемещения и изменения размеров через [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) и [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Также очищается [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) и сохраняется копия презентации. Другие настройки блокировок оставляются без изменений.

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

### **Заключение**

Aspose.Slides for Python via .NET позволяет ограничивать конкретные операции редактирования отдельных фигур или применять одинаковые ограничения ко всем слайдам. Выбирайте блокировки, поддерживаемые типом каждой фигуры, и устанавливайте их значения в `False`, когда нужно снять эти ограничения.

## **Часто задаваемые вопросы**

**Можно ли комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки фигур ограничивают конкретные операции редактирования, тогда как [защита паролем](/slides/ru/python-net/password-protected-presentation/) может ограничивать открытие или изменение презентации. Вы можете использовать оба способа в одном файле.

**Можно ли ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Применяйте блокировки только к фигурам на выбранных слайдах. Это не меняет настройки блокировок на остальных слайдах.

**Как применить блокировки к отдельным фигурам внутри группы?**

Пройдите по коллекции [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) группы и примените соответствующие блокировки к каждой дочерней фигуре. Повторите это для любых вложенных групп. Приведённые выше примеры обрабатывают только коллекцию фигур слайда, поэтому они не устанавливают блокировки для отдельных членов группы.