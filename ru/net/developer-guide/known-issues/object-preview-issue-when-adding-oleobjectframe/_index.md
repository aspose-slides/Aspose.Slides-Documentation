---
title: Проблема предварительного просмотра объекта при добавлении OleObjectFrame
linktitle: Проблема с OLE объектом
type: docs
weight: 10
url: /ru/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема предварительного просмотра
- встроенный объект
- встроенный файл
- объект изменён
- предпросмотр объекта
- презентация
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Узнайте, почему появляется сообщение EMBEDDED OLE OBJECT при добавлении OleObjectFrame в Aspose.Slides для .NET и как исправить проблемы предварительного просмотра в презентациях PPT, PPTX и ODP."
---

## **Введение**

Используя Aspose.Slides for .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд, на выходном слайде отображается сообщение «EMBEDDED OLE OBJECT». Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с объектами OLE см. [Manage OLE](/slides/ru/net/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение «EMBEDDED OLE OBJECT», чтобы уведомить вас о том, что объект OLE был изменён и изображение предварительного просмотра должно быть обновлено.

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe) на слайд (подробности см. в статье «Manage OLE») и затем открываете презентацию в Microsoft PowerPoint, вы увидите это изображение на слайде:

![OLE object message](OLE_object_message.png)

Если вы хотите проверить и подтвердить, что ваш объект OLE был добавлен на слайд, необходимо дважды щёлкнуть по сообщению «EMBEDDED OLE OBJECT», либо щелкнуть правой кнопкой мыши и выбрать опцию **Object > Edit**.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint затем открывает встроенный объект OLE.

![OLE object data](OLE_object_data.png)

Слайд может сохранять сообщение «EMBEDDED OLE OBJECT». После того как вы щёлкните по объекту OLE, предварительный просмотр слайда обновится, и сообщение «EMBEDDED OLE OBJECT» будет заменено фактическим изображением объекта OLE.

![OLE object preview](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение для объекта OLE обновилось корректно. Таким образом, после сохранения презентации, при повторном открытии вы НЕ увидите сообщение «EMBEDDED OLE OBJECT».

## **Другие решения**

### **Решение 1: заменить сообщение «Embedded OLE Object» изображением**

Если вы не хотите удалять сообщение «EMBEDDED OLE OBJECT», открывая презентацию в PowerPoint и затем сохраняя её, вы можете заменить сообщение своим предпочтительным изображением предварительного просмотра. Ниже приведённые строки кода показывают процесс:
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


Слайд, содержащий `OleObjectFrame`, затем изменяется следующим образом:

![New OLE object image](OLE_object_new_image.png)

### **Решение 2: создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все объекты OLE при открытии презентаций в программе.