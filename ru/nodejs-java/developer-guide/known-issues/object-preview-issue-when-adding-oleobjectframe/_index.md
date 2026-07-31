---
title: Проблема предварительного просмотра объекта при добавлении OleObjectFrame
linktitle: Проблема OLE объекта
type: docs
weight: 10
url: /ru/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- объект изменён
- предпросмотр объекта
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для Node.js и как исправить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---
## **Введение**

При использовании Aspose.Slides for Java, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleobjectframe/) на слайд, на выходном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами смотрите [Manage OLE](/slides/ru/nodejs-java/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE‑объект был изменён и требуется обновить изображение‑предпросмотр. 

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleobjectframe/) на слайд (для получения подробностей см. статью «Manage OLE»), а затем открываете презентацию в Microsoft PowerPoint, вы увидите следующее изображение на слайде:

![сообщение OLE объекта](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что OLE‑объект был добавлен на слайд, необходимо дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE объект > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![данные OLE объекта](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE‑объекту предварительный просмотр слайда обновляется, и сообщение «EMBEDDED OLE OBJECT» заменяется фактическим изображением OLE‑объекта. 

![предпросмотр OLE объекта](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE‑объекта обновилось корректно. После сохранения и повторного открытия презентации вы НЕ увидите сообщение «EMBEDDED OLE OBJECT». 

## **Другие решения**

### **Решение 1: Заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение на предпочитаемое изображение‑предпросмотр. Пример кода, демонстрирующего процесс:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Добавьте изображение в ресурсы презентации.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // Установите заголовок и изображение для предварительного просмотра OLE объекта.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Слайд, содержащий `OleObjectFrame`, затем изменяется на следующее:

![Новое изображение OLE объекта](OLE_object_new_image.png)

### **Решение 2: Создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все OLE‑объекты при открытии презентаций в программе.