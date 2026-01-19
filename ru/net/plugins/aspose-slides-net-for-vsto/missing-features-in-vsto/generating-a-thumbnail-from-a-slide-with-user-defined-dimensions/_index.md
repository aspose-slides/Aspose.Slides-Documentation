---
title: Генерация миниатюры со слайда с пользовательскими размерами
type: docs
weight: 100
url: /ru/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---

Чтобы создать миниатюру любого нужного слайда с помощью Aspose.Slides for .NET:

- Создайте экземпляр класса Presentation.
- Получите ссылку на нужный слайд, используя его идентификатор или индекс.
- Получите коэффициенты масштабирования по осям X и Y на основе заданных пользователем размеров X и Y.
- Получите изображение миниатюры указанного слайда в заданном масштабе.
- Сохраните изображение миниатюры в любом требуемом формате изображения.
## **Пример**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Для получения более подробной информации перейдите к [Convert Slide](/slides/ru/net/convert-slide/).

{{% /alert %}}