---
title: Отображено как Tiff
type: docs
weight: 30
url: /ru/net/rendered-as-tiff/
---

Формат TIFF известен своей гибкостью, позволяющей поддерживать многостраничные изображения и данные. Учитывая важность и популярность формата TIFF, Aspose.Slides for .NET предоставляет поддержку конвертации презентаций в документ TIFF.  
В этой статье объясняются различные варианты экспорта TIFF:

- Конвертация презентации в TIFF с размером по умолчанию.  
- Конвертация презентации в TIFF с пользовательским размером.

Метод **Save**, предоставляемый классом **Presentation**, может вызываться разработчиками для преобразования всей презентации в документ **TIFF**. Кроме того, класс TiffOptions раскрывает свойство ImageSize, позволяющее при необходимости задать размер изображения.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)