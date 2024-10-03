---
title: Добавить слайды макета в презентацию
type: docs
weight: 20
url: /ru/net/add-layout-slides-to-presentation/
---

Aspose.Slides для .NET позволяет разработчикам добавлять новые слайды макета в презентацию. Чтобы добавить слайд макета, выполните следующие шаги:

- Создайте экземпляр класса Presentation
- Получите коллекцию мастер-слайдов
- Попробуйте найти существующие слайды макета, чтобы проверить, доступен ли требуемый слайд в коллекции слайдов макета
- Добавьте новый слайд макета, если желаемый макет недоступен
- Добавьте пустой слайд с новым слайдом макета
- Наконец, запишите файл презентации, используя объект Presentation
## **Пример**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Добавление слайдов макета.pptx";

//Создайте экземпляр класса Presentation, представляющий файл презентации

using (Presentation p = new Presentation(FileName))

{

    // Попробуйте найти слайд по типу макета

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Ситуация, когда в презентации отсутствуют некоторые типы макетов.

        // Презентация Technographics.pptx содержит только макеты типа Blank и Custom.

        // Но слайды макета с типами Custom имеют разные имена слайдов,

        // такие как "Заголовок", "Заголовок и содержимое" и т.д. И эти

        // имена можно использовать для выбора слайдов макета.

        // Также можно использовать набор типов заполняемых фигур. Например,

        // Слайд заголовка должен иметь только тип заполнителя для Заголовка и т.д.

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

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Скачать пример кода**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Скачать работающий пример**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Добавление слайдов макета в презентацию](/slides/ru/net/adding-and-editing-slides/#working-with-slide-size-and-layout).

{{% /alert %}}