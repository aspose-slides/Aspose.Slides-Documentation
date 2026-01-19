---
title: Добавить кадр изображения в презентацию
type: docs
weight: 50
url: /ru/net/add-picture-frame-to-presentation/
---

## **VSTO**
Ниже приведён код для добавления изображения в презентацию VSTO:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
Чтобы добавить простой кадр с изображением на слайд, выполните следующие шаги:

1. Создайте экземпляр класса Presentation.
1. Получите ссылку на слайд, используя его индекс.
1. Создайте объект Image, добавив изображение в коллекцию Images, связанную с объектом Presentation, которое будет использоваться для заполнения Shape.
1. Вычислите ширину и высоту изображения.
1. Создайте PictureFrame с учётом ширины и высоты изображения, используя метод AddPictureFrame, предоставленный объектом Shapes, связанным с указанным слайдом.
1. Добавьте кадр с изображением (содержащий картинку) на слайд.
1. Сохраните изменённую презентацию в файл PPTX.

Вышеописанные шаги реализованы в приведённом ниже примере.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide sld = pres.Slides[0];

  //Instantiate the ImageEx class

  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //Add Picture Frame with height and width equivalent of Picture

  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Скачать работающий код**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)