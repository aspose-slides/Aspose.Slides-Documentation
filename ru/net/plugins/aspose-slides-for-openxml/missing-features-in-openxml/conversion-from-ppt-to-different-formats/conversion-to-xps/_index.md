---
title: Конвертация в XPS
type: docs
weight: 40
url: /ru/net/conversion-to-xps/
---

Формат **XPS** также широко используется для обмена данными. Aspose.Slides для .NET учитывает его важность и предоставляет встроенную поддержку для конвертации презентации в документ XPS.

Метод **Save**, предоставляемый классом Presentation, может использоваться для конвертации всей презентации в документ **XPS**. Кроме того, класс **XpsOptions** предоставляет свойство **SaveMetafileAsPng**, которое может быть установлено в true или false в зависимости от требований.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Создание объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation(srcFileName);

//Сохранение презентации в документ TIFF

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)