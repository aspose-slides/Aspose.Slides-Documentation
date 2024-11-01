---
title: Добавить рамку для картинки в презентацию
type: docs
weight: 50
url: /ru/net/add-picture-frame-to-presentation/
---

## **VSTO**
Ниже приведен код для добавления картинки в презентацию VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Чтобы добавить простую рамку для картинки на ваш слайд, пожалуйста, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Создайте объект Image, добавив изображение в коллекцию Images, связанную с объектом Presentation, который будет использоваться для заполнения Shape.
1. Рассчитайте ширину и высоту изображения.
1. Создайте PictureFrame в соответствии с шириной и высотой изображения, используя метод AddPictureFrame, предоставленный объектом Shapes, связанным с указанным слайдом.
1. Добавьте рамку для картинки (содержит изображение) на слайд.
1. Запишите измененную презентацию в файл PPTX.

Вышеописанные шаги реализованы в примере, приведенном ниже.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Создайте экземпляр класса Presentation, который представляет PPTX

  Presentation pres = new Presentation();

  //Получите первый слайд

  ISlide sld = pres.Slides[0];

  //Создайте экземпляр класса ImageEx

  Image img = (Image)new Bitmap(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Добавьте рамку для картинки с высотой и шириной, равными размеру изображения

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Скачать работающий код**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Add Picture Frame/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)