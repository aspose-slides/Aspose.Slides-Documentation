---
title: Layout slide-ok hozzáadása a bemutatóhoz
type: docs
weight: 20
url: /hu/net/add-layout-slides-to-presentation/
---
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy új Layout slide-ot adjanak hozzá a bemutatóhoz. Az Layout slide hozzáadásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Hozzáférjen a Master Slide gyűjteményhez
- Próbálja megtalálni a meglévő Layout slide-okat, hogy lássa, a szükséges már elérhető-e a Layout Slide gyűjteményben
- Adjon hozzá egy új Layout slide-ot, ha a kívánt elrendezés nem áll rendelkezésre
- Adjon hozzá egy üres diát az újonnan hozzáadott Layout slide-dal
- Végül írja ki a bemutató fájlt a Presentation objektummal

## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Példányosítsa a Presentation osztályt, amely a bemutató fájlt képviseli

using (Presentation p = new Presentation(FileName))

{

    // Próbálja meg keresni a layout slide típus alapján

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // Az a helyzet, amikor egy bemutató nem tartalmaz bizonyos típusú elrendezéseket.

        // A Technographics.pptx bemutató csak Blank és Custom elrendezés típusokat tartalmaz.

        // De a Custom típusú layout slide-ok különböző dia nevekkel rendelkeznek,

        // például "Title", "Title and Content" stb. És lehetséges ezeket

        // neveket a layout slide kiválasztásához.

        // Szintén lehetséges a placeholder alakzat típusok halmazát használni. Például,

        // A cím dia csak Title placeholder típussal rendelkezhet, stb.

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

    //Üres dia hozzáadása a hozzáadott layout slide-dal 
    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Bemutató mentése    
    p.Save(FileName, SaveFormat.Pptx);

}

``` 

## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)

## **Futtatható példa letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
További részletekért látogassa meg a [Diaelrendezések alkalmazása vagy módosítása .NET-ben](/slides/hu/net/slide-layout/) oldalt.
{{% /alert %}}