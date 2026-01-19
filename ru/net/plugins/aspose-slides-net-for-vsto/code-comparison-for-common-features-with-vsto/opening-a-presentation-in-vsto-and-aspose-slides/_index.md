---
title: Открытие презентации в VSTO и Aspose.Slides
type: docs
weight: 120
url: /ru/net/opening-a-presentation-in-vsto-and-aspose-slides/
---

## **VSTO**
Ниже приведён фрагмент кода для открытия презентации:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET предоставляет класс **Presentation**, который используется для открытия существующей презентации. Он предлагает несколько перегруженных конструкторов, и мы можем воспользоваться одним из подходящих конструкторов класса **Presentation**, чтобы создать его объект на основе существующей презентации. В примере ниже мы передали имя файла презентации (который нужно открыть) в конструктор класса Presentation. После открытия файла мы получаем общее количество слайдов в презентации, чтобы вывести его на экран.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)