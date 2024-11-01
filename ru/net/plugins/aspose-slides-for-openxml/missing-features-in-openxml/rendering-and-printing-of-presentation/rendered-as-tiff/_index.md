---
title: Рендеринг в TIFF
type: docs
weight: 30
url: /ru/net/rendered-as-tiff/
---

Формат TIFF известен своей гибкостью в работе с многостраничными изображениями и данными. Учитывая важность и популярность формата TIFF, Aspose.Slides для .NET предоставляет поддержку конвертации презентаций в документах TIFF.  
В этой статье объясняется, как различные параметры экспорта TIFF:

- Конвертация презентации в TIFF с размером по умолчанию.
- Конвертация презентации в TIFF с пользовательским размером.

Метод **Save**, предоставленный классом **Presentation**, может быть вызван разработчиками для конвертации всей презентации в документ **TIFF**. Кроме того, класс TiffOptions предоставляет свойство ImageSize, позволяющее разработчику определить размер изображения при необходимости.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Создание объекта Presentation, представляющего файл презентации

using (Presentation pres = new Presentation(srcFileName))

{

    //Сохранение презентации в документ TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)