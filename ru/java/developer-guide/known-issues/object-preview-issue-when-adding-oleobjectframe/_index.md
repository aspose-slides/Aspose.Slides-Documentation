---
title: Заполнитель предварительного просмотра объекта при добавлении OleObjectFrame
linktitle: Заполнитель предварительного просмотра OLE
type: docs
weight: 10
url: /ru/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- заполнитель предварительного просмотра
- по задумке
- встраиваемый объект
- встраиваемый файл
- объект изменён
- предварительный просмотр объекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Почему OLE‑объект, добавленный с помощью Aspose.Slides для Java, отображается как заполнитель EMBEDDED OLE OBJECT до обновления его предварительного просмотра, и как установить собственное изображение предварительного просмотра."
---
## **Введение**

При использовании Aspose.Slides для Java, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/oleobjectframe/) на слайд, на выводимом слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение намеренное и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Manage OLE](/slides/ru/java/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён, и изображение предварительного просмотра необходимо обновить.

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/oleobjectframe/) на слайд (подробнее см. статью «Manage OLE»), а затем открываете презентацию в Microsoft PowerPoint, вы увидите на слайде следующее изображение:

![Сообщение OLE‑объекта](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE‑объект действительно добавлен на слайд, необходимо дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать опцию **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint откроет внедрённый OLE‑объект.

![Данные OLE‑объекта](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После того как вы щёлкнете по OLE‑объекту, предварительный просмотр слайда обновляется, и сообщение «EMBEDDED OLE OBJECT» заменяется реальным изображением OLE‑объекта.

![Предпросмотр OLE‑объекта](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE‑объекта обновилось корректно. После сохранения при повторном открытии презентации сообщение «EMBEDDED OLE OBJECT» больше не будет отображаться.

## **Другой способ**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и сохраняя её, вы можете заменить сообщение на своё собственное изображение предварительного просмотра. Ниже приведён пример кода, демонстрирующий процесс. Предполагается, что первая фигура на первом слайде *embeddedOLE.pptx* является OLE‑объектом, а *myImage.png* содержит изображение, которое следует отобразить; результат сохраняется как *embeddedOLE-newImage.pptx*:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Добавьте изображение в ресурсы презентации.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // Установите изображение для предварительного просмотра OLE‑объекта.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Слайд, содержащий `OleObjectFrame`, затем выглядит так:

![Новое изображение OLE‑объекта](OLE_object_new_image.png)