---
title: Dodaj slajd układu do prezentacji
type: docs
weight: 10
url: /pl/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET umożliwia programistom dodawanie nowych slajdów układu w prezentacji. Aby dodać slajd układu, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj dostęp do kolekcji Master Slide
- Spróbuj znaleźć istniejące slajdy układu, aby sprawdzić, czy wymagany jest już dostępny w kolekcji Layout Slide, czy nie
- Dodaj nowy slajd układu, jeśli żądany układ jest niedostępny
- Dodaj pusty slajd z nowo dodanym slajdem układu
- Na koniec zapisz plik prezentacji przy użyciu obiektu Presentation.
## **Przykład**
``` csharp

 //Instancjuj klasę Presentation, która reprezentuje plik prezentacji

using (Presentation p = new Presentation("Test.pptx"))

{

   // Spróbuj wyszukać według typu slajdu układu

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Sytuacja, gdy prezentacja nie zawiera niektórych typów układów.

     // Prezentacja Technographics.pptx zawiera tylko typy układów Blank i Custom.

     // Jednak slajdy układu typu Custom mają różne nazwy slajdów,

     // takie jak "Title", "Title and Content", itd. i można ich używać

     // jako nazw do wyboru slajdu układu.

     // Można również użyć zestawu typów kształtów zastępczych. Na przykład,

     // slajd tytułowy powinien mieć tylko typ zastępczy Title, itp.

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

  //Dodawanie pustego slajdu z dodanym slajdem układu

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Zapisz prezentację

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Pobierz działający przykład**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
Aby uzyskać więcej informacji, odwiedź [Zastosowanie lub zmiana układów slajdów w .NET](/slides/pl/net/slide-layout/).
{{% /alert %}}