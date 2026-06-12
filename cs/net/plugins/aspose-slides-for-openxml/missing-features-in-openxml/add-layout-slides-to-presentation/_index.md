---
title: Přidat snímky rozložení do prezentace
type: docs
weight: 20
url: /cs/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET umožňuje vývojářům přidávat nové snímky rozložení do prezentace. Pro přidání snímku rozložení postupujte podle následujících kroků:

- Vytvořte instanci třídy Presentation
- Získejte kolekci hlavních snímků
- Zkuste najít existující snímky rozložení, abyste zjistili, zda požadovaný již není v kolekci Layout Slide
- Přidejte nový snímek rozložení, pokud požadované rozložení není k dispozici
- Přidejte prázdný snímek s nově přidaným rozložením
- Nakonec zapište soubor prezentace pomocí objektu Presentation

## **Příklad**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Vytvořte instanci třídy Presentation, která představuje soubor prezentace

using (Presentation p = new Presentation(FileName))

{

    // Pokuste se vyhledat podle typu snímku rozložení

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Situace, kdy prezentace neobsahuje některé typy rozložení.

        // Prezentace Technographics.pptx obsahuje pouze typy rozložení Blank a Custom.

        // Ale snímky rozložení s typy Custom mají různé názvy snímků,

        // například "Title", "Title and Content", atd. A je možné použít tyto

        // názvy pro výběr snímku rozložení.

        // Také je možné použít sadu typů placeholder tvarů. Například,

        // Snímek Title by měl mít pouze typ placeholder Title, atd.

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

    //Přidání prázdného snímku s přidaným snímkem rozložení 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Uložit prezentaci    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Stáhnout ukázkový kód**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Stáhnout spuštěný příklad**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

Pro více informací navštivte [Apply or Change Slide Layouts in .NET](/slides/cs/net/slide-layout/).

{{% /alert %}}