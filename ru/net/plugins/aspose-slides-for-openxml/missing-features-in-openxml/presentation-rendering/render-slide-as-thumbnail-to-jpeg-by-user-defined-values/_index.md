---
title: Рендеринг слайда в миниатюру JPEG с пользовательскими значениями
type: docs
weight: 70
url: /ru/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Для создания миниатюры любого выбранного слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на любой выбранный слайд, используя его ID или индекс.
1. Получите коэффициенты масштабирования по X и Y на основе пользовательских размеров X и Y.
1. Получите изображение миниатюры указанного слайда в заданном масштабе.
1. Сохраните изображение миниатюры в любом желаемом формате изображения.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Создайте экземпляр класса Presentation, который представляет файл презентации
using (Presentation pres = new Presentation(srcFileName))
{
    //Получите доступ к первому слайду
    ISlide sld = pres.Slides[0];

    //Пользовательские размеры
    int desiredX = 1200;
    int desiredY = 800;

    //Получение масштабированных значений X и Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Создание изображения в полном масштабе
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Сохраните изображение на диск в формате JPEG
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)