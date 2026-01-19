---
title: Рендеринг слайда как миниатюры в JPEG
type: docs
weight: 60
url: /ru/net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides for .NET** используется для создания файлов презентаций, содержащих слайды. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам может потребоваться просматривать слайды как изображения в любимом просмотрщике изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюрные изображения слайдов.

Для получения миниатюры любого нужного слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса **Presentation**.
2. Получите ссылку на нужный слайд, используя его ID или индекс.
3. Получите изображение‑миниатюру выбранного слайда в заданном масштабе.
4. Сохраните изображение‑миниатюру в любом желаемом формате изображения.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //Create a full scale image
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)