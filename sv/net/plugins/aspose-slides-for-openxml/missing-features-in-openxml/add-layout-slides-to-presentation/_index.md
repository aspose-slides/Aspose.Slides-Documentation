---
title: Lägg till layoutbilder i presentationen
type: docs
weight: 20
url: /sv/net/add-layout-slides-to-presentation/
---
Aspose.Slides för .NET gör det möjligt för utvecklare att lägga till nya Layout Slides i en presentation. För att lägga till en Layout Slide, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Åtkomst till Master Slide‑samlingen
- Försök hitta befintliga Layout Slides för att se om den önskade redan finns i Layout Slide‑samlingen eller inte
- Lägg till en ny Layout Slide om den önskade layouten inte finns
- Lägg till en tom bild med den nyligen tillagda Layout Slide
- Spara slutligen presentationsfilen med Presentation‑objektet
## **Exempel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instansiera Presentation‑klassen som representerar presentationsfilen

using (Presentation p = new Presentation(FileName))

{

    // Försök att söka efter layout‑bildtyp

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Situationen när en presentation inte innehåller vissa typer av layouter.

        // Technographics.pptx‑presentationen innehåller endast tomma och anpassade layouttyper.

        // Men layoutbilder med anpassade typer har olika bildnamn,

        // som "Title", "Title and Content" osv. Och det är möjligt att använda dessa

        // namn för val av layoutbild.

        // Det är också möjligt att använda uppsättningen av platshållarformtyper. Till exempel,

        // Titelsidan bör bara ha en Title‑platshållartyp, osv.

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

    //Lägger till en tom bild med den tillagda layoutbilden 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Spara presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körande exempel**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

För mer information, besök [Använda eller ändra bildlayouter i .NET](/slides/sv/net/slide-layout/).

{{% /alert %}}