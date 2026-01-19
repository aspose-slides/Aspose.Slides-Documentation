---
title: Преобразование в Tiff с примечаниями
type: docs
weight: 10
url: /ru/net/conversion-to-tiff-with-notes/
---

TIFF — один из нескольких широко используемых форматов изображений, которые Aspose.Slides for .NET поддерживает для преобразования презентации с примечаниями в изображения. Вы также можете создавать миниатюры слайдов в представлении слайдов с примечаниями. Ниже приведены два фрагмента кода, показывающие, как создавать TIFF‑изображения презентации в представлении слайдов с примечаниями.

Метод **Save**, предоставляемый классом **Presentation**, можно использовать для преобразования всей презентации в представлении с примечаниями в формат TIFF. Вы также можете создавать миниатюру слайда в представлении с примечаниями для отдельных слайдов.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)