---
title: Замена изображений в коллекции изображений презентации
type: docs
weight: 110
url: /ru/net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides для .NET позволяет заменять изображения, добавленные в слайд. Эта статья объясняет, как заменить изображение, добавленное в коллекцию изображений презентации, с использованием разных подходов.

{{% /alert %}} 
## **Замена изображения в коллекции изображений презентации**
Aspose.Slides для .NET предоставляет простые API-методы для замены изображений в коллекции изображений презентации. Пожалуйста, выполните следующие шаги:

1. Загрузите файл презентации с изображением, используя класс [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Загрузите изображение из файла в массив байтов.
1. Замените целевое изображение на новое изображение в массиве байтов.
1. Во втором подходе загрузите изображение в объект Image и замените целевое изображение на загруженное изображение.
1. В третьем подходе замените изображение на уже добавленное изображение в коллекции изображений презентации.
1. Запишите изменённую презентацию в файл PPTX.

```c#
//Создание экземпляра презентации
Presentation presentation = new Presentation("presentation.pptx");

//первый способ
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//второй способ
Image newImage = Image.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//третий способ
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//Сохраните презентацию
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```