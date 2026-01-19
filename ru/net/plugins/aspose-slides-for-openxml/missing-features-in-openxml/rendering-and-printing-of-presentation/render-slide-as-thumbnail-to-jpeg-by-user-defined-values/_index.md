---
title: Создать миниатюру слайда в формате JPEG по пользовательским значениям
type: docs
weight: 70
url: /ru/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Чтобы создать миниатюру любого выбранного слайда с помощью Aspose.Slides for .NET:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на нужный слайд, используя его ID или индекс.
1. Вычислите коэффициенты масштабирования X и Y на основе пользовательских размеров X и Y.
1. Получите изображение миниатюры выбранного слайда в указанном масштабе.
1. Сохраните изображение миниатюры в любом требуемом формате изображения.

``` csharp
string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
using (Presentation pres = new Presentation(srcFileName))
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
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)