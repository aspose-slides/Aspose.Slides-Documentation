---
title: Предотвращение редактирования презентации с помощью блокировок фигур в Python
linktitle: Предотвращение редактирования презентации
type: docs
weight: 70
url: /ru/python-net/applying-protection-to-presentation/
keywords:
- предотвращение редактирования
- защита от редактирования
- блокировка фигуры
- блокировка положения
- блокировка выбора
- блокировка размера
- блокировка группировки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via .NET блокирует или разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая безопасность презентаций при сохранении возможности контролируемого редактирования и ускоряя поставку."
---

## **Общие сведения**

Распространённое применение Aspose.Slides — создание, обновление и сохранение презентаций Microsoft PowerPoint (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложений, использующих Aspose.Slides таким образом, получают доступ к сгенерированным презентациям, поэтому защита их от редактирования является актуальной задачей. Важно, чтобы автоматически создаваемые презентации сохраняли своё исходное форматирование и содержание.

В этой статье объясняется, как построены презентации и слайды, а также как Aspose.Slides for Python может применить защиту к презентации и впоследствии её снять. Она предоставляет разработчикам возможность управлять тем, как используются презентации, генерируемые их приложениями.

## **Состав слайда**

Слайд презентации состоит из компонентов, таких как автоконтуры, таблицы, OLE‑объекты, сгруппированные фигуры, рамки изображений, видеорамки, соединители и другие элементы, используемые для построения презентации. В Aspose.Slides for Python каждый элемент на слайде представлен объектом, наследующим класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Структура PPTX сложна, поэтому, в отличие от PPT, где можно использовать общую блокировку для всех типов фигур, различные типы фигур требуют разных блокировок. Класс [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) является универсальным классом блокировки для PPTX. В Aspose.Slides for Python для PPTX поддерживаются следующие типы блокировок:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) блокирует автоконтуры.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) блокирует формы‑соединители.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) блокирует графические объекты.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) блокирует сгруппированные фигуры.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) блокирует рамки изображений.  

Любое действие, выполненное над всеми объектами фигур в объекте [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) применяется ко всей презентации.

## **Применение и удаление защиты**

Применение защиты гарантирует, что презентацию нельзя редактировать. Это полезная техника для защиты содержимого презентации.

### **Применить защиту к фигурам PPTX**

Aspose.Slides for Python предоставляет класс [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) для работы с фигурами на слайде.

Как упоминалось ранее, каждый класс фигуры имеет сопутствующий класс блокировки фигуры для защиты. В данной статье рассматриваются блокировки NoSelect, NoMove и NoResize. Эти блокировки гарантируют, что фигуры нельзя выбрать (щелчками мыши или другими методами) и что их нельзя перемещать или изменять их размер.

Пример кода ниже применяет защиту ко всем типам фигур в презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("Sample.pptx") as presentation:
    # Перебор всех слайдов в презентации.
    for slide in presentation.slides:
        # Перебор всех фигур на слайде.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Сохранение файла презентации.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Удалить защиту**

Чтобы разблокировать фигуру, установите значение соответствующей блокировки в `False`. Ниже показан пример кода, снимающего блокировки в защищённой презентации.

```py
import aspose.slides as slides

# Создать экземпляр класса Presentation, представляющего файл PPTX.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Перебор всех слайдов в презентации.
    for slide in presentation.slides:
        # Перебор всех фигур на слайде.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Сохранение файла презентации.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Заключение**

Aspose.Slides предоставляет несколько вариантов защиты фигур в презентации. Вы можете заблокировать отдельную фигуру или пройтись по всем фигурам в презентации и заблокировать каждую, эффективно обеспечивая безопасность всего файла. Защиту можно снять, установив значение блокировки в `False`.

## **Часто задаваемые вопросы**

**Можно ли комбинировать блокировки фигур и защиту паролем в одной презентации?**

Да. Блокировки ограничивают редактирование объектов внутри файла, тогда как [защита паролем](/slides/ru/python-net/password-protected-presentation/) контролирует доступ к открытию и/или сохранению изменений. Эти механизмы дополняют друг друга и работают совместно.

**Могу ли я ограничить редактирование на отдельных слайдах, не затрагивая остальные?**

Да. Примените блокировки к фигурам на выбранных слайдах; остальные слайды останутся доступными для редактирования.

**Применяются ли блокировки фигур к сгруппированным объектам и соединителям?**

Да. Для групп, соединителей, графических объектов и других типов фигур поддерживаются отдельные типы блокировок.