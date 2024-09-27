---
title: Открытие презентации в VSTO и Aspose.Slides
type: docs
weight: 120
url: /ru/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Ниже приведен код для открытия презентации:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides для .NET предоставляет класс **Presentation**, который используется для открытия существующей презентации. Он предлагает несколько перегруженных конструкторов, и мы можем использовать один из подходящих конструкторов класса **Presentation** для создания его объекта на основе существующей презентации. В приведенном ниже примере мы передаем имя файла презентации (который нужно открыть) конструктору класса Presentation. После открытия файла мы получаем общее количество слайдов в презентации для отображения на экране.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Скачать работающий код**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Скачать пример кода**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Opening a Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)