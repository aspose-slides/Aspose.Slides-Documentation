---
title: Генерация миниатюры слайда с заданными пользователем размерами
type: docs
weight: 100
url: /ru/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Чтобы сгенерировать миниатюру любого желаемого слайда с помощью Aspose.Slides для .NET:

- Создайте экземпляр класса Presentation.
- Получите ссылку на любой желаемый слайд, используя его ID или индекс.
- Получите коэффициенты масштабирования по X и Y на основе заданных пользователем размеров X и Y.
- Получите изображение миниатюры ссылочного слайда в указанном масштабе.
- Сохраните изображение миниатюры в любом желаемом формате изображения.
## **Пример**
``` 

 //Создайте экземпляр класса Presentation, представляющий файл презентации

using (Presentation pres = new Presentation("TestPresentation.pptx"))

{

  //Получите доступ к первому слайду

  ISlide sld = pres.Slides[0];

  //Размер, заданный пользователем

  int desiredX = 1200;

  int desiredY = 800;

  //Получение масштабированного значения по X и Y

  float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;

  float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

  //Создайте полноразмерное изображение

  Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

  //Сохраните изображение на диск в формате JPEG

  bmp.Save("Thumbnail2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

``` 
## **Скачайте работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/User Defined Thumbnail/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачайте образец кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Создание изображения миниатюры слайдов](/slides/ru/net/presentation-viewer/#creating-slides-thumbnail-image).

{{% /alert %}}