---
title: Проблема предварительного просмотра объекта при добавлении OleObjectFrame
linktitle: Проблема OLE-объекта
type: docs
weight: 10
url: /ru/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- объект изменён
- просмотр объекта
- презентация
- PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, почему при добавлении OleObjectFrame в Aspose.Slides для Python появляется сообщение EMBEDDED OLE OBJECT и как решить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides для Python через .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, на выходном слайде отображается сообщение "EMBEDDED OLE OBJECT". Это сообщение намеренно и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE-объектами см. [Manage OLE](/slides/ru/python-net/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides отображает сообщение "EMBEDDED OLE OBJECT", чтобы уведомить вас, что OLE-объект был изменён и изображение предварительного просмотра необходимо обновить. 

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд (подробности см. в статье "Manage OLE") и затем открываете презентацию в Microsoft PowerPoint, вы увидите это изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE-объект был добавлен на слайд, необходимо дважды щёлкнуть по сообщению "EMBEDDED OLE OBJECT", либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint затем открывает встроенный OLE-объект.

![OLE object data](OLE_object_data.png)

Слайд может сохранять сообщение "EMBEDDED OLE OBJECT". Как только вы щёлкните по OLE-объекту, предварительный просмотр слайда обновится, и сообщение "EMBEDDED OLE OBJECT" будет заменено реальным изображением OLE-объекта. 

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE-объекта обновилось корректно. Таким образом, после сохранения презентации, при её повторном открытии вы НЕ увидите сообщение "EMBEDDED OLE OBJECT". 

## **Другие решения**

### **Решение 1: Заменить сообщение "Embedded OLE Object" изображением**

Если вы не хотите удалять сообщение "EMBEDDED OLE OBJECT" открытием презентации в PowerPoint и последующим сохранением, вы можете заменить сообщение предпочитаемым изображением предварительного просмотра. Ниже приведены строки кода, демонстрирующие процесс:
```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Добавить изображение в ресурсы презентации.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Установить заголовок и изображение для предварительного просмотра OLE-объекта.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Слайд, содержащий `OleObjectFrame`, затем будет выглядеть так:

![New OLE object image](OLE_object_new_image.png)

### **Решение 2: Создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все OLE-объекты при открытии презентаций в программе.