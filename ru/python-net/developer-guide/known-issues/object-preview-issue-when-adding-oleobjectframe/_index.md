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
- предварительный просмотр объекта
- презентация
- PowerPoint
- Python
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для Python и как исправить проблемы с предварительным просмотром в презентациях PPT, PPTX и ODP."
---

## **Введение**

При использовании Aspose.Slides for Python via .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, на выводе отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Manage OLE](/slides/ru/python-net/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides выводит сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён и изображение‑превью необходимо обновить. 

Например, если вы добавите график Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд (подробнее см. статью «Manage OLE»), а затем откроете презентацию в Microsoft PowerPoint, вы увидите это изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и убедиться, что ваш OLE‑объект был добавлен на слайд, необходимо дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![OLE object data](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE‑объекту превью слайда обновляется, и сообщение заменяется реальным изображением OLE‑объекта. 

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы изображение OLE‑объекта было корректно обновлено. После сохранения и повторного открытия презентации сообщение «EMBEDDED OLE OBJECT» больше не будет отображаться. 

## **Другие решения**

### **Решение 1: Заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT» открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение выбранным изображением‑превью. Ниже показан процесс:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Добавить изображение в ресурсы презентации.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # Установить заголовок и изображение для предварительного просмотра OLE‑объекта.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```


Слайд, содержащий `OleObjectFrame`, после этого будет выглядеть так:

![New OLE object image](OLE_object_new_image.png)

### **Решение 2: Создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все OLE‑объекты при открытии презентаций в этой программе.