---
title: Отображено как TIFF с заданными пользователем размерами
type: docs
weight: 40
url: /ru/net/rendered-as-tiff-by-user-defined-dimension/
---

Следующий пример демонстрирует, как преобразовать презентацию в документ TIFF с пользовательским размером изображения, используя класс **TiffOptions**.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//Создать объект Presentation, представляющий файл презентации

Presentation pres = new Presentation(srcFileName);

//Создать экземпляр класса TiffOptions

Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//Установка типа сжатия

opts.CompressionType = TiffCompressionTypes.Default;

//Типы сжатия

//Default - Указывает схему сжатия по умолчанию (LZW).

//None - Указывает, что сжатие не используется.

//CCITT3

//CCITT4

//LZW

//RLE

//Depth - зависит от типа сжатия и не может быть установлена вручную.

//Resolution unit - всегда равно "2" (точек на дюйм)

//Установка DPI изображения

opts.DpiX = 200;

opts.DpiY = 100;

//Установка размера изображения

opts.ImageSize = new Size(1728, 1078);

//Сохранить презентацию в TIFF с указанным размером изображения

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)