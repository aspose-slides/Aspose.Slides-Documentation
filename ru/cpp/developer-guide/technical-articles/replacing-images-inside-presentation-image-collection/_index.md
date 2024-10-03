---
title: Замена изображений внутри коллекции изображений презентации
type: docs
weight: 90
url: /ru/cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides для C++ позволяет заменять изображения, добавленные в формы слайдов. В этой статье вы узнаете, как заменить изображение, добавленное в коллекцию изображений презентации, различными способами.

{{% /alert %}} 
## **Замена изображения внутри коллекции изображений презентации**
Aspose.Slides для C++ предоставляет простой метод API, который позволяет вам заменить изображение внутри коллекции изображений презентации следующим образом:

1. Загрузите файл презентации с изображением, используя класс [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Загрузите изображение из файла в массив байтов.
1. Используйте один из следующих подходов:
   - Первый подход: Замените целевое изображение на новое изображение в массиве байтов.
   - Второй подход: Загрузите изображение в объект [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) и замените целевое изображение на загруженное изображение.
   - Третий подход: Замените изображение на уже добавленное изображение в коллекции изображений презентации.
1. Запишите измененную презентацию в файл PPTX.

Этот пример кода показывает, как заменить изображение в коллекции изображений презентации:

``` cpp
// Создаем презентацию
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// Первый подход
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// Второй подход
SharedPtr<Image> newImage = Image::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);

// Третий подход
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// Сохраните презентацию
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```