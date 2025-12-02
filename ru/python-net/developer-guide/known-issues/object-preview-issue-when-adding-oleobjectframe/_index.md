---
title: Проблема предварительного просмотра объекта при добавлении OleObjectFrame
linktitle: Проблема OLE объекта
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
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для Python и как исправить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides for Python via .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд, на выходном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Управление OLE](/slides/ru/python-net/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён и превью‑изображение нужно обновить.

Например, если вы добавляете диаграмму Microsoft Excel как [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) на слайд (подробности см. в статье «Управление OLE»), а затем открываете презентацию в Microsoft PowerPoint, вы увидите следующее изображение на слайде:

![Сообщение OLE объекта](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE‑объект был добавлен на слайд, необходимо дважды щелкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать **Object > Edit**.

![OLE объект > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![Данные OLE объекта](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE‑объекту превью слайда обновляется, и сообщение «EMBEDDED OLE OBJECT» заменяется фактическим изображением OLE‑объекта.

![Превью OLE объекта](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE‑объекта обновилось корректно. После сохранения при повторном открытии презентации сообщение «EMBEDDED OLE OBJECT» больше не будет отображаться.

## **Другие решения**

### **Решение 1: Заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, можно заменить сообщение на требуемое превью‑изображение. Ниже показан пример кода:

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


Слайд, содержащий `OleObjectFrame`, после этого выглядит так:

![Новое изображение OLE объекта](OLE_object_new_image.png)

### **Решение 2: Создать дополнение для PowerPoint**

Вы также можете создать дополнение для Microsoft PowerPoint, которое будет обновлять все OLE‑объекты при открытии презентаций в программе.