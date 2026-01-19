---
title: Добавить слайды макета в презентацию
type: docs
weight: 20
url: /ru/net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NET позволяет разработчикам добавлять новые слайды макета в презентацию. Чтобы добавить слайд макета, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите доступ к коллекции слайдов‑мастеров
- Попробуйте найти существующие слайды макета, чтобы проверить, доступен ли требуемый в коллекции слайдов макета
- Добавьте новый слайд макета, если нужный макет недоступен
- Добавьте пустой слайд с только что добавленным слайдом макета
- Наконец, запишите файл презентации, используя объект Presentation
## **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

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

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Для получения дополнительных сведений посетите [Применить или изменить макеты слайдов в .NET](/slides/ru/net/slide-layout/).

{{% /alert %}}