---
title: Заполнитель превью объекта при добавлении OleObjectFrame
linktitle: Заполнитель превью OLE
type: docs
weight: 10
url: /ru/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- проблема превью
- заполнитель превью
- по замыслу
- встроенный объект
- встроенный файл
- объект изменён
- превью объекта
- презентация
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Почему OLE объект, добавленный с Aspose.Slides для .NET, показывает заполнитель EMBEDDED OLE OBJECT до обновления его превью, и как задать собственное изображение превью."
---
## **Введение**

Используя Aspose.Slides для .NET, когда вы добавляете [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe/) на слайд, на выходном слайде отображается сообщение "EMBEDDED OLE OBJECT". Это сообщение является намеренным и НЕ является ошибкой.

Для получения дополнительной информации о работе с OLE-объектами см. [Manage OLE](/slides/ru/net/manage-ole/).

## **Объяснение и решение**

Aspose.Slides отображает сообщение "EMBEDDED OLE OBJECT", чтобы уведомить вас, что OLE-объект был изменён и изображение превью необходимо обновить.

Например, если вы добавляете диаграмму Microsoft Excel в виде [OleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/oleobjectframe/) на слайд (подробнее см. статью "Manage OLE") и затем открываете презентацию в Microsoft PowerPoint, вы увидите на слайде следующее изображение:

![Сообщение OLE-объекта](OLE_object_message.png)

Если вы хотите проверить и убедиться, что ваш OLE-объект был добавлен на слайд, вам нужно дважды щёлкнуть по сообщению "EMBEDDED OLE OBJECT", либо щёлкнуть правой кнопкой мыши по нему и выбрать пункт **Object > Edit**.

![OLE-объект > Edit](OLE_object_edit.png)

PowerPoint затем открывает встроенный OLE-объект.

![Данные OLE-объекта](OLE_object_data.png)

Слайд может сохранять сообщение "EMBEDDED OLE OBJECT". После щелчка по OLE-объекту превью слайда обновляется, и сообщение "EMBEDDED OLE OBJECT" заменяется реальным изображением OLE-объекта.

![Превью OLE-объекта](OLE_object_preview.png)

Теперь вы можете сохранить презентацию, чтобы убедиться, что изображение OLE-объекта обновилось корректно. Таким образом, после сохранения презентации при её повторном открытии вы НЕ увидите сообщение "EMBEDDED OLE OBJECT".

## **Другие решения**

### **Решение 1: Заменить сообщение "Embedded OLE Object" изображением**

Если вы не хотите удалять сообщение "EMBEDDED OLE OBJECT" открытием презентации в PowerPoint и последующим сохранением, вы можете заменить сообщение на предпочитаемое изображение превью. Ниже приведены строки кода, демонстрирующие процесс:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set the image for the OLE object preview.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

Слайд, содержащий `OleObjectFrame`, затем меняется на следующий:

![Новое изображение OLE-объекта](OLE_object_new_image.png)

### **Решение 2: Создать надстройку для PowerPoint**

Вы также можете создать надстройку для Microsoft PowerPoint, которая будет обновлять все OLE-объекты при открытии презентаций в программе.