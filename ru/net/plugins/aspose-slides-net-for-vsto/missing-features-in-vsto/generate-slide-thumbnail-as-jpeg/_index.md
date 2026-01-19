---
title: Создать миниатюру слайда в формате JPEG
type: docs
weight: 90
url: /ru/net/generate-slide-thumbnail-as-jpeg/
---

Чтобы создать миниатюру любого нужного слайда с помощью Aspose.Slides for .NET:

- Создайте экземпляр класса Presentation.
- Получите ссылку на нужный слайд, используя его ID или индекс.
- Получите изображение миниатюры указанного слайда в заданном масштабе.
- Сохраните изображение миниатюры в любом требуемом формате изображения.
## **Пример**
```cs
//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Для получения дополнительной информации перейдите по ссылке [Конвертировать PPT и PPTX в JPG в .NET](/slides/ru/net/convert-powerpoint-to-jpg/).
{{% /alert %}}