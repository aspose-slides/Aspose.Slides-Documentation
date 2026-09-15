---
title: Проблема превью объекта при добавлении OleObjectFrame
linktitle: Проблема с OLE объектом
type: docs
weight: 10
url: /ru/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема превью
- встраиваемый объект
- встраиваемый файл
- объект изменён
- превью объекта
- PowerPoint
- презентация
- Python
- Java
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides for Python via Java и как исправить проблемы с превью в презентациях PPT, PPTX и ODP."
---
## **Введение**

Когда вы используете Aspose.Slides for Python via Java для добавления [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) на слайд, на выводном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является преднамеренным и не является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Manage OLE](/slides/ru/python-java/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён и его изображение‑превью нужно обновить.

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/) на слайд (подробнее см. статью «Manage OLE»), а затем открываете презентацию в Microsoft PowerPoint, вы увидите на слайде следующее изображение:

![Сообщение OLE‑объекта](OLE_object_message.png)

Чтобы убедиться, что OLE‑объект был добавлен на слайд, дважды щелкните сообщение «EMBEDDED OLE OBJECT» или щёлкните правой кнопкой мыши и выберите **Object > Edit**.

![OLE‑объект > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![Данные OLE‑объекта](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE‑объекту превью слайда обновляется, и сообщение «EMBEDDED OLE OBJECT» заменяется фактическим изображением OLE‑объекта.

![Превью OLE‑объекта](OLE_object_preview.png)

Сохраните презентацию, чтобы сохранить обновлённое изображение‑превью OLE‑объекта. При повторном открытии презентации сообщение «EMBEDDED OLE OBJECT» больше не будет отображаться.

## **Другой способ решения**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение на предпочитаемое изображение‑превью. Ниже приведён код, демонстрирующий процесс:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Добавить изображение в ресурсы презентации.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Установить заголовок и изображение для превью OLE‑объекта.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Слайд, содержащий [OleObjectFrame](https://reference.aspose.com/slides/ru/python-java/aspose.slides/oleobjectframe/), затем изменится следующим образом:

![Новое изображение OLE‑объекта](OLE_object_new_image.png)

## **FAQ**

**Почему появляется сообщение «EMBEDDED OLE OBJECT»?**

Сообщение указывает, что OLE‑объект был изменён и его изображение‑превью необходимо обновить. Такое поведение преднамеренно.

**Как обновить превью в PowerPoint?**

Дважды щёлкните сообщение или выберите **Object > Edit**, чтобы открыть встроенный OLE‑объект. Щёлкните по OLE‑объекту для обновления превью, затем сохраните презентацию.

**Можно ли заменить сообщение без открытия презентации в PowerPoint?**

Да. Вы можете назначить предпочитаемое изображение‑превью OLE‑объекту, как показано в примере кода выше.