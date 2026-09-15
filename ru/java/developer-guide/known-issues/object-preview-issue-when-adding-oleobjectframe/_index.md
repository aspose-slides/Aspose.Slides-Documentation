---
title: Проблема предварительного просмотра при добавлении OleObjectFrame
linktitle: Проблема с OLE объектом
type: docs
weight: 10
url: /ru/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- изменённый объект
- предварительный просмотр объекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides for Java и как исправить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---
## **Введение**

При работе с Aspose.Slides for Java, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/oleobjectframe/) на слайд, на полученном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Manage OLE](/slides/ru/java/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides выводит сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён и требуется обновить изображение‑превью.

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/oleobjectframe/) на слайд (подробности см. в статье «Manage OLE»), а затем открываете презентацию в Microsoft PowerPoint, вы увидите следующее изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE‑объект был добавлен на слайд, необходимо дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![OLE object data](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE‑объекту превью слайда обновляется, и сообщение «EMBEDDED OLE OBJECT» заменяется настоящим изображением OLE‑объекта.

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы удостовериться, что изображение OLE‑объекта обновилось правильно. Таким образом, после сохранения и повторного открытия презентации вы НЕ увидите сообщение «EMBEDDED OLE OBJECT».

## **Другой способ**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение на желаемое изображение‑превью. Следующие строки кода демонстрируют процесс:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Добавить изображение в ресурсы презентации.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // Установить заголовок и изображение для предварительного просмотра OLE‑объекта.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

Слайд, содержащий `OleObjectFrame`, затем изменяется на следующее:

![New OLE object image](OLE_object_new_image.png)