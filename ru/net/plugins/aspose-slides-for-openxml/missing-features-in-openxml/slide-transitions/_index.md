---
title: Переходы слайдов
type: docs
weight: 80
url: /ru/net/slide-transitions/
---

Чтобы было проще понять, мы продемонстрировали использование Aspose.Slides for .NET для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов на слайды, но и настраивать поведение этих эффектов переходов.Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

- Создать экземпляр класса Presentation
- Применить тип перехода слайда к слайду, выбрав один из эффектов переходов, предлагаемых Aspose.Slides for .NET через **TransitionType** enum
- Сохранить изменённый файл презентации.
## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать работающий пример**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Управление переходами слайдов](/slides/ru/net/slide-transition/).

{{% /alert %}}