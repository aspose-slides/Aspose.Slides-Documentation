---
title: Добавить слайд макета в презентацию
type: docs
weight: 10
url: /ru/net/add-layout-slide-to-presentation/
---

Aspose.Slides для .NET позволяет разработчикам добавлять новые слайды макетов в презентацию. Для добавления слайда макета выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите коллекцию основных слайдов
- Попробуйте найти существующие слайды макетов, чтобы узнать, доступен ли нужный в коллекции слайдов макетов
- Добавьте новый слайд макета, если желаемый макет недоступен
- Добавьте пустой слайд с вновь добавленным слайдом макета
- Наконец, запишите файл презентации, используя объект Presentation.
## **Пример**
``` csharp

 //Создайте экземпляр класса Presentation, который представляет файл презентации

using (Presentation p = new Presentation("Test.pptx"))

{

   // Попробуйте найти по типу слайда макета

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Ситуация, когда презентация не содержит некоторые типы макетов.

     // Презентация Technographics.pptx содержит только пустые и пользовательские типы макетов.

     // Но слайды макетов с пользовательскими типами имеют разные названия слайдов,

     // такие как "Заголовок", "Заголовок и содержимое" и т. д. И возможно использовать эти

     // названия для выбора слайда макета.

     // Также возможно использовать набор типов форм для заполнительных областей. Например,

     // Слайд заголовка должен содержать только тип заполнителя заголовка и т. д.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Заголовок и объект")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Заголовок")

            {

                layoutSlide = titleLayoutSlide;

                break;

            }

          }

          if (layoutSlide == null)

          {

             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

             if (layoutSlide == null)

             {

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Заголовок и объект");

             }

          }

      }

  }

  //Добавление пустого слайда с добавленным слайдом макета

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Сохранить презентацию

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Скачать работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации перейдите на страницу [Добавление слайда макета в презентацию](/slides/ru/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}