---
title: Конвертировать презентацию в TIFF с примечаниями
type: docs
weight: 50
url: /ru/net/convert-presentation-to-tiff-with-notes/
---

TIFF — один из нескольких широко используемых форматов изображений, которые Aspose.Slides for .NET поддерживает для конвертации презентации с примечаниями в изображения. Вы также можете создавать миниатюры слайдов в представлении «Слайд с примечаниями». Ниже представлены два фрагмента кода, показывающих, как генерировать TIFF‑изображения презентации в представлении «Слайд с примечаниями».

Метод [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save), доступный в классе [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), можно использовать для преобразования всей презентации в представлении «Слайд с примечаниями» в TIFF. Вы также можете создать миниатюру слайда в представлении «Слайд с примечаниями» для отдельных слайдов.
## **Пример**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Для получения более подробной информации посетите [Конвертировать презентации PowerPoint в TIFF с примечаниями в .NET](/slides/ru/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}