---
title: Elrendezési dia hozzáadása a bemutatóhoz
type: docs
weight: 10
url: /hu/net/add-layout-slide-to-presentation/
---
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy új Elrendezési diát adjanak a bemutatóhoz. Az Elrendezési dia hozzáadásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Érje el a Master Slide gyűjteményt
- Próbálja megtalálni a meglévő Elrendezési diákat, hogy lássa, a kívánt már elérhető-e az Layout Slide gyűjteményben vagy sem
- Adjon hozzá egy új Elrendezési diát, ha a kívánt elrendezés nem elérhető
- Adjon hozzá egy üres diát az újból hozzáadott Elrendezési diával
- Végül írja ki a bemutató fájlt a Presentation objektum segítségével.

## **Példa**
``` csharp

 //Példányosítsa a Presentation osztályt, amely a bemutató fájlt képviseli

using (Presentation p = new Presentation("Test.pptx"))

{

   //Próbálja meg keresni az elrendezési dia típusa alapján

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     //Az a helyzet, amikor a bemutató nem tartalmaz bizonyos típusú elrendezéseket.

     //A Technographics.pptx bemutató csak Üres és Egyéni elrendezés típusokat tartalmaz.

     //Azonban az Egyéni típusú elrendezési diák különböző dianevekkel rendelkeznek,

     //például "Title", "Title and Content" stb. És lehetséges ezeket használni

     //neveket az elrendezési dia kiválasztásához.

     //Az is lehetséges, hogy a helyfoglaló alakzat típusok halmazát használjuk. Például,

     //A cím dia csak cím helyfoglaló típussal kell, hogy rendelkezzen, stb.

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

  //Üres dia hozzáadása a hozzáadott elrendezési diával

  //Bemutató mentése

  p.Slides.InsertEmptySlide(0, layoutSlide);

  p.Save("Output.pptx", SaveFormat.Pptx);

}
``` 
## **Futtatható példa letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **Minta kód letöltése**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
További részletekért látogassa meg a [Slide elrendezések alkalmazását vagy módosítását .NET-ben](/slides/hu/net/slide-layout/).
{{% /alert %}}