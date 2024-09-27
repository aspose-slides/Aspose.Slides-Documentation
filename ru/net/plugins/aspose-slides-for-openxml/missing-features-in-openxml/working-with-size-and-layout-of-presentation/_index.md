---
title: Работа с размером и макетом презентации
type: docs
weight: 90
url: /ru/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** и **SlideSize.Size** — это свойства класса презентации, которые могут быть установлены или получены, как показано ниже в примере.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Пример файлов\";

string FileName = FilePath + "Работа с размером и макетом.pptx";

//Создайте объект Presentation, представляющий файл презентации 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Установите размер слайда сгенерированных презентаций таким же, как у исходного

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Сохраните презентацию на диске

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **Скачать образец кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Скачать работающий пример**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Для получения более подробной информации посетите [Работа с размером и макетом слайда](/slides/ru/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}