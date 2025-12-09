---
title: Профблема предварительного просмотра при добавлении OleObjectFrame
linktitle: Проблема OLE объекта
type: docs
weight: 10
url: /ru/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- объект изменён
- предварительный просмотр объекта
- презентация
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для .NET и как исправить проблемы с просмотром в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides для .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, на выходном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение преднамеренно и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE-объектами см. [Manage OLE](/slides/ru/net/manage-ole/). 

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что OLE-объект был изменён и изображение предварительного просмотра необходимо обновить. 

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд (для получения более подробной информации см. статью «Manage OLE») и затем открываете презентацию в Microsoft PowerPoint, вы увидите следующее изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш OLE-объект был добавлен на слайд, вам нужно дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щёлкнуть правой кнопкой мыши и выбрать пункт **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint откроет встроенный OLE-объект.

![OLE object data](OLE_object_data.png)

На слайде может оставаться сообщение «EMBEDDED OLE OBJECT». После щелчка по OLE-объекту предварительный просмотр слайда обновится, и сообщение «EMBEDDED OLE OBJECT» заменится фактическим изображением OLE-объекта. 

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE‑объекта обновилось корректно. Таким образом, после сохранения презентации при её повторном открытии вы НЕ увидите сообщение «EMBEDDED OLE OBJECT». 

## **Другие решения**

### **Solution 1: Заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение на предпочитаемое изображение предварительного просмотра. Ниже приведены строки кода, демонстрирующие процесс:
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


Слайд, содержащий `OleObjectFrame`, затем меняется на следующий:

![New OLE object image](OLE_object_new_image.png)

### **Solution 2: Создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все OLE‑объекты при открытии презентаций в программе.