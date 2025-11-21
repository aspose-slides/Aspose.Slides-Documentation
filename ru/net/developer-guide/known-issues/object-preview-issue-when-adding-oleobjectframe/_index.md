---
title: Проблема превью объекта при добавлении OleObjectFrame
linktitle: Проблема OLE объекта
type: docs
weight: 10
url: /ru/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема превью
- встраивание объекта
- встраивание файла
- объект изменён
- превью объекта
- презентация
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для .NET и как исправить проблемы превью в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides для .NET, при добавлении [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд выводится сообщение «EMBEDDED OLE OBJECT». Это сообщение намеренно и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE‑объектами см. [Управление OLE](/slides/ru/net/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас, что OLE‑объект был изменён и изображение‑превью необходимо обновить. 

Например, если вы добавляете график Microsoft Excel как [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд (подробности см. в статье «Управление OLE») и затем открываете презентацию в Microsoft PowerPoint, вы увидите следующее изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и убедиться, что ваш OLE‑объект был добавлен на слайд, нужно дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT» или щёлкнуть правой кнопкой мыши и выбрать пункт **Объект > Правка**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE‑объект.

![OLE object data](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». Как только вы щёлкните по OLE‑объекту, превью слайда обновится, и сообщение «EMBEDDED OLE OBJECT» будет заменено реальным изображением OLE‑объекта. 

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы удостовериться, что изображение OLE‑объекта обновилось корректно. Таким образом, после сохранения и повторного открытия презентации вы НЕ увидите сообщение «EMBEDDED OLE OBJECT». 

## **Другие решения**

### **Решение 1: Заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение на выбранное вами изображение превью. Следующие строки кода демонстрируют процесс:
```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```


Слайд, содержащий `OleObjectFrame`, затем изменяется на следующий:

![New OLE object image](OLE_object_new_image.png)

### **Решение 2: Создать дополнение для PowerPoint**

Вы также можете создать дополнение для Microsoft PowerPoint, которое будет обновлять все OLE‑объекты при открытии презентаций в программе.