---
title: Lägg till layoutbild till presentation
type: docs
weight: 10
url: /sv/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET tillåter utvecklare att lägga till nya Layout‑bilder i en presentation. För att lägga till en Layout‑bild, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Få åtkomst till Master‑bildsamlingen
- Försök hitta befintliga Layout‑bilder för att se om den önskade redan finns i Layout‑bildsamlingen eller inte
- Lägg till en ny Layout‑bild om den önskade layouten inte är tillgänglig
- Lägg till en tom bild med den nyligen tillagda Layout‑bilden
- Skriv slutligen presentationsfilen med hjälp av Presentation‑objektet.

## **Exempel**
``` csharp

 //Instansiera Presentation-klassen som representerar presentationsfilen

using (Presentation p = new Presentation("Test.pptx"))

{

   // Försök att söka efter layout‑bildtyp

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // Situationen när en presentation inte innehåller vissa layouttyper.

     // Technographics.pptx‑presentationen innehåller endast tomma och anpassade layouttyper.

     // Men layoutbilder med anpassade typer har olika bildnamn,

     // t.ex. "Title", "Title and Content" osv. Och det är möjligt att använda dessa

     // namn för val av layoutbild.

     // Det är också möjligt att använda uppsättningen av platshållar‑formtyper. Till exempel,

     // Titel‑bilden bör bara ha Title‑platshållartyp, osv.

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

  // Lägger till tom bild med den tillagda layoutbilden

  p.Slides.InsertEmptySlide(0, layoutSlide);

  // Spara presentationen

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **Ladda ner körande exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Ladda ner exempelkod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
För mer information, besök [Använda eller ändra bildlayouter i .NET](/slides/sv/net/slide-layout/).
{{% /alert %}}