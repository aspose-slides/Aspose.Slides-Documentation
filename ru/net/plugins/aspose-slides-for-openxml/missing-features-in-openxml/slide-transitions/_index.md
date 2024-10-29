---
title: Переходы слайдов
type: docs
weight: 80
url: /ru/net/slide-transitions/
---

Чтобы облегчить понимание, мы продемонстрировали использование Aspose.Slides для .NET для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов слайдов, но также настраивать поведение этих эффектов переходов. Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Примените тип перехода слайда из одного из эффектов перехода, предлагаемых Aspose.Slides для .NET, через перечисление **TransitionType**
- Запишите измененный файл презентации.
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Управление переходами слайдов.pptx";

//Создайте экземпляр класса Presentation, который представляет файл презентации

using (Presentation pres = new Presentation(FileName))

{

    //Примените переход типа "круг" на слайд 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Примените переход типа "комбинация" на слайд 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Примените переход типа "увеличение" на слайд 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Запишите презентацию на диск

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример кода**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Скачать работающий пример**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

Для получения дополнительных сведений посетите [Управление переходами слайдов](/slides/ru/net/slide-transition/).

{{% /alert %}}