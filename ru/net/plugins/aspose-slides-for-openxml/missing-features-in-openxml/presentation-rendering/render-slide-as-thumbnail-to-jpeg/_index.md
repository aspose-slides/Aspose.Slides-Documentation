---
title: Отобразить слайд как миниатюру в JPEG
type: docs
weight: 60
url: /ru/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** используется для создания файлов презентаций, содержащих слайды. Эти слайды можно просматривать, открывая файлы презентаций в Microsoft PowerPoint. Но иногда разработчикам необходимо просматривать слайды как изображения в любимом просмотрщике изображений. В таких случаях Aspose.Slides for .NET помогает генерировать миниатюры изображений слайдов.

Чтобы создать миниатюру любого выбранного слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на любой нужный слайд, используя его ID или индекс.
1. Получите изображение миниатюры выбранного слайда в указанном масштабе.
1. Сохраните изображение миниатюры в любом требуемом формате изображения.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//Создайте экземпляр класса Presentation, представляющего файл презентации
using (Presentation pres = new Presentation(srcFileName))
{
    //Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    //Создайте изображение в полном масштабе
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //Сохраните изображение на диск в формате JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)