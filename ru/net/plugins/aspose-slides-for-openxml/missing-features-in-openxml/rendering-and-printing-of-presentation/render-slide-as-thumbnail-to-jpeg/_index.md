---
title: Отрисовка слайда в виде миниатюры в JPEG
type: docs
weight: 60
url: /net/render-slide-as-thumbnail-to-jpeg/
---

**Aspose.Slides для .NET** используется для создания файлов презентаций, содержащих слайды. Эти слайды можно просматривать, открыв файлы презентаций с помощью Microsoft PowerPoint. Но иногда разработчикам может понадобиться просмотреть слайды в виде изображений, используя любимый просмотрщик изображений. В таких случаях Aspose.Slides для .NET помогает вам генерировать миниатюры изображений слайдов.

Чтобы сгенерировать миниатюру любого желаемого слайда с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса **Presentation**.
1. Получите ссылку на любой желаемый слайд, используя его ID или индекс.
1. Получите миниатюру изображения ссылочного слайда на заданном масштабе.
1. Сохраните миниатюру изображения в любом желаемом формате изображения.

``` csharp

 string FilePath = @"..\..\..\Примеры файлов\";

string srcFileName = FilePath + "Миниатюра слайда в JPEG.pptx";

string destFileName = FilePath + "Миниатюра слайда в JPEG.jpg";

// Создайте класс Presentation, представляющий файл презентации

using (Presentation pres = new Presentation(srcFileName))

{

    // Доступ к первому слайду

    ISlide sld = pres.Slides[0];

    // Создайте изображение полного масштаба

    Bitmap bmp = sld.GetThumbnail(1f, 1f);

    // Сохраните изображение на диск в формате JPEG

    bmp.Save(destFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

}


``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)