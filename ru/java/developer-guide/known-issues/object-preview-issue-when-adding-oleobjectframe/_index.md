---
title: Проблема предварительного просмотра при добавлении OleObjectFrame
linktitle: Проблема OLE объекта
type: docs
weight: 10
url: /ru/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- объект изменён
- предварительный просмотр объекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides for Java и как исправить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides for Java, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) на слайд, на выходном слайде отображается сообщение "EMBEDDED OLE OBJECT". Это сообщение преднамеренно и NOT является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Manage OLE](/slides/ru/java/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение "EMBEDDED OLE OBJECT", чтобы уведомить вас о том, что OLE‑объект был изменён и изображение превью должно быть обновлено.

Например, если вы добавите диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe/) на слайд (для получения более подробной информации см. статью "Manage OLE"), а затем откроете презентацию в Microsoft PowerPoint, вы увидите на слайде следующее изображение:

![Сообщение OLE объекта](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE‑объект был добавлен на слайд, вам необходимо дважды щёлкнуть по сообщению "EMBEDDED OLE OBJECT", либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE объект > Edit](OLE_object_edit.png)

PowerPoint затем открывает встроенный OLE‑объект.

![Данные OLE объекта](OLE_object_data.png)

Слайд может сохранять сообщение "EMBEDDED OLE OBJECT". Как только вы щёлкните по OLE‑объекту, превью слайда обновится, и сообщение "EMBEDDED OLE OBJECT" будет заменено фактическим изображением OLE‑объекта.

![Предпросмотр OLE объекта](OLE_object_preview.png)

Теперь вы можете захотеть сохранить презентацию, чтобы убедиться, что изображение OLE‑объекта обновилось корректно. Таким образом, после сохранения презентации, при её повторном открытии вы NOT увидите сообщение "EMBEDDED OLE OBJECT".

## **Другие решения**

### **Solution 1: Заменить сообщение "Embedded OLE Object" изображением**

Если вы не хотите удалять сообщение "EMBEDDED OLE OBJECT" открытием презентации в PowerPoint и её последующим сохранением, вы можете заменить сообщение на предпочитаемое изображение превью. Ниже приведённые строки кода демонстрируют процесс:
```java
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


Слайд, содержащий `OleObjectFrame`, затем изменяется следующим образом:

![Новое изображение OLE объекта](OLE_object_new_image.png)

### **Solution 2: Создать дополнение для PowerPoint**

Вы также можете создать дополнение для Microsoft PowerPoint, которое будет обновлять все OLE‑объекты при открытии презентаций в программе.