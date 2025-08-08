---
title: Предотвращайте изменение презентаций с помощью блокировки фигур на Python
linktitle: Предотвращение изменений презентации
type: docs
weight: 70
url: /ru/python-net/applying-protection-to-presentation/
keywords:
- предотвращение изменений
- защита от редактирования
- блокировка фигуры
- блокировка положения
- блокировка выделения
- блокировка размера
- блокировка группировки
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Узнайте, как Aspose.Slides for Python via .NET блокирует или разблокирует фигуры в файлах PPT, PPTX и ODP, обеспечивая защиту презентаций и позволяя контролируемое редактирование и более быструю доставку."
---

{{% alert color="primary" %}} 

Обычное использование Aspose.Slides заключается в создании, обновлении и сохранении презентаций Microsoft PowerPoint 2007 (PPTX) в рамках автоматизированного рабочего процесса. Пользователи приложения, использующего Aspose.Slides таким образом, получают доступ к выходным презентациям. Защита их от редактирования является распространенной проблемой. Важно, чтобы автоматически созданные презентации сохраняли свое оригинальное форматирование и содержание.

В этой статье объясняется, как [конструируются презентации и слайды](/slides/ru/python-net/applying-protection-to-presentation/) и как Aspose.Slides для Python через .NET может [применить защиту к](/slides/ru/python-net/applying-protection-to-presentation/), а затем [удалить ее из](/slides/ru/python-net/applying-protection-to-presentation/) презентации. Эта функция уникальна для Aspose.Slides и на момент написания недоступна в Microsoft PowerPoint. Это дает разработчикам возможность контролировать, как используются презентации, создаваемые их приложениями.

{{% /alert %}} 
## **Состав слайда**
Слайд PPTX состоит из ряда компонентов, таких как автофигуры, таблицы, OLE-объекты, сгруппированные фигуры, рамки для изображений, рамки для видео, соединители и различные другие элементы, доступные для создания презентации.

В Aspose.Slides для Python через .NET каждый элемент на слайде превращен в объект Shape. Другими словами, каждый элемент на слайде является либо объектом Shape, либо объектом, производным от объекта Shape.

Структура PPTX сложна, поэтому в отличие от PPT, где можно использовать общий замок для всех типов фигур, существуют разные типы замков для разных типов фигур. Класс BaseShapeLock — это общий класс блокировки PPTX. В Aspose.Slides для Python через .NET поддерживаются следующие типы блокировок для PPTX:

- AutoShapeLock блокирует автофигуры.
- ConnectorLock блокирует соединительные фигуры.
- GraphicalObjectLock блокирует графические объекты.
- GroupshapeLock блокирует групповые фигуры.
- PictureFrameLock блокирует рамки для изображений.

Любое действие, выполняемое над всеми объектами Shape в объекте Presentation, применяется ко всей презентации.
## **Применение и удаление защиты**
Применение защиты обеспечивает невозможность редактирования презентации. Это полезная техника для защиты содержания презентации.
### **Применение защиты к фигурам PPTX**
Aspose.Slides для Python через .NET предоставляет класс Shape для работы с фигурой на слайде.

Как упоминалось ранее, каждому классу фигуры соответствует связанный класс блокировки фигуры для защиты. Эта статья сосредоточена на блокировках NoSelect, NoMove и NoResize. Эти блокировки обеспечивают невозможность выбора фигур (через клики мыши или другие методы выбора), а также их перемещения или изменения размера.

Следующие примеры кода применяют защиту ко всем типам фигур в презентации.

```py
import aspose.slides as slides

#Создание экземпляра класса Presentation, который представляет файл PPTX
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #Объект ISlide для доступа к слайдам в презентации
    slide = pres.slides[0]

    #Перебор всех слайдов в презентации
    for slide in pres.slides:
        for shape in slide.shapes:
            #если фигура является автофигурой
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Применение замков к фигурам
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #если фигура является групповой фигурой
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Применение замков к фигурам
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #если фигура является соединителем
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Применение замков к фигурам
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #если фигура является рамкой для изображения
            elif type(shape) is slides.PictureFrame:
                #Приведение к типу рамки для изображения и получение замка для рамки
                picture_lock = shape.shape_lock

                #Применение замков к фигурам
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Сохранение файла презентации
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Удаление защиты**
Защита, применяемая с помощью Aspose.Slides для Python через .NET, может быть удалена только с помощью Aspose.Slides для Python через .NET. Чтобы разблокировать фигуру, установите значение примененной блокировки в false. Пример кода ниже показывает, как разблокировать фигуры в защищенной презентации.

```py
import aspose.slides as slides

#Открытие нужной презентации
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Применение замков к фигурам
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Применение замков к фигурам
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Применение замков к фигурам
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Применение замков к фигурам
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Сохранение файла презентации
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **Резюме**
{{% alert color="primary" %}} 

Aspose.Slides предоставляет ряд возможностей для применения защиты к фигурам в презентации. Можно заблокировать конкретную фигуру или пройтись по всем фигурам в презентации и заблокировать их все, чтобы эффективно заблокировать презентацию.

Только Aspose.Slides для Python через .NET может удалить защиту из презентации, которую он ранее защитил. Удалите защиту, установив значение блокировки в false.

{{% /alert %}} 