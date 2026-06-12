---
title: Lay-outdia toevoegen aan presentatie
type: docs
weight: 10
url: /nl/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET stelt ontwikkelaars in staat om nieuwe lay-outdia's toe te voegen aan een presentatie. Volg de onderstaande stappen om een lay-outdia toe te voegen:

- Maak een instantie van de klasse Presentation
- Toegang tot de Master-dia-collectie
- Probeer bestaande lay-outdia's te vinden om te controleren of de gewenste al beschikbaar is in de lay-outdia-collectie
- Voeg een nieuwe lay-outdia toe als de gewenste lay-out niet beschikbaar is
- Voeg een lege dia toe met de zojuist toegevoegde lay-outdia
- Schrijf tenslotte het presentatiebestand weg met behulp van het Presentation-object.
## **Voorbeeld**
``` csharp

 //Instantieer de Presentation-klasse die het presentatiebestand voorstelt

using (Presentation p = new Presentation("Test.pptx"))

{

   // Zoek op basis van lay-outdia-type

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // De situatie wanneer een presentatie bepaalde type lay-outs niet bevat.

     // De presentatie Technographics.pptx bevat alleen lege en aangepaste lay-outtypes.

     // Maar lay-outdia's met aangepaste types hebben verschillende dia-namen,

     // zoals "Title", "Title and Content", enz. En het is mogelijk om deze

     // namen te gebruiken voor het kiezen van een lay-outdia.

     // Het is ook mogelijk om de set van placeholder-vormtypes te gebruiken. Bijvoorbeeld,

     // Een titel-dia moet alleen een Titel-placeholdertype hebben, enz.

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

  // Voeg een lege dia toe met de toegevoegde lay-outdia

  p.Slides.InsertEmptySlide(0, layoutSlide);

  // Sla de presentatie op

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Download werkend voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Passen lay-outdia's toe of wijzigen in .NET](/slides/nl/net/slide-layout/).

{{% /alert %}}