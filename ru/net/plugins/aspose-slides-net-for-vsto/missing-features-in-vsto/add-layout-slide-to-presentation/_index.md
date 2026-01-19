---
title: Добавить слайд макета в презентацию
type: docs
weight: 10
url: /ru/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NET позволяет разработчикам добавлять новые слайды макета в презентацию. Чтобы добавить слайд макета, пожалуйста, следуйте инструкциям ниже:

- Создайте экземпляр класса Presentation
- Получите доступ к коллекции Master Slide
- Попробуйте найти существующие слайды макета, чтобы проверить, доступен ли требуемый в коллекции Layout Slide
- Добавьте новый слайд макета, если нужный макет недоступен
- Добавьте пустой слайд с только что добавленным слайдом макета
- Наконец, запишите файл презентации, используя объект Presentation.
## **Пример**
``` csharp

 //Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation("Test.pptx"))

{

   // Try to search by layout slide type

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // The situation when a presentation doesn't contain some type of layouts.

     // Technographics.pptx presentation only contains Blank and Custom layout types.

     // But layout slides with Custom types has different slide names,

     // like "Title", "Title and Content", etc. And it is possible to use these

     // names for layout slide selection.

     // Also it is possible to use the set of placeholder shape types. For example,

     // Title slide should have only Title pleceholder type, etc.

     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

     {

       if (titleAndObjectLayoutSlide.Name == "Title and Object")

       {

          layoutSlide = titleAndObjectLayoutSlide;

          break;

       }

      }

      if (layoutSlide == null)

      {

         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

         {

            if (titleLayoutSlide.Name == "Title")

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

                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

             }

          }

      }

  }

  //Adding empty slide with added layout slide

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Save presentation

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Для получения дополнительной информации посетите [Применение или изменение макетов слайдов в .NET](/slides/ru/net/slide-layout/).
{{% /alert %}}