---
title: Lay-outdia's toevoegen aan presentatie
type: docs
weight: 20
url: /nl/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET stelt ontwikkelaars in staat om nieuwe lay-outdia's aan een presentatie toe te voegen. Volg de onderstaande stappen om een lay-outdia toe te voegen:

- Maak een instantie van de klasse Presentation aan
- Open de collectie Master Slides
- Zoek naar bestaande lay-outdia's om te zien of de gewenste al aanwezig is in de collectie
- Voeg een nieuwe lay-outdia toe als de gewenste lay-out niet beschikbaar is
- Voeg een lege dia toe met de zojuist toegevoegde lay-outdia
- Schrijf ten slotte het presentatiebestand weg met het Presentation-object
## **Voorbeeld**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantie van de Presentation-klasse maken die het presentatiebestand vertegenwoordigt

using (Presentation p = new Presentation(FileName))

{

    //Probeer te zoeken op type lay-outdia

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        //De situatie waarin een presentatie niet alle soorten lay-outs bevat.

        //De presentatie Technographics.pptx bevat alleen lege en aangepaste lay-outtypes.

        //Maar lay-outdia's met aangepaste types hebben verschillende dia-namen,

        //zoals "Title", "Title and Content", enz. En het is mogelijk om deze

        //namen te gebruiken voor het selecteren van lay-outdia's.

        //Ook is het mogelijk om de set van placeholder-vormtypes te gebruiken. Bijvoorbeeld,

        //Een Titel-dia moet alleen het Title placeholder-type hebben, enz.

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

    //Lege dia toevoegen met de toegevoegde lay-outdia 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Presentatie opslaan    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Uitvoerende voorbeeld downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Apply or Change Slide Layouts in .NET](/slides/nl/net/slide-layout/).

{{% /alert %}}