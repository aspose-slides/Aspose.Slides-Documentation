---
title: Конвертация презентации в TIFF с заметками
type: docs
weight: 50
url: /ru/net/convert-presentation-to-tiff-with-notes/
---

TIFF является одним из нескольких широко используемых форматов изображений, поддерживаемых Aspose.Slides для .NET для конвертации презентации с заметками в изображения. Вы также можете создавать миниатюры слайдов в режиме заметок. Ниже приведены два фрагмента кода, которые показывают, как создавать TIFF-изображения презентации в режиме заметок.

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), предоставляемый классом [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), может использоваться для конвертации всей презентации в режиме заметок в TIFF. Вы также можете создать миниатюру слайда в режиме заметок для отдельных слайдов.
## **Пример**

``` 

  //Создаем объект Presentation, который представляет файл презентации

 Presentation pres = new Presentation("Conversion.pptx");

 //Сохраняем презентацию в TIFF с заметками

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Скачать рабочий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительных сведений посетите [Конвертация презентации с заметками](/slides/ru/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}