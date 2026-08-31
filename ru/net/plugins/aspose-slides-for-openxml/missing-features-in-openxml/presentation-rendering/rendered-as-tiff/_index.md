---
title: Отображено как TIFF
type: docs
weight: 30
url: /ru/net/rendered-as-tiff/
---
Формат TIFF известен своей гибкостью в поддержке многостраничных изображений и данных. Учитывая важность и популярность формата TIFF, Aspose.Slides for .NET предоставляет поддержку преобразования презентаций в документ TIFF.
В этой статье объясняются различные параметры экспорта TIFF:

- Преобразование презентации в TIFF с размером по умолчанию.
- Преобразование презентации в TIFF с пользовательским размером.

Метод **Save**, предоставляемый классом **Presentation**, может быть вызван разработчиками для преобразования всей презентации в документ **TIFF**. Кроме того, класс TiffOptions раскрывает свойство ImageSize, позволяя разработчику при необходимости задать размер изображения.

``` csharp
using Aspose.Slides;


 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Создайте объект Presentation, который представляет файл презентации

using (Presentation pres = new Presentation(srcFileName))

{

    //Сохранение презентации в документ TIFF

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}
``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)