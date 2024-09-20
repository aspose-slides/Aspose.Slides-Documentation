---
title: Отображено как TIFF по заданным пользователем размерам
type: docs
weight: 40
url: /net/rendered-as-tiff-by-user-defined-dimension/
---

Следующий пример показывает, как преобразовать презентацию в документ TIFF с пользовательским размером изображения, используя класс **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Пример файлов\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Конвертирование в TIFF в заданном формате.tiff";

//Создайте объект Presentation, который представляет файл презентации

Presentation pres = new Presentation(srcFileName);

//Создайте класс TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Установка типа сжатия

opts.CompressionType = TiffCompressionTypes.Default;

//Типы сжатия

//Default - Указывает на стандартную схему сжатия (LZW).

//None - Указывает, что сжатие не используется.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - зависит от типа сжатия и не может быть установлен вручную.

//Единица измерения разрешения - всегда равна "2" (точек на дюйм)

//Установка DPI изображения

opts.DpiX = 200;

opts.DpiY = 100;

//Установите размер изображения

opts.ImageSize = new Size(1728, 1078);

//Сохраните презентацию в TIFF с указанным размером изображения

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)