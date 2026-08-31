---
title: Конвертация в TIFF с приметками
type: docs
weight: 10
url: /ru/net/conversion-to-tiff-with-notes/
---
TIFF — один из нескольких широко используемых форматов изображений, которые Aspose.Slides for .NET поддерживает для преобразования презентации с приметками в изображения. Вы также можете создавать миниатюры слайдов в представлении «Слайды с приметками». Ниже приведены два фрагмента кода, показывающих, как создавать TIFF‑изображения презентации в представлении «Слайды с приметками».

Метод **Save**, предоставляемый классом **Presentation**, можно использовать для преобразования всей презентации в представлении «Слайды с приметками» в TIFF. Вы также можете создавать миниатюру слайда в представлении «Слайды с приметками» для отдельных слайдов.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Создать объект Presentation, представляющий файл презентации
using (Presentation pres = new Presentation(srcFileName))
{
    //Разместить заметки докладчика под каждым отрендеренным слайдом
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Сохранение презентации в TIFF с приметками
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
```
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)