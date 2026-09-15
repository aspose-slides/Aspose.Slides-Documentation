---
title: Запретить редактирование презентации с помощью блокировки фигур
linktitle: Запретить редактирование презентации
type: docs
weight: 60
url: /ru/python-java/applying-protection-to-presentation/
keywords:
- предотвращать редактирование
- защита от редактирования
- блокировать форму
- блокировать позицию
- блокировать выбор
- блокировать размер
- блокировать группировку
- PowerPoint
- OpenDocument
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via Java блокирует или разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая защиту презентаций при разрешённом контролируемом редактировании и более быстрой доставке."
---
## **Обзор**

Распространённое применение Aspose.Slides — создание, обновление и сохранение презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, имеют доступ к сгенерированным презентациям, поэтому защита их от редактирования является важным вопросом. Важно, чтобы автоматически созданные презентации сохраняли своё исходное форматирование и содержимое.

В этой статье объясняется, как структурированы презентации и слайды, а также как Aspose.Slides for Python via Java может применять защиту к презентации и впоследствии её удалять. Она предоставляет разработчикам возможность контролировать использование презентаций, генерируемых их приложениями.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, объекты OLE, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Python via Java каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/).

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать общий замок для всех типов фигур, разные типы фигур требуют разных замков. Класс [BaseShapeLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/baseshapelock/) является универсальным классом блокировки для PPTX. Следующие типы замков поддерживаются в Aspose.Slides for Python via Java для PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/connectorlock/) блокирует соединительные фигуры.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/groupshapelock/) блокирует сгруппированные фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/ru/python-java/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Любое действие, выполненное над всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/ru/python-java/aspose.slides/presentation/), применяется ко всей презентации.

## **Применение и удаление защиты**

Применение защиты гарантирует, что презентацию нельзя отредактировать. Это полезный метод защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for Python via Java предоставляет класс [Shape](https://reference.aspose.com/slides/ru/python-java/aspose.slides/shape/) для работы с фигурами на слайде.

Как упоминалось ранее, каждый класс фигуры имеет соответствующий класс блокировки фигуры для защиты. В этой статье рассматриваются блокировки NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что фигуры нельзя выбрать (через щелчки мышью или другими способами выбора) и что их нельзя перемещать или изменять их размер.

Приведённый ниже пример кода применяет защиту ко всем типам фигур в презентации.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Создайте экземпляр класса Presentation, который представляет файл PPTX.
presentation = Presentation("Sample.pptx")
try:
    # Пройдите по всем слайдам в презентации.
    for slide in presentation.getSlides():
        # Пройдите по всем фигурам на слайде.
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

    # Save the presentation file.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Удалить защиту**

Чтобы разблокировать фигуру, установите значение применённой блокировки в `False`. Ниже приведён пример кода, показывающий, как разблокировать фигуры в защищённой презентации.

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Создайте экземпляр класса Presentation, который представляет файл PPTX.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Пройдите по всем слайдам в презентации.
    for slide in presentation.getSlides():
        # Пройдите по всем фигурам на слайде.
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

    # Сохраните файл презентации.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Заключение**

Aspose.Slides предоставляет несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, эффективно защищая весь файл. Защиту можно снять, установив значение блокировки в `False`.

## **FAQ**

**Можно ли комбинировать блокировки фигур и парольную защиту в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, в то время как [password protection](/slides/ru/python-java/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Можно ли ограничить редактирование на конкретных слайдах, не затрагивая другие?**

Да. Примените блокировки к фигурам на выбранных слайдах; остальные слайды останутся редактируемыми.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Для групп, соединителей, графических объектов и других типов фигур поддерживаются специальные типы блокировок.