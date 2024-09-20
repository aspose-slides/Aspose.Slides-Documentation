---
title: Конвертация в Tiff с заметками
type: docs
weight: 10
url: /net/conversion-to-tiff-with-notes/
---

TIFF – это один из нескольких широко используемых форматов изображений, которые Aspose.Slides для .NET поддерживает для конвертации презентации с заметками в изображения. Вы также можете генерировать миниатюры слайдов в режиме заметок слайдов. Ниже приведены два кода, которые показывают, как генерировать TIFF-изображения презентации в режиме заметок слайдов.

Метод **Save**, предоставленный классом **Presentation**, можно использовать для конвертации всей презентации в режиме заметок слайдов в TIFF. Вы также можете генерировать миниатюру слайда в режиме заметок слайдов для отдельных слайдов.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Конвертация в Tiff с заметкой.pptx";

string destFileName = FilePath + "Конвертация в Tiff с заметкой.tiff";

//Создание объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation(srcFileName);

//Сохранение презентации в формате TIFF с заметками

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)