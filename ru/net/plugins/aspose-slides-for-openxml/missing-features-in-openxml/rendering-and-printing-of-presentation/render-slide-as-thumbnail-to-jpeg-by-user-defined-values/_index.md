---
title: Отобразить слайд в виде миниатюры в формате JPEG по заданным пользователем значениям
type: docs
weight: 70
url: /net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---

Для создания миниатюры любого необходимого слайда с использованием Aspose.Slides для .NET:

1. Создайте экземпляр класса **Presentation**.
2. Получите ссылку на любой необходимый слайд, используя его ID или индекс.
3. Получите коэффициенты масштабирования X и Y на основе заданных пользователем размеров X и Y.
4. Получите изображение миниатюры ссылающегося слайда на указанном масштабе.
5. Сохраните изображение миниатюры в любом нужном формате изображения.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Миниатюра, заданная пользователем.pptx";

string destFileName = FilePath + "Миниатюра, заданная пользователем.jpg";

//Создайте экземпляр класса Presentation, представляющего файл презентации

using (Presentation pres = new Presentation(srcFileName))

{

//Получите доступ к первому слайду

ISlide sld = pres.Slides[0];

//Заданное пользователем измерение

int desiredX = 1200;

int desiredY = 800;

//Получение масштабированного значения X и Y

float ScaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;

float ScaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

//Создайте изображение в полном масштабе

Bitmap bmp = sld.GetThumbnail(ScaleX, ScaleY);

//Сохраните изображение на диск в формате JPEG

bmp.Save(destFileName, System.Drawing.Imaging.ImageFormat.Jpeg);

}

``` 
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)